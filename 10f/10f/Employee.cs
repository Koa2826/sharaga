using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10f
{
    internal class Employee
    { 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int WorkExperience { get; set; }
        public string Post { get; set; }
        public Employee()
        {
            this.LastName = "я устал помогите";
            this.Name = "я устал помогите";
            this.Patronymic = "я устал помогите";
            //this.date_of_birth = "02-февраль-1905";
            this.WorkExperience = 100;
        }
        private Employee(string lastName, string name, string patronymic, DateTime dateOfBirth, int workExperience,
            string post)
        {
            this.LastName = lastName;
            this.Name = name;
            this.Patronymic = patronymic;
            this.DateOfBirth = dateOfBirth;
            this.WorkExperience = workExperience;
            this.Post = post;
        }
        public static readonly List<Employee> AllEmployees = new List<Employee>();
        public static void Add_Employee(string lastName, string name, string patronymic, DateTime dateOfBirth,
            int workExperience, string post)
        {
            Employee employees = new Employee(lastName, name, patronymic, dateOfBirth, workExperience, post);
            AllEmployees.Add(employees);
        }
        public static void Remove_Employee(int empIndex)
        {
            AllEmployees.RemoveAt(empIndex);
        }
        public static void EditEmployee(int empIndex, string lastName, string name, string patronymic,
            string dateOfBirth, string workExperience, string post)
        {
            AllEmployees[empIndex].LastName=lastName;
            AllEmployees[empIndex].Name=name;
            AllEmployees[empIndex].Patronymic=patronymic;
            AllEmployees[empIndex].Post=post;
            AllEmployees[empIndex].DateOfBirth= Convert.ToDateTime(dateOfBirth);; 
            AllEmployees[empIndex].WorkExperience=Convert.ToInt32(workExperience);
        }
        public static string[] Show_Employees(string[] emp)
        {
            emp = new string[AllEmployees.Count];
            for (int i = 0; i < AllEmployees.Count; i++)
            {
                emp[i] = ($" ФИО: {(AllEmployees[i].LastName)} {AllEmployees[i].Name} {AllEmployees[i].Patronymic}" +
                $" Должность: {AllEmployees[i].Post} Дата рождения:{AllEmployees[i].DateOfBirth:dd/MM/yyyy}" +
                $" Рабочий стаж:{AllEmployees[i].WorkExperience}");
            }
            return emp;
        }
        public static void Show_Employee(int empIndex, out string lastName, out string name, out string patronymic,
            out string post, out decimal workExperience, out DateTime dateOfBirth)
        {
            lastName= AllEmployees[empIndex].LastName;
            name=AllEmployees[empIndex].Name;
            patronymic=AllEmployees[empIndex].Patronymic;
            post=AllEmployees[empIndex].Post;
            dateOfBirth=AllEmployees[empIndex].DateOfBirth; 
            workExperience=AllEmployees[empIndex].WorkExperience;
        }
        public static double Average_Age(double averageAge)
        {
            double currentYear = Convert.ToDouble(DateTime.Now.Year);
            int k = 0;
            averageAge = 0;
            for (int i = 0; i < AllEmployees.Count; i++)
            {
                double age = currentYear - Convert.ToDouble(AllEmployees[i].DateOfBirth.Year);
                averageAge += age;
                k++;
            }
            averageAge = averageAge / k;
            if (AllEmployees.Count == 0) averageAge = 0;
            return Math.Round(averageAge);
        }
        public static string Employee_withMax_Work_Experience(string fullname)
        {
            int max = 0;
            for (int i = 0; i < AllEmployees.Count; i++) 
            { 
              if (max <= AllEmployees[i].WorkExperience) 
              {
                 max = AllEmployees[i].WorkExperience;
                 fullname = ($"{AllEmployees[i].LastName}\n{AllEmployees[i].Name}\n{AllEmployees[i].Patronymic}"); 
              }
            }
            if (AllEmployees.Count == 0) fullname = null;
            return fullname;
        }
        public static int GetCount => AllEmployees.Count(); //нужно
        private static bool ForLastName(int k,char[] correctWord)
        {
            bool result = true;
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (Char.IsPunctuation(correctWord[i]) || Char.IsWhiteSpace(correctWord[i])) k++;
                if (k > 1 || Char.IsPunctuation(correctWord[0]) || Char.IsWhiteSpace(correctWord[0]))
                {
                    result = false;
                }
            }
            return result;
        }
        private static bool ForName(int k,char[] correctWord)
        {
            bool result = true;
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (Char.IsPunctuation(correctWord[i])) k++; 
                if (k > 1 || Char.IsPunctuation(correctWord[0]) ||
                    (Char.IsPunctuation(correctWord[i]) && correctWord[i] != '-'))
                    result = false;
                if (Char.IsWhiteSpace(correctWord[i]))
                    result = false;
            }
            return result;
        }
        private static bool ForPatronymic(int k,string letter)
        {
            bool result = Char.IsLetter(Convert.ToChar(letter));
            return result;
        }
        private static bool Correctness(string parameter,string letter, int parampampam)
        {
            bool result = true;
            int k = 0;
            parameter += letter;
            char[] correctWord = parameter.ToCharArray();
            for (int i = 0; i < correctWord.Length; i++)
            {
                switch (parampampam)
                {
                    case 1:result=ForLastName(k,correctWord);break;
                    case 2:result=ForName(k, correctWord);break;
                    case 3:result=ForPatronymic(k, letter);break;
                }
            }
            return result;
        }
        public static bool Pattern(int parampampam, string lastName, string name, string patronymic, string letter,
            out string message)
        {
            bool correctness = true;
            string parameter = "";
            message = "";
            switch (parampampam)
            {
                case 1:parameter=lastName;break;
                case 2:parameter=name;break;
                case 3:parameter=patronymic;break;
            }
            if (parameter.Length >=30) 
            {
                correctness = false;
                message = "Превышен лимит символов";
            }
            if (!Correctness(parameter,letter,parampampam)) 
            {
                correctness = false;
                message = "Некорректный ввод фамилии/имени/отчества";
            }
            return correctness;
        }
        public static void LastSymbol(int parampampam, string lastName, string name, string patronymic,
            out string parameter)
        {
            parameter = "";
            switch (parampampam)
            {
                case 1:parameter=lastName;break;
                case 2:parameter=name;break;
                case 3:parameter=patronymic;break;
            }
            char[] correctWord = parameter.ToCharArray();
            if (Char.IsPunctuation(correctWord[correctWord.Length]) ||
                Char.IsWhiteSpace(correctWord[correctWord.Length]))
            {
                for (int i = 0; i < correctWord.Length - 1; i++)
                {
                    parameter += correctWord[i].ToString();
                }
            }
        }
    }
}