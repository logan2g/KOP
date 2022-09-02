using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _1st_lab_kop
{
    public partial class newDataGridView : UserControl
    {
        public newDataGridView()
        {
            InitializeComponent();
        }

        private List<string> fields;

        public void ConfigureGrid(int nColumns, List<string> headers, List<int> width, 
            List<bool> visible, List<string> fieldName)
        {
            if (nColumns != headers.Count || nColumns != width.Count || nColumns != visible.Count || nColumns != fieldName.Count)
            {
                throw new Exception("Ошибка во входных данных! Проверьте количество и указанные данные для списков");
            }
            for (int i = 0; i < nColumns; i++)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    Name = fieldName[i],
                    ReadOnly = true,
                    HeaderText = headers[i],
                    Visible = visible[i],
                    Width = width[i]
                };
                dataGridView.Columns.Add(column);
            }
            fields = fieldName;
        }

        public void InsertData<T>(List<T> data)
        {
            foreach (var elem in data)
            {
                var objs = new List<object>();
                foreach (var conf in fields)
                {
                    var value = elem.GetType().GetProperty(conf).GetValue(elem);
                    objs.Add(value);
                }
                dataGridView.Rows.Add(objs.ToArray());
            }
        }

        public object GetObjByIndex<T>(int index)
        {
            if (index <= dataGridView.Rows.Count)
            {
                DataGridViewRow curRow = dataGridView.Rows[index];
                Type myType = typeof(T);
                object ret = myType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                for (int i = 0; i < fields.Count; i++)
                {
                    var field = fields[i];
                    var fieldInType = myType.GetProperty(field, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    fieldInType?.SetValue(ret, curRow.Cells[i].Value);
                }
                return ret;
            }
            return null;
        }

        public void Clear()
        {
            dataGridView.Rows.Clear();
        }

        public int CurrentIndex
        {
            get
            {
                if (dataGridView.SelectedRows.Count > 0) return dataGridView.SelectedRows[0].Index;
                return -1;
            }
            set
            {
                if (value <= dataGridView.Rows.Count)
                {
                    dataGridView.Rows[value].Selected = true;
                }
            }
        }
    }
}
