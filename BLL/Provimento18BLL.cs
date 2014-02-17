using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAO;

namespace BLL
{
    public class Provimento18BLL
    {
        private SqlConnection con;
        private Provimento18DAO oProvimento;

        public Provimento18BLL(SqlConnection _con) {
            con = _con;
            oProvimento = new Provimento18DAO(con);
        }

        public DataTable getProvimento(){
            DataTable Dados = new DataTable();
            try 
            { 
                con.Open();
                Dados = oProvimento.getProvimento();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Dados;
        }

        public DataTable getClasseProvimento(string provimento)
        {
            DataTable Dados = new DataTable();
            try
            {
                con.Open();

                if (provimento.Equals("CEP"))
                {
                    Dados = oProvimento.getTipoAtoCep();
                }

                if (provimento.Equals("CESDI"))
                {
                    Dados = oProvimento.getTipoAtoCesdi();
                }

                if (provimento.Equals("RCTO"))
                {
                    Dados = oProvimento.getTipoTestamento();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Dados;
        }

        public DataTable getSubclasseProvimento(String provimento, int id)
        {
            DataTable Dados = new DataTable();
            try
            {
                con.Open();
                if (provimento.Equals("CEP"))
                {
                    Dados = oProvimento.getNatureza(id);
                }

                /*
                if (provimento.Equals("CESDI"))
                {
                    Dados = oProvimento.getQualidade(id);
                }
                */

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Dados;
        }


    }
}
