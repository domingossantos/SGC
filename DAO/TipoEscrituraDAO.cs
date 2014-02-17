using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace DAO
{
    public class TipoEscrituraDAO
    {
        private SqlConnection con;

        public TipoEscrituraDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getTipoEscritura(string filtro = "")
        {
            string sql = "SELECT idTipoEscritura,dsTipoEscritura FROM tblTipoEscritura where 1 = 1 " + filtro + " order by dsTipoEscritura";

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

    }
}
