using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Modelos;

namespace DAO
{
    public class TipoDocumentoDAO
    {
        private SqlConnection con;

        public TipoDocumentoDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getTiposDocumentos(String filtro = "")
        {
            String sql = "Select cdTipoDocumento, nmTipoDocumento ";
            sql += "from tblTipoDocumento where 1 = 1 " + filtro;
            sql += " order by nmTipoDocumento";

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

        public TipoDocumento getTipoDocumento(int codigo)
        {
            String sql = "SELECT cdTipoDocumento,nmTipoDocumento FROM tblTipoDocumento where cdTipoDocumento = " + codigo;
            TipoDocumento tipo = new TipoDocumento();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    tipo.CdTipoDocumento = Convert.ToInt32(dr["cdTipoDocumento"].ToString());
                    tipo.NmTipoDocumento = dr["nmTipoDocumento"].ToString();
                    dr.Close();
                }
                return tipo;
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
