using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Modelos;

namespace DAO
{
    public class PedidoDAO
    {
        private SqlConnection con;

        public PedidoDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getPedidos(String filtro = "")
        {
            String sql = "SELECT nrPedido,dtPedido,dsLogin,stPedido FROM tblPedidos where 1 = 1";
            sql += filtro;
            sql += " order by nrPedido";

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

        public DataTable getPedidosItens(String filtro = "")
        {
            String sql = "SELECT p.nrPedido,p.dtPedido,i.nrSelo,i.vlItem,p.dsLogin,p.stPedido "
                        +"FROM tblItensPedido i "
                        +" inner join tblPedidos p on i.nrPedido = p.nrPedido where 1 = 1";
            sql += filtro;
            sql += " order by p.nrPedido desc";

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

        public ItemPedido getItemPedidoProcesso(String numProcesso)
        {
            String sql = "select idItemPedido, nrPedido,nrCartao,nrSelo,vlItem, "
                        +"cdAto,cdTipoSelo from tblItensPedido where nrProcesso =  '" + numProcesso+"'";

            ItemPedido i = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    i = new ItemPedido();
                    dr.Read();

                    i.NrPedido = Convert.ToInt32(dr["nrPedido"].ToString());
                    i.NrCartao = dr["nrCartao"].ToString();
                    
                    i.IdItemPedido = Convert.ToInt32( dr["idItemPedido"].ToString());
                    i.NrProcesso = numProcesso;
                    if (!dr["nrSelo"].ToString().Equals(""))
                        i.NrSelo = Convert.ToInt32( dr["nrSelo"].ToString());

                    if (!dr["cdTipoSelo"].ToString().Equals(""))
                        i.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());

                    i.CdAto = Convert.ToInt32(dr["cdAto"].ToString());
                   

                    if (!dr["vlItem"].ToString().Equals(""))
                        i.VlItem = Convert.ToDouble(dr["vlItem"].ToString());

                    dr.Close();
                }
                dr.Close();
                return i;
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


        public Pedido getPedido(String numPedido,SqlTransaction trans = null)
        {
            String sql = "select p.nrPedido,p.dtPedido,p.dsLogin,p.stPedido,"
                    +"(select SUM(i.vlItem) from tblItensPedido i "
	                +"where i.nrPedido = p.nrPedido) vlPedido "
                    +"from tblPedidos p "
                    + "where p.nrPedido = " + numPedido;
            
            Pedido p = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con, trans);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    p = new Pedido();
                    dr.Read();
                    p.NrPedido = Convert.ToInt32(dr["nrPedido"].ToString());
                    p.DsLogin = dr["dsLogin"].ToString();
                    p.DtPedido = Convert.ToDateTime(dr["dtPedido"].ToString());
                    p.StPedido = Convert.ToChar(dr["stPedido"].ToString());
                    
                    if (!dr["vlPedido"].ToString().Equals(""))
                        p.VlPedido = Convert.ToDouble(dr["vlPedido"].ToString());   
                    
                    dr.Close();
                }
                dr.Close();
                return p;
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

