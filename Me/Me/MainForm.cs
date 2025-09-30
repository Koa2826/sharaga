namespace Me;

public partial class MainForm : Form
{
    private string connectionString = "Server=localhost;Database=aaaaaaaaaaaaaaa;User Id=postgres;Password=koa2826ver;";
    private string currentUser;
        private string userRole;

        public MainForm(string username = null, string role = null)
        {
            InitializeComponent();
            currentUser = username;
            userRole = role;
            UpdateUserInfo();
            CheckPermissions();
        }

        private void UpdateUserInfo()
        {
            if (!string.IsNullOrEmpty(currentUser))
            {
                lblUserInfo.Text = $"Пользователь: {currentUser}";
                lblUserRole.Text = $"Роль: {userRole}";
                btnLogout.Visible = true;
            }
            else
            {
                lblUserInfo.Text = "Гость";
                lblUserRole.Text = "Роль: Гость";
                btnLogout.Visible = false;
            }
        }

        private void CheckPermissions()
        {
            bool isAdmin = userRole?.ToLower() == "администратор";
            bool isManager = userRole?.ToLower() == "менеджер";
            bool isUser = !string.IsNullOrEmpty(currentUser);
            bool isGuest = string.IsNullOrEmpty(currentUser);

            // Настройка видимости кнопок в зависимости от роли
            
            // Управление товарами - только администратор
            btnProducts.Enabled = isAdmin;
            btnProducts.Visible = isAdmin;

            // Цеха производства - все авторизованные пользователи
            btnWorkshops.Enabled = isUser || isGuest;
            btnWorkshops.Visible = true;

            // Заявки - только авторизованные пользователи (не гости)
            btnOrders.Enabled = isUser;
            btnOrders.Visible = isUser;

            // Просмотр продукции - доступно всем (включая гостей)
            btnViewProducts.Enabled = true;
            btnViewProducts.Visible = true;

            // Настройка цветов для ролей
            if (isAdmin)
            {
                lblUserRole.ForeColor = Color.Red;
            }
            else if (isManager)
            {
                lblUserRole.ForeColor = Color.Blue;
            }
            else if (isUser)
            {
                lblUserRole.ForeColor = Color.Green;
            }
            else
            {
                lblUserRole.ForeColor = Color.Gray;
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm(currentUser, userRole);
            productsForm.ShowDialog();
        }

        private void btnWorkshops_Click(object sender, EventArgs e)
        {
            ProductWorkshopsForm workshopsForm = new ProductWorkshopsForm();
            workshopsForm.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersViewForm ordersForm = new OrdersViewForm(currentUser, userRole);
            ordersForm.ShowDialog();
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ProductsViewForm viewForm = new ProductsViewForm(currentUser, userRole);
            viewForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
}