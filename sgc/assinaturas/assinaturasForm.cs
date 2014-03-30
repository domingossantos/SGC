using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAO;
using Modelos;
using System.Runtime.InteropServices;

namespace sgc.assinaturas
{
    public partial class assinaturasForm : Form
    {
        private Conexao con;
        private AssinaturasBLL assinaturaBLL;
        private Image imgOriginal;
        private PedidoBLL pedidoBLL;
        private Pedido pedido;
        private int idxItens;
        private Size tamanhoOriginal;
        private Size tamanhoModificado;
        private int imgWidth;
        private int imgHeigth;

        private bool _pesquisaRemota;

        public bool pesquisaRemota {
            get { return _pesquisaRemota;  }
            set { _pesquisaRemota = value;  }
        }

        public assinaturasForm()
        {
            con = new Conexao(Dados.strConexao);
            assinaturaBLL = new AssinaturasBLL(con);
            pedidoBLL = new PedidoBLL(con);
            imgHeigth = 0;
            imgWidth = 0;
            idxItens = 0;
            InitializeComponent();
            pesquisaRemota = false;
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage",CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        private void btPesquisa_Click(object sender, EventArgs e)
        {
            pesquisaRemota = false;
            pesquisaCartao();
        }

        private void carregaImagem(String cartao,int posicao = 0)
        {   
            if (cartao != "")
            {
                MemoryStream ms;
                byte[] imgByte = null;
                imagem.Image = null;

                imgByte = assinaturaBLL.getUltimaAssinatura(cartao, pesquisaRemota);
                if (imgByte != null)
                {
                    try
                    {
                        ms = new MemoryStream(imgByte, 0, imgByte.Length);

                        ms.Write(imgByte, 0, imgByte.Length);
                        imagem.Image = Image.FromStream(ms, true);
                        imgOriginal = imagem.Image;
                        imgWidth = imgOriginal.Width;
                        imgHeigth = imgOriginal.Height;
                        tamanhoOriginal = new Size(imgWidth, imgHeigth);
                    }
                    catch (Exception e)
                    {
                        if (posicao == 0)
                        {
                            imagem.Image = Image.FromFile(utils.sessao.PathApp + "\\erro-img.jpg");
                        }
                    }
                }
                else {
                    if (posicao == 0)
                    {
                        imagem.Image = Image.FromFile(utils.sessao.PathApp + "\\no-img.jpg");
                    }
                }
            }
        }




        private void pesquisaCartao()
        {
            int tipoCons = getTipoConsulta();
            DataTable dados = null;
            imagem.Image = null;
            grid.DataSource = null;

            Refresh();
            
            imagemPesquisa();

            dados = assinaturaBLL.pesquisaCartao(txPesquisa.Text, tipoCons, pesquisaRemota);

            try
            {
                if (dados.Rows.Count > 0 )
                {
                    grid.DataSource = dados;

                    if (tipoCons == 5 || tipoCons == 6)
                    {
                        grid.Columns[0].HeaderText = "FICHA";
                        grid.Columns[0].Width = 60;
                        grid.Columns[1].HeaderText = "NOME";
                        grid.Columns[1].Width = 220;
                        grid.Columns[2].HeaderText = "Cartorio";
                        grid.Columns[2].Width = 150;
                        grid.Columns[3].HeaderText = "Cidade";
                        grid.Columns[3].Width = 70;
                        grid.Columns[4].HeaderText = "Obs";
                        grid.Columns[4].Width = 80;

                        grid.Columns[5].HeaderText = "Cadastro";
                        grid.Columns[5].Width = 70;
                        grid.Columns[6].HeaderText = "Renovação";
                        grid.Columns[6].Width = 70;
                        grid.Columns[7].HeaderText = "CPF";
                        grid.Columns[7].Width = 60;
                    }
                    else
                    {
                        grid.Columns[0].HeaderText = "FICHA";
                        grid.Columns[0].Width = 60;
                        grid.Columns[1].HeaderText = "NOME";
                        grid.Columns[1].Width = 240;
                        grid.Columns[2].HeaderText = "CPF";
                        grid.Columns[2].Width = 80;
                        grid.Columns[3].HeaderText = "Renovação";
                        grid.Columns[3].Width = 70;
                        grid.Columns[4].HeaderText = "Observacao";
                        grid.Columns[4].Width = 70;
                        grid.Columns[5].HeaderText = "Cadastro";
                        grid.Columns[5].Width = 60;


                    }
                    grid.Focus();

                }
                else if (!pesquisaRemota)
                {
                    if (MessageBox.Show("Não há cartão disponível para esta consulta!\nDeseja pesquisar na outra base?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
                    {
                        btOutraBase_Click(null, null);
                    }
                    else
                    {
                        txPesquisa.Focus();
                    }
                }
                else { 
                    MessageBox.Show("Não há cartão disponível para esta consulta!");
                    imagem.Image = null;
                    Refresh();
                }
            }
            catch (SqlException) {
                if (pesquisaRemota)
                {
                    MessageBox.Show("Erro ao consultar a outra base.\nConexão perdida!.");
                }
                else {
                    MessageBox.Show("Erro ao consultar assinatura.\nErro na base de dados!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro na consulta de assinaturas");
            }
            
            
            
        }

        private int getTipoConsulta()
        { 
            int t = 0;

            if (rbNome.Checked)
                t = 1;
            else if (rbCPF.Checked)
                t = 2;
            else if (rbRG.Checked)
                t = 3;
            else if (rbCartao.Checked)
                t = 4;
            else if (rbCidade.Checked)
                t = 5;
            else if (rbCartorio.Checked)
                t = 6;

            return t;
        }

        private char getTipoReconhecimento()
        {
            char r;
            if (rbAutentico.Checked)
                r = '1';
            else if (rbSemelhante.Checked)
                r = '2';
            else if (rbDoc.Checked)
                r = '3';
            else
                r = 'S';

            return r;
        }

        private void assinaturasForm_KeyDown(object sender, KeyEventArgs e)
        {

            //MessageBox.Show(e.KeyCode.ToString());
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D1)
            {
                rbNome.Checked = true;
                limpaCampoPesquisa();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D2)
            {
                rbCPF.Checked = true;
                limpaCampoPesquisa();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D3)
            {
                rbRG.Checked = true;
                limpaCampoPesquisa();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D4)
            {
                rbCartao.Checked = true;
                limpaCampoPesquisa();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D5)
            {
                rbCidade.Checked = true;
                limpaCampoPesquisa();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D6)
            {
                rbCartorio.Checked = true;
                limpaCampoPesquisa();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D8)
            {
                rbAutentico.Checked = true;
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D9)
            {
                rbSemelhante.Checked = true;
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D0)
            {
                rbDoc.Checked = true;
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
            {
                btFecharPedido_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Delete)
            {
                btCancelarPedido_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.I)
            {
                incluiAssinaturaMesa();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                repetirPedido();
            }

            if (e.KeyCode == Keys.Escape)
            {
                limparDados();
            }
            if (e.KeyCode == Keys.F11)
            {
                btZoomIn_Click(null, null);
            }
            if (e.KeyCode == Keys.F12)
            {
                btZoomOut_Click(null, null);
            }
            if (e.KeyCode == Keys.F10)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                cbOperacao.Focus();
            }
            if (e.KeyCode == Keys.Insert)
            {
                btInserirPedido_Click(null, null);
            }
            if (e.KeyCode == Keys.F2)
            {
                detalheAssinaturaForm detalheImg = new detalheAssinaturaForm(imagem.Image);
                detalheImg.Show();
            }
        }

        private void limparDados()
        {
            
            grid.DataSource = null;
            imagem.Image = null;
            txPesquisa.Text = "";
            txPesquisa.Focus();
            carregaAtos();
            lbRenovacao.Text = "00/00/0000";
        }
        private void reiniciaPesquisa() {
            txPesquisa.Text = "";
            txPesquisa.Focus();
            //carregaAtos();
            lbRenovacao.Text = "";
        }


        private void imagemPesquisa() {
            imagem.Image = Image.FromFile(utils.sessao.PathApp + @"\pesquisa.jpg");
            Refresh();
        }

        private void grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            imagemPesquisa();

            try
            {
                carregaImagem(grid[0, grid.CurrentRow.Index].Value.ToString(), e.ColumnIndex);
                int idx = 0;
                int idx2 = 0;

                if (grid[2, grid.CurrentRow.Index].Value.ToString().Equals(""))
                {
                    idx = 2;
                }
                else
                {
                    idx = 3;
                }

                idx2 = 4;
                txObservacao.Text = grid[idx2, grid.CurrentRow.Index].Value.ToString();
                if (!grid[idx, grid.CurrentRow.Index].Value.ToString().Equals(""))
                {
                    lbRenovacao.Text = grid[idx, grid.CurrentRow.Index].Value.ToString().Substring(0, 10);
                }
                else {
                    lbRenovacao.Text = "";
                }

            }
            finally { 
                //aqui
            }
        }

        private void txPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                pesquisaRemota = false;
                pesquisaCartao();
            }
        }

