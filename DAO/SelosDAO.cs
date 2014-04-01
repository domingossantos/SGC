using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class SelosDAO
    {
        private SqlConnection con;
        public String sql;

        public SelosDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getSelos(String filtro = "")
        {

            String sql = "Select s.nrSelo,s.dtLancamento,s.stSelo,t.dsTipoSelo,";
            sql += "s.dtAtribuicao,s.dsLogin from tblSelos s ";
            sql += "inner join tblTipoSelo t on s.cdTipoSelo = t.cdTipoSelo ";
            if (!filtro.Equals(""))
                sql += filtro;

            sql += " order by s.nrSelo,t.dsTipoSelo";

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

        public Selo getSelo(int nrSelo, int tipo)
        {
            Selo selo = new Selo();
            String sql = "Select nrSelo,cdTipoSelo,dtLancamento"
                    + ",stSelo from tblSelos where nrSelo = " + nrSelo + " and cdTipoSelo = " + tipo;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    selo.NrSelo = Convert.ToInt32(dr["nrSelo"].ToString());
                    selo.CdTipoSelo = Convert.ToInt32(dr["nrSelo"].ToString());
                    selo.DtLancamento = Convert.ToDateTime(dr["dtLancamento"].ToString());
                    selo.StSelo = Convert.ToChar(dr["stSelo"].ToString());
                }
                return selo;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }

        }



        public Selo getSeloUsuario(string login, int tipo)
        {
            Selo selo = null;
            String sql = "Select top 1 nrSelo,cdTipoSelo,dtLancamento"
                    + ",stSelo from tblSelos where dsLogin = @login and cdTipoSelo = @tipo and stSelo = 'D'";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@login",login);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    selo = new Selo();
                    selo.NrSelo = Convert.ToInt32(dr["nrSelo"].ToString());
                    selo.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());
                    selo.DtLancamento = Convert.ToDateTime(dr["dtLancamento"].ToString());
                    selo.StSelo = Convert.ToChar(dr["stSelo"].ToString());
                    selo.DsLogin = login;
                }
                return selo;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }

        }

        public Selo getSeloTipo(int tipo)
        {
            Selo selo = null;
            //String sql = "Select top 1 nrSelo,cdTipoSelo,dtLancamento"
            //        + ",stSelo from tblSelos where cdTipoSelo = @tipo and stSelo = 'D'";

            String sql = "Select top 1 nrSelo,cdTipoSelo,dtLancamento,stSelo " +
                         "from tblSelos " +
                         "where stSelo = 'D' " +
                         " and cdTipoSelo in ( " +
                            "Select min(t.cdTipoSelo) " +
                            "from tblTipoSelo t " +
                            "inner join tblSelos s on s.cdTipoSelo = t.cdTipoSelo and s.stSelo = 'D' " +
                            "where t.cdTipoDocumento = @tipo " +
                            "group by t.cdTipoSelo,t.nrSerie,t.dsTipoSelo,t.vlSelo,t.cdTipoDocumento) ";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    selo = new Selo();
                    selo.NrSelo = Convert.ToInt32(dr["nrSelo"].ToString());
                    selo.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());
                    selo.DtLancamento = Convert.ToDateTime(dr["dtLancamento"].ToString());
                    selo.StSelo = Convert.ToChar(dr["stSelo"].ToString());
                }
                return selo;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }

        }

        public void addSelos(int inicio, int fim, int tipo)
        {
            try
            {
                String sql = "EXEC	spRegistraSelos @selosInicial = " + inicio + ","
                        + "@selosFinal = " + fim + ","
                        + "@tipoSelo = " + tipo;

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao Registrar Selos "+ex.Message);
                //throw new Exception("Erro SQl: " + ex.Message);
            }
        }

        public void salvaSelo(Selo selo,SqlTransaction tran = null) {
            try
            {
                String sql = "insert into tblSelos (nrSelo,cdTipoSelo,dtLancamento "
                            + ",stSelo,dsLogin,dtAtribuicao) values "
                            + "(@nrSelo,@cdTipoSelo,@dtLancamento "
                            + ",@stSelo,@dsLogin,@dtAtribuicao) ";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrSelo", selo.NrSelo);
                cmd.Parameters.AddWithValue("@cdTIpoSelo", selo.CdTipoSelo);
                cmd.Parameters.AddWithValue("@dtLancamento", selo.DtLancamento);
                cmd.Parameters.AddWithValue("@stSelo", selo.StSelo);
                cmd.Parameters.AddWithValue("@dsLogin", selo.DsLogin);
                cmd.Parameters.AddWithValue("@dtAtribuicao", selo.DtAtribuicao);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao Registrar Selo\n" + ex.Message);
            }
        }

        public void mudarStatusSelo(int nrSelo, int tipo, char status,SqlTransaction trans = null) 
        {
            try
            {
                String sql = "update tblSelos set stSelo = '"+status+"' where nrSelo= "+nrSelo+" and cdTipoSelo = "+tipo;

                SqlCommand cmd = new SqlCommand(sql, con, trans);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }
        }



        public void atribuirSeloUsuario(int inicio, int fim, int tipo, String login)
        {
            String sql = "update tblSelos set dsLogin = @login, dtAtribuicao = getdate() where nrSelo between @inicio and @fim and cdTipoSelo = @tipo";

            SqlCommand cmd = new SqlCommand(sql,con);
            
            try
            {

                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@inicio", inicio);
                cmd.Parameters.AddWithValue("@fim", fim);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }
        }

        public void transferirSelos(int inicio, int fim, int tipo, int origem)
        {
            String sql;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlTransaction tran = con.BeginTransaction();
            cmd.Transaction = tran;
            
            while (inicio <= fim)
            {
                sql = "insert into tblTransferenciaSelos (dtTransferencia,nrSelo,cdTipoSelo, cdLocalCartorio)";
                sql += " values (getdate(),"+ inicio.ToString()+","+tipo.ToString()+","+origem.ToString()+");";

                sql +=  "update tblSelos set stSelo = 'T' where nrSelo = " + inicio.ToString() + " and ";
                sql += " cdTipoSelo = " + tipo.ToString()+";";

                try
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    throw new Exception("Erro SQl: " + sql + " - "+ ex.Message);
                }

                inicio++;
            }

            tran.Commit();
           
        }

        public Selo getUltimoSelo(int tipo,string login, SqlTransaction trans = null)
        {
            Selo selo = null;
            /*
            String sql = "Select nrSelo,cdTipoSelo,dtLancamento,stSelo from tblSelos "
                    + "where nrSelo = (select MIN(nrSelo) from  tblSelos "
                    + "where  stSelo = 'D' and cdTipoSelo in (select cdTipoSelo from tblTipoSelo  "
                    + "where  cdTipoDocumento = " + tipo + ") AND dsLogin = '" + login + "' ) "
                    + "and cdTipoSelo in (select max(cdTipoSelo) from  "
                    + "tblSelos where stSelo = 'D' "
                    + "and cdTipoSelo in (select cdTipoSelo from tblTipoSelo  where  cdTipoDocumento = " + tipo + ") "
                    + "AND dsLogin = '" + login + "')  AND dsLogin = '" + login + "'";
            */
            String sql = "";
            sql = sql + " select  \n ";
            sql = sql + " 	min(s.nrSelo) \n ";
            sql = sql + " 	 nrSelo \n ";
            sql = sql + " 	,min(s.cdTIpoSelo) as cdTipoSelo \n ";
            sql = sql + " 	,min(dtLancamento) as dtLancamento \n ";
            sql = sql + " 	,min(stSelo) as stSelo \n ";
            sql = sql + " from tblSelos s  \n ";
            sql = sql + " where  \n ";
            sql = sql + " 	s.stSelo  = 'D' \n ";
            sql = sql + " 	and s.dsLogin = '"+login+"' \n ";
            sql = sql + " 	and s.cdTipoSelo = ( \n ";
            sql = sql + " 						select min(s1.cdTipoSelo) \n ";
            sql = sql + " 						from tblSelos s1 \n ";
            sql = sql + " 						inner join tblTipoSelo t on t.cdTipoSelo = s1.cdTIpoSelo \n ";
            sql = sql + " 						where s1.cdTipoSelo in(select cdTipoSelo from tblTipoSelo  where  cdTipoDocumento = "+tipo+") \n ";
            sql = sql + " 							and s1.stSelo  = 'D' \n ";
            sql = sql + " 							and s1.dsLogin = '"+login+"') \n ";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                cmd.Transaction = trans;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    selo = new Selo();
                    selo.NrSelo = Convert.ToInt32(dr["nrSelo"].ToString());
                    selo.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());
                    selo.DtLancamento = Convert.ToDateTime(dr["dtLancamento"].ToString());
                    selo.StSelo = Convert.ToChar(dr["stSelo"].ToString());
                    
                }
                dr.Close();
                return selo;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }

        }


        public DataTable getHistoricoSelos(String filtro = "")
        {

            String sql = "select p.nrPedido, i.idItemPedido, p.dtPedido, i.nrProcesso, i.nrSelo,ts.dsTipoSelo, "
                            + " a.dsAto, p.stPedido,p.dsLogin "
                            + " from tblItensPedido i "
                            + " inner join tblPedidos p on i.nrPedido = p.nrPedido "
                            + " inner join tblSelos s on i.nrSelo = s.nrSelo and i.cdTipoSelo = s.cdTipoSelo "
                            + " inner join tblTipoSelo ts on i.cdTipoSelo = ts.cdTipoSelo "
                            + " inner join tblAtosOperacoes a on i.cdAto = a.cdAto"
                            + filtro +" order by p.nrPedido, i.idItemPedido,s.nrSelo";

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

        public void apagaSelos(int inicio, int fim , int tipo) {
            String sql = "delete from tblSelos where nrSelo between @inicio and @fim and cdTipoSelo = @tipo";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                
                cmd.Parameters.AddWithValue("@inicio", inicio);
                cmd.Parameters.AddWithValue("@fim", fim);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }
        }

        public DataTable getSelosPestacao(String dtIni, String dtFim)
        {

            #region Comando Antigo
            String sql = "";
            
            sql = sql + "   select nrSelo  \n ";
            sql = sql + "   	,nrSerie  \n ";
            sql = sql + "   	,cdTJAto  \n ";
            sql = sql + "   	,case cdTJAto  \n ";
            // auteração novo codig tj
            //sql = sql + "               when '61' then 3  \n ";
            //sql = sql + "               when '62' then 3.9  \n ";
            //sql = sql + "               when '63' then 3  \n ";
            sql = sql + "               when '104' then 4.1  \n ";
            sql = sql + "               when '106' then 4.4  \n ";
            
            sql = sql + "           end  as vlAto,   \n ";
            sql = sql + "           case cdTJAto  \n ";

            // auteração novo codig tj
            //sql = sql + "               when '61' then 0.3  \n ";
            //sql = sql + "               when '62' then 0.39  \n ";
            //sql = sql + "               when '63' then 0.3  \n ";
            sql = sql + "               when '104' then 0.41  \n ";
            sql = sql + "               when '106' then 0.44  \n ";

            sql = sql + "           end as vl10Porc,  \n ";
            sql = sql + "           case cdTJAto  \n ";

            // auteração novo codigo tj
            //sql = sql + "               when '61' then 0.08  \n ";
            //sql = sql + "               when '62' then 0.1  \n ";
            //sql = sql + "               when '63' then 0.08  \n ";
            sql = sql + "               when '104' then 0.10  \n ";
            sql = sql + "               when '106' then 0.11  \n ";

            sql = sql + "           end as vl025Porc  \n ";
            sql = sql + "       ,case cdTJAto  \n ";

            // auteração novo codigo tj
            //sql = sql + "           when '61' then 4  \n ";
            //sql = sql + "           when '62' then 4  \n ";
            //sql = sql + "           when '63' then 5  \n ";
            sql = sql + "           when '104' then 4  \n ";
            sql = sql + "           when '106' then 5  \n ";

            sql = sql + "       end as tpSelo  \n ";
            sql = sql + "       ,datepart(year,getdate()) as ANO  \n ";
            sql = sql + "       ,max(dtAtribuicao) as dtInclusao  \n ";
            sql = sql + "       ,max(dtMovimento) as dtPedido   \n ";
            sql = sql + "   	 from ( \n ";
            sql = sql + " 			select  \n ";
            sql = sql + " 				i.nrSelo  \n ";
            sql = sql + " 				,t.nrSerie  \n ";
            sql = sql + "   				,s.dtAtribuicao  \n ";
            sql = sql + "   				,p.dtPedido  \n ";
            sql = sql + "   				,a.cdTJAto  \n ";
            sql = sql + "   				,p.stPedido  \n ";
            sql = sql + "   				,p.dsLogin  \n ";
            sql = sql + "   				,m.dtMovimento \n ";
            sql = sql + " 			from tblItensPedido i  \n ";
            sql = sql + " 			inner join tblSelos s on s.nrSelo = i.nrSelo and s.cdTipoSelo = i.cdTipoSelo  \n ";
            sql = sql + " 			inner join tblTipoSelo t on t.cdTipoSelo = i.cdTipoSelo  \n ";
            sql = sql + " 			inner join tblPedidos p on p.nrPedido = i.nrPedido  \n ";
            sql = sql + " 			inner join tblAtosOperacoes a on a.cdAto = i.cdAto  \n ";
            sql = sql + " 			inner join tblMovimentoCaixa m on m.nrPedido = i.nrPedido \n ";
            sql = sql + " 			where 1 = 1 \n ";
            //sql = sql + " 			and p.stPedido = 'P'  \n ";
            // auteração novo docigo tj
            //sql = sql + " 			and a.cdTjAto in('61','62','63')  \n ";
            sql = sql + " 			and a.cdTjAto in('104','106')  \n ";
            sql = sql + " 			and i.nrSelo is not null \n ";
            sql = sql + " 			and m.dtMovimento between '"+dtIni+" 00:00:00' and '"+dtFim+" 20:00:00' \n ";
            sql = sql + " 			and m.nrPedido > 0 \n ";
            sql = sql + " 	) tab  \n ";
            sql = sql + "   group by nrSelo, nrSerie, cdTJAto  \n ";
            sql = sql + "   having count(*) < 2	order by dtPedido  \n ";
            #endregion


            try
            {
                DateTime dataInicio = Convert.ToDateTime(dtIni+" 00:00:00");
                DateTime dataFim = Convert.ToDateTime(dtFim+" 20:00:00");
                SqlCommand cmd = new SqlCommand("spPesquisaSelosPrestacao", con);
                
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                
                cmd.Parameters.Add(new SqlParameter("@dtInicio",dataInicio));
                cmd.Parameters.Add(new SqlParameter("@dtFim",dataFim));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;
                da.SelectCommand = cmd;
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

        public DataTable historicoMovimentoSelos(String dtInicio, String dtFim, String login, String nrSeloInicio, String nrSeloFim,String tipo)
        {
            String locComandoSql = "";
            locComandoSql = locComandoSql + " select  \n ";
            locComandoSql = locComandoSql + " 	p.nrPedido \n ";
            locComandoSql = locComandoSql + " 	,CONVERT(VARCHAR(10), p.dtPedido, 103) +' '+CONVERT(VARCHAR(12), p.dtPedido, 114) as dtPedido \n ";
            locComandoSql = locComandoSql + " 	,p.dsLogin as UsuarioPedido \n ";
            locComandoSql = locComandoSql + " 	,p.stPedido \n ";
            locComandoSql = locComandoSql + " 	,s.stSelo \n ";
            locComandoSql = locComandoSql + " 	,i.nrSelo \n ";
            locComandoSql = locComandoSql + " 	,t.dsTipoSelo  \n ";
            locComandoSql = locComandoSql + " 	,i.vlItem \n ";
            locComandoSql = locComandoSql + " 	,c.dsLogin as usuariocaixa \n ";
            locComandoSql = locComandoSql + " 	,CONVERT(VARCHAR(10), c.dtMovimento, 103) +' '+CONVERT(VARCHAR(12), c.dtMovimento, 114) as dtPuxadoCaixa \n ";
            locComandoSql = locComandoSql + " from tblPedidos p \n ";
            locComandoSql = locComandoSql + " inner join tblItensPedido i on i.nrPedido = p.nrPedido \n ";
            locComandoSql = locComandoSql + " inner join tblSelos s on s.nrSelo = i.nrSelo and s.cdTipoSelo = i.cdTipoSelo \n ";
            locComandoSql = locComandoSql + " inner join tblTipoSelo t on t.cdTipoSelo = i.cdTipoSelo \n ";
            locComandoSql = locComandoSql + " left outer join tblMovimentoCaixa c on c.nrPedido = p.nrPedido \n ";
            locComandoSql = locComandoSql + " where  \n ";
            locComandoSql = locComandoSql + " p.dtPedido between '"+dtInicio+" 00:00:00' and '"+dtFim+" 20:00:00' \n ";
            if(!login.Equals("")){
                locComandoSql = locComandoSql + " and p.dsLogin ='"+login+"' \n ";
            }

            if (!nrSeloInicio.Equals("")) {
                locComandoSql = locComandoSql + " and i.nrSelo between " + nrSeloInicio + " and " + nrSeloFim + "  \n ";    
            }

            if (!tipo.Equals("")) {
                locComandoSql = locComandoSql + " and i.cdTipoSelo = " + tipo + " \n ";
            }
            

            locComandoSql = locComandoSql + " order by p.nrPedido, i.cdTipoSelo, i.nrSelo, p.dtPedido \n ";

            this.sql = locComandoSql;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(locComandoSql, con);

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