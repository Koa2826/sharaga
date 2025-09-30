using System.ComponentModel;
using System.Data;
using Npgsql;

namespace Me;

public partial class ProductsForm : Form
{
   
    private string connectionString = "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
    private DataTable productsTable;
    private string currentUser;
    private string userRole;
    private bool isEditFormOpen = false;
    private Container components;

    public ProductsForm(string username, string role)
    { 
        InitializeComponent();
        currentUser = username;
        userRole = role;
        CheckAdminPermissions();
        LoadProducts();
        LoadProductTypes();
        LoadMaterials();
    }

    private void CheckAdminPermissions()
    { 
        bool isAdmin = userRole?.ToLower() == "администратор";
        btnAddProduct.Enabled = isAdmin;
        btnEditProduct.Enabled = isAdmin;
        btnDeleteProduct.Enabled = isAdmin;
    }

   private void LoadProducts()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT p.""НаименованиеПродукции"", p.""ТипПродукции"", p.""Артикул"", 
                                   p.""МинСтоимостьДляПартнера"", p.""ОсновнойМатериал""
                            FROM public.""Products"" p";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    productsTable = new DataTable();
                    adapter.Fill(productsTable);

                    dataGridViewProducts.DataSource = productsTable;
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Переименование заголовков
            if (dataGridViewProducts.Columns.Count > 0)
            {
                dataGridViewProducts.Columns["НаименованиеПродукции"].HeaderText = "Наименование";
                dataGridViewProducts.Columns["ТипПродукции"].HeaderText = "Тип продукции";
                dataGridViewProducts.Columns["Артикул"].HeaderText = "Артикул";
                dataGridViewProducts.Columns["МинСтоимостьДляПартнера"].HeaderText = "Мин. стоимость";
                dataGridViewProducts.Columns["ОсновнойМатериал"].HeaderText = "Основной материал";
            }
        }

        private void LoadProductTypes()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT \"ТипПродукции\" FROM public.\"ProductType\"";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbProductTypeFilter.Items.Add(reader["ТипПродукции"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов продукции: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMaterials()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT \"ТипМатериала\" FROM public.\"MaterialType\"";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbMaterialFilter.Items.Add(reader["ТипМатериала"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки материалов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (isEditFormOpen)
            {
                MessageBox.Show("Форма редактирования уже открыта. Закройте ее перед открытием новой.", 
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductEditForm editForm = new ProductEditForm(null, connectionString);
            editForm.FormClosed += (s, args) => { isEditFormOpen = false; LoadProducts(); };
            isEditFormOpen = true;
            editForm.ShowDialog();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isEditFormOpen)
            {
                MessageBox.Show("Форма редактирования уже открыта.", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productName = dataGridViewProducts.SelectedRows[0].Cells["НаименованиеПродукции"].Value.ToString();
            ProductEditForm editForm = new ProductEditForm(productName, connectionString);
            editForm.FormClosed += (s, args) => { isEditFormOpen = false; LoadProducts(); };
            isEditFormOpen = true;
            editForm.ShowDialog();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для удаления.", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string productName = dataGridViewProducts.SelectedRows[0].Cells["НаименованиеПродукции"].Value.ToString();
            
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить товар '{productName}'?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteProduct(productName);
                    LoadProducts();
                    MessageBox.Show("Товар успешно удален.", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении товара: {ex.Message}", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteProduct(string productName)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                // Удаляем связанные записи из ProductWorkshops
                string deleteWorkshopsQuery = $"DELETE FROM public.\"ProductWorkshops\" WHERE \"НаименованиеПродукции\" = '{productName}'";
                NpgsqlCommand workshopsCommand = new NpgsqlCommand(deleteWorkshopsQuery, connection);
                workshopsCommand.ExecuteNonQuery();
                
                // Удаляем сам продукт
                string deleteProductQuery = $"DELETE FROM public.\"Products\" WHERE \"НаименованиеПродукции\" = '{productName}'";
                NpgsqlCommand productCommand = new NpgsqlCommand(deleteProductQuery, connection);
                productCommand.ExecuteNonQuery();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbProductTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbMaterialFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (productsTable == null) return;

            string searchText = txtSearch.Text.ToLower();
            string productTypeFilter = cmbProductTypeFilter.SelectedItem?.ToString();
            string materialFilter = cmbMaterialFilter.SelectedItem?.ToString();

            var filteredRows = productsTable.AsEnumerable().Where(row =>
                (string.IsNullOrEmpty(searchText) || 
                 row.Field<string>("НаименованиеПродукции")?.ToLower().Contains(searchText) == true ||
                 row.Field<string>("ТипПродукции")?.ToLower().Contains(searchText) == true ||
                 row.Field<string>("ОсновнойМатериал")?.ToLower().Contains(searchText) == true) &&
                (string.IsNullOrEmpty(productTypeFilter) || 
                 row.Field<string>("ТипПродукции") == productTypeFilter) &&
                (string.IsNullOrEmpty(materialFilter) || 
                 row.Field<string>("ОсновнойМатериал") == materialFilter)
            );

            dataGridViewProducts.DataSource = filteredRows.CopyToDataTable();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
}