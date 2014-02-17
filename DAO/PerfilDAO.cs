using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class PerfilDAO
    {
        private SqlConnection con;

        public PerfilDAO(SqlConnection objCon) 
        {
            this.con = objCon;
        }
        public DataTable getPerfil() 
        {

            String sql = "Select cdPerfil,nmPerfil from tblPerfil order by nmPerfil";

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

        public Perfil getPerfil(int codigo)
        {
            Perfil perfil = new Perfil();
            
            SqlCommand cmd = new SqlCommand("Select cdPerfil,nmPerfil from tblPerfil where cdPerfil = "+codigo, con);
           
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            perfil.CdPerfil = Convert.ToInt32(dr["cdPerfil"].ToString());
            perfil.NmPerfil = dr["nmPerfil"].ToString();

            return perfil;
        }

            public void savePerfil(Perfil perfil)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "UPDATE tblPerfil SET nmPerfil = @perfil where cdPerfil = @codigo";

                cmd.Parameters.AddWithValue("@perfil",perfil.NmPerfil);
                cmd.Parameters.AddWithValue("@codigo", perfil.CdPerfil);
               // con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                    throw new Exception("Não foi possivel alterar registro");
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                //con.Close();
            }
        }

        public void addPerfil(Perfil perfil)
        {
            
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblPerfil (nmPerfil) values(@perfil); select @@IDENTITY;";

                cmd.Parameters.AddWithValue("@perfil", perfil.NmPerfil);

                perfil.CdPerfil = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                //con.Close();   
            }

        }

        public void delPerfil(int codigo) 
        {
   
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from tblPerfil where cdPerfil = "+codigo;
                
                //con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                    throw new Exception("Não foi possivel excluir registro");
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                //con.Close();
            }
        }
    }
}
