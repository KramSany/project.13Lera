using System.Data;
using System.IO;
using Microsoft.Win32;

namespace LibMas
{
    public class Matrix<T>
    {
        private T[,] _matrix;
        private int _row, _column;
        public Matrix(int rowCount, int columnCount)
        {
            _matrix = new T[rowCount, columnCount];  
        }
        public int RowCount => _matrix.GetLength(0);
        public int ColumnCount => _matrix.GetLength(1);
        public T this[int rowIndex, int columnIndex]
        {
            get => _matrix[rowIndex, columnIndex];
            set => _matrix[rowIndex, columnIndex] = value;
        }

        public void Save()
        {
            StreamWriter outFile = new("rez.txt");
            outFile.WriteLine(_matrix.GetLength(0));
            outFile.WriteLine(_matrix.GetLength(1));
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    outFile.WriteLine(_matrix[i, j]);
                }
            }
            outFile.Close();
        }

        public Matrix<int> Open()
        {
            StreamReader inFile = new("rez.txt");
            int rowCount = int.Parse(inFile.ReadLine());
            int columnCount = int.Parse(inFile.ReadLine());

            Matrix<int> tempMatrix = new(rowCount, columnCount);
            for (int i = 0; i < tempMatrix.RowCount; i++)
            {
                for (int j = 0; j < tempMatrix.ColumnCount; j++)
                {
                    tempMatrix[i,j] = int.Parse(inFile.ReadLine());
                }
            }
            inFile.Close();

            return tempMatrix;
        }
        public void Add(T[,] items)
        {
            _row = items.GetLength(0);
            _column = items.GetLength(1);
            _matrix = new T[_row, _column];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = items[i, j];
                }
            }
        }
        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _matrix.GetLength(1); i++)
            {
                res.Columns.Add("№ " + (i + 1), typeof(T));
            }

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    row[j] = _matrix[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }

    }
}