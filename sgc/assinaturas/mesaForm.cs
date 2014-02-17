using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;
using System.IO;


namespace sgc.assinaturas
{
    public partial class mesaForm : Form
    {
        private Conexao con;
        private AssinaturasBLL assinaturaBLL;
        private Image imgOriginal;
        public mesaForm()
        {
            con = new Conexao(Dados.strConexao);
            assinaturaBLL = new AssinaturasBLL(con);
            InitializeComponent();
        }

        private void mesaForm_Load(object sender, EventArgs e)
        {
            carregaDados();
        }

        private void carregaDados() 
        {
            grid.DataSource = assinaturaBLL.getMesa();

            grid.Columns[0].HeaderText = "FICHA";
            grid.Columns[0].Width = 60;
            grid.Columns[1].HeaderText = "NOME";
            grid.Columns[1].Width = 200;
            grid.Columns[2].HeaderText = "DATA";
            grid.Columns[2].Width = 80;
            grid.Columns[3].HeaderText = "USUARIO";
            grid.Columns[3].Width = 80;
        }

        private void carregaImagem(String cartao)
        {
            if (cartao != "")
            {
                MemoryStream ms;
                byte[] imgByte = null;
                imagem.Image = null;

                //grid[0, grid.CurrentRow.Index].Value.ToString();
                imgByte = assinaturaBLL.getUltimaAssinatura(cartao);
                if (imgByte != null)
                {
                    try
                    {
                        ms = new MemoryStream(imgByte, 0, imgByte.Length);

                        ms.Write(imgByte, 0, imgByte.Length);
                        imagem.Image = Image.FromStream(ms, true);
                        imgOriginal = imagem.Image;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro ao carregar imagem!\n" + e.Message);
                    }
                }
            }
        }

        private void grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            carregaImagem(grid[0, grid.CurrentRow.Index].Value.ToString());
        }

        private void btZoonIn_Click(object sender, EventArgs e)
        {
            imagem.Top = (int)(imagem.Top - (imagem.Height * 0.025));
            imagem.Left = (int)(imagem.Left - (imagem.Width * 0.025));
            imagem.Height = (int)(imagem.Height + (imagem.Height * 0.05));
            imagem.Width = (int)(imagem.Width + (imagem.Width * 0.05));
        }

        private void btZoonOut_Click(object sender, EventArgs e)
        {
            imagem.Top = (int)(imagem.Top + (imagem.Height * 0.025));
            imagem.Left = (int)(imagem.Left + (imagem.Width * 0.025));
            imagem.Height = (int)(imagem.Height - (imagem.Height * 0.05));
            imagem.Width = (int)(imagem.Width - (imagem.Width * 0.05));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            if (!grid[0, grid.CurrentRow.Index].Value.ToString().Equals(""))
            {
                try
                {
                    assinaturaBLL.deletaMesa();
                    imagem.Image = null;
                    MessageBox.Show("Assinaturas apagadas!");
                    carregaDados();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar Mesa" + ex.Message);
                }
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mesaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10) {
                this.Close();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Delete)
            {
                btApagar_Click(null, null);
            }

            if (e.KeyCode == Keys.F11)
            {
                btZoonIn_Click(null, null);
            }

            if (e.KeyCode == Keys.F12)
            {
                btZoonOut_Click(null, null);
            }
        }
    }
}
