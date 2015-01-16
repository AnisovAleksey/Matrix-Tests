using System.Windows.Forms;
using calc.Model;

namespace calc.Forms
{
    public partial class ResultForm : MatrixForm
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ResultForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ввод матрицы 
        /// </summary>
        /// <param name="matrix"></param>
        public void MatrixInput(Matrix matrix)
        {
            if (matrix == null || DataGridViewResult == null)
                return;
            PrintToDataGridView(DataGridViewResult, matrix);
        }

        private void CloseButtonClick(object sender, System.EventArgs e)
        {
            Close();
        }

        
    }
}
