using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sgc.financeiro
{
    public partial class resumoAtosPeriodoForm : Form
    {
        public resumoAtosPeriodoForm()
        {
            InitializeComponent();
        }

        private void resumoAtosPeriodoForm_Load(object sender, EventArgs e)
        {

            
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            DateTime oDtInicio = Convert.ToDateTime(dtInicio.Value.ToShortDateString() + " 00:00:00");
            DateTime oDtFim = Convert.ToDateTime(dtFim.Value.ToShortDateString() + " 23:59:59");


            this.tblItensPedidoTableAdapter.Fill(this.sGCDataSet.tblItensPedido,
                                                 oDtInicio, oDtFim);
            view.RefreshReport();
        }
    }
}
