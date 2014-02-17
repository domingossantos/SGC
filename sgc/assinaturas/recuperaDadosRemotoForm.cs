using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using System.Data.SqlClient;
using System.Threading;
using System.Reflection;
using DAO;
using BLL;
using System.IO;

namespace sgc.assinaturas
{
    public partial class recuperaDadosRemotoForm : Form
    {
        //private AtualizaCartao atualizaCartao;
        private List<AtualizaCartao> TAtualizaCartao;
        private SqlConnection conRemoto;
        private DataTable dados;
        private DateTime dataUltimaAtualizacao;
        private CartaoAssinatura cartao;
        private Assinatura assinatura;
        private AssinaturasBLL assinaturaBLL;
        private Conexao con;
        public recuperaDadosRemotoForm()
        {
            con = new Conexao(Dados.strConexao);
            conRemoto = new SqlConnection(Dados.StrConRemoto);
            cartao = new CartaoAssinatura();
            assinatura = new Assinatura();
            assinaturaBLL = new AssinaturasBLL(con);

            dados = new DataTable();
            InitializeComponent();
        }

        private void getUltimaAtualizacao() {
            
            try
            {
                con.ObjCon.Open();

                string sql = "select max(dtUltimaAtualizacao) from tblAtualizacaoCadastro";

                SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                dataUltimaAtualizacao = Convert.ToDateTime(dr[0].ToString());

                lbDataAtualizacao.Text = dataUltimaAtualizacao.ToString();
                con.ObjCon.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: "+ex.Message);
            }
            
            
        }

        private void recuperaDadosRemotoForm_Load(object sender, EventArgs e)
        {
            
            getUltimaAtualizacao();

            try
            {
                Thread thr = new Thread(getCartoes);
                thr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar atualização\n" + ex.Message);
            }

        }


        private void getCartoes() {

            SetControlPropertyValue(lbStatus, "text", "Recuperando informações remotas");
            string sql = "select top 500 nrCartao,dtAssinatura from tblAssinaturas "
                        + "where stCopia = 'F' and dtAssinatura > '2010-01-01' order by dtAssinatura desc";

            conRemoto.Open();

            SqlCommand cmd = new SqlCommand(sql, conRemoto);

            SqlDataAdapter da = new SqlDataAdapter(sql, conRemoto);
            
            da.Fill(dados);

            SetControlPropertyValue(lbQtdAssinaturas,"Text",  dados.Rows.Count.ToString());
            SetControlPropertyValue(pbAssin, "Maximum", dados.Rows.Count);
            conRemoto.Close();
        
        }


        private int getAssnaturaLocal(string nrCartao, DateTime dtAssin) {

            string sql = "select count(*) as qtd from tblAssinaturas where nrCartao = '" + nrCartao + "'"
                        +" and dtAssinatura = '" + utils.formatos.formatoData(dtAssin.ToString()) + "'";

            if (con.ObjCon.State == ConnectionState.Closed)
                con.ObjCon.Open();

            SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            
            int i = (int)dr["qtd"];
            con.ObjCon.Close();
            return i;
        }

        private int getCartaoLocal(string nrCartao) {
            string sql = "select count(*) as qtd from tblCartaoAssinatura where nrCartao = '" + nrCartao + "'";

            if (con.ObjCon.State == ConnectionState.Closed)
                con.ObjCon.Open();

            SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            int i = (int)dr["qtd"];
            con.ObjCon.Close();
            return i;
        }

        private void gravaCartao() {
            con.ObjCon.Open();
        
        }

