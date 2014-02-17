using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using DAO;
using System.IO;
using MatrixReporter;

namespace sgc.caixa
{
    public partial class entradasRetiradasCaixaForm : Form
    {
        private Conexao con;
        private TipoMovimentoDAO tipoMovimentoDAO;
        private TipoMovimento tipoMovimento;
        private PagamentoCorrentista pagamento;
        private PagamentoCorrentistaDAO pagamentoDAO;
        private CorrentistaDAO correntistaDAO;
        private MovimentoCaixaDAO movimentoCaixaDAO;
        private Reporter imp;
        private AtoOperacaoDAO atoADO;
        public entradasRetiradasCaixaForm()
        {
            con = new Conexao(Dados.strConexao);
            tipoMovimento = new TipoMovimento();
            tipoMovimentoDAO = new TipoMovimentoDAO(con.ObjCon);
            pagamento = new PagamentoCorrentista();
            pagamentoDAO = new PagamentoCorrentistaDAO(con.ObjCon);
            correntistaDAO = new CorrentistaDAO(con.ObjCon);
            movimentoCaixaDAO = new MovimentoCaixaDAO(con.ObjCon);
            atoADO = new AtoOperacaoDAO(con.ObjCon);
            imp = new Reporter();
            InitializeComponent();
        }

        private void carregaOpcao() {
            if (rbSangria.Checked) {
                cbOpcao.DataSource = tipoMovimentoDAO.getTipoMovimentos(" and stTipoMovimento = 'D'");
                cbOpcao.DisplayMember = "des_movimento";
                cbOpcao.ValueMember = "cdTipoMovimento";
                
            }

            if (rbOutros.Checked) {
                cbOpcao.DataSource = tipoMovimentoDAO.getTipoMovimentos(" and stTipoMovimento = 'R'");
                cbOpcao.DisplayMember = "des_movimento";
                cbOpcao.ValueMember = "cdTipoMovimento";
            }

            if (rbCorrentista.Checked) {
                cbOpcao.DataSource = correntistaDAO.getCorrentistas();
                cbOpcao.DisplayMember = "nmNome";
                cbOpcao.ValueMember = "nrCPFCNPJ";
            }
            cbOpcao.Focus();
        }

        private void rbCorrentista_Click(object sender, EventArgs e)
        {
            carregaOpcao();
        }

        private void rbSangria_Click(object sender, EventArgs e)
        {
            carregaOpcao();
        }

        private void rbOutros_Click(object sender, EventArgs e)
        {
            carregaOpcao();
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

        private void txValor_KeyDown(object sender, KeyEventArgs e)
        {
            /*
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
                txValor.Text = "";
            }
            if (str.Length == 1)
            {
                txValor.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txValor.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txValor.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
             * */
        }


        private void btConfirmar_Click(object sender, EventArgs e)
        {
            // Reristra pagamento correntista
            con.ObjCon.Open();
            SqlTransaction trans = con.ObjCon.BeginTransaction();

            sgc.utils.IniFile iniFile = new sgc.utils.IniFile(utils.sessao.PathIniFile);
            bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));
            string mensagem = "";
            if (arquivo)
            {
                if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                {
                    File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }
            }

            


            if (rbCorrentista.Checked) 
            {
                try
                {
                    MovimentoCaixa movimento = new MovimentoCaixa();

                    movimento.IdHitoricoCaixa = utils.sessao.Historico.IdHistoricocaixa;
                    movimento.IdTipoMovimento = utils.sessao.IdPedidoPagtoCorrentista;
                    movimento.NrCaixa = utils.sessao.Historico.NrCaixa;
                    movimento.TpOperacao = 'C';
                    movimento.VlMovimento = Convert.ToDouble(txValor.Text.Replace("R$", ""));
                    movimento.DsLogin = utils.sessao.Historico.DsLogin;
                    movimento.DsLoginAutDesconto = "";
                    movimento.NrPedido = 0;
                    movimento.VlDesconto = 0;
                    movimento.TpPagamento = 1;
                    
                    movimentoCaixaDAO.addMovimentoCaixa(movimento, trans);


                    pagamento.DtPagamentoCorrentista = DateTime.Now;
                    pagamento.IdMovimento = movimento.IdMovimentoCaixa;
                    pagamento.NrCPFCNPJ = cbOpcao.SelectedValue.ToString();
                    pagamento.VlPagamentoCorrentista = Convert.ToDouble(txValor.Text.Replace("R$", ""));

                    pagamentoDAO.addPagamentoCorrentista(pagamento, trans);


                    mensagem = "Recebemos os valores abaixo descritos do Sr(a).";

                    
                    MessageBox.Show("Pagamento registrado.\nImprimindo Recibo.");
                    trans.Commit();

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Erro ao registrar pagamento.\n" + ex.Message);
                }
                finally {
                    con.ObjCon.Close();
                }

            }

