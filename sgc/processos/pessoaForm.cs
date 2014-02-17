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


namespace sgc.processos
{
    public partial class pessoaForm : sgc.modeloForm
    {
        private Conexao con;
        private Pessoa pessoa;
        private PessoaBLL pessoaBLL;
        private AssinaturasBLL oAssinaturaBll;
        char operacao;
        TextBox _CpfCnpfForm= new TextBox();
        public pessoaForm(TextBox pCpfCnpj = null,char op = 'P')
        {
            con = new Conexao(Dados.strConexao);
            pessoaBLL = new PessoaBLL(con);
            oAssinaturaBll = new AssinaturasBLL(con);
            pessoa = new Pessoa();
            operacao = op;

            _CpfCnpfForm = pCpfCnpj;
            InitializeComponent();
        }

        private void carregaPessoa(Pessoa p) {
            txCpfCnpj.Text = p.NrCpfCnpj;
            cbEstado.Text = p.DsUf;
            carregaCidade(p.DsUf,p.IdCidade);
            txEmail.Text = p.DsEmail;
            txNrRG.Text = p.NrRg;
            txDtRG.Text = p.DtRgExpedicao;
            txOrgaoExp.Text = p.DsOrgaoEmissor;
            txEndereco.Text = p.DsEndereco;
            txBairro.Text = p.DsBairro;
            txMae.Text = p.NmMae;
            txPai.Text = p.NmPai;
            txNome.Text = p.NmPessoa;
            txDataNasc.Text = p.DtNascimento;
            txNrFones.Text = p.NrFones;
            cbTipoDoc.Text = p.TpDocumento;
            txDocumento.Text = p.NrDocumento;
            txDtExpedicaoDocumento.Text = p.DtExpedicaoDocumento;
            cbUfDocumento.Text = p.DsUfDocumento;
            txPaisNasc.Text = p.DsPaisNascimento;
            cbEstadoNasc.Text = p.DsUfNascimento;
            cbSexo.Text = p.DsSexo.ToString();

        }

        private void limpaCampos() {
            txCpfCnpj.Text = "";
            txNome.Text = "";
            txNrFones.Text = "";
            txEmail.Text = "";
            txDataNasc.Text = "";
            txNrRG.Text = "";
            txOrgaoExp.Text = "";
            txDtRG.Text = "";
            cbEstado.Text = "";
            carregaCidade("");
            txEndereco.Text = "";
            txBairro.Text = "";
            txPaisNasc.Text = "";
            cbEstadoNasc.Text = "";
            cbTipoDoc.Text = "";
            txDtExpedicaoDocumento.Text = "";
            cbUfDocumento.Text = "";
            txPai.Text = "";
            txMae.Text = "";
            grid.DataSource = null;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!operacao.Equals('P')) {
                MessageBox.Show("Os campos estão atribuidos a um registro.\nFavor clique no botão Cancelar antes de pesquisar uma pessoa.");
            }
            
            DataTable dados = new DataTable();

            if (txCpfCnpj.Text.Equals("") && txNome.Text.Equals("")) {
                MessageBox.Show("Digite um Nome ou CPF/CNPJ para pesquisa");
                return;
            }

            if (!txCpfCnpj.Text.Equals("")) {
                dados = pessoaBLL.buscaPessoaCpfCnpj(txCpfCnpj.Text.Replace(".", "").Replace("-", "").Replace("-", "").Replace("/", ""));
            } else if (!txNome.Text.Equals("")) {
                dados = pessoaBLL.buscaPessoaNome(txNome.Text);
            }

            if (dados.Rows.Count > 0)
            {
                grid.DataSource = dados;
            }
            else {
                MessageBox.Show("Hão há dados");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaCampos();
            txCpfCnpj.Focus();
            operacao = 'N';
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pessoa = pessoaBLL.getPessoa(grid[0, grid.CurrentRow.Index].Value.ToString());
            carregaPessoa(pessoa);
            operacao = 'A';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            operacao = 'P';
            limpaCampos();
        }


        
        private void txCpfCnpj_Leave(object sender, EventArgs e)
        {
            String campo = txCpfCnpj.Text.Replace(".", "").Replace("-", "").Replace("-", "").Replace("/", "");

            if (utils.Validacao.IsCpfCnpj(campo))
            {
                CartaoAssinatura oCartao = oAssinaturaBll.getCartaoPorCpf(campo);


                if (oCartao != null) {
                    MessageBox.Show("O cadastro será completado com informações do cartão de assinatura.\nCaso essas informações estejam desatualizadas favor corrigi-las.");

                    txNome.Text = oCartao.NmCartao;
                    txNrFones.Text = oCartao.NrFones;
                    txEmail.Text = oCartao.DsEmail;
                    txDataNasc.Text = oCartao.DtNascimento.ToString();
                    txNrRG.Text = oCartao.NrRG;
                    txOrgaoExp.Text = oCartao.DsOrgaoEmissor;
                    txDtRG.Text = oCartao.DtExpedicao.ToString();
                    txEndereco.Text = oCartao.DsEndereco;
                    txBairro.Text = oCartao.DsBairro;
                }
              
            }
            else {
                MessageBox.Show("CPF/CNPJ Inválido");
            }
            
            //if (campo.Length == 11)
            //{
            //    if (!utils.Validacao.IsCpf(campo))
            //    {
            //        MessageBox.Show("CPF Inválido");
            //    }
            //}
            //else
            //{
            //    if (!utils.Validacao.IsCnpj(campo))
            //    {
            //        MessageBox.Show("CNPJ Inválido");
            //    }
            //}


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txCpfCnpj.Text.Equals("")) {
                MessageBox.Show("Campo obrigatório: CPF CNPJ");
                return;
            }

