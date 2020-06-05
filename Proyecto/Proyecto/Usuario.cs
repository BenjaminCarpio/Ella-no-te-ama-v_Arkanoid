using System;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu m= new Menu();
             m.Show();
            this.Hide();
        }
    }
}