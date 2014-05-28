using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;


namespace sgc.caixa
{
    public partial class ReimpressaoSangriaForm : Form
    {
        utils.ConexaoDB con;
        public ReimpressaoSangriaForm()
        {
            con = new utils.ConexaoDB(Dados.strConexao);
            InitializeComponent();
        }

        public DataTable getDados(String dsLogin = "", String dtInicio = "",String dtFim = "") {
            String sql = "select m.idMovimento,a.dsAto, m.dtMovimento,m.vlMovimento,m.tpOperacao,m.dsLogin from tblMovimentoCaixa m "
                        + "inner join tblAtosOperacoes a on a.cdAto = m.idTipoMovimento "
                        + "where 1 = 1  ";
            


            if(!dsLogin.Equals("")){
                sql += "and m.dsLogin = '"+dsLogin+"' ";
            }

            sql += "and dtMovimento between '"+dtInicio+" 00:00:00' and '"+dtFim+" 23:59:00'";

            con.abreBanco();
            DataTable dados = con.retornarDataSet(sql);
            con.fechaBanco();            

            return dados;

        }

        public void getUsuarios() {
            String sql = "select dsLogin, nmUsuario from tblUsuario order by dsLogin";

            con.abreBanco();
            cbUsuario.DataSource = con.retornarDataSet(sql);

            cbUsuario.DisplayMember = "nmUsuario";
            cbUsuario.ValueMember = "dsLogin";

            con.fechaBanco();

        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {

            String usuario = cbUsuario.SelectedValue.ToString();
            grid.DataSource = getDados(usuario, 
                                        utils.formatos.formatoData(dtInicio.Value.ToShortDateString(),true),
                                        utils.formatos.formatoData(dtFim.Value.ToShortDateString(), true));
            lblNumRegistros.Text = (grid.RowCount - 1).ToString();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                MatrixReporter.Reporter imp = new MatrixReporter.Reporter();
                sgc.utils.IniFile iniFile = new sgc.utils.IniFile(utils.sessao.PathIniFile);
                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));
                string mensagem = "";
                if (arquivo)
                {
                    if (System.IO.File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                    {
                        System.IO.File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                    }
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();
                int i = 1;

                string valor = grid[3, grid.CurrentRow.Index].Value.ToString();

                imp.PrintText(i, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));
                imp.PrintText(i++, 1, "################### RECIBO ####################");
                imp.PrintText(i++, 1, "No. Movimento:" + grid[0, grid.CurrentRow.Index].Value.ToString().PadLeft(6, '0'));
                imp.PrintText(i++, 1, "REIMPRESSAO DE NOTA");
                imp.PrintText(i++, 1, "OBS.: " + grid[1, grid.CurrentRow.Index].Value.ToString());
                imp.PrintText(i++, 1, "");
                imp.PrintText(i++, 1, "DATA REGISTRO: " + grid[2, grid.CurrentRow.Index].Value.ToString());
                imp.PrintText(i++, 1, "VALOR:");
                imp.PrintText(i++, 30, utils.formatos.formataMoeda(valor).PadLeft(8, ' '));
                imp.PrintText(i++, 1, "Impresso em........: " + DateTime.Now.ToShortDateString());
                imp.PrintText(i++, 1, "Recebido por.......: " + grid[5, grid.CurrentRow.Index].Value.ToString());
                int x = i++;
                int qtdLinhas = Convert.ToInt32(iniFile.IniReadValue("FBOLETO", "QTDFIM"));

                for (int v = 0; v < qtdLinhas; v++)
                {
                    imp.PrintText(x++, 1, "");
                }

                imp.PrintJob();
                utils.MessagensExcept.funMsgSistema("Imprimindo ",3);
            }
            catch(Exception ex){
                utils.MessagensExcept.funMsgSistema("Erro ao imprimir\n"+ex.Message,1);
            }
        }

        private void ReimpressaoSangriaForm_Load(object sender, EventArgs e)
        {
            getUsuarios();
        }
    }
}
