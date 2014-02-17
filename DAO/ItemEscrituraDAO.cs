using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Modelos;

namespace DAO
{
    public class ItemEscrituraDAO
    {
        private SqlConnection con;

        public ItemEscrituraDAO(SqlConnection c)
        {
            con = c;
        }

        public DataTable getListaItensAtivo() {
            string sql = "SELECT idItemEscritura,dsItemEscritura,vlItemEscritura"
                        + ",stItemEscritura FROM tblItensEscritura WHERE stItemEscritura = 'A'";
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

        public ItemEscritura getItemEscritura(int idx) {
            string sql = "SELECT idItemEscritura,dsItemEscritura,vlItemEscritura"
                        + ",stItemEscritura FROM tblItensEscritura WHERE idItemEscritura = " + idx;
            ItemEscritura item = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    item = new ItemEscritura();
                    item.IdItemEscritura = Convert.ToInt32(dr["idItemEscritura"].ToString());
                    item.DsItemEscritura = dr["dsItemEscritura"].ToString();
                    item.VlItemEscritura = Convert.ToDouble( dr["vlItemEscritura"].ToString());
                    item.StItemEscritura = Convert.ToChar(dr["stItemEscritura"].ToString());

                    dr.Close();
                }
                return item;
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

        public void addItemEscritura(ItemEscritura item, SqlTransaction trans = null) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sql;

                cmd.Connection = con;
                cmd.Transaction = trans;

                sql = "INSERT INTO tblItensEscritura "
                    +"(dsItemEscritura,vlItemEscritura,stItemEscritura) "
                    + " VALUES (@dsItemEscritura,@vlItemEscritura,'A'); "
                    + " select @@IDENTITY;";

                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@dsItemEscritura", item.DsItemEscritura);
                cmd.Parameters.AddWithValue("@vlItemEscritura", item.VlItemEscritura);

                item.IdItemEscritura = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Item: " + ex.Message);
            }
        }

        

    }
}
