using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;


namespace DAO
{

    public class HistoricoCaixaDAO
    {
        private SqlConnection con;

        public HistoricoCaixaDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getHistorioscoCaixas(string filtro = "")
        {
            string sql = "SELECT idHistoricoCaixa,dtAbertura,dtFechamento,"
                         + "dsLogin,nrCaixa FROM tblHistoricoCaixa "
                         + " where 1 = 1 " + filtro +" order by idHistoricoCaixa desc"; 
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

        public HistoricoCaixa getHistoricoCaixa(int codigo)
        {
            string sql = "SELECT idHistoricoCaixa,dtAbertura,dtFechamento,"
                         + "dsLogin,nrCaixa FROM tblHistoricoCaixa "
                         + " where idHistoricoCaixa = " + codigo;
            HistoricoCaixa historico = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    historico = new HistoricoCaixa();
                    historico.IdHistoricocaixa = Convert.ToInt32(dr["idHistoricoCaixa"].ToString());
                    historico.DsLogin = (dr["dsLogin"].ToString());
                    historico.DtAbertura = DateTime.Parse(dr["dtAbertura"].ToString());
                    if (dr["dtFechamento"].ToString() != "")
                        historico.DtFechamento = DateTime.Parse(dr["dtFechamento"].ToString());
                    historico.NrCaixa = Convert.ToInt16(dr["nrCaixa"].ToString());
                    dr.Close();
                }
                return historico;
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

        public HistoricoCaixa getUltimoHistoricoCaixaUsuario(string dsLogin)
        {
            string sql = "SELECT idHistoricoCaixa,dtAbertura,dtFechamento,"
                         + "dsLogin,nrCaixa FROM tblHistoricoCaixa "
                         + " where idHistoricoCaixa = (select MAX(idHistoricoCaixa) "
                         + " from tblHistoricoCaixa where dsLogin = '"+dsLogin+"')";
            HistoricoCaixa historico = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    historico = new HistoricoCaixa();
                    historico.IdHistoricocaixa = Convert.ToInt32(dr["idHistoricoCaixa"].ToString());
                    historico.DsLogin = (dr["dsLogin"].ToString());
                    historico.DtAbertura = DateTime.Parse(dr["dtAbertura"].ToString());
                    if (dr["dtFechamento"].ToString() != "")
                        historico.DtFechamento = DateTime.Parse(dr["dtFechamento"].ToString());
                    historico.NrCaixa = Convert.ToInt16(dr["nrCaixa"].ToString());
                    dr.Close();
                }
                return historico;
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

        public HistoricoCaixa getUltimoHistoricoCaixaUsuario(int nrCaixa)
        {
            string sql = "SELECT idHistoricoCaixa,dtAbertura,dtFechamento,"
                         + "dsLogin,nrCaixa FROM tblHistoricoCaixa "
                         + " where idHistoricoCaixa = (select MAX(idHistoricoCaixa) "
                         + " from tblHistoricoCaixa where nrCaixa = '"+nrCaixa+"')";
            HistoricoCaixa historico = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                   
                    dr.Read();
                    historico = new HistoricoCaixa();
                    historico.IdHistoricocaixa = Convert.ToInt32(dr["idHistoricoCaixa"].ToString());
                    historico.DsLogin = (dr["dsLogin"].ToString());
                    historico.DtAbertura = DateTime.Parse(dr["dtAbertura"].ToString());
                    if (dr["dtFechamento"].ToString() != "")
                        historico.DtFechamento = DateTime.Parse(dr["dtFechamento"].ToString());
                    historico.NrCaixa = Convert.ToInt16(dr["nrCaixa"].ToString());
                    dr.Close();
                }
                return historico;
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

        public void addHistoricoCaixa(HistoricoCaixa historico)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "INSERT INTO tblHistoricoCaixa"
                        +"(dtAbertura,dsLogin,nrCaixa)"
                        + "VALUES(@dtAbertura,@dsLogin,@nrCaixa); select @@IDENTITY;";


                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dtAbertura", historico.DtAbertura);
                cmd.Parameters.AddWithValue("@nrCaixa", historico.NrCaixa);
                cmd.Parameters.AddWithValue("@dsLogin", historico.DsLogin);

                historico.IdHistoricocaixa = Convert.ToInt32(cmd.ExecuteScalar());

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

        public void atualizaHistorico(HistoricoCaixa historico) 
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "UPDATE tblHistoricoCaixa set dtFechamento = @dtFechamento where idHistoricoCaixa = @idHistorico";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dtFechamento", historico.DtFechamento);
                cmd.Parameters.AddWithValue("@idHistorico", historico.IdHistoricocaixa);

                historico.IdHistoricocaixa = cmd.ExecuteNonQuery();

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
    }
}
