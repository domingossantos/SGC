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



namespace sgc.admin
{
    public partial class HistoricoMovimentoSelosForm : Form
    {
        private Conexao con;
        private SelosBLL seloBll;
        private UsuarioBLL usuarioBll;

        public HistoricoMovimentoSelosForm()
        {
            con = new Conexao(Dados.strConexao);
            seloBll = new SelosBLL(con);
            usuarioBll = new UsuarioBLL(con);
            InitializeComponent();
        }

        public void getTipoSelo()
        {
            cmbTipoSelo.DataSource = seloBll.getTipoSelos();
            cmbTipoSelo.ValueMember = "cdTipoSelo";
            cmbTipoSelo.DisplayMember = "dsTipoSelo";
            cmbTipoSelo.Text = "Selecione";
            cmbTipoSelo.SelectedIndex = -1;
        }

        public void getUsuarios() {
            cmbUsuario.DataSource = usuarioBll.getUsuarios();
            cmbUsuario.ValueMember = "dsLogin";
            cmbUsuario.DisplayMember = "dsLogin";
            cmbUsuario.Text = "Selecione";
            cmbUsuario.SelectedIndex = -1;
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {

            String login = "";
            String tipo = "";
            
            if (txInicio.Text.Equals("  /  /"))
            {
                utils.MessagensExcept.funMsgSistema("O Campo Inicio é obrigatório", 3);
                txInicio.Focus();
                return;
            }

            if (txFim.Text.Equals("  /  /"))
            {
                utils.MessagensExcept.funMsgSistema("O Campo Final é obrigatório", 3);
                txFim.Focus();
                return;
            }

            if (cmbTipoSelo.SelectedValue != null)
            {
                tipo = cmbTipoSelo.SelectedValue.ToString();
            }

            if (cmbUsuario.SelectedValue != null) {
                login = cmbUsuario.SelectedValue.ToString();
            }

            if (txSeloFim.Text.Equals("")) {
                txSeloFim.Text = txSeloInicio.Text;
            }

            grid.DataSource = seloBll.historicoMovimentoSelos(
                                        getDataFormatoBanco(txInicio.Text),
                                        getDataFormatoBanco(txFim.Text),
                                        login,
                                        txSeloInicio.Text,
                                        txSeloFim.Text,
                                        tipo);
            lbRegEncontrados.Text = (grid.RowCount - 1).ToString();
        }

        private String getDataFormatoBanco(String data) {
            String[] dataArray = data.Split('/');
            return dataArray[2] + "-" + dataArray[1] + "-" + dataArray[0];
        }

        private void HistoricoMovimentoSelosForm_Load(object sender, EventArgs e)
        {
            getUsuarios();
            getTipoSelo();
        }

        private void btExportarXls_Click(object sender, EventArgs e)
        {
            utils.ExportaExcelXml exportarXml = new utils.ExportaExcelXml();
            string _atCaminhoDiretorio = System.Windows.Forms.Application.StartupPath; 

            String arquivoXML =  exportarXml.gerarArquivoXML(seloBll.sql,"HistoricoMocimentoSelos");
            MSDN.Sample.XMLToExcel.OpenXMLOffice openXMLOffice = new MSDN.Sample.XMLToExcel.OpenXMLOffice();
            openXMLOffice.XMLToExcel(arquivoXML);

            
            utils.MessagensExcept.funMsgSistema("Arquivo Exportado", 2);
        }
    }
}
