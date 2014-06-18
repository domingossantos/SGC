using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelos;
using DAO;
using MatrixReporter;
using System.IO;


namespace BLL
{
    public class PedidoBLL
    {
        private Conexao con;
        private Conexao conRemoto;
        private Reporter imp;
        private EpsonCodes iCodes;
        private PedidoDAO pedidoDAO;
        private ItemPedidoDAO itemPedidoDAO;
        private AtoOperacaoDAO atoDAO;
        private TipoDocumentoDAO tipoDocDao;
        private SelosDAO seloDAO;
        private CartaoAssinaturaDAO cartaoDAO;
        private MovimentoCaixaDAO movimentoDAO;
        private CaixaDAO caixaDAO;
        private HistoricoCaixaDAO historicoCaixaDAO;
        private UsuarioDAO usuarioDAO;
        private TipoSeloDAO tipoSeloDAO;
        public PedidoBLL(Conexao c)
        {
            con = c;
            conRemoto = new Conexao(Dados.StrConRemoto);
            imp = new Reporter();
            iCodes = new EpsonCodes();
            pedidoDAO = new PedidoDAO(con.ObjCon);
            itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
            atoDAO = new AtoOperacaoDAO(con.ObjCon);
            tipoDocDao = new TipoDocumentoDAO(con.ObjCon);
            seloDAO = new SelosDAO(con.ObjCon);
            cartaoDAO = new CartaoAssinaturaDAO(con.ObjCon);
            movimentoDAO = new MovimentoCaixaDAO(con.ObjCon);
            caixaDAO = new CaixaDAO(con.ObjCon);
            historicoCaixaDAO = new HistoricoCaixaDAO(con.ObjCon);
            usuarioDAO = new UsuarioDAO(con.ObjCon);
            tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
        }

        public Pedido abrePedido(String login)
        {
            //PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);
            Pedido p = new Pedido();
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }
            try
            {
                p = pedidoDAO.getNovoPedido(login);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
            return p;
        }

