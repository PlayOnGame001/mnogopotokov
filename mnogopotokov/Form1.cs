using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mnogopotokov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("C:");
            comboBox1.Items.Add("E:");
            comboBox1.Items.Add("F:");
            comboBox1.Items.Add("D:");
        }
        public void FileThread()
        {
            listView1.Items.Clear();
            string[] astrFiles = Directory.GetFiles(comboBox1.SelectedItem.ToString() + path);
            foreach (string file in astrFiles)
            {
                Thread.Sleep(300);
                if (file.Contains("." + textBox1.Text))
                {
                    listView1.Items.Add(file);
                }
            }
        }
        string path = "\\Users\\danya\\OneDrive\\Documents";
        Thread thr;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                thr = new Thread(new ThreadStart(FileThread));
                thr.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            thr.Suspend();
        }
    }
}
