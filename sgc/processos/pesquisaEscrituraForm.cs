using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Modelos;
using DAO;

namespace sgc.processos
{
    public partial class pesquisaEscrituraForm : Form
    {
        private EscrituraBLL escrituraBLL;
        private Escritura escritura;
        private Conexao con;
        private escrituraForm oEscForm;
        public pesquisaEscrituraForm(escrituraForm escForm)
        {
            con = new Conexao(Dados.strConexao);
            escritura = new Escritura();
            escrituraBLL = new EscrituraBLL(con);
            oEscForm = escForm;
            InitializeComponent();
        }

        private sbyte getTipo() {
            sbyte r = 0;
            if (rbNumero.Checked)
                r = 1;
            if (rbDatas.Checked)
                r = 2;
            if (rbPessoa.Checked)
                r = 3;
            if (rbEndereco.Checked)
                r = 4;
            if (rbSelo.Checked)
                r = 5;

            return r;
        }

        private void preencheGrid(DataTable dados) {
            /*
             *  idEscritura,cdAto,tpRequerente,vlDocumento"
                            + ",vlVenal,vlBaseCalculo,nrProcessoLaudemio,nrProcessoITBI"
                            + ",dtEntrada,dtSaida,tpEscritura,dsContato,dsEndereco"
                            + ",nrCEP,nmCidade,dsUF,dsFoneContato,dsEmailContato"
                            + ",dtOrcamento
             */
            grid.DataSource = dados;
            grid.Columns[0].HeaderText = "No. Ficha";
            grid.Columns[0].Width = 90;
            grid.Columns[1].Visible = false;
            grid.Columns[2].Visible = false;
            grid.Columns[3].HeaderText = "Valor Documento";
            grid.Columns[3].Width = 120;
            grid.Columns[3].DefaultCellStyle.Format = "c";
            grid.Columns[4].HeaderText = "Valor Venal";
            grid.Columns[4].Width = 120;
            grid.Columns[4].DefaultCellStyle.Format = "c";
            grid.Columns[5].HeaderText = "Valor Base Calculo";
            grid.Columns[5].Width = 120;
            grid.Columns[5].DefaultCellStyle.Format = "c";
            //grid.Columns[5].Visible = false;
            grid.Columns[6].Visible = false;
            grid.Columns[7].Visible = false;
            grid.Columns[8].Visible = false;
            grid.Columns[9].Visible = false;
            grid.Columns[10].Visible = false;
            grid.Columns[11].Visible = false;
            grid.Columns[12].Visible = false;
            grid.Columns[13].Visible = false;
            grid.Columns[14].Visible = false;
            grid.Columns[15].Visible = false;
            grid.Columns[16].Visible = false;
            grid.Columns[17].Visible = false;
            grid.Columns[18].Visible = false;
        }
        
        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            
            if (getTipo() == 0) {
                MessageBox.Show("Selecione um tipo de Pesquisa");
                return;
            }

            DataTable dados = null;

            if (getTipo() == 1) {
                dados = escrituraBLL.getEscriturasPorNum(Convert.ToInt32(utils.formatos.getValorCampoNumerico(txNum.Text)));
            }

            if (getTipo() == 2)
            {
                dados = escrituraBLL.getEscriturasEntreData(utils.formatos.formatoData(dtInicial.Value.ToString(),true),
                                                            utils.formatos.formatoData(dtFinal.Value.ToString(),true));
            }

            if (getTipo() == 3)
            {
                dados = escrituraBLL.getEscriturasPorNome(txPEssoa.Text);
            }

            if (getTipo() == 4) {
                dados = escrituraBLL.getEscriturasPorEndereco(txEndereco.Text);
            }

            if (getTipo() == 5)
            {
                dados = escrituraBLL.getEscriturasPorSelo(txNumSelo.Text);
            }

            preencheGrid(dados);
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!grid[0, grid.CurrentRow.Index].Value.ToString().Equals(""))
            {
                int id = Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value.ToString());

                oEscForm.carregaDados(id);
                oEscForm.Op = 2;
                this.Close();
            }
        }

        private void txNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                btPesquisa_Click(null, null);
            }
        }
    }
}