        private void assinaturasForm_Load(object sender, EventArgs e)
        {
            txPesquisa.Focus();
            carregaAtos();

            /*if(utils.sessao.UsuarioSessao.CdSetor != 1){
                btFecharPedido.Enabled = false;
                btCancelarPedido.Enabled = false;
                btInserirPedido.Enabled = false;
            }*/
        }

        public void carregaAtos()
        {
            cbOperacao.DataSource = assinaturaBLL.getAtosAssinatura();

            cbOperacao.ValueMember = "cdAto";
            cbOperacao.DisplayMember = "descricao";
            cbOperacao.Text = "Selecione";
            cbOperacao.SelectedIndex = -1;
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            imagem.Top = (int)(imagem.Top - (imagem.Height * 0.025));
            imagem.Left = (int)(imagem.Left - (imagem.Width * 0.025));
            imagem.Height = (int)(imagem.Height + (imagem.Height * 0.05));
            imagem.Width = (int)(imagem.Width + (imagem.Width * 0.05));
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            imagem.Top = (int)(imagem.Top + (imagem.Height * 0.025));
            imagem.Left = (int)(imagem.Left + (imagem.Width * 0.025));
            imagem.Height = (int)(imagem.Height - (imagem.Height * 0.05));
            imagem.Width = (int)(imagem.Width - (imagem.Width * 0.05));
        }

