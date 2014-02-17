using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using Modelos;
using DAO;

namespace BLL
{
    public class TipoSeloBLL
    {
        private Conexao con;
        private TipoSeloDAO tipoSeloDAO;
        public TipoSeloBLL(Conexao c)
        {
            con = c;
            tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
        }

        public DataTable getTipoSelo()
        {
            try
            {
                con.ObjCon.Open();

                DataTable dados = tipoSeloDAO.getTipoSelos();

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void addTipoSelo(TipoSelo tipo) {
            try
            {
                con.ObjCon.Open();
                tipoSeloDAO.addTipoSelo(tipo);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void saveTipoSelo(TipoSelo tipo)
        {
            try
            {
                con.ObjCon.Open();
                tipoSeloDAO.saveTipoSelo(tipo);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public TipoSelo getTipoSelo(int id) {
            try
            {
                con.ObjCon.Open();
                TipoSelo tipo = tipoSeloDAO.getTipoSelo(id);

                return tipo;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void delTipoSelo(int id) {
            try
            {
                con.ObjCon.Open();
                tipoSeloDAO.delTipoSelo(id); ;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }
    }
}
