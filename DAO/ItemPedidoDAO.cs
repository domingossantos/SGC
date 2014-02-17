using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class ItemPedidoDAO
    {
        private SqlConnection con;

        public ItemPedidoDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getItensPedido(int nrPedido,SqlTransaction trans = null)
        {
            String sql = "SELECT idItemPedido,nrPedido,cdAto,vlItem, ";
            sql += "nrSelo,cdTipoSelo,nrCartao,nrProcesso,tpReconhecimento,idMovimentoBanco ";
            sql += "FROM tblItensPedido WHERE nrPedido = " + nrPedido.ToString();
            sql += " order by nrPedido, idItemPedido";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql,con);
                
                if(trans != null)
                    da.SelectCommand.Transaction = trans;
                
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



        public DataTable getItensPedidoImpressao(string nrPedidos)
        {
            
            String sql = "select COUNT(i.cdAto) as qtd"
	                +",(select a.dsAto from tblAtosOperacoes a where a.cdAto = i.cdAto) as dsItem"
	                +",(select a.vlAto from tblAtosOperacoes a where a.cdAto = i.cdAto) as vlUnit"
	                +",SUM(i.vlItem) as vlItem"
                    +" from tblItensPedido i"
                    +" where i.nrPedido in("+nrPedidos+")"
                    +" group by i.cdAto order by i.cdAto";

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



        public void addItemPedido(ItemPedido i,SqlTransaction tran= null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;
                cmd.Connection = con;
                cmd.Transaction = tran;
                sql = "INSERT INTO tblItensPedido ";
                sql += "(nrPedido,cdAto,vlItem,nrSelo,cdTipoSelo,nrCartao,nrProcesso,tpReconhecimento,idMovimentoBanco) ";
                sql += "VALUES(@nrPedido,@cdAto,@vlItem,@nrSelo,@cdTipoSelo,@nrCartao,@nrProcesso,@tpReconhecimento,@idMovimentoBanco); ";
                sql += "select @@IDENTITY;";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@nrPedido", i.NrPedido);
                cmd.Parameters.AddWithValue("@cdAto", i.CdAto);
                cmd.Parameters.AddWithValue("@vlItem", i.VlItem);
                if (i.NrSelo == 0)
                    cmd.Parameters.AddWithValue("@nrSelo", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@nrSelo", i.NrSelo);

                if (i.CdTipoSelo == 0)
                    cmd.Parameters.AddWithValue("@cdTipoSelo", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@cdTipoSelo", i.CdTipoSelo);

                if (i.NrCartao == null)
                    cmd.Parameters.AddWithValue("@nrCartao", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@nrCartao", i.NrCartao);

                if (i.NrProcesso == null)
                    cmd.Parameters.AddWithValue("@nrProcesso", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@nrProcesso", i.NrProcesso);

                cmd.Parameters.AddWithValue("@tpReconhecimento",i.TpReconhecimento);

                if (i.IdMovimentoBanco == null)
                    cmd.Parameters.AddWithValue("@idMovimentoBanco", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idMovimentoBanco", i.IdMovimentoBanco);

                i.IdItemPedido = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao registrar item " + e.Message);
            }
        }

        public DataTable getItensPedidoEscritura(int nrPedido, SqlTransaction trans = null)
        {
            String sql = "select i.idItemPedido,a.dsAto,i.nrSelo,(select t.dsTipoSelo from tblTipoSelo t where t.cdTipoSelo = i.cdTipoSelo) as dsTipoSelo,i.vlItem "
                        +"from tblItensPedido i "
                        +"inner join tblPedidos p on p.nrPedido = i.nrPedido "
                        +"inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                        +"WHERE i.nrPedido = " + nrPedido.ToString()
                        + " order by i.nrPedido, i.idItemPedido";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                if (trans != null)
                    da.SelectCommand.Transaction = trans;

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

        public void delItemPedido(int idItem) {
            String sql = " delete  from tblItensPedido where idItemPedido = " + idItem;

            try
            {
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.ExecuteNonQuery();
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
    }
}
