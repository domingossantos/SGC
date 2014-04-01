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

namespace sgc.controleSelos
{
    public partial class situacaoSelosForm : Form
    {
        UsuarioBLL usuarioBll;
        SelosBLL seloBll;
        Conexao con;

        public situacaoSelosForm()
        {
            con = new Conexao(Dados.strConexao);
            usuarioBll = new UsuarioBLL(con);
            seloBll = new SelosBLL(con);
            InitializeComponent();
        }

        private void situacaoSelosForm_Load(object sender, EventArgs e)
        {
            getUsuarios();
            getTipoSelo();
            getTipoDocumento();
            
        }

        private void getUsuarios() {
            cbUsuario.DataSource = usuarioBll.getUsuarios();
            cbUsuario.DisplayMember = "nmUsuario";
            cbUsuario.ValueMember = "dsLogin";
        }

        private void getTipoSelo() {
            cbTipoSelo.DataSource = seloBll.getTipoSelos();
            cbTipoSelo.DisplayMember = "dsTipoSelo";
            cbTipoSelo.ValueMember = "cdTIpoSelo";
        }

        private void getTipoDocumento()
        {
            cbTipoDocumento.DataSource = seloBll.getTipoDocumentos();
            cbTipoDocumento.DisplayMember = "nmTipoDocumento";
            cbTipoDocumento.ValueMember = "cdTipoDocumento";
        }
        

        private sbyte getTipoPesquisa()
        {
            sbyte op = 0;

            if (rbDatas.Checked) {
                op = 1;
            }
            if (rbNumPedido.Checked)
            {
                op = 2;
            }
            if (rbUsuario.Checked)
            {
                op = 3;
            }
            if (rbDataUsuario.Checked)
            {
                op = 4;
            }
            if (rbNome.Checked)
            {
                op = 5;
            }
            if (rbNumSelo.Checked) {
                op = 6;
            }
            if (rbTipoSelo.Checked) {
                op = 7;
            }
            if (rbTipoDocSelo.Checked)
            {
                op = 8;
            }
            if (rbSituacao.Checked) {
                op = 9;
            }


            return op;
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime oDtInicio = Convert.ToDateTime(dtInicio.Value.ToShortDateString() + " 00:00:00");
                DateTime oDtFim = Convert.ToDateTime(dtFim.Value.ToShortDateString() + " 23:59:59");


                vwSituacaoSelosTableAdapter.Connection.ConnectionString = DAO.Dados.strConexao;

                switch (getTipoPesquisa())
                {
                    case 1:
                        this.vwSituacaoSelosTableAdapter.FillByDataUso(
                                    this.sGCDataSet.vwSituacaoSelos
                                    , oDtInicio, oDtFim);
                        break;
                    case 2:
                        this.vwSituacaoSelosTableAdapter.FillByPedido(
                                    this.sGCDataSet.vwSituacaoSelos,
                                    Convert.ToInt32(txNumPedido.Text));
                        break;
                    case 3:
                        this.vwSituacaoSelosTableAdapter.FillBy(
                                    this.sGCDataSet.vwSituacaoSelos,
                                    cbUsuario.SelectedValue.ToString());
                        break;
                    case 4:
                        this.vwSituacaoSelosTableAdapter.FillByLoginEData(
                                    this.sGCDataSet.vwSituacaoSelos,
                                    cbUsuario.SelectedValue.ToString(),
                                    oDtInicio, oDtFim);
                        break;
                    case 5:
                        this.vwSituacaoSelosTableAdapter.FillByNome(
                                    this.sGCDataSet.vwSituacaoSelos,
                                    txNome.Text);
                        break;
                    case 6:
                        this.vwSituacaoSelosTableAdapter.FillByNumSelo(
                                    this.sGCDataSet.vwSituacaoSelos,
                                    Convert.ToInt32(txNumSelo.Text));
                        break;
                    case 7:
                        this.vwSituacaoSelosTableAdapter.FillByTipoSelo(
                                    this.sGCDataSet.vwSituacaoSelos,
                                    Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()));
                        break;
                    case 8:
                        this.vwSituacaoSelosTableAdapter.FillByTipoDocumentoStatus(
                                    this.sGCDataSet.vwSituacaoSelos, cbSituacao.Text.Substring(0, 1),
                                    Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()));
                        break;
                    case 9:
                        this.vwSituacaoSelosTableAdapter.FillBySituacao(
                                    this.sGCDataSet.vwSituacaoSelos, cbSituacao.Text.Substring(0, 1));
                        break;
                }

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao gerar relatório\n"+ex.Message);
            }
        }
    }
}
