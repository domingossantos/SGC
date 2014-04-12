using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class TipoSeloDAO
    {
        private SqlConnection con;
        public TipoSeloDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getTipoSelos(String filtro = "")
        {
            String sql = "Select s.cdTipoSelo,s.nrSerie,s.dsTipoSelo,s.vlSelo,d.nmTipoDocumento,s.stTipoSelo from tblTipoSelo s";
            sql += " inner join tblTipoDocumento d on s.cdTipoDocumento = d.cdTipoDocumento where 1 = 1 " + filtro;
            sql += " order by s.dsTipoSelo";

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

        public TipoSelo getTipoSelo(int codigo)
        {
            TipoSelo tipo = new TipoSelo();
            String sql = "Select cdTipoSelo,nrSerie,dsTipoSelo,vlSelo,cdTipoDocumento,stTipoSelo from tblTipoSelo"
                    + " where cdTipoSelo = @tipo";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@tipo",codigo);
                SqlDataReader dr = cmd.ExecuteReader();
                
                dr.Read();

                tipo.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());
                tipo.NrSerie = dr["nrSerie"].ToString();
                tipo.DsTipoSelo = dr["dsTipoSelo"].ToString();
                tipo.VlSelo = Convert.ToDouble(dr["vlSelo"].ToString());
                tipo.CdTipoDocumento = Convert.ToInt32(dr["cdTipoDocumento"].ToString());

                if (dr["stTipoSelo"].ToString().Equals(""))
                {
                    tipo.StTipoSelo = 'F';
                }
                else
                {
                    tipo.StTipoSelo = dr["stTipoSelo"].ToString().ToCharArray()[0];
                }
                return tipo;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQl: " + ex.Message);
            }
        }

        public TipoSelo getTipoSeloPorDocumento(int codigo)
        {
            TipoSelo tipo = null;
            String sql = "Select top 1 cdTipoSelo,nrSerie,dsTipoSelo,vlSelo,cdTipoDocumento from tblTipoSelo"
                    + " where cdTipoDocumento = @tipo order by cdTipoSelo desc";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@tipo", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    tipo = new TipoSelo();
                    tipo.CdTipoSelo = Convert.ToInt32(dr["cdTipoSelo"].ToString());
                    tipo.NrSerie = dr["nrSerie"].ToString();
                    tipo.DsTipoSelo = dr["dsTipoSelo"].ToString();
                    tipo.VlSelo = Convert.ToDouble(dr["vlSelo"].ToString());
                    tipo.CdTipoDocumento = Convert.ToInt32(dr["cdTipoDocumento"].ToString());
                }
                return tipo;
            }
            catch (SqlException ex)
            {
                con.Close();
                throw new Exception("Erro SQl: " + ex.Message);
            }
        }

        public void addTipoSelo(TipoSelo tipo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                String sql = "insert into tblTipoSelo (nrSerie,dsTipoSelo,vlSelo,cdTipoDocumento,stTipoSelo) ";
                       sql+= " values(@serie,@descricao,@valor,@tipo,@status); select @@IDENTITY;";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@serie", tipo.NrSerie);
                cmd.Parameters.AddWithValue("@descricao", tipo.DsTipoSelo);
                cmd.Parameters.AddWithValue("@valor", tipo.VlSelo);
                cmd.Parameters.AddWithValue("@tipo", tipo.CdTipoDocumento);
                cmd.Parameters.AddWithValue("@status", tipo.StTipoSelo);
                
                tipo.CdTipoSelo = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void saveTipoSelo(TipoSelo tipo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                String sql = "UPDATE tblTipoSelo SET nrSerie = @serie, dsTipoSelo = @descricao, stTipoSelo = @status, ";
                        sql += " vlSelo = @valor, cdTipoDocumento = @tipo where cdTipoSelo = @codigo";
                        cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@serie", tipo.NrSerie);
                cmd.Parameters.AddWithValue("@descricao", tipo.DsTipoSelo);
                cmd.Parameters.AddWithValue("@valor", tipo.VlSelo);
                cmd.Parameters.AddWithValue("@codigo", tipo.CdTipoSelo);
                cmd.Parameters.AddWithValue("@tipo", tipo.CdTipoDocumento);
                cmd.Parameters.AddWithValue("@status", tipo.StTipoSelo);
                

                int result = cmd.ExecuteNonQuery();

                if (result != 1)
                    throw new Exception("Não foi possivel alterar registro");
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

        public void delTipoSelo(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from tblTipoSelo where cdTipoSelo = " + codigo;

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
