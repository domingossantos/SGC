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
    public partial class ImpressaoCartaoForm : Form
    {
        private String nrCartao;
        public ImpressaoCartaoForm(String _nrCartao)
        {
            nrCartao = _nrCartao;
            InitializeComponent();

        }

        private void ImpressaoCartaoForm_Load(object sender, EventArgs e)
        {
            tblCartaoAssinaturaTableAdapter.Connection.ConnectionString = DAO.Dados.strConexao;
            tblCartaoAssinaturaTableAdapter.Fill(this.sGCDataSet.tblCartaoAssinatura, nrCartao);
            this.reportViewer1.RefreshReport();
        }
    }
}
