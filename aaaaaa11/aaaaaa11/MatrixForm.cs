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
            if (Randomly.Checked == true)
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
                    Array.Rows[0].Cells[j].Value = random.Next(-100, 101);
            }
        }
        private void Calculate_Click(object sender, EventArgs e)
        {
            if (ForArray(sender, e))
            {
                ModifyArray.Visible = false;
                label.Visible = false;
                PositiveResult.Text = @"Количество положительных членов массива = ";
                NegativeResult.Text = @"Количество отрицательных членов массива = ";
                PositiveResult.Text += Count.PositiveCount(Count.ToArray(Array)).ToString();
                NegativeResult.Text += Count.NegativeCount(Count.ToArray(Array)).ToString();
                if (Count.NegativeCount(Count.ToArray(Array)) > Count.PositiveCount(Count.ToArray(Array)))
                {
                    ModifyArray.Visible = true;
                    ModifyArray.RowCount = 1;
                    ModifyArray.ColumnCount = Array.ColumnCount;
                    label.Visible = true;
                    int[] array = Count.MoreNegative(Count.ToArray(Array));
                    for (int j = 0; j < ModifyArray.ColumnCount; j++)
                    {
                        ModifyArray.Rows[0].Cells[j].Value = array[j];
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверный ввод данных");
            } 
        }

    private bool ForArray(object sender, EventArgs e)
        {
            bool result = false;
            for (int j = 0; j < Array.ColumnCount; j++)
            {
                if (Array.Rows[0].Cells[j].Value is null)
                {
                    result = false;
                    break;
                }
                else
                { 
                    if (Regex.IsMatch(Array.Rows[0].Cells[j].Value.ToString(), @"^-\d*$")||
                        Regex.IsMatch(Array.Rows[0].Cells[j].Value.ToString(), @"^\d*$"))
                        result = true;
                    else
                    { 
                        result = false; 
                        break;
                    }
                }
            }
            return result;
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
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^-|\d*$"))
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
