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


namespace sgc.caixa
{
    public partial class movimentoCaixaUsuarioForm : Form
    {
        private Conexao con;
        private CaixaBLL caixaBLL;
        private UsuarioBLL usuarioBLL;
        public movimentoCaixaUsuarioForm()
        {
            con = new Conexao(Dados.strConexao);
            caixaBLL = new CaixaBLL(con);
            usuarioBLL = new UsuarioBLL(con);
            InitializeComponent();
        }

        private void movimentoCaixaUsuarioForm_Load(object sender, EventArgs e)
        {
            
            carregaUsuario();
        }

        private void carregaUsuario() {
            cbUsuario.DataSource = usuarioBLL.getUsuarios();
            cbUsuario.ValueMember = "dsLogin";
            cbUsuario.DisplayMember = "nmUsuario";
        }

        private void atualizaGrid() {
            try
            {
                grid.DataSource = caixaBLL.getMovimentoDiaPorUsuarioCaixa(
                        utils.formatos.formatoData( dtInicio.Value.ToShortDateString(),true),
                        utils.formatos.formatoData( dtInicio.Value.ToShortDateString(),true),
                        cbUsuario.SelectedValue.ToString(),
                        txNrCaixa.Text
                    );
                grid.Columns[0].HeaderText = "Tipo Doc.";
                grid.Columns[0].Width = 150;
                grid.Columns[1].HeaderText = "Ato";
                grid.Columns[1].Width = 250;
                grid.Columns[2].HeaderText = "Qtd.";
                grid.Columns[2].Width = 30;
                grid.Columns[3].HeaderText = "Desconto";
                grid.Columns[3].Width = 100;
                grid.Columns[3].DefaultCellStyle.Format = "c";
                grid.Columns[4].HeaderText = "Valor";
                grid.Columns[4].Width = 100;
                grid.Columns[4].DefaultCellStyle.Format = "c";
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao atualizar dados\n"+ex.Message);
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            atualizaGrid();
        }
    }
}
