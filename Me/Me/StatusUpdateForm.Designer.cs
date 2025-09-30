using System.ComponentModel;

namespace Me;

partial class StatusUpdateForm
{
     private Label lblOrderNumber;
    private Label lblCurrentStatus;
    private ComboBox cmbNewStatus;
    private Label lblNewStatus;
    private TextBox txtComment;
    private Label lblComment;
    private Button btnUpdateStatus;
    private Button btnCancel;
    private DataGridView dataGridViewHistory;
    private Label lblHistory;
    private Label lblOrderInfo;
    private TextBox txtCustomer;
    private TextBox txtProduct;
    private TextBox txtQuantity;
    private TextBox txtPrice;
    private TextBox txtTotalAmount;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private TextBox txtCustomerComment;
    private Label lblCustomer;
    private Label lblProduct;
    private Label lblQuantity;
    private Label lblPrice;
    private Label lblTotalAmount;
    private Label lblPhone;
    private Label lblEmail;
    private Label lblCustomerComment;
    private Label lblValidation;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 700);
        this.Text = "Изменение статуса заявки";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Информация о заявке
        lblOrderInfo = new Label();
        lblOrderInfo.Text = "Информация о заявке:";
        lblOrderInfo.Location = new Point(20, 20);
        lblOrderInfo.Size = new Size(150, 20);
        lblOrderInfo.Font = new Font("Arial", 9, FontStyle.Bold);

        // Номер заявки
        lblOrderNumber = new Label();
        lblOrderNumber.Text = "Заявка: ";
        lblOrderNumber.Location = new Point(20, 50);
        lblOrderNumber.Size = new Size(400, 20);
        lblOrderNumber.Font = new Font("Arial", 10, FontStyle.Bold);

        // Текущий статус
        lblCurrentStatus = new Label();
        lblCurrentStatus.Text = "Текущий статус: ";
        lblCurrentStatus.Location = new Point(20, 80);
        lblCurrentStatus.Size = new Size(200, 20);

        // Пользователь
        lblCustomer = new Label();
        lblCustomer.Text = "Пользователь:";
        lblCustomer.Location = new Point(20, 110);
        lblCustomer.Size = new Size(100, 20);

        txtCustomer = new TextBox();
        txtCustomer.Location = new Point(130, 110);
        txtCustomer.Size = new Size(200, 20);
        txtCustomer.ReadOnly = true;

        // Продукция
        lblProduct = new Label();
        lblProduct.Text = "Продукция:";
        lblProduct.Location = new Point(20, 140);
        lblProduct.Size = new Size(100, 20);

        txtProduct = new TextBox();
        txtProduct.Location = new Point(130, 140);
        txtProduct.Size = new Size(200, 20);
        txtProduct.ReadOnly = true;

        // Количество
        lblQuantity = new Label();
        lblQuantity.Text = "Количество:";
        lblQuantity.Location = new Point(20, 170);
        lblQuantity.Size = new Size(100, 20);

        txtQuantity = new TextBox();
        txtQuantity.Location = new Point(130, 170);
        txtQuantity.Size = new Size(100, 20);
        txtQuantity.ReadOnly = true;

        // Цена
        lblPrice = new Label();
        lblPrice.Text = "Цена за ед.:";
        lblPrice.Location = new Point(250, 170);
        lblPrice.Size = new Size(80, 20);

        txtPrice = new TextBox();
        txtPrice.Location = new Point(340, 170);
        txtPrice.Size = new Size(100, 20);
        txtPrice.ReadOnly = true;

        // Общая сумма
        lblTotalAmount = new Label();
        lblTotalAmount.Text = "Общая сумма:";
        lblTotalAmount.Location = new Point(20, 200);
        lblTotalAmount.Size = new Size(100, 20);

        txtTotalAmount = new TextBox();
        txtTotalAmount.Location = new Point(130, 200);
        txtTotalAmount.Size = new Size(100, 20);
        txtTotalAmount.ReadOnly = true;

        // Телефон
        lblPhone = new Label();
        lblPhone.Text = "Телефон:";
        lblPhone.Location = new Point(20, 230);
        lblPhone.Size = new Size(100, 20);

        txtPhone = new TextBox();
        txtPhone.Location = new Point(130, 230);
        txtPhone.Size = new Size(200, 20);
        txtPhone.ReadOnly = true;

        // Email
        lblEmail = new Label();
        lblEmail.Text = "Email:";
        lblEmail.Location = new Point(20, 260);
        lblEmail.Size = new Size(100, 20);

        txtEmail = new TextBox();
        txtEmail.Location = new Point(130, 260);
        txtEmail.Size = new Size(200, 20);
        txtEmail.ReadOnly = true;

        // Комментарий пользователя
        lblCustomerComment = new Label();
        lblCustomerComment.Text = "Комментарий пользователя:";
        lblCustomerComment.Location = new Point(20, 290);
        lblCustomerComment.Size = new Size(150, 20);

        txtCustomerComment = new TextBox();
        txtCustomerComment.Location = new Point(180, 290);
        txtCustomerComment.Size = new Size(200, 40);
        txtCustomerComment.Multiline = true;
        txtCustomerComment.ReadOnly = true;
        txtCustomerComment.ScrollBars = ScrollBars.Vertical;

        // Изменение статуса
        Label lblStatusChange = new Label();
        lblStatusChange.Text = "Изменение статуса:";
        lblStatusChange.Location = new Point(400, 20);
        lblStatusChange.Size = new Size(150, 20);
        lblStatusChange.Font = new Font("Arial", 9, FontStyle.Bold);

        // Новый статус
        lblNewStatus = new Label();
        lblNewStatus.Text = "Новый статус:";
        lblNewStatus.Location = new Point(400, 50);
        lblNewStatus.Size = new Size(100, 20);

        cmbNewStatus = new ComboBox();
        cmbNewStatus.Location = new Point(510, 50);
        cmbNewStatus.Size = new Size(150, 20);
        cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbNewStatus.SelectedIndexChanged += new EventHandler(cmbNewStatus_SelectedIndexChanged);

        // Валидация перехода
        lblValidation = new Label();
        lblValidation.Text = "";
        lblValidation.Location = new Point(400, 80);
        lblValidation.Size = new Size(300, 20);
        lblValidation.Font = new Font("Arial", 8, FontStyle.Italic);

        // Комментарий к изменению
        lblComment = new Label();
        lblComment.Text = "Комментарий к изменению:";
        lblComment.Location = new Point(400, 110);
        lblComment.Size = new Size(150, 20);

        txtComment = new TextBox();
        txtComment.Location = new Point(400, 140);
        txtComment.Size = new Size(350, 60);
        txtComment.Multiline = true;
        txtComment.ScrollBars = ScrollBars.Vertical;

        // История статусов
        lblHistory = new Label();
        lblHistory.Text = "История изменений статуса:";
        lblHistory.Location = new Point(20, 350);
        lblHistory.Size = new Size(200, 20);
        lblHistory.Font = new Font("Arial", 9, FontStyle.Bold);

        dataGridViewHistory = new DataGridView();
        dataGridViewHistory.Location = new Point(20, 380);
        dataGridViewHistory.Size = new Size(750, 200);
        dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewHistory.ReadOnly = true;
        dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Кнопки
        btnUpdateStatus = new Button();
        btnUpdateStatus.Text = "Обновить статус";
        btnUpdateStatus.Location = new Point(400, 600);
        btnUpdateStatus.Size = new Size(120, 30);
        btnUpdateStatus.Click += new EventHandler(btnUpdateStatus_Click);

        btnCancel = new Button();
        btnCancel.Text = "Отмена";
        btnCancel.Location = new Point(530, 600);
        btnCancel.Size = new Size(120, 30);
        btnCancel.Click += new EventHandler(btnCancel_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblOrderInfo);
        this.Controls.Add(lblOrderNumber);
        this.Controls.Add(lblCurrentStatus);
        this.Controls.Add(lblCustomer);
        this.Controls.Add(txtCustomer);
        this.Controls.Add(lblProduct);
        this.Controls.Add(txtProduct);
        this.Controls.Add(lblQuantity);
        this.Controls.Add(txtQuantity);
        this.Controls.Add(lblPrice);
        this.Controls.Add(txtPrice);
        this.Controls.Add(lblTotalAmount);
        this.Controls.Add(txtTotalAmount);
        this.Controls.Add(lblPhone);
        this.Controls.Add(txtPhone);
        this.Controls.Add(lblEmail);
        this.Controls.Add(txtEmail);
        this.Controls.Add(lblCustomerComment);
        this.Controls.Add(txtCustomerComment);
        this.Controls.Add(lblStatusChange);
        this.Controls.Add(lblNewStatus);
        this.Controls.Add(cmbNewStatus);
        this.Controls.Add(lblValidation);
        this.Controls.Add(lblComment);
        this.Controls.Add(txtComment);
        this.Controls.Add(lblHistory);
        this.Controls.Add(dataGridViewHistory);
        this.Controls.Add(btnUpdateStatus);
        this.Controls.Add(btnCancel);
    }
}