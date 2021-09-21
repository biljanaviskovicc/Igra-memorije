using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Igra_memorije_Diplomski_rad_Biljana_Viskovic
{
    public partial class Form1 : Form
    {
        Stopwatch vreme;

        Random random = new Random();
        List<string> ikone = new List<string>()
        {
            "Y", "Y","b","b","L","L","Z","Z",
            "l","l","%","%","j","j","!","!"
        };

        Label prvoKliknuto, drugoKliknuto;


       
        

        bool start;
        

        public Form1()
        {
            InitializeComponent();
            postavljanjeIkona();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (start == true)
            {
               

                if (prvoKliknuto != null && drugoKliknuto != null)
                    return;

                Label clickedLabel = sender as Label;

                if (clickedLabel == null)
                    return;

                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (prvoKliknuto == null)
                {
                    prvoKliknuto = clickedLabel;
                    prvoKliknuto.ForeColor = Color.Black;
                    return;
                }

                drugoKliknuto = clickedLabel;
                drugoKliknuto.ForeColor = Color.Black;

                krajIgre();

                if (prvoKliknuto.Text == drugoKliknuto.Text)
                {
                    prvoKliknuto = null;
                    drugoKliknuto = null;
                }
                else
                    timer1.Start();

                
            }
            else
            {
                MessageBox.Show("Morate pokrenuti igru!");
            }
        }

        private void krajIgre()
        {
            Label label;

            for(int i=0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                {
                    
                    return;
                }
                vreme.Stop();
            }
            
            MessageBox.Show("Pobeda! Vreme koje vam je bilo potrebno: "+lblVreme.Text);
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            prvoKliknuto.ForeColor = prvoKliknuto.BackColor;
            drugoKliknuto.ForeColor = drugoKliknuto.BackColor;

            prvoKliknuto = null;
            drugoKliknuto = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblVreme.Text = string.Format("{0:mm\\:ss}", vreme.Elapsed);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            start = true;
            //timer2.Start();
            vreme.Start();
        }

      

      

        private void Form1_Load(object sender, EventArgs e)
        {
            vreme = new Stopwatch();
        }

        private void postavljanjeIkona()
        {
            Label label;
            int randomNumber;

            for(int i=0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, ikone.Count);
                label.Text = ikone[randomNumber];

                ikone.RemoveAt(randomNumber);

            
            }
        }


    }
}
