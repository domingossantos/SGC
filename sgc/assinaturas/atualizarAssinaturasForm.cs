using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using DAO;
using Modelos;
using BLL;


namespace sgc.assinaturas
{
    public partial class atualizarAssinaturasForm : Form
    {

        Conexao conRemoto;
        Conexao conLocal;
        DataTable dtAssinaturas;
        CartaoAssinatura cartao;
        Assinatura assinatura;
        AssinaturasBLL assinaturaBLL;
        AssinaturasBLL assinaturaBLLRemoto;
        public atualizarAssinaturasForm()
        {
            conLocal = new Conexao(Dados.strConexao);
            conRemoto = new Conexao(Dados.StrConRemoto);
            assinaturaBLL = new AssinaturasBLL(conLocal);
            assinaturaBLLRemoto = new AssinaturasBLL(conRemoto);
            InitializeComponent();
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

        /*
        delegate void lbStatusDelegate(string texto);
        private void setLbStatus(string txt) {
            if (lbStatus.InvokeRequired)
            {
                lbStatusDelegate deleg = new lbStatusDelegate(setLbStatus);
                lbStatus.Invoke(deleg, new object[] { txt });
            }
            else {
                lbStatus.Text = txt;
            }
        }
        */
        private void getAssinaturasAtualizar() 
        {
            try
            {
                SetControlPropertyValue(lbStatus, "text", "Conectando com Servidor Remoto");

                SetControlPropertyValue(lbStatus, "text", "Verificando atualização. Aguarde!");

                dtAssinaturas = new DataTable();
                DateTime data = (assinaturaBLL.getDataUltimaAssinaturaAtualiza());
                
                dtAssinaturas = assinaturaBLLRemoto.getAssinaturasParaAtualizacao(data);

                SetControlPropertyValue(lbNoAssinaturas, "text", dtAssinaturas.Rows.Count.ToString());

                SetControlPropertyValue(lbStatus, "text", "Atualização já verificada! Data:"+data);

                SetControlPropertyValue(btAtualizar, "Enabled", true);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void getAssnaturas() { 

            DataView dv = new DataView(dtAssinaturas);
            DataRow dr;

            char op = 'I';

            assinatura = new Assinatura();
            SetControlPropertyValue(pbAtualiza, "Maximum", dv.Count);
            SetControlPropertyValue(btVerificar, "Enabled", false);
            for (int i = 0; i < dv.Count; i++) {
                dr = dv[i].Row;

                // verificar se o cartao existe
                cartao = assinaturaBLL.getCartao(dr["nrCartao"].ToString());

                if (cartao.NrCartao == null) {
                    // se não inclui
                    op = 'I';
                }
                else {
                    // se existe atualiza
                    op = 'A';
                }

                cartao.NrCartao = dr["nrCartao"].ToString();
                cartao.NmCartao = dr["nmCartao"].ToString();
                cartao.NmCidade = dr["nmCidade"].ToString();
                cartao.NrCEP = dr["nrCEP"].ToString();
                cartao.DsBairro = dr["dsBairro"].ToString();
                cartao.DsEndereco = dr["dsEndereco"].ToString();
                cartao.DsOrgaoEmissor = dr["dsOrgaoExpRG"].ToString();
                cartao.DtCadastro = DateTime.Parse( dr["dtCadastro"].ToString());
                if (!dr["dtExpRG"].ToString().Equals(""))
                    cartao.DtExpedicao = DateTime.Parse(dr["dtExpRG"].ToString());
                else
                    cartao.DtExpedicao = DateTime.Parse("1900-01-01");

                if (!dr["dtNascimento"].ToString().Equals(""))
                    cartao.DtNascimento = DateTime.Parse(dr["dtNascimento"].ToString());
                else
                    cartao.DtNascimento = DateTime.Parse("1900-01-01"); ;

                cartao.DtRenovacao = DateTime.Parse(dr["dtAssinatura"].ToString());
                cartao.NrCPF = dr["nrCPF"].ToString();
                cartao.NrFones = dr["nrFones"].ToString();
                cartao.NrRG = dr["nrRG"].ToString();
                cartao.SgUF = dr["sgUF"].ToString();
                cartao.TpCartao = char.Parse( dr["tpCartao"].ToString());
                cartao.IdCartorio = Convert.ToInt32(dr["idCartorio"].ToString());

                // Salvando Informações
                
                if (assinaturaBLL.getExisteAssinatura(cartao.NrCartao, DateTime.Parse(dr["dtAssinatura"].ToString())) == 0)
                {
                    try
                    {
                        assinaturaBLL.saveCartaoAssinatura(cartao, op);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Erro na atualização!\n" + ex.Message);
                    }

                    if (assinaturaBLL.getExisteAssinatura(dr["nrCartao"].ToString(), DateTime.Parse(dr["dtAssinatura"].ToString())) == 0)
                    {
                        assinatura.DtAssnatura = DateTime.Parse(dr["dtAssinatura"].ToString());
                        assinatura.NrCartao = dr["nrCartao"].ToString();
                        assinatura.BiAssinatura = (byte[])dr["biAssinatura"];
                        try
                        {
                            assinaturaBLL.addAssinatura(assinatura);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro na atualização!\n" + ex.Message);
                        }
                    
                    }

                    
                    
                }
                SetControlPropertyValue(pbAtualiza, "Value", i + 1);
            }

            MessageBox.Show("Assinaturas Atualizadas");
            SetControlPropertyValue(lbNoAssinaturas,"Text","0");
            SetControlPropertyValue(lbStatus, "Text", "Clique em Verificar para saber se existem atualizações");
            SetControlPropertyValue(btVerificar, "Enabled", true);
            SetControlPropertyValue(btAtualizar, "Enabled", false);
            dtAssinaturas.Dispose();
            // insere assinatura
        }


        private void atualizarAssinaturasForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadStart thrStart = new ThreadStart(getAssnaturas);
                Thread thr = new Thread(thrStart);
                thr.IsBackground = true;
                thr.Start();
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar assinaturas\n" + ex.Message);
            }
            
        }

        private void btVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                 ThreadStart thrStart = new ThreadStart(getAssinaturasAtualizar);
                 Thread thr = new Thread(thrStart);
                 thr.IsBackground = true;
                 thr.Start(); 
                //getAssinaturasAtualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar atualização\n" + ex.Message);
            }
        }

    }
}
