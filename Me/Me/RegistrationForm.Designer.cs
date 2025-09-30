using System.ComponentModel;

namespace Me;

partial class RegistrationForm
{
    private TextBox txtFullName;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private TextBox txtConfirmPassword;
    private TextBox txtEmail;
    private TextBox txtPhone;
    private Button btnRegister;
    private Button btnCancel;
    private CheckBox chkShowPassword;
    private Label lblFullName;
    private Label lblUsername;
    private Label lblPassword;
    private Label lblConfirmPassword;
    private Label lblEmail;
    private Label lblPhone;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 350);
        this.Text = "Регистрация нового пользователя";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // ФИО
        lblFullName = new Label();
        lblFullName.Text = "ФИО:*";
        lblFullName.Location = new Point(20, 20);
        lblFullName.Size = new Size(100, 20);

        txtFullName = new TextBox();
        txtFullName.Location = new Point(120, 20);
        txtFullName.Size = new Size(250, 20);

        // Логин
        lblUsername = new Label();
        lblUsername.Text = "Логин:*";
        lblUsername.Location = new Point(20, 50);
        lblUsername.Size = new Size(100, 20);

        txtUsername = new TextBox();
        txtUsername.Location = new Point(120, 50);
        txtUsername.Size = new Size(250, 20);

        // Пароль
        lblPassword = new Label();
        lblPassword.Text = "Пароль:*";
        lblPassword.Location = new Point(20, 80);
        lblPassword.Size = new Size(100, 20);

        txtPassword = new TextBox();
        txtPassword.Location = new Point(120, 80);
        txtPassword.Size = new Size(250, 20);
        txtPassword.UseSystemPasswordChar = true;

        // Подтверждение пароля
        lblConfirmPassword = new Label();
        lblConfirmPassword.Text = "Подтверждение:*";
        lblConfirmPassword.Location = new Point(20, 110);
        lblConfirmPassword.Size = new Size(100, 20);

        txtConfirmPassword = new TextBox();
        txtConfirmPassword.Location = new Point(120, 110);
        txtConfirmPassword.Size = new Size(250, 20);
        txtConfirmPassword.UseSystemPasswordChar = true;

        // Показать пароль
        chkShowPassword = new CheckBox();
        chkShowPassword.Text = "Показать пароль";
        chkShowPassword.Location = new Point(120, 135);
        chkShowPassword.Size = new Size(150, 20);
        chkShowPassword.CheckedChanged += new EventHandler(chkShowPassword_CheckedChanged);

        // Email
        lblEmail = new Label();
        lblEmail.Text = "Email:";
        lblEmail.Location = new Point(20, 165);
        lblEmail.Size = new Size(100, 20);

        txtEmail = new TextBox();
        txtEmail.Location = new Point(120, 165);
        txtEmail.Size = new Size(250, 20);

        // Телефон
        lblPhone = new Label();
        lblPhone.Text = "Телефон:";
        lblPhone.Location = new Point(20, 195);
        lblPhone.Size = new Size(100, 20);

        txtPhone = new TextBox();
        txtPhone.Location = new Point(120, 195);
        txtPhone.Size = new Size(250, 20);

        // Кнопки
        btnRegister = new Button();
        btnRegister.Text = "Зарегистрироваться";
        btnRegister.Location = new Point(120, 240);
        btnRegister.Size = new Size(120, 30);
        btnRegister.Click += new EventHandler(btnRegister_Click);

        btnCancel = new Button();
        btnCancel.Text = "Отмена";
        btnCancel.Location = new Point(250, 240);
        btnCancel.Size = new Size(120, 30);
        btnCancel.Click += new EventHandler(btnCancel_Click);

        // Информация
        Label lblInfo = new Label();
        lblInfo.Text = "* - обязательные поля";
        lblInfo.Location = new Point(20, 280);
        lblInfo.Size = new Size(200, 20);
        lblInfo.ForeColor = System.Drawing.Color.Gray;

        // Добавление элементов на форму
        this.Controls.Add(lblFullName);
        this.Controls.Add(txtFullName);
        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(lblConfirmPassword);
        this.Controls.Add(txtConfirmPassword);
        this.Controls.Add(chkShowPassword);
        this.Controls.Add(lblEmail);
        this.Controls.Add(txtEmail);
        this.Controls.Add(lblPhone);
        this.Controls.Add(txtPhone);
        this.Controls.Add(btnRegister);
        this.Controls.Add(btnCancel);
        this.Controls.Add(lblInfo);
    }
}