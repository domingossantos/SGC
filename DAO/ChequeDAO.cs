using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Modelos;

namespace DAO
{
    public class ChequeDAO
    {

        private SqlConnection con;

        public ChequeDAO(SqlConnection c)
        {
            con = c;
        }

        public void addCheque(Cheque cheque)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                String sql;
                cmd.Connection = con;

                sql = "INSERT INTO tblCheque"
                       +"(nrPedido,nrCheque,nrBanco,nrAgencia"
                       +",nrConta,nrRG,dtCheque,stCheque,stDeposito) VALUES"
                       + "(@nrPedido,@nrCheque,@nrBanco,@nrAgencia"
                       + ",@nrConta,@nrRG,@dtCheque,@stCheque,@stDeposito)"
                       +"select @@IDENTITY;";


                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@nrPedido", cheque.NrPedido);
                cmd.Parameters.AddWithValue("@nrCheque", cheque.NrCheque);
                cmd.Parameters.AddWithValue("@nrBanco", cheque.NrBanco);
                cmd.Parameters.AddWithValue("@nrAgencia", cheque.NrAgencia);
                cmd.Parameters.AddWithValue("@nrConta", cheque.NrConta);
                cmd.Parameters.AddWithValue("@nrRG", cheque.NrRG);
                cmd.Parameters.AddWithValue("@dtCheque", cheque.DtCheque);
                cmd.Parameters.AddWithValue("@stCheque", cheque.StCheque);
                cmd.Parameters.AddWithValue("@stDeposito", cheque.StDeposito);
                
                cheque.IdCheque = Convert.ToInt32(cmd.ExecuteScalar());

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
    }
}
