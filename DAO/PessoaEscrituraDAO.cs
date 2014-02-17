using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;

namespace DAO
{
    public class PessoaEscrituraDAO
    {
        private SqlConnection con;

        public PessoaEscrituraDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getPessoasEscritura(string id)
        {
            try {
                string sql = "select pe.nrCpfCnpj, p.nmPessoa,t.dsTipoPessoa "
                        + "from tblPessoasEscritura pe "
                        + "inner join tblPessoas p on pe.nrCpfCnpj = p.nrCpfCnpj "
                        + "inner join tblTipoPessoa t on pe.cdTipoPessoa = t.cdTipoPessoa "
                        + "where pe.idEscritura = "+id;

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }

        public void salvaPessoaEscritura(PessoaEscritura pe,SqlTransaction trans = null) {

            try {
                string sql = "INSERT INTO tblPessoasEscritura "
                        + "(nrCpfCnpj ,idEscritura,cdTipoPessoa) "
                        + "VALUES (@nrCpfCnpj,@idEscritura,@cdTipoPessoa)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@nrCpfCnpj", pe.NrCpfCnpj);
                cmd.Parameters.AddWithValue("@idEscritura", pe.IdEscritura);
                cmd.Parameters.AddWithValue("@cdTipoPessoa", pe.CdTipoPessoa);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }

        public void delPessoaEscritura(string nrCpfCnpj,int id) {
            try {
                string sql = "delete from tblPessoasEscritura where "
                            + "nrCpfCnpj = @nrCpfCnpj and idEscritura = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrCpfCnpj", nrCpfCnpj);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }
    }
}
