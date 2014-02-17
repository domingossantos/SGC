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
    public partial class relEscriturasForm : Form
    {
        public relEscriturasForm()
        {
            InitializeComponent();
        }

        private void relEscriturasForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGCDataSet.tblListaEscritura' table. You can move, or remove it, as needed.
            this.tblListaEscrituraTableAdapter.Fill(this.sGCDataSet.tblListaEscritura);

            this.reportViewer1.RefreshReport();
        }
    }
}
