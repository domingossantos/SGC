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

        private String validaCampos() {
            String retorno = "";

            /*
            if(txCpfCnpj.Text.Length > 20) retorno = "Verifique tama";

            if (txNome.Text.Length > 100) retorno = false;
            if (txEndereco.Text.Length > 80) retorno = false;
            if (txNrFone.Text.Length > 40) retorno = false;
            if (txBairro.Text.Length > 40) retorno = false;
            if (txEmail.Text.Length > 100) retorno = false;
            if (txUF.Text.Length > 2) retorno = false;
            if (txCidade.Text.Length > 50) retorno = false;
            txNrCep.Text.Replace('.',' ').Trim();
            if (txNrCep.Text.Length > 10) retorno = false;
            */

            if (txCpfCnpj.Text == "")
            {
                retorno = "Campo CPF/CNPJ Obrigatório!\n";
            }

            if (txNome.Text == "")
            {
                retorno += "Campo Nome Obrigatório!\n";
            }
            if (txEndereco.Text == "")
            {
                retorno += "Campo Endereço Obrigatório!\n";
            }

            if (txNrFone.Text == "")
            {
                retorno += "Campo Fone Obrigatório!";
            }



            return retorno;
        }

        private void limpaCampos() {
            txCpfCnpj.Text = "";
            txNome.Text = "";
            txEndereco.Text = "";
            txNrFone.Text = "";
            txBairro.Text = "";
            txEmail.Text = "";
            txUF.Text = "";
            txCidade.Text = "";
            txNrCep.Text = "";
            rbAtivo.Checked = false;
            rbInativo.Checked = false;
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
                //nrCPFCNPJ,nmNome,dsEndereco,dsBairro"
                //        + ",nrCEP,dsCidade,sgUF,dsEmail,nrFone"
                //        + ",dtInclusao,stCorrentista
                grid.DataSource = pesquisaCorrentista();
                grid.Columns[0].HeaderText = "CPF/CNPJ";
                grid.Columns[0].Width = 190;
                grid.Columns[1].HeaderText = "Nome";
                grid.Columns[1].Width = 240;
                grid.Columns[2].HeaderText = "Endereço";
                grid.Columns[2].Width = 240;
                grid.Columns[3].Visible = false;
                grid.Columns[4].Visible = false;
                grid.Columns[5].Visible = false;
                grid.Columns[6].Visible = false;
                grid.Columns[7].HeaderText = "Email";
                grid.Columns[7].Width = 200;
                grid.Columns[8].HeaderText = "Fone";
                grid.Columns[8].Width = 120;
                grid.Columns[9].HeaderText = "Data Cadastro";
                grid.Columns[9].Width = 120;
                grid.Columns[10].HeaderText = "Status";
                grid.Columns[10].Width = 50;

            }
            else {
                MessageBox.Show("Pesquisa não habilitada.\nClique em cancelar a operação atual e iniciar uma pesquisa");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (validaCampos().Length == 0)
                {
                    Correntista oCorrentista = new Correntista();
                    oCorrentista.NrCPFCPNJ = txCpfCnpj.Text;

                    oCorrentista.NmCorrentista = txNome.Text;
                    oCorrentista.DsEndereco = txEndereco.Text;
                    oCorrentista.NrFone = txNrFone.Text.Replace(".", "").Replace("-", "").Replace(",", "").Trim(); ;
                    oCorrentista.DsBairro = txBairro.Text;
                    oCorrentista.DsEmail = txEmail.Text;
                    oCorrentista.SgUF = txUF.Text.Trim();
                    oCorrentista.DsCidade = txCidade.Text;
                    oCorrentista.NrCEP = txNrCep.Text.Replace(".","").Replace("-","").Replace(",","").Trim();
                    oCorrentista.StCorrentista = getStatus();

                    oCorrentistaBll.salvaCorrentista(oCorrentista, operacao);

                    MessageBox.Show("Registro salvo!");
                    pesquisaCorrentista();
                    limpaCampos();
                    operacao = 'P';
                }
                else {
                    MessageBox.Show(validaCampos());
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao salvar dados.\n" + ex.Message);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
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

                operacao = 'A';
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao recuperar dados\n"+ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            operacao = 'I';
            limpaCampos();
            txCpfCnpj.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            MessageBox.Show("Operação cancelada!");
            operacao = 'P';
        }
    }
}
