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

namespace sgc.admin
{
    public partial class HistoricoCancelamentoPedidosForm : Form
    {
        private Conexao con;
        private UsuarioBLL usuarioBll;
        private PedidoBLL pedidoBll;
        public HistoricoCancelamentoPedidosForm()
        {
            con = new Conexao(Dados.strConexao);
            usuarioBll = new UsuarioBLL(con);
            pedidoBll = new PedidoBLL(con);
            InitializeComponent();
        }
        
        public void getUsuarios()
        {
            cmbUsuario.DataSource = usuarioBll.getUsuarios();
            cmbUsuario.ValueMember = "dsLogin";
            cmbUsuario.DisplayMember = "dsLogin";
            cmbUsuario.Text = "Selecione";
            cmbUsuario.SelectedIndex = -1;
        }

        private void HistoricoCancelamentoPedidosForm_Load(object sender, EventArgs e)
        {
            getUsuarios();
        }

        private String getDataFormatoBanco(String data)
        {
            String[] dataArray = data.Split('/');
            return dataArray[2] + "-" + dataArray[1] + "-" + dataArray[0];
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            String login = "";
            String dtInicio = "";
            String dtFim = "";
            if (cmbUsuario.SelectedValue != null) {
                login = cmbUsuario.SelectedValue.ToString();
            }

            if (!txInicio.Text.Equals("  /  /"))
            {
                dtInicio = getDataFormatoBanco(txInicio.Text);
            }

            if (!txFim.Text.Equals("  /  /"))
            {
                dtFim = getDataFormatoBanco(txFim.Text);
            }

            grid.DataSource = pedidoBll.getPedidosCancelados(dtInicio,dtFim,login,txNrPedido.Text);
            lbRegEncontrados.Text = (grid.RowCount - 1).ToString();
            
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            getUsuarios();
            txNrPedido.Text = "";
            txInicio.Text = "  /  /";
            txFim.Text  = "  /  /";
        }
    }
}
