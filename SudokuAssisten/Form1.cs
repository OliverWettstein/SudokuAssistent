using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace sudoku_assistent_002
{
    public partial class Form1 : Form
    {
        List<TextBox> textBoxListe = new List<TextBox>();
        List<Boolean> boollist = new List<Boolean>();
        List<String> stringlist = new List<String>();
        public Form1()
        {
            InitializeComponent();
            checkHomeFolder();
        }

        public void Autofill(TextBox box)
        {
            int[] possibles = Get_Possibles(box);
            string temp = "";
            for (int i = 0; i < 10; i++)
            {
                if (possibles[i] != 0)
                {
                    temp = temp + Convert.ToString(possibles[i]);
                }
            }
            if (temp.Length == 1 && box.Text == "")
            {
                box.Text = temp;
            }
        }

        public void TwoPossibles(TextBox box, int count)
        {
            int[] possibles = Get_Possibles(box);
            string temp = "";
            for (int i = 0; i < 10; i++)
            {
                if (possibles[i] != 0)
                {
                    temp = temp + Convert.ToString(possibles[i]);
                }
            }
            if (temp.Length == 2 && box.Text == "")
            {
                stringlist[count] = "y";
            }
        }

        public void Show_popup(TextBox box)
        {
            int[] possibles = Get_Possibles(box);
            //get every char from possibles if its not 0
            //set position of the popup-window
            label1.Left = box.Left + box.Width + 1;
            label1.Top = box.Top + 3;
            string labeltext = "";
            int pos = 0;
            int temppos = 0;
            for (int i = 0; i < 10; i++)
            {
                if (possibles[i] != 0)
                {
                    labeltext += possibles[i] + "; ";
                    pos++;
                    temppos = possibles[i];
                }
            }

            //write labeltext in label
            label1.Text = labeltext;
            for (int i = 0; i < 10; i++)
            {
                possibles[i] = i;
            }
            //show the label
            if (textBoxListe[last_focused_box].Text != "")
            {
                Hide_popup();
            }
            else
            {
                label1.Show();
            }
        }

        public int[] Get_Possibles(TextBox box)
        {
            //possible numbers that can fit in the textbox
            int[] possibles = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //get the current values
            int n;
            //check possibilities
            if (int.TryParse(box.Text, out n) && box.Text != "0" || box.Text == "")
            {
                //goes through every textbox
                for (int o = 0; o < 81; o++)
                {
                    TextBox textbox = textBoxListe[o];
                    for (int a = 1; a < 4; a++)
                    {
                        possibles = Check_textbox(textbox, Convert.ToString(box.Name[a]), a, possibles, o);
                    }
                }
            }
            else
            {
                boollist[last_focused_box] = false;
            }
            return possibles;
        }

        public int[] Check_textbox(TextBox textbox, string type, int num, int[] possibles, int o)
        {
            //check if textbox_check is in the same column, line or box as the current textbox
            if (Convert.ToString(textbox.Name[num]) == type && textbox.Text != "")
            {
                //check if the input is incorrect
                if (textbox.TextLength > 1)
                {
                    boollist[o] = false;
                }
                else if (textbox.TextLength == 1)
                {
                    //set the value to 0 when the same value is found in textbox
                    possibles[Convert.ToInt32(textbox.Text)] = 0;
                    boollist[o] = true;
                    Check_input(possibles, textBoxListe[last_focused_box]);
                }

            }
            return possibles;
        }

        public void Check_input(int[] possibles, TextBox current_box)
        {
            for (int i = 1; i < 4; i++)
            {
                foreach (TextBox textbox in textBoxListe)
                {
                    if (textbox.Name[i] == current_box.Name[i] && textbox.Text == current_box.Text && textbox.Name != current_box.Name)
                    {
                        for (int a = 0; a < 81; a++)
                        {
                            if (textBoxListe[a].Name == current_box.Name)
                            {
                                boollist[a] = false;
                            }
                        }
                    }
                }
            }
        }

        public void Hide_popup()
        {
            label1.Hide();
        }

        Random rand = new Random();
        public void Generate()
        {
            rand.Next(17, 23);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 81; i++)
            {
                bool b = new Boolean();
                b = true;
                boollist.Add(b);

                string s = "x";
                stringlist.Add(s);
            }

            //generate 9 x 9 textboxes
            int box = 0;
            //9 lines of textboxes
            for (int count = 0; count < 9; count++)
            {
                //y coordinate of the texbox
                int y = 70 + 28 * count;
                //9 columns with textboxes
                for (int i = 0; i < 9; i++)
                {
                    //generate textbox
                    TextBox tb = new TextBox();
                    //x coordinate of the texbox
                    int x = 180 + 31 * i;
                    tb.Location = new Point(x, y);
                    tb.Width = 24;

                    //assign name of the 3 x 3 boxes
                    //revise!
                    if (count < 3 && i < 3) { box = 0; }
                    else if (count < 6 && i < 3) { box = 1; }
                    else if (count < 9 && i < 3) { box = 2; }
                    else if (count < 3 && i < 6) { box = 3; }
                    else if (count < 6 && i < 6) { box = 4; }
                    else if (count < 9 && i < 6) { box = 5; }
                    else if (count < 3 && i < 9) { box = 6; }
                    else if (count < 6 && i < 9) { box = 7; }
                    else if (count < 9 && i < 9) { box = 8; }

                    //assign name, add to list and window
                    tb.Name = "f" + box + count + i;
                    tb.TextAlign = HorizontalAlignment.Center;
                    textBoxListe.Add(tb);
                    this.Controls.Add(tb);
                }
            }
            //set focus on no objekt
            this.ActiveControl = null;
        }

        int last_last_focused_box = 0;
        int last_focused_box = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = 0;
            bool error = false;
            foreach (TextBox textbox in textBoxListe)
            {
                Autofill(textbox);
                TwoPossibles(textbox, count);
                if (textbox.Text != "")
                {
                    stringlist[count] = "x";
                }
                if (textbox.BackColor == Color.Red)
                {
                    error = true;
                    break;
                }
                else
                {
                    error = false;
                }
                count++;
            }
            if (error == true)
            {
                foreach (TextBox textbox in textBoxListe)
                {
                    if (textbox.BackColor == Color.LightGreen || textbox.BackColor == Color.White)
                    {
                        textbox.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (TextBox textbox in textBoxListe)
                {
                    if (textbox.BackColor == Color.LightGreen || textbox.BackColor == Color.White)
                    {
                        textbox.Enabled = true;
                    }
                }
            }


            //draw helplines
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            g.DrawLine(pen, 270, 60, 270, 324);
            g.DrawLine(pen, 362, 60, 362, 324);
            g.DrawLine(pen, 167, 150, 462, 150);
            g.DrawLine(pen, 167, 233, 462, 233);

            //check if any textbox contains focus and then shows the popup
            for (int i = 0; i < 81; i++)
            {
                if (textBoxListe[i].ContainsFocus == true)
                {
                    last_last_focused_box = last_focused_box;
                    last_focused_box = i;
                    Show_popup(textBoxListe[i]);
                }


                if (boollist[i] == false)
                {
                    textBoxListe[i].BackColor = Color.Red;
                }
                if (boollist[i] == true && textBoxListe[i].Enabled == true)
                {
                    textBoxListe[i].BackColor = Color.LightGreen;
                }
                if (stringlist[i] == "y" && textBoxListe[i].Enabled == true)
                {
                    textBoxListe[i].BackColor = Color.Yellow;
                }
                //check if textbox is empty and then change color
                if (textBoxListe[i].Text == "" && stringlist[i] != "y")
                {
                    textBoxListe[i].BackColor = Color.White;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int temp = 0;
            //disabel the textboxes with a value to save a pattern
            foreach (TextBox box in textBoxListe)
            {
                if (box.Text != "" && box.BackColor != Color.Red)
                {
                    box.Enabled = false;
                    box.BackColor = Color.FromArgb(237, 237, 237);
                    box.Font = new Font(box.Font, FontStyle.Bold);
                    button1.Visible = false;
                }
                temp++;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;

            for (int i = 0; i < 81; i++)
            {
                boollist[i] = true;
            }
            foreach (TextBox box in textBoxListe)
            {
                box.Text = "";
                box.Enabled = true;
                box.BackColor = Color.White;
                box.Font = new Font(box.Font, FontStyle.Regular);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void buttonSpeichern_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SudokuAssistent\\savegames");
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                XmlWriter oXmlWriter = null;
                XmlWriterSettings oXmlWriterSettings = new XmlWriterSettings();

                oXmlWriterSettings.Indent = true;
                oXmlWriterSettings.IndentChars = "  ";
                oXmlWriterSettings.NewLineChars = "\r\n";
                oXmlWriter = XmlWriter.Create(saveFileDialog1.FileName, oXmlWriterSettings);
                oXmlWriter.WriteStartDocument(true);
                oXmlWriter.WriteStartElement("textboxes");
                foreach (TextBox forElement in textBoxListe)
                {
                    TextBox textboxSave = forElement;
                    oXmlWriter.WriteStartElement("textbox");
                    oXmlWriter.WriteAttributeString("enabled", textboxSave.Enabled.ToString());
                    oXmlWriter.WriteAttributeString("color", textboxSave.BackColor.ToArgb().ToString());
                    oXmlWriter.WriteAttributeString("number", textboxSave.Text);
                    oXmlWriter.WriteAttributeString("name", textboxSave.Name);
                    oXmlWriter.WriteEndElement();
                }

                oXmlWriter.WriteStartElement("booleans");
                foreach (bool bools in boollist)
                {
                    bool boolsave = bools;
                    oXmlWriter.WriteStartElement("bool");
                    oXmlWriter.WriteAttributeString("bool", boolsave.ToString());
                    oXmlWriter.WriteEndElement();
                }
                oXmlWriter.WriteEndElement();
                Console.WriteLine("Die XML-Datei wurde geschrieben!");
                oXmlWriter.Close();
                   
                
            }
        }

        private void buttonLaden_Click(object sender, EventArgs e)
        {//Get File
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SudokuAssistent\\savegames");
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //ReadFile
                    XmlReader xmlReader = XmlReader.Create(filePath);
                    boollist.Clear();
                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "textbox"))
                        {
                            Console.WriteLine(xmlReader.GetAttribute("name") + ": " + xmlReader.GetAttribute("number") + ": " + xmlReader.GetAttribute("color") + ": " + xmlReader.GetAttribute("enabled"));
                            TextBox textbox = textBoxListe.Find(x => x.Name == xmlReader.GetAttribute("name"));
                            textbox.Name = xmlReader.GetAttribute("name");
                            textbox.Text = xmlReader.GetAttribute("number");
                            Int32 argb = Convert.ToInt32(xmlReader.GetAttribute("color"));
                            Color color = Color.FromArgb(argb);
                            textbox.BackColor = color;
                            textbox.Enabled = Convert.ToBoolean(xmlReader.GetAttribute("enabled"));
                            if (argb == -7278960)
                            {
                                textbox.Enabled = true;
                            }
                        }
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "bool"))
                        {
                            Console.WriteLine(xmlReader.GetAttribute("bool"));
                            bool boolload = Convert.ToBoolean(xmlReader.GetAttribute("bool"));
                            boollist.Add(boolload);
                        }
                    }
                    xmlReader.Close();
                }
            }
        }

        private void buttonVorlageSpeichern_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SudokuAssistent\\muster");
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                XmlWriter oXmlWriter = null;
                XmlWriterSettings oXmlWriterSettings = new XmlWriterSettings();

                oXmlWriterSettings.Indent = true;
                oXmlWriterSettings.IndentChars = "  ";
                oXmlWriterSettings.NewLineChars = "\r\n";
                oXmlWriter = XmlWriter.Create(saveFileDialog1.FileName, oXmlWriterSettings);
                oXmlWriter.WriteStartDocument(true);
                oXmlWriter.WriteStartElement("textboxes");
                foreach (TextBox forElement in textBoxListe)
                {
                    TextBox textboxSave = forElement;
                    oXmlWriter.WriteStartElement("textbox");
                    oXmlWriter.WriteAttributeString("enabled", textboxSave.Enabled.ToString());
                    oXmlWriter.WriteAttributeString("color", textboxSave.BackColor.ToArgb().ToString());
                    oXmlWriter.WriteAttributeString("number", textboxSave.Text);
                    oXmlWriter.WriteAttributeString("name", textboxSave.Name);
                    oXmlWriter.WriteEndElement();
                }

                oXmlWriter.WriteStartElement("booleans");
                foreach (bool bools in boollist)
                {
                    bool boolsave = bools;
                    oXmlWriter.WriteStartElement("bool");
                    oXmlWriter.WriteAttributeString("bool", boolsave.ToString());
                    oXmlWriter.WriteEndElement();
                }
                oXmlWriter.WriteEndElement();
                Console.WriteLine("Die XML-Datei wurde geschrieben!");
                oXmlWriter.Close();


            }
        }

        private void buttonVorlageLaden_Click(object sender, EventArgs e)
        {
            //Get File
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SudokuAssistent\\muster");
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //ReadFile
                    XmlReader xmlReader = XmlReader.Create(filePath);
                    boollist.Clear();
                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "textbox"))
                        {
                            Console.WriteLine(xmlReader.GetAttribute("name") + ": " + xmlReader.GetAttribute("number") + ": " + xmlReader.GetAttribute("color") + ": " + xmlReader.GetAttribute("enabled"));
                            TextBox textbox = textBoxListe.Find(x => x.Name == xmlReader.GetAttribute("name"));
                            textbox.Name = xmlReader.GetAttribute("name");
                            textbox.Text = xmlReader.GetAttribute("number");
                            Int32 argb = Convert.ToInt32(xmlReader.GetAttribute("color"));
                            Color color = Color.FromArgb(argb);
                            textbox.BackColor = color;
                            textbox.Enabled = Convert.ToBoolean(xmlReader.GetAttribute("enabled"));
                            if (argb == -7278960)
                            {
                                textbox.Enabled = true;
                            }
                        }
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "bool"))
                        {
                            Console.WriteLine(xmlReader.GetAttribute("bool"));
                            bool boolload = Convert.ToBoolean(xmlReader.GetAttribute("bool"));
                            boollist.Add(boolload);
                        }
                    }
                    xmlReader.Close();
                }
            }
        }

        private void checkHomeFolder()
        {
            string currentDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SudokuAssistent");
            if (Directory.Exists(currentDirectoryPath))
            {
                Console.WriteLine($"Directory {currentDirectoryPath} exists!");
            }
            else
            {
                Console.WriteLine($"Directory {currentDirectoryPath} does not exist!");
                System.IO.Directory.CreateDirectory(currentDirectoryPath);
                System.IO.Directory.CreateDirectory(Path.Combine(currentDirectoryPath, "savegames"));
                System.IO.Directory.CreateDirectory(Path.Combine(currentDirectoryPath, "muster"));


                string musterVorlagenPath = Path.Combine(Directory.GetCurrentDirectory(), "muster");
                string fileName = "";
                string destFile = "";
                string[] files = System.IO.Directory.GetFiles(musterVorlagenPath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(Path.Combine(currentDirectoryPath, "muster"), fileName);
                    System.IO.File.Copy(s, destFile);
                }
                Console.WriteLine($"Directory {currentDirectoryPath} created!");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Schnellspeichern





        }
    }
}
    
