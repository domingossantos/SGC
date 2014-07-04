using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;
using DAO;

namespace BLL
{
    /// <summary>
    /// Classe de negócio que trata das fncionalidade do cartão de assinatura
    /// </summary>
    public class AssinaturasBLL
    {
        private Conexao con;
        private Conexao conRemoto;
        private CartaoAssinaturaDAO cartaoDAO;
        private AssinaturaDAO assinaturaDAO;
        private AtoOperacaoDAO atosDAO;
        private MesaDAO mesaDAO;
        private TipoRGDAO tipoRGDAO;
        private CartorioDAO cartorioDAO;
        private CartaoAssinaturaRemotoDAO cartaoRemotoDAO;

        public AssinaturasBLL(Conexao objCon)
        {
            this.con = objCon;
            cartaoDAO = new CartaoAssinaturaDAO(con.ObjCon);
            assinaturaDAO = new AssinaturaDAO(con.ObjCon);
            atosDAO = new AtoOperacaoDAO(con.ObjCon);
            mesaDAO = new MesaDAO(con.ObjCon);
            conRemoto = new Conexao(Dados.StrConRemoto);
            cartaoRemotoDAO = new CartaoAssinaturaRemotoDAO(conRemoto.ObjCon);
            cartorioDAO = new CartorioDAO(con.ObjCon);
            tipoRGDAO = new TipoRGDAO(con.ObjCon);
        }

