using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private void add_tree()
        {
            string[] dir = Environment.GetLogicalDrives();
           
            foreach (var item in dir.ToList<string>())
            {
                treeView1.Nodes.Add(item);
                add_tree(item);
            }
        }
        private void add_tree(string path)
        {
            try
            {
                string[] dir = Directory.GetDirectories(path);

                foreach (var item in dir.ToList<string>())
                {
                    treeView1.Nodes.Add(item);
                    add_tree(item);
                }
            }
            catch (Exception) { }
          
        }
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            add_tree();
           // Directory.GetLogicalDrives();
            //Environment.GetLogicalDrives().ToList<string>().ForEach(i => textBox1.Text += i + "\r\n");
          
        }
    }
}
