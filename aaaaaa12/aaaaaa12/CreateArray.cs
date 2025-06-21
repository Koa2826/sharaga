using System;
using System.Windows.Forms;

namespace aaaaaa12
{
    public class CreateArray
    {
        public static void CreateNewArray(int[] ArrayA, int[] ArrayB, out int[,] ArrayC)//создание нового массива
        {
            ArrayC=new int[ArrayA.Length,ArrayB.Length];
            for (int i = 0; i < ArrayA.Length; i++)
            {
                for (int j = 0; j < ArrayB.Length; j++)
                {
                    if (ArrayA[i] != 0) ArrayC[i,j] = ArrayA[i] *ArrayA[j];
                    else ArrayC[i,j] = 1;
                }
            }
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