            if (txNome.Text.Equals(""))
            {
                MessageBox.Show("Campo obrigatório: Nome");
                return;
            }

            if (cbSexo.Text.Equals("")) {
                MessageBox.Show("Campo obrigatório: Sexo");
                return;
            }


            pessoa.DsEmail = txEmail.Text;
            pessoa.DsEndereco = txEndereco.Text;
            pessoa.DsOrgaoEmissor = txOrgaoExp.Text;
            pessoa.DsUf = cbEstado.Text;
            pessoa.DsBairro = txBairro.Text;
            pessoa.DsPaisNascimento = txPaisNasc.Text;
            pessoa.DsUfDocumento = cbUfDocumento.Text;
            pessoa.DsUfNascimento = cbEstadoNasc.Text;
            pessoa.DtExpedicaoDocumento = txDtExpedicaoDocumento.Text;
            pessoa.DtRgExpedicao = txDtRG.Text;
            pessoa.NrDocumento = txDocumento.Text;

            if (cbCidade.Items.Count > 0)
            {
                pessoa.IdCidade = Convert.ToInt32(cbCidade.SelectedValue);
            }
            pessoa.DtNascimento = txDataNasc.Text;
            pessoa.NmMae = txMae.Text;
            pessoa.NmPai = txPai.Text;
            pessoa.NmPessoa = txNome.Text;
            pessoa.NrFones = txNrFones.Text;
            pessoa.NrRg = txNrRG.Text;
            pessoa.NrDocumento = txDocumento.Text;
            pessoa.TpDocumento = cbTipoDoc.Text;
            pessoa.DsSexo = Convert.ToChar(cbSexo.Text);

            if (txCpfCnpj.Text.Length <= 14)
            {
                pessoa.TpPessoa = 'F';
            }
            if (txCpfCnpj.Text.Length > 14)
            {
                pessoa.TpPessoa = 'J';
            }


            if (operacao.Equals('N') || operacao.Equals('I'))
            {
                try
                {
                    pessoa.NrCpfCnpj = txCpfCnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "");
                    pessoaBLL.salvaPessoa(pessoa);

                    MessageBox.Show("Dados Gravador");

                    if (operacao.Equals('I'))
                    {
                        this.Close();
                    }

                    operacao = 'P';
                    limpaCampos();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar dados\n" + ex.Message);
                }


            }

            if (operacao.Equals('A')) {
                try
                {
                    pessoaBLL.atualizaPessoa(pessoa);

                    MessageBox.Show("Dados atualizados");
                    operacao = 'P';
                    limpaCampos();
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro ao atualizar dados\n"+ex.Message);
                }
                
            }
        }

        private void pessoaForm_Load(object sender, EventArgs e)
        {
            if (_CpfCnpfForm != null)
            {
                if (!_CpfCnpfForm.Text.Equals(""))
                {
                    txCpfCnpj.Text = _CpfCnpfForm.Text;
                    operacao = 'I';
                    txNome.Focus();
                }
            }
        }

        private void txCpfCnpj_KeyUp(object sender, KeyEventArgs e)
        {
            string key = e.KeyValue.ToString();
            if (key != "8" && key != "37" && key != "38" && key != "39" && key != "40" && key != "46")
            {
                String Text = txCpfCnpj.Text;
                Text = Text.Replace(".", "").Replace("-","").Replace("/","").Replace("_","");
                String TextoFormato = "";
                String _Formatado = "";
                if(Text.Length <= 11){
                    TextoFormato = "{0}.{1}.{2}-{3}";
                    Text = Text.PadRight(11, '_');
                    _Formatado = String.Format(TextoFormato, Text.Substring(0, 3), Text.Substring(3, 3), Text.Substring(6, 3), Text.Substring(9, 2));
                } else {
                    TextoFormato = "{0}.{1}.{2}/{3}-{4}";
                    Text = Text.PadRight(14, '_');
                    _Formatado = String.Format(TextoFormato, 
                            Text.Substring(0, 2), 
                            Text.Substring(2, 3), 
                            Text.Substring(5, 3), 
                            Text.Substring(8, 4),
                            Text.Substring(12, 2));
                }

                txCpfCnpj.Text = _Formatado;
                int pos = _Formatado.IndexOf("_");
                if (pos >= 0)
                {
                    txCpfCnpj.Select(pos, 0);
                }
                else {
                    txCpfCnpj.Select(txCpfCnpj.Text.Length, 0);
                }
            
            }
            
        }


        private void carregaCidade(string uf,int idCidade = 0) {
            cbCidade.DataSource = pessoaBLL.getCidadesPorEstado(uf);
            cbCidade.ValueMember = "idCidade";
            cbCidade.DisplayMember = "nmCidade";
            if(!idCidade.Equals(0)){
                cbCidade.SelectedValue = idCidade;
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaCidade(cbEstado.Text);
        }
    }
}
