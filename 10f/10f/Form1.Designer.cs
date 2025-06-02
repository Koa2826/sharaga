using System.Windows.Forms;

namespace _10f
{
    partial class AAAA
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AAAA));
            this.Name_label = new System.Windows.Forms.Label();
            this.Patronymic_label = new System.Windows.Forms.Label();
            this.Last_Name_label = new System.Windows.Forms.Label();
            this.Date_of_Birth_label = new System.Windows.Forms.Label();
            this.Work_Experience_label = new System.Windows.Forms.Label();
            this.Work_Experience = new System.Windows.Forms.NumericUpDown();
            this.Date_of_Birth = new System.Windows.Forms.DateTimePicker();
            this.Employees = new System.Windows.Forms.RichTextBox();
            this.Last_Name = new System.Windows.Forms.TextBox();
            this.Patronymic = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.Employee_Data = new System.Windows.Forms.GroupBox();
            this.Post_label = new System.Windows.Forms.Label();
            this.Post = new System.Windows.Forms.ComboBox();
            this.Average_Age_groupBox = new System.Windows.Forms.GroupBox();
            this.Average_Age_label = new System.Windows.Forms.Label();
            this.Work_Experience_groupBox = new System.Windows.Forms.GroupBox();
            this.Max_Work_Experience_label = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Save_as_File = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Work_Experience)).BeginInit();
            this.Employee_Data.SuspendLayout();
            this.Average_Age_groupBox.SuspendLayout();
            this.Work_Experience_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(73, 32);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(35, 17);
            this.Name_label.TabIndex = 0;
            this.Name_label.Text = "Имя";
            // 
            // Patronymic_label
            // 
            this.Patronymic_label.AutoSize = true;
            this.Patronymic_label.Location = new System.Drawing.Point(73, 60);
            this.Patronymic_label.Name = "Patronymic_label";
            this.Patronymic_label.Size = new System.Drawing.Size(71, 17);
            this.Patronymic_label.TabIndex = 1;
            this.Patronymic_label.Text = "Отчество";
            // 
            // Last_Name_label
            // 
            this.Last_Name_label.AutoSize = true;
            this.Last_Name_label.Location = new System.Drawing.Point(73, 88);
            this.Last_Name_label.Name = "Last_Name_label";
            this.Last_Name_label.Size = new System.Drawing.Size(62, 17);
            this.Last_Name_label.TabIndex = 2;
            this.Last_Name_label.Text = "Фамлия";
            // 
            // Date_of_Birth_label
            // 
            this.Date_of_Birth_label.AutoSize = true;
            this.Date_of_Birth_label.Location = new System.Drawing.Point(73, 150);
            this.Date_of_Birth_label.Name = "Date_of_Birth_label";
            this.Date_of_Birth_label.Size = new System.Drawing.Size(111, 17);
            this.Date_of_Birth_label.TabIndex = 3;
            this.Date_of_Birth_label.Text = "Дата рождения";
            // 
            // Work_Experience_label
            // 
            this.Work_Experience_label.AutoSize = true;
            this.Work_Experience_label.Location = new System.Drawing.Point(73, 175);
            this.Work_Experience_label.Name = "Work_Experience_label";
            this.Work_Experience_label.Size = new System.Drawing.Size(94, 17);
            this.Work_Experience_label.TabIndex = 4;
            this.Work_Experience_label.Text = "Стаж работы";
            // 
            // Work_Experience
            // 
            this.Work_Experience.Location = new System.Drawing.Point(193, 173);
            this.Work_Experience.Maximum = new decimal(new int[] { 101, 0, 0, 0 });
            this.Work_Experience.Name = "Work_Experience";
            this.Work_Experience.Size = new System.Drawing.Size(52, 22);
            this.Work_Experience.TabIndex = 5;
            // 
            // Date_of_Birth
            // 
            this.Date_of_Birth.Location = new System.Drawing.Point(193, 145);
            this.Date_of_Birth.Name = "Date_of_Birth";
            this.Date_of_Birth.Size = new System.Drawing.Size(159, 22);
            this.Date_of_Birth.TabIndex = 6;
            this.Date_of_Birth.Value = new System.DateTime(2025, 2, 18, 0, 0, 0, 0);
            // 
            // Employees
            // 
            this.Employees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Employees.Location = new System.Drawing.Point(12, 239);
            this.Employees.Name = "Employees";
            this.Employees.ReadOnly = true;
            this.Employees.Size = new System.Drawing.Size(638, 187);
            this.Employees.TabIndex = 7;
            this.Employees.Text = "";
            this.Employees.WordWrap = false;
            this.Employees.Click += new System.EventHandler(this.Employees_Click);
            // 
            // Last_Name
            // 
            this.Last_Name.Location = new System.Drawing.Point(193, 82);
            this.Last_Name.Name = "Last_Name";
            this.Last_Name.Size = new System.Drawing.Size(159, 22);
            this.Last_Name.TabIndex = 8;
            this.Last_Name.Click += new System.EventHandler(this.Last_Name_Click);
            this.Last_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Employee_KeyPress);
            this.Last_Name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightClick_MouseDown);
            // 
            // Patronymic
            // 
            this.Patronymic.Location = new System.Drawing.Point(193, 54);
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.Size = new System.Drawing.Size(159, 22);
            this.Patronymic.TabIndex = 9;
            this.Patronymic.Click += new System.EventHandler(this.Patronymic_Click);
            this.Patronymic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Employee_KeyPress);
            this.Patronymic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightClick_MouseDown);
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(193, 26);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(159, 22);
            this.Name.TabIndex = 10;
            this.Name.Click += new System.EventHandler(this.Name_Click);
            this.Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Employee_KeyPress);
            this.Name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightClick_MouseDown);
            // 
            // Employee_Data
            // 
            this.Employee_Data.Controls.Add(this.Post_label);
            this.Employee_Data.Controls.Add(this.Post);
            this.Employee_Data.Controls.Add(this.Name);
            this.Employee_Data.Controls.Add(this.Patronymic);
            this.Employee_Data.Controls.Add(this.Last_Name);
            this.Employee_Data.Controls.Add(this.Date_of_Birth);
            this.Employee_Data.Controls.Add(this.Work_Experience);
            this.Employee_Data.Controls.Add(this.Work_Experience_label);
            this.Employee_Data.Controls.Add(this.Date_of_Birth_label);
            this.Employee_Data.Controls.Add(this.Last_Name_label);
            this.Employee_Data.Controls.Add(this.Patronymic_label);
            this.Employee_Data.Controls.Add(this.Name_label);
            this.Employee_Data.Location = new System.Drawing.Point(12, 22);
            this.Employee_Data.Name = "Employee_Data";
            this.Employee_Data.Size = new System.Drawing.Size(369, 202);
            this.Employee_Data.TabIndex = 11;
            this.Employee_Data.TabStop = false;
            this.Employee_Data.Text = "Данные сотрудника";
            // 
            // Post_label
            // 
            this.Post_label.AutoSize = true;
            this.Post_label.Location = new System.Drawing.Point(73, 116);
            this.Post_label.Name = "Post_label";
            this.Post_label.Size = new System.Drawing.Size(81, 17);
            this.Post_label.TabIndex = 12;
            this.Post_label.Text = "Должность";
            // 
            // Post
            // 
            this.Post.FormattingEnabled = true;
            this.Post.Items.AddRange(new object[] { "Директор", "Менеджер", "Секретарь", "Офисный планктон" });
            this.Post.Location = new System.Drawing.Point(193, 112);
            this.Post.Name = "Post";
            this.Post.Size = new System.Drawing.Size(159, 24);
            this.Post.TabIndex = 11;
            this.Post.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Employee_KeyPress);
            // 
            // Average_Age_groupBox
            // 
            this.Average_Age_groupBox.Controls.Add(this.Average_Age_label);
            this.Average_Age_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Average_Age_groupBox.Location = new System.Drawing.Point(399, 22);
            this.Average_Age_groupBox.Name = "Average_Age_groupBox";
            this.Average_Age_groupBox.Size = new System.Drawing.Size(389, 62);
            this.Average_Age_groupBox.TabIndex = 12;
            this.Average_Age_groupBox.TabStop = false;
            this.Average_Age_groupBox.Text = "Средний возраст сотрудников";
            // 
            // Average_Age_label
            // 
            this.Average_Age_label.AutoSize = true;
            this.Average_Age_label.Location = new System.Drawing.Point(16, 28);
            this.Average_Age_label.Name = "Average_Age_label";
            this.Average_Age_label.Size = new System.Drawing.Size(12, 17);
            this.Average_Age_label.TabIndex = 0;
            this.Average_Age_label.Text = " ";
            // 
            // Work_Experience_groupBox
            // 
            this.Work_Experience_groupBox.Controls.Add(this.Max_Work_Experience_label);
            this.Work_Experience_groupBox.Location = new System.Drawing.Point(399, 90);
            this.Work_Experience_groupBox.Name = "Work_Experience_groupBox";
            this.Work_Experience_groupBox.Size = new System.Drawing.Size(389, 99);
            this.Work_Experience_groupBox.TabIndex = 13;
            this.Work_Experience_groupBox.TabStop = false;
            this.Work_Experience_groupBox.Text = "Сотрудник с большим стажем работы";
            // 
            // Max_Work_Experience_label
            // 
            this.Max_Work_Experience_label.AutoSize = true;
            this.Max_Work_Experience_label.Location = new System.Drawing.Point(16, 30);
            this.Max_Work_Experience_label.Name = "Max_Work_Experience_label";
            this.Max_Work_Experience_label.Size = new System.Drawing.Size(12, 17);
            this.Max_Work_Experience_label.TabIndex = 0;
            this.Max_Work_Experience_label.Text = " ";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(399, 190);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(109, 34);
            this.Add.TabIndex = 14;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(656, 237);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(132, 27);
            this.Edit.TabIndex = 15;
            this.Edit.Text = "Редактировать";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(656, 284);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(132, 27);
            this.Delete.TabIndex = 16;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Save_as_File
            // 
            this.Save_as_File.Location = new System.Drawing.Point(656, 378);
            this.Save_as_File.Name = "Save_as_File";
            this.Save_as_File.Size = new System.Drawing.Size(132, 46);
            this.Save_as_File.TabIndex = 17;
            this.Save_as_File.Text = "Сохранить как текстовый файл";
            this.Save_as_File.UseVisualStyleBackColor = true;
            this.Save_as_File.Click += new System.EventHandler(this.Save_as_File_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(656, 335);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(132, 27);
            this.Reset.TabIndex = 18;
            this.Reset.Text = "Сброс";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // AAAA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Save_as_File);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Work_Experience_groupBox);
            this.Controls.Add(this.Average_Age_groupBox);
            this.Controls.Add(this.Employee_Data);
            this.Controls.Add(this.Employees);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "Данные работников";
            ((System.ComponentModel.ISupportInitialize)(this.Work_Experience)).EndInit();
            this.Employee_Data.ResumeLayout(false);
            this.Employee_Data.PerformLayout();
            this.Average_Age_groupBox.ResumeLayout(false);
            this.Average_Age_groupBox.PerformLayout();
            this.Work_Experience_groupBox.ResumeLayout(false);
            this.Work_Experience_groupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Patronymic_label;
        private System.Windows.Forms.Label Last_Name_label;
        private System.Windows.Forms.Label Date_of_Birth_label;
        private System.Windows.Forms.Label Work_Experience_label;
        private System.Windows.Forms.NumericUpDown Work_Experience;
        private System.Windows.Forms.DateTimePicker Date_of_Birth;
        private System.Windows.Forms.RichTextBox Employees;
        private System.Windows.Forms.TextBox Last_Name;
        private System.Windows.Forms.TextBox Patronymic;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.GroupBox Employee_Data;
        private System.Windows.Forms.GroupBox Average_Age_groupBox;
        private System.Windows.Forms.GroupBox Work_Experience_groupBox;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label Average_Age_label;
        private System.Windows.Forms.Label Max_Work_Experience_label;
        private System.Windows.Forms.Button Save_as_File;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label Post_label;
        private System.Windows.Forms.ComboBox Post;
    }
}

