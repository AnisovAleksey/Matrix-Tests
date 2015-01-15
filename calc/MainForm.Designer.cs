namespace calc
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridViewLeft = new System.Windows.Forms.DataGridView();
            this.DataGridViewRight = new System.Windows.Forms.DataGridView();
            this.RadioButtonPlus = new System.Windows.Forms.RadioButton();
            this.RadioButtonMinus = new System.Windows.Forms.RadioButton();
            this.RadioButtonMod = new System.Windows.Forms.RadioButton();
            this.RadioButtonDiv = new System.Windows.Forms.RadioButton();
            this.NumericRightCols = new System.Windows.Forms.NumericUpDown();
            this.MatrixSizesRightLabel = new System.Windows.Forms.Label();
            this.NumericRightRows = new System.Windows.Forms.NumericUpDown();
            this.MatrixRightRowsLabel = new System.Windows.Forms.Label();
            this.MatrixLeftRowsLabel = new System.Windows.Forms.Label();
            this.MatrixLeftColsLabel = new System.Windows.Forms.Label();
            this.NumericLeftRows = new System.Windows.Forms.NumericUpDown();
            this.MatrixSizesLeftLabel = new System.Windows.Forms.Label();
            this.NumericLeftCols = new System.Windows.Forms.NumericUpDown();
            this.RunButton = new System.Windows.Forms.Button();
            this.MatrixRightColsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRightCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRightRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLeftRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLeftCols)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewLeft
            // 
            this.DataGridViewLeft.AllowUserToAddRows = false;
            this.DataGridViewLeft.AllowUserToDeleteRows = false;
            this.DataGridViewLeft.AllowUserToResizeColumns = false;
            this.DataGridViewLeft.AllowUserToResizeRows = false;
            this.DataGridViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewLeft.ColumnHeadersVisible = false;
            this.DataGridViewLeft.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewLeft.MultiSelect = false;
            this.DataGridViewLeft.Name = "DataGridViewLeft";
            this.DataGridViewLeft.RowHeadersVisible = false;
            this.DataGridViewLeft.Size = new System.Drawing.Size(200, 250);
            this.DataGridViewLeft.TabIndex = 2;
            this.DataGridViewLeft.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewCellPainting);
            this.DataGridViewLeft.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            this.DataGridViewLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewKeyDown);
            // 
            // DataGridViewRight
            // 
            this.DataGridViewRight.AllowUserToAddRows = false;
            this.DataGridViewRight.AllowUserToDeleteRows = false;
            this.DataGridViewRight.AllowUserToResizeColumns = false;
            this.DataGridViewRight.AllowUserToResizeRows = false;
            this.DataGridViewRight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewRight.ColumnHeadersVisible = false;
            this.DataGridViewRight.Location = new System.Drawing.Point(380, 12);
            this.DataGridViewRight.MultiSelect = false;
            this.DataGridViewRight.Name = "DataGridViewRight";
            this.DataGridViewRight.RowHeadersVisible = false;
            this.DataGridViewRight.Size = new System.Drawing.Size(200, 250);
            this.DataGridViewRight.TabIndex = 5;
            this.DataGridViewRight.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewCellPainting);
            this.DataGridViewRight.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            this.DataGridViewRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewKeyDown);
            // 
            // RadioButtonPlus
            // 
            this.RadioButtonPlus.AutoSize = true;
            this.RadioButtonPlus.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioButtonPlus.Location = new System.Drawing.Point(227, 12);
            this.RadioButtonPlus.Name = "RadioButtonPlus";
            this.RadioButtonPlus.Size = new System.Drawing.Size(116, 28);
            this.RadioButtonPlus.TabIndex = 6;
            this.RadioButtonPlus.TabStop = true;
            this.RadioButtonPlus.Text = "Сложение";
            this.RadioButtonPlus.UseVisualStyleBackColor = true;
            this.RadioButtonPlus.CheckedChanged += new System.EventHandler(this.RadioButtonPlusMinusCheckedChanged);
            // 
            // RadioButtonMinus
            // 
            this.RadioButtonMinus.AutoSize = true;
            this.RadioButtonMinus.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioButtonMinus.Location = new System.Drawing.Point(227, 56);
            this.RadioButtonMinus.Name = "RadioButtonMinus";
            this.RadioButtonMinus.Size = new System.Drawing.Size(124, 28);
            this.RadioButtonMinus.TabIndex = 7;
            this.RadioButtonMinus.TabStop = true;
            this.RadioButtonMinus.Text = "Вычитание";
            this.RadioButtonMinus.UseVisualStyleBackColor = true;
            this.RadioButtonMinus.CheckedChanged += new System.EventHandler(this.RadioButtonPlusMinusCheckedChanged);
            // 
            // RadioButtonMod
            // 
            this.RadioButtonMod.AutoSize = true;
            this.RadioButtonMod.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioButtonMod.Location = new System.Drawing.Point(227, 102);
            this.RadioButtonMod.Name = "RadioButtonMod";
            this.RadioButtonMod.Size = new System.Drawing.Size(129, 28);
            this.RadioButtonMod.TabIndex = 8;
            this.RadioButtonMod.TabStop = true;
            this.RadioButtonMod.Text = "Умножение";
            this.RadioButtonMod.UseVisualStyleBackColor = true;
            this.RadioButtonMod.CheckedChanged += new System.EventHandler(this.RadioButtonModCheckedChanged);
            // 
            // RadioButtonDiv
            // 
            this.RadioButtonDiv.AutoSize = true;
            this.RadioButtonDiv.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioButtonDiv.Location = new System.Drawing.Point(227, 145);
            this.RadioButtonDiv.Name = "RadioButtonDiv";
            this.RadioButtonDiv.Size = new System.Drawing.Size(150, 28);
            this.RadioButtonDiv.TabIndex = 9;
            this.RadioButtonDiv.TabStop = true;
            this.RadioButtonDiv.Text = "Обр. Матрица";
            this.RadioButtonDiv.UseVisualStyleBackColor = true;
            this.RadioButtonDiv.CheckedChanged += new System.EventHandler(this.RadioButtonDivCheckedChanged);
            // 
            // NumericRightCols
            // 
            this.NumericRightCols.Location = new System.Drawing.Point(451, 309);
            this.NumericRightCols.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericRightCols.Name = "NumericRightCols";
            this.NumericRightCols.Size = new System.Drawing.Size(41, 20);
            this.NumericRightCols.TabIndex = 3;
            this.NumericRightCols.ValueChanged += new System.EventHandler(this.RightNumericValueChanged);
            // 
            // MatrixSizesRightLabel
            // 
            this.MatrixSizesRightLabel.AutoSize = true;
            this.MatrixSizesRightLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixSizesRightLabel.Location = new System.Drawing.Point(376, 275);
            this.MatrixSizesRightLabel.Name = "MatrixSizesRightLabel";
            this.MatrixSizesRightLabel.Size = new System.Drawing.Size(143, 22);
            this.MatrixSizesRightLabel.TabIndex = 7;
            this.MatrixSizesRightLabel.Text = "Размеры матрицы";
            // 
            // NumericRightRows
            // 
            this.NumericRightRows.Location = new System.Drawing.Point(451, 338);
            this.NumericRightRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericRightRows.Name = "NumericRightRows";
            this.NumericRightRows.Size = new System.Drawing.Size(41, 20);
            this.NumericRightRows.TabIndex = 4;
            this.NumericRightRows.ValueChanged += new System.EventHandler(this.RightNumericValueChanged);
            // 
            // MatrixRightRowsLabel
            // 
            this.MatrixRightRowsLabel.AutoSize = true;
            this.MatrixRightRowsLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixRightRowsLabel.Location = new System.Drawing.Point(377, 337);
            this.MatrixRightRowsLabel.Name = "MatrixRightRowsLabel";
            this.MatrixRightRowsLabel.Size = new System.Drawing.Size(50, 18);
            this.MatrixRightRowsLabel.TabIndex = 10;
            this.MatrixRightRowsLabel.Text = "Строки";
            // 
            // MatrixLeftRowsLabel
            // 
            this.MatrixLeftRowsLabel.AutoSize = true;
            this.MatrixLeftRowsLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixLeftRowsLabel.Location = new System.Drawing.Point(12, 340);
            this.MatrixLeftRowsLabel.Name = "MatrixLeftRowsLabel";
            this.MatrixLeftRowsLabel.Size = new System.Drawing.Size(50, 18);
            this.MatrixLeftRowsLabel.TabIndex = 15;
            this.MatrixLeftRowsLabel.Text = "Строки";
            // 
            // MatrixLeftColsLabel
            // 
            this.MatrixLeftColsLabel.AutoSize = true;
            this.MatrixLeftColsLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixLeftColsLabel.Location = new System.Drawing.Point(12, 311);
            this.MatrixLeftColsLabel.Name = "MatrixLeftColsLabel";
            this.MatrixLeftColsLabel.Size = new System.Drawing.Size(59, 18);
            this.MatrixLeftColsLabel.TabIndex = 14;
            this.MatrixLeftColsLabel.Text = "Столбцы";
            // 
            // NumericLeftRows
            // 
            this.NumericLeftRows.Location = new System.Drawing.Point(86, 341);
            this.NumericLeftRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericLeftRows.Name = "NumericLeftRows";
            this.NumericLeftRows.Size = new System.Drawing.Size(41, 20);
            this.NumericLeftRows.TabIndex = 1;
            this.NumericLeftRows.ValueChanged += new System.EventHandler(this.LeftNumeriсValueChanged);
            // 
            // MatrixSizesLeftLabel
            // 
            this.MatrixSizesLeftLabel.AutoSize = true;
            this.MatrixSizesLeftLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixSizesLeftLabel.Location = new System.Drawing.Point(11, 278);
            this.MatrixSizesLeftLabel.Name = "MatrixSizesLeftLabel";
            this.MatrixSizesLeftLabel.Size = new System.Drawing.Size(143, 22);
            this.MatrixSizesLeftLabel.TabIndex = 12;
            this.MatrixSizesLeftLabel.Text = "Размеры матрицы";
            // 
            // NumericLeftCols
            // 
            this.NumericLeftCols.Location = new System.Drawing.Point(86, 312);
            this.NumericLeftCols.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericLeftCols.Name = "NumericLeftCols";
            this.NumericLeftCols.Size = new System.Drawing.Size(41, 20);
            this.NumericLeftCols.TabIndex = 0;
            this.NumericLeftCols.ValueChanged += new System.EventHandler(this.LeftNumeriсValueChanged);
            // 
            // RunButton
            // 
            this.RunButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunButton.Location = new System.Drawing.Point(237, 297);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(119, 47);
            this.RunButton.TabIndex = 10;
            this.RunButton.Text = "Выполнить";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButtonClick);
            // 
            // MatrixRightColsLabel
            // 
            this.MatrixRightColsLabel.AutoSize = true;
            this.MatrixRightColsLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixRightColsLabel.Location = new System.Drawing.Point(377, 308);
            this.MatrixRightColsLabel.Name = "MatrixRightColsLabel";
            this.MatrixRightColsLabel.Size = new System.Drawing.Size(59, 18);
            this.MatrixRightColsLabel.TabIndex = 9;
            this.MatrixRightColsLabel.Text = "Столбцы";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 423);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.MatrixLeftRowsLabel);
            this.Controls.Add(this.MatrixLeftColsLabel);
            this.Controls.Add(this.NumericLeftRows);
            this.Controls.Add(this.MatrixSizesLeftLabel);
            this.Controls.Add(this.NumericLeftCols);
            this.Controls.Add(this.MatrixRightRowsLabel);
            this.Controls.Add(this.MatrixRightColsLabel);
            this.Controls.Add(this.NumericRightRows);
            this.Controls.Add(this.MatrixSizesRightLabel);
            this.Controls.Add(this.NumericRightCols);
            this.Controls.Add(this.RadioButtonDiv);
            this.Controls.Add(this.RadioButtonMod);
            this.Controls.Add(this.RadioButtonMinus);
            this.Controls.Add(this.RadioButtonPlus);
            this.Controls.Add(this.DataGridViewRight);
            this.Controls.Add(this.DataGridViewLeft);
            this.Name = "MainForm";
            this.Text = "Калькулятор матриц";
            this.VisibleChanged += new System.EventHandler(this.MainFormVisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRightCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRightRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLeftRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLeftCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewLeft;
        private System.Windows.Forms.DataGridView DataGridViewRight;
        private System.Windows.Forms.RadioButton RadioButtonPlus;
        private System.Windows.Forms.RadioButton RadioButtonMinus;
        private System.Windows.Forms.RadioButton RadioButtonMod;
        private System.Windows.Forms.RadioButton RadioButtonDiv;
        private System.Windows.Forms.NumericUpDown NumericRightCols;
        private System.Windows.Forms.Label MatrixSizesRightLabel;
        private System.Windows.Forms.NumericUpDown NumericRightRows;
        private System.Windows.Forms.Label MatrixRightRowsLabel;
        private System.Windows.Forms.Label MatrixLeftRowsLabel;
        private System.Windows.Forms.Label MatrixLeftColsLabel;
        private System.Windows.Forms.NumericUpDown NumericLeftRows;
        private System.Windows.Forms.Label MatrixSizesLeftLabel;
        private System.Windows.Forms.NumericUpDown NumericLeftCols;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label MatrixRightColsLabel;
    }
}

