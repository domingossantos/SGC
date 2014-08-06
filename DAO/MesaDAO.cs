using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Modelos;

namespace DAO
{
    public class MesaDAO
    {
        private SqlConnection con;

        public MesaDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getMesa()
        {
            String sql = "select m.nrCartao, c.nmCartao, m.dtInclusao, u.nmUsuario"
                        + " from tblMesa m inner join vwCartaoAssinatura c on m.nrCartao = c.nrCartao"
                        + " inner join tblUsuario u on m.dsLogin = u.dsLogin"
                        + " order by m.dtInclusao desc";
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

        public void addMesa(string nrCartao, string dsLogin)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "INSERT INTO tblMesa"
                        + "(dsLogin,nrCartao,dtInclusao) values"
                        + "(@dsLogin,@nrCartao,getDate())";


                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dsLogin", dsLogin);
                cmd.Parameters.AddWithValue("@nrCartao", nrCartao);

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

        public void delMesa() {
            try {
                string sql = "delete from tblMesa";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                
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
