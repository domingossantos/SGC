using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;

namespace DAO
{
    public class MovimentoCaixaDAO
    {
        private SqlConnection con;

        public MovimentoCaixaDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public void addMovimentoCaixa(MovimentoCaixa movimento,SqlTransaction trans = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;
                cmd.Transaction = trans;

                sql = "INSERT INTO tblMovimentoCaixa"
                        +"(idHistoricoCaixa,dsLogin,nrCaixa"
                        + ",idTipoMovimento,tpOperacao,vlMovimento,dtMovimento,nrPedidoPagto"
                        +",tpPagamento,nrPedido,vlDesconto,dsLoginAutDesconto)"
                        +"VALUES(@idHistoricoCaixa,@dsLogin,@nrCaixa,@idTipoMovimento"
                        + ",@tpOperacao,@vlMovimento,@dtMovimento,@nrPedidoPagto, "
                        + "@tpPagamento,@nrPedido,@vlDesconto,@dsLoginAutDesconto); select @@IDENTITY;";


                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@idHistoricoCaixa", movimento.IdHitoricoCaixa);
                cmd.Parameters.AddWithValue("@dsLogin", movimento.DsLogin);
                cmd.Parameters.AddWithValue("@nrCaixa", movimento.NrCaixa);
                cmd.Parameters.AddWithValue("@idTipoMovimento", movimento.IdTipoMovimento);
                cmd.Parameters.AddWithValue("@tpOperacao", movimento.TpOperacao);
                cmd.Parameters.AddWithValue("@vlMovimento", movimento.VlMovimento);
                cmd.Parameters.AddWithValue("@dtMovimento", DateTime.Now);
                cmd.Parameters.AddWithValue("@tpPagamento", movimento.TpPagamento);
                cmd.Parameters.AddWithValue("@nrPedido", movimento.NrPedido);
                cmd.Parameters.AddWithValue("@vlDesconto", movimento.VlDesconto);
                cmd.Parameters.AddWithValue("@dsLoginAutDesconto", movimento.DsLoginAutDesconto);
                cmd.Parameters.AddWithValue("@nrPedidoPagto", movimento.NrPedidoPagto);

                movimento.IdMovimentoCaixa = Convert.ToInt32( cmd.ExecuteScalar().ToString());
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

        // Alteração dara fechamento de caixa
        public DataTable getResumoPagamento(string filtro = "")
        {

            string sql = "select \n"
                        + "    case m.tpPagamento \n"
                        + "       when 0 then 'FUNDO DE CAIXA' \n"
                        + "       when 1 then 'DINHEIRO' \n"
                        + "       when 2 then 'CORRENTISTA' \n"
                        + "       when 3 then 'CHEQUE' \n"
                        + "       when 4 then 'CONTA ESCRITURA' \n"
                        + "       when 5 then 'DEPOSITO BANCO' \n"
                        + "    end nmPagamento, \n"
                        + " sum(m.vlMovimento) as vlPagamento from tblMovimentoCaixa m \n"
                        + " where tpPagamento in (0,1,2,3,4,5) " + filtro + " \n"
                        + " group by m.tpPagamento \n";

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
                throw new Exception("Erro resumo movimento " + ex.Message);
            }
        }


        public DataTable getResumoMovimento(string filtro = "") {

            string sql = "select \n"
                        + "    case m.tpPagamento \n"
                        + "       when 0 then 'FUNDO DE CAIXA' \n"
                        + "        when 1 then 'DINHEIRO' \n"
                        + "        when 2 then 'CORRENTISTA' \n"
                        + "        when 3 then 'CHEQUE' \n"
                        + "        when 4 then 'CONTA ESCRITURA' \n"
                        + "        when 5 then 'DEPOSITO BANCO' \n"
                        + "    end nmPagamento, \n"
                        + " sum(m.vlMovimento) as vlPagamento from tblMovimentoCaixa m \n"
                        + " where tpPagamento in (0,1,2,3,4,5) " + filtro +" \n"
                        + " group by m.tpPagamento \n";

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
                throw new Exception("Erro resumo movimento " + ex.Message);
            }
        }

