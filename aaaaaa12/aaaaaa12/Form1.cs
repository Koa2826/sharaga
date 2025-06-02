using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace aaaaaa12
{
    public partial class aaaaaa : Form
    {
        public aaaaaa()
        {
            InitializeComponent();
            ArrayA.RowCount = 1;
            ArrayA.ColumnCount = Convert.ToInt32(LengthA.Value);
            ArrayB.RowCount = 1;
            ArrayB.ColumnCount = Convert.ToInt32(LengthB.Value);
        }

        private void columns_ValueChanged(object sender, EventArgs e)
        {
            C.Visible = false;
            ArrayC.Visible = false;
            ArrayC.Rows.Clear();
            ArrayB.ColumnCount = Convert.ToInt32(LengthB.Value);
            if (Randomly.Checked == true)
                Randomly_CheckedChanged(sender, e);
        }

        private void Randomly_CheckedChanged(object sender, EventArgs e)
        {
            C.Visible = false;
            ArrayC.Visible = false;
            ArrayA.RowCount = 1;
            ArrayA.ColumnCount = Convert.ToInt32(LengthA.Value);
            ArrayB.RowCount = 1;
            ArrayB.ColumnCount = Convert.ToInt32(LengthB.Value);
            Random random = new Random();
            for (int j = 0; j < ArrayA.ColumnCount; j++)
            {
                if (ArrayA.Rows[0].Cells[j].Value is null)
                    ArrayA.Rows[0].Cells[j].Value = random.Next(-20, 20);
            }

            for (int j = 0; j < ArrayB.ColumnCount; j++)
            {
                if (ArrayB.Rows[0].Cells[j].Value is null)
                    ArrayB.Rows[0].Cells[j].Value = random.Next(-20, 20);
            }

            ArrayA.Enabled = false;
            ArrayB.Enabled = false;
        }
        private void Calculate_Click(object sender, EventArgs e)
        {
            C.Visible = true;
            ArrayC.Visible = true;
            ArrayC.RowCount = Convert.ToInt32(LengthA.Value);
            ArrayC.ColumnCount = Convert.ToInt32(LengthB.Value);
            int[,] arrayC = new int[ArrayC.RowCount,ArrayC.ColumnCount]; 
            ArrayC.Height = ArrayA.Height*Convert.ToInt32(LengthA.Value);
            int[] arrayA = new int[ArrayA.RowCount];
            int[] arrayB = new int[ArrayC.ColumnCount];
            CreateArray.CreateNewArray(arrayA,arrayB,out arrayC);
            ArrayC.DataSource = arrayC;
            // for (int i = 0; i < ArrayC.RowCount; i++)
            // {
            //     for (int j = 0; j < ArrayC.ColumnCount; j++)
            //     {
            //         if (Convert.ToInt32(ArrayA.Rows[0].Cells[i].Value) != 0)
            //             ArrayC.Rows[i].Cells[j].Value = Convert.ToInt32(ArrayA.Rows[0].Cells[i].Value) *
            //                                             Convert.ToInt32(ArrayB.Rows[0].Cells[j].Value);
            //         else ArrayC.Rows[i].Cells[j].Value = 1;
            //     }
            // }
        }

        private void Manually_CheckedChanged(object sender, EventArgs e)
        {
            C.Visible = false;
            ArrayC.Visible = false;
            ArrayA.Rows.Clear();
            ArrayB.Rows.Clear();
            ArrayA.RowCount = 1;
            ArrayA.ColumnCount = Convert.ToInt32(LengthA.Value);
            ArrayB.Enabled = true;
            ArrayB.RowCount = 1;
            ArrayB.ColumnCount = Convert.ToInt32(LengthB.Value);
            ArrayA.Enabled = true;
        }

        private void Array_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.Match(e.KeyChar.ToString(), @"^-?\d*").Success && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Пожалуйста вводите только цифры", " Введен неверный символ");
            }
        }

        private void Array_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Array_KeyPress);
        }
        private void LengthB_ValueChanged(object sender, EventArgs e)
        {
            C.Visible = false;
            ArrayC.Visible = false;
            ArrayC.Rows.Clear();
            ArrayB.ColumnCount = Convert.ToInt32(LengthB.Value);
            if (Randomly.Checked == true)
                Randomly_CheckedChanged(sender, e);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            C.Visible = false;
            ArrayC.Visible = false;
            ArrayC.Rows.Clear();
            ArrayA.Rows.Clear();
            ArrayB.Rows.Clear();
            OpenFileDialog openFile1 = new OpenFileDialog();
            if (FromFile.Checked)
            {
                if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] fileLines1 = File.ReadAllLines(openFile1.FileName);
                    ArrayA.ColumnCount = Convert.ToInt32(fileLines1.Length);
                    ArrayA.RowCount = 1;
                    LengthA.Value = Convert.ToInt32(fileLines1.Length);
                    for (int i = 0; i < fileLines1.Length; i++)
                    {
                        ArrayA.Rows[0].Cells[i].Value = Convert.ToInt32(fileLines1[i]);
                    }
                }
                OpenFileDialog openFile2 = new OpenFileDialog();
                if (openFile2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] fileLines2 = File.ReadAllLines(openFile2.FileName);
                    ArrayB.ColumnCount = Convert.ToInt32(fileLines2.Length);
                    ArrayB.RowCount = 1;
                    LengthB.Value = Convert.ToInt32(fileLines2.Length);
                    for (int i = 0; i < fileLines2.Length; i++)
                    {
                        ArrayB.Rows[0].Cells[i].Value = Convert.ToInt32(fileLines2[i]);
                    }
                }
            }
        }
    }
}
