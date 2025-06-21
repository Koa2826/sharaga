using System;
using System.Windows.Forms;

namespace aaaaaa11
{ 
    internal class Count
    { 
        public static int NegativeCount(int[] array)
        {
            int k = 0;
            for (int j = 0; j < array.Length; j++)
            { 
                if (array[j] < 0) k++;
            }
            return k;
        }

        public static int PositiveCount(int[] array)
        {
            int k = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] > 0) k++;
            }
            return k;
        }
        public static int[] MoreNegative(int[] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = -array[j];
            }
            return array;
        }
        public static int[] ToArray(DataGridView Array) //создание нового массива
        {
            int[] array= new int[Array.ColumnCount];
            for (int j = 0; j < Array.ColumnCount; j++)
            {
                array[j] = Convert.ToInt32(Array.Rows[0].Cells[j].Value);
            }
            return array;
        }
    }
}