        private void atualizaDados() {

           
            DataView dvDados = new DataView(dados);
            DataRow drDados;
            SetControlPropertyValue(button1, "Enabled", false);
            SetControlPropertyValue(lbQtdAssinaturas, "Text", "Atualizado dados aguarde!");
            char op = 'N';
            CartaoAssinatura cartao = new CartaoAssinatura();

            string nmArquivo = @"log\log-" 
                    + utils.formatos.formatoData(DateTime.Now.Date.ToString(),true)
                    + "-" + DateTime.Now.Hour.ToString()
                    + "-" + DateTime.Now.Minute.ToString() 
                    + "-"+DateTime.Now.Second.ToString() 
                    + ".txt";
            string nmErro = @"log\error-"
                    + utils.formatos.formatoData(DateTime.Now.Date.ToString(), true)
                    + "-" + DateTime.Now.Hour.ToString()
                    + "-" + DateTime.Now.Minute.ToString()
                    + "-" + DateTime.Now.Second.ToString()
                    + ".txt";

            int c = 0;
            int err = 0;
            if (!File.Exists(nmArquivo)) {
                File.Create(nmArquivo).Close();
            }

            if (!File.Exists(nmErro))
            {
                File.Create(nmErro).Close();
            }



            TextWriter arquivo = File.AppendText(nmArquivo);
            TextWriter arquivoErro = File.AppendText(nmErro);

            arquivo.WriteLine("Iniciando copia "+DateTime.Now.ToLongDateString());
            arquivoErro.WriteLine("Iniciando copia " + DateTime.Now.ToLongDateString());
            for (int i = 0; i < dvDados.Count; i++)
            {

                try
                {
                    drDados = dvDados[i].Row;


                    //Verifica se cartão existe na base local
                    arquivo.WriteLine("Lendo Cartão " + drDados["nrCartao"].ToString());
                    if (getCartaoLocal(drDados["nrCartao"].ToString()) == 0)
                    {
                        op = 'N';
                    }
                    else
                    {
                        op = 'A';
                    }

                    cartao = getCartaoRemoto(drDados["nrCartao"].ToString());
                    assinaturaBLL.saveCartaoAssinatura(cartao, op);

                    if (getAssnaturaLocal(drDados["nrCartao"].ToString(), (DateTime)drDados["dtAssinatura"]) == 0)
                    {
                        getAssinRemoto(drDados["nrCartao"].ToString(), (DateTime)drDados["dtAssinatura"]);
                    }

                    setStatusAssinatura(drDados["nrCartao"].ToString(), utils.formatos.formatoData(drDados["dtAssinatura"].ToString()));

                    //salvaDataAtualizacao((DateTime)drDados["dtAssinatura"]);

                    arquivo.WriteLine("Cartão copiado");

                    SetControlPropertyValue(pbAssin, "Value", i + 1);
                    c++;
                    SetControlPropertyValue(lbCopiado, "Text", c.ToString());

                }
                catch (Exception ex)
                {
                    arquivoErro.WriteLine("Erro: " + ex.Message);
                    err++;
                }
                finally {
                    SetControlPropertyValue(lbQtd, "Text", i.ToString());
                    SetControlPropertyValue(lbErros, "Text", err.ToString());
                }
            }

            SetControlPropertyValue(lbQtdAssinaturas, "Text", "Atualização finalizada!");
            SetControlPropertyValue(button1, "Enabled", true);
            arquivo.Close();
            arquivoErro.Close();
        }

        private void getAssinRemoto(string nrCartao, DateTime dtAssin) {
            string sql = "select biAssinatura from tblAssinaturas where nrCartao = '" + nrCartao + "'"
                            + " and  DateAdd (ms,-DatePart (ms, [dtAssinatura] ), [dtAssinatura] ) = '" + utils.formatos.formatoData(dtAssin.ToString()) + "'";



            if (conRemoto.State == ConnectionState.Closed)
                conRemoto.Open();

            SqlCommand cmd = new SqlCommand(sql, conRemoto);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                try
                {
                    dr.Read();

                    assinatura.NrCartao = nrCartao;
                    assinatura.DtAssnatura = dtAssin;
                    assinatura.BiAssinatura = (byte[])dr["biAssinatura"];

                    assinaturaBLL.addAssinatura(assinatura);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally 
                {
                    dr.Close();
                }
            }
            conRemoto.Close();

        }

