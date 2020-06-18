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
        }
         private void Usuario_Load(object sender, EventArgs e)
                {
                    ActiveControl = txtNickname;
                }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtNickname.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    //falta hacer ...

                    MessageBox.Show("Usuario Registrado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
    }
}
