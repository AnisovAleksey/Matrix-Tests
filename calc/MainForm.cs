using System;
using System.Windows.Forms;

namespace calc
{
    public partial class MainForm : MatrixForm
    {
        /// <summary>
        /// Тип double
        /// </summary>
        private static readonly Type DoubleType = typeof(double);

        /// <summary>
        /// Размер столбца в DataGridView
        /// </summary>
        private const int DefaultColumnWidth = 30;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Изменение значения в NumericUpDown правой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightNumericValueChanged(object sender, EventArgs e)
        {
            InvalidateGridView(dataGridView2, numericUpDown1, numericUpDown2);
        }

        /// <summary>
        /// Изменение значения в NumericUpDown левой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftNumeriсValueChanged(object sender, EventArgs e)
        {
            InvalidateGridView(dataGridView1, numericUpDown4, numericUpDown3);
            if (radioButtonDiv.Checked) return;
            if (radioButtonPlus.Checked || radioButtonMinus.Checked)
            {
                numericUpDown1.Value = numericUpDown4.Value;
                numericUpDown2.Value = numericUpDown3.Value;
            }
            else if (radioButtonMod.Checked)
            {
                numericUpDown2.Value = numericUpDown4.Value;
            }
            InvalidateGridView(dataGridView2, numericUpDown1, numericUpDown2);
        }

        /// <summary>
        /// Перерасчет размеров матрицы в зависимости от NumericUpDown и отображение
        /// </summary>
        /// <param name="dataGridView">DataGridView для вывода матрицы</param>
        /// <param name="numericColumn">NumericUpDown отвечающий за столбцы</param>
        /// <param name="numericRows">NumericUpDown отвечающий за строки</param>
        private static void InvalidateGridView(DataGridView dataGridView, NumericUpDown numericColumn, NumericUpDown numericRows)
        {
            while (true)
            {
                if (dataGridView.DataSource != null)
                    MessageBox.Show(dataGridView.DataSource.GetType().ToString());
                var columns = (int) numericColumn.Value;
                var rows = (int) numericRows.Value;
                if (rows == 0 || columns == 0)
                {
                    if (dataGridView.ColumnCount == 0 || dataGridView.RowCount == 0) return;

                    dataGridView.Columns.Clear();
                    dataGridView.Rows.Clear();
                    return;
                }
                if (dataGridView.ColumnCount > columns)
                    dataGridView.Columns.RemoveAt(columns - 1);
                else if (dataGridView.ColumnCount < columns)
                {
                    for (var i = dataGridView.ColumnCount; i < columns; i++)
                    {
                        dataGridView.Columns.Add(String.Empty, String.Empty);
                        dataGridView.Columns[i].ValueType = DoubleType;
                        dataGridView.Columns[i].Width = DefaultColumnWidth;
                    }
                }
                else if (dataGridView.RowCount > rows)
                    dataGridView.Rows.RemoveAt(rows - 1);
                else if (dataGridView.RowCount < rows)
                {
                    for (var i = dataGridView.RowCount; i < rows; i++)
                    {
                        dataGridView.Rows.Add();
                    }
                }
                if (rows != dataGridView.RowCount || columns != dataGridView.ColumnCount)
                    continue;
                break;
            }
        }

        /// <summary>
        /// Вывод ошибки при некорректном значении в ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        /// <summary>
        /// Очистка ячейки при нажатии кнопки Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            if (sender.GetType() != typeof (DataGridView)) return;

            var dataGridView = (DataGridView)sender;
            if (dataGridView.SelectedCells.Count > 0)
            {
                dataGridView.SelectedCells[0].Value = null;
            }
        }

        /// <summary>
        /// Установка 0 в ячейку при ее отрисовке
        /// TODO: нужен вариант получше, метод вызывается всеми ячейками и может создавать лишнюю нагрузку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (sender.GetType() != typeof (DataGridView)) return;

            var dataGridView = (DataGridView)sender;
            var paintingCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (paintingCell.Value != null) return;

            paintingCell.Value = 0D;
            dataGridView.InvalidateCell(paintingCell);
        }

        /// <summary>
        /// Обработка нажатия на кнопку "Выполнить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunButtonClick(object sender, EventArgs e)
        {
            var operation = GetSelectedOperation();
            if (operation == null)
            {
                MessageBox.Show(@"Выберите операцию действия над матрицами");
                return;
            }
            if (dataGridView1.ColumnCount == 0)
            {
                MessageBox.Show(@"Введите матрицу");
                return;
            }

            Matrix matrixLeft;
            Matrix matrixRight;
            try
            {
                matrixLeft = new Matrix(dataGridView1.RowCount, dataGridView1.ColumnCount);
                FillMatrixFromDataGridView(dataGridView1, matrixLeft);
                matrixRight = new Matrix(dataGridView2.RowCount, dataGridView2.ColumnCount);
                FillMatrixFromDataGridView(dataGridView2, matrixRight);
            }
            catch (Exception error)
            {
                MessageBox.Show(@"Матрицы введены не верно \n"+error.Message+@"\n"+error.InnerException);
                return;
            }
            ProgramController.CalculateMatrix(matrixLeft, matrixRight, (Operation)operation);

        }

        /// <summary>
        /// Определение выбранной операции в RadioButton'ах
        /// </summary>
        /// <returns>Операция для матриц</returns>
        private Operation? GetSelectedOperation()
        {
            if (radioButtonPlus.Checked)
                return Operation.Plus;
            else if (radioButtonMinus.Checked)
                return Operation.Minus;
            else if (radioButtonMod.Checked)
                return Operation.Mod;
            else if (radioButtonDiv.Checked)
                return Operation.Div;
            return null;
        }

        /// <summary>
        /// Обработка ChekedChanged для RadioButton'ов с операцией плюс, минус
        /// Блокировка ввода размерностей для 2ой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonPlusMinusCheckedChanged(object sender, EventArgs e)
        {
            if (sender == null || sender.GetType() != typeof (RadioButton)) return;

            var radioButton = (RadioButton)sender;
            if (!radioButton.Checked) return;

            numericUpDown1.Value = numericUpDown4.Value;
            numericUpDown2.Value = numericUpDown3.Value;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        /// <summary>
        /// Обработка ChekedChanged для RadioButton'ов с операцией умножения
        /// Блокировка ввода кол-ва строк 2ой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonModCheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonMod.Checked) return;

            numericUpDown2.Value = numericUpDown4.Value;
            numericUpDown2.Enabled = false;
            numericUpDown1.Enabled = true;
            numericUpDown1.Value = 0;
        }

        /// <summary>
        /// Значение по умолчанию в RadioButton'ах при при показе формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;

            radioButtonPlus.Checked = true;
            RadioButtonPlusMinusCheckedChanged(radioButtonPlus, null);
        }

        /// <summary>
        /// Обработка ChekedChanged для RadioButton'ов с операцией обратной матрицы
        /// Блокировка ввода 2ой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonDivCheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonDiv.Checked) return;

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        /// <summary>
        /// Заполнение матрицы из DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView как источник данных</param>
        /// <param name="matrix">Матрица для заполнения</param>
        private void FillMatrixFromDataGridView(DataGridView dataGridView, Matrix matrix)
        {
            int rows = Math.Min(dataGridView.RowCount, matrix.RowsCount);
            int columns = Math.Min(dataGridView.ColumnCount, matrix.ColumnsCount);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = (double) dataGridView.Rows[i].Cells[j].Value;
                }
            }
        }
    }
}
