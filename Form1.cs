using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
            String c = null;

            int j = 0;

            for (int i = 0; i < txt_read.Length; i++)
            {
                if ((txt_read[i] == '<') && (txt_read[i + 1] != '/'))
                {
                    j++;
                    var str = new string(' ', 2 * j);
                    c += "\n" + str + txt_read[i];
                    continue;
                }
                else if (txt_read[i] == '<' && (txt_read[i + 1] == '/'))
                {
                    c += txt_read[i];
                    j--;
                    continue;
                }
                else if (txt_read[i] == '>')
                {
                   
                    if (i == txt_read.Length - 1)
                    {
                        c += txt_read[i];
                        break;
                    }
                    else if ((txt_read[i + 1] == '<') && (txt_read[i + 2] == '/'))
                    {

                        c += txt_read[i];
                        var str = new string(' ', 2 * j);
                        c += "\n" + str;
                        continue;
                        j--;
                    }
                    else if ((txt_read[i + 1] == '<'))
                    {
                        c += txt_read[i];
                        continue;
                    }
                    else if (txt_read[i + 1] == '\r')
                    {
                        c += txt_read[i];
                        continue;
                    }
                    
                }

                else
                {

                    c += txt_read[i];
                }

            }
            output_txt.Text = c;
            txtArea.Update();

        }

        private void ToJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xml_text = txtArea.Text;
            //string xml_text = System.IO.File.ReadAllText(@"../../data.xml");
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

            //this for loop's function is to add anything between "<" & ">" to a queue called xml_queue 
            //O(n)
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
            //this do all the work :)
            for (int j = 0; xml_queue.Count != 0; j++)
            {
                cnt = 0;
                start_index = 0;
                end_index = 1;
                ind_flag = false;
                txt = false;
                //get each element in the queue then dequeue it
                front_element = xml_queue.Peek().ToString();
                xml_queue.Dequeue();
                // after each iteration it adds the json_text into file 
                for (int k = end_index; end_index < front_element.Length - 1; k++)
                {
                    if (front_element.Substring(0, 1) == "$" && front_element.Substring(0, 4) == "$txt")
                    {
                        // any tag with no attribute
                        if (noattr)
                        {
                            inddex = index;
                            olddind = inddex;
                            txt = true;
                            if (tag_flag)
                            {
                                dot = json_text.Substring(olddind).IndexOf(':') + olddind;
                                json_text = json_text.Remove(dot + 1, 2);

                            }
                            noattr = false;
                            if (json_text[json_text.Length - 1] != '\t' && noattr)
                            {
                                if (json_text[json_text.Length - 1] == '\n' && json_text[json_text.Length - 2] == '{' && tag_flag)
                                {
                                    json_text += json_text.Substring(json_text.Length - 4).Replace("{\n", " ");
                                    json_text += indentation;
                                }
                                else
                                {
                                    json_text += indentation + "\"#text\":";
                                }
                            }
                            else if (json_text[json_text.Length - 1] != '\t')
                            {
                                json_text += indentation;
                            }

                            inddex = json_text.Length - 1;

                            json_text += "\"" + front_element.Substring(4) + "\"";
                            if (json_text[json_text.Length - 1] == '\n')
                            {
                                json_text = json_text.Substring(json_text.Length - 1).Remove(0);
                            }
                            break;
                        }


                        if (ind_flag || (json_text.Substring(json_text.Length - 1) == "\t"))
                        {

                            json_text += "\"#text\":";
                            ind_flag = false;
                        }
                        else
                        {
                            json_text += indentation + "\"#text\":";
                        }

                        txt_element = front_element.Insert(4, "\"");
                        txt_element = txt_element.Insert(front_element.Length + 1, "\"");
                        json_text += txt_element.Substring(4);
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
                        if (index != 0 && tag_flag)
                        {
                            if (json_text[oldind + 1] == ']')
                                json_text = json_text.Remove(oldind, 1);

                            json_text = json_text.Remove(index, 1);
                            if (json_text.Substring(oldind, 1) == ",")
                                json_text = json_text.Remove(oldind, 2 + indentation.Length);
                        }

                        index = json_text.Length;
                        if (tag_flag)
                            json_text += "],\n" + indentation;
                        if (noattr)
                        {
                            endinddex = index;
                            endolddind = olddind;
                            endolddind = inddex;
                            int ind = json_text.Substring(endolddind).Substring(3).IndexOf('"') + endolddind + 3;
                            json_text = json_text.Remove(ind + 4);
                            json_text += indentation;
                            endolddind += json_text.Substring(endolddind).IndexOf('}');
                            endinddex = json_text.Length - 1;
                            break;
                        }
                        break;
                    }
                    else
                    {
                        // the tag element i.e: the first part between "<" ">" splited by space
                        if (cnt == 0)
                        {
                            //if element start with "?" this will not be add to json 

                            if (front_element.Substring(0, 1).Contains("?"))
                            {
                                break;
                            }
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
                        // all attributes are splitted here
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
                            //the attribute is splitted into two parts one for the name and contain "=" and other for the value
                            if (txt_element.Contains('='))
                            {

                                eq_index = txt_element.Substring(0).IndexOf('=');
                                txt_element = txt_element.Replace("=", ":");
                                txt_element = txt_element.Insert(eq_index, "\"");
                                txt_element = txt_element.Insert(0, "\"@");

                            }

                            json_text += txt_element;
                            //only add this if it's the end of the attribute
                            if (cnt % 2 == 0)
                            {
                                json_text += ",\n";
                            }
                            cnt++;

                        }
                    }

                }
                //closing brackets at the end
                if (xml_queue.Count == 1)
                {
                    if (json_text[json_text.Length - indentation.Length - 3] == ']')
                    {
                        json_text = json_text.Remove(json_text.Length - indentation.Length - 3);
                    }
                    json_text += "}";
                }
            }
            output_txt.Text = json_text;
        }

        private void fileSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String txt_read = txtArea.Text;
            string Replace1 = "(?!>\\s+</)(>\\s+<)";
            txt_read = txt_read.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            txt_read = Regex.Replace(txt_read, Replace1, "><");
            txt_read = txt_read.Replace(Environment.NewLine, string.Empty);

            output_txt.Text= txt_read;
        
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as..";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                txtoutput.Write(output_txt.Text);
                txtoutput.Close();
            }
        }

      public static string Decompress(List<int> compressed)
        { 
              // build the dictionary
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(i, ((char)i).ToString());

            string w = dictionary[compressed[0]];
            compressed.RemoveAt(0);
            StringBuilder decompressed = new StringBuilder(w);

            foreach (int k in compressed)
            {
                string entry = null;
                if (dictionary.ContainsKey(k))
                    entry = dictionary[k];
                else if (k == dictionary.Count)
                    entry = w + w[0];

                decompressed.Append(entry);

                // new sequence; add it to the dictionary
                dictionary.Add(dictionary.Count, w + entry[0]);

                w = entry;
            }

            return decompressed.ToString();

         }


      public static List<int> Compress(string to_compress)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < 256; i++)
            {
                dic.Add(((char)i).ToString(), i);
            }
            string st_1 = string.Empty;
            List<int> comp = new List<int>();

            foreach (char st_2 in to_compress)
            {
                string st_3 = st_1 + st_2;
                if (dic.ContainsKey(st_3))
                {
                    st_1 = st_3;
                }
                else
                {
                    comp.Add(dic[st_1]);
                    dic.Add(st_3, dic.Count);
                    st_1 = st_2.ToString();
                }
            }
            if (!string.IsNullOrEmpty(st_1))
                comp.Add(dic[st_1]);
                 return comp;
        }

      
        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("If want compress Input File: press Yes\n If want compress Output File: press No","Purchase Software", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                List<int> compressed = Compress(txtArea.Text);
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Title = "Save file as..";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                    txtoutput.Write(compressed);
                    txtoutput.Close();
                    string decompressed = Decompress(compressed);
                    output_txt.Text = decompressed;
                }
               
                
            }
            else
            {
                List<int> compressed = Compress(output_txt.Text);
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Title = "Save file as..";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                    txtoutput.Write(compressed);
                    txtoutput.Close();
                    string decompressed = Decompress(compressed);
                    txtArea.Text = decompressed;
                }
                
            }
            

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            String txt_read = txtArea.Text;
            List<string> array = new List<string>();
            List<string> arr = new List<string>();
            Stack<string> collector = new Stack<string>();
            for (int i = 0; i < txt_read.Length; i++)
            {
                if (i != 0)
                {
                    if ((txt_read[i] == '\r') || (txt_read[i] == '\n') || ((txt_read[i - 1] == '\n') && (txt_read[i] == ' ')) || ((txt_read[i - 1] == ' ') && (txt_read[i] == ' ')))
                    {
                        continue;
                    }
                }
                if (txt_read[i] != '>')
                {
                    s += txt_read[i];
                    if ((s[0] != '<') && (txt_read[i] == '<'))
                    {
                        s = s.Substring(0, s.Length - 1);
                        array.Add(s);
                        if (i != txt_read.Length - 1)
                        {
                            if (txt_read[i + 1] != '/')
                            {
                                array.Add("</" + collector.Peek());
                                collector.Pop();
                            }
                        }
                        s = "";
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
                                if ((s[0] == '<') && (s[o] == ' ') && (s[1] != '/') && (s[s.Length - 1] != '/'))
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
                            if ((flag == true) && (s[s.Length - 1] != '/'))
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
            output_txt.Text = klh;
        }

        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtArea_Load(object sender, EventArgs e)
        {

        }
        
       
    }
}
