namespace aaaaaa12
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
            this.ArrayA = new System.Windows.Forms.DataGridView();
            this.LengthA = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FromFile = new System.Windows.Forms.RadioButton();
            this.Manually = new System.Windows.Forms.RadioButton();
            this.Randomly = new System.Windows.Forms.RadioButton();
            this.Calculate = new System.Windows.Forms.Button();
            this.ArrayB = new System.Windows.Forms.DataGridView();
            this.LengthB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ArrayC = new System.Windows.Forms.DataGridView();
            this.C = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthA)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер массива A";
            // 
            // ArrayA
            // 
            this.ArrayA.AllowUserToAddRows = false;
            this.ArrayA.AllowUserToDeleteRows = false;
            this.ArrayA.AllowUserToResizeColumns = false;
            this.ArrayA.AllowUserToResizeRows = false;
            this.ArrayA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ArrayA.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ArrayA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ArrayA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArrayA.ColumnHeadersVisible = false;
            this.ArrayA.Enabled = false;
            this.ArrayA.Location = new System.Drawing.Point(46, 181);
            this.ArrayA.Margin = new System.Windows.Forms.Padding(4);
            this.ArrayA.Name = "ArrayA";
            this.ArrayA.RowHeadersVisible = false;
            this.ArrayA.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ArrayA.Size = new System.Drawing.Size(968, 27);
            this.ArrayA.TabIndex = 1;
            this.ArrayA.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Array_EditingControlShowing);
            // 
            // LengthA
            // 
            this.LengthA.Location = new System.Drawing.Point(187, 16);
            this.LengthA.Margin = new System.Windows.Forms.Padding(4);
            this.LengthA.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.LengthA.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.LengthA.Name = "LengthA";
            this.LengthA.Size = new System.Drawing.Size(63, 22);
            this.LengthA.TabIndex = 2;
            this.LengthA.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.LengthA.ValueChanged += new System.EventHandler(this.columns_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FromFile);
            this.groupBox1.Controls.Add(this.Manually);
            this.groupBox1.Controls.Add(this.Randomly);
            this.groupBox1.Location = new System.Drawing.Point(293, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(192, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим ввода массива";
            // 
            // FromFile
            // 
            this.FromFile.AutoSize = true;
            this.FromFile.Location = new System.Drawing.Point(15, 91);
            this.FromFile.Margin = new System.Windows.Forms.Padding(4);
            this.FromFile.Name = "FromFile";
            this.FromFile.Size = new System.Drawing.Size(93, 21);
            this.FromFile.TabIndex = 2;
            this.FromFile.TabStop = true;
            this.FromFile.Text = "Из файла";
            this.FromFile.UseVisualStyleBackColor = true;
            this.FromFile.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Manually
            // 
            this.Manually.AutoSize = true;
            this.Manually.Location = new System.Drawing.Point(15, 62);
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
            this.Randomly.Location = new System.Drawing.Point(15, 33);
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
            this.Calculate.Location = new System.Drawing.Point(46, 107);
            this.Calculate.Margin = new System.Windows.Forms.Padding(4);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(204, 42);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "Вычислить";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // ArrayB
            // 
            this.ArrayB.AllowUserToAddRows = false;
            this.ArrayB.AllowUserToDeleteRows = false;
            this.ArrayB.AllowUserToResizeColumns = false;
            this.ArrayB.AllowUserToResizeRows = false;
            this.ArrayB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ArrayB.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ArrayB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ArrayB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArrayB.ColumnHeadersVisible = false;
            this.ArrayB.Enabled = false;
            this.ArrayB.Location = new System.Drawing.Point(46, 252);
            this.ArrayB.Margin = new System.Windows.Forms.Padding(4);
            this.ArrayB.Name = "ArrayB";
            this.ArrayB.RowHeadersVisible = false;
            this.ArrayB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ArrayB.Size = new System.Drawing.Size(968, 27);
            this.ArrayB.TabIndex = 7;
            this.ArrayB.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Array_EditingControlShowing);
            // 
            // LengthB
            // 
            this.LengthB.Location = new System.Drawing.Point(187, 55);
            this.LengthB.Margin = new System.Windows.Forms.Padding(4);
            this.LengthB.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.LengthB.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.LengthB.Name = "LengthB";
            this.LengthB.Size = new System.Drawing.Size(63, 22);
            this.LengthB.TabIndex = 9;
            this.LengthB.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.LengthB.ValueChanged += new System.EventHandler(this.LengthB_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Размер массива B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Массив B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Массив A";
            // 
            // ArrayC
            // 
            this.ArrayC.AllowUserToAddRows = false;
            this.ArrayC.AllowUserToDeleteRows = false;
            this.ArrayC.AllowUserToResizeColumns = false;
            this.ArrayC.AllowUserToResizeRows = false;
            this.ArrayC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ArrayC.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ArrayC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ArrayC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArrayC.ColumnHeadersVisible = false;
            this.ArrayC.Enabled = false;
            this.ArrayC.Location = new System.Drawing.Point(46, 320);
            this.ArrayC.Margin = new System.Windows.Forms.Padding(4);
            this.ArrayC.Name = "ArrayC";
            this.ArrayC.RowHeadersVisible = false;
            this.ArrayC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ArrayC.Size = new System.Drawing.Size(968, 205);
            this.ArrayC.TabIndex = 12;
            this.ArrayC.Visible = false;
            // 
            // C
            // 
            this.C.AutoSize = true;
            this.C.Location = new System.Drawing.Point(46, 299);
            this.C.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(69, 17);
            this.C.TabIndex = 13;
            this.C.Text = "Массив C";
            this.C.Visible = false;
            // 
            // aaaaaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.C);
            this.Controls.Add(this.ArrayC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LengthB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArrayB);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LengthA);
            this.Controls.Add(this.ArrayA);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "aaaaaa";
            this.Text = "...";
            ((System.ComponentModel.ISupportInitialize)(this.ArrayA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthA)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RadioButton FromFile;

        private System.Windows.Forms.NumericUpDown LengthB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ArrayC;
        private System.Windows.Forms.Label C;

        private System.Windows.Forms.DataGridView ArrayB;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ArrayA;
        private System.Windows.Forms.NumericUpDown LengthA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Randomly;
        private System.Windows.Forms.RadioButton Manually;
        private System.Windows.Forms.Button Calculate;
    }
}

