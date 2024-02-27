namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CalculationInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CalculationInput
            // 
            this.CalculationInput.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CalculationInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CalculationInput.Location = new System.Drawing.Point(12, 12);
            this.CalculationInput.Multiline = true;
            this.CalculationInput.Name = "CalculationInput";
            this.CalculationInput.ReadOnly = true;
            this.CalculationInput.Size = new System.Drawing.Size(366, 114);
            this.CalculationInput.TabIndex = 0;
            this.CalculationInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(385, 516);
            this.Controls.Add(this.CalculationInput);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox CalculationInput;
    }
}