using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using DAO;


namespace sgc.processos
{
    public partial class andamentosForm : Form
    {
        private escrituraForm formEscritura;
        private EscrituraBLL escrituraBLL;

        public andamentosForm(escrituraForm _escrituraForm)
        {
            formEscritura = _escrituraForm;
            Conexao con = new Conexao(Dados.strConexao);
            escrituraBLL = new EscrituraBLL(con);
            InitializeComponent();
        }

        public void carregaAndamentos()
        {
            gridAndamento.DataSource = escrituraBLL.listaAndamento(formEscritura.Escritura.IdEscritura);
            gridAndamento.Columns[0].HeaderText = "COD.";
            gridAndamento.Columns[0].Width = 60;
            gridAndamento.Columns[1].HeaderText = "DESCRIÇÃO";
            gridAndamento.Columns[1].Width = 380;
            gridAndamento.Columns[2].HeaderText = "DATA";
            gridAndamento.Columns[2].Width = 100;
            gridAndamento.Columns[3].HeaderText = "VALOR";
            gridAndamento.Columns[3].Width = 100;
            gridAndamento.Columns[3].DefaultCellStyle.Format = "c";
            gridAndamento.Columns[4].HeaderText = "USUÁRIO";
            gridAndamento.Columns[4].Width = 100;

        }

        private void andamentosForm_Load(object sender, EventArgs e)
        {
            carregaAndamentos();
            lbFicha.Text = formEscritura.Escritura.IdEscritura.ToString();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Andamento andamento = new Andamento();

                if (txAndamento.Text.Equals(""))
                {
                    MessageBox.Show("Campo Obrigatorio: descrição");
                    txAndamento.Focus();
                    return;
                }

                andamento.IdEscritura = formEscritura.Escritura.IdEscritura;
                andamento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                andamento.DtAndamento = dtAndamento.Value;
                if (!txVlAndamento.Text.Equals(""))
                    andamento.VlAndamento = Convert.ToDouble(txVlAndamento.Text);
                else
                    andamento.VlAndamento = 0;
                
                andamento.DsAndamento = txAndamento.Text;
                escrituraBLL.addAndamento(andamento);
                MessageBox.Show("Andamento Gravado!");
                formEscritura.carregaTodosDados();
                carregaAndamentos();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar Andamento!\n" + ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                escrituraBLL.delAndamento(Convert.ToInt32(gridAndamento[0, gridAndamento.CurrentRow.Index].Value.ToString()));
                MessageBox.Show("Andamento Apagado!");
                carregaAndamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar Andamento!\n" + ex.Message);
            }
        }

        private void txVlAndamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

    }
}
