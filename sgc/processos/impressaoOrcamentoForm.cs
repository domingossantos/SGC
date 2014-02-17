using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.processos
{
    public partial class impressaoOrcamentoForm : Form
    {
        int idOrcamento = 0;
        public impressaoOrcamentoForm(int id)
        {
            idOrcamento = id;
            InitializeComponent();
        }

        private void impressaoOrcamentoForm_Load(object sender, EventArgs e)
        {

            tblOrcamentoEscrituraTableAdapter.Fill(sGCDataSet.tblOrcamentoEscritura,  idOrcamento);
            itensOrcamentoTableAdapter.Fill(sGCDataSet.ItensOrcamento, idOrcamento);
            pessoasOrcamentoTableAdapter.Fill(sGCDataSet.PessoasOrcamento, idOrcamento);

            this.report.RefreshReport();
        }

        private void impressaoOrcamentoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tblOrcamentoEscrituraTableAdapter.Dispose();
            itensOrcamentoTableAdapter.Dispose();
            pessoasOrcamentoTableAdapter.Dispose();
            report.Dispose();
        }
    }
}
