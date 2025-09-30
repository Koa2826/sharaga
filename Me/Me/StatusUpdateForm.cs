using System.ComponentModel;
using System.Data;
using Npgsql;

namespace Me;

public partial class StatusUpdateForm : Form
{
   private string connectionString =  "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
        private string orderNumber;
        private string currentStatus;
        private string currentUser;
        private Container components;

        public StatusUpdateForm(string orderNum, string status, string username)
        {
            InitializeComponent();
            orderNumber = orderNum;
            currentStatus = status;
            currentUser = username;
            InitializeForm();
            LoadStatusHistory();
        }

        private void InitializeForm()
        {
            this.Text = $"Изменение статуса заявки: {orderNumber}";
            lblOrderNumber.Text = $"Заявка: {orderNumber}";
            lblCurrentStatus.Text = $"Текущий статус: {currentStatus}";

            // Заполняем комбобокс доступными статусами
            string[] allStatuses = { "Новая", "В обработке", "Подтверждена", "В производстве", "Готово", "Отменена" };
            cmbNewStatus.Items.AddRange(allStatuses);
            
            // Устанавливаем текущий статус как выбранный
            cmbNewStatus.SelectedItem = currentStatus;

            // Загружаем информацию о заявке
            LoadOrderInfo();
        }

        private void LoadOrderInfo()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT o.""ЛогинПользователя"", o.""НаименованиеПродукции"", 
                                   o.""Количество"", o.""Телефон"", o.""Email"", o.""Комментарий"",
                                   p.""МинСтоимостьДляПартнера"",
                                   (o.""Количество"" * p.""МинСтоимостьДляПартнера"") as ""ОбщаяСтоимость""
                            FROM public.""UserOrders"" o
                            JOIN public.""Products"" p ON o.""НаименованиеПродукции"" = p.""НаименованиеПродукции""
                            WHERE o.""НомерЗаявки"" = '{orderNumber}'";

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtCustomer.Text = reader["ЛогинПользователя"].ToString();
                        txtProduct.Text = reader["НаименованиеПродукции"].ToString();
                        txtQuantity.Text = reader["Количество"].ToString();
                        txtPhone.Text = reader["Телефон"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtCustomerComment.Text = reader["Комментарий"]?.ToString() ?? "";
                        
                        decimal price = Convert.ToDecimal(reader["МинСтоимостьДляПартнера"]);
                        decimal total = Convert.ToDecimal(reader["ОбщаяСтоимость"]);
                        
                        txtPrice.Text = price.ToString("F2");
                        txtTotalAmount.Text = total.ToString("F2");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки информации о заявке: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusHistory()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT ""СтарыйСтатус"", ""НовыйСтатус"", ""ДатаИзменения"", 
                                   ""КтоИзменил"", ""Комментарий""
                            FROM public.""OrderStatusHistory""
                            WHERE ""НомерЗаявки"" = '{orderNumber}'
                            ORDER BY ""ДатаИзменения"" DESC";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable historyTable = new DataTable();
                    adapter.Fill(historyTable);

                    dataGridViewHistory.DataSource = historyTable;
                    ConfigureHistoryDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки истории статусов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureHistoryDataGridView()
        {
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHistory.ReadOnly = true;
            dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataGridViewHistory.Columns.Count > 0)
            {
                dataGridViewHistory.Columns["СтарыйСтатус"].HeaderText = "Предыдущий статус";
                dataGridViewHistory.Columns["НовыйСтатус"].HeaderText = "Новый статус";
                dataGridViewHistory.Columns["ДатаИзменения"].HeaderText = "Дата изменения";
                dataGridViewHistory.Columns["КтоИзменил"].HeaderText = "Кто изменил";
                dataGridViewHistory.Columns["Комментарий"].HeaderText = "Комментарий";

                // Форматирование даты
                if (dataGridViewHistory.Columns["ДатаИзменения"] != null)
                    dataGridViewHistory.Columns["ДатаИзменения"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (cmbNewStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите новый статус.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newStatus = cmbNewStatus.SelectedItem.ToString();

            if (newStatus == currentStatus)
            {
                MessageBox.Show("Новый статус совпадает с текущим. Изменение не требуется.", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateStatusTransition(currentStatus, newStatus))
            {
                MessageBox.Show($"Недопустимый переход статуса: {currentStatus} -> {newStatus}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UpdateOrderStatus(newStatus);
                MessageBox.Show($"Статус заявки успешно изменен на: {newStatus}", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении статуса: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateStatusTransition(string fromStatus, string toStatus)
        {
            // Определяем допустимые переходы статусов
            var allowedTransitions = new System.Collections.Generic.Dictionary<string, string[]>
            {
                { "Новая", new[] { "В обработке", "Подтверждена", "Отменена" } },
                { "В обработке", new[] { "Подтверждена", "Отменена" } },
                { "Подтверждена", new[] { "В производстве", "Отменена" } },
                { "В производстве", new[] { "Готово", "Отменена" } },
                { "Готово", new string[] { } }, // Финальный статус
                { "Отменена", new string[] { } } // Финальный статус
            };

            if (allowedTransitions.ContainsKey(fromStatus))
            {
                return Array.IndexOf(allowedTransitions[fromStatus], toStatus) >= 0;
            }

            return false;
        }

        private void UpdateOrderStatus(string newStatus)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Обновляем статус в основной таблице
                        string updateOrderQuery = @"UPDATE public.""UserOrders"" 
                                                  SET ""Статус"" = @newStatus, 
                                                      ""ДатаИзменения"" = NOW() 
                                                  WHERE ""НомерЗаявки"" = @orderNumber";

                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateOrderQuery, connection, transaction);
                        updateCommand.Parameters.AddWithValue("@newStatus", newStatus);
                        updateCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
                        updateCommand.ExecuteNonQuery();

                        // Записываем изменение в историю
                        string insertHistoryQuery = @"INSERT INTO public.""OrderStatusHistory"" 
                                                    (""НомерЗаявки"", ""СтарыйСтатус"", ""НовыйСтатус"", 
                                                     ""КтоИзменил"", ""Комментарий"") 
                                                    VALUES (@orderNumber, @oldStatus, @newStatus, 
                                                            @changedBy, @comment)";

                        NpgsqlCommand historyCommand = new NpgsqlCommand(insertHistoryQuery, connection, transaction);
                        historyCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
                        historyCommand.Parameters.AddWithValue("@oldStatus", string.IsNullOrEmpty(currentStatus) ? (object)DBNull.Value : currentStatus);
                        historyCommand.Parameters.AddWithValue("@newStatus", newStatus);
                        historyCommand.Parameters.AddWithValue("@changedBy", currentUser ?? "Система");
                        historyCommand.Parameters.AddWithValue("@comment", string.IsNullOrWhiteSpace(txtComment.Text) ? (object)DBNull.Value : txtComment.Text);

                        historyCommand.ExecuteNonQuery();

                        transaction.Commit();

                        // Отправляем уведомление при определенных статусах
                        SendStatusNotification(newStatus);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void SendStatusNotification(string newStatus)
        {
            // Здесь можно реализовать отправку уведомлений (email, смс и т.д.)
            // В данном примере просто выводим информационное сообщение
            string customerEmail = txtEmail.Text;
            string customerPhone = txtPhone.Text;

            string notificationMessage = $@"Статус вашей заявки {orderNumber} изменен:
Старый статус: {currentStatus}
Новый статус: {newStatus}";

            if (!string.IsNullOrEmpty(txtComment.Text))
            {
                notificationMessage += $"\nКомментарий: {txtComment.Text}";
            }

            // В реальном приложении здесь был бы код отправки email/SMS
            // Например: EmailService.Send(customerEmail, "Изменение статуса заявки", notificationMessage);
            
            Console.WriteLine($"Уведомление отправлено: {notificationMessage}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbNewStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatusValidation();
        }

        private void UpdateStatusValidation()
        {
            if (cmbNewStatus.SelectedItem != null)
            {
                string newStatus = cmbNewStatus.SelectedItem.ToString();
                bool isValidTransition = ValidateStatusTransition(currentStatus, newStatus);
                
                btnUpdateStatus.Enabled = isValidTransition && newStatus != currentStatus;
                
                if (!isValidTransition && newStatus != currentStatus)
                {
                    lblValidation.Text = $"Недопустимый переход: {currentStatus} → {newStatus}";
                    lblValidation.ForeColor = System.Drawing.Color.Red;
                }
                else if (newStatus == currentStatus)
                {
                    lblValidation.Text = "Статус не изменился";
                    lblValidation.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    lblValidation.Text = $"Допустимый переход: {currentStatus} → {newStatus}";
                    lblValidation.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
}