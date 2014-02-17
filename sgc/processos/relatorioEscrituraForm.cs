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

namespace sgc.processos
{
    public partial class relatorioEscrituraForm : Form
    {
        private EscrituraBLL escrituraBLL;
        public relatorioEscrituraForm()
        {
            Conexao con = new Conexao(Dados.strConexao);
            escrituraBLL = new EscrituraBLL(con);
            InitializeComponent();
        }

        private void pesquisar(sbyte tipo = 1) {

            if (tipo == 1) 
            {
                try
                {
                    grid.DataSource = escrituraBLL.getEscriturasValores(utils.formatos.formatoData(dtInicio.Value.ToShortDateString(), true),
                                                                        utils.formatos.formatoData(dtFinal.Value.ToShortDateString(), true));
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro ao executar pesquisa\n"+ex.Message);
                }
            }
        }

        private void imprimir(sbyte tipo = 1)
        {
            try 
            {
                relEscriturasForm relEscritura = new relEscriturasForm();
                relEscritura.tblListaEscrituraBindingSource.DataSource = escrituraBLL.getEscriturasValores(utils.formatos.formatoData(dtInicio.Value.ToShortDateString(), true),
                                                                        utils.formatos.formatoData(dtFinal.Value.ToShortDateString(), true));

                relEscritura.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar pesquisa\n" + ex.Message);
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}
