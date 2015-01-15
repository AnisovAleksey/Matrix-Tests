namespace calc
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
            if (matrix == null || dataGridView1 == null)
                return;
            PrintToDataGridView(dataGridView1, matrix);
        }

        
    }
}
