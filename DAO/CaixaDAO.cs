using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Modelos;

namespace DAO
{
    public class CaixaDAO
    {
        private SqlConnection con;

        public CaixaDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getCaixas(string filtro = "")
        { 
            string sql = "SELECT nrCaixa ,nmCaixa, stCaixa FROM tblCaixa "
                        + "where 1 = 1 "+ filtro + " order by nrCaixa";

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

        public Caixa getCaixa(int codigo)
        {
            string sql = "SELECT nrCaixa ,nmCaixa, stCaixa FROM tblCaixa where nrCaixa = "+codigo;
            Caixa caixa = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    dr.Read();
                    caixa = new Caixa();
                    caixa.NrCaixa = Convert.ToInt16(dr["nrCaixa"].ToString());
                    caixa.NmCaixa = (dr["nmCaixa"].ToString());
                    caixa.StCaixa = Convert.ToChar(dr["stCaixa"].ToString());
                    dr.Close();
                }
                return caixa;
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

        public void addCaixa(Caixa caixa)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "INSERT INTO tblCaixa (nrCaixa,nmCaixa,stCaixa)";
                sql += "VALUES (@nrCaixa,@nmCaixa,@stCaixa)";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@nrCaixa", caixa.NrCaixa);
                cmd.Parameters.AddWithValue("@nmCaixa", caixa.NmCaixa);
                cmd.Parameters.AddWithValue("@stCaixa", caixa.StCaixa);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void saveCaixa(Caixa caixa) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "update tblCaixa set nmCaixa=@nmCaixa,stCaixa=@stCaixa ";
                sql += "where nrCaixa = @nrCaixa";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@nrCaixa", caixa.NrCaixa);
                cmd.Parameters.AddWithValue("@nmCaixa", caixa.NmCaixa);
                cmd.Parameters.AddWithValue("@stCaixa", caixa.StCaixa);

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
