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

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            for (int i = start_index; end_index < xml_text.Length - 1; i++)
            {
                Len = 0;
                stop = false;
                flag_txt = false;
                i = start_index;
                char r = xml_text[i];
                char ee = xml_text[i + 1];
                if (xml_text[i + 1] == '!' && xml_text[i] == '<')
                {
                    lastcomment = xml_text.Substring(start_index).IndexOf('>');
                    start_index += lastcomment + 1;
                    end_index = start_index - 1;

                }
                else if (i != 0 && xml_text[i - 1] == '>' && (xml_text[i] == '\n' || xml_text[i] == '\r' || xml_text[i] == '\t'))
                {
                    lastcomment = xml_text.Substring(start_index).IndexOf('<');
                    start_index += lastcomment;
                }
                else if (i != 0 && xml_text[i - 1] == '>')
                {
                    txtLen = xml_text.Substring(start_index).IndexOf('<');
                    end_index = start_index + txtLen;
                    txt = xml_text.Substring(start_index, txtLen);
                    start_index = end_index + 1;
                    json_text += "\"#text\" : \"";
                    json_text += txt;
                    json_text += "\"\n";
                    //json_text += "},\n\"";
                    flag_txt = true;
                }
                else if (xml_text[i] == '/')
                {
                    lastcomment = xml_text.Substring(start_index).IndexOf('<');
                    if (lastcomment == -1)
                    {
                        json_text += "},";

                        json_text += "\n}";

                        File.WriteAllText("XMLText.txt", json_text);

                        break;
                    }
                    char ww = xml_text[start_index];
                    char fw = xml_text[end_index];
                    char wyw = xml_text[start_index + 1];
                    start_index += lastcomment;
                    if (xml_text[start_index + 1] == '/')
                    {
                        start_index++;
                    }
                    json_text += "},\n";
                    Len = 0;
                }
                else if (xml_text[i] == '<' && (xml_text[i + 1] != '!' || xml_text[i + 1] != '/'))
                {
                    start_index = i;
                    json_text += "\"";
                    for (int j = start_index; stop == false; j++)
                    {
                        if (xml_text[j] == ' ' && xml_text[j + 1] != ' ' && flag_txt == false)
                        {
                            end_index = j;
                            Len = end_index - start_index;
                            if (xml_text.Substring(start_index, Len).Contains('<'))
                            {
                                start_index += 1;
                                Len -= 1;
                            }
                            if (xml_text.Substring(start_index, Len).Contains('?'))
                            {
                                start_index += 1;
                                Len -= 1;
                            }

                            break;
                        }
                        else if (xml_text[j] == '>')
                        {
                            end_index = j;
                            Len = end_index - start_index;
                            if (xml_text.Substring(start_index, Len).Contains('<'))
                            {
                                start_index += 1;
                                Len -= 1;
                            }
                            if (xml_text.Substring(start_index, Len).Contains('?'))
                            {
                                start_index += 1;
                                Len -= 1;
                            }

                            break;
                        }
                    }
                }


                else if (xml_text[i] != '>')
                {
                    Len = 1;
                    for (int k = start_index + 1; stop == false; k++)
                    {

                        if (xml_text.Substring(start_index, Len).Contains('>'))
                        {
                            if (xml_text.Substring(start_index, Len).Contains('?'))
                            {
                                end_index = k - 3;
                            }
                            else
                            {
                                end_index = k - 2;
                            }

                            Len = end_index - start_index - 1;
                            if (xml_text[end_index + 2] == '\n' || xml_text[end_index + 2] == '\t' || xml_text[end_index + 2] == '\r')
                            {
                                flag_end = true;
                            }
                            break;
                        }

                        if (xml_text[k] == '"')
                        {
                            while (xml_text[k + 1] != '"')
                            {
                                k++;
                            }
                            end_index = k + 1;
                            Len = end_index - start_index + 1;
                            break;
                        }

                        Len++;
                    }

                }
                //xml_stack.Push(xml_text.Substring(start_index, Len));

                
                else if (Len != 0 && !flag_txt)
                {
                    json_text += xml_text.Substring(start_index, Len);
                    json_text += "\": {\n";

                    if (xml_text[end_index + 1] == '?')
                    {
                        start_index = end_index + 2;
                    }
                    else
                    {
                        start_index = end_index + 1;
                    }
                }
                File.WriteAllText("XMLText.txt", json_text);
            }
            json_text += "\n}";
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
    }
}
