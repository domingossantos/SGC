using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.assinaturas
{
    public partial class detalheAssinaturaForm : Form
    {
        public detalheAssinaturaForm(Image imgS)
        {
            InitializeComponent();
            img.Image = imgS;
        }

        private void detalheAssinaturaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
                this.Close();

            if (e.KeyCode == Keys.F11)
                btzoomIn_Click(null, null);

            if (e.KeyCode == Keys.F12)
                btZoomOut_Click(null, null);
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btzoomIn_Click(object sender, EventArgs e)
        {
            img.Top = (int)(img.Top - (img.Height * 0.025));
            img.Left = (int)(img.Left - (img.Width * 0.025));
            img.Height = (int)(img.Height + (img.Height * 0.05));
            img.Width = (int)(img.Width + (img.Width * 0.05));
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            img.Top = (int)(img.Top + (img.Height * 0.025));
            img.Left = (int)(img.Left + (img.Width * 0.025));
            img.Height = (int)(img.Height - (img.Height * 0.05));
            img.Width = (int)(img.Width - (img.Width * 0.05));
        }

        

        
    }
}
