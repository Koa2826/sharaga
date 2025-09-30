using System.ComponentModel;
using System.Data;
using Npgsql;

namespace Me;

public partial class OrdersViewForm : Form
{
    public OrdersViewForm()
    {
        InitializeComponent();
    }
     private string connectionString =   "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
        private string currentUser;
        private string userRole;
        private DataTable ordersTable;
        private Container components;

        public OrdersViewForm(string username = null, string role = null)
        {
            InitializeComponent();
            currentUser = username;
            userRole = role;
            LoadOrders();
            CheckPermissions();
        }

        private void CheckPermissions()
        {
            bool isAdmin = userRole?.ToLower() == "администратор";
            bool isManager = userRole?.ToLower() == "менеджер";
            
            // Администраторы и менеджеры могут видеть все заявки
            if (isAdmin || isManager)
            {
                lblFilterUser.Visible = false;
                txtFilterUser.Visible = false;
            }
            else
            {
                // Обычные пользователи видят только свои заявки
                txtFilterUser.Text = currentUser;
                txtFilterUser.Enabled = false;
            }

            btnUpdateStatus.Enabled = isAdmin || isManager;
            btnDeleteOrder.Enabled = isAdmin;
        }

        private void LoadOrders()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string query = @"SELECT o.""ID"", o.""НомерЗаявки"", o.""ЛогинПользователя"", 
                                   o.""НаименованиеПродукции"", o.""Количество"", o.""Статус"", 
                                   o.""ДатаСоздания"", o.""Телефон"", o.""Email"", o.""Комментарий"",
                                   p.""МинСтоимостьДляПартнера"",
                                   (o.""Количество"" * p.""МинСтоимостьДляПартнера"") as ""ОбщаяСтоимость""
                            FROM public.""UserOrders"" o
                            JOIN public.""Products"" p ON o.""НаименованиеПродукции"" = p.""НаименованиеПродукции""";

                    // Если обычный пользователь - показываем только его заявки
                    if (!string.IsNullOrEmpty(currentUser) && userRole?.ToLower() != "администратор" && userRole?.ToLower() != "менеджер")
                    {
                        query += " WHERE o.\"ЛогинПользователя\" = @username";
                    }

                    query += " ORDER BY o.\"ДатаСоздания\" DESC";

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    
                    if (!string.IsNullOrEmpty(currentUser) && userRole?.ToLower() != "администратор" && userRole?.ToLower() != "менеджер")
                    {
                        command.Parameters.AddWithValue("@username", currentUser);
                    }

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    ordersTable = new DataTable();
                    adapter.Fill(ordersTable);

                    dataGridViewOrders.DataSource = ordersTable;
                    ConfigureDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataGridViewOrders.Columns.Count > 0)
            {
                dataGridViewOrders.Columns["ID"].Visible = false;
                dataGridViewOrders.Columns["НомерЗаявки"].HeaderText = "Номер заявки";
                dataGridViewOrders.Columns["ЛогинПользователя"].HeaderText = "Пользователь";
                dataGridViewOrders.Columns["НаименованиеПродукции"].HeaderText = "Продукция";
                dataGridViewOrders.Columns["Количество"].HeaderText = "Количество";
                dataGridViewOrders.Columns["Статус"].HeaderText = "Статус";
                dataGridViewOrders.Columns["ДатаСоздания"].HeaderText = "Дата создания";
                dataGridViewOrders.Columns["Телефон"].HeaderText = "Телефон";
                dataGridViewOrders.Columns["Email"].HeaderText = "Email";
                dataGridViewOrders.Columns["Комментарий"].HeaderText = "Комментарий";
                dataGridViewOrders.Columns["МинСтоимостьДляПартнера"].HeaderText = "Цена за ед.";
                dataGridViewOrders.Columns["ОбщаяСтоимость"].HeaderText = "Общая стоимость";

                // Форматирование столбцов
                if (dataGridViewOrders.Columns["МинСтоимостьДляПартнера"] != null)
                    dataGridViewOrders.Columns["МинСтоимостьДляПартнера"].DefaultCellStyle.Format = "F2";
                
                if (dataGridViewOrders.Columns["ОбщаяСтоимость"] != null)
                    dataGridViewOrders.Columns["ОбщаяСтоимость"].DefaultCellStyle.Format = "F2";
                
                if (dataGridViewOrders.Columns["ДатаСоздания"] != null)
                    dataGridViewOrders.Columns["ДатаСоздания"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            UserOrderForm orderForm = new UserOrderForm(currentUser);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders(); // Обновляем список после создания заявки
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для изменения статуса.", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string orderNumber = dataGridViewOrders.SelectedRows[0].Cells["НомерЗаявки"].Value.ToString();
            string currentStatus = dataGridViewOrders.SelectedRows[0].Cells["Статус"].Value.ToString();

            StatusUpdateForm statusForm = new StatusUpdateForm(orderNumber, currentStatus, currentUser);
            if (statusForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders(); // Обновляем список после изменения статуса
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для удаления.", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string orderNumber = dataGridViewOrders.SelectedRows[0].Cells["НомерЗаявки"].Value.ToString();
            
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить заявку '{orderNumber}'?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteOrder(orderNumber);
                    LoadOrders();
                    MessageBox.Show("Заявка успешно удалена.", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении заявки: {ex.Message}", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteOrder(string orderNumber)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                // Удаляем из истории статусов (каскадное удаление)
                string deleteHistoryQuery = $"DELETE FROM public.\"OrderStatusHistory\" WHERE \"НомерЗаявки\" = '{orderNumber}'";
                NpgsqlCommand historyCommand = new NpgsqlCommand(deleteHistoryQuery, connection);
                historyCommand.ExecuteNonQuery();
                
                // Удаляем саму заявку
                string deleteOrderQuery = $"DELETE FROM public.\"UserOrders\" WHERE \"НомерЗаявки\" = '{orderNumber}'";
                NpgsqlCommand orderCommand = new NpgsqlCommand(deleteOrderQuery, connection);
                orderCommand.ExecuteNonQuery();
            }
        }

        private void txtFilterUser_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (ordersTable == null) return;

            string searchText = txtSearch.Text.ToLower();
            string userFilter = txtFilterUser.Text.ToLower();
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString();

            var filteredRows = ordersTable.AsEnumerable().Where(row =>
                (string.IsNullOrEmpty(searchText) || 
                 row.Field<string>("НомерЗаявки")?.ToLower().Contains(searchText) == true ||
                 row.Field<string>("НаименованиеПродукции")?.ToLower().Contains(searchText) == true ||
                 row.Field<string>("ЛогинПользователя")?.ToLower().Contains(searchText) == true) &&
                (string.IsNullOrEmpty(userFilter) || 
                 row.Field<string>("ЛогинПользователя")?.ToLower().Contains(userFilter) == true) &&
                (string.IsNullOrEmpty(statusFilter) || 
                 row.Field<string>("Статус") == statusFilter)
            );

            if (filteredRows.Any())
            {
                dataGridViewOrders.DataSource = filteredRows.CopyToDataTable();
            }
            else
            {
                dataGridViewOrders.DataSource = ordersTable.Clone();
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для просмотра истории.", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string orderNumber = dataGridViewOrders.SelectedRows[0].Cells["НомерЗаявки"].Value.ToString();
            // OrderHistoryForm historyForm = new OrderHistoryForm(orderNumber);
            // historyForm.ShowDialog();
        }

        // private void CheckPermissions()
        // {
        //     bool isAdmin = userRole?.ToLower() == "администратор";
        //     bool isManager = userRole?.ToLower() == "менеджер";
        //     bool isUser = !string.IsNullOrEmpty(currentUser);
        //
        //     // Обычные пользователи видят только свои заявки
        //     if (!isAdmin && !isManager)
        //     {
        //         lblFilterUser.Visible = false;
        //         txtFilterUser.Visible = false;
        //         txtFilterUser.Text = currentUser;
        //         txtFilterUser.Enabled = false;
        //     }
        //     else
        //     {
        //         // Администраторы и менеджеры могут фильтровать по пользователям
        //         lblFilterUser.Visible = true;
        //         txtFilterUser.Visible = true;
        //         txtFilterUser.Enabled = true;
        //     }
        //
        //     // Только менеджеры и администраторы могут изменять статусы
        //     btnUpdateStatus.Enabled = isAdmin || isManager;
        //
        //     // Только администраторы могут удалять заявки
        //     btnDeleteOrder.Enabled = isAdmin;
        //
        //     // Все авторизованные пользователи могут создавать заявки
        //     btnCreateOrder.Enabled = isUser;
        //
        //     // Информация о правах
        //     if (isAdmin)
        //     {
        //         lblUserRights.Text = "Права: Администратор (полный доступ)";
        //     }
        //     else if (isManager)
        //     {
        //         lblUserRights.Text = "Права: Менеджер (может изменять статусы)";
        //     }
        //     else if (isUser)
        //     {
        //         lblUserRights.Text = "Права: Пользователь (может создавать заявки)";
        //     }
        // }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
}
