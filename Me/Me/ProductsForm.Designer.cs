using System.ComponentModel;

namespace Me;

partial class ProductsForm
{
     private DataGridView dataGridViewProducts;
    private TextBox txtSearch;
    private ComboBox cmbProductTypeFilter;
    private ComboBox cmbMaterialFilter;
    private Button btnAddProduct;
    private Button btnEditProduct;
    private Button btnDeleteProduct;
    private Button btnBack;
    private Label lblSearch;
    private Label lblProductTypeFilter;
    private Label lblMaterialFilter;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Text = "Управление товарами";
        this.StartPosition = FormStartPosition.CenterScreen;

        // Поиск
        lblSearch = new Label();
        lblSearch.Text = "Поиск:";
        lblSearch.Location = new Point(20, 20);
        lblSearch.Size = new Size(50, 20);

        txtSearch = new TextBox();
        txtSearch.Location = new Point(80, 20);
        txtSearch.Size = new Size(200, 20);
        txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

        // Фильтр по типу продукции
        lblProductTypeFilter = new Label();
        lblProductTypeFilter.Text = "Тип продукции:";
        lblProductTypeFilter.Location = new Point(300, 20);
        lblProductTypeFilter.Size = new Size(100, 20);

        cmbProductTypeFilter = new ComboBox();
        cmbProductTypeFilter.Location = new Point(410, 20);
        cmbProductTypeFilter.Size = new Size(150, 20);
        cmbProductTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProductTypeFilter.SelectedIndexChanged += new EventHandler(cmbProductTypeFilter_SelectedIndexChanged);

        // Фильтр по материалу
        lblMaterialFilter = new Label();
        lblMaterialFilter.Text = "Материал:";
        lblMaterialFilter.Location = new Point(580, 20);
        lblMaterialFilter.Size = new Size(70, 20);

        cmbMaterialFilter = new ComboBox();
        cmbMaterialFilter.Location = new Point(660, 20);
        cmbMaterialFilter.Size = new Size(120, 20);
        cmbMaterialFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMaterialFilter.SelectedIndexChanged += new EventHandler(cmbMaterialFilter_SelectedIndexChanged);

        // DataGridView
        dataGridViewProducts = new DataGridView();
        dataGridViewProducts.Location = new Point(20, 60);
        dataGridViewProducts.Size = new Size(760, 400);
        dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewProducts.ReadOnly = true;
        dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Кнопки
        btnAddProduct = new Button();
        btnAddProduct.Text = "Добавить товар";
        btnAddProduct.Location = new Point(20, 480);
        btnAddProduct.Size = new Size(120, 30);
        btnAddProduct.Click += new EventHandler(btnAddProduct_Click);

        btnEditProduct = new Button();
        btnEditProduct.Text = "Редактировать";
        btnEditProduct.Location = new Point(150, 480);
        btnEditProduct.Size = new Size(120, 30);
        btnEditProduct.Click += new EventHandler(btnEditProduct_Click);

        btnDeleteProduct = new Button();
        btnDeleteProduct.Text = "Удалить";
        btnDeleteProduct.Location = new Point(280, 480);
        btnDeleteProduct.Size = new Size(120, 30);
        btnDeleteProduct.Click += new EventHandler(btnDeleteProduct_Click);

        btnBack = new Button();
        btnBack.Text = "Назад";
        btnBack.Location = new Point(660, 480);
        btnBack.Size = new Size(120, 30);
        btnBack.Click += new EventHandler(btnBack_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblSearch);
        this.Controls.Add(txtSearch);
        this.Controls.Add(lblProductTypeFilter);
        this.Controls.Add(cmbProductTypeFilter);
        this.Controls.Add(lblMaterialFilter);
        this.Controls.Add(cmbMaterialFilter);
        this.Controls.Add(dataGridViewProducts);
        this.Controls.Add(btnAddProduct);
        this.Controls.Add(btnEditProduct);
        this.Controls.Add(btnDeleteProduct);
        this.Controls.Add(btnBack);
    }
}