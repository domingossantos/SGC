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

namespace sgc
{
    public partial class resumoForm : Form
    {
        private Conexao con;
        private PedidoBLL pedidoBll;
        public resumoForm()
        {
            con = new Conexao(Dados.strConexao);
            pedidoBll = new PedidoBLL(con);
            InitializeComponent();
        }

        private void resumoForm_Load(object sender, EventArgs e)
        {
            grid.DataSource = pedidoBll.getIntervaloSelos(utils.sessao.UsuarioSessao.DsLogin);
            grid.Columns[0].HeaderText = "Tipo Selo";
            grid.Columns[0].Width = 170;
            grid.Columns[1].HeaderText = "Inicio";
            grid.Columns[1].Width = 70;
            grid.Columns[2].HeaderText = "Final";
            grid.Columns[2].Width = 70;
            grid.Columns[3].HeaderText = "Qtd.";
            grid.Columns[3].Width = 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
