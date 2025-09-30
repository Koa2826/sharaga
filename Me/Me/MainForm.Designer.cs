namespace Me;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Button btnProducts;
    private Button btnWorkshops;
    private Button btnOrders;
    private Button btnViewProducts;
    private Button btnExit;
    private Button btnLogout;
    private Label lblUserInfo;
    private Label lblUserRole;
    private Label lblTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 450);
        this.Text = "Производственная компания Комфорт";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;

        // Заголовок
        lblTitle = new Label();
        lblTitle.Text = "Производственная компания Комфорт";
        lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        lblTitle.Size = new Size(400, 30);
        lblTitle.Location = new Point(100, 20);
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;

        // Информация о пользователе
        lblUserInfo = new Label();
        lblUserInfo.Text = "Гость";
        lblUserInfo.Size = new Size(300, 20);
        lblUserInfo.Location = new Point(150, 60);
        lblUserInfo.TextAlign = ContentAlignment.MiddleCenter;
        lblUserInfo.Font = new Font("Arial", 10, FontStyle.Regular);

        lblUserRole = new Label();
        lblUserRole.Text = "Роль: Гость";
        lblUserRole.Size = new Size(300, 20);
        lblUserRole.Location = new Point(150, 85);
        lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
        lblUserRole.Font = new Font("Arial", 9, FontStyle.Italic);

        // Кнопка просмотра продукции (доступна всем)
        btnViewProducts = new Button();
        btnViewProducts.Text = "Просмотр продукции";
        btnViewProducts.Size = new Size(200, 40);
        btnViewProducts.Location = new Point(200, 120);
        btnViewProducts.BackColor = Color.LightBlue;
        btnViewProducts.Click += new EventHandler(btnViewProducts_Click);

        // Кнопка цехов (доступна всем)
        btnWorkshops = new Button();
        btnWorkshops.Text = "Цеха производства";
        btnWorkshops.Size = new Size(200, 40);
        btnWorkshops.Location = new Point(200, 170);
        btnWorkshops.BackColor = Color.LightGreen;
        btnWorkshops.Click += new EventHandler(btnWorkshops_Click);

        // Кнопка заявок (только авторизованные)
        btnOrders = new Button();
        btnOrders.Text = "Мои заявки";
        btnOrders.Size = new Size(200, 40);
        btnOrders.Location = new Point(200, 220);
        btnOrders.BackColor = Color.LightYellow;
        btnOrders.Click += new EventHandler(btnOrders_Click);

        // Кнопка управления товарами (только админ)
        btnProducts = new Button();
        btnProducts.Text = "Управление товарами";
        btnProducts.Size = new Size(200, 40);
        btnProducts.Location = new Point(200, 270);
        btnProducts.BackColor = Color.LightCoral;
        btnProducts.Click += new EventHandler(btnProducts_Click);

        // Кнопка выхода из системы
        btnLogout = new Button();
        btnLogout.Text = "Выйти из системы";
        btnLogout.Size = new Size(150, 30);
        btnLogout.Location = new Point(225, 320);
        btnLogout.Click += new EventHandler(btnLogout_Click);

        // Кнопка выхода из приложения
        btnExit = new Button();
        btnExit.Text = "Выход";
        btnExit.Size = new Size(150, 30);
        btnExit.Location = new Point(225, 360);
        btnExit.Click += new EventHandler(btnExit_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblTitle);
        this.Controls.Add(lblUserInfo);
        this.Controls.Add(lblUserRole);
        this.Controls.Add(btnViewProducts);
        this.Controls.Add(btnWorkshops);
        this.Controls.Add(btnOrders);
        this.Controls.Add(btnProducts);
        this.Controls.Add(btnLogout);
        this.Controls.Add(btnExit);
    }
}