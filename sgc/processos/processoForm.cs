using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using DAO;
using BLL;
using sgc.utils;
//using Word=Microsoft.Office.Interop.Word;

namespace sgc.processos
{
    public partial class processoForm : Form
    {
        private Conexao con;
        private Selo selo;
        private SelosBLL seloBLL;
        //private TipoSeloDAO tipoSeloDAO;
        private AtoOperacaoBLL atosBLL;
        private TipoDocumentoDAO tipoDocDAO;
        private PessoaBLL pessoaBLL;
        private ProcessoBLL processoBLL;
        private Processo processo;
        private String usuario;
        private sbyte op;
        private String nrProcesso;
        private PedidoBLL pedidoBLL;
        private Provimento18BLL oProvimento;
        private int nrFolhaAto = 0;
        //private Word.Application oWord;

        public processoForm(String login, String numProcesso = "")
        {
            con = new Conexao(Dados.strConexao);
            selo = new Selo();
            seloBLL = new SelosBLL(con);
            atosBLL = new AtoOperacaoBLL(con);
            tipoDocDAO = new TipoDocumentoDAO(con.ObjCon);
            pessoaBLL = new PessoaBLL(con);
            processoBLL = new ProcessoBLL(con);
            processo = new Processo();
            pedidoBLL = new PedidoBLL(con);
            oProvimento = new Provimento18BLL(con.ObjCon);
            usuario = login;
            nrProcesso = numProcesso;
            op = 0;
            //oWord = new Word.Application();
            InitializeComponent();            
        }

        public void carregaTipoDoc(int idx = 0)
        {
            cbTipoDoc.DataSource = tipoDocDAO.getTiposDocumentos("and cdTipoDocumento between 2 and 6");
            cbTipoDoc.ValueMember = "cdTipoDocumento";
            cbTipoDoc.DisplayMember = "nmTipoDocumento";

            if (idx > 0)
            {
                cbTipoDoc.SelectedValue = idx;
            }
        }
        public void carregaAtos(int tipo, int idx)
        {
            cbAtos.DataSource = atosBLL.listaAtosPorTipo(tipo,idx,"A");
            
            if (idx > 0)
                cbAtos.SelectedValue = idx;
            
            cbAtos.ValueMember = "cdAto";
            cbAtos.DisplayMember = "dsAto";
            Refresh();
        }

        public void carregaProvimento(string provimento = "") {
            cbProvimento.DataSource = oProvimento.getProvimento();
            cbProvimento.ValueMember = "idProvimento";
            cbProvimento.DisplayMember = "nmProvimento";
            if (provimento != null)
            {
                cbProvimento.SelectedValue = provimento;
            }
            else {
                cbProvimento.Text = "Selecione";
            }
        }

        public void carregaClasseProvimento(int id = 0) {
            cbClasse.DataSource = oProvimento.getClasseProvimento(cbProvimento.SelectedValue.ToString());
            cbClasse.ValueMember = "id";
            cbClasse.DisplayMember = "descricao";
            if (id > 0)
            {
                cbClasse.SelectedValue = id;
            }
            else
            {
                cbClasse.Text = "Selecione";
            }
        }


        public void carregaSubClasseProvimento(int id = 0) {
            DataTable dados = oProvimento.getSubclasseProvimento(cbProvimento.SelectedValue.ToString(),
                    Convert.ToInt32(cbClasse.SelectedValue.ToString()));

            if (dados.Rows.Count > 0)
            {
                cbSubClasse.DataSource = dados;
                cbSubClasse.Text = "";
                cbSubClasse.ValueMember = "id";
                cbSubClasse.DisplayMember = "descricao";

                if (id > 0)
                {
                    cbSubClasse.SelectedValue = id;
                }
                else
                {
                    if (dados.Rows.Count > 0)
                    {
                        cbSubClasse.Text = "Selecione";
                    }
                }
            }
        }

