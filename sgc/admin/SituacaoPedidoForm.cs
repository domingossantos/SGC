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

namespace sgc.admin
{
    public partial class SituacaoPedidoForm : Form
    {
        Conexao con = new Conexao(Dados.strConexao);
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
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao consultar pedido.\n"+ex.Message,3);
            }

        }

        public void getMovimentoCaixa() {
            try
            {
                String sql = "select dsLogin ,vlMovimento,vlDesconto, ";
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
    }
}
