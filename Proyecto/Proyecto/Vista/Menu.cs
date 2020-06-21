using System;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Controlador;
using Proyecto.Modelo;

namespace Proyecto
{
    public partial class Menu : Form
    {
        private UserControl current = null;
        private Juego ca;
        private Player _player;
        
        public Menu()
        {
            InitializeComponent();
            current=new UserControl();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        private void Menu_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)//Inicia el juego
        {
            DatosJuego.InicializarJuego();
            
            ca=new Juego();
            ca.Show();
            
            ca.TerminarJuego = () =>
            {
                MessageBox.Show("Has Perdido :(!"+ "Tu puntaje es: " + DatosJuego.puntajes);
                ca.Hide();
                Menu a = new Menu();
                a.Show();
            };
            
            ca.WinningGame = () =>
            {
                MessageBox.Show("Has ganado!"+ "Tu puntaje es: " + DatosJuego.puntajes);
                ca.Hide();
                Menu a = new Menu();
                a.Show();
            };
            
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
            tableLayoutPanel1.Hide();
            current = new UsuarioJuego();
            Controls.Add(current);
            
            
        }
    }
}
  