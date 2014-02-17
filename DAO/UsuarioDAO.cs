using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using Modelos;


namespace DAO
{
    public class UsuarioDAO
    {
        private SqlConnection con;

        public UsuarioDAO(SqlConnection obj)
        {
            this.con = obj;
        }

        public DataTable getUsuarios(string filtro = "")
        {

            String sql = "SELECT dsLogin,nmUsuario,nrCPF,dtCadastro,cdPerfil,cdSetor FROM tblUsuario ";
 
            if (filtro != "")
                sql+= filtro;

            sql += " order by nmUsuario";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql,con);
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

        public Usuario getUsuario(String login)
        {
            Usuario usuario = new Usuario();
            String sql = "SELECT dsLogin,nmUsuario,vlSenha,nrCPF,ISNULL(dtCadastro,'') as dtCadastro,cdPerfil,cdSetor FROM tblUsuario ";
            sql+= " WHERE dsLogin = '"+login+"'";

            SqlCommand cmd = new SqlCommand(sql, con);

           // con.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                usuario.DsLogin = dr["dsLogin"].ToString();
                usuario.NmUsuario = dr["nmUsuario"].ToString();
                usuario.NrCPF = dr["nrCPF"].ToString();
                usuario.VlSenha = dr["vlSenha"].ToString();
                usuario.DtCadastro = Convert.ToDateTime(dr["dtCadastro"].ToString());
                usuario.CdPerfil = Convert.ToInt16(dr["cdPerfil"].ToString());
                usuario.CdSetor = Convert.ToInt16(dr["cdSetor"].ToString());
                dr.Close();
                dr.Dispose();
                return usuario;
            }
            else {
                throw new Exception("Erro ao recuperar usuário!");
            }


        }

        public void alteraSenhaUsuario(Usuario obj)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                String sql = "UPDATE tblUsuario SET vlSenha = @vlSenha ";
                            sql += "WHERE dsLogin = @dsLogin";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dsLogin", obj.DsLogin);
                cmd.Parameters.AddWithValue("@vlSenha", obj.VlSenha);
                
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                    throw new Exception("Erro ao alterar registro!");
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Number);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
            finally
            {
                //con.Close();
            }
        }

        public void saveUsuario(Usuario obj) 
        {
           
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                String sql = "UPDATE tblUsuario SET nmUsuario = @nmUsuario ";
                sql += ",nrCPF = @nrCPF ,cdPerfil = @cdPerfil, cdSetor=@cdSetor WHERE dsLogin = @dsLogin";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dsLogin", obj.DsLogin);
                cmd.Parameters.AddWithValue("@nmUsuario", obj.NmUsuario);
                cmd.Parameters.AddWithValue("@nrCPF", obj.NrCPF);
                cmd.Parameters.AddWithValue("@cdPerfil", obj.CdPerfil);
                cmd.Parameters.AddWithValue("@cdSetor", obj.CdSetor);

                
                //con.Open();

                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                    throw new Exception("Erro ao alterar registro!");
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Number);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
            finally 
            {
                //con.Close();
            }
        }

        public void addUsuario(Usuario obj)
        {
            
            try
            {

                String sql = "INSERT INTO tblUsuario (dsLogin ,nmUsuario, vlSenha,";
                sql += "nrCPF,dtCadastro ,cdPerfil,cdsetor) VALUES (@dsLogin";
                sql += ",@nmUsuario, @vlSenha,@nrCPF ,GETDATE() ,@cdPerfil,@cdSetor);";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dsLogin", obj.DsLogin);
                cmd.Parameters.AddWithValue("@nmUsuario", obj.NmUsuario);
                cmd.Parameters.AddWithValue("@nrCPF", obj.NrCPF);            
                cmd.Parameters.AddWithValue("@cdPerfil", obj.CdPerfil);
                cmd.Parameters.AddWithValue("@vlSenha",obj.VlSenha);
                cmd.Parameters.AddWithValue("@cdSetor", obj.CdSetor);
                //con.Open();
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
            finally
            {
               //con.Close();
            }
        }

        public void delUsuario(string login)
        {
            try
            {
                String sql = "delete from tblUsuario where dsLogin = '"+login+"'";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                    throw new Exception("Não foi possivel excluir registro");

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Number);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
            finally
            {
               //con.Close();
            }
        }
    }
}
