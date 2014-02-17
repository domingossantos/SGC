using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class ProcessoDAO
    {
        private SqlConnection con;
        public ProcessoDAO(SqlConnection c)
        {
            con = c;
        }

        public Processo getProcesso(String processo)
        {
            Processo p = new Processo();

            String sql = "SELECT nrProcesso,dtInclusao,dtEmissao,nrLivro,nrFolha, "
                        + "dsPathArquivo,nrSelo,cdTipoSelo,cdAto,cdTipoDocumento,stProcesso, "
                        + "idProvimento, idClasseProvimento, idSubClasseProvimento,dsLogin, "
                        + "nrLivroComp,nrFolhaComp,dsDesconhecido,dsRefLivro,dsRefLivroComp, "
                        + "dsRefFolha,dsRefFolhaComp,dsRefUfOrigem,dsRefCartorio,vlDocumento, "
                        + "dtCasamento, dsRegimeBens,nrFilhosMaiores,dsRefCidade "
                        + "FROM tblProcesso where nrProcesso = '" + processo + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                

                if (dr.HasRows)
                {
                    p.NrProceso = dr["nrProcesso"].ToString();

                    if (!dr["dtInclusao"].ToString().Equals(""))
                        p.DtInclusao = Convert.ToDateTime(dr["dtInclusao"].ToString());

                    if (!dr["dtEmissao"].ToString().Equals(""))
                        p.DtEmissao = Convert.ToDateTime(dr["dtEmissao"].ToString());



                    if (!dr["nrLivro"].ToString().Equals(""))
                        p.NrLivro = dr["nrLivro"].ToString();

                    if (!dr["nrFolha"].ToString().Equals(""))
                        p.NrFolha = dr["nrFolha"].ToString();


                    p.DsPathArquivo = dr["dsPathArquivo"].ToString();

                    if (!dr["nrSelo"].ToString().Equals(""))
                        p.NrSelo = Convert.ToInt32(dr["nrSelo"].ToString());

                    if (!dr["cdTipoSelo"].ToString().Equals(""))
                        p.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());

                    p.CdAto = Convert.ToInt32(dr["cdAto"].ToString());
                    p.CdTipoDocumento = Convert.ToInt32(dr["cdTipoDocumento"].ToString());


                    if (!dr["stProcesso"].ToString().Equals(""))
                        p.StProcesso = Convert.ToChar(dr["stProcesso"].ToString());


                    if (!dr["idProvimento"].ToString().Equals(""))
                        p.IdProvimento = dr["idProvimento"].ToString();

                    if (!dr["idClasseProvimento"].ToString().Equals(""))
                        p.IdClasseProvimento = Convert.ToInt32(dr["idClasseProvimento"].ToString());

                    if (!dr["idSubClasseProvimento"].ToString().Equals(""))
                        p.IdSubClasseProvimento = Convert.ToInt32(dr["idSubClasseProvimento"].ToString());

                    p.DsLogin = dr["dsLogin"].ToString();

                    p.NrLivroComp = dr["nrLivroComp"].ToString();
                    p.NrFolhaComp = dr["nrFolhaComp"].ToString();
                    p.DsDesconhecido = dr["dsDesconhecido"].ToString();
                    p.DsRefLivro = dr["dsRefLivro"].ToString();
                    p.DsRefLivroComp = dr["dsRefLivroComp"].ToString();
                    p.DsRefFolha = dr["dsRefFolha"].ToString();
                    p.DsRefFolhaComp = dr["dsRefFolhaComp"].ToString();
                    p.DsRefUfOrigem = dr["dsRefUfOrigem"].ToString();
                    p.DsRefCartorio = dr["dsRefCartorio"].ToString();
                    p.DsRegimeBens = dr["dsRegimeBens"].ToString();
                    p.NrFilhosMaiores = dr["nrFilhosMaiores"].ToString();
                    p.DsRefCidade = dr["dsRefCidade"].ToString();

                    if (!dr["dtCasamento"].ToString().Equals(""))
                    {
                        p.DtCasamento = DateTime.Parse(dr["dtCasamento"].ToString());
                    }

                    if (!dr["vlDocumento"].ToString().Equals(""))
                    {
                        p.VlDocumento = Convert.ToDouble(dr["vlDocumento"].ToString());
                    }
                    else
                    {
                        p.VlDocumento = 0;
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                dr.Close();
            }
            return p;
        }

        public DataTable getProcessos(String filtro = "")
        {
            String sql = "select pr.nrProcesso,pr.dtInclusao, pr.dtEmissao,pr.nrSelo,pr.stProcesso"
                          + "      ,pr.nrLivro,pr.nrFolha,p.nrCpfCnpj,p.nmPessoa,t.dsTipoPessoa"
                          +"  from tblProcesso pr "
                          + "  left outer join tblPessoasProcesso pp on pp.nrProcesso = pr.nrProcesso "
                          + "  left outer join tblPessoas p on p.nrCpfCnpj = pp.nrCpfCnpj "
                          + "  left outer join tblTipoPessoa t on t.cdTipoPessoa = pp.cdTipoPessoa "
                          +"  where 1 = 1 " +filtro
                          +"  order by pr.nrProcesso desc";

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

        public DataTable getProcessosProvimentoCep(String filtro = "")
        {
            String sql = "select pr.nrProcesso,pr.idProvimento,c.dsTipoAto,pr.dtInclusao, pr.dtEmissao"
                          + "  ,pr.nrSelo,pr.stProcesso,pr.nrLivro,pr.nrFolha "
                          + "  from tblProcesso pr "
                          + "  inner join tblTipoAtoCep c on pr.idClasseProvimento = c.idTipoAto "
                          + "  where 1 = 1 " + filtro
                          + "  order by pr.nrProcesso desc";

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

        public String getSeqProcesso(SqlTransaction trans)
        {
            String sql = "EXEC spGetNoProcesso";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Transaction = trans;
                String nrProc;

                nrProc = (String)cmd.ExecuteScalar();

                return nrProc;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar Numero do processo " + e.Message);
            }
        }

        public String getSeqProcessoAntigo(DateTime data)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("spGetNoProcessoAntigo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter inParam = cmd.Parameters.Add("dataProcesso",SqlDbType.Date);

                inParam.Direction = ParameterDirection.Input;
                inParam.Value = data;

                SqlParameter nrProcesso = cmd.Parameters.Add("nrProcesso", SqlDbType.VarChar, 12);
                nrProcesso.Direction = ParameterDirection.Output;

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Close();

                return nrProcesso.Value.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar Numero do processo " + e.Message);
            }
        }

        public void setAtoProcesso(String usuario, 
                                   String processo,  
                                   int ato, 
                                   int tipoDoc, 
                                   string provimento18,
                                   int idClasse,
                                   int idSubClasse,
                                   SqlTransaction trans = null)
        {
            //SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.Transaction = trans;

                string sql;
                sql = "update tblProcesso set  cdTipoDocumento = @cdTipoDoc"
                      +", cdAto = @cdAto, idProvimento = @idProvimento "
                      +", idClasseProvimento = @idClasseProvimento "
                      +", idSubClasseProvimento = @idSubClasseProvimento, dsLogin = @dsLogin "
                      +"where nrProcesso = @processo";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@cdAto", ato);
                cmd.Parameters.AddWithValue("@cdTipoDoc", tipoDoc);
                cmd.Parameters.AddWithValue("@idProvimento", provimento18);
                cmd.Parameters.AddWithValue("@idClasseProvimento", idClasse);
                cmd.Parameters.AddWithValue("@idSubClasseProvimento", idSubClasse);
                cmd.Parameters.AddWithValue("@dsLogin", usuario);
                cmd.Parameters.AddWithValue("@processo", processo);


                cmd.ExecuteNonQuery();
                
                if(trans != null)
                    trans.Commit();

            }
            catch (Exception e)
            {
                //trans.Rollback();
                throw new Exception("Erro ao atribuir selo ao processo!\n" + e.Message);
            }
        }

        public void setEscrituraProcesso(String processo, int idEscritura)
        {
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.Transaction = trans;

                string sql;
                sql = "update tblProcesso set  idEscritura = @idEscritura";
                sql += " where nrProcesso = @processo";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@idEscritura", idEscritura);
                cmd.Parameters.AddWithValue("@processo", processo);

                cmd.ExecuteNonQuery();
                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Erro ao atribuir Escritura a processo!\n" + e.Message);
            }
        }


        public void setSeloProcesso(String usuario, String processo,Selo selo,SqlTransaction trans = null)
        {
            //SqlTransaction trans = con.BeginTransaction();    
            try
            {
                SelosDAO selosDAO = new SelosDAO(con);
                SqlCommand cmd = new SqlCommand();
                
                cmd.Connection = con;
                
                cmd.Transaction = trans;

                selosDAO.mudarStatusSelo(selo.NrSelo, selo.CdTipoSelo, 'U',trans);
                string sql;
                sql = "update tblProcesso set nrSelo = @nrSelo, cdTipoSelo = @cdTipoSelo";
                sql += " where nrProcesso = @processo";
                    
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nrSelo",selo.NrSelo);
                cmd.Parameters.AddWithValue("@cdTipoSelo", selo.CdTipoSelo);
                cmd.Parameters.AddWithValue("@processo", processo);

                cmd.ExecuteNonQuery();
                if(trans != null)
                    trans.Commit();
                
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Erro ao atribuir selo ao processo!\n"+ e.Message);
            }


        }

        public void setProcesso(Processo p, SqlTransaction trans = null)
        {
            String sql = "UPDATE tblProcesso SET dtInclusao = @dtInclusao ";
            sql += ",dtEmissao = @dtEmissao, nrLivro = @nrLivro ,nrFolha = @nrFolha ";
            sql += ",dsPathArquivo = @dsPathArquivo ";
            sql += ",cdAto = @cdAto, cdTipoDocumento = @cdTipoDocumento ";
            sql += ",dsObservacao = @dsObservacao ";
            sql += ",idProvimento = @idProvimento ";
            sql += ",idClasseProvimento = @idClasseProvimento ";
            sql += ",idSubClasseProvimento = @idSubClasseProvimento ";
            sql += ",dsLogin = @dsLogin ";
            sql += ",nrLivroComp = @nrLivroComp ";
            sql += ",nrFolhaComp = @nrFolhaComp ";
            sql += ",dsDesconhecido = @dsDesconhecido ";
            sql += ",dsRefLivro = @dsRefLivro ";
            sql += ",dsRefLivroComp = @dsRefLivroComp ";
            sql += ",dsRefFolha = @dsRefFolha ";
            sql += ",dsRefFolhaComp = @dsRefFolhaComp ";
            sql += ",dsRefUfOrigem = @dsRefUfOrigem ";
            sql += ",dsRefCartorio = @dsRefCartorio ";
            sql += ",stProcesso = @stProcesso ";
            sql += ",vlDocumento = @vlDocumento ";
            sql += ",dtCasamento = @dtCasamento ";
            sql += ",dsRegimeBens = @dsRegimeBens ";
            sql += ",nrFilhosMaiores = @nrFilhosMaiores ";
            sql += ",dsRefCidade = @dsRefCidade ";
            sql += "WHERE nrProcesso = @nrProcesso";

            SqlCommand cmd = new SqlCommand();
            
            try
            {
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@dtInclusao", p.DtInclusao);
                
                p.DtEmissao.ToString();

                if (p.DtEmissao.ToString().Equals("01/01/0001 00:00:00"))
                    cmd.Parameters.AddWithValue("@dtEmissao", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@dtEmissao", p.DtEmissao);

                cmd.Parameters.AddWithValue("@nrLivro", p.NrLivro);
                cmd.Parameters.AddWithValue("@nrFolha", p.NrFolha);
                cmd.Parameters.AddWithValue("@dsPathArquivo", p.DsPathArquivo);
                cmd.Parameters.AddWithValue("@cdAto", p.CdAto);
                cmd.Parameters.AddWithValue("@cdTipoDocumento", p.CdTipoDocumento);
                cmd.Parameters.AddWithValue("@nrProcesso", p.NrProceso);
                cmd.Parameters.AddWithValue("@dsObservacao", p.DsObservacao);

                cmd.Parameters.AddWithValue("@idProvimento", p.IdProvimento);
                cmd.Parameters.AddWithValue("@idClasseProvimento", p.IdClasseProvimento);
                cmd.Parameters.AddWithValue("@idSubClasseProvimento", p.IdSubClasseProvimento);
                cmd.Parameters.AddWithValue("@dsLogin", p.DsLogin);
                cmd.Parameters.AddWithValue("@nrLivroComp", p.NrLivroComp);
                cmd.Parameters.AddWithValue("@nrFolhaComp", p.NrFolhaComp);

                cmd.Parameters.AddWithValue("@dsDesconhecido", p.DsDesconhecido);
                cmd.Parameters.AddWithValue("@dsRefLivro", p.DsRefLivro);
                cmd.Parameters.AddWithValue("@dsRefLivroComp", p.DsRefLivroComp);

                cmd.Parameters.AddWithValue("@dsRefFolha", p.DsRefFolha);
                cmd.Parameters.AddWithValue("@dsRefFolhaComp", p.DsRefFolhaComp);
                cmd.Parameters.AddWithValue("@dsRefUfOrigem", p.DsRefUfOrigem);
                cmd.Parameters.AddWithValue("@dsRefCartorio", p.DsRefCartorio);
                cmd.Parameters.AddWithValue("@stProcesso", p.StProcesso);
                cmd.Parameters.AddWithValue("@vlDocumento", p.VlDocumento);

                cmd.Parameters.AddWithValue("@nrFilhosMaiores", p.NrFilhosMaiores);
                cmd.Parameters.AddWithValue("@dsRegimeBens", p.DsRegimeBens);

                cmd.Parameters.AddWithValue("@dsRefCidade", p.DsRefCidade);

                if (p.DtCasamento.ToString().Equals("01/01/0001 00:00:00"))
                {
                    cmd.Parameters.AddWithValue("@dtCasamento", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@dtCasamento", p.DtCasamento);
                }
                
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao atualizar registro.\n" + e.Message);
            }
        }

        public void delPessoaProcesso(string nrProcesso,string nrDoc) {

            try
            {
                string sql = "delete from tblPessoasProcesso where nrProcesso = @nrProcesso and nrCpfCnpj = @nrDoc";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nrProcesso", nrProcesso);
                cmd.Parameters.AddWithValue("@nrDoc", nrDoc);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao apagar registro.\n" + ex.Message);
            }
        }

        public void delPessoasProcesso(string nrProcesso, SqlTransaction trans = null)
        {

            try
            {
                string sql = "delete from tblPessoasProcesso where nrProcesso = @nrProcesso";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@nrProcesso", nrProcesso);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao apagar registro.\n" + ex.Message);
            }
        }


        public void delProcesso(string nrProcesso, SqlTransaction trans = null)
        {

            try
            {
                //string sql = "delete from tblProcesso where nrProcesso = @nrProcesso";

                String sql = "update tblProcesso set stProcesso = 'E' where nrProcesso = @nrProcesso";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@nrProcesso", nrProcesso);
          
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao apagar registro.\n" + ex.Message);
            }
        }


        public void alteraStatusProcesso(string nrProcesso,char status,SqlTransaction trans = null) {
            String sql = "UPDATE tblProcesso SET stProcesso = @status ";
            sql += "WHERE nrProcesso = @nrProcesso";

            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = trans;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@nrProcesso", nrProcesso);
                cmd.Parameters.AddWithValue("@status", status);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao atualizar Processo.\n" + e.Message);
            }
        }

    }
}
