using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sgc.utils;
using BLL;
using DAO;
using Modelos;
using System.IO;


namespace sgc.processos
{
    public partial class pedidoProcesso : Form
    {
        public PedidoBLL pedidoBLL;
        public Conexao c;
        private TipoDocumento tipo;
        public pedidoProcesso()
        {
            InitializeComponent();
            c = new Conexao(Dados.strConexao);
            pedidoBLL = new PedidoBLL(c);
        }

        private void pedidoProcesso_Load(object sender, EventArgs e)
        {
            try
            {
                carregaItens();
                carregaAtos();

                lbTipo.Text = pedidoBLL.getTipoDocumento(sessao.Processo.CdTipoDocumento).NmTipoDocumento;

                lbNumProcesso.Text = sessao.Processo.NrProceso.ToString();

                lbNulPedido.Text = sessao.NrPedido.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregaAtos()
        {
            cbItem.DataSource = pedidoBLL.getOperacoesProcuracao();
            cbItem.DisplayMember = "dsAto";
            cbItem.ValueMember = "cdAto";

            AtoOperacao ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbItem.SelectedValue.ToString()));
            txValorUnt.Text = getValorAto(ato, sessao.ItemPedido.VlItem).ToString();

        }

        private void carregaItens()
        {
            DataTable dados = pedidoBLL.getItensPedidosEscritura(sessao.NrPedido);
            
            grid.DataSource = dados;

            grid.Columns[0].Width = 60;
            grid.Columns[0].HeaderText = "Nº";
            grid.Columns[1].Width = 240;
            grid.Columns[1].HeaderText = "ATO";
            grid.Columns[2].Width = 80;
            grid.Columns[2].HeaderText = "Nº Selo";
            grid.Columns[3].Width = 130;
            grid.Columns[3].HeaderText = "Tipo Selo";
            grid.Columns[4].Width = 100;
            grid.Columns[4].HeaderText = "Valor";
            grid.Columns[4].DefaultCellStyle.Format = "c";

            lbValorTotal.Text = String.Format("{0:N2}", utils.formatos.getSomaCampoGrid(grid, 4));
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbItem.SelectedValue.ToString().Length <= 4)
            {

                AtoOperacao ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbItem.SelectedValue.ToString()));

                txValorUnt.Text = getValorAto(ato, sessao.ItemPedido.VlItem).ToString();

