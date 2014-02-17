using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;


namespace DAO
{
    public class FilaAtendimentoDAO
    {
        private SqlConnection con;

        public FilaAtendimentoDAO(SqlConnection objCon)
        {
            this.con = objCon;
        }

        public string chamarCliente(int setor,string login) {
            try
            {
                string sql = "select top 1 a.nrAtendimento	"
                        + "from tblFilaAtendimento a "
                        + "where a.stAtendimento = 'N' and a.cdSetor = " + setor.ToString()
                        + " order by a.cdTipoAtendimento, a.dtAtendimento desc";

                string nrAtendimento = "0";

                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    nrAtendimento = dr["nrAtendimento"].ToString();

                    sql = "update tblFilaAtendimento set dsLogin = '" + login + "',"
                        + " dtAtendido=getdate(), stAtendimento = 'C' where nrAtendimento = " + nrAtendimento;
                    
                    dr.Close();

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }

                return nrAtendimento;
            }
            catch (Exception ex) {
                throw new Exception("Erro ao chamar cliente! "+ex.Message);
            }
        }


        public void iniciaAtendimento(string nrAtendimento) {
            try {

                string sql = "update tblFilaAtendimento set stAtendimento = 'A' where nrAtendimento = " + nrAtendimento;

                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar atendimento! " + ex.Message);
            }
        }
    }
}