        public void gravaItemPedido(ItemPedido i)
        {
            //ItemPedidoDAO itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }

            try
            {
                itemPedidoDAO.addItemPedido(i);
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

        public AtoOperacao getAtoOperacao(int codigo)
        {
            try
            {
                AtoOperacao ato = new AtoOperacao();
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                ato = atoDAO.getAtoOperacao(codigo);

                return ato;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public TipoDocumento getTipoDocumento(int codigo)
        {
            //TipoDocumentoDAO tipoDocDao = new TipoDocumentoDAO(con.ObjCon);
            try
            {
                TipoDocumento tipoDoc = new TipoDocumento();
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                tipoDoc = tipoDocDao.getTipoDocumento(codigo);

                return tipoDoc;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getItensPedidos(int nrPedido)
        {
            try
            {
                DataTable dados = new DataTable();
                //ItemPedidoDAO itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                dados = itemPedidoDAO.getItensPedido(nrPedido);

                return dados;
            }
            finally
            {
                //con.ObjCon.Close();
            }
        }

        public DataTable getItensPedidosEscritura(int nrPedido)
        {
            try
            {
                DataTable dados = new DataTable();
                //ItemPedidoDAO itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                dados = itemPedidoDAO.getItensPedidoEscritura(nrPedido);

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getItensPedidosImpressao(List<int> nrPedidos)
        {
            try
            {
                DataTable dados = new DataTable();
                //ItemPedidoDAO itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                string pedidos = "";
                for (int i = 0; i < nrPedidos.Count; i++)
                {
                    pedidos += nrPedidos[i].ToString() + ",";
                }

                pedidos = pedidos.Substring(0, (pedidos.Length - 1));
                dados = itemPedidoDAO.getItensPedidoImpressao(pedidos);

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public DataTable getOperacoesProcuracao()
        {
            try
            {
                DataTable dados = new DataTable();
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                AtoOperacaoDAO atos = new AtoOperacaoDAO(con.ObjCon);
                dados = atos.getAtosOperacoes(" and cdUso = 3");


                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public void pagaPedido(int nrPedido) {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                    con.ObjCon.Open();

                pedidoDAO.atualizaPedido(nrPedido, 'P');

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public double fechaPedido(int nrPedido, SqlTransaction trans = null)
        {
            try
            {
                //PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);

                if (con.ObjCon.State == ConnectionState.Closed)
                    con.ObjCon.Open();

                SqlCommand cmd = new SqlCommand("spFechaPedido", con.ObjCon);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = cmd.Parameters.Add(new SqlParameter("@pedido", SqlDbType.BigInt));
                param.Direction = ParameterDirection.Input;
                param.Value = nrPedido;
                SqlDataReader dr = null;
                Double valor = 0;
                dr = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (dr.HasRows)
                {
                    dr.Read();
                    valor = Convert.ToDouble(dr["total"].ToString());
                }

                #region Fechamento Antigo
                //ItemPedidoDAO itemDAO = new ItemPedidoDAO(con.ObjCon);
                //SelosDAO seloDAO = new SelosDAO(con.ObjCon);
                /*
                DataTable dados = itemPedidoDAO.getItensPedido(nrPedido);

                DataView dvDados = new DataView(dados);
                DataRow drDados;
                double valor = 0;
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    //string nselo = drDados["nrSelo"].ToString();
                    valor += Convert.ToDouble(drDados["vlItem"].ToString());
                    //if (drDados["nrSelo"].ToString() != "")
                    //{
                    //    seloDAO.mudarStatusSelo(Convert.ToInt16(drDados["nrSelo"].ToString()), Convert.ToInt16(drDados["cdTipoSelo"].ToString()),'U');
                    //}

                }
                pedidoDAO.atualizaPedido(nrPedido, 'F', trans);
                */
                #endregion
                return valor;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void cancelaPedido(int nrPedido)
        {
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }
            SqlTransaction trans = con.ObjCon.BeginTransaction();

            try
            {

                DataTable dados = itemPedidoDAO.getItensPedido(nrPedido, trans);


                DataView dvDados = new DataView(dados);
                DataRow drDados;
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    string nselo = drDados["nrSelo"].ToString();

                    if (drDados["nrSelo"].ToString() != "")
                    {
                        seloDAO.mudarStatusSelo(Convert.ToInt32(drDados["nrSelo"].ToString()), Convert.ToInt32(drDados["cdTipoSelo"].ToString()), 'D', trans);
                    }

                }
                pedidoDAO.atualizaPedido(nrPedido, 'C', trans);
                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Erro ao cancelar pedido\n" + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void apagarPedido(int nrPedido) {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                pedidoDAO.atualizaPedido(nrPedido, 'C', null);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }
        
        public void cancelaPedido(int nrPedido,Double valor, String login)
        {
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }
            SqlTransaction trans = con.ObjCon.BeginTransaction();

            try
            {

                DataTable dados = itemPedidoDAO.getItensPedido(nrPedido, trans);


                DataView dvDados = new DataView(dados);
                DataRow drDados;
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    string nselo = drDados["nrSelo"].ToString();

                    if (drDados["nrSelo"].ToString() != "")
                    {
                        seloDAO.mudarStatusSelo(Convert.ToInt32(drDados["nrSelo"].ToString()), Convert.ToInt32(drDados["cdTipoSelo"].ToString()), 'D', trans);
                    }

                }
                pedidoDAO.atualizaPedido(nrPedido, 'C', trans);
                trans.Commit();
                pedidoDAO.registraCancelamento(login,nrPedido,valor);

            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Erro ao cancelar pedido\n" + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void pagaPedido(int nrPedido, HistoricoCaixa historico, int tpPagamento, SqlTransaction trans = null)
        {

            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }
            DataTable dados = itemPedidoDAO.getItensPedido(nrPedido);

            double valor = 0;
            DataView dvDados = new DataView(dados);
            DataRow drDados;
            int nrSelo = 0;
            int cdTipo = 0;
            try
            {
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    string nselo = drDados["nrSelo"].ToString();

                    if (drDados["nrSelo"].ToString() != "")
                    {
                        nrSelo = Convert.ToInt32(nselo);
                        cdTipo = Convert.ToInt32(drDados["cdTipoSelo"].ToString());
                        seloDAO.mudarStatusSelo(nrSelo, cdTipo, 'U',trans);
                    }

                    valor += Convert.ToDouble(drDados["vlItem"].ToString());

                }

                pedidoDAO.atualizaPedido(nrPedido, 'P',trans);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao fechar pedido\n" + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getPedidosAbertos(string filtro = "")
        {
            try
            {
                //PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);
                DataTable dados = new DataTable();
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                dados = pedidoDAO.getPedidosItens(" and p.stPedido in ('A','F') " + filtro);

                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Pedido getUltimoPedido(string nrPedido)
        {
            try
            {
                //PedidoDAO pedidoDAO = new PedidoDAO(con.ObjCon);
                con.ObjCon.Open();
                Pedido pedido = pedidoDAO.getPedido(nrPedido);
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                return pedido;
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public Selo getUltimoSelo(int tipo, string login)
        {
            //SelosDAO seloDAO = new SelosDAO(con.ObjCon
            Selo selo = null;
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                selo = seloDAO.getUltimoSelo(atoDAO.getAtoOperacao(tipo).CdTipoDocumento, login);
                return selo;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recuperar ultimo pedido:\n" + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public void mudaStatusSelo(int nrSelo, int tipo, char status)
        {
            //SelosDAO seloDAO = new SelosDAO(con.ObjCon);
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                seloDAO.mudarStatusSelo(nrSelo, tipo, status);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void addItemPedido(ItemPedido i)
        {
            //ItemPedidoDAO itemDAO = new ItemPedidoDAO(con.ObjCon);
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                    con.ObjCon.Open();
                itemPedidoDAO.addItemPedido(i);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public CartaoAssinatura getCartao(string nrCartao, bool remoto = false)
        {
            //CartaoAssinaturaDAO cartaoDAO = new CartaoAssinaturaDAO(con.ObjCon);
            try
            {
                CartaoAssinatura cartao = null;
                if (remoto)
                {
                    CartaoAssinaturaDAO cartaoRemotoDAO = new CartaoAssinaturaDAO(conRemoto.ObjCon);
                    conRemoto.ObjCon.Open();
                    cartao = cartaoRemotoDAO.getCartaoPorNumero(nrCartao);
                }
                else
                {
                    if (con.ObjCon.State == ConnectionState.Closed)
                    {
                        con.ObjCon.Open();
                    }
                    cartao = cartaoDAO.getCartaoPorNumero(nrCartao);
                }
                return cartao;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void imprimePedidoEscritura(string nrPedido, string nrFicha, string valor, string pathIniFile)
        {
            try
            {
                IniFile iniFile = new IniFile(pathIniFile);

                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();
                imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));
                imp.PrintText(6, 1, "################### PEDIDO ####################");
                imp.PrintText(7, 1, "No. PEDIDO:......................" + nrPedido.PadLeft(7, '0').PadLeft(14, ' '));
                imp.PrintText(8, 1, "No. FICHA:......................." + nrFicha.PadLeft(7, '0').PadLeft(14, ' '));
                imp.PrintText(9, 1, "Valor PEDIDO:...................." + valor.PadLeft(14, ' '));
                imp.PrintText(10, 1, "#################### ITENS ####################");

                DataTable dados = itemPedidoDAO.getItensPedidoImpressao(nrPedido);
                DataView dvDados = new DataView(dados);
                DataRow drDados;
                int x = 11;

                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;

                    imp.PrintText(x, 1, drDados[0].ToString().PadLeft(3, '0'));

                    imp.PrintText(x, 6, drDados[1].ToString());
                    if (drDados[1].ToString().Length > 33)
                        x++;
                    imp.PrintText(x, 33, String.Format("{0:N2}", drDados[2]).PadLeft(5, ' '));
                    imp.PrintText(x, 40, String.Format("{0:N2}", drDados[3]).PadLeft(8, ' '));
                    x++;

                }

                imp.PrintText(x, 1, iniFile.IniReadValue("FBOLETO", "LINHA1"));

                int qtdLinhas = Convert.ToInt32(iniFile.IniReadValue("FBOLETO", "QTDFIM"));
                x++;
                for (int i = 0; i < qtdLinhas; i++)
                {
                    imp.PrintText(x++, 1, "");
                }
                imp.EndJob();
                imp.PrintJob();
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

        public String getNomeCorrentistaPgto(int nrPedido) {
            String nome = "";
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                String sql = "select c.nmNome from tblPedidosCorrentista p "
                            + "inner join tblCorrentistas c on c.nrCPFCNPJ = p.nrCPFCNPJ "
                            + "where p.nrPedido = " + nrPedido.ToString();
                SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    nome = dr["nmNome"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro: " + ex.Message);
            }
           
            return nome;

        }


        public DataTable getPedidosFilhos(int nrPedido) {
            DataTable dt = new DataTable();
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                String sql = "select nrPedido from tblMovimentoCaixa where nrPedidoPagto = " + nrPedido.ToString();
                SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);

                da.Fill(dt);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro: " + ex.Message);
            }

            return dt;
        }
        
        public void imprimePedido(List<int> nrPedidos, int nrCaixa, string nomeBoleto, string pathIniFile, string nmUsuario, int forpaPagto, double vlPago = 0, string nmCorrentista = "", bool reimpressao = false,double vlDesconto = 0)
        {
            try
            {
                IniFile iniFile = new IniFile(pathIniFile);
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                string pedidos = nrPedidos[0]+",";
                int nrPedido = nrPedidos[0];
                MovimentoCaixa movimento = movimentoDAO.getMovimentoPorPedido(nrPedido);



                //if (nrPedidos.Count > 1) {
                    DataTable tbPedidos = getPedidosFilhos(nrPedido);
                    DataView vPedidos = new DataView(tbPedidos);
                    DataRow pedidoRow;
                    for (int a = 0; a < vPedidos.Count; a++){
                        pedidoRow = vPedidos[a].Row;
                        pedidos += pedidoRow[0].ToString() + ",";
                    }
                //}


                /*
                for (int i = 0; i < nrPedidos.Count; i++)
                {
                    pedidos += nrPedidos[i].ToString() + ",";
                }
                */
                pedidos = pedidos.Substring(0, (pedidos.Length - 1));
                

               

                DataTable dados = itemPedidoDAO.getItensPedidoImpressao(pedidos);

                DataView dvDados = new DataView(dados);
                DataRow drDados;
                double valor = 0;
                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                    {
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                    }
                }


                string strPgto = "";
                switch (movimento.TpPagamento)
                {
                    case 1: strPgto = "Dinheiro"; break;
                    case 2: strPgto = "Correntista"; break;
                    case 3: strPgto = "Cheque"; break;
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();
                imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));
                imp.PrintText(6, 1, "################### RECIBO ####################");
                imp.PrintText(7, 1, "Recebemos os valores abaixo descritos do Sr(a).");
                imp.PrintText(8, 1, movimento.NmRecibo);
                imp.PrintText(9, 1, "");
                int x = 9;
                imp.PrintText(x++, 1, "Forma de Pagamento......: " + strPgto);
                if (movimento.TpPagamento == 2)
                {
                    imp.PrintText(x++, 1, getNomeCorrentistaPgto(nrPedido));
                }

                imp.PrintText(x++, 1, "N. do Pedido............: " + pedidos);
                imp.PrintText(x++, 1, "N. Caixa :..............: " + nrCaixa.ToString());
                imp.PrintText(x++, 1, "Data/Hora...............: " + DateTime.Now);
                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "Referente aos serviços :");
                imp.PrintText(x++, 1, "QTD  ATO                        VALOR  SUBTOTAL");
                imp.PrintText(x++, 1, "---  -------------------------  -----  --------");



                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;

                    imp.PrintText(x, 1, drDados[0].ToString().PadLeft(3, '0'));

                    imp.PrintText(x, 6, drDados[1].ToString());
                    if (drDados[1].ToString().Length > 33)
                        x++;
                    imp.PrintText(x, 33, String.Format("{0:N2}", drDados[2]).PadLeft(5, ' '));
                    imp.PrintText(x, 40, String.Format("{0:N2}", drDados[3]).PadLeft(8, ' '));
                    x++;
                    valor += Convert.ToDouble(drDados[3].ToString());
                }


                //x++;
                if (reimpressao)
                    imp.PrintText(x++, 1, "Reimpresso em......: " + DateTime.Now.ToShortDateString());
                else
                    imp.PrintText(x++, 1, "Impresso em........: " + DateTime.Now.ToShortDateString());
                //x++;
                



                double troco = 0;
                double valorAPagar = valor - movimento.VlDesconto;

                if (vlPago > 0)
                    troco = movimento.VlDinheiro - valorAPagar;

                
                imp.PrintText(x++, 1, "Funcionario(a).....: " + nmUsuario);
                //x++;
                imp.PrintText(x++, 1, "------------------------------------------------");
                //x++;
                imp.PrintText(x++, 1, "A PAGAR ..........: R$ " + String.Format("{0:N2}", valor).PadLeft(11, ' '));
                //x++;
                imp.PrintText(x++, 1, "USO INTERNO.......: R$ " + String.Format("{0:N2}", movimento.VlDesconto).PadLeft(11, ' '));

                imp.PrintText(x++, 1, "VALOR PAGO........: R$ " + String.Format("{0:N2}", valorAPagar).PadLeft(11, ' '));

                imp.PrintText(x++, 1, "TROCO.............: R$ " + String.Format("{0:N2}", troco).PadLeft(11, ' '));
                //x++;
                


                //x++;
                imp.PrintText(x++, 1, iniFile.IniReadValue("FBOLETO", "LINHA1"));
                imp.PrintText(x++, 1, iniFile.IniReadValue("FBOLETO", "LINHA2"));


                int qtdLinhas = Convert.ToInt32(iniFile.IniReadValue("FBOLETO", "QTDFIM"));

                for (int i = 0; i < qtdLinhas; i++)
                {
                    imp.PrintText(x++, 1, "");
                }

                imp.PrintJob();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao imprimir fita.\nFavor tente reimprimir usando a opção CTRL+R.\n"+ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public MovimentoCaixa getMovimentoPorPedido(int nrPedido) {
            MovimentoCaixa movimento = new MovimentoCaixa();
            try
            {
                con.ObjCon.Open();
                movimento = movimentoDAO.getMovimentoPorPedido(nrPedido);

            }
            finally {
                con.ObjCon.Close();
            }
            return movimento;
        }


        public void imprimeCaixa(string pathIniFile, HistoricoCaixa historico)
        {


            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                Usuario usuario = usuarioDAO.getUsuario(historico.DsLogin);
                IniFile iniFile = new IniFile(pathIniFile);
                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();

                int i = 1;

                imp.PrintText(i, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(i++, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));

                imp.PrintText(i++, 1, "############ FECHAMENTO DE CAIXA ##############");
                imp.PrintText(i++, 1, "Funcionario(a)......: " + usuario.DsLogin);
                imp.PrintText(i++, 1, "Caixa (Guiche):.....: " + historico.NrCaixa.ToString().PadLeft(2, '0'));
                imp.PrintText(i++, 1, "Data/Hora (Inicio)..: " + historico.DtAbertura.ToString());
                imp.PrintText(i++, 1, "Data/Hora (Fim).....: " + historico.DtFechamento.ToString());
                imp.PrintText(i++, 1, "");

                #region Lista de Selos Utilizados
                DataTable selosUsados = pedidoDAO.selosUtilizados(historico.DtAbertura.ToShortDateString()
                        , historico.IdHistoricocaixa, 0);

                DataView dadosSelosUsados = new DataView(selosUsados);
                //DataRow linhaSeloUsado;

                int x = 10;
                imp.PrintText(x++, 1, "");

                imp.PrintText(x++, 1, "############ UTILIZACAO DE SELOS ##############");
                imp.PrintText(x++, 1, "QTD TIPO/SERIE              INTERVALO");
                /*
                for (int i = 0; i < dadosSelosUsados.Count; i++)
                {
                    linhaSeloUsado = dadosSelosUsados[i].Row;
                    imp.PrintText(x++, 1,
                            linhaSeloUsado[2].ToString().PadLeft(3, '0') + " "
                            + linhaSeloUsado[1].ToString().PadRight(24, ' ')
                            + linhaSeloUsado[5].ToString().PadLeft(8, '0')
                            + " A " + linhaSeloUsado[6].ToString().PadLeft(8, '0')
                            );
                }
                */
                #endregion




            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao imprimir Caixa.\n" + ex.Message);
            }
            finally {
                if (con.ObjCon.State == ConnectionState.Open)
                {
                    con.ObjCon.Close();
                }
            }
        }

        public void imprimeFechamentoCaixa(string pathIniFile, HistoricoCaixa historico)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }


                Usuario usuario = usuarioDAO.getUsuario(historico.DsLogin);
                IniFile iniFile = new IniFile(pathIniFile);
                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();
                imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));

                imp.PrintText(6, 1, "############ FECHAMENTO DE CAIXA ##############");
                imp.PrintText(7, 1, "Funcionario(a)......: " + usuario.DsLogin);
                imp.PrintText(8, 1, "Caixa (Guiche):.....: " + historico.NrCaixa.ToString().PadLeft(2, '0'));
                imp.PrintText(9, 1, "Data/Hora (Inicio)..: " + historico.DtAbertura.ToString());
                imp.PrintText(10, 1, "Data/Hora (Fim).....: " + historico.DtFechamento.ToString());

                #region Lista de Selos Utilizados
                DataTable selosUsados = pedidoDAO.selosUtilizados(historico.DtAbertura.ToShortDateString()
                        , historico.IdHistoricocaixa, 0);
                
                DataView dadosSelosUsados = new DataView(selosUsados);
                DataRow linhaSeloUsado;

                int x = 10;
                imp.PrintText(x++, 1, "");

                imp.PrintText(x++, 1, "############ UTILIZACAO DE SELOS ##############");
                imp.PrintText(x++, 1, "QTD TIPO/SERIE              INTERVALO");
                for (int i = 0; i < dadosSelosUsados.Count; i++)
                {
                    linhaSeloUsado = dadosSelosUsados[i].Row;
                    imp.PrintText(x++, 1,
                            linhaSeloUsado[2].ToString().PadLeft(3, '0') + " "
                            + linhaSeloUsado[1].ToString().PadRight(24, ' ')
                            + linhaSeloUsado[5].ToString().PadLeft(8, '0')
                            + " A " + linhaSeloUsado[6].ToString().PadLeft(8, '0')
                            );
                }

                #endregion

                #region Lista de Selos Utilizados Correntista
                DataTable selosUsadosCorrentista = pedidoDAO.selosUtilizados(historico.DtAbertura.ToShortDateString()
                            , historico.IdHistoricocaixa, 1);
                /*DataTable dadosSelosCortesia = pedidoDAO.resumoSelosPedidosDia(
                        historico.DtAbertura.ToShortDateString(),
                        historico.DtAbertura.ToShortDateString(),
                        historico.NrCaixa,
                        historico.IdHistoricocaixa,
                        historico.DsLogin, true);
                */
                DataView dadosSelosUsadosCorrentista = new DataView(selosUsadosCorrentista);
                DataRow linhaSeloUsadoCorrentista;

                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "###### UTILIZACAO DE SELOS CORRENTISTA #######");
                imp.PrintText(x++, 1, "QTD TIPO/SERIE            INTERVALO");
                for (int i = 0; i < dadosSelosUsadosCorrentista.Count; i++)
                {
                    linhaSeloUsadoCorrentista = dadosSelosUsadosCorrentista[i].Row;
                    imp.PrintText(x++, 1,
                            linhaSeloUsadoCorrentista[2].ToString().PadLeft(3, '0') + " "
                            + linhaSeloUsadoCorrentista[1].ToString().PadRight(24, ' ')
                            + linhaSeloUsadoCorrentista[5].ToString().PadLeft(8, '0')
                            + " A " + linhaSeloUsadoCorrentista[6].ToString().PadLeft(8, '0')
                            );
                }
                #endregion

                #region Lista de Selos Utilizados Cortezia
                DataTable selosUsadosCortesia = pedidoDAO.selosUtilizados(historico.DtAbertura.ToShortDateString()
                            , historico.IdHistoricocaixa, 2);

                DataView dadosSelosUsadosCortezia = new DataView(selosUsadosCortesia);
                DataRow linhaSeloUsadoCortezia;

                imp.PrintText(x++, 1, "");

                imp.PrintText(x++, 1, "####### UTILIZACAO DE SELOS CORTESIA #########");
                imp.PrintText(x++, 1, "QTD TIPO/SERIE            INTERVALO");
                for (int i = 0; i < dadosSelosUsadosCortezia.Count; i++)
                {
                    linhaSeloUsadoCortezia = dadosSelosUsadosCortezia[i].Row;
                    imp.PrintText(x++, 1,
                            linhaSeloUsadoCortezia[2].ToString().PadLeft(3, '0') + " "
                            + linhaSeloUsadoCortezia[1].ToString().PadRight(24, ' ')
                            + linhaSeloUsadoCortezia[5].ToString().PadLeft(8, '0')
                            + " A " + linhaSeloUsadoCortezia[6].ToString().PadLeft(8, '0')
                            );
                }
                #endregion


                #region Movimento Diario
                DataTable movimentoDiario = pedidoDAO.movimentoDiarioCaixa(historico.DtAbertura.ToShortDateString()
                            ,historico.IdHistoricocaixa, 1);
                DataView dadosMovimentoDiario = new DataView(movimentoDiario);
                DataRow linhaMovimentoDiario;
                string desc = "";
                double valorMovimento = 0;
                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "################# MOVIMENTO ###################");
                imp.PrintText(x++, 1, "QTD ATO                         SELOS VALOR");

                for (int i = 0; i < dadosMovimentoDiario.Count; i++)
                {

                    linhaMovimentoDiario = dadosMovimentoDiario[i].Row;

                    if (linhaMovimentoDiario[1].ToString().Length > 26)
                    {
                        desc = linhaMovimentoDiario[1].ToString().Substring(0, 25);
                    }
                    else
                    {
                        desc = linhaMovimentoDiario[1].ToString().PadRight(26, ' ');
                    }

                    imp.PrintText(x++, 1, linhaMovimentoDiario[2].ToString().PadLeft(3, '0') + " "
                                + desc + " "
                                + String.Format("{0:N2}", linhaMovimentoDiario[3]).PadLeft(15, ' ')
                                );

                    valorMovimento += Convert.ToDouble(linhaMovimentoDiario[3].ToString());
                }

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "Total:..........................: " + String.Format("R$ {0:N2}", valorMovimento).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");
                #endregion


                #region Movimento Diario Correntista
                DataTable movimentoDiarioCorrentista = pedidoDAO.movimentoDiarioCaixa(historico.DtAbertura.ToShortDateString()
                            , historico.IdHistoricocaixa, 2);
                DataView dadosMovimentoDiarioCorrentista = new DataView(movimentoDiarioCorrentista);
                DataRow linhaMovimentoDiarioCorrentista;

                double valorMovimentoCorrent = 0;
                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "########### MOVIMENTO CORRENTISTA #############");
                imp.PrintText(x++, 1, "QTD ATO                         SELOS VALOR");

                for (int i = 0; i < dadosMovimentoDiarioCorrentista.Count; i++)
                {

                    linhaMovimentoDiarioCorrentista = dadosMovimentoDiarioCorrentista[i].Row;

                    if (linhaMovimentoDiarioCorrentista[1].ToString().Length > 26)
                    {
                        desc = linhaMovimentoDiarioCorrentista[1].ToString().Substring(0, 25);
                    }
                    else
                    {
                        desc = linhaMovimentoDiarioCorrentista[1].ToString().PadRight(26, ' ');
                    }

                    imp.PrintText(x++, 1, linhaMovimentoDiarioCorrentista[2].ToString().PadLeft(3, '0') + " "
                                + desc + " "
                                + String.Format("{0:N2}", linhaMovimentoDiarioCorrentista[3]).PadLeft(15, ' ')
                                );

                    valorMovimentoCorrent += Convert.ToDouble(linhaMovimentoDiarioCorrentista[3].ToString());
                }


                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "Total:..........................: " + String.Format("R$ {0:N2}", valorMovimentoCorrent).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");
                #endregion
                // Movimento Correntista

                #region Demonstrativo Pagamento

                imp.PrintText(x++, 1, "########### DEMOSTRATIVO PAGAMENTO ############");
                imp.PrintText(x++, 1, "TIPO PAGAMENTO                     VALOR");

                StringBuilder filtroResumo = new StringBuilder();

                filtroResumo.Append(" and m.tpOperacao = 'C' ");
                filtroResumo.Append("and m.idMovimento in (select min(idMovimento) from tblMovimentoCaixa ");
				filtroResumo.Append(" where idHistoricoCaixa = "+historico.IdHistoricocaixa);
                filtroResumo.Append(" group by nrPedido)  ");

                DataTable dadosMovimento = movimentoDAO.getResumoMovimento(filtroResumo.ToString());
                DataView dvMovimento = new DataView(dadosMovimento);
                DataRow drMovimento;
                double valorEntradas = 0;

                for (int i = 0; i < dvMovimento.Count; i++)
                {
                    drMovimento = dvMovimento[i].Row;
                    imp.PrintText(x++, 1, drMovimento[0].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drMovimento[1]).PadLeft(10, ' '));
                    valorEntradas += Convert.ToDouble(drMovimento[1].ToString());
                }
                // ENTRAR COM VALOR TOTAL DE DESCONTO
                double valorTotalDesconto = movimentoDAO.getValorTotalDesconto(historico.IdHistoricocaixa);
                imp.PrintText(x++, 1, "DESCONTOS/CORTESIA ".PadRight(36, ' ') + " " + String.Format("{0:N2}", valorTotalDesconto).PadLeft(10, ' '));


                valorEntradas += valorTotalDesconto;

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorEntradas).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");
                #endregion


                imp.PrintText(x++, 1, "###### DEMOSTRATIVO RECEBIMENTO CORREN. #######");
                imp.PrintText(x++, 1, "DESCRICAO                          VALOR");

                DataTable recebimentoCorrentistas = movimentoDAO.getRecebimentosCorrentista(historico.IdHistoricocaixa);
                DataView dadosRecebimentoCorrentista = new DataView(recebimentoCorrentistas);
                DataRow linhaRecebimentoCorrentista;
                double valorRecebeCorrentista = 0;

                for (int i = 0; i < dadosRecebimentoCorrentista.Count; i++)
                {
                    linhaRecebimentoCorrentista = dadosRecebimentoCorrentista[i].Row;
                    imp.PrintText(x++, 1, linhaRecebimentoCorrentista[2].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", linhaRecebimentoCorrentista[0]).PadLeft(10, ' '));
                    valorRecebeCorrentista += Convert.ToDouble(linhaRecebimentoCorrentista[0].ToString());
                }

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorRecebeCorrentista).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");

                imp.PrintText(x++, 1, "########### DEMOSTRATIVO CORRENT. #############");
                imp.PrintText(x++, 1, "DESCRICAO                          VALOR");

                DataTable dadosDemosCorren = movimentoDAO.getDemostrativoCorrentista(historico.IdHistoricocaixa);
                DataView dvDemosCorren = new DataView(dadosDemosCorren);
                DataRow drDemosCorren;
                double valorDemosCorrentista = 0;

                for (int i = 0; i < dvDemosCorren.Count; i++)
                {
                    drDemosCorren = dvDemosCorren[i].Row;

                    if (drDemosCorren[2].ToString().Length > 35)
                    {
                        desc = drDemosCorren[2].ToString().Substring(0, 35);
                    }
                    else
                    {
                        desc = drDemosCorren[2].ToString();
                    }
                    imp.PrintText(x++, 1, desc.PadRight(36, ' ') + " " + String.Format("{0:N2}", drDemosCorren[1]).PadLeft(10, ' '));
                    valorDemosCorrentista += Convert.ToDouble(drDemosCorren[1].ToString());
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorDemosCorrentista).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");

                //Entradas

                imp.PrintText(x++, 1, "########### DEMOSTRATIVO ENTRADA ##############");
                imp.PrintText(x++, 1, "DESCRICAO                          VALOR");



                DataTable dadosEntradas = movimentoDAO.getValoresPorTipo(historico.IdHistoricocaixa, 'R', 0);
                DataView dvEntradas = new DataView(dadosEntradas);
                DataRow drEntradas;
                double valorEntr = 0;

                for (int i = 0; i < dvEntradas.Count; i++)
                {
                    drEntradas = dvEntradas[i].Row;
                    imp.PrintText(x++, 1, drEntradas[1].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drEntradas[2]).PadLeft(10, ' '));
                    valorEntr += Convert.ToDouble(drEntradas[2].ToString());
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorEntr).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");

                //entradas


                imp.PrintText(x++, 1, "############ DEMOSTRATIVO SAIDAS ##############");
                imp.PrintText(x++, 1, "DESCRICAO                          VALOR");



                DataTable dadosOutros = movimentoDAO.getOutrosValores(historico.IdHistoricocaixa);
                DataView dvOutros = new DataView(dadosOutros);
                DataRow drOutros;
                double valorOutrosValores = 0;

                for (int i = 0; i < dvOutros.Count; i++)
                {
                    drOutros = dvOutros[i].Row;
                    imp.PrintText(x++, 1, drOutros[1].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drOutros[2]).PadLeft(10, ' '));
                    valorOutrosValores += Convert.ToDouble(drOutros[2].ToString());
                }


                DataTable dadosDescontos = movimentoDAO.getValorDesconto(historico.IdHistoricocaixa);

                DataView dvDescontos = new DataView(dadosDescontos);
                DataRow drDescontos;
                double valorDescontos = 0;
                for (int i = 0; i < dvDescontos.Count; i++)
                {
                    drDescontos = dvDescontos[i].Row;
                    imp.PrintText(x++, 1, drDescontos[1].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drDescontos[2]).PadLeft(10, ' '));
                    valorDescontos += Convert.ToDouble(drDescontos[2].ToString());
                }


                // PAGTO CORRENTISTA
                double valorTotalCorrentista = movimentoDAO.getValorTotalTipoPgto(historico.IdHistoricocaixa, 2);
                imp.PrintText(x++, 1, "CORRENTISTA ".PadRight(36, ' ') + " " + String.Format("{0:N2}", valorTotalCorrentista).PadLeft(10, ' '));

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorDescontos + valorOutrosValores + valorTotalCorrentista).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");

                double valorFechamento = (((valorMovimento + valorRecebeCorrentista + valorEntr) - valorDescontos) - valorOutrosValores);

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "FECHAMENTO DE CAIXA:............: " + String.Format("R$ {0:N2}", valorFechamento).PadLeft(13, ' '));

                int qtdLinhas = Convert.ToInt32(iniFile.IniReadValue("FBOLETO", "QTDFIM"));

                for (int i = 0; i < qtdLinhas; i++)
                {
                    imp.PrintText(x++, 1, "");
                }

                dvDescontos.Dispose();
                dadosDescontos.Dispose();

                dvOutros.Dispose();
                dadosOutros.Dispose();

                dvMovimento.Dispose();
                dadosMovimento.Dispose();

                dadosMovimentoDiario.Dispose();
                movimentoDiario.Dispose();

                dadosSelosUsados.Dispose();
                selosUsados.Dispose();
                imp.EndJob();
                imp.PrintJob();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro:\n " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        #region Fechamento Movimento Diario
        public void imprimeMovimentoCaixas(string pathIniFile, string dtMovimento, string dtFim)
        {
            try
            {

                con.ObjCon.Open();


                string descricao = "";
                IniFile iniFile = new IniFile(pathIniFile);
                bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

                if (arquivo)
                {
                    if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                        File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }

                imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
                imp.StartJob();
                imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
                imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
                imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
                imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
                imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));

                imp.PrintText(6, 1, "############ MOVIMENTO DE CAIXAS ##############");
                imp.PrintText(7, 1, "Periodo: de " + dtMovimento + " a " + dtFim);

                DataTable dadosSelos = pedidoDAO.resumoSelosPedidosDia(dtMovimento, dtFim);
                DataView dvDados = new DataView(dadosSelos);
                DataRow drDados;
                int x = 8;

                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "############ UTILIZACAO DE SELOS ##############");
                imp.PrintText(x++, 1, "QTD TIPO/SERIE            INTERVALO");
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    imp.PrintText(x++, 1,
                            drDados[2].ToString().PadLeft(3, '0') + " "
                            + drDados[1].ToString().PadRight(24, ' ')
                            + drDados[5].ToString().PadLeft(8, '0')
                            + " A " + drDados[6].ToString().PadLeft(8, '0')
                            );
                }


                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "################# MOVIMENTO ###################");

                DataTable dtResumoBalcao = pedidoDAO.getResumoBalcaoPorPeriodo(dtMovimento, dtFim, 'B');
                DataView dvResumoBalcao = new DataView(dtResumoBalcao);
                DataRow drResumoBalcao;
                double vlResumo = 0;
                double vlMovimento = 0;
                imp.PrintText(x++, 1, "# BALCAO");
                imp.PrintText(x++, 1, "QTD    DESCRICAO                       VALOR");
                imp.PrintText(x++, 1, "-----------------------------------------------");
                for (int i = 0; i < dvResumoBalcao.Count; i++)
                {
                    drResumoBalcao = dvResumoBalcao[i].Row;
                    if (drResumoBalcao[2].ToString().Length >= 25)
                    {
                        descricao = drResumoBalcao[2].ToString().Substring(0, 25);
                    }
                    else
                    {
                        descricao = drResumoBalcao[2].ToString();
                    }

                    imp.PrintText(x++, 1,
                        drResumoBalcao[3].ToString().PadLeft(5, '0') + " "
                        + descricao.PadRight(25, ' ')
                        + String.Format("{0:N2}", drResumoBalcao[4]).PadLeft(15, ' ')
                        );

                    vlResumo += Convert.ToDouble(drResumoBalcao[4]);
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "SUBTOTAL:.......................: " + String.Format("{0:N2}", vlResumo).PadLeft(13, ' '));
                vlMovimento += vlResumo;
                vlResumo = 0;
                imp.PrintText(x++, 1, "-----------------------------------------------");
                DataTable dtResumoEscProc = pedidoDAO.getResumoProcuracaoEscrituraPorPeriodo(dtMovimento, dtFim, 'B');
                DataView dvResumoEscProc = new DataView(dtResumoEscProc);
                DataRow drResumoEscProc;

                imp.PrintText(x++, 1, "# ESCRITURA/PROCURACAO");
                imp.PrintText(x++, 1, "QTD    DESCRICAO                       VALOR");
                imp.PrintText(x++, 1, "-----------------------------------------------");
                for (int i = 0; i < dvResumoEscProc.Count; i++)
                {
                    drResumoEscProc = dvResumoEscProc[i].Row;

                    if (drResumoEscProc[2].ToString().Length >= 25)
                    {
                        descricao = drResumoEscProc[2].ToString().Substring(0, 25);
                    }
                    else
                    {
                        descricao = drResumoEscProc[2].ToString();
                    }
                    imp.PrintText(x++, 1,
                        drResumoEscProc[3].ToString().PadLeft(5, '0') + " "
                        + descricao.PadRight(25, ' ')
                        + String.Format("{0:N2}", drResumoEscProc[4]).PadLeft(15, ' ')
                        );

                    vlResumo += Convert.ToDouble(drResumoEscProc[4]);
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "SUBTOTAL:.......................: " + String.Format("{0:N2}", vlResumo).PadLeft(13, ' '));
                vlMovimento += vlResumo;
                vlResumo = 0;
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("{0:N2}", vlMovimento).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");



                imp.PrintText(x++, 1, "################ CORRENTISTA ##################");

                DataTable dtResumoBalcaoCorrent = pedidoDAO.getResumoBalcaoPorPeriodo(dtMovimento, dtFim, 'C');
                DataView dvResumoBalcaoCorrent = new DataView(dtResumoBalcaoCorrent);
                DataRow drResumoBalcaoCorrent;

                double vlMovimentoCorrent = 0;
                imp.PrintText(x++, 1, "# BALCAO");
                imp.PrintText(x++, 1, "QTD    DESCRICAO                       VALOR");
                imp.PrintText(x++, 1, "-----------------------------------------------");
                for (int i = 0; i < dvResumoBalcaoCorrent.Count; i++)
                {
                    drResumoBalcaoCorrent = dvResumoBalcaoCorrent[i].Row;

                    if (drResumoBalcaoCorrent[2].ToString().Length >= 25)
                    {
                        descricao = drResumoBalcaoCorrent[2].ToString().Substring(0, 25);
                    }
                    else
                    {
                        descricao = drResumoBalcaoCorrent[2].ToString();
                    }
                    imp.PrintText(x++, 1,
                        drResumoBalcaoCorrent[3].ToString().PadLeft(5, '0') + " "
                        + descricao.PadRight(25, ' ')
                        + String.Format("{0:N2}", drResumoBalcaoCorrent[4]).PadLeft(15, ' ')
                        );

                    vlResumo += Convert.ToDouble(drResumoBalcaoCorrent[4]);
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "SUBTOTAL:.......................: " + String.Format("{0:N2}", vlResumo).PadLeft(13, ' '));
                vlMovimentoCorrent += vlResumo;
                vlResumo = 0;
                imp.PrintText(x++, 1, "-----------------------------------------------");

                DataTable dtResumoEscProcCorrent = pedidoDAO.getResumoProcuracaoEscrituraPorPeriodo(dtMovimento, dtFim, 'C');
                DataView dvResumoEscProcCorrent = new DataView(dtResumoEscProcCorrent);
                DataRow drResumoEscProcCorrent;

                imp.PrintText(x++, 1, "# ESCRITURA/PROCURACAO");
                imp.PrintText(x++, 1, "QTD    DESCRICAO                       VALOR");
                imp.PrintText(x++, 1, "-----------------------------------------------");
                for (int i = 0; i < dvResumoEscProcCorrent.Count; i++)
                {
                    drResumoEscProcCorrent = dvResumoEscProcCorrent[i].Row;
                    if (drResumoEscProcCorrent[2].ToString().Length >= 25)
                    {
                        descricao = drResumoEscProcCorrent[2].ToString().Substring(0, 25);
                    }
                    else
                    {
                        descricao = drResumoEscProcCorrent[2].ToString();
                    }
                    imp.PrintText(x++, 1,
                        drResumoEscProcCorrent[3].ToString().PadLeft(5, '0') + " "
                        + descricao.PadRight(25, ' ')
                        + String.Format("{0:N2}", drResumoEscProcCorrent[4]).PadLeft(15, ' ')
                        );

                    vlResumo += Convert.ToDouble(drResumoEscProcCorrent[4]);
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "SUBTOTAL:.......................: " + String.Format("{0:N2}", vlResumo).PadLeft(13, ' '));
                vlMovimentoCorrent += vlResumo;
                vlResumo = 0;
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("{0:N2}", vlMovimentoCorrent).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");



                imp.PrintText(x++, 1, "########### DEMOSTRATIVO PAGAMENTO ############");
                imp.PrintText(x++, 1, "TIPO PAGAMENTO                     VALOR");
                string dtIni = dtMovimento.Substring(6, 4) + "-" + dtMovimento.Substring(3, 2) + "-" + dtMovimento.Substring(0, 2);
                string dtFinal = dtFim.Substring(6, 4) + "-" + dtFim.Substring(3, 2) + "-" + dtFim.Substring(0, 2);

                DataTable dadosMovimento = movimentoDAO.getResumoMovimento("and m.dtMovimento between '" + dtIni + " 00:00:00' and '" + dtFinal + " 23:59:59' and m.tpOperacao in('C','R')");
                DataView dvMovimento = new DataView(dadosMovimento);
                DataRow drMovimento;
                double valorEntradas = 0;

                for (int i = 0; i < dvMovimento.Count; i++)
                {
                    drMovimento = dvMovimento[i].Row;
                    imp.PrintText(x++, 1, drMovimento[0].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drMovimento[1]).PadLeft(10, ' '));
                    valorEntradas += Convert.ToDouble(drMovimento[1].ToString());
                }


                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorEntradas).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");

