using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class CartaoAssinaturaRemotoDAO
    {
        private SqlConnection con;

        public CartaoAssinaturaRemotoDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public void saveCartao(CartaoAssinatura cartao)
        {
            try
            {
                string sql = "UPDATE tblCartaoAssinatura SET ";
                sql += "nmCartao = @nmCartao ";
                sql += ",nrCPF = @nrCPF ";
                sql += ",dsEndereco = @dsEndereco ";
                sql += ",dsBairro = @dsBairro ";
                sql += ",nmCidade = @nmCidade ";
                sql += ",nrCEP = @nrCEP ";
                sql += ",sgUF = @sgUF ";
                sql += ",dtNascimento = @dtNascimento ";
                sql += ",nrRG = @nrRG ";
                sql += ",dtExpRG = @dtExpRG ";
                sql += ",dsOrgaoExpRG = @dsOrgaoExpRG ";
                sql += ",nrFones = @nrFones ";
                sql += ",tpCartao = @tpCartao ";
                sql += "WHERE nrCartao = @nrCartao";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nmCartao", cartao.NmCartao);
                cmd.Parameters.AddWithValue("@nrCPF", cartao.NrCPF);
                cmd.Parameters.AddWithValue("@dsEndereco", cartao.DsEndereco);
                cmd.Parameters.AddWithValue("@dsBairro", cartao.DsBairro);
                cmd.Parameters.AddWithValue("@nmCidade", cartao.NmCidade);
                cmd.Parameters.AddWithValue("@nrCEP", cartao.NrCEP);
                cmd.Parameters.AddWithValue("@sgUF", cartao.SgUF);
                cmd.Parameters.AddWithValue("@dtNascimento", cartao.DtNascimento);
                cmd.Parameters.AddWithValue("@nrRG", cartao.NrRG);
                cmd.Parameters.AddWithValue("@dtExpRG", cartao.DtExpedicao);
                cmd.Parameters.AddWithValue("@dsOrgaoExpRG", cartao.DsOrgaoEmissor);
                cmd.Parameters.AddWithValue("@nrFones", cartao.NrFones);
                cmd.Parameters.AddWithValue("@tpCartao", cartao.TpCartao);

                cmd.Parameters.AddWithValue("@nrCartao", cartao.NrCartao);


                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar registro" + e.Message);
            }

        }

        public void addCartao(CartaoAssinatura cartao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string sql = "INSERT INTO tblCartaoAssinatura ";
                sql += "(nrCartao,dtCadastro,nmCartao,nrCPF,dsEndereco ";
                sql += ",dsBairro,nmCidade,nrCEP,sgUF,dtNascimento,nrRG ";
                sql += ",dtExpRG,dsOrgaoExpRG,nrFones,tpCartao)VALUES ";
                sql += "(@nrCartao,@dtCadastro,@nmCartao,@nrCPF ,@dsEndereco ";
                sql += ",@dsBairro,@nmCidade,@nrCEP,@sgUF ,@dtNascimento,@nrRG ";
                sql += ",@dtExpRG,@dsOrgaoExpRG,@nrFones, @tpCartao)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nrcartao", cartao.NrCartao);
                cmd.Parameters.AddWithValue("@dtCadastro", cartao.DtCadastro);
                cmd.Parameters.AddWithValue("@nmCartao", cartao.NmCartao);
                cmd.Parameters.AddWithValue("@nrCPF", cartao.NrCPF);
                cmd.Parameters.AddWithValue("@dsEndereco", cartao.DsEndereco);
                cmd.Parameters.AddWithValue("@dsBairro", cartao.DsBairro);
                cmd.Parameters.AddWithValue("@nmCidade", cartao.NmCidade);
                cmd.Parameters.AddWithValue("@nrCEP", cartao.NrCEP);
                cmd.Parameters.AddWithValue("@sgUF", cartao.SgUF);
                cmd.Parameters.AddWithValue("@dtNascimento", cartao.DtNascimento);
                cmd.Parameters.AddWithValue("@nrRG", cartao.NrRG);
                cmd.Parameters.AddWithValue("@dtExpRG", cartao.DtExpedicao);
                cmd.Parameters.AddWithValue("@dsOrgaoExpRG", cartao.DsOrgaoEmissor);
                cmd.Parameters.AddWithValue("@nrFones", cartao.NrFones);
                cmd.Parameters.AddWithValue("@tpCartao", cartao.TpCartao);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao inserir cartão " + ex.Message);
            }
        }

        public bool existeCartao(string nrCartao, string tipo)
        {
            try
            {
                bool existe = false;

                string sql = "select count(*) as qtd from tblCartaoAssinatura where nrCartao = '" + nrCartao + "' and tpCartao = '" + tipo + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (Convert.ToInt32(dr[0].ToString()) > 0)
                    existe = true;

                dr.Close();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar cartão" + e.Message);
            }
        }

        public DataTable pesquisaCartaoNome(String nome)
        {
            DataTable dados = new DataTable();
            String sql = "select nrCartao,nmCartao,nrCPF,dtRenovacao,dsObservacao,dtCadastro ";
            sql += " from tblCartaoAssinatura where nmCartao like '" + nome + "%'";
            sql += " order by nmCartao";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }

        }

        public DataTable pesquisaCartaoCPF(String nrCPF)
        {
            DataTable dados = new DataTable();
            String sql = "select nrCartao,nmCartao,nrCPF,dtRenovacao,dsObservacao,dtCadastro";
            sql += " from tblCartaoAssinatura where nrCPF = '" + nrCPF + "'";
            sql += " order by nmCartao";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }

        }
        public DataTable pesquisaCartaoRG(String nrRG)
        {
            DataTable dados = new DataTable();
            String sql = "select nrCartao,nmCartao,nrCPF,dtRenovacao,dsObservacao,dtCadastro";
            sql += " from tblCartaoAssinatura where nrRG = '" + nrRG + "'";
            sql += " order by nmCartao";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }

        }

        public DataTable pesquisaCartaoCidade(String Cidade)
        {
            DataTable dados = new DataTable();
            String sql = "select ca.nrCartao,ca.nmCartao,c.nmCartorio,c.dsCidade,c.dsObservacao,"
                    + "ca.dtCadastro,ca.dtRenovacao,ca.nrCPF "
                    + "from tblCartaoAssinatura ca "
                    + "inner join tblCartorio c on ca.idCartorio = c.idCartorio "
                    + "where c.dsCidade like '" + Cidade + "%' order by ca.nmCartao";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }

        }
        public DataTable pesquisaCartaoCartorio(String Cartorio)
        {
            DataTable dados = new DataTable();
            String sql = "select ca.nrCartao,ca.nmCartao,c.nmCartorio,c.dsCidade,c.dsObservacao,"
                    + "ca.dtCadastro,ca.dtRenovacao,ca.nrCPF "
                    + "from tblCartaoAssinatura ca "
                    + "inner join tblCartorio c on ca.idCartorio = c.idCartorio "
                    + "where c.nmCartorio like '" + Cartorio + "%' order by c.nmCartorio";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }

        }

        public DataTable getCartao(string filtro = "")
        {

            String sql = "select nrCartao,dtCadastro,nmCartao,nrCPF,dsEndereco ";
            sql += ",dsBairro,nmCidade,nrCEP,sgUF,dtNascimento,nrRG,cdTipoRG ";
            sql += ",dtExpRG,dsOrgaoExpRG,nrFones,tpCartao,dtRenovacao,idCartorio, dsObservacao, ";
            sql += "dsEmail from tblCartaoAssinatura where 1 = 1 " + filtro;
            sql += " order by nrCartao ";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }
        }

        public CartaoAssinatura getCartaoPorNumero(string nrCartao)
        {

            String sql = "select nrCartao,dtCadastro,nmCartao,nrCPF,dsEndereco ";
            sql += ",dsBairro,nmCidade,nrCEP,sgUF,dtNascimento,nrRG,cdTipoRG ";
            sql += ",dtExpRG,dsOrgaoExpRG,nrFones,tpCartao,dtRenovacao,idCartorio,dsObservacao ";
            sql += ",dsEmail from tblCartaoAssinatura where nrCartao = '" + nrCartao + "'";
            CartaoAssinatura cartao = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    cartao = new CartaoAssinatura();
                    cartao.NrCartao = dr["nrCartao"].ToString();
                    cartao.NmCartao = (dr["nmCartao"].ToString());
                    cartao.DsEndereco = (dr["dsEndereco"].ToString());
                    cartao.DsBairro = (dr["dsBairro"].ToString());
                    cartao.NmCidade = (dr["nmCidade"].ToString());
                    cartao.NrCEP = (dr["nrCEP"].ToString());
                    cartao.NrRG = (dr["nrRG"].ToString());
                    cartao.DsOrgaoEmissor = (dr["dsOrgaoExpRG"].ToString());


                    if (dr["dtExpRG"].ToString() != "")
                        cartao.DtExpedicao = DateTime.Parse(dr["dtExpRG"].ToString());

                    cartao.NrCPF = (dr["nrCPF"].ToString());
                    cartao.NrFones = (dr["nrFones"].ToString());
                    //cartao.TpCartao = Convert.ToChar(dr["tpCartao"].ToString());
                    cartao.SgUF = (dr["sgUF"].ToString());
                    if (dr["dtNascimento"].ToString() != "")
                        cartao.DtNascimento = DateTime.Parse(dr["dtNascimento"].ToString());
                    if (dr["dtRenovacao"].ToString() != "")
                        cartao.DtRenovacao = DateTime.Parse(dr["dtRenovacao"].ToString());

                    cartao.IdCartorio = Convert.ToInt32(dr["idCartorio"].ToString());
                    cartao.DsObservacao = dr["dsObservacao"].ToString();
                    cartao.DsEmail = dr["dsEmail"].ToString();
                    dr.Close();

                }
                return cartao;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }
        }
        public DataTable pesquisaCartaoNumero(String nrCartao)
        {
            DataTable dados = new DataTable();
            String sql = "select nrCartao,nmCartao,nrCPF,dtRenovacao,dsObservacao,dtCadastro";
            sql += " from tblCartaoAssinatura where nrCartao like '" + nrCartao + "%'";
            sql += " order by nrCartao";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartão " + ex.Message);
            }

        }
    }
}
