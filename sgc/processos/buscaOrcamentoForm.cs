using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;


namespace sgc.processos
{
    public partial class buscaOrcamentoForm : Form
    {
        EscrituraBLL escrituraBll;
        Conexao con;
        escrituraOrcamentoForm oOrcamentoForm;
        public buscaOrcamentoForm(escrituraOrcamentoForm oFormPai)
        {
            con = new Conexao(Dados.strConexao);
            escrituraBll = new EscrituraBLL(con);
            oOrcamentoForm = oFormPai;
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            grid.DataSource = escrituraBll.buscaOrcamentoDatas(
                        utils.formatos.formatoData(dtInicio.Value.ToShortDateString(),true),
                        utils.formatos.formatoData(dtFim.Value.ToShortDateString(), true));

            grid.Columns[0].HeaderText = "No. Orçamento";
            grid.Columns[0].Width = 80;
            grid.Columns[1].HeaderText = "Endereço";
            grid.Columns[1].Width = 280;
            grid.Columns[2].HeaderText = "Contato";
            grid.Columns[2].Width = 120;
            grid.Columns[3].HeaderText = "Fones";
            grid.Columns[3].Width = 120;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oOrcamentoForm.carregaDados(Convert.ToInt32( grid[0, grid.CurrentRow.Index].Value));
            this.Close();

        }
    }
}
