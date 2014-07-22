using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;
using DAO;
using MatrixReporter;
using System.IO;

namespace BLL
{
    public class EscrituraBLL
    {
        private Conexao con;
        private EscrituraDAO escrituraDAO;
        private Escritura escritura;
        private ItemOrcamento itemOrcamento;
        private MovimentoDeposito movimentoDeposito;
        private ItemOrcamentoDAO itemOrcamentoDAO;
        private PessoaEscritura pessoaEscritura;
        private PessoaEscrituraDAO pessoaEscrituraDAO;
        private ItemEscrituraDAO itemEscrituraDAO;
        private MovimentoDepositoDAO movimentoDepositoDAO;
        private AtoOperacaoDAO atosDAO;
        private PedidoDAO pedidoDAO;
        private ItemPedidoDAO itemPedidoDAO;
        private Andamento andamento;
        private AndamentoDAO andamentoDAO;
        private Reporter imp;
        private OrcamentoDAO orcamentoDAO;
        private TipoEscrituraDAO tipoEscrituraDAO;
        private PessoaDAO pessoaDAO;

        public EscrituraBLL(Conexao con)
        {
            this.con = con;
            escritura = new Escritura();
            itemOrcamento = new ItemOrcamento();
            pessoaEscritura = new PessoaEscritura();
            movimentoDeposito = new MovimentoDeposito();
            andamento = new Andamento();
            escrituraDAO = new EscrituraDAO(con.ObjCon);
            itemOrcamentoDAO = new ItemOrcamentoDAO(con.ObjCon);
            pessoaEscrituraDAO = new PessoaEscrituraDAO(con.ObjCon);
            itemEscrituraDAO = new ItemEscrituraDAO(con.ObjCon);
            movimentoDepositoDAO = new MovimentoDepositoDAO(con.ObjCon);
            atosDAO = new AtoOperacaoDAO(con.ObjCon);
            pedidoDAO = new PedidoDAO(con.ObjCon);
            itemPedidoDAO = new ItemPedidoDAO(con.ObjCon);
            andamentoDAO = new AndamentoDAO(con.ObjCon);
            orcamentoDAO = new OrcamentoDAO(con.ObjCon);
            tipoEscrituraDAO = new TipoEscrituraDAO(con.ObjCon);
            pessoaDAO = new PessoaDAO(con.ObjCon);
            imp = new Reporter();
        }

