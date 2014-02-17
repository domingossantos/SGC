using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class CidadeDAO
    {
        private SqlConnection con;

        public CidadeDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getCidadesPorEstado(string uf) {
            DataTable vDados = null;
            try
            {
                string sql = "select idCidade,nmCidade from tblCidadeIBGE where dsUF = '" + uf + "'";

                SqlDataAdapter dAdapter = new SqlDataAdapter(sql,con);
                vDados = new DataTable();
                dAdapter.Fill(vDados);

                dAdapter.Dispose();
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

            return vDados;
        }
    }
}
