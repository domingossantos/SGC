using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;
using DAO;

namespace BLL
{
    public class CaixaBLL
    {
        private Conexao con;
        private CaixaDAO caixaDAO;
        private HistoricoCaixaDAO historicoDAO;
        private MovimentoCaixaDAO movimentoDAO;
        private CorrentistaDAO correntistaDAO;
        // Adicionado em 25/04
        private PedidoDAO pedidoDAO;
        private ItemPedidoDAO itemPedidoDAO;
        private AtoOperacaoDAO atoDAO;
        private TipoDocumentoDAO tipoDocDao;
        private SelosDAO seloDAO;
        private CartaoAssinaturaDAO cartaoDAO;
        private UsuarioDAO usuarioDAO;
        private TipoSeloDAO tipoSeloDAO;
        private MovimentoDepositoDAO movimentoDepositoDAO;
        //
        private ChequeDAO chequeDAO;
        public CaixaBLL(Conexao objCon)
        {
            this.con = objCon;
            this.caixaDAO = new CaixaDAO(con.ObjCon);
            historicoDAO = new HistoricoCaixaDAO(con.ObjCon);
            movimentoDAO = new MovimentoCaixaDAO(con.ObjCon);
            correntistaDAO = new CorrentistaDAO(con.ObjCon);
            pedidoDAO = new PedidoDAO(con.ObjCon);
            itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
            atoDAO = new AtoOperacaoDAO(con.ObjCon);
            tipoDocDao = new TipoDocumentoDAO(con.ObjCon);
            seloDAO = new SelosDAO(con.ObjCon);
            cartaoDAO = new CartaoAssinaturaDAO(con.ObjCon);
            usuarioDAO = new UsuarioDAO(con.ObjCon);
            tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
            movimentoDepositoDAO = new MovimentoDepositoDAO(con.ObjCon);
            chequeDAO = new ChequeDAO(con.ObjCon);
        }

        public DataTable getCaixas()
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                DataTable dados = caixaDAO.getCaixas();
                con.ObjCon.Close();
                return dados;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void salvaCaixa(Caixa caixa, sbyte op) {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                if (op == 1)
                    caixaDAO.addCaixa(caixa);

                if (op == 2)
                    caixaDAO.saveCaixa(caixa);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public Caixa getCaixa(int nrCaixa)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                Caixa caixa = caixaDAO.getCaixa(nrCaixa);

                return caixa;
            }
            finally {
                con.ObjCon.Close();
            }

        }

        public bool getCaixaFechado(int nrCaixa)
        {
            try
            {
                bool st = true;

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                if (caixaDAO.getCaixa(nrCaixa).StCaixa != 'F')
                    st = false;
                

                return st;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void abreCaixa(HistoricoCaixa historico)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                historicoDAO.addHistoricoCaixa(historico);
                Caixa caixa = caixaDAO.getCaixa(historico.NrCaixa);
                caixa.StCaixa = 'A';
                caixaDAO.saveCaixa(caixa);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void fechaCaixa(string dsLogin)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                HistoricoCaixa historico = historicoDAO.getUltimoHistoricoCaixaUsuario(dsLogin);
                historico.DtFechamento = DateTime.Now;
                historicoDAO.atualizaHistorico(historico);
                Caixa caixa = caixaDAO.getCaixa(historico.NrCaixa);
                caixa.StCaixa = 'F';
                caixaDAO.saveCaixa(caixa);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void fechaCaixa(HistoricoCaixa historico)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }

                historico.DtFechamento = DateTime.Now;
                historicoDAO.atualizaHistorico(historico);

                Caixa caixa = caixaDAO.getCaixa(historico.NrCaixa);
                caixa.StCaixa = 'F';
                caixaDAO.saveCaixa(caixa);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        /*
         * Teste se o caixa a ser fechado é o do dia
         */
        public bool getCaixaDia(string dsLogin) 
        {
            try
            {
                bool caixa = false;
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                DateTime hoje = DateTime.Now;
                HistoricoCaixa historico = historicoDAO.getUltimoHistoricoCaixaUsuario(dsLogin);
                string stCaixa = historico.DtAbertura.ToShortDateString();
                string stHoje = hoje.ToShortDateString();
                if (stCaixa == stHoje)
                    caixa = true;

                con.ObjCon.Close();
                return caixa;
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public HistoricoCaixa getUltimoHistorioPorCaixa(int caixa)
        {
            
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                HistoricoCaixa h;
                h = historicoDAO.getUltimoHistoricoCaixaUsuario(caixa);
                return h;
            }
            finally
            {
                con.ObjCon.Close();
            }
            
        }

        public HistoricoCaixa getUltimoHistorioPorUsuario(string dsLogin)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                HistoricoCaixa h = historicoDAO.getUltimoHistoricoCaixaUsuario(dsLogin);
                
                return h;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public HistoricoCaixa getHistoricoCaixa(int idHistorico)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                HistoricoCaixa h = historicoDAO.getHistoricoCaixa(idHistorico);
                
                return h;
            }
            finally {
                con.ObjCon.Close();
            }
        }


