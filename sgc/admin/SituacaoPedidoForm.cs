using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using sgc.utils;

namespace sgc.admin
{
    public partial class SituacaoPedidoForm : Form
    {
        Conexao con = new Conexao(Dados.strConexao);
        ConexaoDB conn = new ConexaoDB(Dados.strConexao);
        public SituacaoPedidoForm()
        {
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            getItensPedido();
            getMovimentoCaixa();
            statusPedido();
        }

        public void getItensPedido()
        {
            try
            {
                String sql = "select a.dsAto,a.vlAto,i.nrSelo ";
                sql += ",(select dsTipoSelo from tblTipoSelo where cdTipoSelo = i.cdTipoSelo) as tipoSelo ";
                sql += ",i.vlItem from tblItensPedido i ";
                sql += "inner join tblAtosOperacoes a on i.cdAto = a.cdAto ";
                sql += "where nrPedido =  " + txNrPedido.Text;
                sql += "order by i.idItemPedido";

                SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridPedido.DataSource = dt;
                da.Dispose();
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao consultar pedido.\n"+ex.Message,3);
            }

        }

        public void getMovimentoCaixa() {
            try
            {
                String sql = "select idMovimento,dsLogin ,vlMovimento,vlDesconto,  tpPagamento, ";
                sql+= "case tpPagamento ";
	                    sql+= "when 1 then 'Dinheiro' ";
                        sql+= "	when 2 then 'Correntista' ";
                        sql+= "	when 3 then 'Cheque' ";
                        sql+= "	else 'Deposito' end tipoPagamento ";
                        sql += ",CONVERT(VARCHAR(10), dtMovimento, 103) +' '+CONVERT(VARCHAR(12), dtMovimento, 114) as dtMovimento ";
                sql += "from tblMovimentoCaixa where nrPedido =" + txNrPedido.Text;
                sql += "order by dtMovimento";

                SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridPagto.DataSource = dt;
            }
            catch (Exception ex)
            {
                utils.MessagensExcept.funMsgSistema("Erro ao consultar pedido.\n" + ex.Message, 3);
            }
        }

        public void statusPedido() {
            String sql = "select p.nrPedido,p.dtPedido,p.dsLogin,p.stPedido,"
                        + "(select SUM(i.vlItem) from tblItensPedido i "
                        + "where i.nrPedido = p.nrPedido) vlPedido "
                        + "from tblPedidos p "
                        + "where p.nrPedido = " + txNrPedido.Text;


            try
            {
                con.ObjCon.Open();
                SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    dr.Read();

                    lbUsuario.Text = dr["dsLogin"].ToString();
                    lbDataPedido.Text = dr["dtPedido"].ToString();
                    lbStatus.Text = dr["stPedido"].ToString();


                    if (!dr["vlPedido"].ToString().Equals(""))
                        lbValor.Text = String.Format("{0:C2}", dr["vlPedido"]);

                    dr.Close();
                }
                dr.Close();



            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        private void apagarMovimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String idMovimento = gridPagto[0, gridPagto.CurrentRow.Index].Value.ToString();

                String sql = "delete from tblMovimentoCaixa where idMovimento = " + idMovimento;

                con.ObjCon.Open();
                SqlCommand cmd = new SqlCommand(sql, con.ObjCon);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Movimento apagado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar movimento.\nErro " + ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }

        }

        private void alterarValorMovimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strValor = (Microsoft.VisualBasic.Interaction.InputBox("Novo Valor", "Cartorio Conduru", "1", 150, 150));
                
                String idMovimento = gridPagto[0, gridPagto.CurrentRow.Index].Value.ToString();

                double valor = Convert.ToDouble(strValor);


                if (valor > 0)
                {

                    String sql = "update tblMovimentoCaixa set vlMovimento = @valor where idMovimento = " + idMovimento;

                    con.ObjCon.Open();
                    SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
                    cmd.Parameters.AddWithValue("@valor", valor);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Movimento alterado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar valor de movimento.\nErro " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        private void btEstorno_Click(object sender, EventArgs e)
        {


            try
            {
                conn.abreBanco();


                //conn.trans = conn.conexao.BeginTransaction();

                String sql = "select idMovimento,tpPagamento from tblMovimentoCaixa where nrPedido = " + txNrPedido.Text;

                DataTable tbMovimento = conn.retornarDataSet(sql);


                if (tbMovimento.Rows.Count > 0)
                {

                    for (int i = 0; tbMovimento.Rows.Count > i;i++ )
                    {
                        sql = "delete from tblMovimentoCaixa where idMovimento = " + tbMovimento.Rows[i]["idMovimento"].ToString();
                        conn.executaSemRetorno(sql);

                        if (Convert.ToInt16(tbMovimento.Rows[i]["tpPagamento"]) == 2)
                        {
                            sql = "delete from tblPedidosCorrentista where nrPedido = " + txNrPedido.Text;
                        }
                        else
                        {
                            sql = "delete from tblCheque where nrPedido = " + txNrPedido.Text;
                        }

                        conn.executaSemRetorno(sql);

                    }

                }
                sql = "update tblPedidos set stPedido = 'F' where nrPedido = " + txNrPedido.Text;
                conn.executaSemRetorno(sql);

                //conn.trans.Commit();
                
                utils.MessagensExcept.funMsgSistema("Pedido estornado", 2);
            }
            catch (Exception ex)
            {
                //conn.trans.Rollback();
                utils.MessagensExcept.funMsgSistema("Erro ao estornar pagamento.\n" + ex.Message, 1);
            }
            finally {
                conn.fechaBanco();
            }
              
        }

        
    }
}
