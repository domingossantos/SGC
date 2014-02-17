using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class AtoOperacaoDAO
    {
        private SqlConnection con;

        public AtoOperacaoDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getAtosOperacoes(String filtro = "")
        {
            String sql = "SELECT a.cdAto,a.dsAto,a.vlAto,a.cdTJAto,a.cdUso, ";
            sql += "a.vlPercentual,t.nmTipoDocumento,a.cdPlanoContas,a.tpAto,a.stRegistro,a.stRepeticao ";
            sql += "FROM tblAtosOperacoes a ";
            sql += "inner join tblTipoDocumento t on a.cdTipoDocumento = t.cdTipoDocumento ";
            sql += " where 1 = 1 "+filtro;
            

            sql += " order by a.dsAto ";

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

        public DataTable getAtosOperacoesValores(String filtro = "")
        {
            String sql = "SELECT a.cdAto,LEFT(a.dsAto+REPLICATE(' ',30),30) +' | ' +RIGHT(replicate(' ',5)+  replace(cast(a.vlAto as varchar),',',','),6) as descricao";
            sql += " FROM tblAtosOperacoes a ";
            sql += " inner join tblTipoDocumento t on a.cdTipoDocumento = t.cdTipoDocumento ";
            sql += " where 1 = 1 " + filtro;
            sql += " order by a.nrOrden, a.dsAto ";

            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Number);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
        }

        public AtoOperacao getAtoOperacao(int cdAto, SqlTransaction trans = null) 
        {
            AtoOperacao ato = new AtoOperacao();

            String sql = "SELECT cdAto,dsAto,vlAto,cdTJAto,stRegistro,stRepeticao, ";
            sql += "cdTipoDocumento,cdUso,vlPercentual,cdPlanoContas, tpAto FROM tblAtosOperacoes ";
            sql += "where cdAto = "+cdAto;

            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;

                cmd.Transaction = trans;

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                ato.CdAto = Convert.ToInt32(dr["cdAto"].ToString());
                ato.DsAto = dr["dsAto"].ToString();
                if (dr["vlAto"].ToString().Equals(""))
                    ato.VlAto = 0;
                else
                ato.VlAto = Convert.ToDouble(dr["vlAto"].ToString());


                ato.CdTJAto = dr["cdTJAto"].ToString();
                ato.CdTipoDocumento = Convert.ToInt32(dr["cdTipoDocumento"].ToString());
                ato.CdUso = Convert.ToInt16(dr["cdUso"].ToString());
                ato.VlPercentual = Convert.ToInt16(dr["vlPercentual"].ToString());
                ato.CdPlanoContas = dr["cdPlanoContas"].ToString();
                ato.StRegistro = Convert.ToChar(dr["stRegistro"].ToString());
                ato.TpAto = Convert.ToChar(dr["tpAto"].ToString());
                ato.StRepeticao = Convert.ToChar(dr["stRepeticao"].ToString());

                dr.Close();

                return ato;
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao recuperar dados "+e.Message);
            }

        }

        public AtoOperacao getAtoOperacaoPlano(String cdPlano, SqlTransaction trans = null)
        {
            AtoOperacao ato = new AtoOperacao();

            String sql = "SELECT top 1 cdAto,dsAto,vlAto,cdTJAto,stRegistro,";
            sql += "cdTipoDocumento,cdUso,vlPercentual,cdPlanoContas, tpAto FROM tblAtosOperacoes ";
            sql += "where cdPlanoContas = '" + cdPlano + "'  and cdUso = 99 order by cdPlanoContas";

            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;

                cmd.Transaction = trans;

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                ato.CdAto = Convert.ToInt32(dr["cdAto"].ToString());
                ato.DsAto = dr["dsAto"].ToString();

                if (dr["vlAto"].ToString().Equals(""))
                    ato.VlAto = 0;
                else
                    ato.VlAto = Convert.ToDouble(dr["vlAto"].ToString());

                ato.CdTJAto = dr["cdTJAto"].ToString();
                ato.CdTipoDocumento = Convert.ToInt32(dr["cdTipoDocumento"].ToString());
                ato.CdUso = Convert.ToInt16(dr["cdUso"].ToString());

                if (dr["vlPercentual"].ToString().Equals(""))
                {
                    ato.VlPercentual = 0;
                }
                else
                {
                    ato.VlPercentual = Convert.ToInt16(dr["vlPercentual"].ToString());
                }

                ato.CdPlanoContas = dr["cdPlanoContas"].ToString();
                ato.StRegistro = Convert.ToChar(dr["stRegistro"].ToString());
                ato.TpAto = Convert.ToChar(dr["tpAto"].ToString());

                dr.Close();

                return ato;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recuperar dados " + e.Message);
            }

        }

        public void addAtoOperacao(AtoOperacao ato)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "INSERT INTO tblAtosOperacoes (dsAto,vlAto,cdPlanoContas,";
                sql+= "cdTJAto,cdTipoDocumento,cdUso,vlPercentual,tpAto,stRegistro,stRepeticao)";
                sql+= "VALUES (@dsAto,@vlAto,@cdPlanoContas ,@cdTJAto,";
                sql += "@cdTipoDocumento ,@cdUso,@vlPercentual,@tpAto,'A',@stRepeticao);  select @@IDENTITY;";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dsAto", ato.DsAto);
                cmd.Parameters.AddWithValue("@vlAto", ato.VlAto);
                cmd.Parameters.AddWithValue("@cdTJAto", ato.CdTJAto);
                cmd.Parameters.AddWithValue("@cdTipoDocumento", ato.CdTipoDocumento);
                cmd.Parameters.AddWithValue("@cdUso", ato.CdUso);
                cmd.Parameters.AddWithValue("@vlPercentual", ato.VlPercentual);
                cmd.Parameters.AddWithValue("@cdPlanoContas", ato.CdPlanoContas);
                cmd.Parameters.AddWithValue("@tpAto", ato.TpAto);
                cmd.Parameters.AddWithValue("@stRepeticao", ato.StRepeticao);
                
                ato.CdAto = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void saveAtoOperacao(AtoOperacao ato)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "update tblAtosOperacoes set dsAto=@dsAto,vlAto=@vlAto,";
                sql += "cdTJAto=@cdTJAto,cdTipoDocumento=@cdTipoDocumento,cdPlanoContas=@cdPlanoContas,";
                sql += " cdUso=@cdUso,vlPercentual=@vlPercentual,tpAto = @tpAto,stRegistro=@stRegistro";
                sql += " ,stRepeticao=@stRepeticao where cdAto=@ato";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@ato", ato.CdAto);
                cmd.Parameters.AddWithValue("@dsAto", ato.DsAto);
                cmd.Parameters.AddWithValue("@vlAto", ato.VlAto);
                cmd.Parameters.AddWithValue("@cdTJAto", ato.CdTJAto);
                cmd.Parameters.AddWithValue("@cdTipoDocumento", ato.CdTipoDocumento);
                cmd.Parameters.AddWithValue("@cdUso", ato.CdUso);
                cmd.Parameters.AddWithValue("@vlPercentual", ato.VlPercentual);
                cmd.Parameters.AddWithValue("@cdPlanoContas", ato.CdPlanoContas);
                cmd.Parameters.AddWithValue("@tpAto", ato.TpAto);
                cmd.Parameters.AddWithValue("@stRegistro", ato.StRegistro);
                cmd.Parameters.AddWithValue("@stRepeticao", ato.StRepeticao);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void delAtoOperacao(int cd)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete FROM tblAtosOperacoes where cdAto = " + cd;

                //con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                    throw new Exception("Não foi possivel excluir registro");
            }
            catch (SqlException e)
            {
                throw new Exception("Erro SQL: " + e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

    }
}