        public DataTable getOutrosValores(int idHistorico)
        {
            string sql = "SELECT "
                        + " m.idTipoMovimento,"
                        + " (select t.dsAto from tblAtosOperacoes t "
                            + " where t.cdAto = m.idTipoMovimento) as dsTipoMovimento ,"
                        + " SUM(m.vlMovimento) as vlMovimento"
                    + " FROM tblMovimentoCaixa m "
                    + " where m.idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                    + "      where idHistoricoCaixa = " + idHistorico.ToString() + "group by nrPedido) "
                    + " and m.tpOperacao = 'D' and tpPagamento <> 2"
                    + "group by m.idTipoMovimento";

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
                throw new Exception("Erro ao outros valoresss " + ex.Message);
            }
        }

        public DataTable getOutrosValores(string dtMovimento)
        {
            string sql = "SELECT "
                        + " m.idTipoMovimento,"
                        + " (select t.dsAto from tblAtosOperacoes t "
                            + " where t.cdAto = m.idTipoMovimento) as dsTipoMovimento ,"
                        + " SUM(m.vlMovimento) as vlMovimento, count(m.idTipoMovimento) as qtd"
                    + " FROM tblMovimentoCaixa m "
                    + " where m.dtMovimento between '" + dtMovimento + " 00:00:00' and '" + dtMovimento + " 23:59:59'"
                    + " and m.tpOperacao = 'D' and tpPagamento <> 2"
                    + "group by m.idTipoMovimento";

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

        public DataTable getOutrosValoresPeriodo(string dtIni,string dtFim)
        {
            string sql = "SELECT "
                        + " m.idTipoMovimento,"
                        + " (select t.dsAto from tblAtosOperacoes t "
                            + " where t.cdAto = m.idTipoMovimento) as dsTipoMovimento ,"
                        + " SUM(m.vlMovimento) as vlMovimento, count(m.idTipoMovimento) as qtd"
                    + " FROM tblMovimentoCaixa m "
                    + " where m.dtMovimento between '" + dtIni + " 00:00:00' and '" + dtFim + " 23:59:59'"
                    + " and m.tpOperacao = 'D' and tpPagamento <> 2"
                    + "group by m.idTipoMovimento";

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

        public DataTable getValoresPorTipo(int idHistorico,char op, sbyte tipo)
        {
            string sql = "SELECT "
                        + " m.idTipoMovimento,"
                        + " (select t.dsAto from tblAtosOperacoes t "
                            + " where t.cdAto = m.idTipoMovimento) as dsTipoMovimento ,"
                        + " SUM(m.vlMovimento) as vlMovimento"
                    + " FROM tblMovimentoCaixa m "
                    + " where m.idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                    + "      where idHistoricoCaixa = " + idHistorico.ToString() + "group by nrPedido) "
                    + " and m.tpOperacao = '" + op + "' and tpPagamento = " + tipo.ToString()
                    + "group by m.idTipoMovimento";

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
                throw new Exception("Erro ao valor por tipoo " + ex.Message);
            }
        }

        
        public DataTable getValorDesconto(int idHistorico) { 

            try
            {
                string sql = "SELECT m.tpPagamento, "
	                         + "case m.tpPagamento "
		                     + " when 1 then 'USO INTERNO' "
		                     + " when 2 then 'CORRENTSTA' "
	                         + " end nmMovimento, "
	                         + " case m.tpPagamento "
		                     + " when 1 then CAST(SUM(m.vlDesconto) AS MONEY) " 
		                     + " when 2 then CAST(SUM(m.vlMovimento) AS MONEY) "
	                         + " end vlDesconto  "
                             + " FROM tblMovimentoCaixa m "
                             + " where m.tpPagamento in(1) AND  "
                             + " m.idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                             + "      where idHistoricoCaixa = " + idHistorico.ToString() + "group by nrPedido) "
                             + " group by m.tpPagamento";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao valor desconto " + ex.Message);
            }
        }

        public DataTable getValorDesconto(string dtMovimento)
        {

            try
            {
                string sql = "SELECT m.tpPagamento, "
                             + "case m.tpPagamento "
                             + " when 1 then 'USO INTERNO' "
                             + " when 2 then 'CORRENTSTA' "
                             + " end nmMovimento, "
                             + " case m.tpPagamento "
                             + " when 1 then CAST(SUM(m.vlDesconto) AS MONEY) "
                             + " when 2 then CAST(SUM(m.vlMovimento) AS MONEY) "
                             + " end vlDesconto  ,"
                             + " case m.tpPagamento "
                             + " when 1 then count(m.tpPagamento) "
                             + " when 2 then count(m.tpPagamento) "
                             + " end qtDesconto  "
                            + " FROM tblMovimentoCaixa m "
                            + " where m.tpPagamento in(1) AND  m.dtMovimento between '" + dtMovimento + " 00:00:00' and '" 
                            + dtMovimento + " 23:59:59'"
                            + " group by m.tpPagamento";
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

        public DataTable getValorDescontoPeriodo(string dtIni, string dtFim)
        {

            try
            {
                string sql = "SELECT m.tpPagamento, "
                             + "case m.tpPagamento "
                             + " when 1 then 'USO INTERNO' "
                             + " when 2 then 'CORRENTSTA' "
                             + " end nmMovimento, "
                             + " case m.tpPagamento "
                             + " when 1 then CAST(SUM(m.vlDesconto) AS MONEY) "
                             + " when 2 then CAST(SUM(m.vlMovimento) AS MONEY) "
                             + " end vlDesconto  ,"
                             + " case m.tpPagamento "
                             + " when 1 then count(m.tpPagamento) "
                             + " when 2 then count(m.tpPagamento) "
                             + " end qtDesconto  "
                            + " FROM tblMovimentoCaixa m "
                            + " where m.tpPagamento in(1) AND  m.dtMovimento between '" + dtIni + " 00:00:00' and '"
                            + dtFim + " 23:59:59'"
                            + " group by m.tpPagamento";
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

        public double getValorTotalDesconto(int idHistorico)
        {

            try
            {
                
                string sql = "select sum(vlDesconto) soma from tblMovimentoCaixa"
                            + " where idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                            + " where idHistoricoCaixa = "+idHistorico.ToString() +" group by nrPedido)  ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                double total = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    if (!dr["soma"].ToString().Equals(""))
                        total = Convert.ToDouble(dr["soma"]);
                }

                dr.Close();
                return total;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar total desconto " + ex.Message);
            }

        }

        public double getValorTotalDesconto(string dtMovimento,string dtFim ="")
        {
            if (dtFim.Equals("")) {
                dtFim = dtMovimento;
            }

            try
            {
                string sql = "select sum(vlDesconto) soma from tblMovimentoCaixa"
                            + " where dtMovimento between '" + dtMovimento + " 00:00:00' and '" + dtFim + " 23:59:59'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                double total = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    if (!dr["soma"].ToString().Equals(""))
                        total = Convert.ToDouble(dr["soma"]);
                }

                dr.Close();
                return total;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar total desconto " + ex.Message);
            }

        }

        public double getValorTotalTipoPgto(int idHistorico,sbyte tipo)
        {

            try
            {
                string sql = "select sum(vlMovimento) soma from tblMovimentoCaixa"
                            + " where idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                            + "      where idHistoricoCaixa = " + idHistorico.ToString() 
                            + " group by nrPedido)  and tpPagamento = " + tipo.ToString();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                double total = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    if (!dr["soma"].ToString().Equals(""))
                        total = Convert.ToDouble(dr["soma"]);
                }

                dr.Close();
                return total;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar total desconto " + ex.Message);
            }
        }

        public double getValorTotalTipoPgto(string dtMovimento, sbyte tipo)
        {

            try
            {
                string sql = "select sum(vlMovimento) soma from tblMovimentoCaixa"
                            + " where dtMovimento between '" + dtMovimento + " 00:00:00' and '" + dtMovimento + " 23:59:59'" 
                            + " and tpPagamento = " + tipo.ToString();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                double total = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    if (!dr["soma"].ToString().Equals(""))
                        total = Convert.ToDouble(dr["soma"]);
                }

                dr.Close();
                return total;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar total desconto " + ex.Message);
            }
        }


        public DataTable getMovimentoDia(string where)
        {
            try
            {
                /*
                string sql = "select t.cdTipoDocumento,t.nmTipoDocumento,o.dsAto, "
                            +" COUNT(i.idItemPedido) qtd,sum(i.vlItem) valor "
                            +"    from tblItensPedido i "
                            +"    inner join tblPedidos p on i.nrPedido = p.nrPedido "
                            +"    inner join tblAtosOperacoes o on i.cdAto = o.cdAto "
                            +"    inner join tblTipoDocumento t on o.cdTipoDocumento = t.cdTipoDocumento "
                            +"    where  "
	                        +"        i.nrPedido in (select nrPedido "
				            +"                    from tblMovimentoCaixa "
				            +"                    where 1 = 1 "+where+") "
                            +"    group by t.cdTipoDocumento,t.nmTipoDocumento,o.dsAto ";
                */

                string sql = "select d.nmTipoDocumento,a.dsAto,count(i.cdAto) qtd "
                          +" ,sum(m.vlDesconto) vlDesconto,sum(i.vlItem) vlItens "
                          +"from tblPedidos p  "
                          +"inner join tblMovimentoCaixa m on m.nrPedido = p.nrPedido  "
                          +"inner join tblItensPedido i on i.nrPedido = p.nrPedido   "
                          +"inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                          +"inner join tblTipoDocumento d on d.cdTipoDocumento = a.cdTipoDocumento "
                          +"where p.stPedido = 'P' " + where
                          +" group by d.nmTipoDocumento,a.dsAto order by 2";


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


        public DataTable getRecebimentosCorrentista(int idHistorico)
        {
            try
            {
                string sql = "select m.vlMovimento,p.nrCPFCNPJ, c.nmNome from tblMovimentoCaixa m " 
                                +"inner join tblPagamentoCorrentista p on p.idMovimento = m.idMovimento "
                                +"inner join tblCorrentistas c on c.nrCPFCNPJ = p.nrCPFCNPJ "
                                +"where m.idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                                +"      where idHistoricoCaixa = " + idHistorico.ToString() + "group by nrPedido) ";

                
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar recebimento correntista " + ex.Message);
            }
        }

        public DataTable getRecebimentosCorrentistaGeral(string dtMovimento)
        {
            try
            {
                string sql = "select m.vlMovimento,p.nrCPFCNPJ, c.nmNome from tblMovimentoCaixa m "
                                + "inner join tblPagamentoCorrentista p on p.idMovimento = m.idMovimento "
                                + "inner join tblCorrentistas c on c.nrCPFCNPJ = p.nrCPFCNPJ "
                                + "where dtMovimento between '" + dtMovimento + " 00:00:00' and '" + dtMovimento + " 23:59:59'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar recebimento correntista " + ex.Message);
            }
        }

        public DataTable getRecebimentosCorrentistaPeriodo(string dtMovimento, string dtFim)
        {
            try
            {
                string sql = "select c.nmNome , sum(m.vlMovimento) "
                                +" from tblMovimentoCaixa m "
                                +" inner join tblPagamentoCorrentista p on p.idMovimento = m.idMovimento "
                                +" inner join tblCorrentistas c on c.nrCPFCNPJ = p.nrCPFCNPJ "
                                +" where dtMovimento between '" + dtMovimento + " 00:00:00' and '" + dtFim + " 23:59:59'"
                                + " group by c.nmNome ";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar recebimento correntista " + ex.Message);
            }
        }

        public DataTable getDemostrativoCorrentista(int idHistorico)
        {
            try
            {
                string sql = "select m.nrPedido "
	                            +",(select sum(vlItem) from tblItensPedido where nrPedido = m.nrPedido) vlPedido "
	                            +",(select c.nmNome "
		                        +"    from tblPedidosCorrentista pc " 
		                        +"    inner join tblCorrentistas c on c.nrCPFCNPJ = pc.nrCPFCNPJ "
		                        +"    where pc.nrPedido = m.nrPedido) "
                                +"from tblMovimentoCaixa m "
                                + "where tpPagamento = 2 and m.idMovimento in (select min(idMovimento) from tblMovimentoCaixa "
                                + "      where idHistoricoCaixa = " + idHistorico.ToString() + "group by nrPedido) ";
                                 
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar demostrativoss correntista " + ex.Message);
            }
        }

        public DataTable getDemostrativoCorrentistaGeral(string dtMovimento)
        {
            try
            {
                string sql = "select m.nrPedido "
                                + ",(select sum(vlItem) from tblItensPedido where nrPedido = m.nrPedido) vlPedido "
                                + ",(select c.nmNome "
                                + "    from tblPedidosCorrentista pc "
                                + "    inner join tblCorrentistas c on c.nrCPFCNPJ = pc.nrCPFCNPJ "
                                + "    where pc.nrPedido = m.nrPedido) "
                                + "from tblMovimentoCaixa m "
                                + "where tpPagamento = 2 and dtMovimento between '" + dtMovimento + " 00:00:00' and '" + dtMovimento + " 23:59:59'";

                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable dados = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar recebimento correntista " + ex.Message);
            }
        }
    }
}
