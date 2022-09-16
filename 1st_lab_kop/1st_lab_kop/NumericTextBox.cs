using System;
using System.Windows.Forms;

namespace _1st_lab_kop
{
    public partial class NumericTextBox : UserControl
    {
        public NumericTextBox()
        {
            InitializeComponent();
        }

        private void NumericTextBox_Load(object sender, EventArgs e)
        {
            checkBox.CheckedChanged += IsTextBoxNull;
        }

        public void AddListener(EventHandler handler)
        {
            textBox.TextChanged += handler;
        }

        public int? NumberValue
        {
            get
            {
                if (checkBox.Checked) return null;
                if (textBox.Text.Equals("")) throw new Exception("Не введено значение");
                int num;
                if (!Int32.TryParse(textBox.Text, out num))
                {
                    throw new Exception("Введено некорректное значение");
                }
                return num;
            }
            set
            {
                if (value == null)
                {
                    checkBox.Checked = true;
                    textBox.Text = "";
                    return;
                }
                checkBox.Checked = false;
                textBox.Text = value.ToString();
            }
        }

        private void IsTextBoxNull(object sender, EventArgs e)
        {
            textBox.Enabled = !checkBox.Checked;
        }
    }
}
