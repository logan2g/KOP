using System;
using System.Collections.Generic;
using System.Drawing;
using _1st_lab_kop;
using System.Windows.Forms;

namespace _1st_lab_kop_winForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private newListBox list;
        private NumericTextBox numTextBox;
        private newDataGridView gridView;

        private void MainForm_Load(object sender, EventArgs e)
        {
            //list
            list = new newListBox();
            list.Size = new Size(100, 100);
            list.Location = new Point(10, 10);
            List<string> data = new List<string>();
            for (int i = 2; i < 6; i++)
            {
                data.Add(i.ToString());
            }
            list.InsertData(data);
            list.AddListener(listIndexChanged);
            Controls.Add(list);
            //numeric textBox
            numTextBox = new NumericTextBox();
            numTextBox.Location = new Point(120, 10);
            numTextBox.NumberValue = 200;
            Controls.Add(numTextBox);
            //dataGridView
            gridView = new newDataGridView();
            gridView.Location = new Point(300, 10);
            List<GridColumnConfig> configs = new List<GridColumnConfig>();
            configs.Add(new GridColumnConfig
            {
                Header = "Имя",
                FieldName = "FirstName",
                Width = 100,
                Visible = true
            });
            configs.Add(new GridColumnConfig
            {
                Header = "Фамилия",
                FieldName = "Surname",
                Width = 100,
                Visible = true
            });
            configs.Add(new GridColumnConfig
            {
                Header = "Отчество",
                FieldName = "LastName",
                Width = 100,
                Visible = true
            });
            try
            {
                gridView.ConfigureGrid(configs);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            List<Person> workers = new List<Person>();
            workers.Add(new Person
            {
                FirstName = "Иван",
                LastName = "Анатольевич",
                Surname = "Фадеев"
            });
            workers.Add(new Person
            {
                FirstName = "Николай",
                LastName = "Сергеевич",
                Surname = "Денисов"
            });
            workers.Add(new Person
            {
                FirstName = "Георгий",
                LastName = "Евгеньевич",
                Surname = "Артемьев"
            });
            gridView.InsertData<Person>(workers);
            Controls.Add(gridView);
        }

        private void listIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Выбран элемент " + list.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Значение: " + numTextBox.NumberValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person tmp = (Person)gridView.GetObjByIndex<Person>((int)numTextBox.NumberValue);
            MessageBox.Show(tmp.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gridView.CurrentIndex = (int)numTextBox.NumberValue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numTextBox.NumberValue = gridView.CurrentIndex;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            list.SelectedItem = numTextBox.NumberValue.ToString();
        }
    }
}
