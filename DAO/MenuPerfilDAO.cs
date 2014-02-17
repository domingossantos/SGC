using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;

namespace DAO
{
    public class MenuPerfilDAO
    {
        private SqlConnection con;

        public MenuPerfilDAO(SqlConnection obj)
        {
            this.con = obj;
        }

        public void addMenuPerfil(MenuPerfil obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblPerfilMenu (cdPerfil,cdMenu) values(@perfil,@menu);";

                cmd.Parameters.AddWithValue("@perfil", obj.CdPerfil);
                cmd.Parameters.AddWithValue("@menu", obj.CdMenu);
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

        public int getMenuPerfilUsuario(int cdPerfil, int cdMenu) {
            int qt = 0;
            try
            {
                string sql = "select count(*) as qtd from tblPerfilMenu where cdPerfil = " + cdPerfil + " and cdMenu = " + cdMenu;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                 qt = Convert.ToInt32(dr["qtd"].ToString());

            }
            catch (Exception ex) {
                throw new Exception("Erro SQl: " + ex.Message);
            }


            return qt;
        }


    }
}