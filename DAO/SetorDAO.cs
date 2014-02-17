using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class SetorDAO
    {
        private SqlConnection con;

        public SetorDAO(SqlConnection objCon) 
        {
            this.con = objCon;
        }

        public DataTable getSetor()
        {

            String sql = "Select cdSetor,nmSetor,dsCor from tblSetor order by nmSetor";
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Number);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }

    }
}
