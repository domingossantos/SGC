using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using System.IO;


namespace sgc.cnj
{
    public partial class ExtrairTextoProvimento18Form : Form
    {
        public ExtrairTextoProvimento18Form()
        {
            InitializeComponent();
        }

        public void gerarArquivoCep() { 
            String sql = "select "
	                    +" p.idClasseProvimento TIPOATOCEP "
	                    +" ,p.idSubClasseProvimento NATUREZAESCRITURA "
	                    +" ,convert(varchar, pe.dtPedido, 103) DATAATO "
	                    +" ,p.nrLivro LIVRO "
	                    +" ,p.nrLivroComp LIVROCOMPLEMENTO "
	                    +" ,p.nrFolha FOLHA "
	                    +" ,p.nrFolhaComp FOLHACOMPLEMENTO "
	                    +" ,i.vlItem VALOR "
	                    +" ,p.dsDesconhecido DESCONHECIDO "
	                    +" ,p.dsRefLivro REFERENTELIVRO "
	                    +" ,p.dsRefLivroComp REFERENTELIVROCOMPLEMENTO "
	                    +" ,p.dsRefFolha REFERENTEFOLHA "
	                    +" ,p.dsRefFolhaComp REFERENTEFOLHACOMPLEMENTO "
	                    +" ,p.dsRefUfOrigem REFERENTEUFORIGEM "
	                    +" ,'' REFERENTECIDADEORIGEM "
	                    +" ,p.dsRefCartorio REFERENTECARTORIO "
	                    +" ,pa.nmPessoa PARTENOME "
	                    +" ,pa.nrRg PARTEIDENTIDADE "
	                    +" ,pa.dsOrgaoEmissor PARTEORGAOEMISSOR "
	                    +" ,case " 
		                +"     when len(pa.nrCpfCnpj) = 11 then 'CPF' "
		                +"     when len(pa.nrCpfCnpj) = 14 then 'CNPJ' "
	                    +" end PARTETIPODOCUMENTO "
	                    +" ,pa.nrCpfCnpj PARTENUMERODOCUMENTO "
	                    +" ,tp.dsTipoPessoa PARTEQUALIDADE "
                        +" from tblProcesso p "
                        +" inner join tblPessoasProcesso pp on p.nrProcesso = pp.nrProcesso "
                        +" inner join tblPessoas pa on pp.nrCpfCnpj = pa.nrCpfCnpj "
                        +" inner join tblTipoPessoa tp on pp.cdTipoPessoa = tp.cdTipoPessoa "
                        +" inner join tblItensPedido i on p.nrProcesso = i.nrProcesso and p.cdAto = i.cdAto "
                        +" inner join tblPedidos pe on i.nrPedido = pe.nrPedido "
                        +" where p.idProvimento = 'CEP' "
                        +" and pe.dtPedido between '2012-11-16 00:00:00' and '2012-11-26 20:00:00'";

            
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = null;
                try
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        string path = saveFileDialog1.FileName;
                        myStream.Close();
                        StreamWriter arquivo = new StreamWriter(path);
                        

                        Conexao con = new Conexao(Dados.strConexao);
                        con.ObjCon.Open();

                        SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);
                        DataTable vDados = new DataTable();

                        da.Fill(vDados);

                        DataView dvDados = new DataView(vDados);
                        DataRow drDados;
                        arquivo.WriteLine("\"TIPOATOCEP\";\"NATUREZAESCRITURA\";\"DATAATO\";\"LIVRO\";\"LIVROCOMPLEMENTO\";\"FOLHA\";\"FOLHACOMPLEMENTO\";\"VALOR\";\"DESCONHECIDO\";\"REFERENTELIVRO\";\"REFERENTELIVROCOMPLEMENTO\";\"REFERENTEFOLHA\";\"REFERENTEFOLHACOMPLEMENTO\";\"REFERENTEUFORIGEM\";\"REFERENTECIDADEORIGEM\";\"REFERENTECARTORIO\";\"PARTENOME\";\"PARTEIDENTIDADE\";\"PARTEORGAOEMISSOR\";\"PARTETIPODOCUMENTO\";\"PARTENUMERODOCUMENTO\";\"PARTEQUALIDADE\"");

                        for (int i = 0; i < dvDados.Count; i++)
                        {
                            drDados = dvDados[i].Row;

                            arquivo.WriteLine(drDados[0].ToString());

                        }

                        arquivo.Flush();
                        arquivo.Close();
                    }
                }
                finally
                {

                    myStream.Close();   
                    
                }

            }   
            
            
            



        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            gerarArquivoCep();
        }
    }
}
