using System;
using System.Collections;
using System.Data;
using Modelos;
using DAO;
using System.Text;


namespace BLL
{
    public class MenuPerfilBLL
    {
        private Conexao con;
        private MenuPerfilDAO menuPerfilDAO;
        public MenuPerfilBLL(Conexao obj) {
            con = obj;
            menuPerfilDAO = new MenuPerfilDAO(con.ObjCon);
        }

        public void incluir(int codigo, int perfil)
        {
            con.ObjCon.Open();
            try
            {
                MenuPerfil menu = new MenuPerfil();
                menu.CdMenu = codigo;
                menu.CdPerfil = perfil;
                menuPerfilDAO.addMenuPerfil(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public bool getMenuExistePerfil(int cdPerfil,int cdMenu) {
            bool st = false;

            con.ObjCon.Open();
            if (menuPerfilDAO.getMenuPerfilUsuario(cdPerfil, cdMenu) > 0)
                st = true;
            
            con.ObjCon.Close();

            return st;
        }
    }
}