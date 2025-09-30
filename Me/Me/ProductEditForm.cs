using System.ComponentModel;
using Npgsql;

namespace Me;

public partial class ProductEditForm : Form
{
    public ProductEditForm()
    {
        InitializeComponent();
    }
     private string productName;
        private string connectionString;
        private bool isEditMode;
        private Container components;

        public ProductEditForm(string existingProductName, string connString)
        {
            InitializeComponent();
            productName = existingProductName;
            connectionString = connString;
            isEditMode = !string.IsNullOrEmpty(existingProductName);
            
            InitializeForm();
            LoadComboBoxData();
            
            if (isEditMode)
            {
                LoadProductData();
            }
        }

        private void InitializeForm()
        {
            this.Text = isEditMode ? "Редактирование товара" : "Добавление товара";
            txtProductId.Enabled = false;
            
            if (!isEditMode)
            {
                txtProductId.Text = "Автоматически";
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Загрузка типов продукции
                    string productTypesQuery = "SELECT \"ТипПродукции\" FROM public.\"ProductType\"";
                    NpgsqlCommand productTypesCommand = new NpgsqlCommand(productTypesQuery, connection);
                    NpgsqlDataReader productTypesReader = productTypesCommand.ExecuteReader();
                    
                    while (productTypesReader.Read())
                    {
                        cmbProductType.Items.Add(productTypesReader["ТипПродукции"]);
                    }
                    productTypesReader.Close();

                    // Загрузка типов материалов
                    string materialsQuery = "SELECT \"ТипМатериала\" FROM public.\"MaterialType\"";
                    NpgsqlCommand materialsCommand = new NpgsqlCommand(materialsQuery, connection);
                    NpgsqlDataReader materialsReader = materialsCommand.ExecuteReader();
                    
                    while (materialsReader.Read())
                    {
                        cmbMaterial.Items.Add(materialsReader["ТипМатериала"]);
                    }
                    materialsReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM public.""Products"" 
                                   WHERE ""НаименованиеПродукции"" = '{productName}'";
                    
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        txtProductName.Text = reader["НаименованиеПродукции"].ToString();
                        cmbProductType.SelectedItem = reader["ТипПродукции"].ToString();
                        txtArticle.Text = reader["Артикул"].ToString();
                        txtMinPrice.Text = reader["МинСтоимостьДляПартнера"].ToString();
                        cmbMaterial.SelectedItem = reader["ОсновнойМатериал"].ToString();
                        
                        // В режиме редактирования ID доступен только для чтения
                        txtProductName.Enabled = false;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных товара: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (isEditMode)
                {
                    UpdateProduct();
                }
                else
                {
                    InsertProduct();
                }
                
                MessageBox.Show($"Товар успешно {(isEditMode ? "обновлен" : "добавлен")}.", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Введите наименование товара.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbProductType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип продукции.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtArticle.Text, out int article) || article < 0)
            {
                MessageBox.Show("Введите корректный артикул (целое неотрицательное число).", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtMinPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Введите корректную минимальную стоимость (неотрицательное число).", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InsertProduct()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO public.""Products"" 
                               (""НаименованиеПродукции"", ""ТипПродукции"", ""Артикул"", 
                                ""МинСтоимостьДляПартнера"", ""ОсновнойМатериал"") 
                               VALUES (@name, @type, @article, @price, @material)";
                
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", txtProductName.Text);
                command.Parameters.AddWithValue("@type", cmbProductType.SelectedItem.ToString());
                command.Parameters.AddWithValue("@article", int.Parse(txtArticle.Text));
                command.Parameters.AddWithValue("@price", decimal.Parse(txtMinPrice.Text));
                command.Parameters.AddWithValue("@material", cmbMaterial.SelectedItem?.ToString() ?? (object)DBNull.Value);
                
                command.ExecuteNonQuery();
            }
        }

        private void UpdateProduct()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE public.""Products"" 
                               SET ""ТипПродукции"" = @type, 
                                   ""Артикул"" = @article, 
                                   ""МинСтоимостьДляПартнера"" = @price, 
                                   ""ОсновнойМатериал"" = @material 
                               WHERE ""НаименованиеПродукции"" = @name";
                
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@type", cmbProductType.SelectedItem.ToString());
                command.Parameters.AddWithValue("@article", int.Parse(txtArticle.Text));
                command.Parameters.AddWithValue("@price", decimal.Parse(txtMinPrice.Text));
                command.Parameters.AddWithValue("@material", cmbMaterial.SelectedItem?.ToString() ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@name", productName);
                
                command.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
}