using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;
using Modelos;

namespace sgc.acesso
{
    public partial class usuarioForm : sgc.modeloForm
    {
        Usuario usuario;
        UsuarioBLL usuarioBLL;
        PerfilBLL perfilBLL;
        Conexao con;
        Int16 operacao = 0;
        public usuarioForm()
        {
            con = new Conexao(Dados.strConexao);
            usuarioBLL = new UsuarioBLL(con);
            perfilBLL = new PerfilBLL(con);
            usuario = new Usuario();
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            txLogin.Focus();
            operacao = 1;
        }

        private void limparCampos()
        {
            txLogin.Text = "";
            txNome.Text = "";
            txCPF.Text = "";
            atualizaPerfil();
            atualizaSetor();
        }
        private void atualizaGrid()
        {

            grid.DataSource = usuarioBLL.listarUsuarios();

            grid.Columns[0].HeaderText = "Login";
            grid.Columns[0].Width = 120;
            grid.Columns[1].HeaderText = "Nome usuário";
            grid.Columns[1].Width = 240;
            grid.Columns[2].HeaderText = "CPF";
            grid.Columns[2].Width = 110;
            grid.Columns[3].HeaderText = "Data Cadastro";
            grid.Columns[3].Width = 110;
            grid.Columns[4].HeaderText = "Perfil";
            grid.Columns[4].Width = 60;

   
        }

        private void usuarioForm_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        public void prencherCampos(String login) 
        {
            
            usuario = this.usuarioBLL.getUsuario(login);
            atualizaPerfil();
            atualizaSetor();
            txLogin.Text = usuario.DsLogin;
            txNome.Text = usuario.NmUsuario;
            txCPF.Text = usuario.NrCPF;
            cbPerfil.SelectedValue = usuario.CdPerfil;
            cbSetor.SelectedValue = usuario.CdSetor;
            
        }

        public void atualizaPerfil()
        {
            cbPerfil.DataSource = perfilBLL.listagem();
            cbPerfil.ValueMember = "cdPerfil";
            cbPerfil.DisplayMember = "nmPerfil";
            cbPerfil.SelectedItem = -1;
        }

        public void atualizaSetor()
        {
            cbSetor.DataSource = perfilBLL.listaSetor();
            cbSetor.ValueMember = "cdSetor";
            cbSetor.DisplayMember = "nmSetor";
            cbSetor.SelectedItem = -1;
        }


        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            prencherCampos(grid[0, grid.CurrentRow.Index].Value.ToString());
            operacao = 2;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (operacao == 0) {
                MessageBox.Show("Não há registro para salvar");
                return;
            }

            if (txLogin.Text.Equals("")) {
                MessageBox.Show("Campo obrigatório. Login");
                txLogin.Focus();
                return;
            }

            if (txNome.Text.Equals(""))
            {
                MessageBox.Show("Campo obrigatório. Nome");
                txNome.Focus();
                return;
            }

            if (cbPerfil.SelectedValue == null)
            {
                MessageBox.Show("Campo obrigatório. Perfil");
                txLogin.Focus();
                return;
            }

            if (operacao == 1)
            {
                try
                {
                    usuario.DsLogin = txLogin.Text;
                    usuario.NrCPF = txCPF.Text.ToString();
                    usuario.NmUsuario = txNome.Text;
                    usuario.CdPerfil = Convert.ToInt32(cbPerfil.SelectedValue.ToString());
                    usuario.VlSenha = "123456"; //utils.crypt.CalculateMD5Hash("123456");
                    usuario.CdSetor = Convert.ToInt32(cbSetor.SelectedValue.ToString());

                    usuarioBLL.inserir(usuario);
                    MessageBox.Show("Registro gravado!");
                    atualizaGrid();
                    limparCampos();
                    operacao = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Edição de Registro
            if (operacao == 2) 
            {
                try
                {
                    usuario.DsLogin = txLogin.Text;
                    usuario.NrCPF = txCPF.Text.ToString();
                    usuario.NmUsuario = txNome.Text;
                    usuario.CdPerfil = Convert.ToInt32(cbPerfil.SelectedValue.ToString());
                    usuario.CdSetor = Convert.ToInt32(cbSetor.SelectedValue.ToString());
                    usuarioBLL.alterar(usuario);
                    MessageBox.Show("Registro atualizado!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    atualizaGrid();
                    limparCampos();
                    operacao = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (operacao == 2)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Deseja apagar este registro", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result.ToString().Equals("Yes"))
                    {
                        usuarioBLL.deletar(txLogin.Text);
                        MessageBox.Show("Registro apagado!");
                        atualizaGrid();
                        limparCampos();
                        operacao = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Selecione um registro para apagar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            operacao = 0;
            atualizaGrid();
            limparCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
        } 

       
    }
}