            if (rbSangria.Checked)
            {
                try
                {
                    MovimentoCaixa movimento = new MovimentoCaixa();

                    AtoOperacao ato = getAtoPlano(cbOpcao.SelectedValue.ToString(),trans);

                    movimento.IdHitoricoCaixa = utils.sessao.Historico.IdHistoricocaixa;
                    movimento.IdTipoMovimento = ato.CdAto;
                    movimento.NrCaixa = utils.sessao.Historico.NrCaixa;
                    movimento.TpOperacao = ato.TpAto;
                    movimento.VlMovimento = Convert.ToDouble(txValor.Text.Replace("R$", ""));
                    movimento.DsLogin = utils.sessao.Historico.DsLogin;
                    movimento.DsLoginAutDesconto = "";
                    movimento.NrPedido = 0;
                    movimento.VlDesconto = 0;
                    
                    
                    mensagem = "SANGRIA DE CAIXA: ";

                    movimentoCaixaDAO.addMovimentoCaixa(movimento, trans);

                    MessageBox.Show("Pagamento registrado.");
                    trans.Commit();

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Erro ao registrar pagamento.\n" + ex.Message);
                }
                finally
                {
                    con.ObjCon.Close();
                }

            }

            if (rbOutros.Checked)
            {
                try
                {
                    MovimentoCaixa movimento = new MovimentoCaixa();
                    AtoOperacao ato = getAtoPlano(cbOpcao.SelectedValue.ToString(), trans);

                    movimento.IdHitoricoCaixa = utils.sessao.Historico.IdHistoricocaixa;
                    movimento.IdTipoMovimento = ato.CdAto;
                    movimento.NrCaixa = utils.sessao.Historico.NrCaixa;
                    movimento.TpOperacao = ato.TpAto;
                    movimento.VlMovimento = Convert.ToDouble(txValor.Text.Replace("R$",""));
                    movimento.DsLogin = utils.sessao.Historico.DsLogin;
                    movimento.DsLoginAutDesconto = "";
                    movimento.NrPedido = 0;
                    movimento.VlDesconto = 0;
                    

                    movimentoCaixaDAO.addMovimentoCaixa(movimento, trans);
                    mensagem = "OUTROS PAGAMENTOS: ";
                    MessageBox.Show("Pagamento registrado.");
                    trans.Commit();

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Erro ao registrar pagamento.\n" + ex.Message);
                }
                finally
                {
                    con.ObjCon.Close();
                }
            }
            imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
            imp.StartJob();
            imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
            imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
            imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
            imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
            imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));
            imp.PrintText(6, 1, "################### RECIBO ####################");
            imp.PrintText(7, 1, mensagem);
            imp.PrintText(8, 1, "OBS.: "+txObservacao.Text);
            imp.PrintText(9, 1, cbOpcao.Text);
            imp.PrintText(10, 1, "");
            imp.PrintText(11, 1, "VALOR:");
            imp.PrintText(12, 30, txValor.Text.PadLeft(8, ' '));
            imp.PrintText(13, 1, "Impresso em........: " + DateTime.Now.ToShortDateString());
            imp.PrintText(14, 1, "Recebido por.......: " + utils.sessao.UsuarioSessao.NmUsuario);
            int x = 14;
            int qtdLinhas = Convert.ToInt32(iniFile.IniReadValue("FBOLETO", "QTDFIM"));

            for (int i = 0; i < qtdLinhas; i++)
            {
                imp.PrintText(x++, 1, "");
            }

            imp.PrintJob();
            con.ObjCon.Close();
            this.Close();
            this.Dispose();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44){
                e.Handled = true;
            }
        }

        private AtoOperacao getAtoPlano(string cdPlano,SqlTransaction trans) {

            AtoOperacao ato = atoADO.getAtoOperacaoPlano(cdPlano,trans);

            return ato;
        }

        private void txValor_Leave(object sender, EventArgs e)
        {
            double valor = Convert.ToDouble(txValor.Text.Replace("R$",""));
            txValor.Text = String.Format("R$ {0:N2}", valor);
        }

    }
}
