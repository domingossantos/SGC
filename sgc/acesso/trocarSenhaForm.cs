using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using DAO;

namespace sgc.acesso
{
    public partial class trocarSenhaForm : Form
    {
        public trocarSenhaForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txAtual.Text.Equals("")) {
                MessageBox.Show("Campo obrigatório: Senha Atual");
                txAtual.Focus();
                return;
            }

            if (txNova.Text.Equals(""))
            {
                MessageBox.Show("Campo obrigatório: Nova Senha");
                txNova.Focus();
                return;
            }

            if (txRepedida.Text.Equals(""))
            {
                MessageBox.Show("Campo obrigatório: Repetir Senha");
                txRepedida.Focus();
                return;
            }

            if(txNova.Text != txRepedida.Text){
                MessageBox.Show("Senhas devem ser iguais!");
                txNova.Focus();
                return;
            }

            

            Conexao con = new Conexao(Dados.strConexao);
            UsuarioBLL usuarioBLL = new UsuarioBLL(con);

            try
            {
                
                //String senhaCrypt = utils.crypt.CalculateMD5Hash(txAtual.Text);
                if (utils.sessao.UsuarioSessao.VlSenha.Equals(txAtual.Text))
                {

                    try
                    {
                        
                        utils.sessao.UsuarioSessao.VlSenha = txNova.Text;
                        usuarioBLL.alterarSenha(utils.sessao.UsuarioSessao);
                       
                        MessageBox.Show("Senha Alterada!");
                        this.Close();
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Erro ao alterar a senha.\n"+ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Senha atual não confere!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Usuario não encontrado! " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