        private void btInserirPedido_Click(object sender, EventArgs e)
        {
            /*
            if (pedidoBLL.checaExistePedidoAberto(utils.sessao.UsuarioSessao.DsLogin).Rows.Count > 0) {
                MessageBox.Show("Há pedidos em aberto no seu caixa.\nFavor confira esses pedidos para poder abrir outro.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            */

            if (cbOperacao.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma operação");
                cbOperacao.Focus();
                return;
            }


            int qtd = 0;
            String strQtd = "";
            Selo selo = null;
            string nrCartao = "0";

            //checa item do pedido
            /*
            switch (cbOperacao.SelectedValue.ToString())
	        {
                case "62": 
                case "63":
                case "64":
                case "66":
                case "67":
                case "68":
                case "69":
                    strQtd = (Microsoft.VisualBasic.Interaction.InputBox("Quantidade", "Cartorio Conduru", "1", 150, 150));
                    if (strQtd.Equals("") || strQtd.Equals("0"))
                    {
                        MessageBox.Show("Informe uma quantidade");
                        return;
                    }
                    else 
                    {
                        qtd = Convert.ToInt32(strQtd);
                    }
                    break;
                default:

                    qtd = 1;
                    break;
	        }
             */

            AtoOperacao ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbOperacao.SelectedValue));
            if (ato.StRepeticao == 'S')
            {
                strQtd = (Microsoft.VisualBasic.Interaction.InputBox("Quantidade", "Cartorio Conduru", "1", 150, 150));
                if (strQtd.Equals("") || strQtd.Equals("0"))
                {
                    MessageBox.Show("Informe uma quantidade");
                    return;
                }
                else
                {
                    qtd = Convert.ToInt32(strQtd);
                }
            }
            else {
                qtd = 1;
            }

