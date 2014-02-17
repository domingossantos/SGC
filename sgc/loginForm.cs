using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAO;
using BLL;
using Modelos;
using sgc.utils;
using System.Data.SqlClient;

namespace sgc
{
    public partial class loginForm : Form
    {
        public mainForm paiForm;

        public loginForm(mainForm pai)
        {
            InitializeComponent();
            paiForm = pai;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.MdiParent.Close();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            if (txUsuario.Text.Length <= 0)
            {
                MessageBox.Show("Digite um nome de usuário!");
                txUsuario.Focus();
            }
            else if (txSenha.Text.Length <= 0)
            {
                MessageBox.Show("Digite uma senha!");
                txSenha.Focus();
            }
            else
            {
                try
                {
                    String login = txUsuario.Text.ToLower();
                    String senha = txSenha.Text.ToLower();

                    lblStatus.Text = "Conectando... Aguarde!";
                    Refresh();
                    Conexao con = new Conexao(Dados.strConexao);
                    UsuarioBLL usuarioBLL = new UsuarioBLL(con);
                    Usuario usuario = usuarioBLL.login(login);
                    
                    if (usuario.VlSenha.Equals(senha))
                    {
                        paiForm.setMenu(true);
                        sessao.UsuarioSessao = usuario;
                        sessao.NrCaixa = 0;

                        paiForm.setNomeUsuario(usuario.NmUsuario, usuario.DsLogin);
                        con.ObjCon.Close();

                        resumoForm oResumoForm = new resumoForm();

                        paiForm.abrirFormFilho(oResumoForm);

                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado!");
                    }
                }
                catch (SqlException) {
                    MessageBox.Show("Erro ao conectar ao banco.\nEntre en contato com o administrador!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao entrar no sistema! \nEntre en contato com o administrador!");
                }
                lblStatus.Text = "...";
            }
        }


        private void txSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                btEntrar_Click(sender, e);
            }
        }

        private void txUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                txSenha.Focus();

            }
        }

       
    }
}
