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

        private void buttonSavePdfWithHeaders_Click(object sender, EventArgs e)
        {
            SavePdfWithHeaders pdf = new SavePdfWithHeaders();
            List<string> width = new List<string>();
            List<string> height = new List<string>();
            List<Tuple<string, string>> header = new List<Tuple<string, string>>();
            List<Person> data = new List<Person>();
            //width
            width.Add("4cm");
            width.Add("3cm");
            width.Add("3cm");
            width.Add("2cm");
            width.Add("2cm");
            //height
            height.Add("1cm");
            height.Add("1cm");
            height.Add("1cm");
            height.Add("1cm");
            height.Add("1cm");
            height.Add("1cm");
            //header
            header.Add(new Tuple<string, string>("Подразделение", "Department"));
            header.Add(new Tuple<string, string>("Фамилия", "Surname"));
            header.Add(new Tuple<string, string>("Имя", "Name"));
            header.Add(new Tuple<string, string>("Возраст", "Age"));
            header.Add(new Tuple<string, string>("Премия", "Bonus"));
            //data
            data.Add(new Person()
            {
                Id = 1,
                Status = false,
                Name = "Иван",
                Surname = "Иванов",
                Age = 34,
                Children = false,
                Car = true,
                Post = "Инж.",
                Department = "Деп. 1",
                Experience = 6,
                Bonus = 2000.1
            });
            data.Add(new Person()
            {
                Id = 2,
                Status = false,
                Name = "Петр",
                Surname = "Петров",
                Age = 44,
                Children = true,
                Car = true,
                Post = "Инж.",
                Department = "Деп. 1",
                Experience = 12,
                Bonus = 2000.1
            });
            data.Add(new Person()
            {
                Id = 3,
                Status = true,
                Name = "Сергей",
                Surname = "Сергеев",
                Age = 55,
                Children = false,
                Car = true,
                Post = "Рук.",
                Department = "Деп. 1",
                Experience = 34,
                Bonus = 5000.5
            });
            data.Add(new Person()
            {
                Id = 4,
                Status = false,
                Name = "Ольга",
                Surname = "Иванова",
                Age = 34,
                Children = true,
                Car = false,
                Post = "Бух.",
                Department = "Бухг.",
                Experience = 8,
                Bonus = 2000.1
            });
            data.Add(new Person()
            {
                Id = 5,
                Status = true,
                Name = "Татьяна",
                Surname = "Петрова",
                Age = 44,
                Children = false,
                Car = false,
                Post = "Ст. Бух.",
                Department = "Бухг.",
                Experience = 14,
                Bonus = 7000.6
            });
            SaveFileDialog dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pdf.CreatePdf(dialog.FileName, "Заголовок", width, height, header, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            SavePdfWithPlot pdf = new SavePdfWithPlot();
            SaveFileDialog dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pdf.CreatePdf(dialog.FileName, "Заголовок", "Гистограмма 1", _2nd_lab_kop.LegendPostion.Left,
                        "Серия 1", new double[] { 1, 3.4, 5, 8, 9.3});
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
