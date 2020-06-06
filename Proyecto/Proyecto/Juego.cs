using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Modelo;

namespace Proyecto
{
    public partial class Juego : Form
    {
        private CustomBlocks[,] cpb;
        private PictureBox Ball;
        public Juego()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
        
        private void Juego_Load(object sender, EventArgs e)
        {
            player.BackgroundImage = Image.FromFile("../../../Sprites/Player.png");
            player.BackgroundImageLayout = ImageLayout.Stretch;
            player.Top = (Height - player.Height) - 80;
            player.Left = (Width / 2) - (player.Width / 2);
            Ball =new PictureBox();
            Ball.Width = Ball.Height = 20;
            Ball.BackgroundImage= Image.FromFile("../../../Sprites/Ball.png");
            Ball.BackgroundImageLayout = ImageLayout.Stretch;
            Ball.Top = player.Top - Ball.Height;
            Ball.Left = player.Left + (player.Width / 2)- (Ball.Width / 2);
            Controls.Add(Ball);
            SlabsCustoms();
            gameTimer.Start();
        }

        private void SlabsCustoms()
        {
            int xAxis = 10;
            int yAxis = 5;

            int pbHeight = (int) (Height * 0.3) / yAxis;
            int pbWidth = (Width-(xAxis - 5)) / xAxis;
            
            cpb = new CustomBlocks[yAxis,xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i,j]=new CustomBlocks();

                    if (i == 0)
                        cpb[i, j].Hits = 2;
                    else
                        cpb[i, j].Hits = 1;

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;
                    
                    cpb[i,j].BackgroundImage=Image.FromFile("../../../Sprites/" + GR() + ".png");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tiletag";
                    
                    Controls.Add(cpb[i,j]);
                }
            }
        }

        private int GR()
        {
            return  new Random().Next(1,8);
        }

        private void Juego_MouseMove(object sender, MouseEventArgs e)
        {
            if(!DatosJuego.juegoIniciado)
            {
                if (e.X < (Width - player.Width))
                {
                    player.Left = e.X;
                    Ball.Left = player.Left + (player.Width / 2)- (Ball.Width / 2);
                }
            }
            else
            {
                if(e.X < (Width -player.Width))
                    player.Left = e.X;
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!DatosJuego.juegoIniciado)
                return;
            Ball.Left += DatosJuego.dirX;
            Ball.Top += DatosJuego.dirY;
            
            rebotarPelota();
        }

        private void Juego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                DatosJuego.juegoIniciado = true;
        }

        private void rebotarPelota()
        {
            if(Ball.Bottom > Height)
                Application.Exit();
            if (Ball.Left < 0 || Ball.Right > Width)
            {
                DatosJuego.dirX = -DatosJuego.dirX;
                    return;
            }

            if (Ball.Bounds.IntersectsWith(player.Bounds))
            {
                DatosJuego.dirY = -DatosJuego.dirY;
            }

            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        cpb[i, j].Hits--;
                        
                        if(cpb[i,j].Hits == 0)
                            Controls.Remove(cpb[i,j]);
                        
                        DatosJuego.dirY = -DatosJuego.dirY;
                    }
                }
            }
        }
    }
}