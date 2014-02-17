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
    public partial class lavrarEscrituraForm : Form
    {
        private EscrituraBLL escrituraBLL;
        private PedidoBLL pedidoBLL;
        private AtoOperacaoBLL atoBLL;
        private Escritura escritura;
        private Selo selo;
        public lavrarEscrituraForm(Escritura esc)
        {
            Conexao con = new Conexao(Dados.strConexao);
            escrituraBLL = new EscrituraBLL(con);
            atoBLL = new AtoOperacaoBLL(con);
            pedidoBLL = new PedidoBLL(con);

            escritura = esc;
            InitializeComponent();
        }

        public void carregaAtos(int idx)
        {
            cbAtos.DataSource = atoBLL.listaAtosPorTipo(3,0,"");

            cbAtos.ValueMember = "cdAto";
            cbAtos.DisplayMember = "dsAto";
            cbAtos.SelectedValue = idx;
            
        }

        private void lavrarEscrituraForm_Load(object sender, EventArgs e)
        {
            carregaAtos(escritura.CdAto);
            lbFicha.Text = escritura.IdEscritura.ToString();
        }

        public void getSelo() {
            AtoOperacao ato = atoBLL.getAto(Convert.ToInt32(cbAtos.SelectedValue.ToString()));

            selo = pedidoBLL.getUltimoSelo(ato.CdAto,utils.sessao.UsuarioSessao.DsLogin);

            if (selo == null)
            {
                MessageBox.Show("Não há selo disponivel para lavrar a escritura!");
                return;
            }
            else 
            {
                try
                {
                    txNrSelo.Text = selo.NrSelo.ToString() + " SERIE " + pedidoBLL.getSerieSelo(selo.CdTipoSelo);
                    pedidoBLL.mudaStatusSelo(selo.NrSelo, selo.CdTipoSelo, 'R');
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro ao atribuor selo\n" + ex.Message);
                }
            }
        }

        private void salvarSelo() 
        {
            try 
            { 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void btGetSelo_Click(object sender, EventArgs e)
        {
            getSelo();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (selo != null)
                {
                    pedidoBLL.mudaStatusSelo(selo.NrSelo, selo.CdTipoSelo, 'D');
                    MessageBox.Show("Lavratura cancelada\nSelo atribuido devolvido ao estoque!");
                }
                else
                {
                    MessageBox.Show("Lavratura cancelada");

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar janela" + ex.Message);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (txLivro.Text.Equals("")) {
                MessageBox.Show("Informa Nº do Livro");
                txLivro.Focus();
                return;
            }

            if (txFolha.Text.Equals(""))
            {
                MessageBox.Show("Informa Nº do Folha");
                txFolha.Focus();
                return;
            }

            if (txNrSelo.Text.Equals(""))
            {
                MessageBox.Show("Atribua um selo a escritura");
                return;
            }

            try 
            {
                int cdAto = Convert.ToInt32(cbAtos.SelectedValue.ToString());
                AtoOperacao atoSelecionado = atoBLL.getAto(cdAto);
                AtoOperacao atoPago = null;
                AtoOperacao atoEscritura = atoBLL.getAto(escritura.CdAto);

                if (atoSelecionado.CdAto.Equals(atoEscritura.CdAto))
                {
                    MessageBox.Show("Ato da Escritura iqual ao Selecionado");

                    atoPago = escrituraBLL.verificaPagamentoEscritura(escritura.IdEscritura, escritura.CdAto);
                    if (atoPago == null)
                    {
                        MovimentoDeposito movimento = new MovimentoDeposito();
                        movimento.IdEscritura = escritura.IdEscritura;
                        movimento.CdAto = atoEscritura.CdAto;
                        movimento.VlMovimento = atoEscritura.VlAto;
                        movimento.DsMovimento = "Lavrar Escritura";
                        movimento.DtMovimento = DateTime.Now;
                        movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                        movimento.TpMovimento = 'D';
                        movimento.StRegistro = 'P';

                        escrituraBLL.solicitaPagamento(movimento, true);
                    }
                }
                else 
                { 
                    atoPago = escrituraBLL.verificaPagamentoEscritura(escritura.IdEscritura, escritura.CdAto);
                    if (atoPago == null)
                    {
                        MovimentoDeposito movimento = new MovimentoDeposito();
                        movimento.IdEscritura = escritura.IdEscritura;
                        movimento.CdAto = atoSelecionado.CdAto;
                        movimento.VlMovimento = atoSelecionado.VlAto;
                        movimento.DsMovimento = "Lavrar Escritura";
                        movimento.DtMovimento = DateTime.Now;
                        movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                        movimento.TpMovimento = 'D';
                        movimento.StRegistro = 'P';

                        escrituraBLL.solicitaPagamento(movimento, true);
                    }
                    else {

                        double valorDiferenca = 0;
                       
                        if (atoSelecionado.VlAto > atoEscritura.VlAto)
                        {
                            valorDiferenca = atoSelecionado.VlAto - atoEscritura.VlAto;
                        }
                        
                        MovimentoDeposito movimento = new MovimentoDeposito();
                        movimento.IdEscritura = escritura.IdEscritura;
                        movimento.CdAto = atoSelecionado.CdAto;
                        movimento.VlMovimento = valorDiferenca;
                        movimento.DsMovimento = "Diferença de Valor de Escritura";
                        movimento.DtMovimento = DateTime.Now;
                        movimento.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                        movimento.TpMovimento = 'D';
                        movimento.StRegistro = 'P';

                        escrituraBLL.solicitaPagamento(movimento, true);
                    }
                }

                escritura.NrLivro = txLivro.Text;
                escritura.NrFolha = txFolha.Text;
                escritura.NrSelo = selo.NrSelo;
                escritura.CdTipoSelo = selo.CdTipoSelo;
                escritura.TpEscritura = 'E';
                if(escritura.DsLogin == null)
                    escritura.DsLogin = utils.sessao.UsuarioSessao.DsLogin;

                escrituraBLL.salvaEscritura(escritura);

                MessageBox.Show("Esccritura Lavada!");
                this.Close();

            }
            catch(Exception ex){
                MessageBox.Show("Erro:"+ex.Message);
            }

        }
    }
}