        public int novaEscritura() {
            try
            {
                con.ObjCon.Open();
               
                return escrituraDAO.novaEscritura();
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

        public void addEscritura(Escritura esc){
            try
            {
                con.ObjCon.Open();
                escrituraDAO.addEscritura(esc);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public void salvaEscritura(Escritura esc)
        {
            try
            {
                con.ObjCon.Open();
                escrituraDAO.salvaEscritura(esc);
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

        public DataTable getEscriturasRelatorio(int id)
        {
            DataTable dados;
            try
            {
                con.ObjCon.Open();
                dados = escrituraDAO.getEscriturasRelatorio(" and idEscritura = " + id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

            return dados;

        }


        public DataTable getEscriturasPorNum(int id) {
            DataTable dados;
            try
            {
                con.ObjCon.Open();
                dados = escrituraDAO.getEscrituras(" and idEscritura = " + id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }

            return dados;

        }

        public DataTable getEscriturasEntreData(String dtInicio, String dtFim)
        {
            DataTable dados;
            try
            {
                con.ObjCon.Open();
                String where = " and dtEntrada between '" + dtInicio + " 00:00:00' and '" + dtFim + " 20:00:00'";

                dados = escrituraDAO.getEscrituras(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

            return dados;

        }

        public DataTable getEscriturasPorNome(string nome)
        {
            DataTable dados;
            try
            {
                con.ObjCon.Open();
                string where = "and idEscritura in (SELECT idEscritura  FROM tblPessoasEscritura "
                                +" where nrCpfCnpj in( "
                                +" SELECT  nrCpfCnpj "
                                +" FROM tblPessoas "
                                +" WHERE nmPessoa like '%"+nome+"%'))";
                dados = escrituraDAO.getEscrituras(where) ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

            return dados;

        }

        public DataTable getEscriturasPorDatas(string dtIni, string dtFim)
        {
            try
            {
                con.ObjCon.Open();
                DataTable dados = escrituraDAO.getEscrituras(" and dtOrcamento between '" + dtIni + " 00:00:00' and '" + dtFim + " 23:59:59'");
                
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getEscriturasPorEndereco(string nmEndereco)
        {
            try
            {
                con.ObjCon.Open();
                DataTable dados = escrituraDAO.getEscrituras(" and dsEndereco like '%"+nmEndereco+"%'");

                return dados;
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

        public DataTable getEscriturasPorSelo(string nrSelo)
        {
            try
            {
                con.ObjCon.Open();
                DataTable dados = escrituraDAO.getEscrituras(" and nrSelo = " + nrSelo);

                return dados;
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

        public Escritura getEscritura(int id) {
            try
            {
                con.ObjCon.Open();
                Escritura esc = escrituraDAO.getEscritura(id);

                return esc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void addItemOrcamento(ItemOrcamento item) {
            try
            {
                con.ObjCon.Open();
                itemOrcamentoDAO.addItemOrcamento(item);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable listaItensOrcamento(int idOrcamento) {
            try
            {
                con.ObjCon.Open();
                DataTable dados = itemOrcamentoDAO.getItensOrcamento(idOrcamento);
                
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable listaItensOrcamentoRelatorio(int idOrcamento)
        {
            try
            {
                con.ObjCon.Open();
                DataTable dados = itemOrcamentoDAO.getItensOrcamentoRelatorio(idOrcamento);

                return dados;
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

        public void delItemOrcamento(int item, int idOrcamento)
        {
            try
            {
                con.ObjCon.Open();
                itemOrcamentoDAO.delItemOrcamento(item, idOrcamento);
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

        public DataTable listaPessoasEscritura(int id) {
            try
            {
                con.ObjCon.Open();
                DataTable dados = pessoaEscrituraDAO.getPessoasEscritura(id.ToString());

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void delPessoaEscritura(string CpfCnpj, int id) {
            try
            {
                con.ObjCon.Open();
                pessoaEscrituraDAO.delPessoaEscritura(CpfCnpj, id);
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

        public void addPessoaEscritura(PessoaEscritura p) {
            try
            {
                con.ObjCon.Open();
                pessoaEscrituraDAO.salvaPessoaEscritura(p);
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

        public DataTable listaItensEscritura() {
            try
            {
                con.ObjCon.Open();
                DataTable dados = atosDAO.getAtosOperacoes(" and cdUso = 4");
                
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public double vlItemEscritura(int idx, int qtd = 0) {
            try
            {
                con.ObjCon.Open();
                AtoOperacao ato = atosDAO.getAtoOperacao(idx);
                
                double valor = 0;
                if (qtd == 0)
                    valor = ato.VlAto;
                else
                    valor = ato.VlAto * qtd;

                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public double getValorTotalOrcamento(int idx) {
            try
            {
                con.ObjCon.Open();
                double r = itemOrcamentoDAO.getValorTotalOrcamento(idx);
                
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }
        /* Movmento Banco */

        public DataTable listaMovimento(int idEscritura,char status) {
            try
            {
                con.ObjCon.Open();
                string where = " and m.stRegistro = 'P' and m.tpMovimento = '" + status + "' and m.idEscritura = " + idEscritura;
                DataTable dados = movimentoDepositoDAO.getListaMovimento(where);
                con.ObjCon.Close();
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable listaSolicitacao(char status = 'A')
        {
            try
            {
                con.ObjCon.Open();
                string where = "and m.tpMovimento = 'D' and m.stRegistro = '" + status + "'";
                DataTable dados = movimentoDepositoDAO.getListaMovimento(where);
                
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void gravaMovimento(MovimentoDeposito movimento) 
        {
            con.ObjCon.Open();
            
            try
            {
                movimentoDepositoDAO.addMovimento(movimento);
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


        public void gravaPagamento(MovimentoDeposito movimento, ref Pedido p) {
            con.ObjCon.Open();
            SqlTransaction trans = con.ObjCon.BeginTransaction();
            try
            {
                movimentoDepositoDAO.addMovimento(movimento, trans);

                ItemPedido i = new ItemPedido();
                p = pedidoDAO.getNovoPedido(movimento.DsLogin, trans);

                i.CdAto = movimento.CdAto;
                i.IdMovimentoBanco = movimento.IdMovimentoBanco;
                i.NrPedido = p.NrPedido;
                i.VlItem = movimento.VlMovimento;

                itemPedidoDAO.addItemPedido(i, trans);

                pedidoDAO.atualizaPedido(p.NrPedido, 'F', trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void solicitaPagamento(MovimentoDeposito movimento,bool forcar = false)
        {
            con.ObjCon.Open();
            try
            {
                double valorCre = movimentoDepositoDAO.getValorCliente(movimento.IdEscritura, 'C');
                if (forcar)
                {
                    movimentoDepositoDAO.addMovimento(movimento);
                }
                else
                {
                    if (valorCre >= movimento.VlMovimento)
                    {
                        movimentoDepositoDAO.addMovimento(movimento);
                    }
                    else
                    {
                        throw new Exception("Não há saldo para esta escritura!");
                    }
                }
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

        public double getValorCliente(int idx, char tipo) {
            try
            {
                con.ObjCon.Open();
                double valorCre = movimentoDepositoDAO.getValorCliente(idx, tipo);
                
                return valorCre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }


        /* Andamentos */
        public DataTable listaAndamento(int id)
        {
            try
            {
                con.ObjCon.Open();
                DataTable dados = andamentoDAO.getListaAndamentos(" and stRegistro = 'A' and idEscritura = " + id);
                
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public void addAndamento(Andamento andamento) {
            try
            {
                con.ObjCon.Open();
                andamentoDAO.addAndamento(andamento);
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
        public void delAndamento(int idx) {
            try
            {
                con.ObjCon.Open();
                andamentoDAO.delAndamento(idx);
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
        public void alteraStatusMovimento(int idx, char status) {
            try
            {
                con.ObjCon.Open();
                movimentoDepositoDAO.altStatusMovimento(idx, status);
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


        public void imprimePedido(string nrFicha, string nrPedido, string valor, string pathIniFile, string informacao ="")
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
                imp.PrintText(8, 1, "No. FICHA:......................" + nrFicha.PadLeft(7, '0').PadLeft(14, ' '));
                imp.PrintText(9, 1, "Valor PEDIDO:...................." + String.Format("{0:N2}", Convert.ToDouble(valor)).PadLeft(14, ' '));
                imp.PrintText(10, 1, "Informação: "+informacao);
                imp.PrintText(11, 1, "#################### ITENS ####################");

                DataTable dados = itemPedidoDAO.getItensPedidoImpressao(nrPedido);
                DataView dvDados = new DataView(dados);
                DataRow drDados;
                int x = 12;
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
            finally
            {
                con.ObjCon.Close();
            }
        }

        public double getValorAto(int idAto) {
            try
            {
                if (idAto > 0)
                {
                    con.ObjCon.Open();
                    AtoOperacao ato = new AtoOperacao();
                    ato = atosDAO.getAtoOperacao(idAto);

                    return ato.VlAto;
                } else {
                    return 0;
                }
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


        public AtoOperacao getAto(int idAto)
        {

            try
            {
                con.ObjCon.Open();
                AtoOperacao ato = new AtoOperacao();
                ato = atosDAO.getAtoOperacao(idAto);

                return ato;
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

        public void apagaPessoaOrcamento(string nrCpfCnpj, int idOrcamento) {
            try
            {
                con.ObjCon.Open();

                pessoaDAO.delPessoaOrcamento(nrCpfCnpj, idOrcamento);
                
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

        public bool verificaAtoPedido(int idEscritura,int cdAto) {

            bool status = false;

            DataTable dados = listaMovimento(idEscritura, 'D');

            DataView dvDados = new DataView(dados);
            DataRow drDados;
            for (int i = 0; i < dvDados.Count; i++)
            {
                drDados = dvDados[i].Row;

                if (drDados["cdAto"].ToString().Equals(cdAto.ToString())) {
                    status = true;
                }
            }

            return status;
        }


        public void alteraAtoEscritura(Escritura esc, int cdAto) { 
            

        }

        /*
         * 
         * */
        public AtoOperacao verificaPagamentoEscritura(int idEscritura,int cdAto)
        {
            try
            {
                con.ObjCon.Open();
                int i = movimentoDepositoDAO.getAtoEscrituraMovimento(idEscritura, cdAto);
                AtoOperacao ato = null;
                if (i > 0)
                {
                    ato = atosDAO.getAtoOperacao(cdAto);
                }

                return ato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable getEscriturasValores(String dtInicio, String dtFim)
        {
            DataTable dados;
            try
            {
                con.ObjCon.Open();
                String where = " and dtEntrada between '" + dtInicio + " 00:00:00' and '" + dtFim + " 20:00:00'";

                dados = escrituraDAO.getEscriturasValores(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }

            return dados;

        }

        #region Orcamento Escritura
        public int novoOramento() {
            int i = 0;
            try
            {
                con.ObjCon.Open();
                i = orcamentoDAO.newOrcamento();
                return i;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        public DataTable getPessoasOrcamento(int idOrcamento) {
            try
            {
                PessoaDAO pessoaADO = new PessoaDAO(con.ObjCon);
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = pessoaADO.getPessoasOrcamento(idOrcamento);

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        public DataTable buscaOrcamentoDatas(String dtInicio, String dtFim)
        {
            try
            {
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = orcamentoDAO.getOrcamentos(dtInicio,dtFim);

                return dados;
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

        public DataTable getTipoEscritura() {
            try
            {
                DataTable dados = new DataTable();
                con.ObjCon.Open();
                dados = tipoEscrituraDAO.getTipoEscritura();

                return dados;
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

        public Orcamento getOrcamento(int id) {
            try { 
                con.ObjCon.Open();
                Orcamento oOrcamento = new Orcamento();
                oOrcamento = orcamentoDAO.getOrcamento(id);

                return oOrcamento;
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

        public void salvaOrcamento(Orcamento oOrcamento) { 
            try{
                con.ObjCon.Open();
                orcamentoDAO.salvaOrcamento(oOrcamento);
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

        public void importaOrcamentoEscritura(int idOrcamento, int idEscritura, string login) {
            Escritura esc = getEscritura(idEscritura);

            Orcamento orc = getOrcamento(idOrcamento);

            esc.VlDocumento = orc.VlTransacao;
            esc.VlVenal = orc.VlVenal;
            esc.DsContato = orc.DsContato;
            esc.DsEndereco = orc.DsEndereco;
            esc.IdOrcamento= orc.IdOrcamento;
            esc.DsLogin = login;
            

            salvaEscritura(esc);


            DataTable pessoasOrcamento = getPessoasOrcamento(idOrcamento);

            if (pessoasOrcamento.Rows.Count > 0) {
                PessoaEscritura pe = new PessoaEscritura();
                for (int i = 0; i < pessoasOrcamento.Rows.Count; i++)
                {
                    DataRow linha = pessoasOrcamento.Rows[i];
                    
                    pe.NrCpfCnpj = linha["nrCpfCnpj"].ToString();
                    pe.IdEscritura = idEscritura;
                    pe.CdTipoPessoa = Convert.ToInt32( linha["cdTipoPessoa"]);
                    addPessoaEscritura(pe);
                }
            }

           


        }

        #endregion

    }
}
