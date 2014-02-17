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
using sgc.utils;


namespace sgc.auxiliares
{
    public partial class atosOperacoesForm : sgc.modeloForm
    {
        private sbyte operacao;
        private Conexao con;
        private AtoOperacaoBLL atoBLL;
        private TipoDocumentoDAO tipoDoc;
        private AtoOperacao ato;
        public atosOperacoesForm()
        {
            operacao = 0;
            con = new Conexao(Dados.strConexao);
            atoBLL = new AtoOperacaoBLL(con);
            tipoDoc = new TipoDocumentoDAO(con.ObjCon);
            ato = new AtoOperacao();
            InitializeComponent();
        }

        private void atualizaGrid()
        {
         
            grid.DataSource = atoBLL.listagem(getCdUso());
            grid.Columns[0].HeaderText = "Código";
            grid.Columns[0].Width = 80;
            grid.Columns[1].HeaderText = "Ato/Operação";
            grid.Columns[1].Width = 220;
            grid.Columns[2].HeaderText = "Valor";
            grid.Columns[2].Width = 80;
            grid.Columns[2].DefaultCellStyle.Format = "c";
            grid.Columns[3].HeaderText = "Cód. TJ";
            grid.Columns[3].Width = 80;
            grid.Columns[4].HeaderText = "Uso";
            grid.Columns[4].Width = 50;
            grid.Columns[5].HeaderText = "Percentual";
            grid.Columns[5].Width = 50;
            grid.Columns[6].HeaderText = "Tipo Documento";
            grid.Columns[6].Width = 120;
            grid.Columns[7].HeaderText = "Plano Contas";
            grid.Columns[7].Width = 80;
            grid.Columns[8].HeaderText = "Tipo";
            grid.Columns[8].Width = 50;
            grid.Columns[9].HeaderText = "Status";
            grid.Columns[9].Width = 50;
            grid.Columns[10].HeaderText = "Repetição";
            grid.Columns[10].Width = 50;
            
        }

        private void carregaTipoDocumento()
        { 
            con.ObjCon.Open();

            cbTipoDocumento.DataSource = tipoDoc.getTiposDocumentos();
            cbTipoDocumento.ValueMember = "cdTipoDocumento";
            cbTipoDocumento.DisplayMember = "nmTipoDocumento";
            cbTipoDocumento.Text = "Selecione...";
            con.ObjCon.Close();

        }

        public void limpaCampos() 
        {
            lbCodAto.Text = "0";
            txDescricao.Text = "";
            txValor.Text = "";
            txCdTJ.Text = "";
            carregaTipoDocumento();
        }

        private void atosOperacoesForm_Load(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaCampos();
            txDescricao.Focus();
            operacao = 1;
        }

        private int getCdUso() 
        {
            int cd = 0;
            // Uso no Balcão
            if (rbBalcao.Checked)
                cd =  1;
            // procuração
            if (rbProcuracao.Checked)
                cd = 2;
            // Pedidos Procuração
            if (rbPedidos.Checked)
                cd = 3;
            // Escritura
            if (rbEscritura.Checked)
                cd = 4;
            // Plano contas
            if (rbPlanoConta.Checked)
                cd = 99;

            return cd;
        }

        private void setCdUso(int cd)
        {
            if (cd == 1)
                rbBalcao.Checked = true;

            if (cd == 2)
                rbProcuracao.Checked = true;

            if (cd == 3)
                rbPedidos.Checked = true;

            if (cd == 4)
                rbEscritura.Checked = true;

            if (cd == 99)
                rbPlanoConta.Checked = true;
        }

        private void setStatus(char cd)
        {
            if (cd == 'A')
                rbAtivo.Checked = true;

            if (cd == 'I')
                rbInativo.Checked = true;

        }

        
        private char getStatus() 
        {
            char status = 'A';
            if (rbAtivo.Checked)
                status = 'A';
            if (rbInativo.Checked)
                status = 'I';

            return status;
        }

        private void setRepeticao(char cd)
        {
            if (cd == 'N')
                rbRepeteNao.Checked = true;

            if (cd == 'S')
                rbRepeteSim.Checked = true;

        }

        private char getRepeticao()
        {
            char status = 'N';
            if (rbRepeteNao.Checked)
                status = 'N';
            if (rbRepeteSim.Checked)
                status = 'S';

            return status;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (operacao == 1)
            {
                ato.DsAto = txDescricao.Text;
                ato.CdUso = getCdUso();
                ato.CdTipoDocumento = Convert.ToInt32(cbTipoDocumento.SelectedValue.ToString());
                ato.VlAto = Convert.ToDouble(txValor.Text);
                ato.CdTJAto = txCdTJ.Text;
                ato.VlPercentual = Convert.ToInt32(txPercentual.Text);
                ato.CdPlanoContas = txPlanoContas.Text;
                ato.StRegistro = getStatus();
                ato.TpAto = Convert.ToChar(txTipoAto.Text);
                ato.StRepeticao = getRepeticao();

                atoBLL.incluir(ato);

                atualizaGrid();
                limpaCampos();
                MessageBox.Show("Registro incluido!");
            }
            if (operacao == 2)
            {
                ato.DsAto = txDescricao.Text;
                ato.CdUso = getCdUso();
                ato.CdTipoDocumento = Convert.ToInt32(cbTipoDocumento.SelectedValue.ToString());
                ato.VlAto = Convert.ToDouble(txValor.Text);
                ato.CdTJAto = txCdTJ.Text;
                ato.VlPercentual = Convert.ToInt32(txPercentual.Text);
                ato.CdPlanoContas = txPlanoContas.Text;
                ato.StRegistro = getStatus();
                ato.TpAto = Convert.ToChar(txTipoAto.Text);
                ato.StRepeticao = getRepeticao();
                atoBLL.salva(ato);

                atualizaGrid();
                limpaCampos();
                MessageBox.Show("Registro incluido!");
            }

        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherCampos(Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value));
            operacao = 2;
            txDescricao.Focus();
        }


        private void preencherCampos(int codigo)
        {
            
            ato = atoBLL.getAto(codigo);
            carregaTipoDocumento();

            lbCodAto.Text = Convert.ToString(ato.CdAto);
            txCdTJ.Text = ato.CdTJAto.ToString();
            txDescricao.Text = ato.DsAto;
            txValor.Text = Convert.ToString(ato.VlAto);
            cbTipoDocumento.SelectedValue = ato.CdTipoDocumento;
            setCdUso(ato.CdUso);
            txPercentual.Text = ato.VlPercentual.ToString();
            txPlanoContas.Text = ato.CdPlanoContas;
            setStatus(ato.StRegistro);
            setRepeticao(ato.StRepeticao);
            txTipoAto.Text = ato.TpAto.ToString();
            txDescricao.Focus();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (operacao == 2)
            {
                atoBLL.excluir(Convert.ToInt32(lbCodAto.Text));
                MessageBox.Show("Registro apagado!");
                atualizaGrid();
                operacao = 0;
                limpaCampos();
            }
            else
            {
                MessageBox.Show("Selecione um registro!");
            }
        }

        private void txValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txValor_Click(object sender, EventArgs e)
        {
            txValor.SelectionStart = txValor.Text.Length + 1;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            atualizaGrid();
        }
    }
}