                lbValorItem.Text = getValorTotalItem(Convert.ToDouble(txValorUnt.Text), Convert.ToInt32(txQtd.Text)).ToString();
            }
            
        }

        private double getValorTotalItem(double valor, int qtd)
        {
            return valor * qtd;
        }
        
        private double getValorAto(AtoOperacao ato,double valor)
        {
            double vl = 0;

            if (ato.VlAto == 0)
                vl = (valor * ato.VlPercentual) / 100;
            else
                vl = ato.VlAto;

            return vl;
        }

        private void txValorUnt_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btSalvaItem_Click(object sender, EventArgs e)
        {
            
            if (validaItem())
            {
                try
                {
                    AtoOperacao ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbItem.SelectedValue.ToString()));

                    ItemPedido i = new ItemPedido();


                    if (ato.CdTJAto.TrimEnd().TrimStart().Equals("61") ||
                        ato.CdTJAto.TrimEnd().TrimStart().Equals("62") ||
                        ato.CdTJAto.TrimEnd().TrimStart().Equals("63"))
                    {



                        for (int x = 0; x < Convert.ToInt16(txQtd.Text); x++)
                        {
                            Selo selo = pedidoBLL.getUltimoSelo(Convert.ToInt32(cbItem.SelectedValue.ToString()),
                                                            utils.sessao.UsuarioSessao.DsLogin);

                            if (selo == null)
                            {
                                MessageBox.Show("Não há selos disponíveis para esta operação!");
                                return;
                            }
                            else
                            {
                                pedidoBLL.mudaStatusSelo(selo.NrSelo, selo.CdTipoSelo, 'R');
                                i.NrSelo = selo.NrSelo;
                                i.CdTipoSelo = selo.CdTipoSelo;
                                i.CdAto = ato.CdAto;
                                i.VlItem = ato.VlAto;
                                i.NrPedido = sessao.NrPedido;
                                i.NrProcesso = sessao.Processo.NrProceso;

                                pedidoBLL.gravaItemPedido(i);

                                selo = null;
                            }
                        }

                    }
                    else
                    {
                        i.CdAto = ato.CdAto;
                        i.VlItem = Convert.ToDouble(lbValorItem.Text);
                        i.NrPedido = sessao.NrPedido;
                        i.NrProcesso = sessao.Processo.NrProceso;
                        pedidoBLL.gravaItemPedido(i);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro ao inserir pedido.\n"+ex.Message);
                }
                carregaItens();
            }
        }

        private bool validaItem()
        {
            bool r = true;
            if (txQtd.Text.Equals(""))
            {
                MessageBox.Show("Informe a quantidade");
                r = false;
            }

            if (txValorUnt.Text.Equals(""))
            {
                MessageBox.Show("Informe o valor unitário");
                r = false;
            }

            return r;
        }

        private void txQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txQtd_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txQtd_KeyUp(object sender, KeyEventArgs e)
        {
            int qtd;
            if (txQtd.Text.Equals(""))
                qtd = 0;
            else
                qtd = Convert.ToInt32(txQtd.Text);
            lbValorItem.Text = getValorTotalItem(Convert.ToDouble(txValorUnt.Text), qtd).ToString();
        }

        private void btGrava_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja fechar esse pedido?", "Fechar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.ToString().Equals("Yes"))
            {
                try
                {
                    pedidoBLL.fechaPedido(sessao.NrPedido);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fechar pedido:\n" + ex.Message);
                }
                try
                {
                    
                    
                    pedidoBLL.imprimePedidoEscritura(sessao.NrPedido.ToString(),"0", lbValorTotal.Text, sessao.PathIniFile);
                    MessageBox.Show("Pedido Fechado.\nImprimindo Pedido.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao imprimir pedido:\n"+ex.Message);
                }

            }
        }

        public void imprimePedido(string nrPedido,string valor) 
        {
            MatrixReporter.Reporter imp = new MatrixReporter.Reporter();

            utils.IniFile iniFile = new utils.IniFile(sessao.PathIniFile);

            bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

            if (arquivo)
            {
                if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA")))
                {
                    File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA"));
                }
            }


            imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRESSORA");
            imp.StartJob();
            imp.PrintText(1, 1, iniFile.IniReadValue("HBOLETO", "LINHA1"));
            imp.PrintText(2, 1, iniFile.IniReadValue("HBOLETO", "LINHA2"));
            imp.PrintText(3, 1, iniFile.IniReadValue("HBOLETO", "LINHA3"));
            imp.PrintText(4, 1, iniFile.IniReadValue("HBOLETO", "LINHA4"));
            imp.PrintText(5, 1, iniFile.IniReadValue("HBOLETO", "LINHA5"));
            imp.PrintText(6, 1, "################### PEDIDO ####################");
            imp.PrintText(7, 1, "No. PEDIDO:......................"+nrPedido.PadLeft(14,' '));
            imp.PrintText(8, 1, "Valor PEDIDO:...................." + String.Format("{0:N2}", valor).PadLeft(14,' '));
            imp.PrintText(9, 1, "#################### ITENS ####################");
            
            imp.PrintText(5, 1, iniFile.IniReadValue("FBOLETO", "LINHA1"));

            int qtdLinhas = Convert.ToInt32(iniFile.IniReadValue("FBOLETO", "QTDFIM"));
            int x = 5;
            for (int i = 0; i < qtdLinhas; i++)
            {
                imp.PrintText(x++, 1, "");
            }

            imp.PrintJob();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pedidoProcesso_Shown(object sender, EventArgs e)
        {
            
        }

        private void btDelataItem_Click(object sender, EventArgs e)
        {
            try
            {
                int idItem = Convert.ToInt32(grid[0, grid.CurrentRow.Index].Value.ToString());
                pedidoBLL.delItemPedido(idItem);
                MessageBox.Show("Pedido apagado");
                carregaItens();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao apagar Item\n"+ex.Message);
            }
        }
    }
}
