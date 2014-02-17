using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using BLL;


namespace sgc.auxiliares
{
    public partial class PessoaForm : Form
    {
        private Form Fpai;
        private TextBox _txCpfCnpj;
        private TextBox _txNome;
        private PessoaBLL pessoaBLL;

        public PessoaForm(Form fPai, TextBox CpfCpnjTx, TextBox NomeTx)
        {
            Fpai = fPai;
            _txCpfCnpj = CpfCpnjTx;
            _txNome = NomeTx;
            Conexao con = new Conexao(Dados.strConexao);
            pessoaBLL = new PessoaBLL(con);
            InitializeComponent();
        }

        private void PessoaForm_Load(object sender, EventArgs e)
        {
            if (_txCpfCnpj.Text.Length == 11)
                rbFisca.Checked = true;

            if (_txCpfCnpj.Text.Length == 14)
                rbJuridica.Checked = true;

            txCpfCnpj.Text = _txCpfCnpj.Text;
            txNome.Focus();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private char getTipo() { 
            char r = 'F';

            if (rbFisca.Checked)
                r = 'F';

            if(rbJuridica.Checked)
                r = 'J';

            return r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pessoaBLL.salvaPessoa(txCpfCnpj.Text,
                                  txNome.Text,
                                  getTipo(),
                                  txFones.Text,
                                  txEndereco.Text,
                                  txEmail.Text);
                MessageBox.Show("Registro Gravado!");
                _txNome.Text = txNome.Text;
                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar pessoa\n"+ex.Message);
            }
        }
    }
}
