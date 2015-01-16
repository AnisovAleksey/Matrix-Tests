using System;
using System.Windows.Forms;
using calc.Model;
using calc.Forms;

namespace calc
{
    static class ProgramController
    {
        private static ResultForm _secondForm;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Запуск расчета для матриц и отображение формы с результатом
        /// </summary>
        /// <param name="matrixA">Первая матрица</param>
        /// <param name="matrixB">Вторая матрица</param>
        /// <param name="operation">Операция для матриц</param>
        public static void CalculateMatrix(Matrix matrixA, Matrix matrixB, Operation operation)
        {
            Matrix result = null;
            try
            {
                switch (operation)
                {
                    case Operation.Plus:
                        result = matrixA + matrixB;
                        break;
                    case Operation.Minus:
                        result = matrixA - matrixB;
                        break;
                    case Operation.Mod:
                        result = matrixA * matrixB;
                        break;
                    case Operation.Div:
                        result = matrixA.Transparate();
                        break;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
            if (_secondForm == null || _secondForm.IsDisposed)
                _secondForm = new ResultForm();
            _secondForm.MatrixInput(result);
            _secondForm.Show();
        }
    }
}
