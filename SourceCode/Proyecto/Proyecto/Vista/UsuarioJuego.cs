using System;
using System.Drawing;
using System.Linq;
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
        private Label[,] players;
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
            LoadTop10();
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            //LoadTop10();
        }

        private void LoadTop10()
        {
            try
            {
                var toplist = RegistDAO.getScore();

                Nick1lbl.Text = toplist[0].nickname;
                label1sc.Text = toplist[0].score.ToString();

                Nick2lbl.Text = toplist[1].nickname;
                label2sc.Text = toplist[1].score.ToString();

                Nick3lbl.Text = toplist[2].nickname;
                label3sc.Text = toplist[2].score.ToString();

                Nick4lbl.Text = toplist[3].nickname;
                label4sc.Text = toplist[3].score.ToString();

                Nick5lbl.Text = toplist[4].nickname;
                label5sc.Text = toplist[4].score.ToString();

                Nick6lbl.Text = toplist[5].nickname;
                label6sc.Text = toplist[5].score.ToString();

                Nick7lbl.Text = toplist[6].nickname;
                label7sc.Text = toplist[6].score.ToString();

                Nick8lbl.Text = toplist[7].nickname;
                label8sc.Text = toplist[7].score.ToString();

                Nick9lbl.Text = toplist[8].nickname;
                label9sc.Text = toplist[8].score.ToString();

                Nick10lbl.Text = toplist[9].nickname;
                label10sc.Text = toplist[9].score.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show("El top 10 está incompleto, rellenando campos vacios con NULL");
            }
            
        }

        private void btnback_Click(object sender, EventArgs e)
        {
             Form temp = this.FindForm(); //Este form temporal es para evitar el error que al regresar al menu desde el puntaje
                                        //se duplicaba entonces se iguala el temporal al form actual y se cierra con todos sus procesos
             temp.Close();
             temp.Dispose();
             //((Form)this.TopLevelControl).Close();    //esta es otra manera de solucionar el problema anterior mencionado
            
            Menu ventana = new Menu();
            ventana.playername = Usuario.GlobalNickname;
            ventana.Show();
            lbltop10.Hide();
        }
    }
}