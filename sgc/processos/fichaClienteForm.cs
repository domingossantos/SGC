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
    public partial class fichaClienteForm : Form
    {
        public fichaClienteForm()
        {
            InitializeComponent();
        }

        private void fichaClienteForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGCDataSet.tblEscritura' table. You can move, or remove it, as needed.
            this.tblEscrituraTableAdapter.Fill(this.sGCDataSet.tblEscritura);
            // TODO: This line of code loads data into the 'sGCDataSet.tblEscritura' table. You can move, or remove it, as needed.
            this.tblEscrituraTableAdapter.Fill(this.sGCDataSet.tblEscritura);

            
            this.reportViewer1.RefreshReport();
        }
    }
}