            // Verifica disponivbilidade de selos para a operação
            switch (cbOperacao.SelectedValue.ToString())
            {
                case "60":
                case "61":
                case "62":
                case "66":
                case "67":
                    selo = pedidoBLL.getUltimoSelo(Convert.ToInt32(cbOperacao.SelectedValue.ToString()), utils.sessao.UsuarioSessao.DsLogin);
                    if (selo == null)
                    {
                        MessageBox.Show("Não há selos disponíveis para esta operação!");
                        
                        return;
                    }
                    break;
            }

            // Checar ultimo pedido
            pedido = pedidoBLL.getUltimoPedido(utils.sessao.NrPedido.ToString());
            
            if (pedido == null)
            {
                txPedido.Items.Clear();
                pedido = pedidoBLL.abrePedido(utils.sessao.UsuarioSessao.DsLogin);
                txPedido.Items.Add("No. do Pedido: " + pedido.NrPedido.ToString());
            }
            else
            {
                if (pedido.StPedido.Equals('F') || pedido.StPedido.Equals('C') || pedido.StPedido.Equals('P'))
                {
                    txPedido.Items.Clear();
                    pedido = pedidoBLL.abrePedido(utils.sessao.UsuarioSessao.DsLogin);
                    txPedido.Items.Add("No. do Pedido: " + pedido.NrPedido.ToString());
                }
            }

            if (txPedido.Items.Count == 1)
            {
                txPedido.Items.Add("ATO                                VALOR");
                txPedido.Items.Add("----------------------------------------");
            }
            
            utils.sessao.NrPedido = pedido.NrPedido;

            ItemPedido i = new ItemPedido();

            // inserinfo item do pedido
            for (int x = 0; x < qtd; x++)
            {
                switch (cbOperacao.SelectedValue.ToString())
                {
                    case "60":
                    case "61":
                    case "62":
                    case "66":
                    case "67":
                        selo = pedidoBLL.getUltimoSelo(Convert.ToInt32(cbOperacao.SelectedValue.ToString()),utils.sessao.UsuarioSessao.DsLogin);
                        if (selo == null)
                        {
                            MessageBox.Show("Não há selos disponíveis para esta operação");
                            return;
                        }
                        else
                            pedidoBLL.mudaStatusSelo(selo.NrSelo, selo.CdTipoSelo, 'R');
                        break;
                    default:
                        selo = new Selo();
                        selo.NrSelo = 0;
                        selo.CdTipoSelo = 0;

                        break;

                }
                i.CdAto = Convert.ToInt32(cbOperacao.SelectedValue.ToString());
                i.NrPedido = pedido.NrPedido;
                i.NrSelo = selo.NrSelo;
                i.CdTipoSelo = selo.CdTipoSelo;
                i.TpReconhecimento = getTipoReconhecimento();
                //AtoOperacao ato = pedidoBLL.getAtoOperacao(Convert.ToInt32(cbOperacao.SelectedValue.ToString()));
                i.VlItem = ato.VlAto;

                if (grid.RowCount > 0)
                {
                    nrCartao = grid[0, grid.CurrentRow.Index].Value.ToString();
                    //txPedido.Items.Add(pedidoBLL.getCartao(nrCartao).NmCartao);
                    txPedido.Items.Add(grid[1, grid.CurrentRow.Index].Value.ToString());
                }
                i.NrCartao = nrCartao;

                pedidoBLL.addItemPedido(i);
                
                txPedido.Items.Add(utils.formatos.formataLinhaImpressao(ato.DsAto, ato.VlAto,40));

                if (i.NrSelo != 0)
                    txPedido.Items.Add("No. Selo: "+i.NrSelo.ToString().PadLeft(8,'0')+ " Serie "+pedidoBLL.getSerieSelo(selo.CdTipoSelo));
            }

