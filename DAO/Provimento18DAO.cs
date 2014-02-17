using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class Provimento18DAO
    {
        private SqlConnection con;

        public Provimento18DAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getProvimento() {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idProvimento,nmProvimento from tblProvimento18";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(Dados);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return Dados;
        }

        public DataTable getTipoAtoCesdi()
        {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idAtoCesdi as id,dsAtoCesdi as descricao from tblTipoAtoCesdi order by dsAtoCesdi";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dados;
        }

        public DataTable getQualidadeCesdi(int idCesdi)
        {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idQualidade as id,dsQualidade as descricao from tblQualdadeSesdi where idAtoSesdi = "+idCesdi+" order by nmAtoSesci";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                
                da.Fill(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dados;
        }

        public DataTable getTipoTestamento()
        {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idTipoTestamento as id,dsTipoTestamento as descricao from tblTipoTestamento order by dsTipoTestamento";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dados;
        }

        public DataTable getTipoAtoCep()
        {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idTipoAto as id,dsTipoAto as descricao from tblTipoAtoCep order by dsTipoAto";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dados;
        }

        public DataTable getNatureza(int idTipoAto)
        {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idNatureza as id,dsNatureza as descricao from tblNaturezaEscritura where idTipoAto = " + idTipoAto + " order by dsNatureza";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                da.Fill(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dados;
        }

        public DataTable getQualidade(int idAtoCesd)
        {
            DataTable Dados = new DataTable();
            try
            {
                string sql = "select idQualidade as id,dsQualidade as descricao from tblQualidadeCesdi where idAtoCesdi = " + idAtoCesd + " order by dsQualidade";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                da.Fill(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dados;
        }
    }
}
