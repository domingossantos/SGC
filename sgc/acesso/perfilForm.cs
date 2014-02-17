using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;
using Modelos;


namespace sgc.acesso
{
    public partial class perfilForm : Form
    {
        private sbyte operacao;
        private Conexao con;
        private PerfilBLL perfilBLL;
        private Perfil perfil;
        private MenuPerfil menuPerfil;
        private MenuPerfilBLL menuPerfilBLL;
        private MenuBLL menuBLL;
        public sbyte Operacao
        {
            get { return operacao; }
            set { operacao = value; }
        }
        public perfilForm()
        {
            Operacao = 0;
            con = new Conexao(Dados.strConexao);
            perfilBLL = new PerfilBLL(con);
            perfil = new Perfil();
            menuPerfil = new MenuPerfil();
            menuPerfilBLL = new MenuPerfilBLL(con);
            menuBLL = new MenuBLL(con);
            InitializeComponent();
        }

        public void atualizaGrid() 
        {
            gridView.DataSource = perfilBLL.listagem();
            gridView.Columns[0].HeaderText = "Código";
            gridView.Columns[0].Width = 80;
            gridView.Columns[1].HeaderText = "Perfil";
            gridView.Columns[1].Width = 200;
        }

        private void perfilForm_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void perfilForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }

       

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txPerfil.Focus();
            Operacao = 1; // Novo Registro
            txCodigo.Text = "";
            txPerfil.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            //con.ObjCon.BeginTransaction();

            if (Operacao == 1) 
            {
                
                perfil.NmPerfil = txPerfil.Text.ToUpper();

                try 
                {
                    perfilBLL.incluir(perfil);
                    MessageBox.Show("Registro gravado");
                }
                catch (Exception ex){
                    MessageBox.Show(ex.ToString());

                }
                txCodigo.Text = perfil.CdPerfil.ToString();
                atualizaGrid();

                Operacao = 0;

                for (int i = 0; i < tvMenu.Nodes.Count; i++)
                {
                    TreeNode no = tvMenu.Nodes[i];
                    
                    if (no.Checked)
                    {
                        MessageBox.Show(no.Index.ToString());
                        //menuPerfil.CdMenu = no.
                    }
                    if (no.Nodes.Count > 1)
                    {
                        for (int x = 0; x < no.Nodes.Count; x++)
                        {
                            TreeNode noFilho = no.Nodes[x];
                            if (noFilho.Checked)
                            {
                                MessageBox.Show(noFilho.Index.ToString());
                            }
                        }

                    }
                }

            }

