using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using DAO;
using BLL;


namespace sgc.controleSelos
{
    public partial class selosForm : Form
    {
        private Conexao con;
        private Selo selo;
        private SelosBLL seloBLL;
        private TipoSeloDAO tipoSeloDAO;
        private UsuarioDAO usuarioDAO;
        private LocaisCartorioDAO locaisCartorioDAO;
        
        public selosForm()
        {
            con = new Conexao(Dados.strConexao);
            selo = new Selo();
            seloBLL = new SelosBLL(con);
            tipoSeloDAO = new TipoSeloDAO(con.ObjCon);
            usuarioDAO = new UsuarioDAO(con.ObjCon);
            locaisCartorioDAO = new LocaisCartorioDAO(con.ObjCon);
            InitializeComponent();
        }

        private void selosForm_Load(object sender, EventArgs e)
        {
            listaTipoSelos();
            listaUsuarios();
            listaLocaisCartorio();
            //atualizaGrid();
        }

        private void listaUsuarios()
        {
            con.ObjCon.Open();
            cbUsuario.DataSource = usuarioDAO.getUsuarios();
            cbUsuario.ValueMember = "dsLogin";
            cbUsuario.DisplayMember = "nmUsuario";
            cbUsuario.Text = "Selecione...";
            con.ObjCon.Close();
        }

        private void listaTipoSelos()
        {
            con.ObjCon.Open();
            cbTipoSelo.DataSource = tipoSeloDAO.getTipoSelos();
            cbTipoSelo.ValueMember = "cdTipoSelo";
            cbTipoSelo.DisplayMember = "dsTipoSelo";
            cbTipoSelo.Text = "Selecione...";
            cbTipoSelo.SelectedIndex = -1;
            con.ObjCon.Close();
        }

        private void listaLocaisCartorio()
        {
            con.ObjCon.Open();
            cbDestino.DataSource = locaisCartorioDAO.getLocaisCartorio();
            cbDestino.ValueMember = "cdLocalCartorio";
            cbDestino.DisplayMember = "dsLocalCartorio";
            cbDestino.Text = "Selecione...";
            con.ObjCon.Close();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (txSeqInicio.Text.Equals(""))
            {
                MessageBox.Show("Informe número inicial da sequencia");
                txSeqInicio.Focus();
                return;
            }

            if (txSeqFinal.Text.Equals(""))
            {
                MessageBox.Show("Informe número final da sequencia");
                txSeqFinal.Focus();
                return;
            }
            if (cbTipoSelo.SelectedValue == null)
            {
                MessageBox.Show("Informe Tipo de Selo!");
                cbTipoSelo.Focus();
                return;
            }
            
            
            try
            {
                grid.DataSource = seloBLL.getSelos(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()));

                grid.Columns[0].HeaderText = "No. Selo";
                grid.Columns[0].Width =80;
                grid.Columns[1].HeaderText = "Data Lançamento";
                grid.Columns[1].Width = 100;
                grid.Columns[2].HeaderText = "Status";
                grid.Columns[2].Width = 50;
                grid.Columns[3].HeaderText = "Tipo Selo";
                grid.Columns[3].Width = 170;
                grid.Columns[4].HeaderText = "Atribuido em";
                grid.Columns[4].Width = 100;
                grid.Columns[5].HeaderText = "Usuário";
                grid.Columns[5].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar selos: "+ex.Message);
            }
            
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                seloBLL.incluir(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()));
                MessageBox.Show("Selos Registrados");
                btPesquisar_Click(sender,e);
                //atualizaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Registrat selos.\n"+ex.Message);
            }
        }

        private void txSeqInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }


        public void atualizaGrid()
        {
            grid.DataSource = seloBLL.getSelos();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            panelAtribuir.Visible = false;
            setAtividade(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panelTranferencia.Visible == true)
                panelTranferencia.Visible = false;

            panelAtribuir.Visible = true;
            setAtividade(1);
        }

        private void btCancelarTransf_Click(object sender, EventArgs e)
        {
            panelTranferencia.Visible = false;
            setAtividade(2);
        }

        private void btTransferir_Click(object sender, EventArgs e)
        {
            
            if (panelAtribuir.Visible == true)
                panelAtribuir.Visible = false;

            panelTranferencia.Visible = true;
            setAtividade(1);
        }

        // Atribui
        private void setAtividade(sbyte op)
        {
            if (op == 1)
            {
                panel1.Enabled = false;
                grid.Enabled = false;
            }
            
            if (op == 2)
            {
                panel1.Enabled = true;
                grid.Enabled = true;
            }
        }

        private void btGravarAtribuicao_Click(object sender, EventArgs e)
        {
            try
            {
                if (seloBLL.checaStatusSelos(seloBLL.getSelos(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()))))
                {
                    MessageBox.Show("Existe selos já Atribuidos, Usados ou Transferidos neste intervalo\nVerifique antes de tentar utilizá-los!");
                }
                else
                {
                    seloBLL.setSelosUsuario(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), cbUsuario.SelectedValue.ToString(), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()));
                    btPesquisar_Click(sender, e);
                    MessageBox.Show("Selos atribuidos com sucesso!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atribuir selos "+ ex.Message);
            }
            finally
            {
                panelAtribuir.Visible = false;
                setAtividade(2);
            }
        }

        private void btGravarTransf_Click(object sender, EventArgs e)
        {
            if (cbDestino.SelectedValue.ToString().Equals(""))
            {
                MessageBox.Show("Selecione um local de destino dos selos!");
            }
            else if (seloBLL.checaStatusSelos(seloBLL.getSelos(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()))))
            {
                MessageBox.Show("Existe selos Transferidos ou Usados neste intervalo.");
            }
            else
            {
                try
                {
                    seloBLL.transfereSelos(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()), Convert.ToInt32(cbDestino.SelectedValue.ToString()));
                    MessageBox.Show("Selos transferidos");
                    btPesquisar_Click(sender, e);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    panelTranferencia.Visible = false;
                    setAtividade(2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grid.DataSource = null;
            txSeqFinal.Text = "";
            txSeqInicio.Text = "";
            txSeqInicio.Focus();
        }

        private void brApagarSelo_Click(object sender, EventArgs e)
        {
            if (seloBLL.checaStatusSelos(seloBLL.getSelos(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()))))
            {
                MessageBox.Show("Existe selos já Atribuidos, Usados ou Transferidos neste intervalo\nVerifique antes de tentar apaga-los!");
            }
            else
            {
                DialogResult dlgR = MessageBox.Show("Deseja apagar estes selos?", "Cartorio Conduru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgR.ToString().Equals("Yes"))
                {
                    try
                    {
                        seloBLL.apagaSelos(Convert.ToInt32(txSeqInicio.Text), Convert.ToInt32(txSeqFinal.Text), Convert.ToInt32(cbTipoSelo.SelectedValue.ToString()));
                        btPesquisar_Click(null, null);
                        MessageBox.Show("Selos Apagados!");
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
    }
}
