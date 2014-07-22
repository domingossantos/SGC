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
    public partial class escrituraForm : Form
    {
        private EscrituraBLL escrituraBLL;
        private Escritura escritura;

        public Escritura Escritura
        {
            get { return escritura; }
        }

        private AtoOperacaoBLL atoBLL;
        private AtoOperacao ato;
        private Pessoa pessoa;
        private PessoaBLL pessoaBLL;
        private PedidoBLL pedidoBLL;
        private Conexao con;
        private string str;
        private string str2;
        private byte op;
        private DateTime dTest = DateTime.MinValue;
        public byte Op
        {
            get { return op; }
            set { op = value; }
        }
        public escrituraForm()
        {
            con = new Conexao(Dados.strConexao);
            ato = new AtoOperacao();
            escritura = new Escritura();
            atoBLL = new AtoOperacaoBLL(con);
            escrituraBLL = new EscrituraBLL(con);
            pessoaBLL = new PessoaBLL(con);
            pedidoBLL = new PedidoBLL(con);
            str = "";
            str2 = "";
            op = 0;
            InitializeComponent();
        }

        public void carregaAtos(int idx = 0)
        {
            cbAtos.DataSource = atoBLL.listaAtosPorTipo(3,0,null);
            if (idx > 0)
                cbAtos.SelectedValue = idx;
            else
                cbAtos.Text = "Selecione";
            
            cbAtos.ValueMember = "cdAto";
            cbAtos.DisplayMember = "dsAto";
        }

        public void carregaTipoPessoa() {
            cbTipo.DataSource = pessoaBLL.getTipoPessoa();
            
            cbTipo.ValueMember = "cdTipoPessoa";
            cbTipo.DisplayMember = "dsTipoPessoa";

            cbTipo.Text = "Selecione";
        }

        

        
        public void carregaPagamento() {
            gridItensPgto.DataSource = escrituraBLL.listaMovimento(escritura.IdEscritura,'D');
            gridItensPgto.Columns[0].HeaderText = "COD.";
            gridItensPgto.Columns[0].Width = 60;
            gridItensPgto.Columns[1].HeaderText = "FICHA";
            gridItensPgto.Columns[1].Width = 70;
            gridItensPgto.Columns[2].HeaderText = "ATO";
            gridItensPgto.Columns[2].Width = 280;
            gridItensPgto.Columns[3].HeaderText = "VALOR";
            gridItensPgto.Columns[3].Width = 180;
            gridItensPgto.Columns[3].DefaultCellStyle.Format = "c";
            gridItensPgto.Columns[4].HeaderText = "DESCRIÇÃO";
            gridItensPgto.Columns[4].Width = 280;
            gridItensPgto.Columns[5].HeaderText = "DATA";
            gridItensPgto.Columns[5].Width = 100;
            gridItensPgto.Columns[6].HeaderText = "USUÁRIO";
            gridItensPgto.Columns[6].Width = 100;

            lbTotalPgto.Text = String.Format("R$ {0:N2}", getSomaCampoGrid(gridItensPgto, 3));
        }

        public void carregaPessoaEscritura() {
            gridVendedor.DataSource = escrituraBLL.listaPessoasEscritura(escritura.IdEscritura);
            gridVendedor.Columns[0].HeaderText = "CPF/CNPJ";
            gridVendedor.Columns[0].Width = 140;
            gridVendedor.Columns[1].HeaderText = "NOME";
            gridVendedor.Columns[1].Width = 380;
            gridVendedor.Columns[2].HeaderText = "TIPO";
            gridVendedor.Columns[2].Width = 180;
            
        }

        
        public void carregaOrcamentoEscritura()
        {
            gridItensOrcamento.DataSource = escrituraBLL.listaItensOrcamento(escritura.IdOrcamento);
            gridItensOrcamento.Columns[0].HeaderText = "COD.";
            gridItensOrcamento.Columns[0].Width = 40;
            gridItensOrcamento.Columns[1].HeaderText = "DESCRIÇÃO";
            gridItensOrcamento.Columns[1].Width = 280;
            gridItensOrcamento.Columns[2].HeaderText = "QTD";
            gridItensOrcamento.Columns[2].Width = 40;
            gridItensOrcamento.Columns[3].HeaderText = "VALOR";
            gridItensOrcamento.Columns[3].Width = 80;
            gridItensOrcamento.Columns[3].DefaultCellStyle.Format = "c";
            gridItensOrcamento.Columns[4].HeaderText = "USUÁRIO";
            gridItensOrcamento.Columns[4].Width = 80;

            lbValorTotalItens.Text = String.Format("R$ {0:N2}", getSomaCampoGrid(gridItensOrcamento, 3));
        }

        public void carregaRecebimentos() {
            gridRecebe.DataSource = escrituraBLL.listaMovimento(escritura.IdEscritura,'C');
            gridRecebe.Columns[0].HeaderText = "COD.";
            gridRecebe.Columns[0].Width = 60;
            gridRecebe.Columns[1].HeaderText = "FICHA";
            gridRecebe.Columns[1].Width = 70;
            gridRecebe.Columns[2].HeaderText = "ATO";
            gridRecebe.Columns[2].Width = 280;
            gridRecebe.Columns[3].HeaderText = "VALOR";
            gridRecebe.Columns[3].Width = 180;
            gridRecebe.Columns[3].DefaultCellStyle.Format = "c";
            gridRecebe.Columns[4].HeaderText = "DESCRIÇÃO";
            gridRecebe.Columns[4].Width = 280;
            gridRecebe.Columns[5].HeaderText = "DATA";
            gridRecebe.Columns[5].Width = 100;
            gridRecebe.Columns[6].HeaderText = "USUÁRIO";
            gridRecebe.Columns[6].Width = 100;

            lbTotalRecebe.Text = String.Format("R$ {0:N2}",getSomaCampoGrid(gridRecebe,3));           

        }

        public double getSomaCampoGrid(DataGridView grid, int coluna) {
            double soma = 0;
            for (int i = 0; i < grid.RowCount; i++)
            {
                soma += Convert.ToDouble(grid[coluna, i].Value);
            }

            return soma;
        }

        private void setSegundaNota(int idx) {
            if (idx == 0)
            {
                cbSegundNota.SelectedIndex = 1;
            }
            else {
                cbSegundNota.SelectedIndex = 0;
            }
        }

        private sbyte getSegundaNota() {
            sbyte idx = 0;

            if (cbSegundNota.SelectedIndex == 0)
            {
                idx = 1;
            }

            return idx;
        }


        public void atualizaResumo() {
            lbValorCreditado.Text = String.Format("R$ {0:N2}",escrituraBLL.getValorCliente(escritura.IdEscritura,'C'));
            lbValorDebitado.Text = String.Format("R$ {0:N2}", escrituraBLL.getValorCliente(escritura.IdEscritura, 'D'));
            lbSaldoCliente.Text = String.Format("R$ {0:N2}", escrituraBLL.getValorCliente(escritura.IdEscritura, 'C') - escrituraBLL.getValorCliente(escritura.IdEscritura, 'D'));
        }
        public void carregaTodosDados(){
        
            carregaItensOrcamento();
            carregaTipoPessoa();
            carregaPessoaEscritura();
            carregaOrcamentoEscritura();
            carregaRecebimentos();
            carregaPagamento();
            atualizaResumo();
            lbNumFicha.Text = escritura.IdEscritura.ToString();
            lbResponsavel.Text = escritura.DsLogin;
            lbLivro.Text = escritura.NrLivro;
            lbFolha.Text = escritura.NrFolha;

            if (escritura.DtEntrada == null) {
                txDataAbertura.Text = escritura.DtEntrada.ToShortDateString();
            }

            if (escritura.NrSelo != 0)
            {
                lbSelo.Text = escritura.NrSelo.ToString() + " SERIE " + pedidoBLL.getSerieSelo(escritura.CdTipoSelo);
            }

            if (escritura.TpEscritura.Equals('F'))
            {
                MessageBox.Show("Escritura Finalizada. Dados somente para consulta!");
                
                btAddPessoa.Enabled = false;
                brDelPessoa.Enabled = false;
                btAndamento.Enabled = false;
                btFecharEscritura.Enabled = false;
                btPagamento.Enabled = false;
                btRecebimento.Enabled = false;
                btSalvar.Enabled = false;
            }
            else
            {
                
                btAddPessoa.Enabled = true;
                brDelPessoa.Enabled = true;
                btAndamento.Enabled = true;
                btFecharEscritura.Enabled = true;
                btPagamento.Enabled = true;
                btRecebimento.Enabled = true;
                btSalvar.Enabled = true;
            }
        }

        public void limparCampos() {
            carregaAtos();
            str = "";

            txVlImovel.Text = "";
            txVlVenal.Text = "";
            txVlBaseCalculo.Text = "";
            txCEP.Text = "";
            txCidade.Text = "";
            txCpfCnpj.Text = "";
            txEmailContato.Text = "";
            txEndereco.Text = "";
            txFoneContato.Text = "";
            txNomeContato.Text = "";
            txNomePessoa.Text = "";
            txProcessoItbi.Text = "";
            txProcessoLaudemio.Text = "";
            txVlBaseCalculo.Text = "";
            txVlImovel.Text = "";
            txVlVenal.Text = "";
            lbFolha.Text = "0";
            lbLivro.Text = "0";
            lbNumFicha.Text = "0";
            lbResponsavel.Text = "";
            lbSaldoCliente.Text = "0";
            lbSelo.Text = "0";
            lbTotalPgto.Text = "0";
            lbTotalRecebe.Text = "0";
            lbValorCreditado.Text = "0";
            lbValorDebitado.Text = "0";
            lbValorEscritura.Text = "0";
            lbValorTotalItens.Text = "0";
            gridItensOrcamento.DataSource = null;
            gridItensPgto.DataSource = null;
            gridRecebe.DataSource = null;
            gridVendedor.DataSource = null;
            
        }
        private bool IsNumeric(int Val)
        {
            return (((Val >= 48 && Val <= 57) || (Val >= 96 && Val <= 105)) || (Val == 8) || (Val == 46));
        }
        private int setKeyCode(int i)
        {
            int n = 0;
            switch (i)
            {
                case 96:
                    n = 48;
                    break;
                case 97:
                    n = 49;
                    break;
                case 98:
                    n = 50;
                    break;
                case 99:
                    n = 51;
                    break;
                case 100:
                    n = 52;
                    break;
                case 101:
                    n = 53;
                    break;
                case 102:
                    n = 54;
                    break;
                case 103:
                    n = 55;
                    break;
                case 104:
                    n = 56;
                    break;
                case 105:
                    n = 57;
                    break;
                default:
                    n = i;
                    break;
            }
            return n;
        }

        

        

       
        

        private void setUF(string uf) {

            for (int i = 0; i < cbUF.Items.Count - 1; i++)
            {
                if (cbUF.Items[i].ToString().Equals(uf)) {
                    cbUF.SelectedIndex = i;
                    return;
                }
            }
        }


        private string getUF() {
            string uf = "PA";
            if (cbUF.SelectedIndex >= 0) {
                uf = cbUF.Items[cbUF.SelectedIndex].ToString();
            }

            return uf;
        }

        private void formataTextoMoeda(object sender, KeyEventArgs e, TextBox objText)
        {

            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode))
            {
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = true;
            }

            if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else if (!((KeyCode == 8) || (KeyCode == 46)))
            {
                if (KeyCode >= 96 && KeyCode <= 105)
                    KeyCode = setKeyCode(KeyCode);

                str = str + Convert.ToChar(KeyCode);
            }

            if (str.Length == 0)
            {
                txVlImovel.Text = "";
            }
            if (str.Length == 1)
            {
                objText.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                objText.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                objText.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
        }


        private void calculaValorBase() {

            if (txVlImovel.Text.Equals(""))
                txVlImovel.Text = "0";

            if (txVlVenal.Text.Equals(""))
                txVlVenal.Text = "0";

            double vlImovel = Convert.ToDouble(txVlImovel.Text);
            double vlVenal = Convert.ToDouble(txVlVenal.Text);

            if (vlImovel >= vlVenal)
            {
                txVlBaseCalculo.Text = vlImovel.ToString();
            }
            else 
            {
                txVlBaseCalculo.Text = vlVenal.ToString();
            } 
        }

        public void carregaItensOrcamento() {
            
            gridItensOrcamento.DataSource = escrituraBLL.listaItensOrcamento(escritura.IdEscritura);
            
        }

        // Metodos de ação
        private void btNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja abrir um novo Ficha?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
            {
                limparCampos();
                txVlImovel.Focus();

                try
                {
                    escritura.IdEscritura = escrituraBLL.novaEscritura();
                }
                catch (Exception ex)
                {
                    utils.MessagensExcept.funMsgSistema("Erro ao salvar nova ficha.\n" + ex.Message, 1);
                }
                lbNumFicha.Text = escritura.IdEscritura.ToString();
                op = 2;
                carregaTodosDados();
            }
        }

        private void txVlImovel_KeyDown(object sender, KeyEventArgs e)
        {
            //formataTextoMoeda(sender,e,txVlImovel);
        }

        private void txVlImovel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txVlVenal_KeyDown(object sender, KeyEventArgs e)
        {
            //formataTextoMoeda(sender, e, txVlVenal);
        }

        private void txVlVenal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txVlImovel_Leave(object sender, EventArgs e)
        {
            calculaValorBase();
        }

        private void txVlVenal_Leave(object sender, EventArgs e)
        {
            calculaValorBase();
        }

        private void txVlImovel_Enter(object sender, EventArgs e)
        {
            str = txVlImovel.Text.Replace(",","");
        }

        private void txVlVenal_Enter(object sender, EventArgs e)
        {
            str = txVlVenal.Text.Replace(",", "");
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (op == 0) {
                MessageBox.Show("Selecione uma escritura ou clique em novo para salvar os dados!");
                return;
            }

            if (txVlImovel.Text.Equals("")) {
                MessageBox.Show("Campo Obrigatório: Valor Imóvel");
                txVlImovel.Focus();
                return;
            }

            if (txVlVenal.Text.Equals(""))
            {
                MessageBox.Show("Campo Obrigatório: Valor Venal");
                txVlVenal.Focus();
                return;
            }
            
            if (txVlBaseCalculo.Text.Equals(""))
            {
                MessageBox.Show("Campo Obrigatório: Valor Base");
                txVlBaseCalculo.Focus();
                return;
            }

            if (txEndereco.Text.Equals(""))
            {
                MessageBox.Show("Campo Obrigatório: Endereço");
                txEndereco.Focus();
                return;
            }

            if (escritura.TpEscritura == 'F') {
                MessageBox.Show("Escritura Já finalizada. Dados somente para conferencia");
                return;
            }
            
            //if (op == 1)
            //{
            //    escritura.CdAto = Convert.ToInt32(cbAtos.SelectedValue.ToString());
            //    escritura.TpRequerente = getTipoRequerente();
            //    escritura.VlDocumento = Convert.ToDouble(txVlImovel.Text);
            //    escritura.VlVenal = Convert.ToDouble(txVlVenal.Text);
            //    escritura.VlBaseCalculo = Convert.ToDouble(txVlBaseCalculo.Text);
            //    escritura.NrProcessoITBI = txProcessoItbi.Text;
            //    escritura.NrProcessoLaudemio = txProcessoLaudemio.Text;
            //    escritura.DsContato = txNomeContato.Text;
            //    escritura.DsEndereco = txEndereco.Text;
            //    escritura.NrCEP = txCEP.Text;
            //    escritura.NmCidade = txCidade.Text;
            //    escritura.DsUF = getUF();
            //    escritura.DsFoneContato = txFoneContato.Text;
            //    escritura.DsEmailContato = txEmailContato.Text;
            //    escritura.DtOrcamento = DateTime.Now;
            //    escritura.TpEscritura = getTipoEscritura();
            //    escritura.StSegundaNota = getSegundaNota();
            //    escritura.DtEntrada = Convert.ToDateTime(txDataAbertura.Text);

            //    if (escritura.DsLogin == null)
            //        escritura.DsLogin = utils.sessao.UsuarioSessao.DsLogin;


            //    escrituraBLL.addEscritura(escritura);



            //    MessageBox.Show("Escritura gravada!");
                

            //    op = 0;
            //}
            if (op == 2)
            {
                
                escritura.CdAto = Convert.ToInt32(cbAtos.SelectedValue.ToString());
                escritura.TpRequerente = 'F';
                escritura.VlDocumento = Convert.ToDouble(txVlImovel.Text);
                escritura.VlVenal = Convert.ToDouble(txVlVenal.Text);
                escritura.VlBaseCalculo = Convert.ToDouble(txVlBaseCalculo.Text);
                escritura.TpEscritura = 'E';
                escritura.DsEndereco = txEndereco.Text;
                escritura.NrCEP = txCEP.Text;
                escritura.NmCidade = txCidade.Text;
                escritura.DsContato = txNomeContato.Text;
                escritura.DsFoneContato = txFoneContato.Text;
                escritura.DsEmailContato = txEmailContato.Text;
                escritura.NrProcessoITBI = txProcessoItbi.Text;
                escritura.NrProcessoLaudemio = txProcessoLaudemio.Text;
                escritura.StSegundaNota = getSegundaNota();
                escritura.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                if (!cbUF.Text.Equals(""))
                    escritura.DsUF = cbUF.SelectedItem.ToString();
                else
                    escritura.DsUF = "PA";
                escrituraBLL.salvaEscritura(escritura);

                if (txDataAbertura.Text.Equals("__/__/____"))
                {
                    escritura.DtEntrada = DateTime.Now;
                }
                else
                {
                    if (DateTime.TryParse(txDataAbertura.Text.Trim(), out dTest))
                    {
                        escritura.DtEntrada = DateTime.Parse(txDataAbertura.Text);
                    }
                    else {
                        utils.MessagensExcept.funMsgSistema("Data Inválida",1);
                        txDataAbertura.Focus();
                        return;
                    }
                }

                utils.MessagensExcept.funMsgSistema("Escritura gravada!",2);

            }
            gravaValorEscritura();
            carregaTodosDados();
        }

        private void btAndamentos_Click(object sender, EventArgs e)
        {
            pesquisaEscrituraForm pesquisaForm = new pesquisaEscrituraForm(this);
            pesquisaForm.ShowDialog();

        }

        public void carregaDados(int id) {
            limparCampos();

            escritura = escrituraBLL.getEscritura(id);

            txVlImovel.Text =  String.Format("{0:N2}", escritura.VlDocumento);
            txVlVenal.Text = String.Format("{0:N2}", escritura.VlVenal);
            txVlBaseCalculo.Text = String.Format("{0:N2}",escritura.VlBaseCalculo);
            txProcessoLaudemio.Text = escritura.NrProcessoLaudemio.ToString();
            txProcessoItbi.Text = escritura.NrProcessoITBI.ToString();
            txEndereco.Text = escritura.DsEndereco;
            txFoneContato.Text = escritura.DsFoneContato;
            txNomeContato.Text = escritura.DsContato;
            txEmailContato.Text = escritura.DsEmailContato;
            txCEP.Text = escritura.NrCEP;
            txCidade.Text = escritura.NmCidade;


            setUF(escritura.DsUF);
            
            setSegundaNota(escritura.StSegundaNota);
            cbAtos.SelectedValue = escritura.CdAto;

            lbValorEscritura.Text = String.Format("{0:N2}",escrituraBLL.getValorAto(escritura.CdAto));

            carregaTodosDados();
        }

        private void btPesquisaPessoa_Click(object sender, EventArgs e)
        {
            if (!txCpfCnpj.Text.Equals(""))
            {

                String nome = pessoaBLL.pesquisaPessoa(txCpfCnpj.Text);

                if (nome == null)
                {
                    String msg = "Não há cliente cadastrado com esse CPF/CNPJ!\nDeseja cadastra-lo";
                    DialogResult result = MessageBox.Show(msg, "Cadastro de Pessoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result.ToString().Equals("Yes"))
                    {
                        //auxiliares.PessoaForm pessoaForm = new auxiliares.PessoaForm(this, txCpfCnpj, txNomePessoa);
                        pessoaForm oPessoaForm = new pessoaForm(txCpfCnpj);
                        oPessoaForm.ShowDialog();
                    }
                    else
                    {
                        txCpfCnpj.Text = "";
                        txCpfCnpj.Focus();
                    }
                }
                else
                {
                    txNomePessoa.Text = nome;
                    btAddPessoa.Enabled = true;
                }
            }
        }

        private void txCpfCnpj_Leave(object sender, EventArgs e)
        {
            btPesquisaPessoa_Click(null,null);
        }

        private void btAddPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                PessoaEscritura pe = new PessoaEscritura();
                pe.CdTipoPessoa = Convert.ToInt32(cbTipo.SelectedValue.ToString());
                pe.IdEscritura = escritura.IdEscritura;
                pe.NrCpfCnpj = txCpfCnpj.Text;
                escrituraBLL.addPessoaEscritura (pe);
                utils.MessagensExcept.funMsgSistema("Registro Salvo!",2);
                txNomePessoa.Text = "";
                txCpfCnpj.Text = "";
                txCpfCnpj.Focus();
                carregaPessoaEscritura();
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao cadastrar pessoa.\n" + ex.Message,1);
            }
        }

        private void brDelPessoa_Click(object sender, EventArgs e)
        {
            if (escritura.IdEscritura <= 0) {
                utils.MessagensExcept.funMsgSistema("Selecione uma Escritura para editar os registros",3);
            }
            try
            {
                string num = gridVendedor[0, gridVendedor.CurrentRow.Index].Value.ToString();
                escrituraBLL.delPessoaEscritura(num, escritura.IdEscritura);
                utils.MessagensExcept.funMsgSistema("Registro Apagado!",2);
                carregaPessoaEscritura();
            }
            catch(Exception){
                utils.MessagensExcept.funMsgSistema("Não há registro selecionado!",2);
            }
        }

        private void abreFormItem(sbyte op) {
            registraItemEscrituraForm ItemForm = new registraItemEscrituraForm(this, op);
            ItemForm.ShowDialog();
        }

        private void btDelItem_Click(object sender, EventArgs e)
        {
            try
            {
                escrituraBLL.delItemOrcamento(Convert.ToInt32(gridItensOrcamento[0, gridItensOrcamento.CurrentRow.Index].Value.ToString()), escritura.IdEscritura);
                utils.MessagensExcept.funMsgSistema("Item apagado!",2);
                carregaItensOrcamento();
            }
            catch (Exception) {
                utils.MessagensExcept.funMsgSistema("Erro ao apagar item!",1);
                con.ObjCon.Close();
            }
        }

        private void brAddPagto_Click(object sender, EventArgs e)
        {
            abreFormItem(2);
        }

        private void btAddRecebe_Click(object sender, EventArgs e)
        {
            abreFormItem(3);
        }

        private void btAtualizaDados_Click(object sender, EventArgs e)
        {
            carregaTodosDados();
        }

        private void escrituraForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10) {
                DialogResult result = MessageBox.Show("Deseja fechar esta janela", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.ToString().Equals("Yes"))
                    this.Close();
            }

            if (e.KeyCode == Keys.F5) {
                btAtualizaDados_Click(null, null);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S) {
                btSalvar_Click(null, null);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                btNovo_Click(null, null);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.L)
            {
                pesquisaEscrituraForm pesquisaForm = new pesquisaEscrituraForm(this);
                pesquisaForm.ShowDialog();
            }


        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {
            fichaClienteForm fichaForm = new fichaClienteForm();
            fichaForm.tblEscrituraBindingSource.DataSource = escrituraBLL.getEscriturasRelatorio(escritura.IdEscritura);
            fichaForm.tblItensOrcamentoBindingSource.DataSource = escrituraBLL.listaItensOrcamentoRelatorio(escritura.IdEscritura);

            fichaForm.ShowDialog();
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            abreFormItem(1);
        }

        private void btAndamento_Click(object sender, EventArgs e)
        {
            andamentosForm formAndamento = new andamentosForm(this);
            formAndamento.ShowDialog();
        }

        private void btPagamento_Click(object sender, EventArgs e)
        {
            abreFormItem(2);
        }

        private void btRecebimento_Click(object sender, EventArgs e)
        {
            abreFormItem(3);
        }

        private void escrituraForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btProcesso_Click(object sender, EventArgs e)
        {

            AtoOperacao atoPago = escrituraBLL.verificaPagamentoEscritura(escritura.IdEscritura, escritura.CdAto);
            if (atoPago != null)
            {
                utils.MessagensExcept.funMsgSistema("Escritura já paga!",2);
            }

            lavrarEscrituraForm lavrarForm = new lavrarEscrituraForm(escritura);
            lavrarForm.ShowDialog();

        }

        private void cbAtos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbValorEscritura.Text = String.Format("{0:N2}", escrituraBLL.getValorAto(Convert.ToInt32(cbAtos.SelectedValue.ToString())));


            // Verifica mudança de ato

        }


        private void gravaValorEscritura() 
        {
            try
            {
                AtoOperacao ato = escrituraBLL.verificaPagamentoEscritura(escritura.IdEscritura,
                                    Convert.ToInt32(cbAtos.SelectedValue.ToString()));

                if (ato == null)
                {
                    MovimentoDeposito movimento = new MovimentoDeposito();

                    ato = atoBLL.getAto(Convert.ToInt32(cbAtos.SelectedValue.ToString()));
                    movimento.IdEscritura = escritura.IdEscritura;
                    movimento.CdAto = ato.CdAto;
                    movimento.VlMovimento = ato.VlAto;
                    movimento.DsMovimento = ato.DsAto;
                    movimento.DtMovimento = DateTime.Now;
                    movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                    movimento.TpMovimento = 'D';
                    movimento.StRegistro = 'P';

                    escrituraBLL.solicitaPagamento(movimento, true);
                }
            }
            catch (Exception ex)
            {
                utils.MessagensExcept.funMsgSistema("Erro ao solictar pagamento.\n" + ex.Message,1);
            }
                
    
        }

        private void btFecharEscritura_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlgR = MessageBox.Show("Deseja Fechar esta Ficha e Entregar a Escritura?", "Cartorio Conduru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgR == DialogResult.No)
                {
                    utils.MessagensExcept.funMsgSistema("Solicitação Cancelada!",3);
                    return;
                }
                
                gravaValorEscritura();
                double valor = escrituraBLL.getValorCliente(escritura.IdEscritura, 'C');
                if (valor < 0) 
                {
                    utils.MessagensExcept.funMsgSistema("O saldo desta ficha está negativa.\nFavor entrar em contato com o cliente para informá-lo.",3);
                    return;
                }


                if (valor > 0)
                {
                    ato = atoBLL.getAto("10100");
                    Pedido p = new Pedido();

                    MovimentoDeposito movimento = new MovimentoDeposito();
                    movimento.IdEscritura = escritura.IdEscritura;
                    movimento.CdAto = ato.CdAto;
                    movimento.VlMovimento = valor;
                    movimento.DsMovimento = "FINALIZAÇÃO ESCRITURA";
                    movimento.DtMovimento = DateTime.Now;
                    movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                    movimento.TpMovimento = 'D';
                    movimento.StRegistro = 'A';

                    escrituraBLL.gravaPagamento(movimento,ref p);
                    escrituraBLL.imprimePedido(escritura.IdEscritura.ToString(), p.NrPedido.ToString(), p.VlPedido.ToString(), utils.sessao.PathIniFile);
                }

                escritura.TpEscritura = 'F';
                escritura.DtSaida = DateTime.Now;
                if (escritura.DsLogin == null)
                    escritura.DsLogin = utils.sessao.UsuarioSessao.DsLogin;

                escrituraBLL.salvaEscritura(escritura);

            }
            catch (Exception ex)
            {
                utils.MessagensExcept.funMsgSistema("Erro ao Fechar Ficha\n" + ex.Message,1);
            }

        }

        private void brImportOrcamento_Click(object sender, EventArgs e)
        {
            if (!escritura.IdOrcamento.Equals(0)) {
                utils.MessagensExcept.funMsgSistema("Orçamento já atribuido a Ficha",3);
                return;
            }

            string orcamento = (Microsoft.VisualBasic.Interaction.InputBox("Informe Número do Orçamento", "Cartorio Conduru", "0", 150, 150));

            if (!orcamento.Equals("0") && !orcamento.Equals(""))
            {
                try
                {
                    escrituraBLL.importaOrcamentoEscritura(Convert.ToInt32(orcamento),
                                            escritura.IdEscritura,
                                            utils.sessao.UsuarioSessao.DsLogin);

                    carregaTodosDados();
                    utils.MessagensExcept.funMsgSistema("Informações importadas",2);

                }
                finally { 
                    
                }
            }
            
        }
       
    }
}
