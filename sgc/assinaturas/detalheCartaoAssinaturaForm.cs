using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;
using Modelos;


namespace sgc.assinaturas
{
    public partial class detalheCartaoAssinaturaForm : Form
    {
        private AssinaturasBLL assinaturaBLL;
        private CartaoAssinatura oCartao;
        public detalheCartaoAssinaturaForm(CartaoAssinatura cartao)
        {
            Conexao con = new Conexao(Dados.strConexao);
            assinaturaBLL = new AssinaturasBLL(con);
            oCartao = cartao;
            InitializeComponent();
        }

        private void carregaDados() {
           

        }

        private void detalheCartaoAssinaturaForm_Load(object sender, EventArgs e)
        {
            try
            {
                txDtNasc.Text = Convert.ToString(oCartao.DtNascimento).Substring(0,10);
                if (oCartao.DtRenovacao != null) {
                    txDtRenovacao.Text = Convert.ToString(oCartao.DtRenovacao).Substring(0, 10);
                }
                
                txEndereco.Text = oCartao.DsEndereco;

                txNome.Text = oCartao.NmCartao;
                txFicha.Text = oCartao.NrCartao;
                txBairro.Text = oCartao.DsBairro;
                txCidade.Text = oCartao.NmCidade;
                txCPF.Text = oCartao.NrCPF;

                if (oCartao.DtExpedicao != null)
                {
                    txDtExpedicao.Text = Convert.ToString(oCartao.DtExpedicao).Substring(0, 10); ;
                }

                txOrgaoEmissor.Text = oCartao.DsOrgaoEmissor;
                txRG.Text = oCartao.NrRG;
                txUF.Text = oCartao.SgUF;
                if (oCartao.DtCadastro != null)
                {
                    txDtCadastro.Text = Convert.ToString(oCartao.DtCadastro.ToShortDateString());
                }
                txEmail.Text = oCartao.DsEmail;
                txFone.Text = oCartao.NrFones;
                txCep.Text = oCartao.NrCEP;
                lbTIpoIdent.Text = assinaturaBLL.getDesricaoTipoRG(oCartao.CdTipoRG);
                if (oCartao.DtRenovacao != null)
                {
                    txDtRenovacao.Text = Convert.ToString(oCartao.DtRenovacao).Substring(0, 10);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro"+ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detalheCartaoAssinaturaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10) this.Close();
        }
    }
}
