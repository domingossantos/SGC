using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;

namespace DAO
{
    public class MovimentoDepositoDAO
    {
        private SqlConnection con;

        public MovimentoDepositoDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getListaMovimento(string filtro = "") {
            string sql = "SELECT m.idMovimentoBanco, RIGHT('00000'+CAST( m.idEscritura AS VARCHAR(5)),6) as idEscritura,"
                        + " i.dsAto,m.vlMovimento,m.dsMovimento,m.dtMovimento,m.dsLogin "
                        + "FROM tblMovimentoDeposito m "
                        + "inner join tblAtosOperacoes i on i.cdAto = m.cdAto "
                        + " where 1 = 1 " + filtro
                        + " order by m.idMovimentoBanco desc";
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

        public void addMovimento(MovimentoDeposito movimento,SqlTransaction trans = null) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;
                cmd.Transaction = trans;
                sql = "INSERT INTO tblMovimentoDeposito "
                    + "(idEscritura,tpMovimento,dsMovimento,vlMovimento "
                    +",dtMovimento,cdAto,dsLogin,stRegistro) VALUES "
                    +"(@idEscritura,@tpMovimento,@dsMovimento,@vlMovimento "
                    + ",@dtMovimento,@cdAto,@dsLogin,@stRegistro); select @@IDENTITY;";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@idEscritura", movimento.IdEscritura);
                cmd.Parameters.AddWithValue("@tpMovimento", movimento.TpMovimento);
                cmd.Parameters.AddWithValue("@dsMovimento", movimento.DsMovimento);
                cmd.Parameters.AddWithValue("@cdAto", movimento.CdAto);
                cmd.Parameters.AddWithValue("@dtMovimento", movimento.DtMovimento);
                cmd.Parameters.AddWithValue("@vlMovimento", movimento.VlMovimento);
                cmd.Parameters.AddWithValue("@dsLogin", movimento.DsLogin);
                cmd.Parameters.AddWithValue("@stRegistro", movimento.StRegistro);
                
                movimento.IdMovimentoBanco = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void altStatusMovimento(int idx,char status,SqlTransaction trans = null) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                sql = "UPDATE tblMovimentoDeposito set stRegistro = @status where idMovimentoBanco = @id";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", idx);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public double getValorCliente(int idEscritura, char tipo) {
            try
            {
                double valor = 0;
                string sql = "select ISNULL(SUM(vlMovimento), 0) as valor FROM tblMovimentoDeposito "
                             + " WHERE  tpMovimento = @tipo and idEscritura = @id and stRegistro = 'P'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idEscritura);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                valor = Convert.ToDouble(dr["valor"]);
                dr.Close();

                return valor;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public int getAtoEscrituraMovimento(int idEscritura, int cdAto)
        {
            try
            {
                int valor = 0;
                string sql = "select count(cdAto) as qtd FROM tblMovimentoDeposito "
                             + " WHERE  idEscritura = @id and cdAto = @cdAto";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idEscritura);
                cmd.Parameters.AddWithValue("@cdAto", cdAto);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                valor = Convert.ToInt32(dr["qtd"]);
                dr.Close();

                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
