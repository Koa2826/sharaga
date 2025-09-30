using System.ComponentModel;

namespace Me;

partial class LoginForm
{
   private TextBox txtUsername;
    private TextBox txtPassword;
    private TextBox txtCaptcha;
    private Button btnLogin;
    private Button btnGuest;
    private Button btnRegister;
    private Button btnRefreshCaptcha;
    private CheckBox chkShowPassword;
    private Label lblUsername;
    private Label lblPassword;
    private Label lblCaptcha;
    private Label lblBlockMessage;
    private PictureBox picCaptcha;
    private Label lblTitle;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(450, 400);
        this.Text = "Авторизация - Комфорт";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.BackColor = Color.White;

        // Заголовок
        lblTitle = new Label();
        lblTitle.Text = "Производственная компания Комфорт";
        lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
        lblTitle.Size = new Size(400, 30);
        lblTitle.Location = new Point(25, 20);
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblTitle.ForeColor = Color.DarkBlue;

        // Логин
        lblUsername = new Label();
        lblUsername.Text = "Логин:";
        lblUsername.Location = new Point(50, 70);
        lblUsername.Size = new Size(80, 20);
        lblUsername.Font = new Font("Arial", 9, FontStyle.Regular);

        txtUsername = new TextBox();
        txtUsername.Location = new Point(130, 70);
        txtUsername.Size = new Size(250, 20);
        txtUsername.Font = new Font("Arial", 9, FontStyle.Regular);
        txtUsername.KeyPress += new KeyPressEventHandler(txtUsername_KeyPress);

        // Пароль
        lblPassword = new Label();
        lblPassword.Text = "Пароль:";
        lblPassword.Location = new Point(50, 100);
        lblPassword.Size = new Size(80, 20);
        lblPassword.Font = new Font("Arial", 9, FontStyle.Regular);

        txtPassword = new TextBox();
        txtPassword.Location = new Point(130, 100);
        txtPassword.Size = new Size(250, 20);
        txtPassword.Font = new Font("Arial", 9, FontStyle.Regular);
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.KeyPress += new KeyPressEventHandler(txtPassword_KeyPress);

        // Показать пароль
        chkShowPassword = new CheckBox();
        chkShowPassword.Text = "Показать пароль";
        chkShowPassword.Location = new Point(130, 125);
        chkShowPassword.Size = new Size(150, 20);
        chkShowPassword.Font = new Font("Arial", 8, FontStyle.Regular);
        chkShowPassword.CheckedChanged += new EventHandler(chkShowPassword_CheckedChanged);

        // Капча
        lblCaptcha = new Label();
        lblCaptcha.Text = "Капча:";
        lblCaptcha.Location = new Point(50, 155);
        lblCaptcha.Size = new Size(80, 20);
        lblCaptcha.Font = new Font("Arial", 9, FontStyle.Regular);
        lblCaptcha.Visible = false;

        txtCaptcha = new TextBox();
        txtCaptcha.Location = new Point(130, 155);
        txtCaptcha.Size = new Size(100, 20);
        txtCaptcha.Font = new Font("Arial", 9, FontStyle.Regular);
        txtCaptcha.Visible = false;
        txtCaptcha.KeyPress += new KeyPressEventHandler(txtCaptcha_KeyPress);

        picCaptcha = new PictureBox();
        picCaptcha.Location = new Point(240, 155);
        picCaptcha.Size = new Size(120, 40);
        picCaptcha.BorderStyle = BorderStyle.FixedSingle;
        picCaptcha.Visible = false;

        btnRefreshCaptcha = new Button();
        btnRefreshCaptcha.Text = "Обновить";
        btnRefreshCaptcha.Location = new Point(240, 200);
        btnRefreshCaptcha.Size = new Size(80, 25);
        btnRefreshCaptcha.Font = new Font("Arial", 8, FontStyle.Regular);
        btnRefreshCaptcha.Visible = false;
        btnRefreshCaptcha.Click += new EventHandler(btnRefreshCaptcha_Click);

        // Сообщение о блокировке
        lblBlockMessage = new Label();
        lblBlockMessage.Text = "";
        lblBlockMessage.Location = new Point(50, 230);
        lblBlockMessage.Size = new Size(350, 20);
        lblBlockMessage.ForeColor = Color.Red;
        lblBlockMessage.Font = new Font("Arial", 9, FontStyle.Bold);
        lblBlockMessage.TextAlign = ContentAlignment.MiddleCenter;
        lblBlockMessage.Visible = false;

        // Кнопки
        btnLogin = new Button();
        btnLogin.Text = "Войти";
        btnLogin.Location = new Point(130, 260);
        btnLogin.Size = new Size(100, 35);
        btnLogin.Font = new Font("Arial", 10, FontStyle.Bold);
        btnLogin.BackColor = Color.LightBlue;
        btnLogin.Click += new EventHandler(btnLogin_Click);

        btnGuest = new Button();
        btnGuest.Text = "Войти как гость";
        btnGuest.Location = new Point(240, 260);
        btnGuest.Size = new Size(100, 35);
        btnGuest.Font = new Font("Arial", 9, FontStyle.Regular);
        btnGuest.BackColor = Color.LightGreen;
        btnGuest.Click += new EventHandler(btnGuest_Click);

        btnRegister = new Button();
        btnRegister.Text = "Регистрация";
        btnRegister.Location = new Point(175, 305);
        btnRegister.Size = new Size(120, 30);
        btnRegister.Font = new Font("Arial", 9, FontStyle.Regular);
        btnRegister.BackColor = Color.LightYellow;
        btnRegister.Click += new EventHandler(btnRegister_Click);

        // Информационная подпись
        Label lblInfo = new Label();
        lblInfo.Text = "Гостевой доступ: только просмотр продукции";
        lblInfo.Location = new Point(50, 350);
        lblInfo.Size = new Size(350, 20);
        lblInfo.ForeColor = Color.Gray;
        lblInfo.Font = new Font("Arial", 8, FontStyle.Italic);
        lblInfo.TextAlign = ContentAlignment.MiddleCenter;

        // Добавление элементов на форму
        this.Controls.Add(lblTitle);
        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(chkShowPassword);
        this.Controls.Add(lblCaptcha);
        this.Controls.Add(txtCaptcha);
        this.Controls.Add(picCaptcha);
        this.Controls.Add(btnRefreshCaptcha);
        this.Controls.Add(lblBlockMessage);
        this.Controls.Add(btnLogin);
        this.Controls.Add(btnGuest);
        this.Controls.Add(btnRegister);
        this.Controls.Add(lblInfo);
    }

    #endregion
}