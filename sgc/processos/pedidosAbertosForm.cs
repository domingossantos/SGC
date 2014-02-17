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
using Modelos;

namespace sgc.processos
{
    public partial class pedidosAbertosForm : Form
    {
        private PedidoBLL pedidoBLL;
        private Conexao con;
        public pedidosAbertosForm()
        {  
            InitializeComponent();
            con = new Conexao(Dados.strConexao);
            pedidoBLL = new PedidoBLL(con);
        }

        private void pedidosAbertosForm_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void atualizaGrid(string filtro="")
        {
            grid.DataSource = pedidoBLL.getPedidosAbertos(filtro);
            grid.Columns[0].HeaderText = "No. Pedido";
            grid.Columns[0].Width = 80;
            grid.Columns[1].HeaderText = "Data Pedido";
            grid.Columns[1].Width = 120;
            grid.Columns[2].HeaderText = "No. Selo";
            grid.Columns[2].Width = 100;
            grid.Columns[3].HeaderText = "Valor";
            grid.Columns[3].Width = 120;
            grid.Columns[3].DefaultCellStyle.Format = "c";
            grid.Columns[4].HeaderText = "Usuário";
            grid.Columns[4].Width = 160;
            grid.Columns[5].HeaderText = "Status Pedido";
            grid.Columns[5].Width = 80;
        }

        private void fecharPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.CdPerfil == 1)
            {

                pedidoBLL.fechaPedido(Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value.ToString()));
                MessageBox.Show("Pedido Fechado!");
                atualizaGrid();
            }
            else {
                MessageBox.Show("Usuário não tem permissão de acesso!");
            }
        }

        private void cancelarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (utils.sessao.UsuarioSessao.CdPerfil == 1)
            {
                Pedido pedido = pedidoBLL.getUltimoPedido(grid[0, grid.CurrentRow.Index].Value.ToString());
                pedidoBLL.cancelaPedido(pedido.NrPedido,pedido.VlPedido,utils.sessao.UsuarioSessao.DsLogin);
                MessageBox.Show("Pedido Cencelado!");
                atualizaGrid();
            }
            else
            {
                MessageBox.Show("Usuário não tem permissão de acesso!");
            }
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            string filtro = "";
            DateTime hoje = DateTime.Now;
            if (rbTodos.Checked) {
                filtro = "";
            }
            if (rbHoje.Checked) {

                filtro = "and dtPedido between '" + utils.formatos.formatoData(hoje.ToShortDateString(),true)
                            + " 00:00:00' and '" + utils.formatos.formatoData(hoje.ToShortDateString(), true) + " 23:59:59'"; 
            }
            if (rbTresDias.Checked) {
                DateTime anteontem = hoje.AddDays(-3);
                filtro = "and dtPedido between '" + utils.formatos.formatoData(anteontem.ToShortDateString(), true)
                            + " 00:00:00' and '" + utils.formatos.formatoData(hoje.ToShortDateString(), true) + " 23:59:59'"; 
            }

            if (rbEntreDatas.Checked) {
                filtro = "and dtPedido between '" + utils.formatos.formatoData(dtInicio.Value.ToShortDateString(), true)
                            + " 00:00:00' and '" + utils.formatos.formatoData(dtFim.Value.ToShortDateString(), true) + " 23:59:59'"; 
            }
            atualizaGrid(filtro);
        }

        private void apagarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (utils.sessao.UsuarioSessao.DsLogin.Equals("admin"))
            {
                Pedido pedido = pedidoBLL.getUltimoPedido(grid[0, grid.CurrentRow.Index].Value.ToString());
                pedidoBLL.apagarPedido(pedido.NrPedido);
                MessageBox.Show("Pedido Apagado!");
                atualizaGrid();
            }
            else
            {
                MessageBox.Show("Usuário não tem permissão de acesso!");
            }
        }
    }
}
