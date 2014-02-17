using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace sgc.caixa
{
    public partial class relMovimentoDiarioForm : Form
    {
        public relMovimentoDiarioForm()
        {
            InitializeComponent();
        }

        private void relMovimentoDiarioForm_Load(object sender, EventArgs e)
        {

            this.rView.RefreshReport();
        }

        private void btVisualizar_Click(object sender, EventArgs e)
        {
            string sDtInicio = dtRelatorio.Value.ToShortDateString()+ " 00:00:00";
            string sDtFim = dtRelatorio.Value.ToShortDateString() + " 23:59:59";

            //tblMovimentoTotalDiaTableAdapter.GetData(Convert.ToDateTime(sDtInicio), Convert.ToDateTime(sDtFim));

            tblMovimentoTotalDiaTableAdapter.Fill(sGCDataSet.tblMovimentoTotalDia, Convert.ToDateTime(sDtInicio), Convert.ToDateTime(sDtFim));
            /*ReportParameter pDtInicio = new ReportParameter("dtInicio",sDtInicio);
            ReportParameter pDtFim = new ReportParameter("dtFim",sDtFim);

            rView.LocalReport.SetParameters(pDtInicio);
            rView.LocalReport.SetParameters(pDtFim);*/
            rView.RefreshReport();
            


        }
    }
}
