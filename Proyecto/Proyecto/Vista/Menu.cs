using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Menu : Form
    {
        private UserControl current = null;
        private Juego ca;
        public Menu()
        {
            InitializeComponent();
            current=new UserControl();
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

        private void button1_Click(object sender, EventArgs e)//Inicia el juego
        {
            Juego j= new Juego();
            j.Show();
            
        }
    
        private void button3_Click(object sender, EventArgs e)//Cierra la aplicacion de manera correcta cerrando todos los procesos.
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e) //Boton Score, 
        {
            
            
            button3.Hide();
            button1.Hide();
            button2.Hide();
            current = new UsuarioJuego();
            Controls.Add(current);
            
            
        }
    }
}
  