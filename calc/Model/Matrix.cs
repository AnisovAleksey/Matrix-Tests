using System;
using System.Collections.Generic;

namespace calc.Model
{
    public class Matrix
    {
        /// <summary>
        /// Кол-во строк текущей матрицы
        /// </summary>
        public readonly int RowsCount;
        /// <summary>
        /// Кол-во столбцов текущей матрицы
        /// </summary>
        public readonly int ColumnsCount;
        /// <summary>
        /// Кол-во ячеек текущей матрицы
        /// </summary>
        private readonly int _matrixCells;
        /// <summary>
        /// Массив со значениями матрицы размерностью RowsCount*ColumnsCount
        /// </summary>
        private readonly double[] _data;


        /// <summary>
        /// Конструктор квадратной матрицы матрицы
        /// </summary>
        /// <param name="rowsColumns">Размер квадратной матрицы</param>
        /// <returns>Квадратная матрица по заданному размеру</returns>
        public Matrix(int rowsColumns)
        {
            if (rowsColumns <= 0)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentOutOfRangeException(@"Matrix size");
            }

            ColumnsCount = RowsCount = rowsColumns;
            _matrixCells = RowsCount * ColumnsCount;
            _data = new double[_matrixCells];
        }

        /// <summary>
        /// Конструктор матрицы
        /// </summary>
        /// <param name="rows">Кол-во строк</param>
        /// <param name="columns">Кол-во столбцов</param>
        /// <returns>Матрица созданная по указанным размерам</returns>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentOutOfRangeException(@"Matrix size");
            }

            ColumnsCount = columns;
            RowsCount = rows;
            _matrixCells = RowsCount * ColumnsCount;
            _data = new double[_matrixCells];
        }

        /// <summary>
        /// Заполнить матрицу как единичную
        /// </summary>
        public void FillLikeIdentity()
        {
            for (var i = 0; i < ColumnsCount; i++)
            {
                for (var j = 0; j < RowsCount; j++)
                {
                    if (i == j)
                        this[j, i] = 1;
                    else
                        this[j, i] = 0;
                }
            }
        }



        /// <summary>
        /// Доступ к элементам матрицы
        /// </summary>
        /// <param name="row">Нужная строка</param>
        /// <param name="column">Нужный столбец</param>
        /// <returns>Элемент матрицы по строке, столбцу</returns>
        public double this[int row, int column]
        {
            get
            {
                ValidateRange(row, column);
                return _data[row * ColumnsCount + column];
            }

            set
            {
                ValidateRange(row, column);
                _data[row * ColumnsCount + column] = value;
            }
        }

        /// <summary>
        /// Доступ к элементам матрицы
        /// </summary>
        /// <param name="cell">Нужная ячейка</param>
        /// <returns>Элемент матрицы по ячейке</returns>
        private double this[int cell]
        {
            get
            {
                ValidateRange(cell);
                return _data[cell];
            }

            set
            {
                ValidateRange(cell);
                _data[cell] = value;
            }
        }

        /// <summary>
        /// Проверка на наличие запрашиваемого элемента
        /// </summary>
        /// <param name="row">Нужная строка</param>
        /// <param name="column">Нужный столбец</param>
        private void ValidateRange(int row, int column)
        {
            if (row < 0 || row >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(@"row");
            }

            if (column < 0 || column >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(@"column");
            }
        }

        /// <summary>
        /// Проверка на наличие запрашиваемого элемента
        /// </summary>
        /// <param name="cell">Нужная ячейка</param>
        private void ValidateRange(int cell)
        {
            if (_matrixCells <= cell)
            {
                throw new ArgumentOutOfRangeException(@"cell");
            }
        }

        /// <summary>
        /// Расчет обратной матрицы
        /// </summary>
        /// <returns>Обратная матрица</returns>
        public Matrix Transparate()
        {
            var identityMatrix = new Matrix(RowsCount);
            identityMatrix.FillLikeIdentity();
            var forCalc = AddRightMatrix(identityMatrix);
            for (var i = 0; i < ColumnsCount; i++)
            {
                var p = forCalc[i, i];
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (p == 0)
                    throw new ArithmeticException("Matrix transparate is imposible");
                forCalc.RowDivide(i, p);

                for (var j = 0; j < RowsCount; j++)
                {
                    if (i == j)
                        continue;

                    forCalc.SubRowFromRow(j, i, forCalc[j, i]);
                }
            }
            return forCalc.GetRightMatrix();
        }

        /// <summary>
        /// Деление указанной строки на число double в матрице
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="number">Число</param>
        public void RowDivide(int row, double number)
        {
            for (var i = 0; i < ColumnsCount; i++)
            {
                this[row, i] = this[row, i] / number;
            }
        }

        /// <summary>
        /// Вычитание одной строки матрицы из другой с указанным множителем
        /// </summary>
        /// <param name="row">Уменьшаемое</param>
        /// <param name="subRow">Вычитаемое</param>
        /// <param name="mult">Множитель</param>
        public void SubRowFromRow(int row, int subRow, double mult)
        {
            for (var i = 0; i < ColumnsCount; i++)
            {
                this[row, i] = this[row, i] - mult * this[subRow, i];
            }
        }

        /// <summary>
        /// Присоединение матрица справа
        /// </summary>
        /// <param name="matrixForAdd">Матрица для присоединения</param>
        /// <returns>Объедененная матрица</returns>
        public Matrix AddRightMatrix(Matrix matrixForAdd) {
            var result = new Matrix(RowsCount, ColumnsCount + matrixForAdd.ColumnsCount);
            var i = 0;
            for ( ; i < ColumnsCount; i++)
            {
                for (var j = 0; j < RowsCount; j++)
                {
                    result[i, j] = this[i, j];
                }
            }
            for ( ; i < result.ColumnsCount; i++)
            {
                for (var j = 0; j < RowsCount; j++)
                {
                    result[j, i] = matrixForAdd[j, i - ColumnsCount];
                }
            }
            return result;
        }

        /// <summary>
        /// Берется правая часть матрицы с кол-вом строк,столбцов ColumnsCount/2
        /// </summary>
        /// <returns>Правая часть матрицы</returns>
        public Matrix GetRightMatrix()
        {
            var result = new Matrix(RowsCount, ColumnsCount / 2);
            for (var i = RowsCount; i < ColumnsCount; i++)
            {
                for (var j = 0; j < RowsCount; j++)
                {
                    result[j, i - RowsCount] = this[j, i];
                }
            }
            return result;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="a">Первая матрица</param>
        /// <param name="b">Вторая матрица</param>
        /// <returns>Результирующая матрица</returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.RowsCount != b.RowsCount || a.ColumnsCount != b.ColumnsCount)
            {
                throw new ArgumentException("Not suitable matrix sizes");
            }
            var result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (var i = 0; i < a.RowsCount * a.ColumnsCount; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        /// <summary>
        /// Вычитание матриц
        /// </summary>
        /// <param name="a">Уменьшаемая матрица</param>
        /// <param name="b">Вычитаемая матрица</param>
        /// <returns>Результат вычитания матриц</returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.RowsCount != b.RowsCount || a.ColumnsCount != b.ColumnsCount)
            {
                throw new ArgumentException("Not suitable matrix sizes");
            }
            var result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (var i = 0; i < a.RowsCount * a.ColumnsCount; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="a">Первая матрица</param>
        /// <param name="b">Вторая матрица</param>
        /// <returns>Произведение матриц</returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.ColumnsCount != b.RowsCount)
            {
                throw new ArgumentException("Not suitable matrix sizes");
            }
            var result = new Matrix(a.RowsCount, b.ColumnsCount);
            for (var i = 0; i < result.RowsCount; i++)
            {
                for (var j = 0; j < result.ColumnsCount; j++)
                {
                    for (var r = 0; r < a.ColumnsCount; r++)
                    {
                        result[i, j] += a[i, r] * b[r, j];
                    }
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            var matrix = (Matrix) obj;
            if (matrix.ColumnsCount != ColumnsCount) return false;
            if (matrix.RowsCount != RowsCount) return false;
            for (var i = 0; i < RowsCount * ColumnsCount; i++)
            {
                if (Math.Abs(this[i] - matrix[i]) > Double.Epsilon)
                    return false;
            }
            return true;
        }
    }
}
