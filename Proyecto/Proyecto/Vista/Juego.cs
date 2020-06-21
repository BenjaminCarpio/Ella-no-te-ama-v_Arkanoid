using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Controlador;
using Proyecto.Modelo;

namespace Proyecto
{
    public partial class Juego : Form
    {
        private CustomBlocks[,] cpb;
        private PictureBox Ball;

        private Label vidasRestantes, Puntajes;
        private Panel Score;
        
        private double tiempoTranscurido = 0, tiempoLimite = 4;
        private int remainingPb = 0;

        private PictureBox Corazon;
        private PictureBox[] Corazones;

        public Action TerminarJuego,WinningGame;

        public Juego()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            
        }
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        
        private void Juego_Load(object sender, EventArgs e)
        {
            
            PanelPuntajes();
            BackgroundImage = Image.FromFile("../../../Sprites/fondo.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
            
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
            //gameTimer.Start();
        }

        private void SlabsCustoms()
        {    
            int xAxis = 10;
            int yAxis = 5;
            remainingPb = xAxis * yAxis;

            int pbHeight = (int) (Height * 0.3) / yAxis;
            int pbWidth = (Width - (xAxis - 5)) / xAxis;
    
            cpb = new CustomBlocks[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomBlocks();

                    if (i == 4)
                        cpb[i, j].Hits = 2;
                    else
                        cpb[i, j].Hits = 1;
                    
                    //tamano
                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    
                    //Posicion left  y posicion top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + Score.Height + 1;
                    //cpb[i, j].BackgroundImage = Image.FromFile("../../../Sprites/" + GR() + ".png");
                    
                    
                    int imageBack;
                    if (i % 2 == 1 && j % 2 != 1 )
                        imageBack = 4;
                    else if (i % 2 == 1 && j % 3 != 0)
                        imageBack = 3;
                    else if (i % 2 == 1 && j % 2 != 0)
                        imageBack = 3;
                    else
                        imageBack = 6;
                    
                    if (i == 4)
                    {    
                        cpb[i, j].BackgroundImage = Image.FromFile("../../../Sprites/blinded.png");
                        cpb[i, j].Tag = "blinded";
                    }
                    else
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../../Sprites/" + imageBack + ".png");
                        cpb[i, j].Tag = "tileTag";
                    }

                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    
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
            
            try
            {
                   rebotarPelota(); 
                   DatosJuego.ticksRealizados += 0.01;
                   Ball.Left += DatosJuego.dirX;
                   Ball.Top += DatosJuego.dirY;
            }
            catch (NoBoundExceptio exception)
            {
                try
                {
                    DatosJuego.vidas--;
                    DatosJuego.juegoIniciado = false;
                    gameTimer.Stop();
                    
                    ReposicionarElementos();
                    ActualizarElementos();
                   
                   if(DatosJuego.vidas == 0)
                   {
                       throw new NoMoreLifesException("");
                   }
                }
                catch (NoMoreLifesException e1)
                {
                   gameTimer.Stop();
                   TerminarJuego?.Invoke();
                }
            }
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
            if (Ball.Top < Score.Height)
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
                        if (cpb[i, j] != null && i == 4)
                        {
                            DatosJuego.puntajes += cpb[i, j].Hits;
                            cpb[i, j].Hits--;
                        }else
                        {
                            DatosJuego.puntajes += (int) (cpb[i, j].Hits * DatosJuego.ticksRealizados);
                             cpb[i, j].Hits--;
                        }
                        
                        if (cpb[i, j].Hits == 0)
                        {
                            Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;

                            remainingPb--;    

                        }
                        else if (cpb[i, j].Tag.Equals("blinded"))
                            cpb[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broken.png");

                        DatosJuego.dirY = -DatosJuego.dirY;
                        Puntajes.Text = DatosJuego.puntajes.ToString();

                        if (remainingPb == 0)
                        {
                            DatosJuego.puntajes = DatosJuego.puntajes * DatosJuego.vidas ;
                            WinningGame?.Invoke();
                        }

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
            Puntajes.Left = Width - 150;

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

        private void Juego_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Menu ventana = new Menu();
            ventana.Show();
        }
    }
}
