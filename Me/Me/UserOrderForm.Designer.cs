using System.ComponentModel;

namespace Me;

partial class UserOrderForm
{
   private TextBox txtOrderNumber;
    private TextBox txtUsername;
    private ComboBox cmbProductName;
    private NumericUpDown nudQuantity;
    private TextBox txtPrice;
    private TextBox txtTotalAmount;
    private ComboBox cmbStatus;
    private DateTimePicker dtpOrderDate;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private TextBox txtComment;
    private Button btnSubmitOrder;
    private Button btnCancel;
    private Label lblOrderNumber;
    private Label lblUsername;
    private Label lblProductName;
    private Label lblQuantity;
    private Label lblPrice;
    private Label lblTotalAmount;
    private Label lblStatus;
    private Label lblOrderDate;
    private Label lblPhone;
    private Label lblEmail;
    private Label lblComment;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 500);
        this.Text = "Создание заявки на товар";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        // Номер заявки
        lblOrderNumber = new Label();
        lblOrderNumber.Text = "Номер заявки:";
        lblOrderNumber.Location = new Point(20, 20);
        lblOrderNumber.Size = new Size(120, 20);

        txtOrderNumber = new TextBox();
        txtOrderNumber.Location = new Point(150, 20);
        txtOrderNumber.Size = new Size(200, 20);
        txtOrderNumber.ReadOnly = true;

        // Логин пользователя
        lblUsername = new Label();
        lblUsername.Text = "Логин пользователя:";
        lblUsername.Location = new Point(20, 50);
        lblUsername.Size = new Size(120, 20);

        txtUsername = new TextBox();
        txtUsername.Location = new Point(150, 50);
        txtUsername.Size = new Size(200, 20);

        // Дата заявки
        lblOrderDate = new Label();
        lblOrderDate.Text = "Дата заявки:";
        lblOrderDate.Location = new Point(20, 80);
        lblOrderDate.Size = new Size(120, 20);

        dtpOrderDate = new DateTimePicker();
        dtpOrderDate.Location = new Point(150, 80);
        dtpOrderDate.Size = new Size(200, 20);
        dtpOrderDate.Enabled = false;

        // Наименование продукции
        lblProductName = new Label();
        lblProductName.Text = "Продукция:";
        lblProductName.Location = new Point(20, 110);
        lblProductName.Size = new Size(120, 20);

        cmbProductName = new ComboBox();
        cmbProductName.Location = new Point(150, 110);
        cmbProductName.Size = new Size(200, 20);
        cmbProductName.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProductName.SelectedIndexChanged += new EventHandler(cmbProductName_SelectedIndexChanged);

        // Количество
        lblQuantity = new Label();
        lblQuantity.Text = "Количество:";
        lblQuantity.Location = new Point(20, 140);
        lblQuantity.Size = new Size(120, 20);

        nudQuantity = new NumericUpDown();
        nudQuantity.Location = new Point(150, 140);
        nudQuantity.Size = new Size(100, 20);
        nudQuantity.Minimum = 1;
        nudQuantity.Maximum = 1000;
        nudQuantity.ValueChanged += new EventHandler(nudQuantity_ValueChanged);

        // Цена
        lblPrice = new Label();
        lblPrice.Text = "Цена за единицу:";
        lblPrice.Location = new Point(20, 170);
        lblPrice.Size = new Size(120, 20);

        txtPrice = new TextBox();
        txtPrice.Location = new Point(150, 170);
        txtPrice.Size = new Size(100, 20);
        txtPrice.ReadOnly = true;

        // Общая сумма
        lblTotalAmount = new Label();
        lblTotalAmount.Text = "Общая сумма:";
        lblTotalAmount.Location = new Point(20, 200);
        lblTotalAmount.Size = new Size(120, 20);

        txtTotalAmount = new TextBox();
        txtTotalAmount.Location = new Point(150, 200);
        txtTotalAmount.Size = new Size(100, 20);
        txtTotalAmount.ReadOnly = true;

        // Статус
        lblStatus = new Label();
        lblStatus.Text = "Статус:";
        lblStatus.Location = new Point(20, 230);
        lblStatus.Size = new Size(120, 20);

        cmbStatus = new ComboBox();
        cmbStatus.Location = new Point(150, 230);
        cmbStatus.Size = new Size(150, 20);
        cmbStatus.Items.AddRange(new string[] { "Новая", "В обработке", "Подтверждена", "В производстве", "Готово", "Отменена" });
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        // Телефон
        lblPhone = new Label();
        lblPhone.Text = "Телефон:";
        lblPhone.Location = new Point(20, 260);
        lblPhone.Size = new Size(120, 20);

        txtPhone = new TextBox();
        txtPhone.Location = new Point(150, 260);
        txtPhone.Size = new Size(200, 20);

        // Email
        lblEmail = new Label();
        lblEmail.Text = "Email:";
        lblEmail.Location = new Point(20, 290);
        lblEmail.Size = new Size(120, 20);

        txtEmail = new TextBox();
        txtEmail.Location = new Point(150, 290);
        txtEmail.Size = new Size(200, 20);

        // Комментарий
        lblComment = new Label();
        lblComment.Text = "Комментарий:";
        lblComment.Location = new Point(20, 320);
        lblComment.Size = new Size(120, 20);

        txtComment = new TextBox();
        txtComment.Location = new Point(150, 320);
        txtComment.Size = new Size(200, 60);
        txtComment.Multiline = true;
        txtComment.ScrollBars = ScrollBars.Vertical;

        // Кнопки
        btnSubmitOrder = new Button();
        btnSubmitOrder.Text = "Создать заявку";
        btnSubmitOrder.Location = new Point(150, 400);
        btnSubmitOrder.Size = new Size(120, 30);
        btnSubmitOrder.Click += new EventHandler(btnSubmitOrder_Click);

        btnCancel = new Button();
        btnCancel.Text = "Отмена";
        btnCancel.Location = new Point(280, 400);
        btnCancel.Size = new Size(120, 30);
        btnCancel.Click += new EventHandler(btnCancel_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblOrderNumber);
        this.Controls.Add(txtOrderNumber);
        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblOrderDate);
        this.Controls.Add(dtpOrderDate);
        this.Controls.Add(lblProductName);
        this.Controls.Add(cmbProductName);
        this.Controls.Add(lblQuantity);
        this.Controls.Add(nudQuantity);
        this.Controls.Add(lblPrice);
        this.Controls.Add(txtPrice);
        this.Controls.Add(lblTotalAmount);
        this.Controls.Add(txtTotalAmount);
        this.Controls.Add(lblStatus);
        this.Controls.Add(cmbStatus);
        this.Controls.Add(lblPhone);
        this.Controls.Add(txtPhone);
        this.Controls.Add(lblEmail);
        this.Controls.Add(txtEmail);
        this.Controls.Add(lblComment);
        this.Controls.Add(txtComment);
        this.Controls.Add(btnSubmitOrder);
        this.Controls.Add(btnCancel);
    }
}