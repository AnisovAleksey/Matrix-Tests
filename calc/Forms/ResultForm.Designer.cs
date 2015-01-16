namespace calc.Forms
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridViewResult = new System.Windows.Forms.DataGridView();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewResult
            // 
            this.DataGridViewResult.AllowUserToAddRows = false;
            this.DataGridViewResult.AllowUserToDeleteRows = false;
            this.DataGridViewResult.AllowUserToResizeColumns = false;
            this.DataGridViewResult.AllowUserToResizeRows = false;
            this.DataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewResult.ColumnHeadersVisible = false;
            this.DataGridViewResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewResult.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewResult.MultiSelect = false;
            this.DataGridViewResult.Name = "DataGridViewResult";
            this.DataGridViewResult.RowHeadersVisible = false;
            this.DataGridViewResult.Size = new System.Drawing.Size(600, 400);
            this.DataGridViewResult.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(226, 446);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(184, 48);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 522);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DataGridViewResult);
            this.Name = "ResultForm";
            this.Text = "Результат вычислений";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewResult;
        private System.Windows.Forms.Button CloseButton;
    }
}