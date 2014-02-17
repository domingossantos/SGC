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
using MatrixReporter;

namespace sgc.caixa
{
    public partial class movimentoCaixasForm : Form
    {
        private PedidoBLL pedidoBLL;
        private Conexao con;
        private Reporter impressora;
        public movimentoCaixasForm()
        {
            con = new Conexao(DAO.Dados.strConexao);
            pedidoBLL = new PedidoBLL(con);
            impressora = new Reporter();
            InitializeComponent();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                pedidoBLL.imprimeMovimentoCaixas(utils.sessao.PathIniFile, 
                                    dtMovimento.Value.ToShortDateString(),
                                    dtFim.Value.ToShortDateString());
                MessageBox.Show("Imprimindo fita!");
            }
            catch(Exception ex){
                MessageBox.Show("Erro ao imprimir\n"+ex.Message+"\n"+ex.StackTrace);
            }

        }
    }
}
