using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class AssinaturaDAO
    {
        private SqlConnection con;

        public AssinaturaDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public byte[] getAssinatura(String nrCartao, DateTime data)
        {
            //String sql = "select top 5 biAssinatura from tblAssinaturas ";
            String sql = "select top 5 biAssinatura from vwAssinaturas ";
                   sql += " where nrCartao = '"+nrCartao.PadLeft(7,'0')+"'";
                   sql += "and DateAdd (ms,-DatePart (ms, [dtAssinatura] ), [dtAssinatura] ) ";
                   sql += " =  CONVERT(datetime,'" + formatoData(data.ToString()) + "',20) ";
                   
            
            try
            {
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    return (byte[])dr["biAssinatura"];
                }
                else
                {
                    return null;
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao ler assinatura "+ex.Message);
            }
        }

        public byte[] getRG(String nrCartao, string campo)
        {
            String sql = "select " + campo + " from  tblCartaoAssinatura ";
            sql += " where nrCartao = '" + nrCartao.PadLeft(7, '0') + "' ";


            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    if (!dr[campo].ToString().Equals(""))
                    {
                        return (byte[])dr[campo];
                    }
                    else {
                        return null;    
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao ler assinatura " + ex.Message);
            }
        }

        public byte[] getUltimaAssinatura(String nrCartao)
        {
            String sql = "select biAssinatura from  vwAssinaturas ";
            sql += " where nrCartao = '"+nrCartao+"' and dtAssinatura = ";
            sql += " (select MAX(dtAssinatura) from  vwAssinaturas ";
            sql += " where nrCartao = '" + nrCartao + "') ";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    return (byte[])dr["biAssinatura"];
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao ler assinatura " + ex.Message);
            }
        }

        public int getExisteAssinatura(String nrCartao,DateTime dtAssinatura)
        {
            String sql = "select count(*) as qtd from  tblAssinaturas ";
            sql += " where nrCartao = @nrCartao and dtAssinatura = @dtAssinatura ";
            

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nrCartao",nrCartao);
                cmd.Parameters.AddWithValue("@dtAssinatura", dtAssinatura);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    return (int)dr["qtd"];
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao ler assinatura " + ex.Message);
            }
        }

        public DateTime getDataUltimaAssinatura(String nrCartao)
        {
            String sql = "select MAX(dtAssinatura) data from  vwAssinaturas "
                        + " where nrCartao = '" + nrCartao + "' ";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DateTime data = new DateTime();
                if (dr.HasRows)
                {
                    dr.Read();
                    data = (DateTime)dr["data"];
                }
                dr.Close();
                return data;
                
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao ler assinatura " + ex.Message);
            }
        }

        public DateTime getDataUltimaAssinaturaAtualiza()
        {
            String sql = "select MAX(dtAssinatura) data from  tblAssinaturas ";
                        

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DateTime data = new DateTime();
                if (dr.HasRows)
                {
                    dr.Read();
                    data = (DateTime)dr["data"];
                }
                dr.Close();
                return data;

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao ler assinatura " + ex.Message);
            }
        }


        public DataTable getAssinaturas(string nrCartao)
        {
            try
            {
                //String sql = "select top 5 dtAssinatura from  tblAssinaturas where nrCartao = '" + nrCartao.PadLeft(7, '0') + "' order by dtAssinatura desc";
                String sql = "select dtAssinatura  from  vwAssinaturas ";
                sql += " where nrCartao = '" + nrCartao+"' "; /*+"' and dtAssinatura = ";
                sql += " (select MAX(dtAssinatura) from  vwAssinaturas ";
                sql += " where nrCartao = '" + nrCartao + "')"; */
                
                
                DataTable dados = new DataTable();

                //SqlCommand cmd = new SqlCommand(sql,con);

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar assinaturas 11 " + ex.Message);
            }
        }

        public DataTable getCartoes(string nrCartaoIni, string nrCartoesFim)
        {
            try
            {
                String sql = "select  distinct nrCartao from tblCartaoAssinatura where nrCartao between '" + nrCartaoIni + "' and '" + nrCartoesFim + "'";
                DataTable dados = new DataTable();

                //SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);

                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar assinaturas " + ex.Message);
            }
        }

        public void addAssinatura(Assinatura obj)
        {
            try
            {
                string sql = "insert into  tblAssinaturas (dtAssinatura, biAssinatura, nrCartao) values (@dtAssinatura,@biAssinatura,@nrCartao)";

                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@dtAssinatura",obj.DtAssnatura);
                cmd.Parameters.AddWithValue("@biAssinatura", obj.BiAssinatura);
                cmd.Parameters.AddWithValue("@nrCartao", obj.NrCartao);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar assinaturas " + ex.Message);
            }
        }

        public string formatoData(String data)
        {
            return data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2) + " " + data.Substring(11, 8);
        }

        // Motodos para atualização de registros

        public DataTable getAssinaturasParaAtualizacao(DateTime dtAtualizacao) {
            DataTable vDados = new DataTable();

            string sql = "SELECT top 250 dtAssinatura ,biAssinatura"
                  +",nrCartao,dtCadastro ,nmCartao ,nrCPF ,dsEndereco ,dsBairro"
                  +",nmCidade ,nrCEP ,sgUF ,dtNascimento ,nrRG ,dtExpRG ,biRGFrente"
                  +",biRGVerso,dsOrgaoExpRG,nrFones,tpCartao,dtRenovacao ,idCartorio"
                  + " FROM vwAssinaturasCartao where dtAssinatura > @dtAssinatura"
                  + " order by dtAssinatura ";



            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("@dtAssinatura",dtAtualizacao);
            da.Fill(vDados);
            return vDados;
        }

        public void delAssinaturas(string nrCartao, SqlTransaction trans = null)
        {
            try
            {
                string sql = "delete from  tblAssinaturas  where nrCartao = '" + nrCartao.PadLeft(7, '0') + "'";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao apagar assinatura\n" + ex.Message);
            }
        }


        public void delAssinatura(DateTime dtAssin, string nrCartao)
        {
            try
            {
                string sql = "delete from  tblAssinaturas  where nrCartao = '" + nrCartao.PadLeft(7, '0') + "'";
                           sql += "and DateAdd (ms,-DatePart (ms, [dtAssinatura] ), [dtAssinatura] ) ";
                           sql += " =  CONVERT(datetime,'" + formatoData(dtAssin.ToString()) + "',20) ";

                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao apagar assinatura\n" + ex.Message);
            }
        }

        public DataTable getAssinaturasPorTamanho(Int32 _tamanho) {
            DataTable vDados = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("select nrCartao, dtAssinatura, (nrTamanhoImagem/1024) as nrTamanhoKb ");
            sql.Append(", (nrTamanhoImagem/1024)/1024 as nrTamanhoMb ");
            sql.Append("from  vwlAssinaturas ");
            sql.Append("where (nrTamanhoImagem/1024) > @tamanho ");
            sql.Append("order by nrTamanhoImagem desc");


            SqlDataAdapter da = new SqlDataAdapter(sql.ToString(), con);
            da.SelectCommand.Parameters.AddWithValue("@tamanho", _tamanho);
            da.Fill(vDados);
            return vDados;
        }
    }
}