            // constante para a mensagem WM_VSCROLL
            const uint WM_VSCROLL = 0x115;
            // constante para o parâmetro wParam
            const int SB_BOTTOM = 7;

            // handle para a caixa de texto
            IntPtr handle = txPedido.Handle;
            IntPtr wParam = (IntPtr)SB_BOTTOM;
            IntPtr lParam = IntPtr.Zero;

            // vamos fazer com que o TextBox role para o fundo (parte inferior)
            SendMessage(txPedido.Handle, WM_VSCROLL, wParam, lParam);
            reiniciaPesquisa();
            
        }

        private void btFecharPedido_Click(object sender, EventArgs e)
        {
            double valor = pedidoBLL.fechaPedido(utils.sessao.NrPedido);

            resumoPedidoFechado(utils.sessao.NrPedido);
            limparDados();
            Clipboard.SetText(utils.sessao.NrPedido.ToString());
            //utils.sessao.NrPedido = 0;
            /*
            if (utils.sessao.UsuarioSessao.CdSetor != 2 )
            {
                string nrFicha = (Microsoft.VisualBasic.Interaction.InputBox("Digite o nº da Ficha", "Cartorio Conduru", "0", 150, 150));
                pedidoBLL.imprimePedidoEscritura(
                        utils.sessao.NrPedido.ToString(),
                        nrFicha,
                        String.Format("{0:N2}", valor),
                        utils.sessao.PathIniFile
                    );
                MessageBox.Show("Pedido impresso!");
            }
             * */
        }

        private void resumoPedidoFechado(int nrPedido)
        {
            txPedido.Items.Clear();
            txPedido.Items.Add("No. do Pedido: " + nrPedido.ToString());
            txPedido.Items.Add("----------------------------------------");
            txPedido.Items.Add("QTQ Descricao                   Valor");
            txPedido.Items.Add("----------------------------------------");

            List<int> lPedidos = new List<int>();
            lPedidos.Add(nrPedido);
            DataTable dados = pedidoBLL.getItensPedidosImpressao(lPedidos);

            DataView dvDados = new DataView(dados);
            DataRow drDados;
            double valor = 0;
            string linha = "";
            for (int x = 0; x < dvDados.Count; x++)
            {
                drDados = dvDados[x].Row;

                linha = drDados[0].ToString().PadLeft(3, '0') + " " + drDados[1].ToString().PadRight(28, ' ') + String.Format("{0:N2}", drDados[3]).PadLeft(8,' ');
                txPedido.Items.Add(linha);

                valor += Convert.ToDouble(drDados[3].ToString());
            }
            txPedido.Items.Add("----------------------------------------");
            txPedido.Items.Add("Total: "+ String.Format("{0:N2}", valor).PadLeft(33,' '));
            
            DataTable vSelos = pedidoBLL.getIntervaloSelos(utils.sessao.UsuarioSessao.DsLogin);
            DataView dvSelos = new DataView(vSelos);
            DataRow drSelos;
            txPedido.Items.Add("----------------------------------------");
            txPedido.Items.Add("Selos Disponível");
            for (int i = 0; i < dvSelos.Count; i++)
			{
                drSelos = dvSelos[i].Row;

			    txPedido.Items.Add(drSelos[0].ToString());
                txPedido.Items.Add(" Inicio: " + drSelos[1].ToString().PadRight(10, ' ') + " Fim: " + drSelos[2].ToString().PadRight(10, ' ') + " Disponivel: " + drSelos[3].ToString().PadRight(6, ' '));
			}
            // constante para a mensagem WM_VSCROLL
            const uint WM_VSCROLL = 0x115;
            // constante para o parâmetro wParam
            const int SB_BOTTOM = 7;

            // handle para a caixa de texto
            IntPtr handle = txPedido.Handle;
            IntPtr wParam = (IntPtr)SB_BOTTOM;
            IntPtr lParam = IntPtr.Zero;

            // vamos fazer com que o TextBox role para o fundo (parte inferior)
            SendMessage(txPedido.Handle, WM_VSCROLL, wParam, lParam);

        }

        private void assinaturasForm_Shown(object sender, EventArgs e)
        {
            txPesquisa.Focus();
        }

        private void btCancelarPedido_Click(object sender, EventArgs e)
        {
            pedido = pedidoBLL.getUltimoPedido(utils.sessao.NrPedido.ToString());

            switch (pedido.StPedido)
	        {
                case 'F':
                    MessageBox.Show("Pedido já fechado. Não é possivel cancelar.");
                    break;
                case 'C':
                    MessageBox.Show("Pedifo já cancelado.");
                    break;
                case 'A':
                    pedidoBLL.cancelaPedido(utils.sessao.NrPedido,pedido.VlPedido,utils.sessao.UsuarioSessao.DsLogin);

                    MessageBox.Show("Pedido Cancelado!\nTodos os selos usados foram devolvidos.");
                    //limparDados();
                    txPesquisa.Focus();
                    txPedido.Items.Clear();
                    break;
		
	        }    
         }

        private void assinaturasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void incluiAssinaturaMesa()
        {
            if (grid.RowCount > 0)
            {
                assinaturaBLL.salvaAssinaturaMesa(utils.sessao.UsuarioSessao.DsLogin, grid[0, grid.CurrentRow.Index].Value.ToString());
                MessageBox.Show("Assinatura adicionada a mesa");
            }
            else
            {
                MessageBox.Show("Realize uma pesquisa para adicionar uma assinatura a mesa");
            }


        }

        private void repetirPedido()
        {
            try
            {
                pedido = pedidoBLL.getUltimoPedido(utils.sessao.NrPedido.ToString());
                int nrPedido = 0;
                if (pedido.StPedido.Equals('A'))
                {
                    MessageBox.Show("Feche o pedido antes de repeti-lo!");
                    return;
                }
                else if (pedido.StPedido.Equals('C'))
                {
                    MessageBox.Show("Pedido cancelado. este não pode ser repetido!");
                    return;
                }
                else if (pedido.StPedido.Equals('F'))
                {

                    int Qtd = Convert.ToInt32((Microsoft.VisualBasic.Interaction.InputBox("Número de Repetições", "Cartorio Conduru", "0", 150, 150)));

                    if (Qtd > 0)
                    {
                        nrPedido = pedidoBLL.repetirPedido(pedido.NrPedido, utils.sessao.UsuarioSessao.DsLogin, Qtd);
                    }
                }
                utils.sessao.NrPedido = nrPedido;
                btFecharPedido_Click(null, null);


            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao repetir pedido\n" + e.Message);
            }
            
        }

        public void limpaCampoPesquisa() {
            //txPesquisa.Text = "";
            txPesquisa.Focus();
        }
        private void rbNome_Click(object sender, EventArgs e)
        {
            limpaCampoPesquisa();
        }

        private void rbCPF_Click(object sender, EventArgs e)
        {
            limpaCampoPesquisa();
        }

        private void rbRG_Click(object sender, EventArgs e)
        {
            limpaCampoPesquisa();
        }

        private void rbCartao_Click(object sender, EventArgs e)
        {
            limpaCampoPesquisa();
        }

        private void rbCidade_Click(object sender, EventArgs e)
        {
            limpaCampoPesquisa();
        }

        private void rbCartorio_Click(object sender, EventArgs e)
        {
            limpaCampoPesquisa();
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            CartaoAssinatura cartao = assinaturaBLL.getCartao(grid[0, grid.CurrentRow.Index].Value.ToString());

            detalheCartaoAssinaturaForm detalheCartao = new detalheCartaoAssinaturaForm(cartao);
            detalheCartao.Show();
        }

        private void btOutraBase_Click(object sender, EventArgs e)
        {
            pesquisaRemota = true;
            pesquisaCartao();
        }

    }
}
