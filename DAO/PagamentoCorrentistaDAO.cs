using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Modelos;

namespace DAO
{
    public class PagamentoCorrentistaDAO
    {
        private SqlConnection con;

        public PagamentoCorrentistaDAO(SqlConnection obj) {
            this.con = obj;
        }

        public void addPagamentoCorrentista(PagamentoCorrentista pag,SqlTransaction trans = null) {
            try
            {
                string sql = "INSERT INTO tblPagamentoCorrentista "
                            + "(nrCPFCNPJ,idMovimento,dtPagamentoCorrentista"
                            + ",vlPagamentoCorrentista)  VALUES "
                            + "(@nrCPFCNPJ,@idMovimento,@dtPagamentoCorrentista"
                            + ",@vlPagamentoCorrentista)";



                SqlCommand cmd = new SqlCommand(sql, con,trans);

                cmd.Parameters.AddWithValue("@nrCPFCNPJ",pag.NrCPFCNPJ);
                cmd.Parameters.AddWithValue("@idMovimento", pag.IdMovimento);
                cmd.Parameters.AddWithValue("@dtPagamentoCorrentista", pag.DtPagamentoCorrentista);
                cmd.Parameters.AddWithValue("@vlPagamentoCorrentista", pag.VlPagamentoCorrentista);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw new Exception("Erro ao incluir pagamento correntista.\n" + e.Message);
            }
        }

    }
}
