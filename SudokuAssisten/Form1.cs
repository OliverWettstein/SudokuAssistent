using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuAssisten
{
    public partial class Form1 : Form
    {
        List<TextBox> textBoxListe = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int box = 0; 
            for (int count = 0; count < 9; count++)
            {
                int x = 100 + 26 * count + 10;
                for (int i = 0; i < 9; i++)
                {
                    TextBox tb = new TextBox();
                    int y = 50 + 26 * i + 10;
                    tb.Location = new Point(x, y);
                    tb.Width = 26;
                    if (count < 3 && i < 3) { box = 0; }
                    if (count < 3 && i < 3) { box = 1; }
                    if (count < 3 && i < 3) { box = 2; }
                    if (count < 3 && i < 3) { box = 3; }
                    if (count < 3 && i < 3) { box = 4; }
                    if (count < 3 && i < 3) { box = 5; }
                    if (count < 3 && i < 3) { box = 6; }
                    if (count < 3 && i < 3) { box = 7; }
                    if (count < 3 && i < 3) { box = 8; }

                    tb.Name = "f"+ box + count + i;
                    textBoxListe.Add(tb);
                    this.Controls.Add(tb);
                }
            }
           
        }
    }
}
