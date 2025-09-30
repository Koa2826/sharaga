using System.ComponentModel;

namespace Me;

partial class ProductWorkshopsForm
{
    private ComboBox cmbProducts;
    private DataGridView dataGridViewWorkshops;
    private Label lblTotalTime;
    private Label lblSelectProduct;
    private Label lblProductQuantity;
    private TextBox txtProductQuantity;
    private Label lblParam1;
    private TextBox txtParam1;
    private Label lblParam2;
    private TextBox txtParam2;
    private Button btnCalculateRawMaterials;
    private Button btnBack;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(700, 550);
        this.Text = "Цеха производства продукции";
        this.StartPosition = FormStartPosition.CenterScreen;

        // Выбор продукции
        lblSelectProduct = new Label();
        lblSelectProduct.Text = "Выберите продукцию:";
        lblSelectProduct.Location = new Point(20, 20);
        lblSelectProduct.Size = new Size(150, 20);

        cmbProducts = new ComboBox();
        cmbProducts.Location = new Point(180, 20);
        cmbProducts.Size = new Size(250, 20);
        cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProducts.SelectedIndexChanged += new EventHandler(cmbProducts_SelectedIndexChanged);

        // DataGridView для цехов
        dataGridViewWorkshops = new DataGridView();
        dataGridViewWorkshops.Location = new Point(20, 60);
        dataGridViewWorkshops.Size = new Size(660, 200);
        dataGridViewWorkshops.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewWorkshops.ReadOnly = true;
        dataGridViewWorkshops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Общее время изготовления
        lblTotalTime = new Label();
        lblTotalTime.Text = "Общее время изготовления: ";
        lblTotalTime.Location = new Point(20, 270);
        lblTotalTime.Size = new Size(300, 20);
        lblTotalTime.Font = new Font("Arial", 10, FontStyle.Bold);

        // Параметры для расчета
        Label lblCalculationTitle = new Label();
        lblCalculationTitle.Text = "Расчет необходимого сырья:";
        lblCalculationTitle.Location = new Point(20, 300);
        lblCalculationTitle.Size = new Size(200, 20);
        lblCalculationTitle.Font = new Font("Arial", 10, FontStyle.Bold);

        // Количество продукции
        lblProductQuantity = new Label();
        lblProductQuantity.Text = "Количество продукции:";
        lblProductQuantity.Location = new Point(20, 330);
        lblProductQuantity.Size = new Size(150, 20);

        txtProductQuantity = new TextBox();
        txtProductQuantity.Location = new Point(180, 330);
        txtProductQuantity.Size = new Size(100, 20);

        // Параметр 1
        lblParam1 = new Label();
        lblParam1.Text = "Параметр 1:";
        lblParam1.Location = new Point(20, 360);
        lblParam1.Size = new Size(150, 20);

        txtParam1 = new TextBox();
        txtParam1.Location = new Point(180, 360);
        txtParam1.Size = new Size(100, 20);

        // Параметр 2
        lblParam2 = new Label();
        lblParam2.Text = "Параметр 2:";
        lblParam2.Location = new Point(20, 390);
        lblParam2.Size = new Size(150, 20);

        txtParam2 = new TextBox();
        txtParam2.Location = new Point(180, 390);
        txtParam2.Size = new Size(100, 20);

        /// Кнопка расчета
        btnCalculateRawMaterials = new Button();
        btnCalculateRawMaterials.Text = "Рассчитать сырье";
        btnCalculateRawMaterials.Location = new Point(300, 360);
        btnCalculateRawMaterials.Size = new Size(150, 50);
        btnCalculateRawMaterials.Click += new EventHandler(btnCalculateRawMaterials_Click);

        // Кнопка назад
        btnBack = new Button();
        btnBack.Text = "Назад";
        btnBack.Location = new Point(560, 470);
        btnBack.Size = new Size(120, 30);
        btnBack.Click += new EventHandler(btnBack_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblSelectProduct);
        this.Controls.Add(cmbProducts);
        this.Controls.Add(dataGridViewWorkshops);
        this.Controls.Add(lblTotalTime);
        this.Controls.Add(lblCalculationTitle);
        this.Controls.Add(lblProductQuantity);
        this.Controls.Add(txtProductQuantity);
        this.Controls.Add(lblParam1);
        this.Controls.Add(txtParam1);
        this.Controls.Add(lblParam2);
        this.Controls.Add(txtParam2);
        this.Controls.Add(btnCalculateRawMaterials);
        this.Controls.Add(btnBack);
    }
}