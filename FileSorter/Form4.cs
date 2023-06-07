using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class Form4 : Form
    {
        BindingSource bs = new BindingSource();
        int index;
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(List<string> _tags, int _index)
        {
            InitializeComponent();
            bs.DataSource = _tags;
            tagBox.DataSource = bs;
            index = _index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.receiveData(textBox1.Text, index);
            bs.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.receiveDeletion(index, tagBox.SelectedIndex);
            bs.ResetBindings(false);
        }
    }
}
