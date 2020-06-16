using System;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Menu : Form
    {
        private Juego ca;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load_1(object sender, EventArgs e)
        {
            ca = new Juego();

            ca.Dock = DockStyle.Fill;

            ca.Width = Width;
            ca.Height = Height;

            ca.TerminarJuego = () =>
            {
                ca = null;
                ca = new Juego();

                MessageBox.Show("Has perdido");

                ca.Hide();
                new Menu();
            };
        }

        private void button1_Click(object sender, EventArgs e)//Start game
        {
            Juego j= new Juego();
            j.Show();
            Controls.Add(ca);
        }
    
        private void button3_Click(object sender, EventArgs e)//Close Program
        {
            Application.Exit();
        }
        
        }
    }