        public bool verificaPedido(String nrProcesso)
        {
            String sql = "select count(*) as qtd from tblPedidos "
                        + "where nrPedido = (select max(nrPedido)  from tblItensPedido "
                        + "where nrProcesso = @nrProcesso) and stPedido in ('A','P')" ;
            bool retorno;
            try
            {
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@nrProcesso",nrProcesso);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                if (Convert.ToInt32(dr["qtd"].ToString()) > 0)
                    retorno = true;
                else
                    retorno = false;

                dr.Close();

                return retorno;
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

        public Pedido getPedidoProcesso(String nrProcesso)
        {
            String sql = "select nrPedido from tblPedidos "
                        + "where nrPedido = (select max(nrPedido)  from tblItensPedido "
                        + "where nrProcesso = @nrProcesso) and stPedido = 'P'";
            Pedido pedido = null;

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrProcesso", nrProcesso);
                SqlDataReader dr = cmd.ExecuteReader();
                
                

                if (dr.HasRows) {
                    dr.Read();
                    pedido = getPedido(dr["nrPedido"].ToString());
                }
                    

                dr.Close();

                return pedido;

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

        public Pedido getNovoPedido(String login,SqlTransaction tran = null)
        {
            Pedido p = new Pedido();

            try
            {
                SqlCommand cmd = new SqlCommand("spAbrePedido", con, tran);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar));
                param.Direction = ParameterDirection.Input;
                param.Value = login;
                SqlDataReader dr = null;

                dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                
                if (dr.HasRows)
                {
                    dr.Read();
                    p.NrPedido = Convert.ToInt32(dr["nrPedido"].ToString());
                    p.DsLogin = login;
                    p.DtPedido = Convert.ToDateTime(dr["dtPedido"].ToString());
                }
                dr.Close();
                return p;
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao abrir pedido: \n"+e.Message);
            }
        }

        public void registraCancelamento(String login, int pedido, Double valor) {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO tblCancelamentoPedido (dsLogin,nrPedido,vlPedido) ");
            sql.Append(" VALUES(@login, @pedido, @valor)");

            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(), con);

                cmd.Parameters.AddWithValue("@login", @login);
                cmd.Parameters.AddWithValue("@pedido", @pedido);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao registar log " + e.Message);
            }

        }

        
        public void atualizaPedido(int nrPedido, char st,SqlTransaction trans = null)
        {
            String sql = "update tblPedidos set stPedido = @status where nrPedido = @nrPedido";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con, trans);

                cmd.Parameters.AddWithValue("@status", st);
                cmd.Parameters.AddWithValue("@nrPedido", nrPedido);

