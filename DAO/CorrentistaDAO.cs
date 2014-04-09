using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Modelos;

namespace DAO
{
    public class CorrentistaDAO
    {
        private SqlConnection con;

        public CorrentistaDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getCorrentistas(string filtro = "")
        {

            string sql = "SELECT nrCPFCNPJ,nmNome,dsEndereco,dsBairro"
                        + ",nrCEP,dsCidade,sgUF,dsEmail,nrFone"
                        + ",dtInclusao,stCorrentista"
                        + " FROM tblCorrentistas"
                        + " where 1 = 1 " + filtro
                        + " order by nmNome";
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


        public Correntista getCorrentista(String cpfcnpj) {
            try
            {
                Correntista oConrrentista = new Correntista();
                String sql = "SELECT nrCPFCNPJ,nmNome,dsEndereco,dsBairro,nrCEP,dsCidade "
                            + ",sgUF,dsEmail,nrFone,dtInclusao,stCorrentista FROM tblCorrentistas "
                            + " where nrCPFCNPJ = @nrCpfCnpj";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrCpfCnpj", cpfcnpj);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    oConrrentista.NrCPFCPNJ = dr["nrCpfCnpj"].ToString();
                    oConrrentista.NmCorrentista = dr["nmNome"].ToString();
                    oConrrentista.DsEndereco = dr["dsEndereco"].ToString();
                    oConrrentista.DsBairro = dr["dsBairro"].ToString();
                    oConrrentista.NrCEP = dr["nrCEP"].ToString();
                    oConrrentista.DsCidade = dr["dsCidade"].ToString();
                    oConrrentista.SgUF = dr["sgUF"].ToString();
                    oConrrentista.DsEmail = dr["dsEmail"].ToString();
                    oConrrentista.NrFone = dr["nrFone"].ToString();
                    if (!dr["dtInclusao"].ToString().Equals(""))
                        oConrrentista.DtInclusao = DateTime.Parse(dr["dtInclusao"].ToString());

                    if (dr["stCorrentista"].ToString().Length == 1)
                    {
                        oConrrentista.StCorrentista = Convert.ToChar(dr["stCorrentista"].ToString());
                    }
                    else {
                        oConrrentista.StCorrentista = 'A';
                    }
                    dr.Close();
                }


                return oConrrentista;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public void novoCorrentista(Correntista oCorrentista) {
            try
            {
                
                String sql = "INSERT INTO tblCorrentistas "
                             +"  (nrCPFCNPJ"
                             +"  ,nmNome"
                             +"  ,dsEndereco"
                             +"  ,dsBairro"
                             +"  ,nrCEP"
                             +"  ,dsCidade"
                             +"  ,sgUF"
                             +"  ,dsEmail"
                             +"  ,nrFone"
                             +"  ,dtInclusao"
                             +"  ,stCorrentista)"
                         +" VALUES "
                             +"  (@nrCPFCNPJ"
                             +"  ,@nmNome"
                             +"  ,@dsEndereco"
                             +"  ,@dsBairro"
                             +"  ,@nrCEP"
                             +"  ,@dsCidade"
                             +"  ,@sgUF"
                             +"  ,@dsEmail"
                             +"  ,@nrFone"
                             +"  ,GETDATE()"
                             +"  ,'A')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrCpfCnpj", oCorrentista.NrCPFCPNJ);
                cmd.Parameters.AddWithValue("@nmNome", oCorrentista.NmCorrentista);
                cmd.Parameters.AddWithValue("@dsEndereco", oCorrentista.DsEndereco);
                cmd.Parameters.AddWithValue("@dsBairro", oCorrentista.DsBairro);
                cmd.Parameters.AddWithValue("@nrCEP", oCorrentista.NrCEP);
                cmd.Parameters.AddWithValue("@sgUF", oCorrentista.SgUF);
                cmd.Parameters.AddWithValue("@dsEmail", oCorrentista.DsEmail);
                cmd.Parameters.AddWithValue("@dsCidade", oCorrentista.DsCidade);
                cmd.Parameters.AddWithValue("@nrFone", oCorrentista.NrCPFCPNJ);
                

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void salvaCorrentista(Correntista oCorrentista) {
            try
            {
                
                String sql = "UPDATE dbo.tblCorrentistas "
                             +"  SET nmNome = @nmNome "
                             +"     ,dsEndereco = @dsEndereco "
                             +"     ,dsBairro = @dsBairro "
                             +"     ,nrCEP = @nrCEP "
                             +"     ,dsCidade = @dsCidade "
                             +"     ,sgUF = @sgUF "
                             +"     ,dsEmail = @dsEmail "
                             +"     ,nrFone = @nrFone "
                             +"     ,stCorrentista = @stCorrentista "
                             +" where nrCPFCNPJ = @nrCpfCnpj";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nrCpfCnpj", oCorrentista.NrCPFCPNJ);
                cmd.Parameters.AddWithValue("@nmNome", oCorrentista.NmCorrentista);
                cmd.Parameters.AddWithValue("@dsEndereco", oCorrentista.DsEndereco);
                cmd.Parameters.AddWithValue("@dsBairro", oCorrentista.DsBairro);
                cmd.Parameters.AddWithValue("@nrCEP", oCorrentista.NrCEP);
                cmd.Parameters.AddWithValue("@sgUF", oCorrentista.SgUF);
                cmd.Parameters.AddWithValue("@dsEmail", oCorrentista.DsEmail);
                cmd.Parameters.AddWithValue("@dsCidade", oCorrentista.DsCidade);
                cmd.Parameters.AddWithValue("@nrFone", oCorrentista.NrFone);
                cmd.Parameters.AddWithValue("@stCorrentista", oCorrentista.StCorrentista);

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addPedidoCorrentista(PedidoCorrentista pedido)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "INSERT INTO tblPedidosCorrentista"
                       +"(dtPedido,nrPedido,nrCPFCNPJ,vlPedido,stPedido"
                       +",dsAutorizacao)   VALUES"
                       +"(@dtPedido,@nrPedido,@nrCPFCNPJ,@vlPedido"
                       +",@stPedido,@dsAutorizacao); select @@IDENTITY;";


                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dtPedido", pedido.DtPedido);
                cmd.Parameters.AddWithValue("@nrPedido", pedido.NrPedido);
                cmd.Parameters.AddWithValue("@nrCPFCNPJ", pedido.NrCPFCNPJ);
                cmd.Parameters.AddWithValue("@vlPedido", pedido.VlPedido);
                cmd.Parameters.AddWithValue("@stPedido", pedido.StPedido);
                cmd.Parameters.AddWithValue("@dsAutorizacao", pedido.DsAutorizacao);

                pedido.IdPedidoCorrentista = Convert.ToInt32(cmd.ExecuteScalar());

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
