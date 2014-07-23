using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.assinaturas
{
    public partial class ImpressaoRGForm : Form
    {
        private String nrCartao;
        public ImpressaoRGForm(String _nrCartao)
        {
            nrCartao = _nrCartao;
            InitializeComponent();
        }

        private void ImpressaoRGForm_Load(object sender, EventArgs e)
        {

            tblCartaoAssinaturaTableAdapter.Connection.ConnectionString = DAO.Dados.strConexao;
            tblCartaoAssinaturaTableAdapter.Fill(this.sGCDataSet.tblCartaoAssinatura, nrCartao);

            System.Drawing.Printing.PageSettings pageSettings = new System.Drawing.Printing.PageSettings();

            pageSettings.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
            reportViewer1.SetPageSettings(pageSettings);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
