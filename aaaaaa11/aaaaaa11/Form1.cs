using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace aaaaaa11
{
    public partial class aaaaaa : Form
    { 
        int _cellValue = -1;
        public aaaaaa()
        {
            InitializeComponent();
            Array.RowCount = 1;
            Array.ColumnCount = Convert.ToInt32(columns.Value);
        }
        private void columns_ValueChanged(object sender, EventArgs e)
        {
            Array.ColumnCount = Convert.ToInt32(columns.Value);
            if(Randomly.Checked == true) 
                Randomly_CheckedChanged(sender, e);
        }
        private void Randomly_CheckedChanged(object sender, EventArgs e)
        {
            Array.Enabled = false;
            Array.RowCount = 1;
            Array.ColumnCount = Convert.ToInt32(columns.Value);
            Random random = new Random();
            for (int j = 0; j < Array.ColumnCount; j++)
            {
                if (Array.Rows[0].Cells[j].Value is null) 
                    Array.Rows[0].Cells[j].Value = random.Next(-100, 100);
            }
        }
        private void Calculate_Click(object sender, EventArgs e) 
        {
            ModifyArray.Visible=false;
            label.Visible=false;
            PositiveResult.Text = @"Количество положительных членов массива = ";
            NegativeResult.Text = @"Количество отрицательных членов массива = ";
            PositiveResult.Text += Count.PositiveCount(Array).ToString();
            NegativeResult.Text +=  Count.NegativeCount(Array).ToString();
            if (Count.NegativeCount(Array)>Count.PositiveCount(Array))
            {
                ModifyArray.Visible = true;
                ModifyArray.RowCount = 1;
                ModifyArray.ColumnCount = Array.ColumnCount;
                label.Visible = true;
                Count.MoreNegative(Array,ModifyArray);
            }
        }
        private void Manually_CheckedChanged(object sender, EventArgs e)
        {
            ModifyArray.Visible=false;
            label.Visible=false;
            Array.Rows.Clear();
            Array.RowCount = 1;
            Array.ColumnCount = Convert.ToInt32(columns.Value);
            Array.Enabled = true;
        }
        private void Array_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a;
            if (Regex.IsMatch(e.KeyChar.ToString(), @"^-\d*$"))
            {
                Console.WriteLine(Array.CurrentCell.ColumnIndex.ToString());
                if(!string.IsNullOrEmpty(Array.Rows[0].Cells[Array.CurrentCell.ColumnIndex].Value.ToString()))
                    a = Array.Rows[0].Cells[Array.CurrentCell.ColumnIndex].Value.ToString().ToCharArray()+e.KeyChar.ToString();
                else
                    a = e.KeyChar.ToString();
                if (e.KeyChar == '-'&& a.ToCharArray().Length<1)
                {
                    e.Handled = true; 
                    MessageBox.Show(@"Ошибка данных");
                }
            }
            else
            {
                e.Handled = true; 
                MessageBox.Show(@"Ошибка данных");
            }
        }
        private void Array_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Array_KeyPress); 
            
        }
    }
}
