using System;
using System.Windows.Forms;

namespace calc
{
    public class MatrixForm : Form
    {
        /// <summary>
        /// Вывод матрицы в DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView в который записать матрицу</param>
        /// <param name="matrix">Матрица, которую нужно вывести</param>
        protected void PrintToDataGridView(DataGridView dataGridView, Matrix matrix)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(@"dataGridView");

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            int i;
            for (i = 0; i < matrix.ColumnsCount; i++)
            {
                dataGridView.Columns.Add("", "");
                if (i < matrix.RowsCount)
                    dataGridView.Rows.Add();
            }
            for (; i < matrix.RowsCount; i++)
            {
                dataGridView.Rows.Add();
            }

            for (i = 0; i < matrix.ColumnsCount; i++)
            {
                for (var j = 0; j < matrix.RowsCount; j++)
                {
                    dataGridView.Rows[j].Cells[i].Value = Math.Round(matrix[j, i], 2);
                }
            }

        }
    }
}
