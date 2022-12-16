using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMas
{
    public static class ExtensionMatrix
    {
        public static void Fill(this Matrix<int> numbers, int row, int column)
        {
            int[,] matrix = new int[row, column];
            Random random = new();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = random.Next(1, 3);
                }
            }
            numbers.Add(matrix);
        }
        public static int FindColumn(this Matrix<int> matrix)
        {
            int[] maxIdentitys = new int[matrix.ColumnCount];
            Dictionary<int, int> identitys = new Dictionary<int, int>();

            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                for (int i = 0; i < matrix.RowCount; i++)
                {
                    if (!identitys.ContainsKey(matrix[i, j]))
                    {
                        identitys.Add(matrix[i, j], 0);
                    }

                    identitys[matrix[i, j]]++;
                }

                maxIdentitys[j] = identitys.Values.Max();
                identitys.Clear();
            }

            int index = Array.FindIndex(maxIdentitys, el => el == maxIdentitys.Max());

            return index + 1;
        }
    }
}