            if (Operacao == 2)
            {
                try
                {
                    // Atualizar registro
                    perfil.CdPerfil = Convert.ToInt32(txCodigo.Text);
                    perfil.NmPerfil = txPerfil.Text;

                    perfilBLL.alterar(perfil);
                    //MessageBox.Show("Registro alterado!");
                    atualizaGrid();
                    menuBLL.apagaMenuPerfil(perfil.CdPerfil);
                    int codigo = 0;
                    string[] texto;
                    for (int i = 0; i < tvMenu.Nodes.Count; i++)
                    {
                        TreeNode no = tvMenu.Nodes[i];

                        if (no.Checked)
                        {
                            texto = no.Text.Split('-');
                            
                            codigo = Convert.ToInt32(texto[0].Trim());
                            menuPerfilBLL.incluir(codigo,perfil.CdPerfil);
                        }

                        if (no.Nodes.Count > 0)
                        {
                            for (int x = 0; x < no.Nodes.Count; x++)
                            {
                                TreeNode noFilho = no.Nodes[x];
                                
                                if (noFilho.Checked)
                                {
                                    texto = noFilho.Text.Split('-');

                                    codigo = Convert.ToInt32(texto[0].Trim());

                                    menuPerfilBLL.incluir(codigo, perfil.CdPerfil);
                                }

                                if (noFilho.Nodes.Count > 0)
                                {
                        
                                    for (int x1 = 0; x1 < noFilho.Nodes.Count; x1++)
                                    {
                                        TreeNode noNeto = noFilho.Nodes[x1];
                                
                                        if (noNeto.Checked)
                                        {
                                            texto = noNeto.Text.Split('-');

                                            codigo = Convert.ToInt32(texto[0].Trim()); 
                                            menuPerfilBLL.incluir(codigo, perfil.CdPerfil);  
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    MessageBox.Show("Perfil atualizado");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //con.ObjCon
                }
            }
        }

        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txCodigo.Text = gridView[0, gridView.CurrentRow.Index].Value.ToString();
            txPerfil.Text = gridView[1, gridView.CurrentRow.Index].Value.ToString();

            Operacao = 2; // Atualização

            getItensMenu();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (Operacao == 2)
            {
                Conexao con = new Conexao(Dados.strConexao);
                PerfilBLL perfil = new PerfilBLL(con);
                perfil.deletar(Convert.ToInt32(txCodigo.Text));
                atualizaGrid();
                MessageBox.Show("Registro apagado!");
                Operacao = 0;
                con.ObjCon.Close();
            }
            else
            {
                MessageBox.Show("Selecione um registro!");
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void getItensMenu() {
            Conexao con = new Conexao(Dados.strConexao);
            MenuBLL objMenu = new MenuBLL(con);
            int idPerfil = Convert.ToInt32(txCodigo.Text);

            DataTable dtMenu = objMenu.listarMenu(0,idPerfil);

            tvMenu.Nodes.Clear();

            tvMenu.BeginUpdate();
            int status = 0;
            string texto = "";
            foreach (DataRow linha in dtMenu.Rows)
            {
                texto = linha["cdMenu"].ToString().PadLeft(3, '0') + " - " + linha["nmMenu"].ToString();
                TreeNode menu = tvMenu.Nodes.Add(linha["cdMenu"].ToString(),texto);
                status = Convert.ToInt32(linha["stMenu"].ToString());
                if (status == 0)
                    menu.Checked = false;
                else
                    menu.Checked = true;

                DataTable dtMenuFilho = objMenu.listarMenu(Convert.ToInt32(linha["cdMenu"].ToString()),idPerfil);
                
                foreach (DataRow linhaFilho in dtMenuFilho.Rows)
                {
                    texto = linhaFilho["cdMenu"].ToString().PadLeft(3, '0') + " - " + linhaFilho["nmMenu"].ToString();
                    TreeNode menuFilho = menu.Nodes.Add(linhaFilho["cdMenu"].ToString(), texto);
                    status = Convert.ToInt32(linhaFilho["stMenu"].ToString());
                    if (status == 0)
                        menuFilho.Checked = false;
                    else
                        menuFilho.Checked = true;

                    DataTable dtMenuNeto = objMenu.listarMenu(Convert.ToInt32(linhaFilho["cdMenu"].ToString()), idPerfil);
                    foreach (DataRow linhaNeto in dtMenuNeto.Rows) {
                        texto = linhaNeto["cdMenu"].ToString().PadLeft(3, '0') + " - " + linhaNeto["nmMenu"].ToString();
                        TreeNode menuNeto = menuFilho.Nodes.Add(linhaNeto["cdMenu"].ToString(), texto);
                        status = Convert.ToInt32(linhaNeto["stMenu"].ToString());
                        if (status == 0)
                            menuNeto.Checked = false;
                        else
                            menuNeto.Checked = true;
                    }
                }

            }

            tvMenu.EndUpdate();

        }

        private void tvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode clickedNode = e.Node;
            if (clickedNode.Checked) {
                if (clickedNode.Nodes.Count > 0) {
                    for (int x = 0; x < clickedNode.Nodes.Count; x++)
                    {
                        TreeNode noFilho = clickedNode.Nodes[x];
                        if (!noFilho.Checked)
                            noFilho.Checked = true;
                        else
                            noFilho.Checked = false;
                    }
                }
            }
        }
    }
}
