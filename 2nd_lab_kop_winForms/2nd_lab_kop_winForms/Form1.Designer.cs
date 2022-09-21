
namespace _2nd_lab_kop_winForms
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
            this.buttonSavePdf = new System.Windows.Forms.Button();
            this.buttonSavePdfWithHeaders = new System.Windows.Forms.Button();
            this.buttonChart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSavePdf
            // 
            this.buttonSavePdf.Location = new System.Drawing.Point(13, 13);
            this.buttonSavePdf.Name = "buttonSavePdf";
            this.buttonSavePdf.Size = new System.Drawing.Size(190, 23);
            this.buttonSavePdf.TabIndex = 0;
            this.buttonSavePdf.Text = "Сохранить пробный набор";
            this.buttonSavePdf.UseVisualStyleBackColor = true;
            this.buttonSavePdf.Click += new System.EventHandler(this.buttonSavePdf_Click);
            // 
            // buttonSavePdfWithHeaders
            // 
            this.buttonSavePdfWithHeaders.Location = new System.Drawing.Point(13, 43);
            this.buttonSavePdfWithHeaders.Name = "buttonSavePdfWithHeaders";
            this.buttonSavePdfWithHeaders.Size = new System.Drawing.Size(190, 23);
            this.buttonSavePdfWithHeaders.TabIndex = 1;
            this.buttonSavePdfWithHeaders.Text = "Сохранить набор с зголовками";
            this.buttonSavePdfWithHeaders.UseVisualStyleBackColor = true;
            this.buttonSavePdfWithHeaders.Click += new System.EventHandler(this.buttonSavePdfWithHeaders_Click);
            // 
            // buttonChart
            // 
            this.buttonChart.Location = new System.Drawing.Point(13, 72);
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(190, 23);
            this.buttonChart.TabIndex = 2;
            this.buttonChart.Text = "График";
            this.buttonChart.UseVisualStyleBackColor = true;
            this.buttonChart.Click += new System.EventHandler(this.buttonChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonChart);
            this.Controls.Add(this.buttonSavePdfWithHeaders);
            this.Controls.Add(this.buttonSavePdf);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSavePdf;
        private System.Windows.Forms.Button buttonSavePdfWithHeaders;
        private System.Windows.Forms.Button buttonChart;
    }
}

