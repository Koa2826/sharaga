using System.ComponentModel;
using System.Data;
using Npgsql;

namespace Me;

public partial class ProductWorkshopsForm : Form
{
    private Container components;
        public ProductWorkshopsForm()
        {
            InitializeComponent();
            LoadProducts();
            lblParam1.Text = "Длина изделия (м):";
            lblParam2.Text = "Ширина изделия (м):";
        }
        private const string connectionString =
            "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";

        private void LoadProducts()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query =
                        "SELECT \"НаименованиеПродукции\" FROM public.\"Products\" ORDER BY \"НаименованиеПродукции\"";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    cmbProducts.Items.Clear();
                    while (reader.Read())
                    {
                        cmbProducts.Items.Add(reader["НаименованиеПродукции"]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продукции: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem != null)
            {
                LoadWorkshopsForProduct(cmbProducts.SelectedItem.ToString());
            }
        }

        private void LoadWorkshopsForProduct(string productName)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT pw.""НазваниецЦеха"", w.""ТипЦеха"", w.""КолвоЧеловекДляПроизводства"", 
                                   pw.""ВремяИзготовления(ч)""
                            FROM public.""ProductWorkshops"" pw
                            JOIN public.""Workshops"" w ON pw.""НазваниецЦеха"" = w.""НазваниеЦеха""
                            WHERE pw.""НаименованиеПродукции"" = '{productName}'";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewWorkshops.DataSource = table;
                    ConfigureWorkshopsDataGridView();

                    // Расчет общего времени изготовления
                    CalculateTotalTime(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки цехов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureWorkshopsDataGridView()
        {
            dataGridViewWorkshops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewWorkshops.ReadOnly = true;

            if (dataGridViewWorkshops.Columns.Count > 0)
            {
                dataGridViewWorkshops.Columns["НазваниецЦеха"].HeaderText = "Название цеха";
                dataGridViewWorkshops.Columns["ТипЦеха"].HeaderText = "Тип цеха";
                dataGridViewWorkshops.Columns["КолвоЧеловекДляПроизводства"].HeaderText = "Количество человек";
                dataGridViewWorkshops.Columns["ВремяИзготовления(ч)"].HeaderText = "Время изготовления (ч)";
            }
        }

        private void CalculateTotalTime(DataTable table)
        {
            decimal totalTime = 0;
            foreach (DataRow row in table.Rows)
            {
                if (decimal.TryParse(row["ВремяИзготовления(ч)"].ToString(), out decimal time))
                {
                    totalTime += time;
                }
            }

            lblTotalTime.Text = $"Общее время изготовления: {totalTime} часов";
        }

      private void btnCalculateRawMaterials_Click(object sender, EventArgs e)
{
    if (cmbProducts.SelectedItem == null)
    {
        MessageBox.Show("Выберите продукт для расчета.", "Информация", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }

    if (!int.TryParse(txtProductQuantity.Text, out int quantity) || quantity <= 0)
    {
        MessageBox.Show("Введите корректное количество продукции (целое положительное число).", "Ошибка", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    if (!double.TryParse(txtParam1.Text, out double param1) || param1 <= 0 ||
        !double.TryParse(txtParam2.Text, out double param2) || param2 <= 0)
    {
        MessageBox.Show("Введите корректные параметры продукции (положительные числа).", "Ошибка", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    // Получаем данные для расчета
    string productName = cmbProducts.SelectedItem.ToString();
    string materialType = GetProductMaterial(productName);

    if (string.IsNullOrEmpty(materialType))
    {
        MessageBox.Show("Не удалось определить материал для выбранной продукции.", "Ошибка", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    // Вызов метода расчета сырья
    int result = CalculateRawMaterialRequired(productName, materialType, quantity, param1, param2);

    if (result == -1)
    {
        MessageBox.Show("Ошибка расчета. Проверьте корректность данных или наличие продукции и материала в базе данных.", "Ошибка", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else
    {
        // Показываем результат расчета
        ShowCalculationResult(result, productName, materialType, quantity, param1, param2);
    }
}

public int CalculateRawMaterialRequired(string productName, string materialType, 
                                      int productQuantity, double param1, double param2)
{
    try
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // Получаем коэффициент типа продукции
            string productTypeQuery = $@"SELECT pt.""КоэффицентТипаПродукции"" 
                                       FROM public.""Products"" p
                                       JOIN public.""ProductType"" pt ON p.""ТипПродукции"" = pt.""ТипПродукции""
                                       WHERE p.""НаименованиеПродукции"" = '{productName}'";
            NpgsqlCommand productTypeCommand = new NpgsqlCommand(productTypeQuery, connection);
            var productTypeCoefficientObj = productTypeCommand.ExecuteScalar();

            if (productTypeCoefficientObj == null || !double.TryParse(productTypeCoefficientObj.ToString(), out double productTypeCoefficient))
            {
                return -1;
            }

            // Получаем процент потерь сырья
            string materialLossQuery = $@"SELECT ""ПроцентПотерьСырья"" FROM public.""MaterialType"" 
                                        WHERE ""ТипМатериала"" = '{materialType}'";
            NpgsqlCommand materialLossCommand = new NpgsqlCommand(materialLossQuery, connection);
            var materialLossObj = materialLossCommand.ExecuteScalar();

            if (materialLossObj == null || !double.TryParse(materialLossObj.ToString(), out double materialLossPercent))
            {
                return -1;
            }

            // Расчет количества сырья на одну единицу продукции
            double rawMaterialPerUnit = param1 * param2 * productTypeCoefficient;
            
            // Учет потерь сырья
            double totalRawMaterialNeeded = rawMaterialPerUnit * productQuantity;
            double totalWithLosses = totalRawMaterialNeeded * (1 + materialLossPercent / 100);
            
            // Округляем до целого числа в большую сторону
            return (int)Math.Ceiling(totalWithLosses);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Ошибка расчета сырья: {ex.Message}", "Ошибка", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return -1;
    }
}

private void ShowCalculationResult(int rawMaterialRequired, string productName, string materialType, 
                                  int quantity, double param1, double param2)
{
    string message = $@"Результат расчета:

Продукция: {productName}
Материал: {materialType}
Количество продукции: {quantity} шт.
Длина изделия: {param1} м
Ширина изделия: {param2} м

Требуемое количество сырья: {rawMaterialRequired} единиц

*Примечание: расчет учитывает технологические потери материала при производстве*";

    MessageBox.Show(message, "Результат расчета сырья", 
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}

private string GetProductMaterial(string productName)
{
    try
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = $@"SELECT ""ОсновнойМатериал"" FROM public.""Products"" 
                           WHERE ""НаименованиеПродукции"" = '{productName}'";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteScalar();
            return result?.ToString();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Ошибка получения материала: {ex.Message}", "Ошибка", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
    }
}

private void btnBack_Click(object sender, EventArgs e)
{
    this.Close();
}
}