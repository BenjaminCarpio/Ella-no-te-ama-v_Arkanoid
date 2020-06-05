using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Juego : Form
    {
        bool goLeft;
        bool goRight;
        bool isGameOver;
        int score;
        int ballx;
        int bally;
        int playerSpeed;
        Random rnd = new Random();

        public Juego()
        {
            InitializeComponent();
            setupGame();
        }

        private void setupGame()
        {
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            gameTimer.Start();
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string) x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }  
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            
            txtScore.Text = "Score: " + score + "  "+ message;
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if (goRight == true && player.Left < 500)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;
            if (ball.Left < 0 || ball.Left > 550)
            {
                ballx = -ballx; 
            }

            if (ball.Top < 0)
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                bally = rnd.Next(5, 12)*-1;

                if (ballx < 0)
                {
                    ballx = rnd.Next(5,12)*-1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }
            }
            foreach (Control x in this.Controls)
            {
                 if (x is PictureBox && (string) x.Tag == "blocks")
                 {
                     if (ball.Bounds.IntersectsWith(x.Bounds))
                     {
                         score += 1;
                         bally = -bally;
                         this.Controls.Remove(x);
                     }
                 }
            }

            if (score == 15)
            {
                gameOver("HAS GANADO!!");
            }

            if (ball.Top > 516)
            {
               gameOver("HAS PERDIDO!!");
            }
            
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
    }
}