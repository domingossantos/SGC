using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class SelosUsuarioDAO
    {
        private SqlConnection con;

        public SelosUsuarioDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getSelosUsuarios(String filtro = "")
        {
            String sql = "SELECT dsLogin, nrInicioSeq, nrFimSeq, cdTipoSelo,";
                    sql+= " dtAtribuicao, stSelosUsuario ";
                    sql+= " FROM tblSelosUsuario";
            if (!filtro.Equals(""))
                sql += filtro;

            sql += " order by dsLogin";

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
        
        public DataTable getSelosUsuario(String login)
        {
            String sql = "SELECT dsLogin, nrInicioSeq, nrFimSeq, cdTipoSelo,";
            sql += " dtAtribuicao, stSelosUsuario ";
            sql += " FROM tblSelosUsuario where dsLogin = '"+login+"'";
            sql += " order by cdTipoSelo,nrInicioSeq";

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

        public void registraSelosUsuario(int inicio, int final, string login,int tipo)
        {
            try
            {
                String sql = "insert into tblSelosUsuario (dsLogin, nrInicioSeq, nrFimSeq, cdTipoSelo,";
                        sql+= "dtAtribuicao, stSelosUsuario) values ";
                        sql += " (@login,@inicio,@fim,@tipo,getdate(),'A')";

                SqlCommand cmd = new SqlCommand(sql,con);
                
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@inicio", inicio);
                cmd.Parameters.AddWithValue("@fim", final);
                cmd.Parameters.AddWithValue("@tipo", tipo);

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

        public void mudaStatusSelos(string login, int inicio, int final, int tipo, char status)
        {
            try
            {
                String sql = "update tblSelosUsuario set stSelosUsuario = @status ";
                sql += "where dsLogin = @login and cdTipoSelo = @tipo ";
                sql += "and nrInicioSeq = @inicio and nrFimSeq = @final";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@inicio", inicio);
                cmd.Parameters.AddWithValue("@final", final);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }
        }
    }
}
