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


namespace sgc.processos
{
    public partial class addPessoaOrcamentoForm : Form
    {
        Conexao con;
        PessoaBLL pessoaBll;
        char op;
        escrituraOrcamentoForm oFormOrcamento;
        public addPessoaOrcamentoForm(escrituraOrcamentoForm fPai)
        {
            con = new Conexao(Dados.strConexao);
            pessoaBll = new PessoaBLL(con);
            op = 'C';
            oFormOrcamento = fPai;
            InitializeComponent();
        }

        public void buscaCliente() {
            string nome = pessoaBll.pesquisaPessoa(txCpfCnpj.Text);

            if (nome == null)
            {
                MessageBox.Show("CPF/CNPJ não encontrado!\nEntre com o nome para registrar o cliente!");
                op = 'N';
            }
            else
            {
                MessageBox.Show("Cliente encontrado!");
                op = 'I';
                txNome.Text = nome;
            }
        }

        public void preencheComboTipoPessoa() {
            cbTipoPessoa.DataSource = pessoaBll.getTipoPessoa();

            cbTipoPessoa.DisplayMember = "dsTipoPessoa";
            cbTipoPessoa.ValueMember = "cdTipoPessoa";
        }


        private void btBusca_Click(object sender, EventArgs e)
        {
            buscaCliente();
        }

        private void txCpfCnpj_Leave(object sender, EventArgs e)
        {
            buscaCliente();
        }

        private void addPessoaOrcamentoForm_Load(object sender, EventArgs e)
        {
            preencheComboTipoPessoa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (op.Equals('N')) {
                if (txNome.Text.Equals("")) {
                    MessageBox.Show("Digite o nome do cliente!");
                    txNome.Focus();
                    return;
                }


                pessoaBll.salvaNomePessoa(txCpfCnpj.Text, txNome.Text);

                pessoaBll.salvaPessoaOrcamento(txCpfCnpj.Text,
                                oFormOrcamento.oOrcamento.IdOrcamento,
                                Convert.ToInt32(cbTipoPessoa.SelectedValue.ToString()));

                oFormOrcamento.atualizaGridClientes();
                this.Close();
            }

            if (op.Equals('I')) {
                pessoaBll.salvaPessoaOrcamento(txCpfCnpj.Text,
                                    Convert.ToInt32(oFormOrcamento.lbNumOrcamento.Text),
                                    Convert.ToInt32(cbTipoPessoa.SelectedValue.ToString()));

                oFormOrcamento.atualizaGridClientes();
                this.Close();
            }
        }


    }
}
