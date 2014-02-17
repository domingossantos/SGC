using System;
using System.Data.SqlClient;
using System.Data;
using Modelos;

namespace DAO
{
    public class OrcamentoDAO
    {
        private SqlConnection con;

        public OrcamentoDAO(SqlConnection oCon) {
            con = oCon;
        }

        public int newOrcamento() {
            int o = 0;

            try
            {

                string sql = "insert into tblOrcamentoEscritura (dtRegistro) values (getdate()); select @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, con);
                o = Convert.ToInt32(cmd.ExecuteScalar());
                return o;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void salvaOrcamento(Orcamento oOrcamento) { 
            
            try
            {
                string sql = "UPDATE tblOrcamentoEscritura"
                         + "  SET vlTransacao = @vlTransacao"
                         + "     ,vlVenal = @vlVenal"
                         + "     ,dsEndereco = @dsEndereco"
                         + "     ,dsContato = @dsContato"
                         + "     ,nrFoneContato = @nrFoneContato"
                         + "     ,dsObs = @dsObs"
                         + "     ,dtTransacao = @dtTransacao"
                         + "     ,idTipoEscritura = @idTipoEscritura"
                         + " WHERE idOrcamento = @id";

                SqlCommand cmd = new SqlCommand(sql,con);

                cmd.Parameters.AddWithValue("vlTransacao", oOrcamento.VlTransacao);
                cmd.Parameters.AddWithValue("vlVenal", oOrcamento.VlVenal);
                cmd.Parameters.AddWithValue("dsEndereco", oOrcamento.DsEndereco);
                cmd.Parameters.AddWithValue("dsContato", oOrcamento.DsContato);
                cmd.Parameters.AddWithValue("nrFoneContato", oOrcamento.NrFoneContato);
                cmd.Parameters.AddWithValue("dsObs", oOrcamento.DsObservacao);
                cmd.Parameters.AddWithValue("dtTransacao", oOrcamento.DtTransacao);
                cmd.Parameters.AddWithValue("idTipoEscritura", oOrcamento.IdTipoEscritura);
                cmd.Parameters.AddWithValue("id", oOrcamento.IdOrcamento);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) {
                throw new Exception("Erro"+ ex.Message);
            }
        }

        public DataTable getOrcamentos(string dtInicio, string dtFim)
        {
            DataTable dados = new DataTable();
            String sql = "select idOrcamento,"
                        +" dsEndereco, dsContato, nrFoneContato"
                        +" from tblOrcamentoEscritura"
                        +" where dtRegistro between '"+dtInicio+" 00:00:00' "
                        +" and '"+dtFim+" 23:00:00'";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Orcamento getOrcamento(int id)
        {
            Orcamento oOrcamento = null;
            String sql = "select dtTransacao,vlTransacao,vlVenal,dsEndereco "
                        +"  ,dsContato,nrFoneContato,dsObs,tpEscritura "
                        +"  ,dtRegistro,idTipoEscritura "
                        +"  from tblOrcamentoEscritura "
                        +"  where idORcamento = "+id.ToString();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows) {
                    dr.Read();
                    oOrcamento = new Orcamento();
                    oOrcamento.IdOrcamento = id;
                    if (!dr["idTipoEscritura"].ToString().Equals(""))
                        oOrcamento.IdTipoEscritura = Convert.ToInt32(dr["idTipoEscritura"].ToString());

                    oOrcamento.DsContato = dr["dsContato"].ToString();
                    oOrcamento.DsEndereco = dr["dsEndereco"].ToString();
                    oOrcamento.DsObservacao = dr["dsObs"].ToString();
                    if (!dr["dtTransacao"].ToString().Equals(""))
                        oOrcamento.DtTransacao = Convert.ToDateTime(dr["dtTransacao"].ToString());
                    
                    oOrcamento.NrFoneContato = dr["nrFoneContato"].ToString();
                    if (!dr["vlTransacao"].ToString().Equals(""))
                        oOrcamento.VlTransacao = Convert.ToDouble(dr["vlTransacao"].ToString());

                    if (!dr["vlVenal"].ToString().Equals(""))
                        oOrcamento.VlVenal = Convert.ToDouble( dr["vlVenal"].ToString());

                    dr.Close();
                }

                
                return oOrcamento;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
