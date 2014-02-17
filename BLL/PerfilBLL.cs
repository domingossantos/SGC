using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using Modelos;
using DAO;

namespace BLL
{
    public class PerfilBLL
    {
        private Conexao con;
        private PerfilDAO perfilDAO;
        private SetorDAO setorDAO;
        public PerfilBLL(Conexao con) {
            this.con = con;
            perfilDAO = new PerfilDAO(con.ObjCon);
            setorDAO = new SetorDAO(con.ObjCon);
        }

        public void incluir(Perfil perfil)
        {
            try
            {
                if (perfil.NmPerfil.Trim().Length == 0)
                {
                    throw new Exception("Nome do perfil é obrigatório!");
                }

                perfil.NmPerfil = perfil.NmPerfil.ToLower();

                con.ObjCon.Open();

                perfilDAO.addPerfil(perfil);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable listagem()
        {
            try
            {
                con.ObjCon.Open();
                DataTable dados = perfilDAO.getPerfil();
                
                return dados;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void deletar(int codigo)
        {
            try
            {
                con.ObjCon.Open();
                perfilDAO.delPerfil(codigo);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }
        public void alterar(Perfil perfil) 
        {
            try
            {
                con.ObjCon.Open();
                perfilDAO.savePerfil(perfil);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public DataTable listaSetor() {

            try
            {
                con.ObjCon.Open();
                DataTable dados = setorDAO.getSetor();
                
                return dados;
            }
            finally {
                con.ObjCon.Close();
            }
        }

    }
}
