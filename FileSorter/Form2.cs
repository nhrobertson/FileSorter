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
    public partial class Form2 : Form
    {
        public static List<FileData> files = new List<FileData>();
        BindingSource bs = new BindingSource();
        public static Form2 instance;

        public Form2()
        {
            InitializeComponent();
            instance = this;
            dragDrop.AllowDrop = true;
            dragDrop.AutoScroll = true;
        }
        public Form2(string file)
        {
            InitializeComponent();
            instance = this;
            dragDrop.AllowDrop = true;
            dragDrop.AutoScroll = true;
            FileData fileData = new FileData(file);
            files.Add(fileData);
            
        }

        public Form2(string[] arrFiles)
        {
            InitializeComponent();
            instance = this;
            dragDrop.AllowDrop = true;
            dragDrop.AutoScroll = true;
            foreach(string file in arrFiles)
            {
                FileData fileData = new FileData(file);
                files.Add(fileData);
            }

        }

        internal void receiveData(string text, int index)
        {
            //MessageBox.Show(index.ToString());
            if (index >= 0)
            {
                files[index].tags.Add(text);
                bs.ResetBindings(false);
            }
            
        }

        internal void receiveDeletion(int index, int tagIndex)
        {
            if (index >= 0)
            {
                files[index].tags.RemoveAt(tagIndex);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            bs.DataSource = files;
            FileListBox.DataSource = bs;
            FileListBox.DisplayMember = "Name";
            FileListBox.ValueMember = "Location";
        }


        private void dragDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] arrFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in arrFiles)
            {
                FileData fileData = new FileData(file);
                files.Add(fileData);
            }
            bs.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileData fileData = new FileData(dialog.FileName);
                    files.Add(fileData);
                    bs.ResetBindings(false);
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FileListBox_DoubleClick(object sender, EventArgs e)
        {
            if (FileListBox.SelectedItem != null)
            {
                Form4 f4 = new Form4(files[FileListBox.SelectedIndex].tags, FileListBox.SelectedIndex);
                f4.ShowDialog();
            }
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            bs.ResetBindings(false);
        }

        private void dragDrop_DragEnter(object sender, DragEventArgs e)
        {
            //Changes icon of mouse to indicate drag and drop
            e.Effect = DragDropEffects.All;
        }
    }
}
