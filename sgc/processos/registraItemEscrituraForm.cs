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
using System.IO;

namespace sgc.processos
{
    public partial class registraItemEscrituraForm : Form
    {
        private EscrituraBLL escrituraBLL;
        private MovimentoDeposito movimento;
        private Escritura escritura;
        private escrituraForm FormEscritura;
        private AtoOperacaoBLL atoBLL;
        sbyte funcao;

        public registraItemEscrituraForm(escrituraForm _FormEscritura,sbyte _funcao)
        {
            Conexao con = new Conexao(Dados.strConexao);
            escrituraBLL = new EscrituraBLL(con);
            atoBLL = new AtoOperacaoBLL(con);
            FormEscritura = _FormEscritura;
            escritura = _FormEscritura.Escritura;
            funcao = _funcao;
            InitializeComponent();
        }

        private void adicionaRecebimento() {
            try
            {
                Pedido p = new Pedido();
                movimento = new MovimentoDeposito();

                movimento.IdEscritura = escritura.IdEscritura;
                movimento.CdAto = utils.sessao.CdAtodeposito;
                movimento.VlMovimento = Convert.ToDouble(txValor.Text);
                movimento.DsMovimento = txDescricao.Text;
                movimento.DtMovimento = DateTime.Now;
                movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                movimento.TpMovimento = 'C';
                movimento.StRegistro = 'P';
                escrituraBLL.gravaPagamentoEscritura(movimento, ref p);

                MessageBox.Show("Pagamento gravado com sucesso!\nImprimindo pedido Nº " + p.NrPedido);
                string nmBoleto = (Microsoft.VisualBasic.Interaction.InputBox("Nome para o Recibo:", "Cartorio Conduru", "0", 150, 150));
                escrituraBLL.imprimeReciboPedidoEscritura(escritura.IdEscritura.ToString(), p.NrPedido.ToString(), p.VlPedido.ToString(), utils.sessao.PathIniFile,nmBoleto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar Pagamento!\n" + ex.Message);
            }
        }

        private void adicionaPagamento()
        {
            try
            {
                movimento = new MovimentoDeposito();
                movimento.IdEscritura = escritura.IdEscritura;
                movimento.CdAto = Convert.ToInt32(cbItem.SelectedValue.ToString());
                movimento.VlMovimento = Convert.ToDouble(txValor.Text);
                movimento.DsMovimento = txDescricao.Text;
                movimento.DtMovimento = DateTime.Now;
                movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                movimento.TpMovimento = 'D';
                movimento.StRegistro = 'A';
                DialogResult dlgR = new DialogResult();
                bool forcar = false;

                if (escrituraBLL.getValorCliente(escritura.IdEscritura, 'C') <= 0) 
                {    
                    dlgR = MessageBox.Show("Cliente não tem saldo!\nDeseja solicitar pagamento?", "Cartorio Conduru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgR == DialogResult.No)
                    {
                        MessageBox.Show("Solicitação Cancelada!");
                        return;
                    }
                    else 
                    {
                        MessageBox.Show("O registro será gravado mas o pagamento só será\nliberado com autorização do departamento financeiro!");
                        forcar = true;
                    }
                }

                escrituraBLL.solicitaPagamento(movimento,forcar);

                IniFile iniFile = new IniFile(utils.sessao.PathIniFile);
                MatrixReporter.Reporter imp = new MatrixReporter.Reporter();

                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();
                imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));
                imp.PrintText(6, 1, "########## SOLICITACAO DE PAGAMENTO ###########");
                imp.PrintText(8, 1, "No. FICHA:......................" + escritura.IdEscritura.ToString().PadLeft(7, '0').PadLeft(14, ' '));
                imp.PrintText(9, 1, "Valor :........................." + String.Format("{0:N2}", Convert.ToDouble(txValor.Text)).PadLeft(14, ' '));
                
                AtoOperacao ato = atoBLL.getAto(Convert.ToInt32(cbItem.SelectedValue.ToString()));
                imp.PrintText(10, 1, "ATO: "+ato.DsAto);
                imp.PrintText(11, 1, "Data Solicitacao: " + DateTime.Now.ToShortDateString());
                imp.PrintText(12, 1, "SOLICITANTE: " + utils.sessao.UsuarioSessao.NmUsuario);

                
                imp.PrintText(16, 1, "_______________________________________________");
                imp.PrintText(17, 1, "                 SOLICITANTE");
                imp.EndJob();
                imp.PrintJob();
                MessageBox.Show("Pagamento Solicitado!");

            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao solictar pagamento.\n" + ex.Message);
            }
        }

        private void adicionaItemOrcamento(){
            try
            {
                ItemOrcamento item = new ItemOrcamento();

                item.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                item.CdAto = Convert.ToInt32(cbItem.SelectedValue.ToString());
                item.NrQuantidade = txQuant.Text.Equals("") ? 1 : Convert.ToInt32(txQuant.Text);
                item.VlTotal = Convert.ToDouble(txValor.Text);
                item.IdOrcamento = escritura.IdEscritura;
                escrituraBLL.addItemOrcamento(item);
                MessageBox.Show("Item registrado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar item!\n"+ex.Message);
            }
        }

        public void carregaItens()
        {
            cbItem.DataSource = escrituraBLL.listaItensEscritura();

            cbItem.ValueMember = "cdAto";
            cbItem.DisplayMember = "dsAto";

            cbItem.Text = "Selecione";
        }

       
        private void btGravar_Click(object sender, EventArgs e)
        {
            switch (funcao)
            {
                case 1:
                    adicionaItemOrcamento();
                    break;
                case 2:
                    adicionaPagamento();
                    break;
                case 3:
                    adicionaRecebimento();
                    break;
                default:
                    break;
            }

            FormEscritura.carregaTodosDados();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void calcularValorItem() {
            int qtd = 1;
            if (!txQuant.Text.Equals(""))
            {
                if (Convert.ToInt32(txQuant.Text) > 1)
                {
                    qtd = Convert.ToInt32(txQuant.Text);
                }
            }

            txValor.Text = String.Format("{0:N2}", escrituraBLL.vlItemEscritura(Convert.ToInt32(cbItem.SelectedValue.ToString()), qtd));
        }

        private void cbItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            calcularValorItem();
        }

        private void txQuant_Leave(object sender, EventArgs e)
        {
            calcularValorItem();
        }

        private void registraItemEscrituraForm_Load(object sender, EventArgs e)
        {
            carregaItens();

            switch (funcao)
            {
                case 1:
                    this.Text = "Orçamento Escritura";
                    txQuant.Enabled = true;
                    break;
                case 2:
                    this.Text = "Pagamento Escritura";
                    txQuant.Enabled = false;
                    break;
                case 3:
                    this.Text = "Recebimento Escritura";
                    txQuant.Enabled = false;
                    cbItem.SelectedValue = 74;
                    cbItem.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void verificaValorEscritura() {

        }
    }
}
