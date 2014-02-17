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
using Modelos;

namespace sgc.caixa
{
    public partial class caixaPesquisaForm : Form
    {
        private CaixaBLL caixaBLL;
        private Conexao con;
        private PedidoBLL pedidoBLL;
        private UsuarioBLL usuarioBLL;
        
        public caixaPesquisaForm()
        {
            con = new Conexao(DAO.Dados.strConexao);
            caixaBLL = new CaixaBLL(con);
            pedidoBLL = new PedidoBLL(con);
            usuarioBLL = new UsuarioBLL(con);
            InitializeComponent();
        }

        public void carregaUsuario(){
            cbUsuarios.DataSource = usuarioBLL.listarUsuarios();

            cbUsuarios.ValueMember = "dsLogin";
            cbUsuarios.DisplayMember = "nmUsuario";
            cbUsuarios.Text = "Selecione";
            cbUsuarios.SelectedItem = -1;
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            string inicio = "";
            string fim = "";
            string login = "";
            int caixa = 0;

            if (!txCaixa.Text.Equals("")) {
                caixa = Convert.ToInt32(txCaixa.Text);
            }

            if (!cbUsuarios.Text.Equals("Selecione")) {
                login = cbUsuarios.SelectedValue.ToString();
            }

            if (!DateTime.Now.ToShortDateString().Equals(dtInicio.Value.ToShortDateString())) {
                inicio = utils.formatos.formatoData(dtInicio.Value.ToShortDateString(),true);
                fim = utils.formatos.formatoData(dtFim.Value.ToShortDateString(),true);
            }
            
            grid.DataSource = caixaBLL.pesquisaCaixa(inicio,fim,login,caixa);

            if (grid.RowCount == 0) MessageBox.Show("Não há registros a exbir");
        }



        private void brPrint_Click(object sender, EventArgs e)
        {
            if (grid.RowCount > 0)
            {
                int idHistorico = Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value);
                pedidoBLL.imprimeFechamentoCaixa(utils.sessao.PathIniFile, caixaBLL.getHistoricoCaixa(idHistorico));
                MessageBox.Show("Imprimindo Fita do Caixa");
            }
        }

        private void brFechar_Click(object sender, EventArgs e)
        {
            try
            {
                int idHitorico = Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value.ToString());
                HistoricoCaixa historico = caixaBLL.getHistoricoCaixa(idHitorico);
                caixaBLL.fechaCaixa(historico);
                MessageBox.Show("Caixa Fechado");
                btPesquisa_Click(null, null);
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao fechar caixa\n"+ex.Message);
            }
        }

        private void caixaPesquisaForm_Load(object sender, EventArgs e)
        {
            carregaUsuario();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            carregaUsuario();
            txCaixa.Text = "";
            dtInicio.Value = DateTime.Now;
            dtFim.Value = DateTime.Now;
        }
    }
}
