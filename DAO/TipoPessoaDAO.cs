using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class TipoPessoaDAO
    {
        private SqlConnection con;

        public TipoPessoaDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getTipoPessoa(String filtro = "")
        {
            String sql = "SELECT cdTipoPessoa,dsTipoPessoa"
                        +" FROM tblTipoPessoa where 1 = 1 ";

            if (!filtro.Equals(""))
                sql += filtro;

            sql += " order by dsTipoPessoa";
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
