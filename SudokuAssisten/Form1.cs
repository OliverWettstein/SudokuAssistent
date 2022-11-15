using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku_assistent_002
{
    public partial class Form1 : Form
    {
        List<TextBox> textBoxListe = new List<TextBox>();
        List<Boolean> boollist = new List<Boolean>();
        public Form1()
        {
            InitializeComponent();
        }

        int[] last_possibles = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public int[] Check_textbox(TextBox textbox, string type, int num, int[] possibles, bool last)
        {
            if (textbox.Text == "" && last == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    last_possibles[i] = possibles[i];
                }
            }
            //check if textbox_check is in the same column, line or box as the current textbox
            if (Convert.ToString(textbox.Name[num]) == type && textbox.Text != "")
            {
                //check if the input is incorrect
                if (textbox.TextLength > 1 || !last_possibles.Contains(Convert.ToInt32(textbox.Text)))
                {
                    textbox.BackColor = Color.Red;
                }
                if (textbox.TextLength == 1 && last_possibles.Contains(Convert.ToInt32(textbox.Text)))
                {
                    //set the value to 0 when the same value is found in textbox
                    possibles[Convert.ToInt32(textbox.Text)] = 0;
                    if (textbox.Enabled)
                    {
                        textbox.BackColor = Color.LightGreen;
                    }
                }


                //check if textbox is empty and then change color
                if (textbox.Text == "")
                {
                    textbox.BackColor = Color.White;
                }
            }
            return possibles;
        }

        public void Show_popup(TextBox box)
        {
            //possible numbers that can fit in the textbox
            int[] possibles = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };



            //set position of the popup-window
            label1.Left = box.Left + box.Width + 1;
            label1.Top = box.Top + 3;

            //get the current values

            char current_block = box.Name[1];
            char current_line = box.Name[2];
            char current_column = box.Name[3];
            int n;
            //check possibilities
            if (int.TryParse(box.Text, out n) || box.Text == "")
            {
                box.BackColor = Color.White;
                //goes through every textbox
                foreach (TextBox textbox in textBoxListe)
                {
                    possibles = Check_textbox(textbox, Convert.ToString(current_block), 1, possibles, true);
                    possibles = Check_textbox(textbox, Convert.ToString(current_line), 2, possibles, false);
                    possibles = Check_textbox(textbox, Convert.ToString(current_column), 3, possibles, false);
                }
            }
            else
            {
                box.BackColor = Color.Red;
            }

            //get every char from possibles if its not 0
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
            label1.Show();
            //Autofill
            if (pos == 1)
            {
                box.Text = Convert.ToString(temppos);
                box.BackColor = Color.Yellow;
            }
        }
        public void Hide_popup()
        {
            this.ActiveControl = null;
            label1.Hide();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //generate 9 x 9 textboxes
            int box = 0;
            //9 lines of textboxes
            for (int count = 0; count < 9; count++)
            {
                //y coordinate of the texbox
                int y = 30 + 28 * count;
                //9 columns with textboxes
                for (int i = 0; i < 9; i++)
                {
                    //generate textbox
                    TextBox tb = new TextBox();
                    //x coordinate of the texbox
                    int x = 84 + 31 * i;
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
                    textBoxListe.Add(tb);
                    this.Controls.Add(tb);
                }
            }
            //set focus on no objekt
            this.ActiveControl = null;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //draw helplines
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            g.DrawLine(pen, 173, 20, 173, 284);
            g.DrawLine(pen, 266, 20, 266, 284);
            g.DrawLine(pen, 68, 110, 370, 110);
            g.DrawLine(pen, 68, 193, 370, 193);

            //check if any textbox contains focus and then shows the popup
            for (int i = 0; i < 81; i++)
            {
                if (textBoxListe[i].ContainsFocus == true)
                {
                    if (textBoxListe[i].TextLength != 1)
                    {
                        Show_popup(textBoxListe[i]);
                    }

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //disabel the textboxes with a value to save a pattern
            foreach (TextBox box in textBoxListe)
            {
                if (box.Text != "")
                {
                    box.BackColor = Color.DarkGray;
                    box.ReadOnly = true; //test
                    button1.Visible = false;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Hide_popup();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //enable the textboxes and clear them
            foreach (TextBox box in textBoxListe)
            {
                box.Text = "";
                box.BackColor = Color.White;
                box.Enabled = true;
                button1.Visible = true;
            }
        }

        private void hans_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 81; i++)
            {
                if (textBoxListe[i].TextLength != 1)
                {
                    Show_popup(textBoxListe[i]);
                    Hide_popup();
                }
                
            }
                
        }
    }
}
