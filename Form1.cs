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
        string sh;
        string klh;
        Boolean flag = true;
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
            string xml_text = System.IO.File.ReadAllText(@"../../data.xml");
            string json_text = "{\n";
            Queue xml_queue = new Queue();

            int start_index = 0;
            int end_index = 0;
            int dot = 0;
            int eq_index = 0;
            int brack_index = 0;
            int index = 0;
            int oldind = 0;
            int inddex = 0;
            int olddind = 0;
            int endinddex = 0;
            int endolddind = 0;
            int start_txt = 0;
            int end_txt = 0;
            int Len = 0;
            int Len_txt = 0;
            int cnt = 0;
            int same_cnt = 1;
            int txt_cnt = 0;
            int find_greaterthan = 0;
            int find_lessthan = 0;
            bool tag_flag = false;
            bool ind_flag = false;
            bool noattr = true;
            bool txt = false;
            string queue_element = "";
            string txt_element = "";
            string front_element = "";
            string indentation = "";
            string prevtag = "";
            string attr = "";



            for (int i = start_index; end_index + 2 < xml_text.Length - 1; i++)
            {
                i = start_index;
                find_lessthan = xml_text.Substring(end_index).IndexOf('<') + end_index;
                start_index = find_lessthan + 1;
                find_greaterthan = xml_text.Substring(start_index).IndexOf('>') + start_index;
                end_index = find_greaterthan - 1;
                Len = end_index - start_index + 1;
                queue_element = xml_text.Substring(start_index, Len);
                xml_queue.Enqueue(queue_element);
                if (find_greaterthan + 1 != xml_text.Length && xml_text[find_greaterthan + 1] != '\n' && xml_text[find_greaterthan + 1] != '\r' && xml_text[find_greaterthan + 1] != '\t' && xml_text[find_greaterthan + 1] != '<')
                {
                    find_lessthan = xml_text.Substring(end_index).IndexOf('<') + end_index;
                    start_txt = find_greaterthan + 1;
                    end_txt = find_lessthan - 1;
                    Len_txt = end_txt - start_txt + 1;
                    txt_element = xml_text.Substring(start_txt, Len_txt);
                    xml_queue.Enqueue("$txt" + txt_element);
                }
            }

            for (int j = 0; xml_queue.Count != 0; j++)
            {
                cnt = 0;
                start_index = 0;
                end_index = 1;
                ind_flag = false;
                txt = false;
                front_element = xml_queue.Peek().ToString();
                xml_queue.Dequeue();
                File.WriteAllText("XMLText.txt", json_text);
                attr = "";
                for (int k = end_index; end_index < front_element.Length - 1; k++)
                {
                    File.WriteAllText("XMLText.txt", json_text);
                    if (front_element.Substring(0, 1) == "$" && front_element.Substring(0, 4) == "$txt")
                    {

                        if (noattr)
                        {

                            inddex = index;
                            olddind = inddex;
                            txt = true;
                            if (tag_flag)
                            {
                                dot = json_text.Substring(olddind).IndexOf(':') + olddind;
                                //string ttt = json_text.Substring(dot);
                                //olddind += ttt.IndexOf('{');
                                //string dttt = json_text.Substring(olddind);

                                json_text = json_text.Remove(dot + 1, 2);

                            }
                            noattr = false;
                            if (json_text[json_text.Length - 1] != '\t' && noattr)
                            {
                                if (json_text[json_text.Length - 1] == '\n' && json_text[json_text.Length - 2] == '{' && tag_flag)
                                {
                                    string hhh = json_text.Substring(json_text.Length - 200);
                                    json_text += json_text.Substring(json_text.Length - 4).Replace("{\n", " ");
                                    json_text += indentation;
                                }
                                else
                                {
                                    string hhdh = json_text.Substring(json_text.Length - 2);

                                    json_text += indentation + "\"#text\":";
                                }
                            }
                            else if (json_text[json_text.Length - 1] != '\t')
                            {
                                json_text += indentation;
                            }

                            //json_text.Substring(dot).Replace("{", "")
                            //json_text.Substring(dot).Replace("\n", "")
                            //json_text =json_text.Replace("],{", "");
                            //json_text = json_text.Replace("],\t{", "");
                            //json_text.Substring(dot).Replace("\n","");
                            inddex = json_text.Length - 1;

                            json_text += "\"" + front_element.Substring(4) + "\"";
                            if (json_text[json_text.Length - 1] == '\n')
                            {
                                json_text = json_text.Substring(json_text.Length - 1).Remove(0);
                            }
                            break;
                        }

                        if (attr != "text")
                        {
                            if (ind_flag || (json_text.Substring(json_text.Length - 1) == "\t"))
                            {

                                json_text += "\"#text\":";

                                ind_flag = false;
                            }
                            else
                            {
                                json_text += indentation + "\"#text\":";
                            }
                        }
                        attr = "";
                        txt_element = front_element.Insert(4, "\"");
                        txt_element = txt_element.Insert(front_element.Length + 1, "\"");
                        json_text += txt_element.Substring(4);
                        File.WriteAllText("XMLText.txt", json_text);
                        break;
                    }
                    else if (front_element.Substring(0, 3) == "!--")
                    {
                        break;
                    }
                    else if (front_element.Substring(0, 1) == "/")
                    {
                        oldind = index;
                        if (indentation.Length != 0)
                            indentation = indentation.Substring(0, indentation.Length - 1);
                        if (tag_flag == true)
                            same_cnt--;
                        if (same_cnt == 0)
                            json_text += "]\n";

                        json_text += "\n" + indentation + "},\n" + indentation;
                        if (index != 0 && tag_flag && oldind + 1 < json_text.Length)
                        {


                            if (json_text[oldind + 1] == ']')
                                json_text = json_text.Remove(oldind, 1);

                            json_text = json_text.Remove(index, 1);
                            //char dd = json_text[oldind + 1];
                            //char dxd = json_text[oldind];
                            //string dsd = json_text.Substring(oldind-6 , indentation.Length + 9);
                            if (json_text.Substring(oldind, 1) == ",")
                                json_text = json_text.Remove(oldind);
                        }

                        index = json_text.Length;
                        if (tag_flag)
                            json_text += "],\n" + indentation;
                        if (noattr)
                        {
                            endinddex = index;
                            endolddind = olddind;
                            endolddind = inddex;
                            string tftt = json_text.Substring(endolddind);
                            int ind = tftt.Substring(3).IndexOf('"') + endolddind + 3;


                            // string tfvftt = json_text.Substring(ind+4);
                            //json_text.Substring(ind).Replace("\"{", "\"");
                            json_text = json_text.Remove(ind + 4);
                            json_text += indentation;

                            endolddind += tftt.IndexOf('}');
                            //string ttcdt = json_text.Substring(endolddind);

                            //json_text = json_text.Remove(endolddind,1);
                            //json_text.Substring(dot).Replace("{", "");
                            //string dddd = json_text.Substring(endinddex);
                            // string ef = json_text.Substring(olddind);
                            // string rr = json_text.Substring(inddex);

                            //json_text +=json_text.Substring(endolddind).Replace("\n", "");
                            //json_text += json_text.Substring(olddind).Replace("},\n", "");
                            //json_text += json_text.Substring(olddind).Replace(",", "");
                            //json_text += json_text.Substring(olddind).Replace("{", "");
                            //json_text =json_text.Replace("],{", "");
                            //json_text = json_text.Replace("],\t{", "");

                            endinddex = json_text.Length - 1;
                            //json_text += "\"" + front_element.Substring(4) + "\"";

                            break;
                        }
                        break;
                    }
                    else
                    {
                        if (cnt == 0)
                        {
                            noattr = true;
                            start_index = 0;
                            if (json_text[json_text.Length - 1] != '\n' || json_text[json_text.Length - 1] != '\t')
                            {
                                json_text += "\n" + indentation;
                            }
                            if (front_element.Contains(' '))
                                end_index = front_element.Substring(start_index).IndexOf(' ') + start_index - 1;
                            else
                            {
                                end_index = front_element.Length - 1;

                            }
                            Len = end_index - start_index + 1;
                            txt_element = front_element.Substring(start_index, Len);
                            if (prevtag != txt_element)
                            {
                                txt_element = txt_element.Insert(txt_element.Length, "\":");
                                txt_element = txt_element.Insert(0, "\"");
                                json_text += txt_element;
                                tag_flag = false;
                                attr = "";
                                brack_index = json_text.Length;
                            }
                            else
                            {
                                tag_flag = true;
                                if (brack_index != 0 && !(json_text[brack_index] == '['))
                                {
                                    json_text = json_text.Insert(brack_index, "[\n" + indentation);

                                }
                                same_cnt++;
                            }

                            prevtag = front_element.Substring(start_index, Len);
                            indentation += "\t";
                            if (txt == false)
                                json_text += "{\n";

                            cnt++;
                        }
                        else
                        {
                            noattr = false;
                            if (cnt % 2 != 0)
                            {
                                json_text += indentation;
                                ind_flag = true;
                            }
                            start_index = end_index + 2;
                            Len = front_element.Substring(start_index).IndexOf('"') + 1;
                            if (Len == 0) break;
                            end_index = start_index + Len - 2;
                            txt_element = front_element.Substring(start_index, Len);
                            if (txt_element.Contains('='))
                            {

                                eq_index = txt_element.Substring(0).IndexOf('=');
                                txt_element = txt_element.Replace("=", ":");
                                txt_element = txt_element.Insert(eq_index, "\"");
                                txt_element = txt_element.Insert(0, "\"@");

                            }

                            json_text += txt_element;
                            if (cnt % 2 == 0)
                            {
                                json_text += ",\n";
                            }
                            cnt++;
                        }
                    }

                }
                if (xml_queue.Count == 1) json_text += "}";
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
            List<string> arr = new List<string>();
            Stack<string> collector = new Stack<string>();
            for (int i = 0; i < txt_read.Length; i++)
            {
                if ((txt_read[i] == '\r') || (txt_read[i] == '\n'))
                {
                    continue;
                }
                if (txt_read[i] != '>')
                {
                    s += txt_read[i];
                    if ((s[0] != '<') && (txt_read[i] == '<'))
                    {
                        s = s.Substring(0, s.Length - 1);
                        array.Add(s);
                        s = "";
                        if (i != txt_read.Length - 1)
                        {
                            if (txt_read[i + 1] != '/')
                            {
                                array.Add("</" + collector.Peek());
                                collector.Pop();
                            }
                        }
                        i--;
                        continue;
                    }
                }
                else
                {
                    if (txt_read[i] == '>')
                    {
                        if ((s[1] == '!') || (s[1] == '?'))
                        {
                            array.Add(s + '>');
                        }
                        else if (s[1] != '/')
                        {
                            array.Add(s + '>');
                            for (int o = 0; o < s.Length; o++)
                            {
                                sh += s[o];
                                if ((s[0] == '<') && (s[o] == ' ') && (s[1] != '/'))
                                {
                                    sh = sh.Substring(0, sh.Length - 1);
                                    arr.Add(sh + '>');
                                    string temp = arr[arr.Count - 1].Substring(1);
                                    collector.Push(temp);
                                    sh = "";
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag == true)
                            {
                                arr.Add(sh + '>');
                                string temp = arr[arr.Count - 1].Substring(1);
                                collector.Push(temp);
                            }
                            flag = true;
                        }
                        else
                        {
                            if (s + '>' == ("</" + collector.Peek()))
                            {
                                array.Add(s + '>');
                                collector.Pop();
                            }
                            else
                            {
                                s = ("</" + collector.Peek());
                                array.Add(s);
                                collector.Pop();
                            }
                        }
                    }
                    s = "";
                    sh = "";
                }
            }
            if (collector.Count != 0)
            {
                while (collector.Count != 0)
                {
                    array.Add("</" + collector.Peek());
                    collector.Pop();
                }
            }
            for (int l = 0; l < array.Count; l++)
            {
                klh += array[l] + '\n';
            }
            txtArea.Text = klh;
        }
    }
}
