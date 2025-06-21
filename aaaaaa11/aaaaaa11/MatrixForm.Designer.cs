namespace aaaaaa11
{
    partial class aaaaaa
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
            this.label1 = new System.Windows.Forms.Label();
            this.Array = new System.Windows.Forms.DataGridView();
            this.columns = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Manually = new System.Windows.Forms.RadioButton();
            this.Randomly = new System.Windows.Forms.RadioButton();
            this.Calculate = new System.Windows.Forms.Button();
            this.NegativeResult = new System.Windows.Forms.Label();
            this.PositiveResult = new System.Windows.Forms.Label();
            this.ModifyArray = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Array)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columns)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifyArray)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер массива";
            // 
            // Array
            // 
            this.Array.AllowUserToAddRows = false;
            this.Array.AllowUserToDeleteRows = false;
            this.Array.AllowUserToResizeColumns = false;
            this.Array.AllowUserToResizeRows = false;
            this.Array.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Array.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Array.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Array.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Array.ColumnHeadersVisible = false;
            this.Array.Enabled = false;
            this.Array.Location = new System.Drawing.Point(54, 379);
            this.Array.Margin = new System.Windows.Forms.Padding(4);
            this.Array.Name = "Array";
            this.Array.RowHeadersVisible = false;
            this.Array.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Array.Size = new System.Drawing.Size(981, 31);
            this.Array.TabIndex = 1;
            this.Array.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Array_EditingControlShowing);
            // 
            // columns
            // 
            this.columns.Location = new System.Drawing.Point(182, 47);
            this.columns.Margin = new System.Windows.Forms.Padding(4);
            this.columns.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.columns.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.columns.Name = "columns";
            this.columns.Size = new System.Drawing.Size(63, 22);
            this.columns.TabIndex = 2;
            this.columns.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.columns.ValueChanged += new System.EventHandler(this.columns_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Manually);
            this.groupBox1.Controls.Add(this.Randomly);
            this.groupBox1.Location = new System.Drawing.Point(54, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(192, 158);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим ввода массива";
            // 
            // Manually
            // 
            this.Manually.AutoSize = true;
            this.Manually.Location = new System.Drawing.Point(15, 84);
            this.Manually.Margin = new System.Windows.Forms.Padding(4);
            this.Manually.Name = "Manually";
            this.Manually.Size = new System.Drawing.Size(86, 21);
            this.Manually.TabIndex = 1;
            this.Manually.TabStop = true;
            this.Manually.Text = "Вручную";
            this.Manually.UseVisualStyleBackColor = true;
            this.Manually.CheckedChanged += new System.EventHandler(this.Manually_CheckedChanged);
            // 
            // Randomly
            // 
            this.Randomly.AutoSize = true;
            this.Randomly.Location = new System.Drawing.Point(15, 46);
            this.Randomly.Margin = new System.Windows.Forms.Padding(4);
            this.Randomly.Name = "Randomly";
            this.Randomly.Size = new System.Drawing.Size(93, 21);
            this.Randomly.TabIndex = 0;
            this.Randomly.TabStop = true;
            this.Randomly.Text = "Случайно";
            this.Randomly.UseVisualStyleBackColor = true;
            this.Randomly.CheckedChanged += new System.EventHandler(this.Randomly_CheckedChanged);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(54, 276);
            this.Calculate.Margin = new System.Windows.Forms.Padding(4);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(191, 42);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "Вычислить";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // NegativeResult
            // 
            this.NegativeResult.AutoSize = true;
            this.NegativeResult.Location = new System.Drawing.Point(418, 143);
            this.NegativeResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NegativeResult.Name = "NegativeResult";
            this.NegativeResult.Size = new System.Drawing.Size(318, 17);
            this.NegativeResult.TabIndex = 5;
            this.NegativeResult.Text = "Количество положительных членов массива = ";
            // 
            // PositiveResult
            // 
            this.PositiveResult.AutoSize = true;
            this.PositiveResult.Location = new System.Drawing.Point(418, 186);
            this.PositiveResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PositiveResult.Name = "PositiveResult";
            this.PositiveResult.Size = new System.Drawing.Size(316, 17);
            this.PositiveResult.TabIndex = 6;
            this.PositiveResult.Text = "Количество отрицательных членов массива = ";
            // 
            // ModifyArray
            // 
            this.ModifyArray.AllowUserToAddRows = false;
            this.ModifyArray.AllowUserToDeleteRows = false;
            this.ModifyArray.AllowUserToResizeColumns = false;
            this.ModifyArray.AllowUserToResizeRows = false;
            this.ModifyArray.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ModifyArray.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ModifyArray.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModifyArray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ModifyArray.ColumnHeadersVisible = false;
            this.ModifyArray.Enabled = false;
            this.ModifyArray.Location = new System.Drawing.Point(54, 465);
            this.ModifyArray.Margin = new System.Windows.Forms.Padding(4);
            this.ModifyArray.Name = "ModifyArray";
            this.ModifyArray.RowHeadersVisible = false;
            this.ModifyArray.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ModifyArray.Size = new System.Drawing.Size(981, 31);
            this.ModifyArray.TabIndex = 7;
            this.ModifyArray.Visible = false;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(54, 438);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(157, 23);
            this.label.TabIndex = 8;
            this.label.Text = "Обновленный массив";
            this.label.Visible = false;
            // 
            // aaaaaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ModifyArray);
            this.Controls.Add(this.PositiveResult);
            this.Controls.Add(this.NegativeResult);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.columns);
            this.Controls.Add(this.Array);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "aaaaaa";
            this.Text = "...";
            ((System.ComponentModel.ISupportInitialize)(this.Array)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columns)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifyArray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label;

        private System.Windows.Forms.DataGridView ModifyArray;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Array;
        private System.Windows.Forms.NumericUpDown columns;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Randomly;
        private System.Windows.Forms.RadioButton Manually;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label NegativeResult;
        private System.Windows.Forms.Label PositiveResult;
    }
}

