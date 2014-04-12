using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using DAO;
using BLL;

namespace sgc.controleSelos
{
    public partial class tipoSeloForm : sgc.modeloForm
    {
        private Conexao con;
        private TipoSelo tipoSelo;
        private TipoSeloBLL tipoSeloBLL;
        private TipoDocumentoDAO tipoDocDAO;
        private string str;
        private short op = 0;

        public tipoSeloForm()
        {
            con = new Conexao(Dados.strConexao);
            tipoSelo = new TipoSelo();
            tipoSeloBLL = new TipoSeloBLL(con);
            tipoDocDAO = new TipoDocumentoDAO(con.ObjCon);
            InitializeComponent();
        }

        private void tipoSeloForm_Load(object sender, EventArgs e)
        {
            carregaTipoDoc();
            listaTipoSelo();
        }

        private void carregaTipoDoc()
        {
            con.ObjCon.Open();
            cbTipoDoc.DataSource = tipoDocDAO.getTiposDocumentos();
            cbTipoDoc.ValueMember = "cdTipoDocumento";
            cbTipoDoc.DisplayMember = "nmTipoDocumento";
            cbTipoDoc.Text = "Selecione...";
            con.ObjCon.Close();
        }

        private void listaTipoSelo()
        {
            grid.DataSource = tipoSeloBLL.getTipoSelo();

            grid.Columns[0].HeaderText = "#";
            grid.Columns[0].Width = 30;
            grid.Columns[1].HeaderText = "Série";
            grid.Columns[1].Width = 50;
            grid.Columns[2].HeaderText = "Descrição";
            grid.Columns[2].Width = 200;
            grid.Columns[3].HeaderText = "Valor";
            grid.Columns[3].Width = 50;
            grid.Columns[4].HeaderText = "Tipo Documento";
            grid.Columns[4].Width = 200;
            grid.Columns[5].HeaderText = "Gatuito";
            grid.Columns[5].Width = 60;
             


        }
        private bool IsNumeric(int Val)
        {
            return (((Val >= 48 && Val <= 57) || (Val >= 96 && Val <= 105)) || (Val == 8) || (Val == 46));
        }
        private int setKeyCode(int i)
        {
            int n = 0;
            switch (i)
            {
                case 96:
                    n = 48;
                    break;
                case 97:
                    n = 49;
                    break;
                case 98:
                    n = 50;
                    break;
                case 99:
                    n = 51;
                    break;
                case 100:
                    n = 52;
                    break;
                case 101:
                    n = 53;
                    break;
                case 102:
                    n = 54;
                    break;
                case 103:
                    n = 55;
                    break;
                case 104:
                    n = 56;
                    break;
                case 105:
                    n = 57;
                    break;
                default:
                    n = i;
                    break;
            }
            return n;
        }
        private void txValor_KeyDown(object sender, KeyEventArgs e)
        {
            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode))
            {
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = true;
            }

            if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else if (!((KeyCode == 8) || (KeyCode == 46)))
            {
                if (KeyCode >= 96 && KeyCode <= 105)
                    KeyCode = setKeyCode(KeyCode);

                str = str + Convert.ToChar(KeyCode);
            }

            if (str.Length == 0)
            {
                txValor.Text = "";
            }
            if (str.Length == 1)
            {
                txValor.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txValor.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txValor.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
        }
        
        private void txValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void limpaCampos() {
            carregaTipoDoc();
            lbCodigo.Text = "0";
            txSerie.Text = "";
            txDescricao.Text = "";
            txValor.Text = "";
            str = "";
        }

        public char getGratuidade() { 
            char retorno = 'N';
            if (ckGratuito.Checked) {
                retorno = 'S';
            }

            return retorno;
        }


        public void setGratuidade(char status) {
            
            if (status.Equals('S'))
            {
                ckGratuito.Checked = true;
            }
            else
            {
                ckGratuito.Checked = false;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cbTipoDoc.Focus();
            limpaCampos();
            op = 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbTipoDoc.SelectedValue == null)
            {
                MessageBox.Show("Selecione um Tipo de Documento");
                cbTipoDoc.Focus();
                return;
            }

            if (txSerie.Text.Equals(""))
            {
                MessageBox.Show("Informe a Série do Selo");
                txSerie.Focus();
                return;
            }
            if (txDescricao.Text.Equals(""))
            {
                MessageBox.Show("Informe a Descrição do Selo");
                txDescricao.Focus();
                return;
            }
            if (txValor.Text.Equals(""))
            {
                MessageBox.Show("Informe o Valor do Selo");
                txValor.Focus();
                return;
            }

            if (op == 1) {
                tipoSelo.CdTipoDocumento = Convert.ToInt32( cbTipoDoc.SelectedValue.ToString());
                tipoSelo.DsTipoSelo = txDescricao.Text;
                tipoSelo.NrSerie = txSerie.Text;
                tipoSelo.VlSelo = Convert.ToDouble(txValor.Text);
                tipoSelo.StTipoSelo = getGratuidade();

                tipoSeloBLL.addTipoSelo(tipoSelo);
                MessageBox.Show("Registro salvo");
                listaTipoSelo();
                limpaCampos();
                op = 0;
            }

            if (op == 2)
            {


                tipoSelo.CdTipoDocumento = Convert.ToInt32(cbTipoDoc.SelectedValue.ToString());
                tipoSelo.DsTipoSelo = txDescricao.Text;
                tipoSelo.NrSerie = txSerie.Text;
                tipoSelo.VlSelo = Convert.ToDouble(txValor.Text);
                tipoSelo.CdTipoSelo = Convert.ToInt32(lbCodigo.Text);
                tipoSelo.StTipoSelo = getGratuidade();

                tipoSeloBLL.saveTipoSelo(tipoSelo);
                MessageBox.Show("Registro salvo");
                listaTipoSelo();
                limpaCampos();
                op = 0;
            }

        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tipoSelo = tipoSeloBLL.getTipoSelo(Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value.ToString()));

            lbCodigo.Text = tipoSelo.CdTipoSelo.ToString();
            txSerie.Text = tipoSelo.NrSerie;
            txDescricao.Text = tipoSelo.DsTipoSelo;
            txValor.Text = tipoSelo.VlSelo.ToString();
            cbTipoDoc.SelectedValue = Convert.ToString(tipoSelo.CdTipoDocumento);
            setGratuidade(tipoSelo.StTipoSelo);
            

            op = 2;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (lbCodigo.Text.Equals("0")) {
                MessageBox.Show("Selecione um Tipo de Selo");
                return;
            }

            if (op == 2) {

                tipoSeloBLL.delTipoSelo(Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value.ToString()));
                MessageBox.Show("Registro apagado!");
                listaTipoSelo();
                limpaCampos();
                op = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            op = 0;
        }
    }
}
