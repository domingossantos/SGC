using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.cnj
{
    public partial class impressaoCepForm : Form
    {
        String dtInicio = "";
        String dtFim = "";
        public impressaoCepForm(String pDtInicio, String pDtFim)
        {
            dtInicio = pDtInicio;
            dtFim = pDtFim;
            InitializeComponent();
        }

        private void impressaoCepForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGCDataSet.tblListaCEP' table. You can move, or remove it, as needed.
            DateTime oDtInicio = Convert.ToDateTime(dtInicio + " 00:00:00");
            DateTime oDtFim = Convert.ToDateTime(dtFim + " 23:59:59");
            sGCDataSet.EnforceConstraints = false;
            this.tblListaCEPTableAdapter.FillByDatas(this.sGCDataSet.tblListaCEP,oDtInicio, oDtFim);

            this.reportViewer1.RefreshReport();
        }
    }
}
