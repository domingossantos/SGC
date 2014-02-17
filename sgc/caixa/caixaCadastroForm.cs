using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;
using Modelos;

namespace sgc.caixa
{
    public partial class caixaCadastroForm : sgc.modeloForm
    {
        private sbyte op = 0;
        private CaixaBLL caixaBLL;
        private Conexao con;
        private Caixa caixa;
        public caixaCadastroForm()
        {
            con = new Conexao(Dados.strConexao);
            caixaBLL = new CaixaBLL(con);
            caixa = null;
            InitializeComponent();
        }

        private void limparCampos()
        {
            op = 0;
            txDescricao.Text = "";
            txNoCaixa.Text = "";
            rbAberto.Checked = false;
            rbCancelado.Checked = false;
            rbFechado.Checked = false;
        }

        private void atualizaGrid() {
            grid.DataSource = caixaBLL.getCaixas();
            grid.Columns[0].HeaderText = "No. Caixa";
            grid.Columns[0].Width = 80;
            grid.Columns[1].HeaderText = "Descrição";
            grid.Columns[1].Width = 100;
            grid.Columns[2].HeaderText = "Status";
            grid.Columns[2].Width = 50;
        }

        private void preecherCampos(int nrCaixa)
        {
            caixa = new Caixa();
            caixa = caixaBLL.getCaixa(nrCaixa);
            txNoCaixa.Text = caixa.NrCaixa.ToString();
            txDescricao.Text = caixa.NmCaixa;
            setStatusCheck(caixa.StCaixa);
            txNoCaixa.Focus();
        }

        private bool stChecks()
        {
            bool st = false;

            if (rbAberto.Checked) st = true;
            if (rbCancelado.Checked) st = true;
            if (rbFechado.Checked) st = true;

            return st;
        }

        private char getStatusCheck()
        {
            char st = '0';

            if (rbAberto.Checked) st = 'A';
            if (rbCancelado.Checked) st = 'C';
            if (rbFechado.Checked) st = 'F';

            return st;
        }

        private void setStatusCheck(char st)
        {
            if (st == 'A') rbAberto.Checked = true; ;
            if (st == 'C') rbCancelado.Checked = true; ;
            if (st == 'F') rbFechado.Checked = true; ;

        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            op = 1;
            txNoCaixa.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txNoCaixa.Text.Equals(""))
            {
                MessageBox.Show("No. do Caixa obrigatório");
                return;
            }

            if (txDescricao.Text.Equals("")) {
                MessageBox.Show("Descrição do Caixa obrigatório");
                return;
            }

            if (!stChecks()) {
                MessageBox.Show("Status do Caixa obrigatório");
                return;
            }


            try
            {
                caixa = new Caixa();

                caixa.NrCaixa = Convert.ToInt32(txNoCaixa.Text);
                caixa.NmCaixa = txDescricao.Text;
                caixa.StCaixa = getStatusCheck();

                caixaBLL.salvaCaixa(caixa, op);
                caixa = null;
                atualizaGrid();
                op = 0;
                limparCampos();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: "+ex.Message);
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            preecherCampos(Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value));
            op = 2;
        }

        private void caixaCadastroForm_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função não disponível");
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            
        }
    }
}