        public void carregaProcesso(String numProcesso)
        {

            if (numProcesso.Length > 0)
            {
                processo = processoBLL.getProcesso(numProcesso);

                carregaTipoDoc(processo.CdTipoDocumento);
                carregaAtos(processo.CdTipoDocumento, processo.CdAto);
                carregaProvimento(processo.IdProvimento);
                carregaClasseProvimento(processo.IdClasseProvimento);
                carregaSubClasseProvimento(processo.IdSubClasseProvimento);
                
                lbNumProcesso.Text = numProcesso;
                lbNrSelo.Text = processo.NrSelo.ToString();

                txNrFolha.Text = processo.NrFolha;
                txCompFolha.Text = processo.NrFolhaComp;
                txNrLivro.Text = processo.NrLivro;
                txCompLivro.Text = processo.NrLivroComp;
                txPathDocumento.Text = processo.DsPathArquivo;
                txDtCasamento.Text = processo.DtCasamento.ToShortDateString();
                txNrFilhosMaiores.Text = processo.NrFilhosMaiores;
                cbRegimeBens.Text = processo.DsRegimeBens;

                txRefLivro.Text = processo.DsRefLivro;
                txRefLivroComp.Text = processo.DsRefLivroComp;
                txRefFolha.Text = processo.DsRefFolha;
                txRefFolhaComp.Text = processo.DsRefFolhaComp;
                cbEstadoRef.Text = processo.DsRefUfOrigem;
                if (!processo.DsRefCidade.Equals(""))
                {
                    carregaCidade(processo.DsRefUfOrigem, Convert.ToInt32(processo.DsRefCidade));
                }
                txValorDocumento.Text = processo.VlDocumento.ToString();
                txDesconhecido.Text = processo.DsDesconhecido;
                txCartorio.Text = processo.DsRefCartorio;

                if (processo.CdTipoSelo > 0)
                {
                    TipoSelo tipoSelo = seloBLL.getTipoSelo(processo.CdTipoSelo);
                    lbNrSelo.Text = processo.NrSelo.ToString() + " SERIE " + tipoSelo.NrSerie;
                }
                else
                {
                    lbNrSelo.Text = "000000 SERIE 0";
                }
                
                carregaTipoPessoa();
                carregaGridPessoa(numProcesso);
            }
            else {
                carregaProvimento();
            }


        }

        private void carregaGridPessoa(string numProcesso) {
            grid.DataSource = pessoaBLL.getPessoasProcesso(numProcesso);

            grid.Columns[0].HeaderText = "CPF/CNPJ";
            grid.Columns[0].Width = 100;
            grid.Columns[1].HeaderText = "NOME";
            grid.Columns[1].Width = 220;
            grid.Columns[2].HeaderText = "FONE";
            grid.Columns[2].Width = 80;
            grid.Columns[3].HeaderText = "FUNÇÃO";
            grid.Columns[3].Width = 120;
        }

        public void carregaTipoPessoa()
        {
            cbTipoPessoa.DataSource = pessoaBLL.getTipoPessoa(cbProvimento.SelectedValue.ToString());
            cbTipoPessoa.ValueMember = "cdTipoPessoa";
            cbTipoPessoa.DisplayMember = "dsTipoPessoa";
        }

        private void carregaCidade(string uf, int idCidade = 0)
        {
            cbCidade.DataSource = pessoaBLL.getCidadesPorEstado(uf);
            cbCidade.ValueMember = "idCidade";
            cbCidade.DisplayMember = "nmCidade";

            if (!idCidade.Equals(0))
            {
                cbCidade.SelectedValue = idCidade;
            }
        }

        private void processoForm_Load(object sender, EventArgs e)
        {
            carregaAtos(6,0);
            carregaProcesso(nrProcesso);
            carregaTipoDoc(processo.CdTipoDocumento);
        }

