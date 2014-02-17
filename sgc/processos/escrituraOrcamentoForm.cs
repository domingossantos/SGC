using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Modelos;
using DAO;
namespace sgc.processos
{
    public partial class escrituraOrcamentoForm : Form
    {
        EscrituraBLL escrituraBll;
        Conexao con;
        public Orcamento oOrcamento;
        public int idOrcamento = 0;
        public escrituraOrcamentoForm()
        {
            con = new Conexao(Dados.strConexao);
            escrituraBll = new EscrituraBLL(con);
            oOrcamento = new Orcamento();
            InitializeComponent();
        }

        public void carregaComboTipoEscritura(int id = 0) {
            cbTipoEscritura.DataSource = escrituraBll.getTipoEscritura();
            cbTipoEscritura.ValueMember = "idTipoEscritura";
            cbTipoEscritura.DisplayMember = "dsTipoEscritura";
            if (id > 0)
            {
                cbTipoEscritura.SelectedValue = id;
            }
        }

        public void carregaComboItem(int id = 0) {
            cbItemOrcamento.DataSource = escrituraBll.listaItensEscritura();
            cbItemOrcamento.ValueMember = "cdAto";
            cbItemOrcamento.DisplayMember = "dsAto";
            if (id > 0) {
                cbItemOrcamento.SelectedValue = id;
            }
        }

        public void atualizaGridClientes() {
            grid.DataSource = escrituraBll.getPessoasOrcamento(Convert.ToInt32(lbNumOrcamento.Text));

            grid.Columns[0].HeaderText = "CPF/CNPJ";
            grid.Columns[0].Width = 100;
            grid.Columns[1].HeaderText = "NOME";
            grid.Columns[1].Width = 280;
            grid.Columns[2].HeaderText = "TIPO";
            grid.Columns[2].Width = 100;

        }

        public void carregaItensOrcamento(int id)
        {

            gridItens.DataSource = escrituraBll.listaItensOrcamento(id);
            gridItens.Columns[0].Visible = false;

            gridItens.Columns[1].HeaderText = "ATO/OPERAÇÃO";
            gridItens.Columns[1].Width = 200;
            gridItens.Columns[2].HeaderText = "QTD";
            gridItens.Columns[2].Width = 40;
            gridItens.Columns[3].HeaderText = "VALOR";
            gridItens.Columns[3].Width = 100;
            gridItens.Columns[3].DefaultCellStyle.Format = "c";
            gridItens.Columns[4].Visible = false;
        }
        public void carregaDados(int num) {

            oOrcamento = escrituraBll.getOrcamento(num);

            
            lbNumOrcamento.Text = oOrcamento.IdOrcamento.ToString();
            txContato.Text = oOrcamento.DsContato;
            txDataTrans.Text = oOrcamento.DtTransacao.ToShortDateString();
            txEndereco.Text = oOrcamento.DsEndereco;
            txFoneContato.Text = oOrcamento.NrFoneContato;
            txObs.Text = oOrcamento.DsObservacao;
            txvalorTransacao.Text = oOrcamento.VlTransacao.ToString();
            txValorVenal.Text = oOrcamento.VlVenal.ToString();

            carregaComboTipoEscritura(oOrcamento.IdTipoEscritura);
            carregaItensOrcamento(oOrcamento.IdOrcamento);

            btNovo.Enabled = false;
            btSalvar.Enabled = true;
            pnClientes.Enabled = true;
            pnDados.Enabled = true;

            atualizaGridClientes();
        }

        private void btAddCliente_Click(object sender, EventArgs e)
        {
            addPessoaOrcamentoForm addForm = new addPessoaOrcamentoForm(this);
            addForm.ShowDialog();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            try
            {
                oOrcamento.IdOrcamento = escrituraBll.novoOramento();
                lbNumOrcamento.Text = oOrcamento.IdOrcamento.ToString();
                btNovo.Enabled = false;
                btSalvar.Enabled = true;
                pnClientes.Enabled = true;
                pnDados.Enabled = true;
                atualizaGridClientes();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Orcamento oOrcamento = new Orcamento();

                oOrcamento.IdOrcamento = Convert.ToInt32(lbNumOrcamento.Text);
                oOrcamento.IdTipoEscritura = Convert.ToInt32(cbTipoEscritura.SelectedValue);
                oOrcamento.NrFoneContato = txFoneContato.Text;
                oOrcamento.VlTransacao = Convert.ToDouble(txvalorTransacao.Text);
                oOrcamento.VlVenal = Convert.ToDouble(txValorVenal.Text);
                oOrcamento.DsContato = txContato.Text;
                oOrcamento.DsEndereco = txEndereco.Text;
                oOrcamento.DsObservacao = txObs.Text;
                oOrcamento.DtTransacao = Convert.ToDateTime(txDataTrans.Text);

                escrituraBll.salvaOrcamento(oOrcamento);

                MessageBox.Show("Orçamento Salvo");
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao salvar ORçamento\n" + ex.Message);
            }


        }

