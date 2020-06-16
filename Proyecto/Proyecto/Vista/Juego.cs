﻿using System;
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

        private Label vidasRestantes, Puntajes;
        private Panel Score;

        private PictureBox Corazon;
        private PictureBox[] Corazones;

        public Action TerminarJuego;

        public Juego()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            PanelPuntajes();
            player.BackgroundImage = Image.FromFile("../../../Sprites/Player.png");
            player.BackgroundImageLayout = ImageLayout.Stretch;
            player.Top = (Height - player.Height) - 80;
            player.Left = (Width / 2) - (player.Width / 2);
            
            Ball = new PictureBox();
            Ball.Width = Ball.Height = 20;
            Ball.BackgroundImage = Image.FromFile("../../../Sprites/Ball.png");
            Ball.BackgroundImageLayout = ImageLayout.Stretch;
            Ball.Top = player.Top - Ball.Height;
            Ball.Left = player.Left + (player.Width / 2) - (Ball.Width / 2);
            
            Controls.Add(Ball);
            
            SlabsCustoms();
            gameTimer.Start();
        }

        private void SlabsCustoms()
        {
            int xAxis = 10;
            int yAxis = 5;

            int pbHeight = (int) (Height * 0.3) / yAxis;
            int pbWidth = (Width - (xAxis - 5)) / xAxis;

            cpb = new CustomBlocks[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomBlocks();

                    if (i == 0)
                        cpb[i, j].Hits = 2;
                    else
                        cpb[i, j].Hits = 1;

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + Score.Height + 1;
                    
                    cpb[i, j].BackgroundImage = Image.FromFile("../../../Sprites/" + GR() + ".png");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tiletag";

                    Controls.Add(cpb[i, j]);
                }
            }
        }

        private int GR()
        {
            return new Random().Next(1, 8);
        }

        private void Juego_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DatosJuego.juegoIniciado)
            {
                if (e.X < (Width - player.Width))
                {
                    player.Left = e.X;
                    Ball.Left = player.Left + (player.Width / 2) - (Ball.Width / 2);
                }
            }
            else
            {
                if (e.X < (Width - player.Width))
                    player.Left = e.X;
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!DatosJuego.juegoIniciado)
                return;

            DatosJuego.ticksRealizados += 0.1;
            
            Ball.Left += DatosJuego.dirX;
            Ball.Top += DatosJuego.dirY;

            rebotarPelota();
        }

        private void Juego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DatosJuego.juegoIniciado = true;
                gameTimer.Start();
            }
        }

        private void rebotarPelota()
        {
            if (Ball.Top < 0)
                DatosJuego.dirY = -DatosJuego.dirY;

            if (Ball.Bottom > Height)
            {
                DatosJuego.vidas--;
                DatosJuego.juegoIniciado = false;
                gameTimer.Stop();

                ReposicionarElementos();
                ActualizarElementos();

                if (DatosJuego.vidas == 0)
                {
                    gameTimer.Stop();
                    TerminarJuego?.Invoke();
                }

            }

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
                    if (cpb[i, j] != null && Ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        DatosJuego.puntajes += (int) (cpb[i, j].Hits * DatosJuego.ticksRealizados);
                        cpb[i, j].Hits--;

                        if (cpb[i, j].Hits == 0)
                        {
                            Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;
                        }

                        DatosJuego.dirY = -DatosJuego.dirY;

                        Puntajes.Text = DatosJuego.puntajes.ToString();
                        return;
                    }
                }
            }
        }

        private void MoverPelota()
        {
            Ball.Left += DatosJuego.dirX;
            Ball.Top += DatosJuego.dirY;
        }

        private void PanelPuntajes()
        {
            // Instanciar panel
            Score = new Panel();

            // Setear elementos del panel
            Score.Width = Width;
            Score.Height = (int) (Height * 0.07);

            Score.Top = Score.Left = 0;

            Score.BackColor = Color.Black;

            #region Label + PictureBox

            // Instanciar pb
            Corazon = new PictureBox();

            Corazon.Height = Corazon.Width = Score.Height;

            Corazon.Top = 0;
            Corazon.Left = 20;

            Corazon.BackgroundImage = Image.FromFile("../../../Sprites/Heart.png");
            Corazon.BackgroundImageLayout = ImageLayout.Stretch;

            #endregion

            #region N cantidad de PictureBox

            Corazones = new PictureBox[DatosJuego.vidas];

            for (int i = 0; i < DatosJuego.vidas; i++)
            {
                // Instanciacion de pb
                Corazones[i] = new PictureBox();

                Corazones[i].Height = Corazones[i].Width = Score.Height;

                Corazones[i].BackgroundImage = Image.FromFile("../../../Sprites/Heart.png");
                Corazones[i].BackgroundImageLayout = ImageLayout.Stretch;

                Corazones[i].Top = 0;

                if (i == 0)
                    // corazones[i].Left = 20;
                    Corazones[i].Left = Score.Width / 2;
                else
                {
                    Corazones[i].Left = Corazones[i - 1].Right + 5;
                }
            }

            #endregion

            // Instanciar labels
            vidasRestantes = new Label();
            Puntajes = new Label();

            // Setear elementos de los labels
            vidasRestantes.ForeColor = Puntajes.ForeColor = Color.White;

            vidasRestantes.Text = "x " + DatosJuego.vidas.ToString();
            Puntajes.Text = DatosJuego.puntajes.ToString();

            vidasRestantes.Font = Puntajes.Font = new Font("Microsoft YaHei", 24F);
            vidasRestantes.TextAlign = Puntajes.TextAlign = ContentAlignment.MiddleCenter;

            vidasRestantes.Left = Corazon.Right + 5;
            Puntajes.Left = Width - 100;

            vidasRestantes.Height = Puntajes.Height = Score.Height;

            Score.Controls.Add(Corazon);
            Score.Controls.Add(vidasRestantes);
            Score.Controls.Add(Puntajes);

            foreach (var pb in Corazones)
            {
                Score.Controls.Add(pb);
            }

            Controls.Add(Score);
        }

        private void ReposicionarElementos()
        {
            player.Left = (Width / 2) - (player.Width / 2);
            Ball.Top = player.Top - Ball.Height;
            Ball.Left = player.Left + (player.Width / 2) - (Ball.Width / 2);
        }

        private void ActualizarElementos()
        {
            vidasRestantes.Text = "x " + DatosJuego.vidas.ToString();

            Score.Controls.Remove(Corazones[DatosJuego.vidas]);
            Corazones[DatosJuego.vidas] = null;
        }
    }
}