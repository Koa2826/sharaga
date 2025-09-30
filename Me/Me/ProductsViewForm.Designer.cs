using System.ComponentModel;

namespace Me;

partial class ProductsViewForm
{
     private DataGridView dataGridViewProducts;
    private TextBox txtSearch;
    private ComboBox cmbProductTypeFilter;
    private ComboBox cmbMaterialFilter;
    private Button btnCreateOrder;
    private Button btnBack;
    private Label lblSearch;
    private Label lblProductTypeFilter;
    private Label lblMaterialFilter;
    private Label lblGuestInfo;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Text = "Просмотр продукции";
        this.StartPosition = FormStartPosition.CenterScreen;

        // Информация для гостей
        lblGuestInfo = new Label();
        lblGuestInfo.Text = "Гостевой режим - доступен только просмотр. Для создания заявок необходима авторизация.";
        lblGuestInfo.Location = new Point(20, 10);
        lblGuestInfo.Size = new Size(760, 20);
        lblGuestInfo.ForeColor = Color.Blue;
        lblGuestInfo.TextAlign = ContentAlignment.MiddleCenter;
        lblGuestInfo.Font = new Font("Arial", 9, FontStyle.Italic);
        lblGuestInfo.Visible = false;

        // Поиск
        lblSearch = new Label();
        lblSearch.Text = "Поиск:";
        lblSearch.Location = new Point(20, 40);
        lblSearch.Size = new Size(50, 20);

        txtSearch = new TextBox();
        txtSearch.Location = new Point(80, 40);
        txtSearch.Size = new Size(200, 20);
        txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
        txtSearch.PlaceholderText = "Введите название продукции...";

        // Фильтр по типу продукции
        lblProductTypeFilter = new Label();
        lblProductTypeFilter.Text = "Тип продукции:";
        lblProductTypeFilter.Location = new Point(300, 40);
        lblProductTypeFilter.Size = new Size(100, 20);

        cmbProductTypeFilter = new ComboBox();
        cmbProductTypeFilter.Location = new Point(410, 40);
        cmbProductTypeFilter.Size = new Size(150, 20);
        cmbProductTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProductTypeFilter.SelectedIndexChanged += new EventHandler(cmbProductTypeFilter_SelectedIndexChanged);

        // Фильтр по материалу
        lblMaterialFilter = new Label();
        lblMaterialFilter.Text = "Материал:";
        lblMaterialFilter.Location = new Point(580, 40);
        lblMaterialFilter.Size = new Size(70, 20);

        cmbMaterialFilter = new ComboBox();
        cmbMaterialFilter.Location = new Point(660, 40);
        cmbMaterialFilter.Size = new Size(120, 20);
        cmbMaterialFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMaterialFilter.SelectedIndexChanged += new EventHandler(cmbMaterialFilter_SelectedIndexChanged);

        // DataGridView
        dataGridViewProducts = new DataGridView();
        dataGridViewProducts.Location = new Point(20, 70);
        dataGridViewProducts.Size = new Size(760, 400);
        dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewProducts.ReadOnly = true;
        dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewProducts.CellDoubleClick += new DataGridViewCellEventHandler(dataGridViewProducts_CellDoubleClick);

        // Кнопки
        btnCreateOrder = new Button();
        btnCreateOrder.Text = "Создать заявку";
        btnCreateOrder.Location = new Point(20, 490);
        btnCreateOrder.Size = new Size(120, 30);
        btnCreateOrder.Click += new EventHandler(btnCreateOrder_Click);

        btnBack = new Button();
        btnBack.Text = "Назад";
        btnBack.Location = new Point(660, 490);
        btnBack.Size = new Size(120, 30);
        btnBack.Click += new EventHandler(btnBack_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblGuestInfo);
        this.Controls.Add(lblSearch);
        this.Controls.Add(txtSearch);
        this.Controls.Add(lblProductTypeFilter);
        this.Controls.Add(cmbProductTypeFilter);
        this.Controls.Add(lblMaterialFilter);
        this.Controls.Add(cmbMaterialFilter);
        this.Controls.Add(dataGridViewProducts);
        this.Controls.Add(btnCreateOrder);
        this.Controls.Add(btnBack);
    }
}