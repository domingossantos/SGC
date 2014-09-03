using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class PessoaDAO
    {
        private SqlConnection con;

        public PessoaDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getPessoas(String filtro = "")
        {
            String sql = "SELECT nrCpfCnpj,tpPessoa,nmPessoa,dsEndereco,nrFones "
                         +" ,dsEmail,nrRg,dsOrgaoEmissor,nmPai,nmMae "
                         +" ,dtNascimento,dsCidade,dsUf,tpDocumento,idCidade "
                         + " ,dtRgExpedicao,nrDocumento,dsUfDocumento,dtExpedicaoDocumento "
                         + " ,dsBairro,dsUfNascimento,dsPaisNascimento,dsSexo"
                         +" FROM tblPessoas where 1 = 1";

            if (!filtro.Equals(""))
                sql += filtro;

            sql += " order by nmPessoa";
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

        public Pessoa getPessoa(String cpfcnpj)
        {
            Pessoa pessoa = new Pessoa();

            String sql = "SELECT nrCpfCnpj,tpPessoa,nmPessoa,dsEndereco,nrFones "
                         + " ,dsEmail,nrRg,dsOrgaoEmissor,nmPai,nmMae "
                         + " ,dtNascimento,dsCidade,dsUf,tpDocumento,idCidade "
                         + " ,dtRgExpedicao,nrDocumento,dsUfDocumento,dtExpedicaoDocumento "
                         + " ,dsBairro,dsUfNascimento,dsPaisNascimento,dsSexo"
                        +" FROM tblPessoas where nrCpfCnpj = @numero";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numero", cpfcnpj);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    pessoa.NrCpfCnpj = dr["nrCpfCnpj"].ToString();
                    pessoa.NmPessoa = dr["nmPessoa"].ToString();
                    pessoa.DsEndereco = dr["dsEndereco"].ToString();
                    pessoa.DsBairro = dr["dsBairro"].ToString();
                    pessoa.DsEmail = dr["dsEmail"].ToString();
                    pessoa.NrFones = dr["nrFones"].ToString();
                    pessoa.TpPessoa = Convert.ToChar(dr["tpPessoa"].ToString());
                    pessoa.DsCidade = dr["dsCidade"].ToString();

                    if (!dr["idCidade"].ToString().Equals(""))
                    {
                        pessoa.IdCidade = Convert.ToInt32(dr["idCidade"].ToString());
                    }

                    pessoa.DsUf = dr["dsUf"].ToString();
                    pessoa.DtNascimento = dr["dtNascimento"].ToString();
                    pessoa.NrRg = dr["nrRg"].ToString();
                    pessoa.DsOrgaoEmissor = dr["dsOrgaoEmissor"].ToString();
                    pessoa.DtRgExpedicao = dr["dtRgExpedicao"].ToString();
                    pessoa.NmMae = dr["nmMae"].ToString();
                    pessoa.NmPai = dr["nmPai"].ToString();
                    pessoa.TpDocumento = dr["tpDocumento"].ToString();
                    pessoa.NrDocumento = dr["nrDocumento"].ToString();
                    pessoa.DtExpedicaoDocumento = dr["dtExpedicaoDocumento"].ToString();
                    pessoa.DsUfDocumento = dr["dsUfDocumento"].ToString();
                    pessoa.DsUfNascimento = dr["dsUfNascimento"].ToString();
                    pessoa.DsPaisNascimento = dr["dsPaisNascimento"].ToString();
                    if (!dr["dsSexo"].ToString().Equals(""))
                    {
                        pessoa.DsSexo = Convert.ToChar(dr["dsSexo"]);
                    }

                    dr.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recuperar dado: "+e.Message);
            }
            return pessoa;
        }

        public void savePessoaMinimo(Pessoa p) {
            try
            {
                String sql = "insert into tblPessoas (nrCpfCnpj,tpPessoa,nmPessoa) values (@nrCpfCnpj,@tipo,@nome)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrCpfCnpj", p.NrCpfCnpj);
                cmd.Parameters.AddWithValue("@tipo", p.TpPessoa);
                cmd.Parameters.AddWithValue("@nome", p.NmPessoa);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw new Exception("Erro ao registrar pessoa\n" + ex.Message);
            }
        }

        public void savePessoa(Pessoa p)
        {
            try
            {
                String sql = "insert into tblPessoas (nrCpfCnpj,tpPessoa,nmPessoa,dsEndereco,nrFones,dsEmail, "
                            + " nrRg,dsOrgaoEmissor,nmPai,nmMae,dtNascimento,dsUf,tpDocumento, "
                            + " idCidade,dtRgExpedicao,nrDocumento,dsUfDocumento,dtExpedicaoDocumento,dsBairro, "
                            + " dsUfNascimento,dsPaisNascimento,dsSexo) "
                            + " values (@nrCpfCnpj,@tpPessoa,@nmPessoa,@dsEndereco,@nrFones,@dsEmail,@nrRg,"
                            + "@dsOrgaoEmissor,@nmPai,@nmMae,@dtNascimento,@dsUf,@tpDocumento, "
                            + "@idCidade,@dtRgExpedicao,@nrDocumento,@dsUfDocumento,@dtExpedicaoDocumento, "
                            + "@dsBairro,@dsUfNascimento,@dsPaisNascimento,@dsSexo)";

                SqlCommand cmd = new SqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@nrCpfCnpj", p.NrCpfCnpj);
                cmd.Parameters.AddWithValue("@tpPessoa", p.TpPessoa);
                cmd.Parameters.AddWithValue("@nmPessoa", p.NmPessoa);
                cmd.Parameters.AddWithValue("@dsEndereco", p.DsEndereco);
                cmd.Parameters.AddWithValue("@dsEmail", p.DsEmail);
                cmd.Parameters.AddWithValue("@nrFones", p.NrFones);
                cmd.Parameters.AddWithValue("@nrRg", p.NrRg);
                cmd.Parameters.AddWithValue("@dsOrgaoEmissor", p.DsOrgaoEmissor);
                cmd.Parameters.AddWithValue("@nmPai", p.NmPai);
                cmd.Parameters.AddWithValue("@nmMae", p.NmMae);
                cmd.Parameters.AddWithValue("@dtNascimento", p.DtNascimento);
                cmd.Parameters.AddWithValue("@dsUf", p.DsUf);
                cmd.Parameters.AddWithValue("@tpDocumento", p.TpDocumento);


                if (p.IdCidade <= 0)
                {
                    cmd.Parameters.AddWithValue("@idCidade", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idCidade", p.IdCidade);
                }

                cmd.Parameters.AddWithValue("@dtRgExpedicao", p.DtRgExpedicao);
                cmd.Parameters.AddWithValue("@nrDocumento", p.NrDocumento);
                cmd.Parameters.AddWithValue("@dsUfDocumento", p.DsUfDocumento);
                cmd.Parameters.AddWithValue("@dtExpedicaoDocumento", p.DtExpedicaoDocumento);
                cmd.Parameters.AddWithValue("@dsBairro", p.DsBairro);
                cmd.Parameters.AddWithValue("@dsUfNascimento", p.DsUfNascimento);
                cmd.Parameters.AddWithValue("@dsPaisNascimento", p.DsPaisNascimento);
                cmd.Parameters.AddWithValue("@dsSexo", p.DsSexo);

                cmd.ExecuteNonQuery();                
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void updatePessoa(Pessoa p)
        {
            try
            {
                String sql = "UPDATE tblPessoas"
                              +"     SET tpPessoa = @tpPessoa,nmPessoa = @nmPessoa"
                              +"        ,dsEndereco = @dsEndereco,nrFones = @nrFones"
                              +"        ,dsEmail = @dsEmail,nrRg = @nrRg"
                              +"        ,dsOrgaoEmissor = @dsOrgaoEmissor"
                              +"        ,nmPai = @nmPai,nmMae = @nmMae"
                              +"        ,dtNascimento = @dtNascimento"
                              +"        ,dsCidade = @dsCidade,dsUf = @dsUf"
                              +"        ,tpDocumento = @tpDocumento"
                              +"        , idCidade = @idCidade"
                              +"        , dtRgExpedicao = @dtRgExpedicao"
                              +"        , nrDocumento = @nrDocumento"
                              +"        , dsUfDocumento = @dsUfDocumento"
                              +"        , dtExpedicaoDocumento = @dtExpedicaoDocumento"
                              +"        , dsBairro = @dsBairro"
                              +"        , dsUfNascimento = @dsUfNascimento"
                              +"        , dsPaisNascimento = @dsPaisNascimento"
                              +"        , dsSexo = @dsSexo"
                              +"   WHERE nrCpfCnpj = @nrCpfCnpj";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nrCpfCnpj", p.NrCpfCnpj);
                cmd.Parameters.AddWithValue("@nmPessoa", p.NmPessoa);
                cmd.Parameters.AddWithValue("@dsEmail", p.DsEmail);
                cmd.Parameters.AddWithValue("@dsEndereco", p.DsEndereco);
                cmd.Parameters.AddWithValue("@nrFones", p.NrFones);
                cmd.Parameters.AddWithValue("@tpPessoa", p.TpPessoa);
                cmd.Parameters.AddWithValue("@nrRg", p.NrRg);
                cmd.Parameters.AddWithValue("@dsOrgaoEmissor", p.DsOrgaoEmissor);
                cmd.Parameters.AddWithValue("@nmPai", p.NmPai);
                cmd.Parameters.AddWithValue("@nmMae", p.NmMae);
                cmd.Parameters.AddWithValue("@dtNascimento", p.DtNascimento);
                cmd.Parameters.AddWithValue("@dsCidade", p.TpPessoa);
                cmd.Parameters.AddWithValue("@dsUf", p.DsUf);
                cmd.Parameters.AddWithValue("@tpDocumento", p.TpDocumento);

                if (p.IdCidade.Equals(null))
                {
                    cmd.Parameters.AddWithValue("@idCidade", DBNull.Value);
                } else {
                    cmd.Parameters.AddWithValue("@idCidade", p.IdCidade);
                }
                cmd.Parameters.AddWithValue("@dtRgExpedicao", p.DtRgExpedicao);
                cmd.Parameters.AddWithValue("@nrDocumento", p.NrDocumento);
                cmd.Parameters.AddWithValue("@dsUfDocumento", p.DsUfDocumento);
                cmd.Parameters.AddWithValue("@dtExpedicaoDocumento", p.DtExpedicaoDocumento);
                cmd.Parameters.AddWithValue("@dsBairro", p.DsBairro);
                cmd.Parameters.AddWithValue("@dsUfNascimento", p.DsUfNascimento);
                cmd.Parameters.AddWithValue("@dsPaisNascimento", p.DsPaisNascimento);
                cmd.Parameters.AddWithValue("@dsSexo", p.DsSexo);


                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void savePessoaProcesso(String nrCpfCnpj, String nrProcesso,int tipo)
        {
            try
            {
                String sql = "insert into tblPessoasProcesso (nrProcesso,nrCpfCnpj,cdTipoPessoa) ";
                sql += "values (@processo,@cpfcnpj,@tipo)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cpfcnpj", nrCpfCnpj);
                cmd.Parameters.AddWithValue("@processo", nrProcesso);
                cmd.Parameters.AddWithValue("@tipo", tipo);
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

        public DataTable getPessoasProcesso(String nrProcesso)
        {
            Pessoa pessoa = new Pessoa();

            String sql = "select p.nrCpfCnpj,p.nmPessoa,p.nrFones,t.dsTipoPessoa ";
            sql += "from tblPessoasProcesso pp ";
            sql += "inner join tblPessoas p on pp.nrCpfCnpj = p.nrCpfCnpj ";
            sql += "inner join tblTipoPessoa t on pp.cdTipoPessoa = t.cdTipoPessoa ";
            sql += "where pp.nrProcesso = '"+nrProcesso+"' order by p.nmPessoa, t.cdTipoPessoa";

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

        public void savePessoaOrcamento(String nrCpfCnpj, int idOrcamento, int tipo)
        {
            try
            {
                String sql = "insert into tblPessoaOrcamento (idOrcamento,nrCpfCnpj,cdTipoPessoa) ";
                sql += "values (@orcamento,@cpfcnpj,@tipo)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cpfcnpj", nrCpfCnpj);
                cmd.Parameters.AddWithValue("@orcamento", idOrcamento);
                cmd.Parameters.AddWithValue("@tipo", tipo);
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

        public void delPessoaOrcamento(string nrCpfCnpj,int idOrcamento) {
            try
            {
                String sql = "delete from tblPessoaOrcamento ";
                sql += "where nrCpfCnpj = @cpfcnpj and idOrcamento = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@cpfcnpj", nrCpfCnpj);
                cmd.Parameters.AddWithValue("@id", idOrcamento);
                
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public DataTable getPessoasOrcamento(int idOrcamento)
        {
            String sql = "select po.nrCpfCnpj, p.nmPessoa, t.dsTipoPessoa, po.cdTipoPessoa "
                        +" from tblPessoaOrcamento po"
                        +" inner join tblPessoas p on p.nrCpfCnpj = po.nrCpfCnpj"
                        +" inner join tblTipoPessoa t on t.cdTipoPessoa = po.cdTipoPessoa"
                        +" where po.idOrcamento = "+idOrcamento.ToString();

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

    }
}

