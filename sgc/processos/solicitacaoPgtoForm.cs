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
    public partial class solicitacaoPgtoForm : Form
    {
        private Conexao con;
        private EscrituraBLL escrituraBLL;
        public solicitacaoPgtoForm()
        {
            con = new Conexao(Dados.strConexao);
            escrituraBLL = new EscrituraBLL(con);
            InitializeComponent();
        }

        public void carregaSolicitacoes(char status = 'A') {
            gridSocilitacoes.DataSource = escrituraBLL.listaSolicitacao(status);
            gridSocilitacoes.Columns[0].HeaderText = "COD.";
            gridSocilitacoes.Columns[0].Width = 60;
            gridSocilitacoes.Columns[1].HeaderText = "FICHA";
            gridSocilitacoes.Columns[1].Width = 70;
            gridSocilitacoes.Columns[2].HeaderText = "ATO";
            gridSocilitacoes.Columns[2].Width = 280;
            gridSocilitacoes.Columns[3].HeaderText = "VALOR";
            gridSocilitacoes.Columns[3].Width = 180;
            gridSocilitacoes.Columns[3].DefaultCellStyle.Format = "c";
            gridSocilitacoes.Columns[4].HeaderText = "DESCRIÇÃO";
            gridSocilitacoes.Columns[4].Width = 280;
            gridSocilitacoes.Columns[5].HeaderText = "DATA";
            gridSocilitacoes.Columns[5].Width = 100;
            gridSocilitacoes.Columns[6].HeaderText = "USUÁRIO";
            gridSocilitacoes.Columns[6].Width = 100;

            lbValorTotal.Text = String.Format("R$ {0:N2}", utils.formatos.getSomaCampoGrid(gridSocilitacoes, 3));
        }

        private void solicitacaoPgtoForm_Load(object sender, EventArgs e)
        {
            carregaSolicitacoes();
        }

        private void btAtender_Click(object sender, EventArgs e)
        {
            try
            {
                escrituraBLL.alteraStatusMovimento(
                                        Convert.ToInt32(gridSocilitacoes[0, gridSocilitacoes.CurrentRow.Index].Value.ToString()), 
                                        'P');
                carregaSolicitacoes();

                MessageBox.Show("Solicitação Atendida!");
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao atender solicitação\n" + ex.Message);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                escrituraBLL.alteraStatusMovimento(Convert.ToInt32(gridSocilitacoes[0, gridSocilitacoes.CurrentRow.Index].Value.ToString()), 'E');
                carregaSolicitacoes();

                MessageBox.Show("Solicitação Apagada!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar solicitação\n" + ex.Message);
            }
        }
    }
}