                cmd.ExecuteScalar();
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao alterar status "+e.Message);
            }

        }

        public void atualizaPedido(int nrPedido, DateTime data, SqlTransaction trans = null)
        {
            String sql = "update tblPedidos set dtPedido = @data where nrPedido = @nrPedido";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con, trans);

                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@nrPedido", nrPedido);

                cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao alterar status " + e.Message);
            }

        }


        public DataTable resumoSelosPedidosDia(string data,  string dataF = "",int caixa=0, int idHistorico=0,string login="",bool stDesconto = false)
        {
            data = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);
            dataF = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);


            /*
            String sql = "select i.cdTipoSelo, \n"
                                + "(select dsTipoSelo from tblTipoSelo where cdTipoSelo = i.cdtipoSelo) as descricao, \n"
                                + "count(i.idItemPedido) as qtd, \n"
                                + "min(i.nrSelo) as primerio, \n"
                                + "MAX(i.nrSelo) as ultimo \n"
                            + "from tblItensPedido i \n"
                            + "inner join tblPedidos p on i.nrPedido = p.nrPedido \n"
                            + "inner join tblSelos s on i.nrSelo = s.nrSelo and i.cdTipoSelo = s.cdTipoSelo \n"
                            + "inner join tblMovimentoCaixa m on p.nrPedido= m.nrPedido \n"
                            + "where p.dtPedido between '" + data + " 00:00:00' and '" + data + " 23:59:59' \n"
                            + "and p.stPedido = 'P' \n"
                           // + "and p.dsLogin = '" + login + "' "
                            + "and s.stSelo = 'U' \n";
                            if(caixa > 0)
                            {
                                sql +="and m.nrCaixa = " + caixa.ToString() +" \n";
                            }

                            if (idHistorico > 0)
                            {
                                sql +=" and m.idHistoricoCaixa = " + idHistorico.ToString()+" \n";
                            }
                            if (stDesconto) {
                                sql += " and m.vlDesconto > 0 \n";
                            }
                            sql +=" group by i.cdTipoSelo";  
            
                */

            StringBuilder sql = new StringBuilder();
            sql.Append("select i.cdTipoSelo, t.dsTipoSelo, count(i.cdAto) qtd \n");
            sql.Append(", sum(m.vlDesconto) vlDesconto, sum(i.vlItem) vlItens \n ");
            sql.Append(" ,min(i.nrSelo), max(i.nrSelo) \n");
            sql.Append("from tblPedidos p \n ");
            sql.Append("inner join tblMovimentoCaixa m on m.nrPedido = p.nrPedido \n ");
            sql.Append("inner join tblItensPedido i on i.nrPedido = p.nrPedido \n  ");
            sql.Append("inner join tblTipoSelo t on t.cdTipoSelo = i.cdTipoSelo \n ");
            sql.Append("where p.dtPedido between  '" + data + " 00:00:00' and '" + data + " 23:59:59' \n ");
            sql.Append("and p.stPedido = 'P' \n  ");
            
            if (caixa > 0)
            {
                sql.Append("and m.nrCaixa = " + caixa.ToString() + " \n");
            }
            if (idHistorico > 0)
            {
                sql.Append("and m.idHistoricoCaixa = " + idHistorico + " \n ");
            }
            if (stDesconto)
            {
                sql.Append(" and m.vlDesconto > 0 \n");
            }
            
            sql.Append("and i.nrSelo is not null \n  ");
            sql.Append("group by i.cdTipoSelo,t.dsTipoSelo order by 2 ");

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql.ToString(), con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL Resumo pedido dia:\n" + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro Resumo pedido dia:\n " + e.Message);
            }
        }

        public DataTable resumoAtosPedidosDia(string data, string login="", int caixa=0,int historico=0)
        {

            data = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);


            String sql = "select i.cdAto, "
                    + " (select top 1 dsAto from tblAtosOperacoes where cdAto = i.cdAto) as descricao, "
                    + " count(i.idItemPedido) as qtd, SUM(i.vlItem) as valor, "
                    + " (select top 1 cdTjAto from tblAtosOperacoes where cdAto = i.cdAto) as cdAtoTj, "
                    + " (select nmTipoDocumento from tblTipoDocumento where cdTipoDocumento = "
                    + "     (select top 1 cdTipoDocumento from tblAtosOperacoes where cdAto = i.cdAto) "
                    + " ) as documento, count(i.cdAto) qtd "
                    + " from tblItensPedido i inner join tblPedidos p on p.nrPedido = i.nrPedido "
                    + " inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                            + "where i.nrPedido in (select nrPedido from tblMovimentoCaixa "
                    + " where dtMovimento between '" + data + " 00:00:00' and '" + data + " 23:59:59' and tpPagamento <> 2";

                    
                    if(!login.Equals("")){
                        sql +=" and dsLogin = '" + login + "'";
                    }
                    
                    if(historico > 0)
                    {
                        sql +=" and idHistoricoCaixa = "+ historico;
                    }
                    if (caixa > 0)
                    {
                        sql +=" and nrCaixa = " + caixa;
                    }   
                    sql+=")  group by i.cdAto order by 2";
                    //and p.stPedido = 'P'
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL resumo atos dia:\n" + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro resumo atos dia:\n" + e.Message);
            }
        }

        public DataTable resumoAtosPedidosCorrentistaDia(string data, string login = "", int caixa = 0, int historico = 0)
        {
            // 012345678
            // 10/10/2011
            data = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);


            String sql = "select i.cdAto, "
                    + " (select top 1 dsAto from tblAtosOperacoes where cdAto = i.cdAto) as descricao, "
                    + " count(i.idItemPedido) as qtd, SUM(i.vlItem) as valor, "
                    + " (select top 1 cdTjAto from tblAtosOperacoes where cdAto = i.cdAto) as cdAtoTj, "
                    + " (select nmTipoDocumento from tblTipoDocumento where cdTipoDocumento = "
                    + "     (select top 1 cdTipoDocumento from tblAtosOperacoes where cdAto = i.cdAto) "
                    + " ) as documento, count(i.cdAto) qtd "
                    + " from tblItensPedido i inner join tblPedidos p on p.nrPedido = i.nrPedido "
                    + " inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                            + "where i.nrPedido in (select nrPedido from tblMovimentoCaixa "
                    + " where dtMovimento between '" + data + " 00:00:00' and '" + data + " 23:59:59' and tpPagamento = 2";


            if (!login.Equals(""))
            {
                sql += " and dsLogin = '" + login + "'";
            }

            if (historico > 0)
            {
                sql += " and idHistoricoCaixa = " + historico;
            }
            if (caixa > 0)
            {
                sql += " and nrCaixa = " + caixa;
            }
            sql += ") and p.stPedido = 'P' group by i.cdAto order by 2";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL resumo atos correntista:\n" + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro resumo atos correntista:\n " + e.Message);
            }
        }

        public DataTable getPedidosMulti(string login, int nrPedidoIni, int nrPedidoFim)
        {

            String sql = "SELECT nrPedido FROM tblPedidos where stPedido = 'F' "
                    + "and dsLogin = '"+login+"'  and nrPedido between "+nrPedidoIni+" and "+nrPedidoFim;

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

        public DataTable getIntervaloSelos(string login) {
            string sql = "select t.dsTipoSelo, min(s.nrSelo) inicio, max(s.nrSelo) fim, COUNT(s.nrSelo)  qtd "
                        +" from tblSelos s inner join tblTipoSelo t on t.cdTipoSelo = s.cdTipoSelo "
                        +" where s.dsLogin = '"+login+"' and s.stSelo = 'D' group by t.dsTipoSelo";

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


        #region metodos fechamento caixa geral
        public DataTable getResumoBalcaoPorPeriodo(string ini, string fim, char tipo)
        {
            ini = ini.Substring(6, 4) + "-" + ini.Substring(3, 2) + "-" + ini.Substring(0, 2);
            fim = fim.Substring(6, 4) + "-" + fim.Substring(3, 2) + "-" + fim.Substring(0, 2);

            string where = "";

            if (tipo.Equals('C'))
            {
                where = " and tpPagamento = 2 ";
            }
            else
            {
                where = " and tpPagamento <> 2 ";
            }

            string sql = "select  td.nmTipoDocumento, i.cdAto, "
                           +"  (select top 1 dsAto from tblAtosOperacoes where cdAto = i.cdAto) as descricao, "
                           +"  count(i.idItemPedido) as qtd, SUM(i.vlItem) as valor"
                           +" from tblItensPedido i "
                           +" inner join tblPedidos p on p.nrPedido = i.nrPedido "
                           +" inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                           //+" inner join tblUsuario u on u.dsLogin = p.dsLogin "
                           +" inner join tblTipoDocumento td on  td.cdTipoDocumento = a.cdTipoDocumento"
                           +" where i.nrPedido in (select nrPedido from tblMovimentoCaixa "
                           +"                      where dtMovimento between '"+ini+" 00:00:00' "
						   +"                           and '"+fim+" 23:59:59'  "+where+")"
                           +" and p.stPedido = 'P' "
                           +" and td.cdTipoDocumento in(1,7,8)"
                           + " group by td.nmTipoDocumento, i.cdAto order by 2";

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
        
        
        public DataTable getResumoProcuracaoEscrituraPorPeriodo(string ini, string fim,char tipo)
        {
            ini = ini.Substring(6, 4) + "-" + ini.Substring(3, 2) + "-" + ini.Substring(0, 2);
            fim = fim.Substring(6, 4) + "-" + fim.Substring(3, 2) + "-" + fim.Substring(0, 2);

            string where = "";

            if (tipo.Equals('C')) {
                where = " and tpPagamento = 2  ";
            }else {
                where = " and tpPagamento <> 2 ";
            }

            string sql = "select  td.nmTipoDocumento, i.cdAto, "
                           + "  (select top 1 dsAto from tblAtosOperacoes where cdAto = i.cdAto) as descricao, "
                           + "  count(i.idItemPedido) as qtd, SUM(i.vlItem) as valor"
                           + " from tblItensPedido i "
                           + " inner join tblPedidos p on p.nrPedido = i.nrPedido "
                           + " inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                           //+ " inner join tblUsuario u on u.dsLogin = p.dsLogin "
                           + " inner join tblTipoDocumento td on  td.cdTipoDocumento = a.cdTipoDocumento"
                           + " where i.nrPedido in (select nrPedido from tblMovimentoCaixa "
                           + "                      where dtMovimento between '" + ini + " 00:00:00' "
                           + "                           and '" + fim + " 23:59:59' " + where + ")"
                           + " and p.stPedido = 'P' "
                           + " and td.cdTipoDocumento not in(1,7,8)"
                           + " group by td.nmTipoDocumento, i.cdAto order by 2";

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
        

        
        public DataTable getResumoAtosPorSetor(string data) {
            data = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);
            string sql = "select u.cdSetor, i.cdAto," 
	                    +" (select nmSetor from tblSetor where cdSetor = u.cdSetor) as setor, "
	                    +" (select top 1 dsAto from tblAtosOperacoes where cdAto = i.cdAto) as descricao, "
	                    +" count(i.idItemPedido) as qtd, SUM(i.vlItem) as valor, "
                        +" (select top 1 cdTjAto from tblAtosOperacoes where cdAto = i.cdAto) as cdAtoTj, "
                        +" (select nmTipoDocumento from tblTipoDocumento where cdTipoDocumento = "
                        +"(select top 1 cdTipoDocumento from tblAtosOperacoes where cdAto = i.cdAto) "
                        +" ) as documento from tblItensPedido i "
                     +"inner join tblPedidos p on p.nrPedido = i.nrPedido "
                     +"inner join tblAtosOperacoes a on a.cdAto = i.cdAto "
                     +"inner join tblUsuario u on u.dsLogin = p.dsLogin "
                     +"where i.nrPedido in (select nrPedido from tblMovimentoCaixa "
					 +"	                    where dtMovimento between '"+data+" 00:00:00' and '"+data+" 23:59:59' and tpPagamento <> 2)"
                     + "and p.stPedido = 'P' group by u.cdSetor, i.cdAto order by 1,2";

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


        public DataTable getQuantidadeSeloPeriodo(string data,string fim) {
            string sql = "select i.cdTipoSelo,COUNT(*) qtd, "
	                +" (select dsTipoSelo from tblTipoSelo where cdTipoSelo = i.cdTipoSelo) dsTipoSelo, "
	                +" (select vlSelo from tblTipoSelo where cdTipoSelo = i.cdTipoSelo) vlSelo, "
	                +" (select vlSelo from tblTipoSelo where cdTipoSelo = i.cdTipoSelo) * COUNT(*) vlTotal "
                 +" from tblItensPedido i "
                 +" inner join tblPedidos p on p.nrPedido = i.nrPedido "
                 +" where i.nrPedido in (select nrPedido from tblMovimentoCaixa "
				 +" where dtMovimento between '"+data+" 00:00:00' and '"+fim+" 23:59:59' and tpPagamento <> 2) "
                 +" and p.stPedido = 'P' and i.nrSelo is not null "
                 + " group by i.cdTipoSelo order by 2";

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



        #endregion


        #region Fechamento de caixa (JAN 2014)
        /*
         * selosUtilizados: Retorna o intervalo de selos
         *                  utilizados em um dia por uma operadora
         *                  discriminando seu tipo e serie
         * Paramentos: 
         *  Data: data do movimenti
         *  IdHistoricoMovimento: codigo do movimento de caixa
         *  Tipo Consulta: 0 Normal, 1 Correntista, 2 Cortezia
         *  
         */
        public DataTable selosUtilizados(String data, int idHistoricoCaixa, int tipoConsulta) {

            StringBuilder sql = new StringBuilder();
            data = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);

            sql.Append("select i.cdTipoSelo, t.dsTipoSelo, count(i.cdAto) qtd \n");
            sql.Append(", sum(m.vlDesconto) vlDesconto, sum(i.vlItem) vlItens \n ");
            sql.Append(" ,min(i.nrSelo), max(i.nrSelo) \n");
            sql.Append("from tblPedidos p \n ");
            sql.Append("inner join tblMovimentoCaixa m on m.nrPedido = p.nrPedido \n ");
            sql.Append("inner join tblItensPedido i on i.nrPedido = p.nrPedido \n  ");
            sql.Append("inner join tblTipoSelo t on t.cdTipoSelo = i.cdTipoSelo \n ");
            sql.Append("where p.dtPedido between  '"+data+" 00:00:00' and '"+data+" 23:59:59' \n ");
            sql.Append("and p.stPedido = 'P' \n  ");
            sql.Append("and m.idHistoricoCaixa = "+idHistoricoCaixa+" \n ");

            if (tipoConsulta == 1)
            {
                sql.Append("and m.tpPagamento = 2 \n");
            }

            if (tipoConsulta == 2)
            {
                sql.Append("and m.vlDesconto > 0 \n");
            }

            sql.Append("and i.nrSelo is not null \n  ");
            sql.Append("group by i.cdTipoSelo,t.dsTipoSelo order by 2 ");

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql.ToString(), con);
                
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

        /*
         * movimentoDiarioCaixa: Retorno o movimento diario de
         *                       um caixa resumindo por ato
         *                       
         * Paramentos: 
         *  Data: data do movimenti
         *  IdHistoricoMovimento: codigo do movimento de caixa
         *  Tipo Pagamento: 1 Dinheiro, 2 Correntista
         */
        public DataTable movimentoDiarioCaixa(String data, int idHistoricoCaixa, int tipoPagamento)
        {

            StringBuilder sql = new StringBuilder();
            data = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);

            sql.Append("select i.cdAto,a.dsAto, count(i.cdAto) qtd , sum(i.vlItem) vlItens \n");
            sql.Append("from tblPedidos p \n");
            sql.Append("inner join tblMovimentoCaixa m on m.nrPedido = p.nrPedido \n");
            sql.Append("inner join tblItensPedido i on i.nrPedido = p.nrPedido \n");
            sql.Append("inner join tblAtosOperacoes a on a.cdAto = i.cdAto \n");
            sql.Append("where p.dtPedido between '" + data + " 00:00:00' and '" + data + " 23:59:59'  \n");
            sql.Append("and p.stPedido = 'P' \n");
            sql.Append("and m.idHistoricoCaixa = "+idHistoricoCaixa+"  \n");
            
            if (tipoPagamento == 1)
            {
                sql.Append("and m.tpPagamento <> 2 \n");
            }
            else {
                sql.Append("and m.tpPagamento = 2 \n");
            }

            sql.Append("group by i.cdAto,a.dsAto order by 2 \n ");

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql.ToString(), con);

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
        #endregion

        #region Historico Cancelamento
        public DataTable getPedidosCancelados(String dtInicio, String dtFim, String login, String nrPedido)
        {
            String sql = "select dtCancelamento as Data,dsLogin as Usuario";
	               sql += ", nrPedido as Pedido, vlPedido as Valor ";
                   sql += "from tblCancelamentoPedido where 1 = 1";
                   if (!dtInicio.Equals("")) {
                       sql += " and dtCancelamento between '" + dtInicio + " 00:00:00' and '" + dtFim + " 20:00:00'";
                   }

                   if (!login.Equals("")) {
                       sql += " and dsLogin = '" + login + "'";
                   }

                   if (!nrPedido.Equals("")) {
                       sql += "and nrPedido = " + nrPedido;
                   }

                   sql += " order by dtCancelamento";

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
        #endregion
    }
}
