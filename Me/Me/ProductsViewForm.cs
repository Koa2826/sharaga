using System.ComponentModel;
using System.Data;
using Npgsql;

namespace Me;

public partial class ProductsViewForm : Form
{
    private string connectionString = "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
    private DataTable productsTable;
        private string currentUser;
        private string userRole;
        private Container components;

        public ProductsViewForm(string username = null, string role = null)
        {
            InitializeComponent();
            currentUser = username;
            userRole = role;
            CheckPermissions();
            LoadProducts();
            LoadProductTypes();
            LoadMaterials();
        }

        private void CheckPermissions()
        {
            bool isGuest = string.IsNullOrEmpty(currentUser);
            
            if (isGuest)
            {
                this.Text = "Просмотр продукции (Гостевой режим)";
                lblGuestInfo.Visible = true;
            }
            else
            {
                this.Text = "Просмотр продукции";
                lblGuestInfo.Visible = false;
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT p.""НаименованиеПродукции"", p.""ТипПродукции"", p.""Артикул"", 
                                   p.""МинСтоимостьДляПартнера"", p.""ОсновнойМатериал"",
                                   pt.""КоэффицентТипаПродукции""
                            FROM public.""Products"" p
                            LEFT JOIN public.""ProductType"" pt ON p.""ТипПродукции"" = pt.""ТипПродукции""
                            ORDER BY p.""НаименованиеПродукции""";

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
            dataGridViewProducts.RowHeadersVisible = false;

            // Переименование заголовков
            if (dataGridViewProducts.Columns.Count > 0)
            {
                dataGridViewProducts.Columns["НаименованиеПродукции"].HeaderText = "Наименование";
                dataGridViewProducts.Columns["ТипПродукции"].HeaderText = "Тип продукции";
                dataGridViewProducts.Columns["Артикул"].HeaderText = "Артикул";
                dataGridViewProducts.Columns["МинСтоимостьДляПартнера"].HeaderText = "Мин. стоимость";
                dataGridViewProducts.Columns["ОсновнойМатериал"].HeaderText = "Основной материал";
                dataGridViewProducts.Columns["КоэффицентТипаПродукции"].HeaderText = "Коэффициент типа";

                // Форматирование цены
                if (dataGridViewProducts.Columns["МинСтоимостьДляПартнера"] != null)
                    dataGridViewProducts.Columns["МинСтоимостьДляПартнера"].DefaultCellStyle.Format = "F2";
            }
        }

        private void LoadProductTypes()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT \"ТипПродукции\" FROM public.\"ProductType\" ORDER BY \"ТипПродукции\"";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    cmbProductTypeFilter.Items.Clear();
                    cmbProductTypeFilter.Items.Add("Все типы");

                    while (reader.Read())
                    {
                        cmbProductTypeFilter.Items.Add(reader["ТипПродукции"]);
                    }
                    cmbProductTypeFilter.SelectedIndex = 0;
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
                    string query = "SELECT \"ТипМатериала\" FROM public.\"MaterialType\" ORDER BY \"ТипМатериала\"";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    cmbMaterialFilter.Items.Clear();
                    cmbMaterialFilter.Items.Add("Все материалы");

                    while (reader.Read())
                    {
                        cmbMaterialFilter.Items.Add(reader["ТипМатериала"]);
                    }
                    cmbMaterialFilter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки материалов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                (productTypeFilter == "Все типы" || string.IsNullOrEmpty(productTypeFilter) || 
                 row.Field<string>("ТипПродукции") == productTypeFilter) &&
                (materialFilter == "Все материалы" || string.IsNullOrEmpty(materialFilter) || 
                 row.Field<string>("ОсновнойМатериал") == materialFilter)
            );

            if (filteredRows.Any())
            {
                dataGridViewProducts.DataSource = filteredRows.CopyToDataTable();
            }
            else
            {
                dataGridViewProducts.DataSource = productsTable.Clone();
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentUser))
            {
                MessageBox.Show("Для создания заявки необходимо авторизоваться в системе.", "Требуется авторизация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserOrderForm orderForm = new UserOrderForm(currentUser);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Заявка успешно создана!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewProducts.Rows[e.RowIndex].Cells["НаименованиеПродукции"].Value != null)
            {
                string productName = dataGridViewProducts.Rows[e.RowIndex].Cells["НаименованиеПродукции"].Value.ToString();
                ShowProductDetails(productName);
            }
        }

        private void ShowProductDetails(string productName)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT p.""НаименованиеПродукции"", p.""ТипПродукции"", p.""Артикул"", 
                                   p.""МинСтоимостьДляПартнера"", p.""ОсновнойМатериал"",
                                   pt.""КоэффицентТипаПродукции"", mt.""ПроцентПотерьСырья""
                            FROM public.""Products"" p
                            LEFT JOIN public.""ProductType"" pt ON p.""ТипПродукции"" = pt.""ТипПродукции""
                            LEFT JOIN public.""MaterialType"" mt ON p.""ОсновнойМатериал"" = mt.""ТипМатериала""
                            WHERE p.""НаименованиеПродукции"" = '{productName}'";

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string details = $@"Детальная информация о продукции:

Наименование: {reader["НаименованиеПродукции"]}
Тип продукции: {reader["ТипПродукции"]}
Артикул: {reader["Артикул"]}
Минимальная стоимость: {reader["МинСтоимостьДляПартнера"]} руб.
Основной материал: {reader["ОсновнойМатериал"]}
Коэффициент типа: {reader["КоэффицентТипаПродукции"]}
Процент потерь материала: {reader["ПроцентПотерьСырья"]}%";

                        MessageBox.Show(details, "Информация о продукции", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
}