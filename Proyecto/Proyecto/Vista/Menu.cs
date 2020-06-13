using System;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Start game
        {
            Juego j= new Juego();
            j.Show();
        }

        private void button3_Click(object sender, EventArgs e)//Close Program
        {
            Application.Exit();
        }
    }
}