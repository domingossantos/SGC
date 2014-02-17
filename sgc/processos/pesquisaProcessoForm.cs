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
using sgc.utils;

namespace sgc.processos
{
    public partial class pesquisaProcessoForm : Form
    {
        private Conexao con;
        private ProcessoBLL processoBLL;
        private Processo processo;
        private String login;
        public pesquisaProcessoForm(String loginUsuario)
        {
            con = new Conexao(Dados.strConexao);
            processoBLL = new ProcessoBLL(con);
            processo = new Processo();
            login = loginUsuario;
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            pesquisaProcesso();
        }


        public short getTipoPesquisa() {
            if (rbNumProcesso.Checked)
                return 1;
            else if (rbPesquisaCpf.Checked)
                return 2;
            else if (rbPesquisaNome.Checked)
                return 3;
            else if (rbSelo.Checked)
                return 4;
            else if (rbData.Checked)
                return 5;
            else if (rbEntreDatas.Checked)
                return 6;
            else
                return 0; 

        }
        private void pesquisaProcesso()
        {
            if (getTipoPesquisa() < 5)
            { 
                if(txPesquisa.Text.Equals("")){
                    MessageBox.Show("Digite um argumento de pesquisa");
                    txPesquisa.Focus();
                }
            }
            try{

                DataTable dados = processoBLL.getProcessos(txPesquisa.Text,
                            utils.formatos.formatoData(dtInicio.Value.ToShortDateString().ToString(),true),
                            utils.formatos.formatoData(dtFim.Value.ToShortDateString().ToString(), true), 
                            getTipoPesquisa());

                if(dados.Rows.Count == 0){
                    MessageBox.Show("Não há dados a exibir");
                } else {
                    grid.DataSource = dados;
                    grid.Columns[0].Width = 100;
                    grid.Columns[0].HeaderText = "Nº Processo";

                    grid.Columns[1].Width = 100;
                    grid.Columns[1].HeaderText = "Data Entrada";

                    grid.Columns[2].Width = 100;
                    grid.Columns[2].HeaderText = "Data Saida";

                    grid.Columns[3].Width = 60;
                    grid.Columns[3].HeaderText = "Nº Selo";
                    /*
                    grid.Columns[4].Width = 80;
                    grid.Columns[4].HeaderText = "CPF/CNPJ Outorgante";
                    
                    grid.Columns[5].Width = 120;
                    grid.Columns[5].HeaderText = "Nome Outorgante";

                    grid.Columns[6].Width = 60;
                    grid.Columns[6].HeaderText = "CPF/CNPJ Outorgado";

                    grid.Columns[7].Width = 120;
                    grid.Columns[7].HeaderText = "Nome Outorgado";
                    */
                    grid.Columns[4].Width = 60;
                    grid.Columns[4].HeaderText = "Status";
                    
                    
                }

                
            }
            catch(Exception ex){
                MessageBox.Show("Erro ao pesquisar processo.\n"+ex.Message);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void pesquisaProcessoForm_Load(object sender, EventArgs e)
        {
            txPesquisa.Focus();
        }

        private void btEditarProcesso_Click(object sender, EventArgs e)
        {

            if (grid.RowCount <= 0) {
                MessageBox.Show("Selecione um processo");
                return;
            }
            
            String numProc = Convert.ToString(grid[0, grid.CurrentRow.Index].Value);

            processoForm ProcessoForm = new processoForm(login, numProc);

            ProcessoForm.MdiParent = this.MdiParent;
            ProcessoForm.panelTipoProcesso.Enabled = false;
            ProcessoForm.panelProcesso.Enabled = true;
            ProcessoForm.Show();
            this.Close();
        }

        private void brReabrirPedido_Click(object sender, EventArgs e)
        {

        }
    }
}
