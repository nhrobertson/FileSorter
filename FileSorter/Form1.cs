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
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            dragDrop.AllowDrop = true;
            dragDrop.AutoScroll = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = dialog.FileName;
                    Form2 form2 = new Form2(file);
                    form2.Show();
                    this.Close();
                } else
                {
                    Form3 form3 = new Form3();
                    form3.Show();
                }
            }
            
        }
        private void dragDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Form2 form2 = new Form2(files);
            form2.Show();
            this.Close();
        }

        private void dragDrop_DragEnter(object sender, DragEventArgs e)
        {
            //Changes icon of mouse to indicate drag and drop
            e.Effect = DragDropEffects.All;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
