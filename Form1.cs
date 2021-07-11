using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XML_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(open.FileName));
                txtArea.Text = read.ReadToEnd();
                read.Dispose();
                txtArea.Language = FastColoredTextBoxNS.Language.XML;

            }

        }

         private void fileSizeToolStripMenuItem_Click(object sender, EventArgs e)
          {
            String txt_read = txtArea.Text;
            for (int i = 0; i < txt_read.Length; i++)
            {
                if (txt_read[i] == ' ')
               txtArea.Text = txtArea.Text.Replace(" ", String.Empty);
                txtArea.Text = txtArea.Text.Replace("\n", "").Replace("\r", "");
            }

          }
          
        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
