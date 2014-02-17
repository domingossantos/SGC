using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc
{
    public partial class formModelo : Form
    {
        public formModelo()
        {
            InitializeComponent();
        }

        private void formModelo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnNovo.PerformClick();
                    break;
                case Keys.F3:
                    btnSalvar.PerformClick();
                    break;
                case Keys.F4:
                    btnPesquisar.PerformClick();
                    break;
                case Keys.F5:
                    btnApagar.PerformClick();
                    break;
                case Keys.F6:
                    btnCancelar.PerformClick();
                    break;
                case Keys.F7:
                    btnRelatorio.PerformClick();
                    break;
                case Keys.F10:
                    DialogResult result = MessageBox.Show("Deseja fechar esta janela", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result.ToString().Equals("Yes"))
                        this.Close();
                    break;
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
                default:
                    break;
            }
        }
    }
}