        private void cbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoDoc.SelectedValue != null)
            {
                if (cbTipoDoc.SelectedValue.ToString().Length == 1)
                {
                    int i = Convert.ToInt32(cbTipoDoc.SelectedValue.ToString());
                    if (processo.CdAto > 0)
                    {
                        carregaAtos(i, processo.CdAto);
                    }
                    else {
                        carregaAtos(i, 0);
                    }
                }
            }
           
        }


        private void txCPFOutorgante_KeyUp(object sender, KeyEventArgs e)
        {
            /*String id = txCPFOutorgante.Text;

            id = formatos.limpaCpfCnpj(id);

            if (txCPFOutorgante.Text.Length == 11)
            {
                txCPFOutorgante.Text = formatos.formatoCPFCNPJ(txCPFOutorgante.Text);
            }

            if (txCPFOutorgante.Text.Length == 14)
            {
                txCPFOutorgante.Text = formatos.formatoCPFCNPJ(txCPFOutorgante.Text);
            }*/
        }

        private void btAbriProcesso_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProvimento.Text.Equals("Selecione")) {
                    MessageBox.Show("Selecione um provimento");
                    return;
                }

                if (cbClasse.Text.Equals("Selecione"))
                {
                    MessageBox.Show("Selecione uma Classe");
                    return;
                }

                

                Selo selo = new Selo();
                TipoSelo tipoSelo = new TipoSelo();
                if (Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()) == 5)
                {
                    tipoSelo.CdTipoSelo = 0;
                    
                    selo.NrSelo = 0;
                    selo.CdTipoSelo = 0;
                }
                else
                {

                    #region codigo antigo
                    /*
                    if (Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()) == 4)
                    {
                        tipoSelo = seloBLL.getTipoSeloPorDocumento(2);
                    }
                    else {
                        tipoSelo = seloBLL.getTipoSeloPorDocumento(Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()));
                    }


                    if (tipoSelo == null)
                    {
                        MessageBox.Show("Não há selos disponiveis para esta operação Tipo!");
                        return;
                    }


                    selo = seloBLL.getSeloTipo(tipoSelo.CdTipoSelo);
                     */
                    #endregion

                    if (Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()) == 4)
                    {
                        selo = seloBLL.getSeloTipo(2);
                    }
                    else
                    {
                        selo = seloBLL.getSeloTipo(Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()));
                    }


                    if (selo == null)
                    {
                        MessageBox.Show("Não há selos disponiveis para esta operação!");
                        return;
                    }
                }


                panelTipoProcesso.Enabled = false;
                panelProcesso.Enabled = true;
                lbNumProcesso.Text = processoBLL.geraNumProcesso();

                int idSub = 0;

                if (cbSubClasse.Text.Equals(""))
                {
                    idSub = 0;
                }
                else {
                    Convert.ToInt32(cbSubClasse.SelectedValue.ToString());
                }

                processoBLL.novoProcesso(usuario,
                                lbNumProcesso.Text,
                                Convert.ToInt32(cbAtos.SelectedValue.ToString()),
                                Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()),
                                cbProvimento.SelectedValue.ToString(),
                                Convert.ToInt32(cbClasse.SelectedValue.ToString()),
                                idSub,
                                selo);


                //MessageBox.Show(cbTipoDoc.SelectedValue.ToString());
                if (Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()).Equals(3)) {

                    if (MessageBox.Show("Deseja vincular nº de Ficha?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes")) {
                        int nrFicha = Convert.ToInt32(
                                    (Microsoft.VisualBasic.Interaction.InputBox(
                                        "Digite o Nº da Ficha", "Cartorio Conduru", "0", 100, 100))
                                    );

                        processoBLL.setEscrituraProcesso(lbNumProcesso.Text,nrFicha);
                    }
                }


                processo = processoBLL.getProcesso(lbNumProcesso.Text);
                
                lbNrSelo.Text = processo.NrSelo.ToString() + " SERIE: " + tipoSelo.NrSerie;
                carregaProcesso(lbNumProcesso.Text);
                txCpfPessoa.Focus();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao gerar Processo.\n"+ex.Message);
            }
        }

        private void btBuscaPessoa_Click(object sender, EventArgs e)
        {
            String _cpf = txCpfPessoa.Text.Replace(".", "").Replace("-", "").Replace("/", "");
            String nome = pessoaBLL.pesquisaPessoa(_cpf);

            if (nome == null)
            {
                String msg = "Não há cliente cadastrado com esse CPF/CNPJ!\nDeseja cadastra-lo";
                DialogResult result = MessageBox.Show(msg, 
                                                        "Cadastro de Pessoa", 
                                                        MessageBoxButtons.YesNo, 
                                                        MessageBoxIcon.Question);
                if (result.ToString().Equals("Yes"))
                {

                    pessoaForm oFormPessoa = new pessoaForm(txCpfPessoa,'I');
                    oFormPessoa.ShowDialog();

                }
                else
                {
                    txCpfPessoa.Text = "";
                    txCpfPessoa.Focus();
                }
            }
            else
            {
                txNomePessoa.Text = nome;
                btRegPessoa.Enabled = true;
            }
        }

        private void txNomePessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txNomePessoa.BackColor = Color.White;

                if (op == 1)
                {
                    pessoaBLL.salvaNomePessoa(txCpfPessoa.Text, txNomePessoa.Text);
                    MessageBox.Show("Registro Salvo!");
                    op = 0;
                    btRegPessoa.Enabled = true;
                }
            }
        }

        private void btRegPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                string _cpf = txCpfPessoa.Text.Replace(".","").Replace("-","").Replace("/","");
                processoBLL.setPessoaProcesso(_cpf, lbNumProcesso.Text, Convert.ToInt32(cbTipoPessoa.SelectedValue.ToString()));
                carregaGridPessoa(lbNumProcesso.Text);
                limpaCamposPessoa();
                txCpfPessoa.Focus();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: \n"+ex.Message);
            }
        }

        private void limpaCamposPessoa() 
        {
            txCpfPessoa.Text = "";
            txNomePessoa.Text = "";
        }

        private void salvaDadosProcesso()
        {
            processo.CdAto = Convert.ToInt32(cbAtos.SelectedValue.ToString());
            processo.CdTipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue.ToString());
            processo.DsPathArquivo = txPathDocumento.Text;
            processo.NrFolha = txNrFolha.Text;
            processo.NrFolhaComp = txCompFolha.Text;
            processo.NrLivro = txNrLivro.Text;
            processo.NrLivroComp = txCompLivro.Text;
            processo.DsObservacao = txObservacao.Text;
            processo.IdProvimento = cbProvimento.SelectedValue.ToString();
            processo.IdClasseProvimento = Convert.ToInt32(cbClasse.SelectedValue.ToString());
            processo.DtEmissao = dtFinalizacao.Value;
            processo.DsRegimeBens = cbRegimeBens.Text;
            processo.NrFilhosMaiores = txNrFilhosMaiores.Text;
            if (txValorDocumento.Text.Equals(""))
            {
                processo.VlDocumento = 0;
            }
            else {
                processo.VlDocumento = Convert.ToDouble(txValorDocumento.Text);
            }

            if (!txDtCasamento.Text.Equals("  /  /"))
            {
                processo.DtCasamento = Convert.ToDateTime(txDtCasamento.Text);
            }
            
            if (cbSubClasse.Text.Equals(""))
            {
                processo.IdSubClasseProvimento = 0;
            }
            else {
                processo.IdSubClasseProvimento = Convert.ToInt32(cbSubClasse.SelectedValue.ToString());
            }

            processo.DsRefCartorio = txCartorio.Text;
            processo.DsDesconhecido = txDesconhecido.Text;
            processo.DsRefFolha = txRefFolha.Text;
            processo.DsRefFolhaComp = txRefFolhaComp.Text;
            processo.DsRefLivro = txRefLivro.Text;
            processo.DsRefLivroComp = txRefLivroComp.Text;
            processo.DsRefUfOrigem = cbEstadoRef.Text;
            processo.DsRefCidade = cbCidade.SelectedValue.ToString();


            processoBLL.setProcesso(processo);
        }

        private void btSalvaAlteracao_Click(object sender, EventArgs e)
        {
            panelTipoProcesso.Enabled = false;
            btAbriProcesso.Enabled = true;
            salvaDadosProcesso();
            MessageBox.Show("Processo Salvo!");
        }

        private void btAlterarProcesso_Click(object sender, EventArgs e)
        {
            panelTipoProcesso.Enabled = true;
            btAbriProcesso.Enabled = false;
        }

        private void txNrFolha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
              //  e.Handled = true; 
        }

        private void btAddDocumeto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                txPathDocumento.Text = open.FileName;
            }
        }

        private void btOpenDoc_Click(object sender, EventArgs e)
        {
            if (!txPathDocumento.Text.Equals(""))
            {
                System.Diagnostics.Process.Start(@txPathDocumento.Text);
            }
        }

        private void btGerarPedido_Click(object sender, EventArgs e)
        {
            Pedido p = new Pedido();

            p = processoBLL.abrePedido(usuario,lbNumProcesso.Text);

            if (p.StPedido == 'F')
            {
                MessageBox.Show("Já existe um pedido fechado para este processo.");
            }
            else if(p.StPedido == 'P')
            {
                MessageBox.Show("Já existe um pedido pago para este processo.");
            }
            else if(p.StPedido == 'A')
            {
                sessao.NrPedido = p.NrPedido;
                sessao.Processo = processo;
                ItemPedido itemPedido = new ItemPedido();
                AtoOperacao ato = new AtoOperacao();
                
                ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbAtos.SelectedValue.ToString()));
                

                itemPedido.CdAto = ato.CdAto;
                itemPedido.CdTipoSelo = processo.CdTipoSelo;
                itemPedido.NrPedido = p.NrPedido;
                itemPedido.NrProcesso = (lbNumProcesso.Text);
                itemPedido.NrSelo = processo.NrSelo;
                itemPedido.VlItem = ato.VlAto; 
                
                sessao.ItemPedido = itemPedido;

                pedidoProcesso pedidoProcesso = new pedidoProcesso();
                pedidoProcesso.MdiParent = this.MdiParent;
                pedidoProcesso.Show();
            }
            else
            {
                try
                {

                    sessao.NrPedido = p.NrPedido;
                    ItemPedido itemPedido = new ItemPedido();
                    AtoOperacao ato = new AtoOperacao();
                    ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbAtos.SelectedValue.ToString()));

                    int qtdItem = 1;
                    if (ato.CdTJAto.TrimEnd().Equals("74") || ato.CdTJAto.TrimEnd().Equals("81"))
                    {
                        qtdItem = Convert.ToInt32(
                                        (Microsoft.VisualBasic.Interaction.InputBox(
                                            "Quantidade de Folhas", "Cartorio Conduru", "1", 150, 150))
                                        );
                    }

                    itemPedido.CdAto = ato.CdAto;
                    itemPedido.CdTipoSelo = processo.CdTipoSelo;
                    itemPedido.NrPedido = p.NrPedido;
                    itemPedido.NrProcesso = (lbNumProcesso.Text);
                    itemPedido.NrSelo = processo.NrSelo;
                    itemPedido.VlItem = ato.VlAto * qtdItem;

                    pedidoBLL.gravaItemPedido(itemPedido);

                    sessao.Processo = processo;
                    sessao.ItemPedido = itemPedido;


                    pedidoProcesso pedidoProcesso = new pedidoProcesso();
                    pedidoProcesso.MdiParent = this.MdiParent;
                    pedidoProcesso.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Close();
                }
            }

            
            
        }

        private void processoForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.F2:
                    btGerarPedido_Click(null, null);
                    break;
                case Keys.F10:
                    this.Close();
                    break;

            }


        }

        private void txCpfPessoa_Leave(object sender, EventArgs e)
        {
            if (!txCpfPessoa.Text.Equals(""))
            {
                btBuscaPessoa_Click(null, null);
                txNomePessoa.Focus();
            }
        }

        private void txNomePessoa_Leave(object sender, EventArgs e)
        {
            /*
            txNomePessoa.BackColor = Color.White;

            if (op == 1)
            {
                pessoaBLL.salvaNomePessoa(txCpfPessoa.Text, txNomePessoa.Text);
                MessageBox.Show("Registro Salvo!");
                op = 0;
                btRegPessoa.Enabled = true;
            }
             */
        }

        private void btApagaPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                processoBLL.delPessoaProcesso(lbNumProcesso.Text, grid[0, grid.CurrentRow.Index].Value.ToString());
                MessageBox.Show("Registro Apagado");
                carregaGridPessoa(lbNumProcesso.Text);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btExcluirProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir esse processo?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
                {
                    //verificar se o processo já foi pago
                    if (processo.StProcesso == 'A')
                    {
                        processoBLL.excluiProcesso(processo);
                        MessageBox.Show("Processo Excluido.\nO Selo usado neste processo tornou-se disponível ser utilizado.");
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Processo já finalizado ou encerrado");
                    }

                }
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao excluir processo.\n"+ex.Message);
            }
        }

        private void btCancelarProc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedido p = new Pedido();
            p = processoBLL.getPedidoProcesso(lbNumProcesso.Text);
            if (p == null){
                MessageBox.Show("Não há pedido para este Processo");
                return;
            }

            if (p.StPedido == 'P' )
            {
                entregaDocumentoForm entregaForm = new entregaDocumentoForm(processo);
                entregaForm.ShowDialog();
            }
            else {
                MessageBox.Show("O pedido não pode ser entregue pois ainda não foi pago!");
            }


        }


        private void cbProvimento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregaClasseProvimento();
            carregaTipoPessoa();
        }

        private void cbClasse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregaSubClasseProvimento();
        }

        private void txCpfPessoa_KeyUp(object sender, KeyEventArgs e)
        {
            string key = e.KeyValue.ToString();
            if (key != "8" && key != "37" && key != "38" && key != "39" && key != "40" && key != "46")
            {
                String Text = txCpfPessoa.Text;
                Text = Text.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");
                String TextoFormato = "";
                String _Formatado = "";
                if (Text.Length <= 11)
                {
                    TextoFormato = "{0}.{1}.{2}-{3}";
                    Text = Text.PadRight(11, '_');
                    _Formatado = String.Format(TextoFormato, Text.Substring(0, 3), Text.Substring(3, 3), Text.Substring(6, 3), Text.Substring(9, 2));
                }
                else
                {
                    TextoFormato = "{0}.{1}.{2}/{3}-{4}";
                    Text = Text.PadRight(14, '_');
                    _Formatado = String.Format(TextoFormato,
                            Text.Substring(0, 2),
                            Text.Substring(2, 3),
                            Text.Substring(5, 3),
                            Text.Substring(8, 4),
                            Text.Substring(12, 2));
                }

                txCpfPessoa.Text = _Formatado;
                int pos = _Formatado.IndexOf("_");
                if (pos >= 0)
                {
                    txCpfPessoa.Select(pos, 0);
                }
                else
                {
                    txCpfPessoa.Select(txCpfPessoa.Text.Length, 0);
                }

            }
        }

        private void cbEstadoRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaCidade(cbEstadoRef.Text);
        }

        
    }
}
