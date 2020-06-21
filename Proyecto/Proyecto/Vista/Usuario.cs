using System;
using System.Windows.Forms;
using Proyecto.Controlador;
using Proyecto.Modelo;

namespace Proyecto
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
         private void Usuario_Load(object sender, EventArgs e)
                {
                    ActiveControl = txtNickname;
                }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNickname.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                PlayerDAO.insertPlayer(txtNickname.Text); //Se comprueba si existe o no el nickname en la base y se agrega si no existe
                var ventana = new Menu();
                ventana.Show();
                this.Hide();
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
