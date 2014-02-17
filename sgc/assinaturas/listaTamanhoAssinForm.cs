using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;

namespace sgc.assinaturas
{
    public partial class listaTamanhoAssinForm : Form
    {
        private Conexao conexao = new Conexao(Dados.strConexao);
        private AssinaturaDAO assinaturaDao;
        public listaTamanhoAssinForm()
        {
            assinaturaDao = new AssinaturaDAO(conexao.ObjCon);
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (!cbTamanho.Text.Equals(""))
            {
                Int32 tamanho = Convert.ToInt32(cbTamanho.Text);

                gdDados.DataSource = assinaturaDao.getAssinaturasPorTamanho(tamanho);
                gdDados.Columns[0].HeaderText = "Ficha";
                gdDados.Columns[1].HeaderText = "Data Ficha";
                gdDados.Columns[2].HeaderText = "Kb";
                gdDados.Columns[3].HeaderText = "Mb";

                lbQtdRegistros.Text = (gdDados.RowCount - 1).ToString();

            }
            else {
                MessageBox.Show("Selecione um tamanho");
            }
        }
    }
}
