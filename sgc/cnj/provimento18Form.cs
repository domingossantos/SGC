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

namespace sgc.cnj
{
    public partial class provimento18Form : Form
    {
        private Processo oProcesso;
        private ProcessoBLL oProcessoBll;
        private Provimento18BLL oProvimentoBll;
        private PessoaBLL oPessoaBll;
        private Conexao con;
        private char operacao;
        public provimento18Form()
        {
            con = new Conexao(Dados.strConexao);
            oProcessoBll = new ProcessoBLL(con);
            oProvimentoBll = new Provimento18BLL(con.ObjCon);
            oPessoaBll = new PessoaBLL(con);
            oProcesso = new Processo();
            operacao = 'P';
            InitializeComponent();
        }


        public String getProvimento() {
            String opcao = "";

            if (rbCESDI.Checked) {
                opcao = "CESDI";
            }

            if (rbCEP.Checked)
            {
                opcao = "CEP";
            }

            if (rbCRTO.Checked)
            {
                opcao = "RCTO";
            }

            return opcao;
        }

        public void carregaClasseProvimento(int id = 0)
        {
            cbClasse.DataSource = oProvimentoBll.getClasseProvimento(getProvimento());
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


        public void carregaSubClasseProvimento(int id = 0)
        {
            DataTable dados = oProvimentoBll.getSubclasseProvimento(getProvimento(),
                    Convert.ToInt32(cbClasse.SelectedValue.ToString()));

            if (dados.Rows.Count > 0)
            {
                cbSubClasse.DataSource = dados;
                cbSubClasse.Text = "";
                cbSubClasse.ValueMember = "id";
                cbSubClasse.DisplayMember = "descricao";

                if (id > 0 || id != null)
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
            else {
                cbSubClasse.DataSource = null;
            }
        }


        private void btNovo_Click(object sender, EventArgs e)
        {
            if (getProvimento().Equals("")) {
                MessageBox.Show("Selecione um tipo de provimento");
                return;
            }

            operacao = 'N';
            limpaCampos();
            cbClasse.Focus();
        }

        public void limpaCampos() {
            lbNumProcesso.Text = "0";
            carregaClasseProvimento();
            cbSubClasse.DataSource = null;
            txData.Text = "";
            txLivro.Text = "";
            txLivroComp.Text = "";
            txFolha.Text = "";
            txFolhaComp.Text = "";
            txValor.Text = "";
            txDeconhecido.Text = "";
            txCartorioRef.Text = "";
            txRefLivro.Text = "";
            txRefLivroComp.Text = "";
            txRefFolha.Text = "";
            txRefFolhaComp.Text = "";
            gridPartes.DataSource = null;
        }

        public void limpaGridPRocesso() {
            grid.DataSource = null;
        }


        public void pesquisaProvimento() {
            
        }

        private void btGrava_Click(object sender, EventArgs e)
        {

            if (operacao.Equals('P'))
            {
                MessageBox.Show("Selecione um processo para Edição ou\nInicie um novo cadastro prescionando Novo");
                return;
            }
            
            if (operacao.Equals('N'))
            {

                oProcesso.NrProceso = oProcessoBll.geraNumProcessoAntigo(txData.Text);
                lbNumProcesso.Text = oProcesso.NrProceso;
            }
            else {
                oProcesso.NrProceso = lbNumProcesso.Text;
            }


            
            oProcesso.IdProvimento = getProvimento();
            oProcesso.IdClasseProvimento = Convert.ToInt32(cbClasse.SelectedValue);
            oProcesso.StProcesso = 'T';
            if (cbSubClasse.Text.Equals(""))
            {
                oProcesso.IdSubClasseProvimento = 0;
            }
            else 
            {
                oProcesso.IdSubClasseProvimento = Convert.ToInt32(cbSubClasse.SelectedValue);
            }

            oProcesso.CdTipoDocumento = 3;
            oProcesso.CdAto = 199;
            oProcesso.DsPathArquivo = "";
            oProcesso.DsObservacao = "";
            oProcesso.DtEmissao = DateTime.Parse(txData.Text);
            oProcesso.DtInclusao = DateTime.Parse(txData.Text);
            oProcesso.NrLivro = txLivro.Text;
            oProcesso.NrLivroComp = txLivroComp.Text;
            oProcesso.NrFolha = txFolha.Text;
            oProcesso.NrFolhaComp = txFolhaComp.Text;
            oProcesso.DsDesconhecido = txDeconhecido.Text;
            oProcesso.DsRefLivro = txRefLivro.Text;
            oProcesso.DsRefLivroComp = txRefLivroComp.Text;
            oProcesso.DsRefFolha = txRefFolha.Text;
            oProcesso.DsRefFolhaComp = txRefFolhaComp.Text;
            oProcesso.DsRefUfOrigem = cbEstadoRef.Text;
            oProcesso.DsRefCartorio = txCartorioRef.Text;

         
            oProcesso.DsRefCidade = cbCidade.SelectedValue.ToString();
            
            oProcesso.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
            if (!txDtCasamento.Text.Equals("  /  /"))
            {
                oProcesso.DtCasamento = Convert.ToDateTime(txDtCasamento.Text);
            }
            oProcesso.NrFilhosMaiores = txNrFilhosMaiores.Text;
            oProcesso.DsRegimeBens = cbRegimeBens.Text;

            if (!txValor.Text.Equals(""))
            {
                oProcesso.VlDocumento = Convert.ToDouble(txValor.Text);
            }
            else {
                oProcesso.VlDocumento = 0;
            }


            oProcessoBll.setProcesso(oProcesso);

            MessageBox.Show("Processo Gravado!");
            operacao = 'P';
        }

        private void rbCRTO_Click(object sender, EventArgs e)
        {
            carregaClasseProvimento();
        }

        private void rbCEP_Click(object sender, EventArgs e)
        {
            carregaClasseProvimento();
        }

        private void rbCESDI_Click(object sender, EventArgs e)
        {
            carregaClasseProvimento();
        }

        private void cbClasse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregaSubClasseProvimento();
            carregaTipoPessoa();
        }

        private void btBuscaPessoa_Click(object sender, EventArgs e)
        {
            String _cpf = txCpfPessoa.Text.Replace(".", "").Replace("-", "").Replace("/", "");

            if (!utils.Validacao.IsCpfCnpj(_cpf))
            {
                MessageBox.Show("CPF/CNPJ inválido!");
                return;
            }



            String nome = oPessoaBll.pesquisaPessoa(_cpf);

            if (nome == null)
            {
                String msg = "Não há cliente cadastrado com esse CPF/CNPJ!\nDeseja cadastra-lo";
                DialogResult result = MessageBox.Show(msg,
                                                        "Cadastro de Pessoa",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                if (result.ToString().Equals("Yes"))
                {

                    processos.pessoaForm oFormPessoa = new processos.pessoaForm(txCpfPessoa, 'I');
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

        public void carregaTipoPessoa()
        {
            cbTipoPessoa.DataSource = oPessoaBll.getTipoPessoa(getProvimento());
            cbTipoPessoa.ValueMember = "cdTipoPessoa";
            cbTipoPessoa.DisplayMember = "dsTipoPessoa";
        }

        private void txCpfPessoa_Leave(object sender, EventArgs e)
        {
            btBuscaPessoa_Click(null, null);
        }


        private void carregaGridPessoa(string numProcesso)
        {
            gridPartes.DataSource = oPessoaBll.getPessoasProcesso(numProcesso);

            gridPartes.Columns[0].HeaderText = "CPF/CNPJ";
            gridPartes.Columns[0].Width = 100;
            gridPartes.Columns[1].HeaderText = "NOME";
            gridPartes.Columns[1].Width = 220;
            gridPartes.Columns[2].HeaderText = "FONE";
            gridPartes.Columns[2].Width = 80;
            gridPartes.Columns[3].HeaderText = "FUNÇÃO";
            gridPartes.Columns[3].Width = 120;
        }
        private void btRegPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                string _cpf = txCpfPessoa.Text.Replace(".", "").Replace("-", "").Replace("/", "");
                oProcessoBll.setPessoaProcesso(_cpf, lbNumProcesso.Text, Convert.ToInt32(cbTipoPessoa.SelectedValue.ToString()));
                carregaGridPessoa(lbNumProcesso.Text);
                txCpfPessoa.Text = "";
                txNomePessoa.Text = "";
                txCpfPessoa.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
        }


        private void carregaCidade(string uf, int idCidade = 0)
        {
            cbCidade.DataSource = oPessoaBll.getCidadesPorEstado(uf);
            cbCidade.ValueMember = "idCidade";
            cbCidade.DisplayMember = "nmCidade";

            if (!idCidade.Equals(0))
            {
                cbCidade.SelectedValue = idCidade;
            }
        }

        private void btApagaPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                oProcessoBll.delPessoaProcesso(lbNumProcesso.Text, gridPartes[0, gridPartes.CurrentRow.Index].Value.ToString());
                MessageBox.Show("Registro Apagado");
                carregaGridPessoa(lbNumProcesso.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (getProvimento().Equals("")) {
                MessageBox.Show("Selecione um tipo de provimento");
                return;
            }

            DataTable vDados = oProcessoBll.getProcessosProvimento(getProvimento(),
                                utils.formatos.formatoData(dtIni.Value.ToShortDateString(),true),
                                utils.formatos.formatoData(dtFim.Value.ToShortDateString(),true));
            if (vDados.Rows.Count <= 0)
            {
                MessageBox.Show("Não há dados a exibir");
                limpaGridPRocesso();
                return;
            }

            grid.DataSource = vDados;

            if (getProvimento().Equals("CEP"))
            {
                
            }
        }

        private void carregaProcesso(String nrProcesso) {
            oProcesso = oProcessoBll.getProcesso(nrProcesso);

            lbNumProcesso.Text = oProcesso.NrProceso;
            carregaClasseProvimento(oProcesso.IdClasseProvimento);
            carregaSubClasseProvimento(oProcesso.IdSubClasseProvimento);
            txData.Text = oProcesso.DtEmissao.ToShortDateString();
            txLivro.Text = oProcesso.NrLivro;
            txLivroComp.Text = oProcesso.NrLivroComp;
            txFolha.Text = oProcesso.NrFolha ;
            txFolhaComp.Text = oProcesso.NrFolhaComp;
            txValor.Text = oProcesso.VlDocumento.ToString();
            txDeconhecido.Text = oProcesso.DsDesconhecido;
            txCartorioRef.Text = oProcesso.DsRefCartorio;
            txRefLivro.Text = oProcesso.DsRefLivro;
            txRefLivroComp.Text = oProcesso.DsRefLivroComp;
            txRefFolha.Text = oProcesso.DsRefFolha;
            txRefFolhaComp.Text = oProcesso.DsRefFolhaComp;
            cbEstadoRef.Text = oProcesso.DsRefUfOrigem;
            carregaCidade(oProcesso.DsRefUfOrigem, Convert.ToInt32(oProcesso.DsRefCidade));
            carregaTipoPessoa();

        }

        

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            carregaProcesso(grid[0, grid.CurrentRow.Index].Value.ToString());
            carregaGridPessoa(grid[0, grid.CurrentRow.Index].Value.ToString());

            operacao = 'U';
        }

        private void provimento18Form_Load(object sender, EventArgs e)
        {
            operacao = 'P';
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (operacao.Equals('U'))
                {
                    oProcessoBll.apagaProcessoProvimento18(lbNumProcesso.Text);
                    MessageBox.Show("Processo Apagado");
                    btPesquisar_Click(null, null);
                }
            }
            catch(Exception ex){
                MessageBox.Show("Erro ao apagar Processo\n"+ex.Message);
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            impressaoCepForm oImpressaoCepForm = new impressaoCepForm(dtIni.Value.ToShortDateString(), dtFim.Value.ToShortDateString());
            oImpressaoCepForm.Show();
        }

        private void cbEstadoRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaCidade(cbEstadoRef.Text);
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
