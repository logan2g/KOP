using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _2nd_lab_kop;

namespace _2nd_lab_kop_winForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSavePdf_Click(object sender, EventArgs e)
        {
            SavePdfWithSimpleTable pdf = new SavePdfWithSimpleTable();
            List<string[][]> data = new List<string[][]>();
            data.Add(new string[][] {
                new string[] { "1", "3" },
                new string[] { "2", "4" } });
            SaveFileDialog dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pdf.CreatePdf(dialog.FileName, "Заголоооооооооооооовок", data);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
