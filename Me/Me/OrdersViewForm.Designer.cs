using System.ComponentModel;

namespace Me;

partial class OrdersViewForm
{
   private DataGridView dataGridViewOrders;
    private Button btnCreateOrder;
    private Button btnUpdateStatus;
    private Button btnDeleteOrder;
    private Button btnViewHistory;
    private Button btnBack;
    private TextBox txtSearch;
    private TextBox txtFilterUser;
    private ComboBox cmbFilterStatus;
    private Label lblSearch;
    private Label lblFilterUser;
    private Label lblFilterStatus;
    private Label lblUserRights;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(900, 600);
        this.Text = "Просмотр заявок";
        this.StartPosition = FormStartPosition.CenterScreen;
        
        // В InitializeComponent():
        lblUserRights = new Label();
        lblUserRights.Text = "Права: ";
        lblUserRights.Location = new Point(20, 520);
        lblUserRights.Size = new Size(300, 20);
        lblUserRights.Font = new Font("Arial", 8, FontStyle.Italic);
        this.Controls.Add(lblUserRights);
        
        // Поиск
        lblSearch = new Label();
        lblSearch.Text = "Поиск:";
        lblSearch.Location = new Point(20, 20);
        lblSearch.Size = new Size(50, 20);

        txtSearch = new TextBox();
        txtSearch.Location = new Point(80, 20);
        txtSearch.Size = new Size(200, 20);
        txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

        // Фильтр по пользователю
        lblFilterUser = new Label();
        lblFilterUser.Text = "Пользователь:";
        lblFilterUser.Location = new Point(300, 20);
        lblFilterUser.Size = new Size(80, 20);

        txtFilterUser = new TextBox();
        txtFilterUser.Location = new Point(390, 20);
        txtFilterUser.Size = new Size(150, 20);
        txtFilterUser.TextChanged += new EventHandler(txtFilterUser_TextChanged);

        // Фильтр по статусу
        lblFilterStatus = new Label();
        lblFilterStatus.Text = "Статус:";
        lblFilterStatus.Location = new Point(560, 20);
        lblFilterStatus.Size = new Size(50, 20);

        cmbFilterStatus = new ComboBox();
        cmbFilterStatus.Location = new Point(620, 20);
        cmbFilterStatus.Size = new Size(150, 20);
        cmbFilterStatus.Items.AddRange(new string[] { "Новая", "В обработке", "Подтверждена", "В производстве", "Готово", "Отменена" });
        cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbFilterStatus.SelectedIndexChanged += new EventHandler(cmbFilterStatus_SelectedIndexChanged);

        // DataGridView
        dataGridViewOrders = new DataGridView();
        dataGridViewOrders.Location = new Point(20, 60);
        dataGridViewOrders.Size = new Size(860, 400);
        dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewOrders.ReadOnly = true;
        dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Кнопки
        btnCreateOrder = new Button();
        btnCreateOrder.Text = "Создать заявку";
        btnCreateOrder.Location = new Point(20, 480);
        btnCreateOrder.Size = new Size(120, 30);
        btnCreateOrder.Click += new EventHandler(btnCreateOrder_Click);

        btnUpdateStatus = new Button();
        btnUpdateStatus.Text = "Изменить статус";
        btnUpdateStatus.Location = new Point(150, 480);
        btnUpdateStatus.Size = new Size(120, 30);
        btnUpdateStatus.Click += new EventHandler(btnUpdateStatus_Click);

        btnViewHistory = new Button();
        btnViewHistory.Text = "История статусов";
        btnViewHistory.Location = new Point(280, 480);
        btnViewHistory.Size = new Size(120, 30);
        btnViewHistory.Click += new EventHandler(btnViewHistory_Click);

        btnDeleteOrder = new Button();
        btnDeleteOrder.Text = "Удалить заявку";
        btnDeleteOrder.Location = new Point(410, 480);
        btnDeleteOrder.Size = new Size(120, 30);
        btnDeleteOrder.Click += new EventHandler(btnDeleteOrder_Click);

        btnBack = new Button();
        btnBack.Text = "Назад";
        btnBack.Location = new Point(760, 480);
        btnBack.Size = new Size(120, 30);
        btnBack.Click += new EventHandler(btnBack_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblSearch);
        this.Controls.Add(txtSearch);
        this.Controls.Add(lblFilterUser);
        this.Controls.Add(txtFilterUser);
        this.Controls.Add(lblFilterStatus);
        this.Controls.Add(cmbFilterStatus);
        this.Controls.Add(dataGridViewOrders);
        this.Controls.Add(btnCreateOrder);
        this.Controls.Add(btnUpdateStatus);
        this.Controls.Add(btnViewHistory);
        this.Controls.Add(btnDeleteOrder);
        this.Controls.Add(btnBack);
    }
}