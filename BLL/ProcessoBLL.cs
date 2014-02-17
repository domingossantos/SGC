using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelos;
using DAO;

namespace BLL
{
    public class ProcessoBLL
    {
        private Conexao con;

        public ProcessoBLL(Conexao c)
        {
            con = c;
        }

        public String geraNumProcesso(SqlTransaction trans = null)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                String proc = procDAO.getSeqProcesso(trans);
             

                return proc;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public String geraNumProcessoAntigo(String data)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();

                //String[] vData = data.Split('/');
                
                DateTime dtProcesso = DateTime.Parse(data);
                String proc = procDAO.getSeqProcessoAntigo(dtProcesso);

                return proc;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public void novoProcesso(String usuario, String processo, int ato, int tipoDoc,
                                 string provimento18,int idClasse,
                                 int idSubClasse, Selo selo = null, SqlTransaction trans = null)
        {
            setAtoProcesso(usuario, processo, ato, tipoDoc, provimento18,idClasse, idSubClasse, trans);
            if (selo != null)
            {
                setSeloProcesso(usuario, processo, selo,trans);
            }
        }

        public void setAtoProcesso(String usuario, String processo,
                                   int ato, int tipoDoc, string provimento18,
                                   int idClasse, int idSubClasse = 0, SqlTransaction trans = null)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                if (con.ObjCon.State == ConnectionState.Closed)
                    con.ObjCon.Open();

