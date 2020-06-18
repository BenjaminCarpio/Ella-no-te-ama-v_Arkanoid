using System;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Controlador;
using Proyecto.Modelo;
using Proyecto.Properties;

namespace Proyecto
{
    public partial class UsuarioJuego : UserControl
    {
        public delegate void OnClosedWindow();
        public OnClosedWindow CloseAction;
        public UsuarioJuego()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.BackgroundImage=Image.FromFile("../../../Sprites/tutorial.gif");

            throw new System.NotImplementedException();
        }

        private void UsuarioJuego_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            labTop10.BackColor = Color.FromArgb(125, labTop10.BackColor);
            labPlayers.BackColor = Color.FromArgb(125, labTop10.BackColor);
            labScore.BackColor = Color.FromArgb(125, labTop10.BackColor);
        }
       private void BestPlayer()
        {
            labPlayers.Text = "\n  Players\n";
            labScore.Text = "\nScore\n";
            
            var PlayerList = RegistDAO.getNickName();
            var ScoreList = RegistDAO.getScore();
            
            for (int i = 0; i < PlayerList.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        labPlayers.Text += $"{i + 1}" + PlayerList[i] + "\n";
                        break;
                    case 9:labPlayers.Text += $"{i + 1}" + PlayerList[i] + "\n";
                            break;
                    default: labPlayers.Text += $"{i + 1}  " + PlayerList[i] + "\n";
                        break;
                }
                labScore.Text += ScoreList[i] + "\n";
            }
        }
    
        private void btnback_Click(object sender, EventArgs e)
        {
            Menu ventana = new Menu();
            lbltop10.Hide();
            ventana.Show();
        }
    }
}