        private void limpaCampos() {
            btNovo.Enabled = true;
            btSalvar.Enabled = false;
            pnClientes.Enabled = false;
            pnDados.Enabled = false;
            lbNumOrcamento.Text = "0";
            grid.DataSource = null;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            buscaOrcamentoForm oBuscaForm = new buscaOrcamentoForm(this);

            oBuscaForm.ShowDialog();
        }

        private void escrituraOrcamentoForm_Load(object sender, EventArgs e)
        {
            carregaComboItem();
            carregaComboTipoEscritura();
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {

            if (txQtd.Text.Equals("")) {
                MessageBox.Show("Favor entrar com a quantidade");
                txQtd.Focus();
                return;
            }

            try
            {
                ItemOrcamento oItem = new ItemOrcamento();


                AtoOperacao oAto = escrituraBll.getAto(Convert.ToInt32(cbItemOrcamento.SelectedValue));
                String strValor = "";
                Double valorItem = 0;

                if (oAto.VlAto == null || oAto.VlAto == 0)
                {
                    if (oAto.VlPercentual == null || oAto.VlPercentual == 0)
                    {
                        strValor = (Microsoft.VisualBasic.Interaction.InputBox("informe o valor a ser utiliado neste item\nPara cancelar não digite nenhum valor.", "Cartorio Conduru", "", 150, 150));

                        if (!strValor.Equals(""))
                        {
                            try
                            {
                                valorItem = Convert.ToDouble(strValor);
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Digite um valor numerico");
                                return;
                            }

                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(txvalorTransacao.Text) >= Convert.ToDouble(txValorVenal.Text))
                        {
                            valorItem = Convert.ToDouble(txvalorTransacao.Text) * oAto.VlPercentual;
                        }

                        if (Convert.ToDouble(txvalorTransacao.Text) <= Convert.ToDouble(txValorVenal.Text))
                        {
                            valorItem = Convert.ToDouble(txValorVenal.Text) * oAto.VlPercentual;
                        }

                    }
                }
                else {
                    valorItem = oAto.VlAto;
                }

                oItem.IdOrcamento = oOrcamento.IdOrcamento;
                oItem.NrQuantidade = Convert.ToInt32(txQtd.Text);
                oItem.CdAto = oAto.CdAto;
                oItem.VlTotal = valorItem * Convert.ToInt32(txQtd.Text);
                oItem.StRegistro = 'A';
                oItem.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                escrituraBll.addItemOrcamento(oItem);

                MessageBox.Show("Item Adicionado");
                carregaItensOrcamento(oOrcamento.IdOrcamento);
                carregaComboItem();
                txQtd.Text = "";
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao adicionar Item "+ex.Message);
            }
        }

        private void btDelCliente_Click(object sender, EventArgs e)
        {
            try
            {
                escrituraBll.apagaPessoaOrcamento(grid[0, grid.CurrentRow.Index].Value.ToString(), oOrcamento.IdOrcamento);
                atualizaGridClientes();
                MessageBox.Show("Cliente apagado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar cliente " + ex.Message);
            }
        }

        private void btDelItem_Click(object sender, EventArgs e)
        {
            try
            {
                int item = Convert.ToInt32(gridItens[0, gridItens.CurrentRow.Index].Value);
                escrituraBll.delItemOrcamento(item, oOrcamento.IdOrcamento);
                MessageBox.Show("Item apagado");
                carregaItensOrcamento(oOrcamento.IdOrcamento);

            }
            catch (Exception) {
                MessageBox.Show("Erro ao apagar item");
            }
        }

        private void btImprime_Click(object sender, EventArgs e)
        {
            impressaoOrcamentoForm printOrcamento = new impressaoOrcamentoForm(oOrcamento.IdOrcamento);
            printOrcamento.ShowDialog();
        }

        private void txvalorTransacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }

            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                txValorVenal.Focus();
            }
        }

        private void txValorVenal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }

            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                txDataTrans.Focus();
            }
        }
    }
}
