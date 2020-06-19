using System.ComponentModel;

namespace Proyecto
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player.Location = new System.Drawing.Point(280, 419);
            this.player.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(110, 46);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(695, 477);
            this.Controls.Add(this.player);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimizeBox = false;
            this.Name = "Juego";
            this.Text = "Juego";
            this.Load += new System.EventHandler(this.Juego_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Juego_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Juego_MouseMove);
            ((System.ComponentModel.ISupportInitialize) (this.player)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer gameTimer;
    }
}