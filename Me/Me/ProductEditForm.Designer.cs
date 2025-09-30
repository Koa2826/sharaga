using System.ComponentModel;

namespace Me;

partial class ProductEditForm
{
    private TextBox txtProductName;
    private ComboBox cmbProductType;
    private TextBox txtArticle;
    private TextBox txtMinPrice;
    private ComboBox cmbMaterial;
    private Button btnSave;
    private Button btnCancel;
    private Label lblProductName;
    private Label lblProductType;
    private Label lblArticle;
    private Label lblMinPrice;
    private Label lblMaterial;
    private TextBox txtProductId;
    private Label lblProductId;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 350);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // ID товара
        lblProductId = new Label();
        lblProductId.Text = "ID товара:";
        lblProductId.Location = new Point(20, 20);
        lblProductId.Size = new Size(100, 20);

        txtProductId = new TextBox();
        txtProductId.Location = new Point(150, 20);
        txtProductId.Size = new Size(200, 20);
        txtProductId.ReadOnly = true;

        // Наименование товара
        lblProductName = new Label();
        lblProductName.Text = "Наименование:";
        lblProductName.Location = new Point(20, 60);
        lblProductName.Size = new Size(100, 20);

        txtProductName = new TextBox();
        txtProductName.Location = new Point(150, 60);
        txtProductName.Size = new Size(200, 20);

        // Тип продукции
        lblProductType = new Label();
        lblProductType.Text = "Тип продукции:";
        lblProductType.Location = new Point(20, 100);
        lblProductType.Size = new Size(100, 20);

        cmbProductType = new ComboBox();
        cmbProductType.Location = new Point(150, 100);
        cmbProductType.Size = new Size(200, 20);
        cmbProductType.DropDownStyle = ComboBoxStyle.DropDownList;

        // Артикул
        lblArticle = new Label();
        lblArticle.Text = "Артикул:";
        lblArticle.Location = new Point(20, 140);
        lblArticle.Size = new Size(100, 20);

        txtArticle = new TextBox();
        txtArticle.Location = new Point(150, 140);
        txtArticle.Size = new Size(200, 20);

        // Минимальная стоимость
        lblMinPrice = new Label();
        lblMinPrice.Text = "Мин. стоимость:";
        lblMinPrice.Location = new Point(20, 180);
        lblMinPrice.Size = new Size(100, 20);

        txtMinPrice = new TextBox();
        txtMinPrice.Location = new Point(150, 180);
        txtMinPrice.Size = new Size(200, 20);

        // Материал
        lblMaterial = new Label();
        lblMaterial.Text = "Основной материал:";
        lblMaterial.Location = new Point(20, 220);
        lblMaterial.Size = new Size(120, 20);

        cmbMaterial = new ComboBox();
        cmbMaterial.Location = new Point(150, 220);
        cmbMaterial.Size = new Size(200, 20);
        cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;

        // Кнопки
        btnSave = new Button();
        btnSave.Text = "Сохранить";
        btnSave.Location = new Point(150, 270);
        btnSave.Size = new Size(100, 30);
        btnSave.Click += new EventHandler(btnSave_Click);

        btnCancel = new Button();
        btnCancel.Text = "Отмена";
        btnCancel.Location = new Point(260, 270);
        btnCancel.Size = new Size(100, 30);
        btnCancel.Click += new EventHandler(btnCancel_Click);

        // Добавление элементов на форму
        this.Controls.Add(lblProductId);
        this.Controls.Add(txtProductId);
        this.Controls.Add(lblProductName);
        this.Controls.Add(txtProductName);
        this.Controls.Add(lblProductType);
        this.Controls.Add(cmbProductType);
        this.Controls.Add(lblArticle);
        this.Controls.Add(txtArticle);
        this.Controls.Add(lblMinPrice);
        this.Controls.Add(txtMinPrice);
        this.Controls.Add(lblMaterial);
        this.Controls.Add(cmbMaterial);
        this.Controls.Add(btnSave);
        this.Controls.Add(btnCancel);
    }
}