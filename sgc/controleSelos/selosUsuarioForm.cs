using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using DAO;
using BLL;

namespace sgc.controleSelos
{
    public partial class selosUsuarioForm : Form
    {
        private Conexao con;
        private Selo selo;
        private SelosBLL seloBLL;
        private UsuarioDAO usuarioDAO;
        
        public selosUsuarioForm()
        {
            con = new Conexao(Dados.strConexao);
            selo = new Selo();
            seloBLL = new SelosBLL(con);
            usuarioDAO = new UsuarioDAO(con.ObjCon);
            InitializeComponent();
        }

        private void comboUsuarios() {
            con.ObjCon.Open();
            cbUsuario.DataSource = usuarioDAO.getUsuarios();
            cbUsuario.ValueMember = "dsLogin";
            cbUsuario.DisplayMember = "nmUsuario";
            cbUsuario.Text = "Selecione...";
            con.ObjCon.Close();
        }

        private void pesquisaSelos(string status,string nrSelo = "" ,string dsLogin="",string dtIni="", string dtFim="") {

            if (txNrSelo.Text.Equals("")) {
                nrSelo = "0";
            }

            if (!ckData.Checked) {
                dtIni = "";
                dtFim = "";
            }

            grid.DataSource = seloBLL.getSelosUsuario(dsLogin,dtIni,dtFim,status,Convert.ToInt32(nrSelo));


            grid.Columns[0].HeaderText = "No. Pedido";
            grid.Columns[0].Width = 60;
            grid.Columns[1].HeaderText = "No. do Item";
            grid.Columns[1].Width = 60;
            grid.Columns[2].HeaderText = "Data";
            grid.Columns[2].Width = 100;
            grid.Columns[3].HeaderText = "No. Processo";
            grid.Columns[3].Width = 70;
            grid.Columns[4].HeaderText = "No. Selo";
            grid.Columns[4].Width = 100;
            grid.Columns[5].HeaderText = "Serie";
            grid.Columns[5].Width = 140;
            grid.Columns[6].HeaderText = "Ato";
            grid.Columns[6].Width = 200;
            grid.Columns[7].HeaderText = "Status";
            grid.Columns[7].Width = 50;
            grid.Columns[8].HeaderText = "Utilizado por ";
            grid.Columns[8].Width = 80;
        }

        private string getStatus() {
            if (rbDisponivel.Checked) {
                return "D";
            }
            if (rbUsado.Checked)
            {
                return "U";
            }
            else {
                return "T";
            }
        }

        private void selosUsuarioForm_Load(object sender, EventArgs e)
        {
            comboUsuarios();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            
            if (cbUsuario.SelectedValue == null)
            {
                MessageBox.Show("Selecione usuario");
                cbUsuario.Focus();
                return;
            }

            try
            {
                pesquisaSelos(getStatus(),
                                txNrSelo.Text,
                                cbUsuario.SelectedValue.ToString(),
                                utils.formatos.formatoData(dpInicio.Value.ToShortDateString(), true),
                                utils.formatos.formatoData(dpFim.Value.ToShortDateString(), true));
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro: "+ex.Message);
            }
        }
    }
}
