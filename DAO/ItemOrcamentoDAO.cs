using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Modelos;

namespace DAO
{
    public class ItemOrcamentoDAO
    {
        private SqlConnection con;

        public ItemOrcamentoDAO(SqlConnection c)
        {
            con = c;
        }

        public void addItemOrcamento(ItemOrcamento item, SqlTransaction trans = null) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;

                cmd.Connection = con;
                cmd.Transaction = trans;

                sql = "INSERT INTO tblItensOrcamento (idOrcamento,cdAto"
                    + ",nrQuantidade,vlTotal,dsLogin,stRegistro) VALUES (@idOrcamento"
                    + ",@cdAto,@nrQuantidade,@vlTotal,@dsLogin,'A')";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@idOrcamento", item.IdOrcamento);
                cmd.Parameters.AddWithValue("@cdAto", item.CdAto);
                cmd.Parameters.AddWithValue("@nrQuantidade", item.NrQuantidade);
                cmd.Parameters.AddWithValue("@vlTotal", item.VlTotal);
                cmd.Parameters.AddWithValue("@dsLogin", item.DsLogin);

                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Item: " + ex.Message);
            }
        }

        public DataTable getItensOrcamento(int idOrcamento)
        {

            string sql = "SELECT o.cdAto,a.dsAto "
                        +",o.nrQuantidade,o.vlTotal, o.dsLogin "
                        +"FROM tblItensOrcamento o "
                        +"inner join tblAtosOperacoes a on a.cdAto = o.cdAto"
                        +" where o.stRegistro = 'A' and o.idOrcamento = "+idOrcamento;
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

        public DataTable getItensOrcamentoRelatorio(int idOrcamento)
        {

            string sql = "SELECT a.dsAto,a.vlAto "
                        + ",o.nrQuantidade,o.vlTotal "
                        + "FROM tblItensOrcamento o "
                        + "inner join tblAtosOperacoes a on a.cdAto = o.cdAto"
                        + " where o.idOrcamento = " + idOrcamento;
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

        public void delItemOrcamento(int cdAto, int idOrcamento,SqlTransaction trans = null) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;

                cmd.Connection = con;
                cmd.Transaction = trans;

                sql = "delete from  tblItensOrcamento  "
                    + "where idOrcamento = @id and cdAto = @cdAto ";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@id", idOrcamento);
                cmd.Parameters.AddWithValue("@cdAto", cdAto);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Item: " + ex.Message);
            }
        }

        public double getValorTotalOrcamento(int idx) {
            string sql = "SELECT sum(vlTotal) total "
                        + "FROM tblItensOrcamento WHERE idOrcamento = " + idx;
            double item = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    item = dr["total"] == DBNull.Value ? 0 : Convert.ToDouble(dr["total"]);

                    dr.Close();
                }
                return item;
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

    }
}
