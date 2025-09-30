using System.ComponentModel;
using Npgsql;

namespace Me;

public partial class LoginForm : Form
{
    private string connectionString =  "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
        private int failedAttempts = 0;
        private bool captchaRequired = false;
        private string currentCaptcha;
        private DateTime? blockUntil = null;

        public LoginForm()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblCaptcha.Visible = captchaRequired;
            txtCaptcha.Visible = captchaRequired;
            btnRefreshCaptcha.Visible = captchaRequired;
            picCaptcha.Visible = captchaRequired;

            if (blockUntil.HasValue && DateTime.Now < blockUntil.Value)
            {
                TimeSpan remaining = blockUntil.Value - DateTime.Now;
                lblBlockMessage.Text = $"Система заблокирована. Осталось: {remaining:mm\\:ss}";
                lblBlockMessage.Visible = true;
                btnLogin.Enabled = false;
                btnGuest.Enabled = false;
                btnRegister.Enabled = false;
            }
            else
            {
                lblBlockMessage.Visible = false;
                btnLogin.Enabled = true;
                btnGuest.Enabled = true;
                btnRegister.Enabled = true;
                blockUntil = null;
            }

            if (captchaRequired)
            {
                GenerateCaptcha();
            }
        }

        private void GenerateCaptcha()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            currentCaptcha = "";
            
            for (int i = 0; i < 4; i++)
            {
                currentCaptcha += chars[random.Next(chars.Length)];
            }

            // Создание изображения капчи
            Bitmap bitmap = new Bitmap(120, 40);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                
                // Добавление шума
                for (int i = 0; i < 50; i++)
                {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                }

                // Рисование текста
                using (Font font = new Font("Arial", 14, FontStyle.Bold))
                {
                    for (int i = 0; i < currentCaptcha.Length; i++)
                    {
                        float x = 10 + i * 25 + random.Next(-5, 5);
                        float y = random.Next(5, 15);
                        g.DrawString(currentCaptcha[i].ToString(), font, 
                                    Brushes.Black, x, y);
                    }
                }

                // Добавление линий
                for (int i = 0; i < 3; i++)
                {
                    g.DrawLine(Pens.Gray, 
                              random.Next(bitmap.Width), random.Next(bitmap.Height),
                              random.Next(bitmap.Width), random.Next(bitmap.Height));
                }
            }

            picCaptcha.Image = bitmap;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (blockUntil.HasValue && DateTime.Now < blockUntil.Value)
            {
                MessageBox.Show("Система временно заблокирована. Попробуйте позже.", "Блокировка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (captchaRequired && txtCaptcha.Text != currentCaptcha)
            {
                MessageBox.Show("Неверная капча.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                failedAttempts++;
                CheckBlockStatus();
                GenerateCaptcha();
                return;
            }

            // Проверка учетных данных в базе данных
            string userRole;
            if (AuthenticateUser(username, password, out userRole))
            {
                // Запись в историю входа
                LogLoginAttempt(username, true);
                
                MainForm mainForm = new MainForm(username, userRole);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                failedAttempts++;
                LogLoginAttempt(username, false);
                
                if (failedAttempts >= 2)
                {
                    captchaRequired = true;
                }
                
                CheckBlockStatus();
                UpdateUI();
                
                MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckBlockStatus()
        {
            if (failedAttempts >= 3)
            {
                blockUntil = DateTime.Now.AddMinutes(3);
                MessageBox.Show("Слишком много неудачных попыток. Система заблокирована на 3 минуты.", 
                    "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AuthenticateUser(string username, string password, out string role)
        {
            role = null;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ""РольСотрудника"" FROM public.""Users"" 
                           WHERE ""Логин"" = @username AND ""Пароль"" = @password";
                    
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка аутентификации: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LogLoginAttempt(string username, bool success)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO public.""LoginHistory"" 
                                   (""Время"", ""Логин"", ""Успешность"") 
                                   VALUES (NOW(), '{username}', {success})";
                    
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Игнорируем ошибки записи в историю
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            if (registrationForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Регистрация прошла успешно! Теперь вы можете войти в систему.", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
}