                procDAO.setAtoProcesso(usuario, processo,  ato, tipoDoc,provimento18,idClasse,idSubClasse,trans);
            }
            catch(Exception ex)
            {
                    throw new Exception("Erro: "+ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void setEscrituraProcesso(String processo, int idEscritura)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                procDAO.setEscrituraProcesso(processo, idEscritura);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public void setSeloProcesso(String usuario, String processo, Selo selo, SqlTransaction trans= null)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                procDAO.setSeloProcesso(usuario, processo, selo, trans);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void setPessoaProcesso(String nrCpfCnpj, String nrProcesso,int tipo)
        {
            try
            {
                PessoaDAO pessoaDAO = new PessoaDAO(con.ObjCon);
                con.ObjCon.Open();
                pessoaDAO.savePessoaProcesso(nrCpfCnpj, nrProcesso, tipo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public Processo getProcesso(String proc)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                Processo p = new Processo();
                p = procDAO.getProcesso(proc);

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }    
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getProcessos()
        {
            try
            {
                DataTable dt = new DataTable();
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                dt = procDAO.getProcessos();

                return dt;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getProcessos(DateTime data)
        {
            try
            {
                DataTable dt = new DataTable();
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                dt = procDAO.getProcessos(" and dtInclusao = '" + data.ToShortDateString() + "' and stProcesso = 'A'");

             
                return dt;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getProcessos(String nrProcesso)
        {
            try
            {
                DataTable dt = new DataTable();
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);

                con.ObjCon.Open();
                dt = procDAO.getProcessos(" and nrProcesso = '" + nrProcesso + "' ");

                return dt;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getProcessosProvimento(string provimento, String dtIni, String dtFim)
        {
            try
            {
                DataTable vDados = new DataTable();
                ProcessoDAO oDao = new ProcessoDAO(con.ObjCon);
                String where = " and pr.dtInclusao between '"+dtIni+" 00:00:00' and '"+dtFim+" 20:00:00' and pr.stProcesso <> 'E'";
                con.ObjCon.Open();
                if(provimento.Equals("CEP")){
                    vDados = oDao.getProcessosProvimentoCep(where);
                }

                return vDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getProcessos(String argumento, String dtInicio, String dtFim, short tipo = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);
                string where = " and stProcesso = 'A' ";
                if (tipo == 1)
                {
                    where = " and pr.nrProcesso= '" + argumento + "'";
                }

                if (tipo == 2)
                {
                    where = " and pr.nrProcesso in (SELECT nrProcesso from tblPessoasProcesso where nrCpfCnpj ='" + argumento + "') ";
                }

                if (tipo == 3)
                {
                    where = " and p.nmPessoa like '%" + argumento + "%'";
                }
                if (tipo == 4)
                {
                    where = " and pr.nrSelo = " + argumento + "";
                }
                if (tipo == 5)
                {
                    where = " and pr.dtInclusao <= '" +  dtInicio + " 00:00:00'";
                }

                if (tipo == 6)
                {
                    where = " and pr.dtInclusao between '" + dtInicio + " 00:00:00' and '" + dtFim + " 23:00:00'";
                }

                
                
                con.ObjCon.Open();
                dt = procDAO.getProcessos(where);

                return dt;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void setProcesso(Processo p,SqlTransaction trans = null)
        {
            try
            {
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);
                con.ObjCon.Open();
                procDAO.setProcesso(p);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public Pedido abrePedido(String login,String nrProcesso, SqlTransaction trans = null)
        {
            try
            {
                PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);
                Pedido p = new Pedido();
                ItemPedido i = new ItemPedido();
                con.ObjCon.Open();

                if (pedidoDAO.verificaPedido(nrProcesso))
                {
                    i = pedidoDAO.getItemPedidoProcesso(nrProcesso);
                    p = pedidoDAO.getPedido(i.NrPedido.ToString());

                    if (p.StPedido == 'P')
                    {
                        throw new Exception("Processo já pago!");
                    }
                }
                else
                {
                    p = pedidoDAO.getNovoPedido(login,trans);
                }
                return p;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void delPessoaProcesso(string nrProcesso, string nrPessoa) {
            try
            {
                ProcessoDAO processoDAO = new ProcessoDAO(con.ObjCon);
                con.ObjCon.Open();
                processoDAO.delPessoaProcesso(nrProcesso, nrPessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void excluiProcesso(Processo processo) {
            ProcessoDAO processoDAO = new ProcessoDAO(con.ObjCon);
            SelosDAO seloDAO = new SelosDAO(con.ObjCon);
            con.ObjCon.Open();
            SqlTransaction trans = con.ObjCon.BeginTransaction();
            try
            {
                processoDAO.alteraStatusProcesso(processo.NrProceso,'E',trans);
                seloDAO.mudarStatusSelo(processo.NrSelo, processo.CdTipoSelo, 'D', trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Pedido getPedidoProcesso(String nrProcesso) {
            try {
                con.ObjCon.Open();
                PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);
                Pedido p = pedidoDAO.getPedidoProcesso(nrProcesso);
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void gravaProcessoAntigo(Selo selo,Processo processo,string dsLogin,int cdAto, int cdTipoDoc,ref Pedido p)
        {

            con.ObjCon.Open();
            SqlTransaction trans = null; // con.ObjCon.BeginTransaction();

            try
            {
                SelosDAO selosDAO = new SelosDAO(con.ObjCon);

                selosDAO.salvaSelo(selo, trans);
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);
               
                /*this.novoProcesso(dsLogin,
                                        processo.NrProceso,
                                        cdAto,
                                        cdTipoDoc,
                                        selo,
                                        trans);
                */
                
                procDAO.setProcesso(processo,trans);

                PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);
                ItemPedido i = new ItemPedido();


                if (pedidoDAO.verificaPedido(processo.NrProceso))
                {
                    i = pedidoDAO.getItemPedidoProcesso(processo.NrProceso);
                    p = pedidoDAO.getPedido(i.NrPedido.ToString());

                    if (p.StPedido == 'P')
                    {
                        throw new Exception("Processo já pago!");
                    }
                }
                else
                {
                    p = pedidoDAO.getNovoPedido(dsLogin, trans);
                }

                AtoOperacaoDAO atoDAO = new AtoOperacaoDAO(con.ObjCon);

                AtoOperacao ato = atoDAO.getAtoOperacao(cdAto);

                i.CdAto = ato.CdAto;
                i.CdTipoSelo = processo.CdTipoSelo;
                i.NrPedido = p.NrPedido;
                i.NrProcesso = (processo.NrProceso);
                i.NrSelo = processo.NrSelo;
                i.VlItem = ato.VlAto;
                

                PedidoBLL pedidoBLL = new PedidoBLL(con);

                pedidoBLL.addItemPedido(i);

                pedidoBLL.fechaPedido(p.NrPedido, trans);

                //trans.Commit();
            }
            catch (Exception ex) {
                //trans.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void apagaProcessoProvimento18(String nrProcesso) { 
            con.ObjCon.Open();
            SqlTransaction trans = con.ObjCon.BeginTransaction();
            try
            {
                
                ProcessoDAO procDAO = new ProcessoDAO(con.ObjCon);
                //procDAO.delPessoasProcesso(nrProcesso,trans);
                procDAO.delProcesso(nrProcesso,trans);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }
    
    }

    
}