        public void salvaMovimento(MovimentoCaixa movimento, SqlTransaction trans = null)
        {
            try
            {
                if(con.ObjCon.State == ConnectionState.Closed){
                    con.ObjCon.Open();
                }

                movimentoDAO.addMovimentoCaixa(movimento,trans);
            }
            finally
            {
                //con.ObjCon.Close();
            }
        }

        public DataTable pesquisaCaixa(string inicio="", string fim="",string login = "", int caixa = 0)
        {
            try
            {
                DataTable dadosCaixa = new DataTable();
                DataTable dadosHist = null;
                string filtro = "";

                if (caixa > 0)
                {
                    filtro += " and nrCaixa = " + caixa.ToString();
                }

                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                dadosCaixa = caixaDAO.getCaixas(filtro);
                filtro = "";
                if (dadosCaixa.Rows.Count > 0)
                {
                    DataView dvDados = new DataView(dadosCaixa);
                    //DataRow drDados;
                    if (!inicio.Equals(""))
                    {
                        filtro += " and dtAbertura between '" + inicio + "' and '" + fim + "'";
                    }

                    if (!login.Equals(""))
                    {
                        filtro += " and dsLogin ='" + login + "'";
                    }

                    filtro += "and nrCaixa = " + caixa.ToString() ;
                    
                    /*for (int i = 0; i < dvDados.Count; i++)
                    {
                        drDados = dvDados[i].Row;
                        filtro += "'" + drDados["nrCaixa"].ToString() + "',";
                    }*/

                    //filtro = filtro.Substring(0, (filtro.Length - 1)) + ")";

                    dadosHist = historicoDAO.getHistorioscoCaixas(filtro);
                }

                
                return dadosHist;
            }
            finally {
                con.ObjCon.Close();
            }
        }
        
        public DataTable pesquisaCaixa(string nrCaixa, char stCaixa = 'A')
        {
            try
            {
                DataTable dadosCaixa = new DataTable();
                DataTable dadosHist = null;
                string filtro = "and nrCaixa = " + nrCaixa + " and stCaixa = '" + stCaixa + "'";
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                dadosCaixa = caixaDAO.getCaixas(filtro);

                if (dadosCaixa.Rows.Count > 0)
                {

                    dadosHist = historicoDAO.getHistorioscoCaixas(filtro);

                }
                return dadosHist;
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getCorrentistas()
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                DataTable dados = correntistaDAO.getCorrentistas();
                
                return dados;
            }
            finally
            {
                con.ObjCon.Close();
            }

        }

