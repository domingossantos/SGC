using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Modelos;

namespace DAO
{
    public class CartorioDAO
    {
        private SqlConnection con;

        public CartorioDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public DataTable getListaCartorio(string filtro = "")
        {
            DataTable dados = new DataTable();
            String sql = "SELECT idCartorio,nmCartorio,dsObservacao,dsEndereco "
                        +" ,dsBairro,dsCidade,sgUF,nrFones,nrFax,dsEmail "
                        +" ,dtCadastro,nrCEP,nrCNPJ FROM SGC.dbo.tblCartorio "
                        +" where 1 = 1 and "+filtro;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao consultar cartorios " + ex.Message);
            }
        }
    }
}
