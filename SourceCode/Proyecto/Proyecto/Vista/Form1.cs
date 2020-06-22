using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            pictureBox1.Image = Image.FromFile("../../../Sprites/Start.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}