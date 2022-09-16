using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _1st_lab_kop
{
    public partial class newListBox : UserControl
    {
        public newListBox()
        {
            InitializeComponent();
        }

        public string SelectedItem
        {
            set
            {
                if (listBox.Items.Contains(value))
                {
                    listBox.SelectedIndex = listBox.Items.IndexOf(value);
                }
            }
            get
            {
                if (listBox.SelectedIndex > -1) return listBox.SelectedItem.ToString();
                return "";
            }
        }

        public void AddListener(EventHandler handler)
        {
            listBox.SelectedIndexChanged += handler;
        }

        public void ClearData()
        {
            listBox.Items.Clear();
        }

        public void InsertData(List<string> value)
        {
            listBox.Items.AddRange(value.ToArray());
        }
    }
}
