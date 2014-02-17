using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using DAO;
using BLL;
using sgc.utils;

namespace sgc.processos
{
    public partial class registroProcuracaoAntiga : Form
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
        private PedidoBLL pedidoBLL;

        public registroProcuracaoAntiga()
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
            InitializeComponent();
        }

        public void carregaTipoDoc(int idx = 0)
        {
            cbTipoDoc.DataSource = tipoDocDAO.getTiposDocumentos("and cdTipoDocumento between 2 and 6");
            if (idx > 0)
                cbTipoDoc.SelectedValue = idx;
            cbTipoDoc.ValueMember = "cdTipoDocumento";
            cbTipoDoc.DisplayMember = "nmTipoDocumento";
        }

        public void carregaAtos(int tipo, int idx = 0)
        {
            cbAtos.DataSource = atosBLL.listaAtosPorTipo(tipo,0,"");
            if (idx > 0)
                cbAtos.SelectedValue = idx;

            cbAtos.ValueMember = "cdAto";
            cbAtos.DisplayMember = "dsAto";
        }

        public void carregaTipoSelo() {
            cbTipoSelo.DataSource = seloBLL.getTipoSelos();
            cbTipoSelo.ValueMember = "cdTipoSelo";
            cbTipoSelo.DisplayMember = "dsTipoSelo";
        }

        private void cbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoDoc.SelectedValue.ToString().Length == 1)
            {
                int i = Convert.ToInt32(cbTipoDoc.SelectedValue.ToString());
                carregaAtos(i);
            }
        }

        private void registroProcuracaoAntiga_Load(object sender, EventArgs e)
        {
            carregaTipoDoc();
            carregaTipoSelo();
        }

        private void btGeraPedido_Click(object sender, EventArgs e)
        {
            // Verifica Selo
            Selo selo = seloBLL.getSelo(Convert.ToInt32(txNrSelo.Text), Convert.ToInt32( cbTipoSelo.SelectedValue));
            
            try
            {

                if (selo.NrSelo > 0)
                {
                    MessageBox.Show("Selo exitente e não pode ser\nusado para esta operação!");
                    return;
                }

                selo.NrSelo = Convert.ToInt32(txNrSelo.Text);
                selo.CdTipoSelo = Convert.ToInt32(cbTipoSelo.SelectedValue);
                selo.DtLancamento = DateTime.Now;
                selo.DtAtribuicao = DateTime.Now;
                selo.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                selo.StSelo = 'C';


                string numProcesso = processoBLL.geraNumProcesso();


                Processo processo = new Processo();
                processo.NrProceso = numProcesso;
                processo.CdAto = Convert.ToInt32(cbAtos.SelectedValue.ToString());
                processo.CdTipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue.ToString());
                processo.NrFolha = txFolha.Text;
                processo.NrLivro = txLivro.Text;
                processo.DsObservacao = txObservacao.Text;
                processo.DtEmissao = DateTime.Now;
                processo.DtInclusao = DateTime.Now;
                processo.DsPathArquivo = "";


                Pedido pedido = new Pedido();
                ItemPedido itemPedido = new ItemPedido();
                AtoOperacao ato = new AtoOperacao();

                processoBLL.gravaProcessoAntigo(selo, processo,
                                                utils.sessao.UsuarioSessao.DsLogin,
                                                Convert.ToInt32(cbAtos.SelectedValue.ToString()),
                                                Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()),
                                                ref pedido);

                pedidoBLL.imprimePedidoEscritura(pedido.NrPedido.ToString(), "0", ato.VlAto.ToString(), sessao.PathIniFile);
                MessageBox.Show("Pedido Emitido.\nImprimindo Pedido.");

                txFolha.Text = "";
                txLivro.Text = "";
                txNrSelo.Text = "";
                txObservacao.Text = "";
                carregaTipoDoc();
                carregaTipoSelo();
                carregaAtos(Convert.ToInt32(cbTipoDoc.SelectedValue.ToString()));
            }
            catch (Exception ex) {
                //trans.Rollback();
                MessageBox.Show("Erro ao registrar documento\n"+ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
