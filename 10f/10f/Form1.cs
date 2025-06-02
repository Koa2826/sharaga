using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace _10f
{
    public partial class AAAA : Form
    {
        int _empLineIndex = -1;
        int _parampampam = 0;

        public AAAA()
        {
            InitializeComponent();
            Post.SelectedIndex = 3;
            Date_of_Birth.MaxDate = new DateTime(DateTime.Today.Year - 14, DateTime.Today.Month, DateTime.Today.Day);
            Date_of_Birth.MinDate = new DateTime(DateTime.Today.Year - 115, DateTime.Today.Month, DateTime.Today.Day);
            Date_of_Birth.Value = Date_of_Birth.MaxDate;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!char.IsPunctuation(Last_Name.Text.ToCharArray()[Last_Name.Text.Length-1]) ||
                !char.IsWhiteSpace(Last_Name.Text.ToCharArray()[Last_Name.Text.Length-1]) ||
                !char.IsPunctuation(Name.Text.ToCharArray()[Name.Text.Length-1]) ||
                !char.IsWhiteSpace(Name.Text.ToCharArray()[Last_Name.Text.Length-1]))
            {
                // MessageBox.Show(@"Пробел, апостроф или тире не может быть последним символом в фамилии/имени ",
                //     @"Ошибка данных");
                Name.Text = Name.Text.Remove(Name.Text.Length - 2);
                Last_Name.Text = Name.Text.Remove(Name.Text.Length - 2);
            }
            // else 
            // { 
                if (string.IsNullOrEmpty(Last_Name.Text) || string.IsNullOrEmpty(Name.Text)
                                                       || string.IsNullOrEmpty(Last_Name.Text)) 
                { 
                    MessageBox.Show(
                        @"Заполните все необходимые поля(Имя, Фамилия, Дата рождения и рабочий стаж должны быть заполнены)", 
                        @"Вы ввели не всю необходимую информацию о сотруднике"); 
                }
                else 
                { 
                    string lastName = Last_Name.Text; 
                    string name = Name.Text; 
                    string patronymic = Patronymic.Text; 
                    DateTime dateOfBirth = Convert.ToDateTime(Date_of_Birth.Text); 
                    int workExperience = Convert.ToInt32(Work_Experience.Text);
                    string post = Post.Text;
                    Employee employee = new Employee(); 
                    Employee.Add_Employee(lastName, name, patronymic, dateOfBirth, workExperience, post); 
                    string[] emp = new string[Employee.GetCount]; 
                    Employees.Lines = Employee.Show_Employees(emp); 
                    double averageAge = 0; 
                    Average_Age_label.Text = Employee.Average_Age(averageAge).ToString(); 
                    string fullname = "dd "; 
                    Max_Work_Experience_label.Text = Employee.Employee_withMax_Work_Experience(fullname); 
                    ResetEmployeeData(sender, e); 
                }
            // }
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            if (_empLineIndex > -1)
            {
                Employee.EditEmployee(_empLineIndex, Last_Name.Text, Name.Text, Patronymic.Text,
                    Date_of_Birth.Text, Work_Experience.Text, Post.Text);
                AfterDeleteEdit(sender, e);
            }
            else
            {
                MessageBox.Show(@"Вы не выбрали сотрудника для изменения данных");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (_empLineIndex > -1)
            {
                Employee.Remove_Employee(_empLineIndex);
                AfterDeleteEdit(sender, e);
            }
            else
            {
                MessageBox.Show(@"Вы не выбрали сотрудника для удаления");
            }
        }

        private void Save_as_File_Click(object sender, EventArgs e)
        {
            if (Employees.Text.Length == 0)
            {
                MessageBox.Show(@"Вы не добавили ни одного сотрудника 
                 Прежде чем вновь пытаться сохранить данные в файл,
                 добавьте хотя бы одного сотрудника",
                    @"Файл не может быть сохранен");
            }
            else
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = "*.txt";
                saveFile1.Filter = @"TXT Files|*.txt";
                saveFile1.FileName = "Сотрудники";
                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                    saveFile1.FileName.Length > 0)
                {
                    Employees.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            ResetEmployeeData(sender, e);
            Employee.AllEmployees.Clear();
            Employees.Clear();
            Average_Age_label.Text = " ";
            Max_Work_Experience_label.Text = " ";
        }

        private void Employee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[\p{L}\s'\-]") && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show(@"Введен неверный символ", @"Ошибка данных");
            }
            string message = "";
            if (!Employee.Pattern(_parampampam, Last_Name.Text, Name.Text, Patronymic.Text, e.KeyChar.ToString(),
                    out message) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show(message, @"Ошибка данных");
            }
        }
        private void Employees_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Employees.Text))
            {
                int selectionStart = Employees.SelectionStart;
                _empLineIndex = Employees.GetLineFromCharIndex(selectionStart);
                new DateTime(2002, 02, 20);
                Employee.Show_Employee(_empLineIndex, out string lastName, out string name, out string patronymic,
                    out string post, out decimal workExperience, out DateTime dateOfBirth);
                Last_Name.Text = lastName;
                Name.Text = name;
                Patronymic.Text = patronymic;
                Post.Text = post;
                Date_of_Birth.Value = dateOfBirth;
                Work_Experience.Value = workExperience;
                Add.Enabled = false;
            }
        }
        private void AfterDeleteEdit(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            string[] emp = new string[Employee.GetCount];
            Employees.Lines = Employee.Show_Employees(emp);
            _empLineIndex = -1;
            ResetEmployeeData(sender, e);
            double averageAge = 0;
            Average_Age_label.Text = Employee.Average_Age(averageAge).ToString();
            string fullname = "dd ";
            Max_Work_Experience_label.Text = Employee.Employee_withMax_Work_Experience(fullname);
        }
        private void ResetEmployeeData(object sender, EventArgs e)
        {
            Name.Clear();
            Last_Name.Clear();
            Patronymic.Clear();
            Post.SelectedIndex = 3;
            Date_of_Birth.Value = Date_of_Birth.MaxDate;
            Work_Experience.Value = 0;
            Add.Enabled = true;
        }
        private void Name_Click(object sender, EventArgs e)
        {
            _parampampam = 2;
        }

        private void Patronymic_Click(object sender, EventArgs e)
        {
            _parampampam = 3;
        }

        private void Last_Name_Click(object sender, EventArgs e)
        {
            _parampampam = 1;
            // if (!string.IsNullOrEmpty(Name.Text))
            // {
            //     Console.WriteLine(Name.Text.ToCharArray()[Last_Name.Text.Length]);
            //     if (char.IsPunctuation(Name.Text.ToCharArray()[Last_Name.Text.Length]))
            //     {
            //         Name.Text += "j";
            //         Name.Text = Name.Text.Remove(Name.Text.Length - 1);
            //     }
            // }
        }

        private void RightClick_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Employee_Data.Enabled = false;
                MessageBox.Show(@"не тыкать тут правой кнопкой мыши");
                Employee_Data.Enabled = true;
            }
        }
    }
}
