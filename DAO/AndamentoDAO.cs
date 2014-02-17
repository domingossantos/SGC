using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;

namespace DAO
{
    public class AndamentoDAO
    {
        private SqlConnection con;

        public AndamentoDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getListaAndamentos(string filtro = "")
        {
            string sql = "SELECT idAndamento,dsAndamento,dtAndamento,vlAndamento, dsLogin "
                        + "FROM tblAndamentoEscritura "
                        + " where 1 = 1 " + filtro + " order by idAndamento desc";
            try
            {

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

        public void addAndamento(Andamento andamento, SqlTransaction trans = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;
                cmd.Transaction = trans;
                sql = "INSERT INTO tblAndamentoEscritura "
                    + "(idEscritura,dsAndamento,dtAndamento,vlAndamento,dsLogin) "
                    + " VALUES (@idEscritura,@dsAndamento,@dtAndamento,@vlAndamento,@dsLogin); "
                    + " select @@IDENTITY;";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@idEscritura", andamento.IdEscritura);
                cmd.Parameters.AddWithValue("@dsAndamento", andamento.DsAndamento);
                cmd.Parameters.AddWithValue("@dtAndamento", andamento.DtAndamento);
                cmd.Parameters.AddWithValue("@vlAndamento", andamento.VlAndamento);
                cmd.Parameters.AddWithValue("@dsLogin", andamento.DsLogin);

                andamento.IdAndamento = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void delAndamento(int idx) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;
                sql = "UPDATE tblAndamentoEscritura set stRegistro = 'I'"
                    + " where idAndamento = @idx";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@idx", idx);


                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
