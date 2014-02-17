using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using DAO;

namespace sgc.processos
{
    public partial class entregaDocumentoForm : Form
    {
        Processo processo;
        AtoOperacao ato;
        AtoOperacaoBLL atoBLL;
        Conexao conn;
        public entregaDocumentoForm(Processo p)
        {
            processo = p;
            conn = new Conexao(Dados.strConexao);
            atoBLL = new AtoOperacaoBLL(conn);
            InitializeComponent();
        }

        public void carregaDados() 
        {
            lbNrProcesso.Text = processo.NrProceso;
            lbLivroFolha.Text = "Livro " + processo.NrLivro + " Folha " + processo.NrFolha;
            ato = atoBLL.getAto(processo.CdAto);
            lbAto.Text = ato.DsAto;
        }

        private void entregaDocumentoForm_Load(object sender, EventArgs e)
        {
            carregaDados();
        }
    }
}
