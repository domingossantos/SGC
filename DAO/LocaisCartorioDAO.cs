using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Modelos;
using System.Text;

namespace DAO
{
    public class LocaisCartorioDAO
    {
        private SqlConnection con;

        public LocaisCartorioDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getLocaisCartorio()
        {
            String sql = "select cdLocalCartorio,dsLocalCartorio from tblLocaisCartorio";
            
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
