using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sgc.utils;
using Modelos;
using DAO;
using BLL;
using MatrixReporter;

namespace sgc.caixa
{
    public partial class caixaForm : Form
    {
        public string str;
        private PedidoBLL pedidoBLL;
        private CaixaBLL caixaBLL;
        private EscrituraBLL escrituraBLL;
        private Conexao con;
        private Pedido p;
        private double valor = 0;
        private Reporter impressora;
        private EpsonCodes pc;
        private string dsLoginDesconto;
        private UsuarioBLL usuarioBLL;
        private char stDesconto = 'N';
        public caixaForm()
        {
            con = new Conexao(DAO.Dados.strConexao);
            pedidoBLL = new PedidoBLL(con);
            caixaBLL = new CaixaBLL(con);
            usuarioBLL = new UsuarioBLL(con);
            escrituraBLL = new EscrituraBLL(con);
            p = null;
            impressora = new Reporter();
            pc = new EpsonCodes();
            dsLoginDesconto = "";
            InitializeComponent();
        }

        #region Formatação de campo texto tipo moeda

        private void txPago_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void txValorDesconto_KeyDown(object sender, KeyEventArgs e)
        {

          
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

        private void txPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }

            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0){
                btPagamento.Focus();
            }
        }

        private void txTroco_KeyDown(object sender, KeyEventArgs e)
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
                txTroco.Text = "";
            }
            if (str.Length == 1)
            {
                txTroco.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txTroco.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txTroco.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
        }

        private void txDesconto_KeyDown(object sender, KeyEventArgs e)
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
                txDesconto.Text = "";
            }

            if (str.Length == 1)
            {
                txDesconto.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txDesconto.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txDesconto.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }

        }

        private void txTotal_KeyDown(object sender, KeyEventArgs e)
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
                txTotal.Text = "";
            }
            if (str.Length == 1)
            {
                txTotal.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txTotal.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txTotal.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
        }

        private void txTroco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44) {
                e.Handled = true;
            }
        }
        #endregion

        private void caixaForm_Shown(object sender, EventArgs e)
        {
            txPedido.Focus();
        }


        private void limparDados()
        {
            txPedido.Text = "";
            txPago.Text = "";
            txTotal.Text = "";
            txTroco.Text = "";
            txDesconto.Text = "";
            grid.Rows.Clear();
            lbPedidos.Text = "0;";
            txPedido.Focus();
            valor = 0;
            rbDinheiro.Checked = true;
            str = "";
            txUltmoPedido.Text = "";
            txUltmoPedido.Visible = false;
            btProcurarPedido.Visible = false;
            txNrEscritura.Text = "";
            gbEscritura.Visible = false;
            txAgencia.Text = "";
            txBanco.Text = "";
            txContaCorrente.Text = "";
            txDtResgate.Text = "";
            txRG.Text = "";
            ckPedidosMulti.Checked = false;
        }

        private void carregaCorrentista()
        {
            cbCorrentista.DataSource = caixaBLL.getCorrentistas();
            cbCorrentista.ValueMember = "nrCPFCNPJ";
            cbCorrentista.DisplayMember = "nmNome";

        }

        private void setTipoPagamento(int i) 
        {
            switch (i)
            {
                case 1:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = false;
                    break;
                case 2:
                    gbCorrentista.Visible = true;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = false;
                    break;
                case 3:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = true;
                    gbEscritura.Visible = false;
                    break;
                case 4:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = true;
                    break;
                default:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = false;
                    break;
            }
        }

        private int getTipoPagamento()
        {
            int t = 0;

            if (rbDinheiro.Checked)
                t = 1;
            else if (rbCorrentista.Checked)
                t = 2;
            else if (rbCheque.Checked)
                t = 3;
            else if (rbClienteEscritura.Checked)
                t = 4;
            else if (rbDeposito.Checked)
                t = 5;

            return t;
        }

        private void btProcurar_Click(object sender, EventArgs e)
        {
            if (txPedido.Text.Equals("")) {
                MessageBox.Show("Dgite um No. de Pedido");
                txPedido.Focus();
                return;
            }

            if (grid.RowCount > 0) {
                if (!ckPedidosMulti.Checked)
                {
                    MessageBox.Show("Já existem pedidos relacionados!");
                    return;
                }
            }


            p = pedidoBLL.getUltimoPedido(txPedido.Text);
            if (p == null)
            {
                MessageBox.Show("Pedido não encontrado!");
                return;
            }

            switch (p.StPedido)
	        {
                case 'C':
                    MessageBox.Show("Pedido Cancelado!");
                    txPedido.Focus();
                    return;
		        break;
                case 'A':
                    MessageBox.Show("Pedido Aberto!");
                    txPedido.Focus();
                    return;
                break;
                case 'P':
                    MessageBox.Show("Pedido já pago!");
                    txPedido.Focus();
                    return;
                break;
	        }


            if (lbPedidos.Text.Contains(txPedido.Text))
            {
                MessageBox.Show("Pedido já está relacionado!");
                txPedido.Focus();
                return;
            }

            lbPedidos.Text += txPedido.Text + ";";
            String[] pedidos = lbPedidos.Text.Split(new char[] { ';' });
            List<int> lPedidos = new List<int>();
            
            int i;
            for (i = 1; i < pedidos.Length - 1; i++)
            {
                lPedidos.Add(Convert.ToInt32(pedidos[i]));
            }

            try
            {
                DataTable dados = pedidoBLL.getItensPedidosImpressao(lPedidos);
                DataView dvDados = new DataView(dados);
                DataRow drDados;

                grid.Rows.Clear();

                for (int x = 0; x < dvDados.Count; x++)
                {
                    drDados = dvDados[x].Row;
                    grid.Rows.Add(drDados[0], drDados[1], String.Format("{0:N2}", drDados[2]), String.Format("{0:N2}", drDados[3]));
                }

                txTotal.Text = String.Format("{0:N2}", utils.formatos.getSomaCampoGrid(grid, 3));
                txPago.Focus();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro ao pesquisar pedido.\n"+ex.Message);
            }
        }

        private void txPago_Leave(object sender, EventArgs e)
        {
            if (!txPago.Text.Equals(""))
            {

                txPago.Text = txPago.Text.Replace("R$", "");
                txTotal.Text = txTotal.Text.Replace("R$", "");    

                double pago = Convert.ToDouble(utils.formatos.getValorCampoNumerico(txPago.Text));
                double valor = Convert.ToDouble(utils.formatos.getValorCampoNumerico(txTotal.Text));


                txPago.Text = String.Format("R$ {0:N2}", pago);
                txTotal.Text = String.Format("R$ {0:N2}", valor);
                if (pago < valor)
                {
                    MessageBox.Show("Valor informato é menor que o necessário.");
                    txPago.Focus();
                    return;
                }
                else
                {
                    txTroco.Text = String.Format("R$ {0:N2}", (pago - valor));
                }
            }
        }

        private void btPagamento_Click(object sender, EventArgs e)
        {
            if (!caixaBLL.getCaixaDia(utils.sessao.UsuarioSessao.DsLogin))
            {
                MessageBox.Show("Você não pode registrar pagamentos sem\nantes fechar o caixa do dia anterior!");
                return;
            }



            if (!MessageBox.Show("Deseja efetuar esse pagamento?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
            {
                MessageBox.Show("Pagamento Cancelado!");
                return;
            }


            if (txPago.Text.Equals(""))
            {
                MessageBox.Show("Informe valor de pagamento");
                txPago.Focus();
                return;
            }

            String[] pedidos = lbPedidos.Text.Split(new char[] { ';' });

            if (pedidos.Length == 2)
            {
                MessageBox.Show("Digite numero do pedido");
                txPedido.Focus();
                return;
            }

            if (Convert.ToDouble(txPago.Text.Replace("R$", "")) < Convert.ToDouble(txTotal.Text.Replace("R$", "")))
            {
                MessageBox.Show("Valor de pagamento não pode ser menor que o\nvalor total do pedido.");
                txPago.Focus();
                return;
            }

            string nmCorrentista = "";
            if (getTipoPagamento() == 2)
            {
                if (cbCorrentista.SelectedValue == null) 
                {
                    MessageBox.Show("Selecione um Correntista!");
                    cbCorrentista.Focus();
                    return;
                }
            }

            if (getTipoPagamento() == 3)
            {
                if (txBanco.Text.Equals("") || txAgencia.Text.Equals("") || txNrCheque.Text.Equals("") || txContaCorrente.Text.Equals(""))
                {
                    MessageBox.Show("Preencha as informações do cheque");
                    txBanco.Focus();
                    return;
                }
            }

            if (getTipoPagamento() == 5)
            {
                if (txBanco.Text.Equals("") || txAgencia.Text.Equals("") || txContaCorrente.Text.Equals(""))
                {
                    MessageBox.Show("Preencha as informações do Deposito");
                    txBanco.Focus();
                    return;
                }
            }

            string nmBoleto = (Microsoft.VisualBasic.Interaction.InputBox("Nome impresso no boleto", "Cartorio Conduru", "0", 150, 150));

            double vlPago = Convert.ToDouble(txPago.Text.Replace("R$", ""));

            List<int> lPedidos = new List<int>();
                       
            int i;
            for (i = 1; i < pedidos.Length -1; i++)
            {
                pedidoBLL.pagaPedido(Convert.ToInt32(pedidos[i]),sessao.Historico,getTipoPagamento());
                lPedidos.Add(Convert.ToInt32(pedidos[i]));   
            }

            
            MovimentoCaixa movimento = new MovimentoCaixa();

            movimento.IdHitoricoCaixa = sessao.Historico.IdHistoricocaixa;
            movimento.DtMovimento = DateTime.Now;
            movimento.DsLogin = sessao.UsuarioSessao.DsLogin;
            movimento.IdTipoMovimento = sessao.CdAtoPedido;
            movimento.NrCaixa = sessao.NrCaixa;
            movimento.NrPedido = lPedidos[0];
            movimento.TpOperacao = 'C';
            movimento.TpPagamento = getTipoPagamento();
            movimento.VlMovimento = Convert.ToDouble(txTotal.Text.Replace("R$", ""));


            if (txDesconto.Text.Equals(""))
                txDesconto.Text = "0";

            movimento.VlDesconto = Convert.ToDouble(txDesconto.Text.Replace("R$", ""));
            movimento.DsLoginAutDesconto = dsLoginDesconto;

            caixaBLL.salvaMovimento(movimento);

            for (i = 1; i < lPedidos.Count; i++)
            {
                movimento.IdHitoricoCaixa = sessao.Historico.IdHistoricocaixa;
                movimento.DtMovimento = DateTime.Now;
                movimento.DsLogin = sessao.UsuarioSessao.DsLogin;
                movimento.IdTipoMovimento = sessao.CdAtoPedido;
                movimento.NrCaixa = sessao.NrCaixa;
                movimento.NrPedido = lPedidos[i];
                movimento.TpOperacao = 'C';
                movimento.TpPagamento = getTipoPagamento();
                movimento.VlMovimento = 0;

                txDesconto.Text = "0";

                movimento.VlDesconto = 0;
                movimento.DsLoginAutDesconto = "";
                caixaBLL.salvaMovimento(movimento);
            }

            //Verifica se o pedid vem da escritura
            for (int n = 0; n < lPedidos.Count; n++)
            {
                DataTable dadosItens = new DataTable();
                dadosItens = pedidoBLL.getItensPedidos(Convert.ToInt32(lPedidos[n]));

                DataView dvDados = new DataView(dadosItens);
                DataRow drDados;
                for (int m = 0; m < dvDados.Count; m++)
                {
                    drDados = dvDados[m].Row;
                    if (!drDados["idMovimentoBanco"].ToString().Equals("")) {
                        escrituraBLL.alteraStatusMovimento(Convert.ToInt32(drDados["idMovimentoBanco"].ToString()), 'P');
                    } 
                }
            }
            


            if (getTipoPagamento() == 2)
            {
                PedidoCorrentista pedidoCorrentista = new PedidoCorrentista();
                pedidoCorrentista.DtPedido = movimento.DtMovimento;
                pedidoCorrentista.DsAutorizacao = "";
                pedidoCorrentista.NrCPFCNPJ = cbCorrentista.SelectedValue.ToString();
                pedidoCorrentista.StPedido = 'A';
                pedidoCorrentista.VlPedido = movimento.VlMovimento;
                pedidoCorrentista.NrPedido = movimento.NrPedido;
                nmCorrentista = cbCorrentista.Text;
                caixaBLL.salvaPedidoCorrentista(pedidoCorrentista);
            }

            if (getTipoPagamento() == 3)
            {
                Cheque cheque = new Cheque();
                cheque.DtCheque = Convert.ToDateTime(txDtResgate.Text);
                cheque.NrPedido = movimento.NrPedido;
                cheque.NrRG = txRG.Text;
                cheque.StCheque = 'A';
                cheque.NrCheque = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txNrCheque.Text));
                cheque.NrBanco = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txBanco.Text));
                cheque.NrAgencia = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txAgencia.Text));
                cheque.NrConta = utils.formatos.getValorCampoNumerico(txContaCorrente.Text);
                cheque.StDeposito = 'C';

                caixaBLL.salvaCheque(cheque);

            }

            if (getTipoPagamento() == 4)
            {
                for (int x = 0; x < lPedidos.Count; x++)
                {
                    DataTable dadosItens = new DataTable();
                    dadosItens =  pedidoBLL.getItensPedidos(Convert.ToInt32(lPedidos[x]));

                    DataView dvDados = new DataView(dadosItens);
                    DataRow drDados;
                    for (int y = 0; y < dvDados.Count; y++){
                        drDados = dvDados[y].Row;
                        MovimentoDeposito movimentoDp = new MovimentoDeposito();
                        movimentoDp.IdEscritura = Convert.ToInt32(txNrEscritura.Text);
                        movimentoDp.CdAto = Convert.ToInt32(drDados["cdAto"].ToString());
                        movimentoDp.VlMovimento = Convert.ToDouble(drDados["vlItem"].ToString());
                        movimentoDp.DsMovimento = "PAGAMENTO CAIXA";
                        movimentoDp.DtMovimento = DateTime.Now;
                        movimentoDp.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                        movimentoDp.TpMovimento = 'D';
                        movimentoDp.StRegistro = 'P';
                        escrituraBLL.solicitaPagamento(movimentoDp);
                    }
                    
                }
            }

            if (getTipoPagamento() == 5)
            {
                Cheque cheque = new Cheque();
                cheque.DtCheque = Convert.ToDateTime(txDtResgate.Text);
                cheque.NrPedido = movimento.NrPedido;
                cheque.NrRG = "";
                cheque.StCheque = 'P';
                cheque.NrCheque = 0;
                cheque.NrBanco = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txBanco.Text));
                cheque.NrAgencia = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txAgencia.Text));
                cheque.NrConta = utils.formatos.getValorCampoNumerico(txContaCorrente.Text);
                cheque.StDeposito = 'D';

                caixaBLL.salvaCheque(cheque);

            }
            ckPedidosMulti.Checked = false;
            pedidoBLL.imprimePedido(lPedidos,
                                    sessao.NrCaixa, 
                                    nmBoleto, 
                                    sessao.PathIniFile,
                                    sessao.UsuarioSessao.NmUsuario,
                                    getTipoPagamento(),
                                    vlPago,
                                    nmCorrentista);

            MessageBox.Show("Pedido(s) Pago(s)!\nImprimindo Recibo.");
            
            limparDados();
        }

        private void caixaForm_Load(object sender, EventArgs e)
        {
            abreCaixa();
            carregaCorrentista();
            gbCorrentista.Visible = false;
        }

        private void abreCaixa()
        {
            /*
            string strCaixa = "0";
            HistoricoCaixa historico = null;
            if (sessao.NrCaixa ==  0)
                {
                    strCaixa = (Microsoft.VisualBasic.Interaction.InputBox("No. do Caixa", "Cartorio Conduru", "0", 150, 150));
                    
                        if (strCaixa.Equals("0"))
                        {
                            MessageBox.Show("Informe No. do Caixa");
                            abreCaixa();
                            return;
                        }

                        if (strCaixa.Equals("")) {
                            this.Close();
                        }

                }

            if (!caixaBLL.getCaixaFechado(Convert.ToInt16(strCaixa)))
            {
                historico = new HistoricoCaixa();

                historico = caixaBLL.getUltimoHistorioPorCaixa(Convert.ToInt32(strCaixa));
                if (!historico.DsLogin.Equals(sessao.UsuarioSessao.DsLogin))
                {
                    MessageBox.Show("Caixa No. " + strCaixa + " aberto pelo usuário " + historico.DsLogin + "\nFavor utilizar outro no. de caixa.");
                    this.Close();
                    this.Dispose();
                    return;
                }
                else
                {
                    if (historico.DtAbertura.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        MessageBox.Show("Este caixa esta aberto desde o dia " + historico.DtAbertura.ToShortDateString() + "\nFavor feche-o para então utilizá-lo novamente.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Caixa já aberto.");
                        panel2.Enabled = true;
                        panel1.Enabled = true;
                        sessao.Historico = historico;
                        sessao.NrCaixa = Convert.ToInt32(strCaixa);
                    }
                }
            }
            else
            {
                historico = new HistoricoCaixa();

                historico.DsLogin = sessao.UsuarioSessao.DsLogin;
                historico.DtAbertura = DateTime.Now;
                historico.NrCaixa = Convert.ToInt32(strCaixa);
                
                caixaBLL.abreCaixa(historico);

                string vlCaixa = (Microsoft.VisualBasic.Interaction.InputBox("Valor de Abertura de Caixa", "Cartorio Conduru", "0", 150, 150));

                if (vlCaixa != "")
                {
                    MovimentoCaixa movimento = new MovimentoCaixa();

                    movimento.IdHitoricoCaixa = historico.IdHistoricocaixa;
                    movimento.IdTipoMovimento = 4;
                    movimento.NrCaixa = historico.NrCaixa;
                    movimento.TpOperacao = 'C';
                    movimento.VlMovimento = Convert.ToDouble(vlCaixa);
                    movimento.DsLogin = historico.DsLogin;
                    movimento.DsLoginAutDesconto = dsLoginDesconto;
                    movimento.NrCaixa = historico.NrCaixa;
                    movimento.NrPedido = 0;
                    movimento.VlDesconto = 0;

                    caixaBLL.salvaMovimento(movimento);
                }
                sessao.NrCaixa = historico.NrCaixa;
                sessao.Historico = historico;
                panel2.Enabled = true;
                panel1.Enabled = true;
            } */
        }

        private void caixaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sessao.NrCaixa = 0;
        }

        private void caixaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                btPagamento_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                btReimprimir_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.O)
            {
                btRetiradas_Click(null, null);
            }
            if (e.KeyCode == Keys.F5)
            {
                btDesconto_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                if (ckPedidosMulti.Checked)
                {
                    ckPedidosMulti.Checked = false;
                    txUltmoPedido.Visible = false;
                    btProcurarPedido.Visible = false;
                }
                else
                {
                    txUltmoPedido.Visible = true;
                    ckPedidosMulti.Checked = true;
                    btProcurarPedido.Visible = true;
                    txUltmoPedido.Focus();
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                rbDinheiro.Checked = true;
            }
            if (e.KeyCode == Keys.F7)
            {
                rbCorrentista.Checked = true;
            }
            if (e.KeyCode == Keys.F8)
            {
                rbCheque.Checked = true;
            }
            if (e.KeyCode == Keys.F9)
            {
                rbClienteEscritura.Checked = true;
            }
            if (e.KeyCode == Keys.F11)
            {
                rbDeposito.Checked = true;
            }
            if (e.KeyCode == Keys.Escape) {
                limparDados();
            }
            if (e.KeyCode == Keys.F2)
            {
                btFecharCaixa_Click(null, null);
            }
        }


        private void btFecharCaixa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Fechar este Caixa?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
            {

                if (caixaBLL.getCaixaDia(sessao.UsuarioSessao.DsLogin))
                {
                    caixaBLL.fechaCaixa(sessao.UsuarioSessao.DsLogin);
                    MessageBox.Show("Caixa Fechado\nIniciando impressão!");
                    try
                    {
                        HistoricoCaixa historico = caixaBLL.getUltimoHistorioPorUsuario(sessao.UsuarioSessao.DsLogin);

                        pedidoBLL.imprimeFechamentoCaixa(sessao.PathIniFile, historico);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao imprimir fechamento do caixa.\n" + ex.Message);
                    }
                }
            }   
        }

        private void btReimprimir_Click(object sender, EventArgs e)
        {
            string nrPedido = (Microsoft.VisualBasic.Interaction.InputBox("Digite no. do pedido", "Cartorio Conduru", "0", 150, 150));
            
            if (nrPedido != "")
            {
                List<int> lPedidos = new List<int>();
                lPedidos.Add(Convert.ToInt32(nrPedido));

                pedidoBLL.imprimePedido(lPedidos, sessao.NrCaixa, "Reimpressao", sessao.PathIniFile, sessao.UsuarioSessao.NmUsuario,0,0,"",true);
                MessageBox.Show("Pedido enviado a impressora!");
            }
        }


       

      
        private void rbDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
        }

        private void rbCorrentista_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
        }

        private void rbCheque_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
            gbCheque.Text = "Cheque";
            txRG.Enabled = true;
            txNrCheque.Enabled = true;
        }

        private void txPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                btProcurar_Click(null, null);
            }
        }

        #region Tratamento de Desconto
        /// <summary>
        /// Trata a concessão de desconto a um pedido
        /// </summary>
       
        private void btCancelarDesc_Click(object sender, EventArgs e)
        {
            gbDesconto.Visible = false;
            str = "";
            txLogin.Text = "";
            txSenha.Text = "";
            txValorDesconto.Text = "";
        }

        #endregion

        private void brGravarDesc_Click(object sender, EventArgs e)
        {
            if (txLogin.Text.Equals(""))
            {
                MessageBox.Show("Digite o nome de Usuário");
                txLogin.Focus();
                return;
            }

            if (txSenha.Text.Equals(""))
            {
                MessageBox.Show("Digite uma senha");
                txSenha.Focus();
                return;
            }

            if (txValorDesconto.Text.Equals(""))
            {
                MessageBox.Show("Digite um valor de desconto");
                txValorDesconto.Focus();
                return;
            }

            Usuario ususario = usuarioBLL.login(txLogin.Text);
            string senha = txSenha.Text;

            if (ususario.VlSenha.Equals(senha))
            {

                if (stDesconto.Equals('D'))
                {
                    dsLoginDesconto = ususario.DsLogin;

                    double valorDesconto = 0;

                    if (rbTipoPercent.Checked)
                    {
                        valorDesconto = Convert.ToDouble(txTotal.Text) * (Convert.ToDouble(txValorDesconto.Text) / 100);
                    }
                    else
                    {
                        valorDesconto = Convert.ToDouble(txValorDesconto.Text);
                    }


                    if (rbTipoDinheiro.Checked && (valorDesconto > Convert.ToDouble(txTotal.Text)))
                    {
                        MessageBox.Show("Valor de desconto não pode ser maior que o valor a pagar!");
                        txValorDesconto.Focus();
                        return;
                    }

                    txTotal.Text = System.Math.Round((Convert.ToDouble(txTotal.Text) - valorDesconto), 2).ToString();
                    txDesconto.Text = System.Math.Round(valorDesconto, 2).ToString();

                    txPago.Focus();

                    gbDesconto.Visible = false;
                    stDesconto = 'N';
                    str = "";
                    txLogin.Text = "";
                    txSenha.Text = "";
                    txValorDesconto.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Usuário não encontrado!");
                txLogin.Focus();
            }
        }

        private void btDesconto_Click(object sender, EventArgs e)
        {
            gbDesconto.Text = "Autorizar Desconto";
            gbDesconto.Visible = true;
            txLogin.Focus();
            stDesconto = 'D';
        }

        private void btRetiradas_Click(object sender, EventArgs e)
        {
            entradasRetiradasCaixaForm entRetCaixaForm = new entradasRetiradasCaixaForm();
            entRetCaixaForm.ShowDialog();
        }

        private void ckPedidosMulti_Click(object sender, EventArgs e)
        {
            
        }

        private void ckPedidosMulti_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPedidosMulti.Checked)
            {
                txUltmoPedido.Visible = true;
                btProcurarPedido.Visible = true;
            }
            else
            {
                txUltmoPedido.Visible = false;
                btProcurarPedido.Visible = false;
            }
        }

        private void btProcurarPedido_Click(object sender, EventArgs e)
        {
            DataTable dados = null;
            DataView dvDados = null;
            DataRow drDados;
            int i;
            dados = pedidoBLL.getPedidosMulti(utils.sessao.UsuarioSessao.DsLogin, Convert.ToInt32(txPedido.Text), Convert.ToInt32(txUltmoPedido.Text));
            dvDados = new DataView(dados);

            if (dvDados.Count > 0) {
                limparDados();
            }

            for (i = 0; i < dvDados.Count; i++)
            {
                drDados = dvDados[i].Row;
                lbPedidos.Text += drDados[0].ToString() + ";";
            }

            String[] pedidos = lbPedidos.Text.Split(new char[] { ';' });
            List<int> lPedidos = new List<int>();

            
            for (i = 1; i < pedidos.Length - 1; i++)
            {
                lPedidos.Add(Convert.ToInt32(pedidos[i]));
            }

            dados = pedidoBLL.getItensPedidosImpressao(lPedidos);
            dvDados = new DataView(dados);
            

            for (i = 0; i < dvDados.Count; i++)
            {
                drDados = dvDados[i].Row;
                grid.Rows.Add(drDados[0], drDados[1], String.Format("{0:N2}", drDados[2]), String.Format("{0:N2}", drDados[3]));

                valor += Convert.ToDouble(drDados[3].ToString());
            }

            txTotal.Text = String.Format("{0:N2}", valor);

            txPago.Focus();
        }

        private void txUltmoPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                btProcurarPedido_Click(null, null);
            }
        }

        private void btVerificaSaldo_Click(object sender, EventArgs e)
        {
            if (escrituraBLL.getValorCliente(Convert.ToInt32(txNrEscritura.Text), 'C') <= 0)
            {
                MessageBox.Show("Cliente sem saldo!");
                return;
            }
            else {
                txPago.Text = txTotal.Text;
            }


        }

        private void rbClienteEscritura_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
            txNrEscritura.Text = "";
            gbEscritura.Visible = true;
            txNrEscritura.Focus();
        }

        private void rbDeposito_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
            gbCheque.Visible = true;
            gbCheque.Text = "Deposito Conta";
            txNrCheque.Enabled = false;
            txRG.Enabled = false;
        }

        private void txBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        












    }
}
