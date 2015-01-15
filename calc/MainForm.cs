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
            InvalidateGridView(DataGridViewRight, NumericRightCols, NumericRightRows);
        }

        /// <summary>
        /// Изменение значения в NumericUpDown левой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftNumeriсValueChanged(object sender, EventArgs e)
        {
            InvalidateGridView(DataGridViewLeft, NumericLeftCols, NumericLeftRows);
            if (RadioButtonDiv.Checked) return;
            if (RadioButtonPlus.Checked || RadioButtonMinus.Checked)
            {
                NumericRightCols.Value = NumericLeftCols.Value;
                NumericRightRows.Value = NumericLeftRows.Value;
            }
            else if (RadioButtonMod.Checked)
            {
                NumericRightRows.Value = NumericLeftCols.Value;
            }
            InvalidateGridView(DataGridViewRight, NumericRightCols, NumericRightRows);
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
            if (DataGridViewLeft.ColumnCount == 0)
            {
                MessageBox.Show(@"Введите матрицу");
                return;
            }

            Matrix matrixLeft;
            Matrix matrixRight;
            try
            {
                matrixLeft = new Matrix(DataGridViewLeft.RowCount, DataGridViewLeft.ColumnCount);
                FillMatrixFromDataGridView(DataGridViewLeft, matrixLeft);
                matrixRight = new Matrix(DataGridViewRight.RowCount, DataGridViewRight.ColumnCount);
                FillMatrixFromDataGridView(DataGridViewRight, matrixRight);
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
            if (RadioButtonPlus.Checked)
                return Operation.Plus;
            else if (RadioButtonMinus.Checked)
                return Operation.Minus;
            else if (RadioButtonMod.Checked)
                return Operation.Mod;
            else if (RadioButtonDiv.Checked)
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

            NumericRightCols.Value = NumericLeftCols.Value;
            NumericRightRows.Value = NumericLeftRows.Value;
            NumericRightCols.Enabled = false;
            NumericRightRows.Enabled = false;
        }

        /// <summary>
        /// Обработка ChekedChanged для RadioButton'ов с операцией умножения
        /// Блокировка ввода кол-ва строк 2ой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonModCheckedChanged(object sender, EventArgs e)
        {
            if (!RadioButtonMod.Checked) return;

            NumericRightRows.Value = NumericLeftCols.Value;
            NumericRightRows.Enabled = false;
            NumericRightCols.Enabled = true;
        }

        /// <summary>
        /// Значение по умолчанию в RadioButton'ах при при показе формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;

            RadioButtonPlus.Checked = true;
            RadioButtonPlusMinusCheckedChanged(RadioButtonPlus, null);
        }

        /// <summary>
        /// Обработка ChekedChanged для RadioButton'ов с операцией обратной матрицы
        /// Блокировка ввода 2ой матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonDivCheckedChanged(object sender, EventArgs e)
        {
            if (!RadioButtonDiv.Checked) return;

            NumericRightCols.Enabled = false;
            NumericRightRows.Enabled = false;
            NumericRightCols.Value = 0;
            NumericRightRows.Value = 0;
            InvalidateGridView(DataGridViewRight, NumericRightCols, NumericRightRows);
        }

        /// <summary>
        /// Заполнение матрицы из DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView как источник данных</param>
        /// <param name="matrix">Матрица для заполнения</param>
        private static void FillMatrixFromDataGridView(DataGridView dataGridView, Matrix matrix)
        {
            var rows = Math.Min(dataGridView.RowCount, matrix.RowsCount);
            var columns = Math.Min(dataGridView.ColumnCount, matrix.ColumnsCount);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = (double) dataGridView.Rows[i].Cells[j].Value;
                }
            }
        }
    }
}
