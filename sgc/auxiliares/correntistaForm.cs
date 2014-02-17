using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using DAO;

namespace sgc.auxiliares
{
    public partial class correntistaForm : sgc.modeloForm
    {
        private char operacao;
        private Correntista oCorrentista;
        private CorrentistaBLL oCorrentistaBll;
        public correntistaForm()
        {
            Conexao oCon = new Conexao(Dados.strConexao);
            oCorrentistaBll = new CorrentistaBLL(oCon);
            operacao = 'P';
            InitializeComponent();
        }

        #region Operações 
        private DataTable pesquisaCorrentista() {
            DataTable vDados = new DataTable();

            if (!txCpfCnpj.Text.Equals("")) {
                vDados = oCorrentistaBll.getCorrentistas(" and nrCpfCnpj = '" + txCpfCnpj.Text + "'");
            }
            if (!txNome.Text.Equals(""))
            {
                vDados = oCorrentistaBll.getCorrentistas(" and nmNome like '%" + txNome.Text + "%'");
            }
            return vDados;
        }

        private char getStatus() {
            char status = 'A';

            if(rbInativo.Checked){
                status = 'I';
            }
            return status;

        }
        private void setStatus(char status) {
            if (status.Equals('A'))
            {
                rbAtivo.Checked = true;
            }
            else {
                rbInativo.Checked = true;
            }
        }
        #endregion
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (operacao.Equals('P'))
            {
                grid.DataSource = pesquisaCorrentista();
            }
            else {
                MessageBox.Show("Pesquisa não habilitada.\nClique em cancelar a operação atual e iniciar uma pesquisa");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            oCorrentista = oCorrentistaBll.getCorrentista(grid[0, grid.CurrentRow.Index].Value.ToString());
            txCpfCnpj.Text = oCorrentista.NrCPFCPNJ;
            txNome.Text = oCorrentista.NmCorrentista;
            txEndereco.Text = oCorrentista.DsEndereco;
            txNrFone.Text = oCorrentista.NrCEP;
            txBairro.Text = oCorrentista.DsBairro;
            txEmail.Text = oCorrentista.DsEmail;
            txUF.Text = oCorrentista.SgUF;
            txCidade.Text = oCorrentista.DsCidade;
            txNrCep.Text = oCorrentista.NrCEP;
            setStatus(oCorrentista.StCorrentista);

        }
    }
}
