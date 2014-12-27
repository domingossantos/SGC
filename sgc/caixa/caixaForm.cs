using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sgc.utils;
using Modelos;
using DAO;
using BLL;
using MatrixReporter;
using System.Runtime.InteropServices;
using System.IO;

namespace sgc.caixa
{
    public partial class caixaForm : Form
    {
        public string str;
        private PedidoBLL pedidoBLL;
        private CaixaBLL caixaBLL;
        private EscrituraBLL escrituraBLL;
        private Conexao con;
        private Pedido oPedido;
        private double valor = 0;
        private Reporter impressora;
        private EpsonCodes pc;
        private string dsLoginDesconto;
        private UsuarioBLL usuarioBLL;
        private char stDesconto = 'N';


        // Importar DLL da Impressora de Etiquetas
        const uint IMAGE_BITMAP = 0;
        const uint LR_LOADFROMFILE = 16;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType,
           int cxDesired, int cyDesired, uint fuLoad);
        [DllImport("Gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int DeleteObject(IntPtr ho);
        const string szSavePath = "C:\\Argox";
        const string szSaveFile = "C:\\Argox\\PPLA_Example.Prn";
        const string sznop1 = "nop_front\r\n";
        const string sznop2 = "nop_middle\r\n";
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_Maxi(int x, int y, int primary, int secondary,
            int country, int service, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_Maxi_Ori(int x, int y, int ori, int primary,
            int secondary, int country, int service, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_PDF417(int x, int y, int narrow, int width, char normal,
            int security, int aspect, int row, int column, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_PDF417_Ori(int x, int y, int ori, int narrow, int width,
            char normal, int security, int aspect, int row, int column, char mode, int numeric,
            string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_DataMatrix(int x, int y, int rotation, int hor_mul,
            int ver_mul, int ECC, int data_format, int num_rows, int num_col, char mode,
            int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern void A_Clear_Memory();
        [DllImport("Winppla.dll")]
        private static extern void A_ClosePrn();
        [DllImport("Winppla.dll")]
        private static extern int A_CreatePrn(int selection, string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Del_Graphic(int mem_mode, string graphic);
        [DllImport("Winppla.dll")]
        private static extern int A_Draw_Box(char mode, int x, int y, int width, int height,
            int top, int side);
        [DllImport("Winppla.dll")]
        private static extern int A_Draw_Line(char mode, int x, int y, int width, int height);
        [DllImport("Winppla.dll")]
        private static extern void A_Feed_Label();
        [DllImport("Winppla.dll")]
        private static extern IntPtr A_Get_DLL_Version(int nShowMessage);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_DLL_VersionA(int nShowMessage);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_Graphic(int x, int y, int mem_mode, char format,
            string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_Graphic_ColorBMP(int x, int y, int mem_mode, char format,
            string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_Graphic_ColorBMPEx(int x, int y, int nWidth, int nHeight,
            int rotate, int mem_mode, char format, string id_name, string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_Graphic_ColorBMP_HBitmap(int x, int y, int nWidth, int nHeight,
           int rotate, int mem_mode, char format, string id_name, IntPtr hbm);
        [DllImport("Winppla.dll")]
        private static extern int A_Initial_Setting(int Type, string Source);
        [DllImport("Winppla.dll")]
        private static extern int A_WriteData(int IsImmediate, byte[] pbuf, int length);
        [DllImport("Winppla.dll")]
        private static extern int A_ReadData(byte[] pbuf, int length, int dwTimeoutms);
        [DllImport("Winppla.dll")]
        private static extern int A_Load_Graphic(int x, int y, string graphic_name);
        [DllImport("Winppla.dll")]
        private static extern int A_Open_ChineseFont(string path);
        [DllImport("Winppla.dll")]
        private static extern int A_Print_Form(int width, int height, int copies, int amount,
            string form_name);
        [DllImport("Winppla.dll")]
        private static extern int A_Print_Out(int width, int height, int copies, int amount);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Barcode(int x, int y, int ori, char type, int narrow,
            int width, int height, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text(int x, int y, int ori, int font, int type,
            int hor_factor, int ver_factor, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_Chinese(int x, int y, int fonttype, string id_name,
            string data, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_TrueType(int x, int y, int FSize, string FType,
            int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name,
            string data, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_TrueType_W(int x, int y, int FHeight, int FWidth,
            string FType, int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut,
            string id_name, string data, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Backfeed(int back);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_BMPSave(int nSave, string pstrBMPFName);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Cutting(int cutting);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Darkness(int heat);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_DebugDialog(int nEnable);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Feed(char rate);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Form(string formfile, string form_name, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Margin(int position, int margin);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Prncomport(int baud, int parity, int data, int stop);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Prncomport_PC(int nBaudRate, int nByteSize, int nParity,
            int nStopBits, int nDsr, int nCts, int nXonXoff);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Sensor_Mode(char type, int continuous);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Speed(char speed);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Syssetting(int transfer, int cut_peel, int length,
            int zero, int pause);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Unit(char unit);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Gap(int gap);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Logic(int logic);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_ProcessDlg(int nShow);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_ErrorDlg(int nShow);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_LabelVer(int centiInch);
        [DllImport("Winppla.dll")]
        private static extern int A_GetUSBBufferLen();
        [DllImport("Winppla.dll")]
        private static extern int A_EnumUSB(byte[] buf);
        [DllImport("Winppla.dll")]
        private static extern int A_CreateUSBPort(int nPort);
        [DllImport("Winppla.dll")]
        private static extern int A_CreatePort(int nPortType, int nPort, string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Clear_MemoryEx(int nMode);
        [DllImport("Winppla.dll")]
        private static extern void A_Set_Mirror();
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_RSS(int x, int y, int ori, int ratio, int height,
            char rtype, int mult, int seg, string data1, string data2);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_QR_M(int x, int y, int ori, char mult, int value,
            int model, char error, int mask, char dinput, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_QR_A(int x, int y, int ori, char mult, int value,
            char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_GetNetPrinterBufferLen();
        [DllImport("Winppla.dll")]
        private static extern int A_EnumNetPrinter(byte[] buf);
        [DllImport("Winppla.dll")]
        private static extern int A_CreateNetPort(int nPort);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_TrueType_Uni(int x, int y, int FSize, string FType,
            int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name,
            byte[] data, int format, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_TrueType_UniB(int x, int y, int FSize, string FType,
            int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name,
            byte[] data, int format, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_GetUSBDeviceInfo(int nPort, byte[] pDeviceName,
            out int pDeviceNameLen, byte[] pDevicePath, out int pDevicePathLen);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_EncryptionKey(string encryptionKey);
        [DllImport("Winppla.dll")]
        private static extern int A_Check_EncryptionKey(string decodeKey, string encryptionKey,
            int dwTimeoutms);

        public caixaForm()
        {
            con = new Conexao(DAO.Dados.strConexao);
            pedidoBLL = new PedidoBLL(con);
            caixaBLL = new CaixaBLL(con);
            usuarioBLL = new UsuarioBLL(con);
            escrituraBLL = new EscrituraBLL(con);
            oPedido = null;
            impressora = new Reporter();
            pc = new EpsonCodes();
            dsLoginDesconto = "";
            InitializeComponent();
        }

        #region Formatação de campo texto tipo moeda

        private void txPago_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void txValorDesconto_KeyDown(object sender, KeyEventArgs e)
        {

          
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

        private void txPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }

            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0){
                btPagamento.Focus();
            }
        }

        private void txTroco_KeyDown(object sender, KeyEventArgs e)
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
                txTroco.Text = "";
            }
            if (str.Length == 1)
            {
                txTroco.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txTroco.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txTroco.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
        }

        private void txDesconto_KeyDown(object sender, KeyEventArgs e)
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
                txDesconto.Text = "";
            }

            if (str.Length == 1)
            {
                txDesconto.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txDesconto.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txDesconto.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }

        }

        private void txTotal_KeyDown(object sender, KeyEventArgs e)
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
                txTotal.Text = "";
            }
            if (str.Length == 1)
            {
                txTotal.Text = "0,0" + str;
            }
            else if (str.Length == 2)
            {
                txTotal.Text = "0," + str;
            }
            else if (str.Length > 2)
            {
                txTotal.Text = str.Substring(0, str.Length - 2) + "," +
                                str.Substring(str.Length - 2);
            }
        }

        private void txTroco_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void txValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44) {
                e.Handled = true;
            }
        }
        #endregion

        private void caixaForm_Shown(object sender, EventArgs e)
        {
            txPedido.Focus();
        }


        private void limparDados(bool stTroco = false)
        {
            txPedido.Text = "";
            
            
            grid.Rows.Clear();
            lbPedidos.Text = "0;";

            if (!stTroco) {
                txPago.Text = "";
                txTotal.Text = "";
                txTroco.Text = "";
                txDesconto.Text = "";
            }


            valor = 0;
            rbDinheiro.Checked = true;
            str = "";
            txUltmoPedido.Text = "";
            txUltmoPedido.Visible = false;
            btProcurarPedido.Visible = false;
            txNrEscritura.Text = "";
            gbEscritura.Visible = false;
            txAgencia.Text = "";
            txBanco.Text = "";
            txContaCorrente.Text = "";
            txDtResgate.Text = "";
            txRG.Text = "";
            ckPedidosMulti.Checked = false;
            dsLoginDesconto = "";
            txLogin.Text = "";
            txValorDesconto.Text = "";
            txSenha.Text = "";
            

            txPedido.Focus();
        }

        private void carregaCorrentista()
        {
            cbCorrentista.DataSource = caixaBLL.getCorrentistas();
            cbCorrentista.ValueMember = "nrCPFCNPJ";
            cbCorrentista.DisplayMember = "nmNome";

        }

        private void setTipoPagamento(int i) 
        {
            switch (i)
            {
                case 1:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = false;
                    break;
                case 2:
                    gbCorrentista.Visible = true;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = false;
                    break;
                case 3:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = true;
                    gbEscritura.Visible = false;
                    break;
                case 4:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = true;
                    break;
                default:
                    gbCorrentista.Visible = false;
                    gbCheque.Visible = false;
                    gbEscritura.Visible = false;
                    break;
            }
        }

        private int getTipoPagamento()
        {
            int t = 0;

            if (rbDinheiro.Checked)
                t = 1;
            else if (rbCorrentista.Checked)
                t = 2;
            else if (rbCheque.Checked)
                t = 3;
            else if (rbClienteEscritura.Checked)
                t = 4;
            else if (rbDeposito.Checked)
                t = 5;

            return t;
        }

        private void btProcurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txPedido.Text.Equals(""))
                {
                    utils.MessagensExcept.funMsgSistema("Digite um No. de Pedido", 3);
                    txPedido.Focus();
                    return;
                }

                if (grid.RowCount > 0)
                {
                    if (!ckPedidosMulti.Checked)
                    {
                        utils.MessagensExcept.funMsgSistema("Já existem pedidos relacionados!", 3);
                        return;
                    }
                }

                oPedido = pedidoBLL.getUltimoPedido(txPedido.Text);
               
                if (oPedido == null)
                {
                    utils.MessagensExcept.funMsgSistema("Pedido não encontrado!", 3);
                    return;
                }

                switch (oPedido.StPedido)
                {
                    case 'C':
                        utils.MessagensExcept.funMsgSistema("Pedido Cancelado!", 2);
                        txPedido.Focus();
                        return;
                        break;
                    case 'A':
                        utils.MessagensExcept.funMsgSistema("Pedido Aberto!", 2);
                        txPedido.Focus();
                        return;
                        break;
                    case 'P':
                        utils.MessagensExcept.funMsgSistema("Pedido já pago!", 2);
                        txPedido.Focus();
                        return;
                        break;
                }

                
                if (lbPedidos.Text.Contains(txPedido.Text))
                {
                    utils.MessagensExcept.funMsgSistema("Pedido já está relacionado!", 2);
                    txPedido.Focus();
                    return;
                }

                lbPedidos.Text += txPedido.Text + ";";
                String[] pedidos = lbPedidos.Text.Split(new char[] { ';' });
                List<int> lPedidos = new List<int>();

                int i;
                for (i = 1; i < pedidos.Length - 1; i++)
                {
                    lPedidos.Add(Convert.ToInt32(pedidos[i]));
                }


            
                DataTable dados = pedidoBLL.getItensPedidosImpressao(lPedidos);
                DataView dvDados = new DataView(dados);
                DataRow drDados;

                grid.Rows.Clear();

                for (int x = 0; x < dvDados.Count; x++)
                {
                    drDados = dvDados[x].Row;
                    grid.Rows.Add(drDados[0], drDados[1], String.Format("{0:N2}", drDados[2]), String.Format("{0:N2}", drDados[3]));
                }

                txTotal.Text = String.Format("{0:N2}", utils.formatos.getSomaCampoGrid(grid, 3));
                txPago.Focus();
            }
            catch (Exception ex) 
            {
                utils.MessagensExcept.funMsgSistema("Erro ao pesquisar pedido.\n" + ex.Message,1);
            }
        }

        private void checaStatusPgto(Pedido pedido)
        {
            
            
        }

        private void txPago_Leave(object sender, EventArgs e)
        {
            if (!txPago.Text.Equals(""))
            {

                txPago.Text = txPago.Text.Replace("R$", "");
                txTotal.Text = txTotal.Text.Replace("R$", "");    

                double pago = Convert.ToDouble(utils.formatos.getValorCampoNumerico(txPago.Text));
                double valor = Convert.ToDouble(utils.formatos.getValorCampoNumerico(txTotal.Text));


                txPago.Text = String.Format("R$ {0:N2}", pago);
                txTotal.Text = String.Format("R$ {0:N2}", valor);
                if (pago < valor)
                {
                    utils.MessagensExcept.funMsgSistema("Valor informato é menor que o necessário.",3);
                    txPago.Focus();
                    return;
                }
                else
                {
                    txTroco.Text = String.Format("R$ {0:N2}", (pago - valor));
                }
            }
        }

        
        private void btPagamento_Click(object sender, EventArgs e)
        {
            if (!caixaBLL.getCaixaDia(utils.sessao.UsuarioSessao.DsLogin))
            {
                utils.MessagensExcept.funMsgSistema("Você não pode registrar pagamentos sem\nantes fechar o caixa do dia anterior!",3);
                return;
            }

            if (!MessageBox.Show("Deseja efetuar esse pagamento?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
            {
                utils.MessagensExcept.funMsgSistema("Pagamento Cancelado!",3);
                limparDados();
                return;
            }


            if (txPago.Text.Equals(""))
            {
                utils.MessagensExcept.funMsgSistema("Informe valor de pagamento",3);
                txPago.Focus();
                return;
            }

            String[] pedidos = lbPedidos.Text.Split(new char[] { ';' });

            if (pedidos.Length == 2)
            {
                utils.MessagensExcept.funMsgSistema("Digite numero do pedido",2);
                txPedido.Focus();
                return;
            }


            if (Convert.ToDouble(txPago.Text.Replace("R$", "")) < Convert.ToDouble(txTotal.Text.Replace("R$", "")))
            {
                utils.MessagensExcept.funMsgSistema("Valor de pagamento não pode ser menor que o\nvalor total do pedido.",2);
                txPago.Focus();
                return;
            }

            string nmCorrentista = "";
            if (getTipoPagamento() == 2)
            {
                if (cbCorrentista.SelectedValue == null) 
                {
                    utils.MessagensExcept.funMsgSistema("Selecione um Correntista!",3);
                    cbCorrentista.Focus();
                    return;
                }



                if (!txTotal.Text.Equals(txPago.Text))
                {
                    utils.MessagensExcept.funMsgSistema("O valor de pagamento deve ser igual ao valor total!", 1);
                    txPago.Focus();
                    return;
                }

                if (!txDesconto.Text.Equals("")) {
                    utils.MessagensExcept.funMsgSistema("Pagamento de correntista não aceita desconto!", 1);
                    return;
                }
            }

            if (getTipoPagamento() == 3)
            {
                if (txBanco.Text.Equals("") || txAgencia.Text.Equals("") || txNrCheque.Text.Equals("") || txContaCorrente.Text.Equals(""))
                {
                    utils.MessagensExcept.funMsgSistema("Preencha as informações do cheque",3);
                    txBanco.Focus();
                    return;
                }
            }

            if (getTipoPagamento() == 5)
            {
                if (txBanco.Text.Equals("") || txAgencia.Text.Equals("") || txContaCorrente.Text.Equals(""))
                {
                    utils.MessagensExcept.funMsgSistema("Preencha as informações do Deposito",3);
                    txBanco.Focus();
                    return;
                }
            }

            string nmBoleto = (Microsoft.VisualBasic.Interaction.InputBox("Nome impresso no boleto", "Cartorio Conduru", "0", 150, 150));

            double vlPago = Convert.ToDouble(txPago.Text.Replace("R$", ""));

            List<int> lPedidos = new List<int>();

            

            int i;
            for (i = 1; i < pedidos.Length -1; i++)
            {
                lPedidos.Add(Convert.ToInt32(pedidos[i]));   
            }

            if (txDesconto.Text.Equals(""))
                txDesconto.Text = "0";
            
            try
            {
                
                // Registro de pagamento via procedure
                char resposta = 'F';
                try
                {
                    SqlCommand cmd = new SqlCommand("psPgtoPedido", con.ObjCon);

                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    
                    if (con.ObjCon.State == ConnectionState.Closed)
                    {
                        con.ObjCon.Open();
                    }

                    cmd.Parameters.Add("@nrPedidos", SqlDbType.VarChar).Value = lbPedidos.Text.Substring(2);
                    cmd.Parameters.Add("@vlPago", SqlDbType.Money).Value = vlPago;
                    cmd.Parameters.Add("@idHistorico", SqlDbType.Int).Value = sessao.Historico.IdHistoricocaixa;
                    cmd.Parameters.Add("@dsLogin", SqlDbType.VarChar).Value = sessao.UsuarioSessao.DsLogin;
                    cmd.Parameters.Add("@nrCaixa", SqlDbType.Int).Value = sessao.NrCaixa;
                    cmd.Parameters.Add("@cdTipoMovimento", SqlDbType.Int).Value = sessao.CdAtoPedido;
                    cmd.Parameters.Add("@cdTipoPgto", SqlDbType.Int).Value = getTipoPagamento();
                    cmd.Parameters.Add("@vlDesconto", SqlDbType.Money).Value = Convert.ToDouble(txDesconto.Text.Replace("R$", ""));
                    cmd.Parameters.Add("@dsLoginDesconto", SqlDbType.VarChar).Value = dsLoginDesconto;
                    cmd.Parameters.Add("@nmRecibo", SqlDbType.VarChar).Value = nmBoleto;
                    

                    SqlDataReader dr = null;

                    dr = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (dr.HasRows)
                    {
                        dr.Read();
                        resposta = Convert.ToChar(dr["resultado"].ToString());
                        
                    }
                    dr.Close();
                    con.ObjCon.Close();
                }
                catch (SqlException ex)
                {
                    utils.MessagensExcept.funMsgSistema("Erro ao efetuar pagamento.\n"+ex.Message,1);
                }
                    
                
                
                /*
                bool stPgtoPedido = caixaBLL.registraPagamentoPedido(vlPago
                                                , lPedidos
                                                , sessao.Historico
                                                , sessao.UsuarioSessao.DsLogin
                                                , sessao.CdAtoPedido
                                                , sessao.NrCaixa
                                                , getTipoPagamento()
                                                , Convert.ToDouble(txDesconto.Text.Replace("R$", ""))
                                                , dsLoginDesconto
                                                ,nmBoleto);
                
                */
                if (resposta == 'T') {

                    int nrPedidoPagto = lPedidos[0];

                    if (getTipoPagamento() == 2)
                    {
                        PedidoCorrentista pedidoCorrentista = new PedidoCorrentista();
                        pedidoCorrentista.DtPedido = DateTime.Now;
                        pedidoCorrentista.DsAutorizacao = "";
                        pedidoCorrentista.NrCPFCNPJ = cbCorrentista.SelectedValue.ToString();
                        pedidoCorrentista.StPedido = 'A';
                        pedidoCorrentista.VlPedido = vlPago;
                        pedidoCorrentista.NrPedido = nrPedidoPagto;
                        nmCorrentista = cbCorrentista.Text;
                        caixaBLL.salvaPedidoCorrentista(pedidoCorrentista);
                    }

                    if (getTipoPagamento() == 3)
                    {
                        Cheque cheque = new Cheque();
                        cheque.DtCheque = Convert.ToDateTime(txDtResgate.Text);
                        cheque.NrPedido = nrPedidoPagto;
                        cheque.NrRG = txRG.Text;
                        cheque.StCheque = 'A';
                        cheque.NrCheque = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txNrCheque.Text));
                        cheque.NrBanco = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txBanco.Text));
                        cheque.NrAgencia = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txAgencia.Text));
                        cheque.NrConta = utils.formatos.getValorCampoNumerico(txContaCorrente.Text);
                        cheque.StDeposito = 'C';

                        caixaBLL.salvaCheque(cheque);

                    }

                    if (getTipoPagamento() == 4)
                    {
                        for (int x = 0; x < lPedidos.Count; x++)
                        {
                            DataTable dadosItens = new DataTable();
                            dadosItens = pedidoBLL.getItensPedidos(Convert.ToInt32(lPedidos[x]));

                            DataView dvDados = new DataView(dadosItens);
                            DataRow drDados;
                            for (int y = 0; y < dvDados.Count; y++)
                            {
                                drDados = dvDados[y].Row;
                                MovimentoDeposito movimentoDp = new MovimentoDeposito();
                                movimentoDp.IdEscritura = Convert.ToInt32(txNrEscritura.Text);
                                movimentoDp.CdAto = Convert.ToInt32(drDados["cdAto"].ToString());
                                movimentoDp.VlMovimento = Convert.ToDouble(drDados["vlItem"].ToString());
                                movimentoDp.DsMovimento = "PAGAMENTO CAIXA";
                                movimentoDp.DtMovimento = DateTime.Now;
                                movimentoDp.DsLogin = utils.sessao.UsuarioSessao.DsLogin;
                                movimentoDp.TpMovimento = 'D';
                                movimentoDp.StRegistro = 'P';
                                escrituraBLL.solicitaPagamento(movimentoDp);
                            }

                        }
                    }

                    if (getTipoPagamento() == 5)
                    {
                        Cheque cheque = new Cheque();
                        cheque.DtCheque = Convert.ToDateTime(txDtResgate.Text);
                        cheque.NrPedido = nrPedidoPagto;
                        cheque.NrRG = "";
                        cheque.StCheque = 'P';
                        cheque.NrCheque = 0;
                        cheque.NrBanco = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txBanco.Text));
                        cheque.NrAgencia = Convert.ToInt32(utils.formatos.getValorCampoNumerico(txAgencia.Text));
                        cheque.NrConta = utils.formatos.getValorCampoNumerico(txContaCorrente.Text);
                        cheque.StDeposito = 'D';

                        caixaBLL.salvaCheque(cheque);

                    }
                    vlPago = Convert.ToDouble(txPago.Text.Replace("R$", ""));
                    ckPedidosMulti.Checked = false;

                    

                    foreach (int nPedido in lPedidos) {
                        pedidoBLL.pagaPedido(nPedido);
                    }

                    utils.MessagensExcept.funMsgSistema("Pedido(s) Pago(s)!\n Iniciando impressão do recibo.",2);
                    int tipoPgto = getTipoPagamento();
                    limparDados(true);



                    pedidoBLL.imprimePedido(lPedidos,
                                            sessao.NrCaixa,
                                            nmBoleto,
                                            sessao.PathIniFile,
                                            sessao.UsuarioSessao.NmUsuario,
                                            tipoPgto,
                                            Convert.ToDouble(txPago.Text.Replace("R$", "")),
                                            nmCorrentista
                                            ,false
                                            , Convert.ToDouble(txDesconto.Text.Replace("R$", "")));

                    
                    if (MessageBox.Show("Deseja Imprimir etiqueta?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
                    {
                        imprimeEtiqueta(lPedidos);
                    }
                    
                }
                
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro: " + ex.Message,1);
            }
                
        }


        public void imprimeEtiqueta(List<int> pedidos) {

            List<String> linhasImpressao = new List<string>();
            utils.IniFile iniFile = new utils.IniFile(sessao.PathIniFile);
            Reporter imp = new Reporter();
            EpsonCodes iCodes = new EpsonCodes();
            bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));
            String strPedidos = "";
            if (arquivo)
            {
                if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRETIQUETA")))
                {
                    File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRETIQUETA"));
                }
            }


            imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRETIQUETA");
            imp.StartJob();
            int i = 1;
            sbyte count = 0;
            foreach (int pedido in pedidos)
            {
                strPedidos += pedido.ToString() + ",";
            }

            strPedidos = strPedidos.Substring(0, (strPedidos.Length - 1));

            linhasImpressao = pedidoBLL.geraDadosEtiqueta(strPedidos, sessao.PathIniFile, sessao.UsuarioSessao.NmUsuario);

            if (count == 0)
            {
                imp.PrintText(i, 1, "");
                imp.PrintText(i++, 1, "");
            }
            else
            {
                imp.PrintText(i++, 1, "");
            }
            for (int x = 0; x < linhasImpressao.Count; x++)
            {
                imp.PrintText((i++), 1, iCodes.CondensedOn + linhasImpressao[x] + iCodes.CondensedOff);
            }

            imp.PutText(iCodes.Eject);
            imp.EndJob();
            imp.PrintJob();
            /*
            int nLen, ret, sw;
            byte[] pbuf = new byte[128];
            string strmsg;
            IntPtr ver;
            System.Text.Encoding encAscII = System.Text.Encoding.ASCII;
            System.Text.Encoding encUnicode = System.Text.Encoding.Unicode;

            // dll version.
            ver = A_Get_DLL_Version(0);

            // search port.
            nLen = A_GetUSBBufferLen() + 1;
            strmsg = "DLL ";
            strmsg += Marshal.PtrToStringAnsi(ver);
            strmsg += "\r\n";
            if (nLen > 1)
            {
                byte[] buf1, buf2;
                int len1 = 128, len2 = 128;
                buf1 = new byte[len1];
                buf2 = new byte[len2];
                A_EnumUSB(pbuf);
                A_GetUSBDeviceInfo(1, buf1, out len1, buf2, out len2);
                sw = 1;
                if (1 == sw)
                {
                    ret = A_CreatePrn(12, encAscII.GetString(buf2, 0, len2));// open usb.
                }
                else
                {
                    ret = A_CreateUSBPort(1);// must call A_GetUSBBufferLen() function fisrt.
                }
                if (0 != ret)
                {
                    strmsg += "Open USB fail!";
                }
                else
                {
                    strmsg += "Open USB:\r\nDevice name: ";
                    strmsg += encAscII.GetString(buf1, 0, len1);
                    strmsg += "\r\nDevice path: ";
                    strmsg += encAscII.GetString(buf2, 0, len2);
                    //sw = 2;
                    if (2 == sw)
                    {
                        //get printer status.
                        pbuf[0] = 0x01;
                        pbuf[1] = 0x46;
                        pbuf[2] = 0x0D;
                        pbuf[3] = 0x0A;
                        A_WriteData(1, pbuf, 4);//<SOH>F
                        ret = A_ReadData(pbuf, 2, 1000);
                    }
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(szSavePath);
                ret = A_CreatePrn(0, szSaveFile);// open file.
                strmsg += "Open ";
                strmsg += szSaveFile;
                if (0 != ret)
                {
                    strmsg += " file fail!";
                }
                else
                {
                    strmsg += " file succeed!";
                }
            }
            MessageBox.Show(strmsg);
            if (0 != ret)
                return;

            // sample setting.
            A_Set_DebugDialog(1);
            A_Set_Unit('n');
            A_Set_Syssetting(1, 0, 0, 0, 0);
            A_Set_Darkness(8);
            A_Del_Graphic(1, "*");// delete all picture.
            A_Clear_Memory();// clear memory.
            A_WriteData(0, encAscII.GetBytes(sznop2), sznop2.Length);
            A_WriteData(1, encAscII.GetBytes(sznop1), sznop1.Length);

            //draw box.
            A_Draw_Box('A', 20, 10, 320, 170, 4, 4);

            int Y = 30;

            //print text, true type text.
            for (int x = 0; x < linhas.Length;x++ )
            {
                A_Prn_Text(20, Y, 1, 2, 0, 1, 1, 'N', 2, linhas[x].ToString());
                Y = Y + 30;
            }
            //A_Prn_Text_TrueType(20, 60, 30, "Arial", 1, 400, 0, 0, 0, "AA", "TrueType Font", 1);//save in ram.
            //A_Prn_Text_TrueType_W(20, 90, 20, 20, "Times New Roman", 1, 400, 0, 0, 0, "AB", "TT_W: 多字元測試", 1);
            
            //A_Prn_Text_TrueType_Uni(20, 120, 30, "Times New Roman", 1, 400, 0, 0, 0, "AC", Encoding.Unicode.GetBytes("TT_Uni: 多字元測試"), 1, 1);//UTF-16
            //encUnicode.GetBytes("\xFEFF", 0, 1, pbuf, 0);//UTF-16.//pbuf[0]=0xFF,pbuf[1]=0xFE;
            //encUnicode.GetBytes("TT_UniB: 多字元測試", 0, 14, pbuf, 2);//copy mutil byte.
            //encUnicode.GetBytes("\x0000", 0, 1, pbuf, 30);//null.//pbuf[30]=0x00,pbuf[31]=0x00;
            //A_Prn_Text_TrueType_UniB(20, 150, 30, "Times New Roman", 1, 400, 0, 0, 0, "AD", pbuf, 0, 1);//Byte Order Mark.

            // output.
            A_Print_Out(1, 1, 1, 1);// copy 2.

            // close port.
            A_ClosePrn();
             * */
        }




        private void caixaForm_Load(object sender, EventArgs e)
        {
            
            carregaCorrentista();
            gbCorrentista.Visible = false;
        }

        private void caixaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sessao.NrCaixa = 0;
        }

        private void caixaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                btPagamento_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                btReimprimir_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.O)
            {
                btRetiradas_Click(null, null);
            }
            if (e.KeyCode == Keys.F5)
            {
                btDesconto_Click(null, null);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                if (ckPedidosMulti.Checked)
                {
                    ckPedidosMulti.Checked = false;
                    txUltmoPedido.Visible = false;
                    btProcurarPedido.Visible = false;
                }
                else
                {
                    txUltmoPedido.Visible = true;
                    ckPedidosMulti.Checked = true;
                    btProcurarPedido.Visible = true;
                    txUltmoPedido.Focus();
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                rbDinheiro.Checked = true;
            }
            if (e.KeyCode == Keys.F7)
            {
                rbCorrentista.Checked = true;
            }
            if (e.KeyCode == Keys.F8)
            {
                rbCheque.Checked = true;
            }
            if (e.KeyCode == Keys.F9)
            {
                rbClienteEscritura.Checked = true;
            }
            if (e.KeyCode == Keys.F11)
            {
                rbDeposito.Checked = true;
            }
            if (e.KeyCode == Keys.Escape) {
                limparDados();
            }
            if (e.KeyCode == Keys.F2)
            {
                btFecharCaixa_Click(null, null);
            }
        }


        private void btFecharCaixa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Fechar este Caixa?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
            {

                if (pedidoBLL.checaExistePedidoFechados(sessao.UsuarioSessao.DsLogin).Rows.Count > 0) {
                    utils.MessagensExcept.funMsgSistema("Você possui pedidos ainda não pagos.\nFavor verifique a lista de pedidos não em aberto.",3);
                    return;
                }



                if (caixaBLL.getCaixaDia(sessao.UsuarioSessao.DsLogin))
                {
                    caixaBLL.fechaCaixa(sessao.UsuarioSessao.DsLogin);
                    utils.MessagensExcept.funMsgSistema("Caixa Fechado\nIniciando impressão!",2);
                    try
                    {
                        HistoricoCaixa historico = caixaBLL.getUltimoHistorioPorUsuario(sessao.UsuarioSessao.DsLogin);

                        pedidoBLL.imprimeFechamentoCaixa(sessao.PathIniFile, historico);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        utils.MessagensExcept.funMsgSistema("Erro ao imprimir fechamento do caixa.\n" + ex.Message,1);
                    }
                }
            }   
        }

        private void btReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string nrPedido = (Microsoft.VisualBasic.Interaction.InputBox("Digite no. do pedido", "Cartorio Conduru", "0", 150, 150));

                if (nrPedido != "")
                {
                    List<int> lPedidos = new List<int>();
                    lPedidos.Add(Convert.ToInt32(nrPedido));

                    pedidoBLL.imprimePedido(lPedidos, sessao.NrCaixa, "Reimpressao", sessao.PathIniFile, sessao.UsuarioSessao.NmUsuario, 0, 0, "", true);
                    utils.MessagensExcept.funMsgSistema("Pedido enviado a impressora!", 2);
                }
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema(ex.Message, 1);
            }
        }


       

      
        private void rbDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
        }

        private void rbCorrentista_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
        }

        private void rbCheque_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
            gbCheque.Text = "Cheque";
            txRG.Enabled = true;
            txNrCheque.Enabled = true;
        }

        private void txPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                btProcurar_Click(null, null);
            }
        }

        #region Tratamento de Desconto
        /// <summary>
        /// Trata a concessão de desconto a um pedido
        /// </summary>
       
        private void btCancelarDesc_Click(object sender, EventArgs e)
        {
            gbDesconto.Visible = false;
            str = "";
            txLogin.Text = "";
            txSenha.Text = "";
            txValorDesconto.Text = "";
        }

        #endregion

        private void brGravarDesc_Click(object sender, EventArgs e)
        {
            if (txLogin.Text.Equals(""))
            {
                utils.MessagensExcept.funMsgSistema("Digite o nome de Usuário",2);
                txLogin.Focus();
                return;
            }

            if (txSenha.Text.Equals(""))
            {
                utils.MessagensExcept.funMsgSistema("Digite uma senha",2);
                txSenha.Focus();
                return;
            }

            if (txValorDesconto.Text.Equals(""))
            {
                utils.MessagensExcept.funMsgSistema("Digite um valor de desconto",2);
                txValorDesconto.Focus();
                return;
            }

            Usuario ususario = usuarioBLL.login(txLogin.Text);
            string senha = txSenha.Text;

            if (ususario.VlSenha.Equals(senha))
            {

                if (stDesconto.Equals('D'))
                {
                    dsLoginDesconto = ususario.DsLogin;

                    double valorDesconto = 0;

                    if (rbTipoPercent.Checked)
                    {
                        valorDesconto = Convert.ToDouble(txTotal.Text) * (Convert.ToDouble(txValorDesconto.Text) / 100);
                    }
                    else
                    {
                        valorDesconto = Convert.ToDouble(txValorDesconto.Text);
                    }


                    if (rbTipoDinheiro.Checked && (valorDesconto > Convert.ToDouble(txTotal.Text)))
                    {
                        utils.MessagensExcept.funMsgSistema("Valor de desconto não pode ser maior que o valor a pagar!",1);
                        txValorDesconto.Focus();
                        return;
                    }

                    txTotal.Text = System.Math.Round((Convert.ToDouble(txTotal.Text) - valorDesconto), 2).ToString();
                    txDesconto.Text = System.Math.Round(valorDesconto, 2).ToString();

                    txPago.Focus();

                    gbDesconto.Visible = false;
                    stDesconto = 'N';
                    str = "";
                    txLogin.Text = "";
                    txSenha.Text = "";
                    txValorDesconto.Text = "";
                }

            }
            else
            {
                utils.MessagensExcept.funMsgSistema("Usuário não encontrado!",3);
                txLogin.Focus();
            }
        }

        private void btDesconto_Click(object sender, EventArgs e)
        {
            gbDesconto.Text = "Autorizar Desconto";
            gbDesconto.Visible = true;
            txLogin.Focus();
            stDesconto = 'D';
        }

        private void btRetiradas_Click(object sender, EventArgs e)
        {
            entradasRetiradasCaixaForm entRetCaixaForm = new entradasRetiradasCaixaForm();
            entRetCaixaForm.ShowDialog();
        }

        private void ckPedidosMulti_Click(object sender, EventArgs e)
        {
            
        }

        private void ckPedidosMulti_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPedidosMulti.Checked)
            {
                txUltmoPedido.Visible = true;
                btProcurarPedido.Visible = true;
            }
            else
            {
                txUltmoPedido.Visible = false;
                btProcurarPedido.Visible = false;
            }
        }

        private void btProcurarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dados = null;
                DataView dvDados = null;
                DataRow drDados;
                int i;
                dados = pedidoBLL.getPedidosMulti(utils.sessao.UsuarioSessao.DsLogin, Convert.ToInt32(txPedido.Text), Convert.ToInt32(txUltmoPedido.Text));
                dvDados = new DataView(dados);

                if (dvDados.Count > 0)
                {
                    limparDados();
                }

                for (i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    lbPedidos.Text += drDados[0].ToString() + ";";
                }

                String[] pedidos = lbPedidos.Text.Split(new char[] { ';' });
                List<int> lPedidos = new List<int>();


                for (i = 1; i < pedidos.Length - 1; i++)
                {
                    lPedidos.Add(Convert.ToInt32(pedidos[i]));
                }

                dados = pedidoBLL.getItensPedidosImpressao(lPedidos);
                dvDados = new DataView(dados);


                for (i = 0; i < dvDados.Count; i++)
                {
                    drDados = dvDados[i].Row;
                    grid.Rows.Add(drDados[0], drDados[1], String.Format("{0:N2}", drDados[2]), String.Format("{0:N2}", drDados[3]));

                    valor += Convert.ToDouble(drDados[3].ToString());
                }

                txTotal.Text = String.Format("{0:N2}", valor);

                txPago.Focus();
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao pesquisar pedido.\n" + ex.Message, 1);
            }
        }

        private void txUltmoPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                btProcurarPedido_Click(null, null);
            }
        }

        private void btVerificaSaldo_Click(object sender, EventArgs e)
        {
            if (escrituraBLL.getValorCliente(Convert.ToInt32(txNrEscritura.Text), 'C') <= 0)
            {
                utils.MessagensExcept.funMsgSistema("Cliente sem saldo!",3);
                return;
            }
            else {
                txPago.Text = txTotal.Text;
            }


        }

        private void rbClienteEscritura_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
            txNrEscritura.Text = "";
            gbEscritura.Visible = true;
            txNrEscritura.Focus();
        }

        private void rbDeposito_CheckedChanged(object sender, EventArgs e)
        {
            setTipoPagamento(getTipoPagamento());
            gbCheque.Visible = true;
            gbCheque.Text = "Deposito Conta";
            txNrCheque.Enabled = false;
            txRG.Enabled = false;
        }

        private void txBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        












    }
}

