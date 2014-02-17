using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Text;

namespace DAO 
{
    public class MenuDAO
    {
        private SqlConnection con;

        public MenuDAO(SqlConnection obj)
        {
            this.con = obj;
        }

         public DataTable getMenus()
         {
             String sql = "Select cdMenu,nmMenu from tblMenu order by cdMenu";

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

         public DataTable getMenus(int id,int perfil)
         {
             String sql = "Select m.cdMenu, m.nmMenu, "
             + "(select COUNT(*) from tblPerfilMenu p where p.cdPerfil = " + perfil + " and p.cdMenu = m.cdMenu) stMenu"
             + " from tblMenu  m where m.cdMenuPai = "+id+" order by m.cdMenu";
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

         public DataTable getMenusPerfil(int id)
         {
             String sql = "select m.cdMenu,	m.nmMenu, m.cdMenuPai"
	                    + "(select COUNT(*) from tblPerfilMenu p where p.cdPerfil = "+id+" and p.cdMenu = m.cdMenu) stMenu"
                        + " from tblMenu m order by m.cdMenuPai, m.cdMenu";
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


         public int getIdMenu(String menu) 
         {
             String sql = "Select cdMenu from tblMenu where nmMenu = '" + menu + "'";
             try
             {
                 SqlCommand cmd = new SqlCommand(sql, con);
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     dr.Read();
                     int id = Convert.ToInt32(dr["cdMenu"].ToString());
                     dr.Close();
                     return id;
                     
                 }
                 else
                 {
                     return 0;
                 }
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

         public void apagaMenusPerfil(int idPerfil) {

             try
             {
                 string sql = "delete from tblPerfilMenu where cdPerfil = " + idPerfil;
                 SqlCommand cmd = new SqlCommand(sql, con);
                 cmd.ExecuteNonQuery();

             }
             catch (Exception e) {
                 throw new Exception("Erro ao apagar registros\n"+e.Message);
             }
         }
        

    }

}
