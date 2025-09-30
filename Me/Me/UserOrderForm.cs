using System.ComponentModel;
using System.Data;
using Npgsql;

namespace Me;

public partial class UserOrderForm : Form
{
    public UserOrderForm()
    {
        InitializeComponent();
    }
    private string connectionString =  "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
        private string currentUser;
        private DataTable productsTable;
        private Container components;

        public UserOrderForm(string username = null)
        {
            InitializeComponent();
            currentUser = username;
            
            // Проверяем авторизацию
            if (string.IsNullOrEmpty(currentUser))
            {
                MessageBox.Show("Для создания заявки необходимо авторизоваться.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            
            LoadProducts();
            GenerateOrderNumber();
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (!string.IsNullOrEmpty(currentUser))
            {
                txtUsername.Text = currentUser;
                txtUsername.Enabled = false;
                
                // Загружаем контактные данные пользователя
                LoadUserContactInfo();
            }
            
            dtpOrderDate.Value = DateTime.Now;
            cmbStatus.SelectedItem = "Новая";
            cmbStatus.Enabled = false; // Статус "Новая" устанавливается автоматически
        }

        private void LoadUserContactInfo()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ""Email"", ""Телефон"" FROM public.""Users"" 
                           WHERE ""Логин"" = @username";
                    
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", currentUser);
                    
                    NpgsqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtEmail.Text = reader["Email"]?.ToString() ?? "";
                        txtPhone.Text = reader["Телефон"]?.ToString() ?? "";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Не блокируем создание заявки при ошибке загрузки контактов
                Console.WriteLine($"Ошибка загрузки контактных данных: {ex.Message}");
            }
        }

        private void GenerateOrderNumber()
        {
            string orderNumber = "ORD-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            txtOrderNumber.Text = orderNumber;
        }

        private void LoadProducts()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ""НаименованиеПродукции"", ""МинСтоимостьДляПартнера"", 
                                   ""ТипПродукции"", ""ОсновнойМатериал""
                            FROM public.""Products"" 
                            ORDER BY ""НаименованиеПродукции""";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    productsTable = new DataTable();
                    adapter.Fill(productsTable);

                    cmbProductName.DataSource = productsTable;
                    cmbProductName.DisplayMember = "НаименованиеПродукции";
                    cmbProductName.ValueMember = "НаименованиеПродукции";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продукции: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)cmbProductName.SelectedItem;
                decimal price = Convert.ToDecimal(selectedRow["МинСтоимостьДляПартнера"]);
                txtPrice.Text = price.ToString("F2");
                CalculateTotal();
            }
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price) && nudQuantity.Value > 0)
            {
                decimal total = price * nudQuantity.Value;
                txtTotalAmount.Text = total.ToString("F2");
            }
            else
            {
                txtTotalAmount.Text = "0.00";
            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                SaveOrder();
                MessageBox.Show("Заявка успешно создана!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заявки: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("Номер заявки не может быть пустым.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Введите логин пользователя.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbProductName.SelectedItem == null)
            {
                MessageBox.Show("Выберите продукцию.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше 0.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон для связи.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SaveOrder()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                string query = @"INSERT INTO public.""UserOrders"" 
                               (""НомерЗаявки"", ""ЛогинПользователя"", ""НаименованиеПродукции"", 
                                ""Количество"", ""Статус"", ""Комментарий"", ""Телефон"", ""Email"") 
                               VALUES (@orderNumber, @username, @productName, 
                                       @quantity, @status, @comment, @phone, @email)";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderNumber", txtOrderNumber.Text);
                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@productName", cmbProductName.SelectedValue.ToString());
                command.Parameters.AddWithValue("@quantity", (int)nudQuantity.Value);
                command.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                command.Parameters.AddWithValue("@comment", string.IsNullOrWhiteSpace(txtComment.Text) ? (object)DBNull.Value : txtComment.Text);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);

                command.ExecuteNonQuery();

                // Запись в историю статусов
                LogStatusChange(txtOrderNumber.Text, null, cmbStatus.SelectedItem.ToString(), "Система", "Создание заявки");
            }
        }

        private void LogStatusChange(string orderNumber, string oldStatus, string newStatus, string changedBy, string comment)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO public.""OrderStatusHistory"" 
                               (""НомерЗаявки"", ""СтарыйСтатус"", ""НовыйСтатус"", ""КтоИзменил"", ""Комментарий"") 
                               VALUES (@orderNumber, @oldStatus, @newStatus, @changedBy, @comment)";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderNumber", orderNumber);
                command.Parameters.AddWithValue("@oldStatus", string.IsNullOrEmpty(oldStatus) ? (object)DBNull.Value : oldStatus);
                command.Parameters.AddWithValue("@newStatus", newStatus);
                command.Parameters.AddWithValue("@changedBy", changedBy);
                command.Parameters.AddWithValue("@comment", string.IsNullOrWhiteSpace(comment) ? (object)DBNull.Value : comment);

                command.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
}