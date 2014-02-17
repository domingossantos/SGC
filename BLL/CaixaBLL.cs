using System;
using System.Collections.Generic;
using System.Data;
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
        private ChequeDAO chequeDAO;
        public CaixaBLL(Conexao objCon)
        {
            this.con = objCon;
            this.caixaDAO = new CaixaDAO(con.ObjCon);
            historicoDAO = new HistoricoCaixaDAO(con.ObjCon);
            movimentoDAO = new MovimentoCaixaDAO(con.ObjCon);
            correntistaDAO = new CorrentistaDAO(con.ObjCon);
            chequeDAO = new ChequeDAO(con.ObjCon);
        }

        public DataTable getCaixas()
        {
            try
            {
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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

                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();

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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
                HistoricoCaixa h = historicoDAO.getHistoricoCaixa(idHistorico);
                
                return h;
            }
            finally {
                con.ObjCon.Close();
            }
        }


        public void salvaMovimento(MovimentoCaixa movimento)
        {
            try
            {
                con.ObjCon.Open();
                movimentoDAO.addMovimentoCaixa(movimento);
            }
            finally
            {
                con.ObjCon.Close();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                con.ObjCon.Open();
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
                

                con.ObjCon.Open();
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
    }


}
