using System;
using System.Collections;
using System.Data;
using System.Text;
using Modelos;
using DAO;

namespace BLL
{
    public class MenuBLL
    {
        private Conexao con;
        private MenuDAO menuDAO;
        public MenuBLL(Conexao con) 
        {
            this.con = con;
            this.menuDAO = new MenuDAO(con.ObjCon);
        }

        public DataTable listarMenu(int id,int idPerfil)
        {
            con.ObjCon.Open();
            DataTable dados = menuDAO.getMenus(id,idPerfil);
            con.ObjCon.Close();
            return dados;
        }

        public DataTable listarMenuPerfil(int id)
        {
            con.ObjCon.Open();
            DataTable dados = menuDAO.getMenusPerfil(id);
            con.ObjCon.Close();
            return dados;
        }
        
        public int getIdMenu(String menu) {
            con.ObjCon.Open();
            int id = menuDAO.getIdMenu(menu);
            con.ObjCon.Close();
            return id;
        }

        public void apagaMenuPerfil(int idPerfil) {
            con.ObjCon.Open();
            menuDAO.apagaMenusPerfil(idPerfil);
            con.ObjCon.Close();
        }
        

        
    }
}
