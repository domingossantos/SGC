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

namespace sgc.admin
{
    public partial class CancelaSeloForm : Form
    {
        private Conexao con;
        private SelosBLL seloBll;

        public CancelaSeloForm()
        {
            con = new Conexao(Dados.strConexao);
            seloBll = new SelosBLL(con);
            InitializeComponent();
        }

        public void getTipoSelo() 
        {
            cmbTipoSelo.DataSource = seloBll.getTipoSelos();
            cmbTipoSelo.ValueMember = "cdTipoSelo";
            cmbTipoSelo.DisplayMember = "dsTipoSelo";
        }

        private void CancelaSeloForm_Load(object sender, EventArgs e)
        {
            getTipoSelo();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            int inicio = 0;
            int fim = 0;
            int tipo = Convert.ToInt32(cmbTipoSelo.SelectedValue.ToString());

            if(txInicio.Text.Equals("")){
                utils.MessagensExcept.funMsgSistema("O Campo selo inicial é obrigatório",3);
                txInicio.Focus();
                return;
            } else {
                try{
                inicio = Convert.ToInt32(txInicio.Text);
                }
                catch(Exception ex){
                    utils.MessagensExcept.funMsgSistema("O Campo Selo deve ser somente numeros!\n"+ex.Message,1);
                    return;
                }
            }

            try {
                if (txFim.Text.Equals("")) {
                    txFim.Text = txInicio.Text;
                }

                fim = Convert.ToInt32(txFim.Text);
            }
            catch(Exception ex){
                utils.MessagensExcept.funMsgSistema("O Campo Selo deve ser somente numeros!\n"+ex.Message,1);
                txFim.Focus();
                return;
            }


            grid.DataSource = seloBll.getSelos(inicio,fim, tipo);

            if (grid.RowCount <= 1) {
                utils.MessagensExcept.funMsgSistema("Não há dados para o intervalo informado", 3);
                grid.DataSource = null;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja cancelar selos?", "Confirmação",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String nrSelo = ""; ;
                int tipo = Convert.ToInt32(cmbTipoSelo.SelectedValue.ToString());
                if (grid.RowCount > 1)
                {
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {

                        nrSelo = grid[0, i].Value.ToString();

                        seloBll.mudaStatusSelo(Convert.ToInt32(nrSelo), tipo, 'C');
                    }
                    utils.MessagensExcept.funMsgSistema("Selos Cancelados!", 3);
                }
                else
                {
                    utils.MessagensExcept.funMsgSistema("Não há selos para cancelar!", 3);
                }

            }
            else {
                utils.MessagensExcept.funMsgSistema("Operação cancelada!", 3);
            }

        }

        private void brRestaurar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja restaurar selos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                String nrSelo = ""; ;
                int tipo = Convert.ToInt32(cmbTipoSelo.SelectedValue.ToString());
                if (grid.RowCount > 1)
                {
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {

                        nrSelo = grid[0, i].Value.ToString();

                        seloBll.mudaStatusSelo(Convert.ToInt32(nrSelo), tipo, 'D');
                    }
                    utils.MessagensExcept.funMsgSistema("Selos Restaurados!", 3);
                }
                else
                {
                    utils.MessagensExcept.funMsgSistema("Não há selos para restaurar!", 3);
                }
            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Operação cancelada!", 3);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja marcar selos como usado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String nrSelo = ""; ;
                int tipo = Convert.ToInt32(cmbTipoSelo.SelectedValue.ToString());
                if (grid.RowCount > 1)
                {
                    for (int i = 0; i < grid.RowCount - 1; i++)
                    {

                        nrSelo = grid[0, i].Value.ToString();

                        seloBll.mudaStatusSelo(Convert.ToInt32(nrSelo), tipo, 'U');
                    }
                    utils.MessagensExcept.funMsgSistema("Selos marcados como usados!", 3);
                }
                else
                {
                    utils.MessagensExcept.funMsgSistema("Não há selos para marcar!", 3);
                }

            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Operação cancelada!", 3);
            }
        }
    }
}
