using System;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Controlador;
using Proyecto.Modelo;

namespace Proyecto
{
    public partial class Usuario : Form
    {
        public static string GlobalNickname;
        public Usuario()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            pictureBox1.Image = Image.FromFile("../../../Sprites/tutorial.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
         private void Usuario_Load(object sender, EventArgs e)
                {
                    ActiveControl = txtNickname;
                    
                }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                 if (txtNickname.Text.Equals(""))
                 throw  new EmptyNicknameException("");
                     
                if(txtNickname.Text.Length > 20)
                    throw new NicknameExceedMaxLength("");
                    
                PlayerDAO.insertPlayer(txtNickname.Text); //Se comprueba si existe o no el nickname en la base y se agrega si no existe
                GlobalNickname = txtNickname.Text;
                var ventana = new Menu();
                ventana.playername = txtNickname.Text;
                ventana.Show();
                
                }
                catch (EmptyNicknameException exception)
                {
                    MessageBox.Show("Nose puede dejar Campos Vacios");
                   
                }
                catch (NicknameExceedMaxLength exce){
                MessageBox.Show("Has superado el maximo de caracteres disponible, intente nuevamente con menos de 20 caracteres");
               }
        }

        private void txtNickname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              button1_Click((object)sender, (EventArgs)e);  
            }
        }

        private void Usuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
