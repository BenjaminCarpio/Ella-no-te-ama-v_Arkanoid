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
        public string playername;
        
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
            //La linea de abajo cierra el menu ya que al terminar el juego se vuelve a abrir el menu 
            //y se evita que este se duplique 
            ((Form)this.TopLevelControl).Close();
            DatosJuego.InicializarJuego();
            
            ca=new Juego();
            ca.Show();
            
            ca.TerminarJuego = () =>
            {
                //En caso de desear agregar al registro el puntaje aun cuando se pierde, quitar el comentario de la linea siguiente
                //RegistDAO.insertRegis(playername, DatosJuego.puntajes);
                MessageBox.Show("Has Perdido :(!"+ "Tu puntaje es: " + DatosJuego.puntajes);
                ca.Hide();
                Menu a = new Menu();
                a.playername = Usuario.GlobalNickname;
                a.Show();
            };
            
            ca.WinningGame = () =>
            {
                RegistDAO.insertRegis(playername, DatosJuego.puntajes);
                MessageBox.Show("Has ganado!"+ "Tu puntaje es: " + DatosJuego.puntajes);
                ca.Hide();
                Menu a = new Menu();
                a.playername = Usuario.GlobalNickname;
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
  