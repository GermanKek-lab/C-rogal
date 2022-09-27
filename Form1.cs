using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        public Player Stas = new Player(30, 30);
        public Enemy Line = new Enemy(40, 40);

        public class Player : PictureBox
        {
            int vsta;
            int shirina;
            public int Hitpoint;

            public Player (int vsta, int shirina)
            {
                this.Height = vsta;
                this.Width = shirina;
                this.BackColor = Color.Blue;
                this.Top = 100;
                this.Left = 100;
                this.Visible = true;
                this.Hitpoint = 10;
                this.BringToFront();
            }

            public void Go_player(KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        this.Top -= 10;
                        break;


                    case Keys.S:
                        this.Top += 10;
                        break;


                    case Keys.A:
                        this.Left -= 10;
                        break;


                    case Keys.D:
                        this.Left += 10;
                        break;
                }
            }


        }

        public class Enemy : PictureBox
        {
            int vsta;
            int shirina;

            public Enemy(int vsta, int shirina)
            {
                this.Height = vsta;
                this.Width = shirina;
                this.BackColor = Color.Red;
                this.Top = 100;
                this.Left = 300;
                this.Visible = true;
                this.BringToFront();
            }

            public bool Stop_player(Player Pl)
            {
                return ((this.Location.Y - this.Height > Pl.Location.Y - 10) 
                    || (this.Location.Y + this.Height < Pl.Location.Y) 
                    || (this.Location.X - this.Width > Pl.Location.X - 10)
                    || (this.Location.X + this.Width < Pl.Location.X));
            }

        }


        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            Controls.Add(Stas);
            Controls.Add(Line);

        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Line.Stop_player(Stas))
            {
                Stas.Go_player(e);
            }
            else
            {
                if (Line.Location.Y - Line.Height >= Stas.Location.Y - 10)
                {
                    Stas.Top -= 10;
                    Stas.Hitpoint -= 1;
                }
                else if (Line.Location.Y + Line.Height <= Stas.Location.Y)
                {
                    Stas.Top += 10;
                    Stas.Hitpoint -= 1;
                }
                else if (Line.Location.X - Line.Width >= Stas.Location.X - 10)
                {
                    Stas.Left -= 10;
                    Stas.Hitpoint -= 1;
                }
                else if (Line.Location.X + Line.Width <= Stas.Location.X)
                {
                    Stas.Left += 10;
                    Stas.Hitpoint -= 1;
                }

                if (Stas.Hitpoint <= 0)
                {
                    Stas.Hitpoint = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Stas.Hitpoint.ToString();
        }
    }
}