        public void salvaPedidoCorrentista(PedidoCorrentista p)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                correntistaDAO.addPedidoCorrentista(p);
            }
            finally
            {
                con.ObjCon.Close();
            }
            
        }

        public void salvaCheque(Cheque c)
        {
            try
            {
                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                chequeDAO.addCheque(c);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }


        public HistoricoCaixa recuperaCaixaAtual(int nrCaixa, string dsLogin)
        {
            try
            {
                HistoricoCaixa historico = new HistoricoCaixa();
                if (getCaixaFechado(nrCaixa))
                {


                }
                else
                {
                    historico = getUltimoHistorioPorCaixa(nrCaixa);

                    if (historico.DsLogin.Equals(dsLogin))
                    {
                        //historico = true;
                    }
                }


                return historico;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public DataTable getMovimentoDiaPorUsuarioCaixa(String dtInicio, String dtFim = "", String login = "", String nrCaixa = "")
        {
            try
            {
                string where = "";

                where += " and p.dtPedido between '" + dtInicio + " 00:00:00' and '" + dtInicio + " 23:00:00' ";

                if (!login.Equals("")) {
                    where += " and m.dsLogin = '" + login + "' ";
                }

                if(!nrCaixa.Equals("")){
                    where += " and m.nrCaixa = " + nrCaixa;
                }


                if (con.ObjCon.State == ConnectionState.Closed)
                {
                    con.ObjCon.Open();
                }
                DataTable dados = movimentoDAO.getMovimentoDia(where);

                return dados;
            }
            catch (Exception ex){
                throw new Exception("Erro ao listar movimento\n" + ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public MovimentoCaixa getMovimentoPorPedido(int nrPedido) {
            MovimentoCaixa movimento = new MovimentoCaixa();
            try
            {

            }
            catch (Exception ex) { 
                throw new Exception("Erro ao carregar movimento.\n"+ex.Message);
            }
            finally{
                con.ObjCon.Close();
            }
            return movimento;
        }

        public bool registraPagamentoPedido(double vlPago
                                    , List<int> PedidosList
                                    , HistoricoCaixa historico
                                    , String dsLogin
                                    , int idTipoMovimento
                                    , int nrCaixa
                                    , int tipoPagamento
                                    , double vlDesconto
                                    , string dsLoginDesconto
                                    ,string nomeRecibo)
        { 
            bool stFuncao = false;
            if(con.ObjCon.State == ConnectionState.Closed){
                con.ObjCon.Open();
            }

            SqlTransaction transacao = con.ObjCon.BeginTransaction();
            int nrPedidoPagamentoPai = 0;
            try
            {
                //Ler Lista de Pedidos
                foreach (int nrPedido in PedidosList)
                {
                    if (nrPedido > 0)
                    {

                        Pedido pedido = pedidoDAO.getPedido(nrPedido.ToString(),transacao);

                        DateTime dataPedido = new DateTime(pedido.DtPedido.Year
                                                            , pedido.DtPedido.Month
                                                            , pedido.DtPedido.Day, 0, 0, 0);

                        DateTime dataHistorico = new DateTime(historico.DtAbertura.Year
                                                            , historico.DtAbertura.Month
                                                            , historico.DtAbertura.Day, 0, 0, 0);

                        int diferencaDatas = DateTime.Compare(dataPedido, dataHistorico);
                        
                       if(diferencaDatas != 0){
                           DateTime novaDataPedido = new DateTime(historico.DtAbertura.Year
                                                           , historico.DtAbertura.Month
                                                           , historico.DtAbertura.Day
                                                           , pedido.DtPedido.Hour
                                                           , pedido.DtPedido.Minute
                                                           , pedido.DtPedido.Second);
                           pedidoDAO.atualizaPedido(nrPedido, novaDataPedido, transacao);
                        }
                        
                        DataTable dados = itemPedidoDAO.getItensPedido(nrPedido,transacao);


                        DataView dvDados = new DataView(dados);
                        DataRow drDados;
                        int nrSelo = 0;
                        int cdTipo = 0;

                        for (int i = 0; i < dvDados.Count; i++)
                        {
                            drDados = dvDados[i].Row;
                            string nselo = drDados["nrSelo"].ToString();

                            if (drDados["nrSelo"].ToString() != "")
                            {
                                nrSelo = Convert.ToInt32(nselo);
                                cdTipo = Convert.ToInt32(drDados["cdTipoSelo"].ToString());
                                seloDAO.mudarStatusSelo(nrSelo, cdTipo, 'U', transacao);
                            }

                            //valor += Convert.ToDouble(drDados["vlItem"].ToString());

                        }
                        pedidoDAO.atualizaPedido(nrPedido, 'P', transacao);

                        MovimentoCaixa movimento = new MovimentoCaixa();

                        movimento.IdHitoricoCaixa = historico.IdHistoricocaixa;
                        movimento.DtMovimento = DateTime.Now;
                        movimento.DsLogin = dsLogin;
                        movimento.IdTipoMovimento = idTipoMovimento;
                        movimento.NrCaixa = nrCaixa;
                        movimento.NrPedido = nrPedido;
                        movimento.TpOperacao = 'C';
                        movimento.TpPagamento = tipoPagamento;

                        if (nrPedidoPagamentoPai == 0)
                        {
                            movimento.VlMovimento = vlPago;
                            movimento.NrPedidoPagto = 0;
                            movimento.VlDesconto = vlDesconto;
                            movimento.VlDinheiro = vlPago;
                        }
                        else 
                        {
                            movimento.VlMovimento = 0.0;
                            movimento.NrPedidoPagto = nrPedidoPagamentoPai;
                            movimento.VlDesconto = 0;
                            movimento.VlDinheiro = 0;
                            
                        }

                        movimento.NmRecibo = nomeRecibo;
                        movimento.DsLoginAutDesconto = dsLoginDesconto;
                        movimento.NrPedidoPagto = nrPedidoPagamentoPai;
                        
                        salvaMovimento(movimento, transacao);

                        // Verifica se pedido é de escritura
                            DataTable dadosItens = new DataTable();
                            dadosItens = itemPedidoDAO.getItensPedido(nrPedido,transacao);

                            DataView dvDadosItens = new DataView(dadosItens);
                            DataRow drDadosItem;
                            for (int m = 0; m < dvDadosItens.Count; m++)
                            {
                                drDadosItem = dvDadosItens[m].Row;
                                if (!drDadosItem["idMovimentoBanco"].ToString().Equals(""))
                                {
                                    movimentoDepositoDAO.altStatusMovimento(Convert.ToInt32(drDadosItem["idMovimentoBanco"].ToString()), 'P',transacao);
                                }
                            }

                        if (nrPedidoPagamentoPai == 0)
                        {
                            nrPedidoPagamentoPai = nrPedido;
                        }
                    }


                }
                transacao.Commit();
                stFuncao = true;
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw new Exception("Erro ao efetuar pagamento.\nErro : " + ex.Message);
                
            }
            finally 
            {
                con.ObjCon.Close();
            }

            return stFuncao;
        }
    }


}