        private CartaoAssinatura getCartaoRemoto(string nrCartao) {

            string sql = "select nrCartao,idCartorio,dtCadastro,nmCartao"
                        +",nrCPF,dsEndereco,dsBairro,nmCidade,nrCEP"
                        +",sgUF,dtNascimento,nrRG,dtExpRG,biRGFrente"
                        +",biRGVerso,dsOrgaoExpRG,nrFones,tpCartao"
                        +",dtRenovacao,biFotoCartao,dsObservacao,dsEmail from tblCartaoAssinatura "
                        +"where nrCartao = '" + nrCartao + "'";

            if (conRemoto.State == ConnectionState.Closed)
                conRemoto.Open();

            SqlCommand cmd = new SqlCommand(sql, conRemoto);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();


            cartao.NrCartao = dr["nrCartao"].ToString();
            cartao.NmCartao = (dr["nmCartao"].ToString());
            cartao.DsEndereco = (dr["dsEndereco"].ToString());
            cartao.DsBairro = (dr["dsBairro"].ToString());
            cartao.NmCidade = (dr["nmCidade"].ToString());
            cartao.NrCEP = (dr["nrCEP"].ToString());
            cartao.NrRG = (dr["nrRG"].ToString());
            cartao.DsOrgaoEmissor = (dr["dsOrgaoExpRG"].ToString());

            cartao.DtCadastro = DateTime.Parse(dr["dtCadastro"].ToString());


            if (dr["dtExpRG"].ToString() != "")
                cartao.DtExpedicao = DateTime.Parse(dr["dtExpRG"].ToString());

            cartao.NrCPF = (dr["nrCPF"].ToString());
            cartao.NrFones = (dr["nrFones"].ToString());
            if (!dr["tpCartao"].ToString().Equals(""))
                cartao.TpCartao = Convert.ToChar(dr["tpCartao"].ToString());
            else
                cartao.TpCartao = '0';

            cartao.SgUF = (dr["sgUF"].ToString());
            if (dr["dtNascimento"].ToString() != "")
                cartao.DtNascimento = DateTime.Parse(dr["dtNascimento"].ToString());
            else
                cartao.DtNascimento = null;

            if (dr["dtRenovacao"].ToString() != "")
                cartao.DtRenovacao = DateTime.Parse(dr["dtRenovacao"].ToString());
            else
                cartao.DtRenovacao = null;

            if (dr["biFotoCartao"].ToString() != "")
            {
                cartao.BiFotoCartao = (byte[])dr["biFotoCartao"];
            }
            cartao.DsObservacao = dr["dsObservacao"].ToString();
            cartao.DsEmail = dr["dsEmail"].ToString();

            try
            {
                return cartao;
            }
            finally {
                dr.Close();
                conRemoto.Close();
            }
            
        }


        private void setStatusAssinatura(string cartao,string data) {
            try
            {
                if (conRemoto.State == ConnectionState.Closed)
                    conRemoto.Open();

                string sql = "EXEC	spMarcaAtualizacao @nrCartao = '" + cartao + "', "
                            + " @dtAssinatura = '" +  data + "'";

                SqlCommand cmd = new SqlCommand(sql, conRemoto);

                cmd.ExecuteNonQuery();
            }
            finally {
                conRemoto.Close();
            }
            
        }

        private void salvaDataAtualizacao(DateTime data) {
            string sql = "INSERT INTO tblAtualizacaoCadastro "
                        + "(dtUltimaAtualizacao) VALUES (@dtUltimaAtualizacao)";

            if(con.ObjCon.State == ConnectionState.Closed)
                con.ObjCon.Open();
            
            SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
            cmd.Parameters.AddWithValue("@dtUltimaAtualizacao",data);
            cmd.ExecuteNonQuery();

            con.ObjCon.Close();
        }

        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thr = new Thread(atualizaDados);
                thr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar atualização\n" + ex.Message);
            }
        }


    }
}
