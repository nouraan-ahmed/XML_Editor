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
        string s;
        string line;
        string last_l;
        string t;
        string klh;
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

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String txt_read = txtArea.Text;
            string c;
            int j = 0;
            txtArea.Clear();
            for (int i = 0; i < txt_read.Length; i++)
            {
                if ((txt_read[i] == '>') && (txt_read[i + 1] == ' '))
                {
                    goto label;
                }
            label: if ((txt_read[i] == '<') && (txt_read[i + 1] == '/'))
                {
                    j--;
                    var str = new string(' ', 2 * j);
                    txtArea.AppendText("\n" + str + txt_read[i]);
                    continue;

                }
                else if (txt_read[i] == '<')
                {
                    var str = new string(' ', 2 * j);
                    txtArea.AppendText("\n" + str + txt_read[i]);
                    j++;
                    continue;
                }
                else
                {
                    txtArea.Text += txt_read[i];
                }
                txtArea.Update();
            }
        }

        private void ToJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start_index = 0;
            int end_index = 0;
            int Len = 0;
            int txtLen = 0;
            int eq_index;
            int index;
            int lastcomment;
            bool flag_end = false;
            bool flag_txt = false;
            bool stop = false;
            string txt = "";
            string json_text = "{\n";
            //Stack xml_stack = new Stack();
            string xml_text = System.IO.File.ReadAllText(@"../../data-sample.xml");


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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as..";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                txtoutput.Write(txtArea.Text);
                txtoutput.Close();
            }
        }
        
        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            String txt_read = txtArea.Text;
            List<string> array = new List<string>();
            Stack<string> collector = new Stack<string>();
            for (int i = 0; i < txt_read.Length; i++)
            {

                if ((txt_read[i] != '\n') && (txt_read[i] != ' '))
                {
                    s += txt_read[i];
                }
                else
                {
                    array.Add(s);
                    s = "";
                }
                if (i == txt_read.Length - 1)
                {
                    array.Add(s);
                    s = "";
                }

            }
            for (int j = 0; j < array.Count; j++)
            {
                line = array[j];
                if (j != 0)
                {
                    last_l = array[j - 1];
                }
                else
                    last_l = array[0];

                if (line[0] == '<')
                {
                    if (line[1] == '/')
                    {
                        if (line != ("</" + collector.Peek()))
                        {
                            array[j] = "</" + collector.Peek();
                            collector.Pop();
                        }
                        else
                            collector.Pop();
                    }
                    else if ((last_l[0] != '<') && (j != 0))
                    {
                        array.Insert(j, "</" + collector.Peek());
                        collector.Pop();
                    }
                    else
                    {
                        string temp = line.Substring(1);
                        collector.Push(temp);
                    }
                }
            }
            if (collector.Count == 0)
            {
                for (int l = 0; l < array.Count; l++)
                {
                    klh += array[l] + '\n';
                }
                txtArea.Text = klh;
            }
            else
            {
                while (collector.Count != 0)
                {
                    array.Add("</" + collector.Peek());
                    collector.Pop();
                }
                for (int l = 0; l < array.Count; l++)
                {
                    klh += array[l] + '\n';
                }
                txtArea.Text = klh;
            }
        }
    }
}
