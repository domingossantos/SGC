using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;

namespace DAO
{
    public class TipoRGDAO
    {
        private SqlConnection con;

        public TipoRGDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getTipoRG()
        {
            DataTable dados = new DataTable();
            String sql = "select cdTipoRG, dsTipoRG ";
            sql += " from tblTipoRG ";
            sql += " order by cdTipoRG";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar Tipo RG " + ex.Message);
            }

        }

        public String getDescricao(int id) {
            String sql = "select dsTipoRG from tblTipoRG where cdTipoRG = " + id;

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            String desc = "";
            if (dr.HasRows)
            {
                desc = dr["dsTipoRG"].ToString();
            }

            dr.Close();
            return desc;
        }

    }
}