        public DataTable pesquisaCartao(String arg, int tipo,bool remoto = false)
        {
            DataTable dados = new DataTable();

            if (!remoto)
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                try
                {
                    switch (tipo)
                    {
                        case 1:
                            dados = cartaoDAO.pesquisaCartaoNome(arg);
                            break;
                        case 2:
                            dados = cartaoDAO.pesquisaCartaoCPF(arg);
                            break;
                        case 3:
                            dados = cartaoDAO.pesquisaCartaoRG(arg);
                            break;
                        case 4:
                            dados = cartaoDAO.pesquisaCartaoNumero(arg);
                            break;
                        case 5:
                            dados = cartaoDAO.pesquisaCartaoCidade(arg);
                            break;
                        case 6:
                            dados = cartaoDAO.pesquisaCartaoCartorio(arg);
                            break;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao pesquisar Cartão:\n" + e.Message);
                }
                finally
                {
                    con.ObjCon.Close();
                }
            }
            else {
                conRemoto.ObjCon.Open();
                try
                {
                    switch (tipo)
                    {
                        case 1:
                            dados = cartaoRemotoDAO.pesquisaCartaoNome(arg);
                            break;
                        case 2:
                            dados = cartaoRemotoDAO.pesquisaCartaoCPF(arg);
                            break;
                        case 3:
                            dados = cartaoRemotoDAO.pesquisaCartaoRG(arg);
                            break;
                        case 4:
                            dados = cartaoRemotoDAO.pesquisaCartaoNumero(arg);
                            break;
                        case 5:
                            dados = cartaoRemotoDAO.pesquisaCartaoCidade(arg);
                            break;
                        case 6:
                            dados = cartaoRemotoDAO.pesquisaCartaoCartorio(arg);
                            break;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao pesquisar Cartão:\n" + e.Message);
                }
                finally
                {
                    conRemoto.ObjCon.Close();
                }
            }
            return dados;
        }

        public byte[] getAssinatura(String nrCartao,DateTime data)
        {
            byte[] img;

            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                img = assinaturaDAO.getAssinatura(nrCartao, data);
                
                return img;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public byte[] getUltimaAssinatura(String nrCartao,bool remoto = false)
        {
            byte[] img;
            try
            {

                if (remoto)
                {
                    
                    AssinaturaDAO assinaturaRemota = new AssinaturaDAO(conRemoto.ObjCon);
                    conRemoto.ObjCon.Open();
                    img = assinaturaRemota.getUltimaAssinatura(nrCartao);
                }
                else {
                    con.ObjCon.Open();
                    img = assinaturaDAO.getUltimaAssinatura(nrCartao);
                }


                return img;
            }
            finally {
                conRemoto.ObjCon.Close();
                con.ObjCon.Close();
            }
            
        }

        public int getExisteAssinatura(String nrCartao,DateTime dtAssinatura)
        {
            try
            {
                int i = 0;

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                i = assinaturaDAO.getExisteAssinatura(nrCartao, dtAssinatura);
                

                return i;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DateTime getDataUltimaAssinatura(string nrCartao)
        {
            try
            {
                DateTime data;
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                data = assinaturaDAO.getDataUltimaAssinatura(nrCartao);

                return data;
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public DateTime getDataUltimaAssinaturaAtualiza()
        {
            try
            {
                DateTime data;
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                data = assinaturaDAO.getDataUltimaAssinaturaAtualiza();

                return data;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getAtosAssinatura()
        {
            try
            {
                DataTable dados = new DataTable();

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                //AtoOperacaoDAO atosDAO = new AtoOperacaoDAO(con.ObjCon);
                dados = atosDAO.getAtosOperacoesValores("and cdUso in(1,3) and stRegistro = 'A'");


                return dados;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getCartaoPorArgumento(string arg,int tipo)
        {
            try
            {
                DataTable dados = null;
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                //CartaoAssinaturaDAO cartaoDAO = new CartaoAssinaturaDAO(con.ObjCon);

                switch (tipo)
                {
                    case 1:
                        dados = cartaoDAO.getCartao(" and nrCartao = '" + arg.Trim() + "'");
                        break;
                    case 2:
                        dados = cartaoDAO.getCartao(" and nrCPF = '" + arg + "'");
                        break;
                    case 3:
                        dados = cartaoDAO.getCartao(" and nmCartao like '" + arg + "%'");
                        break;
                }


                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public void saveCartaoAssinatura(CartaoAssinatura cartao,char op)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                    con.ObjCon.Open();

                CartaoAssinaturaDAO cartaoDAO = new CartaoAssinaturaDAO(con.ObjCon);
                if (op.Equals('N'))
                {
                    cartaoDAO.addCartao(cartao);
                }
                else
                {
                    cartaoDAO.saveCartao(cartao);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar registro " + e.Message);
            }
            finally {
                con.ObjCon.Close();
            }
            
        }


        public CartaoAssinatura verificaCartao(string nrCartao, string tipo="")
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                CartaoAssinatura cartao = null;

                if (cartaoDAO.existeCartao(nrCartao, tipo))
                {
                    
                    DataTable dados = cartaoDAO.getCartao(" and nrCartao = '" + nrCartao + "'");
                    cartao = new CartaoAssinatura();
                    
                    cartao.NrCartao = dados.Rows[0]["nrCartao"].ToString();
                    cartao.NmCartao = dados.Rows[0]["nmCartao"].ToString();
                    cartao.NmCidade = dados.Rows[0]["nmCidade"].ToString();
                    cartao.NrCEP = dados.Rows[0]["nrCEP"].ToString();
                    cartao.NrCPF = dados.Rows[0]["nrCPF"].ToString();
                    cartao.NrFones = dados.Rows[0]["nrFones"].ToString();
                    cartao.NrRG = dados.Rows[0]["nrRG"].ToString();
                    cartao.SgUF = dados.Rows[0]["sgUF"].ToString();
                    //cartao.TpCartao = Convert.ToChar(tipo);
                    cartao.DsBairro = dados.Rows[0]["dsBairro"].ToString();
                    cartao.DsEndereco = dados.Rows[0]["dsEndereco"].ToString();
                    cartao.DsOrgaoEmissor = dados.Rows[0]["dsOrgaoExpRG"].ToString();

                    if(!dados.Rows[0]["dtCadastro"].ToString().Equals(""))
                        cartao.DtCadastro = DateTime.Parse(dados.Rows[0]["dtCadastro"].ToString());

                    if (!dados.Rows[0]["dtExpRG"].ToString().Equals(""))
                        cartao.DtExpedicao = DateTime.Parse(dados.Rows[0]["dtExpRG"].ToString());

                    if (!dados.Rows[0]["dtNascimento"].ToString().Equals(""))
                        cartao.DtNascimento = DateTime.Parse(dados.Rows[0]["dtNascimento"].ToString());
                    
                    if (!dados.Rows[0]["dtRenovacao"].ToString().Equals(""))
                        cartao.DtRenovacao = DateTime.Parse(dados.Rows[0]["dtRenovacao"].ToString());
                    cartao.IdCartorio = Convert.ToInt32(dados.Rows[0]["idCartorio"].ToString());

                    cartao.DsObservacao = dados.Rows[0]["dsObservacao"].ToString();

                    if (!dados.Rows[0]["cdTipoRG"].ToString().Equals(""))
                    {
                        cartao.CdTipoRG = Convert.ToInt32(dados.Rows[0]["cdTipoRG"].ToString());
                    }

                    cartao.DsEmail = dados.Rows[0]["dsEmail"].ToString();
                }

                return cartao;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar registro " + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public CartaoAssinatura getCartao(string nrCartao)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                CartaoAssinatura cartao = null;

                DataTable dados = cartaoDAO.getCartao(" and nrCartao = '" + nrCartao + "'");

                if (dados.Rows.Count > 0)
                {
                    cartao = new CartaoAssinatura();
                    cartao.NrCartao = dados.Rows[0]["nrCartao"].ToString();
                    cartao.NmCartao = dados.Rows[0]["nmCartao"].ToString();
                    cartao.NmCidade = dados.Rows[0]["nmCidade"].ToString();
                    cartao.NrCEP = dados.Rows[0]["nrCEP"].ToString();
                    cartao.NrCPF = dados.Rows[0]["nrCPF"].ToString();
                    cartao.NrFones = dados.Rows[0]["nrFones"].ToString();
                    cartao.NrRG = dados.Rows[0]["nrRG"].ToString();
                    cartao.SgUF = dados.Rows[0]["sgUF"].ToString();
                    cartao.DsBairro = dados.Rows[0]["dsBairro"].ToString();
                    cartao.DsEndereco = dados.Rows[0]["dsEndereco"].ToString();
                    cartao.DsOrgaoEmissor = dados.Rows[0]["dsOrgaoExpRG"].ToString();

                    if (!dados.Rows[0]["dtCadastro"].ToString().Equals(""))
                        cartao.DtCadastro = DateTime.Parse(dados.Rows[0]["dtCadastro"].ToString());

                    if (!dados.Rows[0]["dtExpRG"].ToString().Equals(""))
                        cartao.DtExpedicao = DateTime.Parse(dados.Rows[0]["dtExpRG"].ToString());

                    if (!dados.Rows[0]["dtNascimento"].ToString().Equals(""))
                        cartao.DtNascimento = DateTime.Parse(dados.Rows[0]["dtNascimento"].ToString());

                    if (!dados.Rows[0]["dtRenovacao"].ToString().Equals(""))
                        cartao.DtRenovacao = DateTime.Parse(dados.Rows[0]["dtRenovacao"].ToString());

                    cartao.DsObservacao = dados.Rows[0]["dsObservacao"].ToString();
                    if (!dados.Rows[0]["cdTipoRG"].ToString().Equals(""))
                        cartao.CdTipoRG = Convert.ToInt32(dados.Rows[0]["cdTipoRG"].ToString());

                    cartao.DsEmail = dados.Rows[0]["dsEmail"].ToString();
                }


                return cartao;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recuperar cartão " + e.Message);
            }
            finally {
                con.ObjCon.Close();
            }
            
        }

        public CartaoAssinatura getCartaoPorCpf(string nrCpf)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                CartaoAssinatura cartao = null;

                DataTable dados = cartaoDAO.getCartao(" and nrCpf = '" + nrCpf + "'");

                if (dados.Rows.Count > 0)
                {
                    cartao = new CartaoAssinatura();
                    cartao.NrCartao = dados.Rows[0]["nrCartao"].ToString();
                    cartao.NmCartao = dados.Rows[0]["nmCartao"].ToString();
                    cartao.NmCidade = dados.Rows[0]["nmCidade"].ToString();
                    cartao.NrCEP = dados.Rows[0]["nrCEP"].ToString();
                    cartao.NrCPF = dados.Rows[0]["nrCPF"].ToString();
                    cartao.NrFones = dados.Rows[0]["nrFones"].ToString();
                    cartao.NrRG = dados.Rows[0]["nrRG"].ToString();
                    cartao.SgUF = dados.Rows[0]["sgUF"].ToString();
                    cartao.DsBairro = dados.Rows[0]["dsBairro"].ToString();
                    cartao.DsEndereco = dados.Rows[0]["dsEndereco"].ToString();
                    cartao.DsOrgaoEmissor = dados.Rows[0]["dsOrgaoExpRG"].ToString();

                    if (!dados.Rows[0]["dtCadastro"].ToString().Equals(""))
                        cartao.DtCadastro = DateTime.Parse(dados.Rows[0]["dtCadastro"].ToString());

                    if (!dados.Rows[0]["dtExpRG"].ToString().Equals(""))
                        cartao.DtExpedicao = DateTime.Parse(dados.Rows[0]["dtExpRG"].ToString());

                    if (!dados.Rows[0]["dtNascimento"].ToString().Equals(""))
                        cartao.DtNascimento = DateTime.Parse(dados.Rows[0]["dtNascimento"].ToString());

                    if (!dados.Rows[0]["dtRenovacao"].ToString().Equals(""))
                        cartao.DtRenovacao = DateTime.Parse(dados.Rows[0]["dtRenovacao"].ToString());

                    cartao.DsObservacao = dados.Rows[0]["dsObservacao"].ToString();
                    if (!dados.Rows[0]["cdTipoRG"].ToString().Equals(""))
                        cartao.CdTipoRG = Convert.ToInt32(dados.Rows[0]["cdTipoRG"].ToString());
                }


                return cartao;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recuperar cartão " + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }


        public DataTable getAssinaturas(string nrCartao)
        {
            try
            {
                DataTable dados = new DataTable();
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                //AssinaturaDAO assinaturaDAO = new AssinaturaDAO(con.ObjCon);
                dados = assinaturaDAO.getAssinaturas(nrCartao);

                return dados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao consultar Assinaturas");
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void addAssinatura(Assinatura assin)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                //AssinaturaDAO assinaturaDAO = new AssinaturaDAO(con.ObjCon);
                assinaturaDAO.addAssinatura(assin);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir Assinatura " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getMesa() 
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                DataTable dados = mesaDAO.getMesa();
                return dados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar Assinaturas da Mesa!");
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void salvaAssinaturaMesa(string dsLogin, string nrCartao)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                mesaDAO.addMesa(nrCartao, dsLogin);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir assinatura na mesa!" + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void deletaMesa() {

            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                mesaDAO.delMesa();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }


        public DataTable getCartoes(string nrCartaoIni, string nrCartaoFim)
        {
            try
            {
                DataTable dados = new DataTable();
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                dados = assinaturaDAO.getCartoes(nrCartaoIni, nrCartaoFim);
                return dados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao consultar Assinaturas");
            }
            finally {
                con.ObjCon.Close();
            }

        }

        public DataTable getAssinaturasParaAtualizacao(DateTime dtAtualizacao) {
            try
            {
                DataTable vDados = new DataTable();

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                vDados = assinaturaDAO.getAssinaturasParaAtualizacao(dtAtualizacao);

                return vDados;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar assinaturas:\n" + ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getTipoRGCombo()
        {
            try
            {
                DataTable vDados = new DataTable();

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                vDados = tipoRGDAO.getTipoRG();
                return vDados;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar assinaturas:\n" + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getCartoriosCombo()
        {
            try
            {
                DataTable vDados = new DataTable();

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                vDados = cartorioDAO.getListaCartorio("idCartorio not in (0, 2)");

                return vDados;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar assinaturas:\n" + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void apagaAssinatura(DateTime dtAssin, string nrCartao)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                assinaturaDAO.delAssinatura(dtAssin,nrCartao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao apagar assinatura:\n" + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void delCartaoAssinatura(string nrCartao) {
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }
            SqlTransaction trans = con.ObjCon.BeginTransaction();
            try {

                assinaturaDAO.delAssinaturas(nrCartao,trans);

                cartaoDAO.delCartao(nrCartao, trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Erro ao apagar assinatura:\n" + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public String getDesricaoTipoRG(int id) {
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }
            String desc = tipoRGDAO.getDescricao(id);
            con.ObjCon.Close();

            return desc;
        }

        public DataTable getEstadoCivil() {
            DataTable dados = new DataTable();
            try
            {
                String sql = "select idEstadoCivil, dsEstadoCivil from tblEstadoCivil order by dsEstadoCivil";
                
                SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);
                da.Fill(dados);

            }
            catch (Exception ex) {
                throw new Exception("Erro ao recuperar estado civil."+ex.Message);
            }
            return dados;
        }
    }


}
