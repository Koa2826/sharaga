using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aaaaaa11
{
    internal class Count
    {
        public static int NegativeCount(DataGridView array)
        {
            int k = 0;
            for (int j = 0; j < array.ColumnCount; j++)
            { 
                if (Convert.ToInt32(array.Rows[0].Cells[j].Value) < 0) k++;
            }
            return k;
        }
        public static int PositiveCount(DataGridView array)
        {
            int k = 0;
            for (int j = 0; j < array.ColumnCount; j++)
            {
                if (Convert.ToInt32(array.Rows[0].Cells[j].Value)> 0) k++;
            }
            return k;
        }
        public static void MoreNegative(DataGridView array, DataGridView array2)
        {
            for (int j = 0; j < array.ColumnCount; j++)
            {
                array2.Rows[0].Cells[j].Value = -Convert.ToInt32(array.Rows[0].Cells[j].Value);
            }
        }
    }
}