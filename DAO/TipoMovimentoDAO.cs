using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace DAO
{
    public class TipoMovimentoDAO
    {
        private SqlConnection con;

        public TipoMovimentoDAO(SqlConnection con){
            this.con = con;
        }

        public DataTable getTipoMovimentos(string filtro = "")
        {
            string sql = "SELECT idTipoMovimento ,RTRIM(stTipoMovimento)+ '-'+[cdTipoMovimento]+' '+[dsTipoMovimento] as des_movimento,"
                        + " dsTipoMovimento,cdTipoMovimento "
                        + ",stTipoMovimento FROM tblTipoMovimento "
                        + " where 1 = 1 " + filtro + " order by cdTipoMovimento";

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