                // outros pagamentos
                imp.PrintText(x++, 1, "############## OUTROS PAGAMENTO ###############");
                DataTable dadosMovimentoOutros = movimentoDAO.getOutrasReceitas(dtIni,dtFinal) ;
                DataView dvMovimentoOutros = new DataView(dadosMovimentoOutros);
                DataRow drMovimentoOutros;
                double valorEntradasOutros = 0;

                for (int i = 0; i < dvMovimentoOutros.Count; i++)
                {
                    drMovimentoOutros = dvMovimentoOutros[i].Row;
                    imp.PrintText(x++, 1, drMovimentoOutros[2].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drMovimentoOutros[3]).PadLeft(10, ' '));
                    valorEntradasOutros += Convert.ToDouble(drMovimentoOutros[3].ToString());
                }


                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorEntradasOutros).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");




                imp.PrintText(x++, 1, "###### DEMOSTRATIVO RECEBIMENTO CORREN. #######");
                imp.PrintText(x++, 1, "CORRENTISTA                          VALOR");

                DataTable dadosRecebeCorren = movimentoDAO.getRecebimentosCorrentistaPeriodo(dtIni, dtFinal);
                DataView dvRecebeCorren = new DataView(dadosRecebeCorren);
                DataRow drRecebeCorren;
                double valorRecebeCorrentista = 0;

                for (int i = 0; i < dvRecebeCorren.Count; i++)
                {
                    drRecebeCorren = dvRecebeCorren[i].Row;
                    imp.PrintText(x++, 1, drRecebeCorren[0].ToString().PadRight(36, ' ') + " " + String.Format("{0:N2}", drRecebeCorren[1]).PadLeft(10, ' '));
                    valorRecebeCorrentista += Convert.ToDouble(drRecebeCorren[1].ToString());
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorRecebeCorrentista).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");




                imp.PrintText(x++, 1, "##################### SELOS ###################");
                imp.PrintText(x++, 1, "QTD   TIPO                    V.UN.       VALOR");

                DataTable dadosQtdSelos = pedidoDAO.getQuantidadeSeloPeriodo(dtIni, dtFinal);
                DataView dvQtdSelos = new DataView(dadosQtdSelos);
                DataRow drQtdSelos;
                double vlSelos = 0;

                for (int i = 0; i < dvQtdSelos.Count; i++)
                {
                    drQtdSelos = dvQtdSelos[i].Row;
                    imp.PrintText(x++, 1, drQtdSelos[1].ToString().PadLeft(5, '0') + " "
                                        + drQtdSelos[2].ToString().PadRight(23, ' ')
                                        + String.Format("{0:N2}", drQtdSelos[3]).PadLeft(6, ' ') + " "
                                        + String.Format("{0:N2}", drQtdSelos[4]).PadLeft(10, ' '));
                    vlSelos += Convert.ToDouble(drQtdSelos[4]);
                }
                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", vlSelos).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");

                imp.PrintText(x++, 1, "############ DEMOSTRATIVO SAIDAS ##############");
                imp.PrintText(x++, 1, "DESCRICAO                          VALOR");


                DataTable dadosOutros = movimentoDAO.getOutrosValoresPeriodo(dtIni, dtFinal);
                DataView dvOutros = new DataView(dadosOutros);
                DataRow drOutros;
                double valorOutrosValores = 0;

                for (int i = 0; i < dvOutros.Count; i++)
                {
                    drOutros = dvOutros[i].Row;

                    imp.PrintText(x++, 1, drOutros[3].ToString().PadLeft(5, '0') + " " + drOutros[1].ToString().PadRight(30, ' ') + " " + String.Format("{0:N2}", drOutros[2]).PadLeft(10, ' '));
                    valorOutrosValores += Convert.ToDouble(drOutros[2].ToString());
                }

                DataTable dadosDescontos = movimentoDAO.getValorDescontoPeriodo(dtIni, dtFinal);

                DataView dvDescontos = new DataView(dadosDescontos);
                DataRow drDescontos;
                double valorDescontos = 0;
                for (int i = 0; i < dvDescontos.Count; i++)
                {
                    drDescontos = dvDescontos[i].Row;
                    imp.PrintText(x++, 1, drDescontos[3].ToString().PadLeft(5, '0') + " " + drDescontos[1].ToString().PadRight(30, ' ') + " " + String.Format("{0:N2}", drDescontos[2]).PadLeft(10, ' '));
                    valorDescontos += Convert.ToDouble(drDescontos[2].ToString());
                }

                // PAGTO CORRENTISTA
                double valorTotalCorrentista = movimentoDAO.getValorTotalTipoPgto(dtIni, 2);

                imp.PrintText(x++, 1, "CORRENTISTA ".PadRight(36, ' ') + " " + String.Format("{0:N2}", valorTotalCorrentista).PadLeft(10, ' '));
                valorOutrosValores += valorTotalCorrentista + valorDescontos;

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "TOTAL:..........................: " + String.Format("R$ {0:N2}", valorOutrosValores).PadLeft(13, ' '));

                valorOutrosValores = valorOutrosValores - (valorTotalCorrentista + valorDescontos);

                double valorTotal = (valorEntradas - valorTotalCorrentista) - (valorOutrosValores);

                imp.PrintText(x++, 1, "-----------------------------------------------");
                imp.PrintText(x++, 1, "");
                imp.PrintText(x++, 1, "TOTAL GERAL:....................: " + String.Format("R$ {0:N2}", valorTotal).PadLeft(13, ' '));
                imp.PrintText(x++, 1, "");



                imp.EndJob();
                imp.PrintJob();

            }
            catch (SqlException dbex)
            {
                throw new Exception("Erro: " + dbex.Message + "\n" + dbex.ErrorCode);
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

        #endregion

        public int repetirPedido(int nrPedido, string dsLogin, int nrRepeticoes)
        {
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }

            SqlTransaction trans = con.ObjCon.BeginTransaction();

            Pedido pedido = new Pedido();
            pedido = pedidoDAO.getNovoPedido(dsLogin, trans);

            double valor = 0;
            DataTable dados = itemPedidoDAO.getItensPedido(nrPedido, trans);
            DataView dvDados = new DataView(dados);
            DataRow drDados;
            Selo selo = null;
            ItemPedido itemPedido = null;

            try
            {
                for (int i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    string nselo = drDados["nrSelo"].ToString();
                    int ato = Convert.ToInt16(drDados["cdAto"].ToString());
                    if (drDados["nrSelo"].ToString() != "")
                    {
                        for (int rep = 0; rep < nrRepeticoes; rep++)
                        {
                            selo = seloDAO.getUltimoSelo(atoDAO.getAtoOperacao(ato, trans).CdTipoDocumento, dsLogin, trans);
                            if (selo != null)
                            {

                                itemPedido = new ItemPedido();
                                itemPedido.CdAto = ato;
                                itemPedido.CdTipoSelo = selo.CdTipoSelo;
                                itemPedido.NrCartao = drDados["nrCartao"].ToString();
                                itemPedido.NrPedido = pedido.NrPedido;
                                itemPedido.NrSelo = selo.NrSelo;
                                itemPedido.TpReconhecimento = Convert.ToChar(drDados["tpReconhecimento"].ToString());
                                itemPedido.VlItem = Convert.ToDouble(drDados["vlItem"].ToString());

                                itemPedidoDAO.addItemPedido(itemPedido, trans);
                                seloDAO.mudarStatusSelo(selo.NrSelo, selo.CdTipoSelo, 'U', trans);
                            }
                            else
                            {
                                trans.Rollback();
                                con.ObjCon.Close();
                                throw new Exception("Não há selo disponível para esta operação!");
                            }
                        }

                    }

                    valor += Convert.ToDouble(drDados["vlItem"].ToString());

                }

                pedidoDAO.atualizaPedido(pedido.NrPedido, 'F', trans);

                trans.Commit();
            }
            catch (SqlException e)
            {
                trans.Rollback();
                con.ObjCon.Close();
                throw new Exception("Erro ao repetir pedido\n" + e.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }


            return pedido.NrPedido;
        }

        public int selosDisponiveis(int tpSelo, string dsLogin = "")
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                int qtd = 0;
                DataTable dados = seloDAO.getSelos("and t.cdTipoDocumento = " + tpSelo.ToString() + "  and s.stSelo = 'D' and s.dsLogin = '" + dsLogin + "'");

                qtd = dados.Rows.Count;


                return qtd;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getMovimentoDiario(int idHistorico)
        {
            DataTable dados = null;
            if (con.ObjCon.State == ConnectionState.Closed)
            {
                con.ObjCon.Open();
            }

            con.ObjCon.Close();
            return dados;
        }

        public void delItemPedido(int idItem)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                itemPedidoDAO.delItemPedido(idItem);
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


        public DataTable getPedidosMulti(string login, int nrPedidoIni, int nrPedidoFim)
        {
            try
            {
                DataTable dados = null;

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                dados = pedidoDAO.getPedidosMulti(login, nrPedidoIni, nrPedidoFim);


                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getIntervaloSelos(string login)
        {
            DataTable intervalo = new DataTable();
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                intervalo = pedidoDAO.getIntervaloSelos(login);
            }
            finally
            {
                con.ObjCon.Close();
            }
            return intervalo;
        }

        public string getSerieSelo(int cdTipoSelo)
        {
            string serie = "";
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                serie = tipoSeloDAO.getTipoSelo(cdTipoSelo).NrSerie;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
            return serie;
        }

        public DataTable getPedidosCancelados(String dtInicio, String dtFim, String login, String nrPedido)
        {
            DataTable intervalo = new DataTable();
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                intervalo = pedidoDAO.getPedidosCancelados(dtInicio,dtFim,login,nrPedido);
            }
            finally
            {
                con.ObjCon.Close();
            }
            return intervalo;
        }

        public DataTable checaExistePedidoAberto(String login) {
            return pedidoDAO.getPedidos(" and stPedido = 'A' and dsLogin = '"+login+"'");
        }

        public DataTable checaExistePedidoFechados(String login)
        {
            return pedidoDAO.getPedidos(" and stPedido in('A','F') and dsLogin = '" + login + "'");
        }
    }
}

