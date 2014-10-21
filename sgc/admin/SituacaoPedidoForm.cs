using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using BLL;
using sgc.utils;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using MatrixReporter;
using System.IO;

namespace sgc.admin
{
    public partial class SituacaoPedidoForm : Form
    {
        public Conexao con = new Conexao(Dados.strConexao);
        ConexaoDB conexao = new ConexaoDB(Dados.strConexao);
        public PedidoBLL pedidoBll;

        private PrintDocument printDoc = new PrintDocument();
        private PageSettings pgSettings = new PageSettings();
        private PrinterSettings prtSettings = new PrinterSettings();
        private List<string> linhasImpressao = new List<string>();

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
        
        
        public SituacaoPedidoForm()
        {
            pedidoBll = new PedidoBLL(con);
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage); 
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            getItensPedido();
            getMovimentoCaixa();
            statusPedido();
        }

        public void getItensPedido()
        {
            try
            {
                String sql = "select a.dsAto,a.vlAto,i.nrSelo ";
                sql += ",(select dsTipoSelo from tblTipoSelo where cdTipoSelo = i.cdTipoSelo) as tipoSelo ";
                sql += ",i.vlItem from tblItensPedido i ";
                sql += "inner join tblAtosOperacoes a on i.cdAto = a.cdAto ";
                sql += "where nrPedido =  " + txNrPedido.Text;
                sql += "order by i.idItemPedido";

                SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridPedido.DataSource = dt;
                da.Dispose();
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao consultar pedido.\n"+ex.Message,3);
            }

        }

        public void getMovimentoCaixa() {
            try
            {
                String sql = "select idMovimento,dsLogin ,vlMovimento,vlDesconto,  tpPagamento, ";
                sql+= "case tpPagamento ";
	                    sql+= "when 1 then 'Dinheiro' ";
                        sql+= "	when 2 then 'Correntista' ";
                        sql+= "	when 3 then 'Cheque' ";
                        sql+= "	else 'Deposito' end tipoPagamento ";
                        sql += ",CONVERT(VARCHAR(10), dtMovimento, 103) +' '+CONVERT(VARCHAR(12), dtMovimento, 114) as dtMovimento ";
                sql += "from tblMovimentoCaixa where nrPedido =" + txNrPedido.Text;
                sql += "order by dtMovimento";

                SqlDataAdapter da = new SqlDataAdapter(sql, con.ObjCon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridPagto.DataSource = dt;
            }
            catch (Exception ex)
            {
                utils.MessagensExcept.funMsgSistema("Erro ao consultar pedido.\n" + ex.Message, 3);
            }
        }

        public void statusPedido() {
            String sql = "select p.nrPedido,p.dtPedido,p.dsLogin,p.stPedido,"
                        + "(select SUM(i.vlItem) from tblItensPedido i "
                        + "where i.nrPedido = p.nrPedido) vlPedido "
                        + "from tblPedidos p "
                        + "where p.nrPedido = " + txNrPedido.Text;


            try
            {
                con.ObjCon.Open();
                SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    dr.Read();

                    lbUsuario.Text = dr["dsLogin"].ToString();
                    lbDataPedido.Text = dr["dtPedido"].ToString();
                    lbStatus.Text = dr["stPedido"].ToString();


                    if (!dr["vlPedido"].ToString().Equals(""))
                        lbValor.Text = String.Format("{0:C2}", dr["vlPedido"]);

                    dr.Close();
                }
                dr.Close();



            }
            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro: " + e.Message);
            }
            finally {
                con.ObjCon.Close();
            }
        }

        private void apagarMovimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String idMovimento = gridPagto[0, gridPagto.CurrentRow.Index].Value.ToString();

                String sql = "delete from tblMovimentoCaixa where idMovimento = " + idMovimento;

                con.ObjCon.Open();
                SqlCommand cmd = new SqlCommand(sql, con.ObjCon);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Movimento apagado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar movimento.\nErro " + ex.Message);
            }
            finally {
                con.ObjCon.Close();
            }

        }

        private void alterarValorMovimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strValor = (Microsoft.VisualBasic.Interaction.InputBox("Novo Valor", "Cartorio Conduru", "1", 150, 150));
                
                String idMovimento = gridPagto[0, gridPagto.CurrentRow.Index].Value.ToString();

                double valor = Convert.ToDouble(strValor);


                if (valor > 0)
                {

                    String sql = "update tblMovimentoCaixa set vlMovimento = @valor where idMovimento = " + idMovimento;

                    con.ObjCon.Open();
                    SqlCommand cmd = new SqlCommand(sql, con.ObjCon);
                    cmd.Parameters.AddWithValue("@valor", valor);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Movimento alterado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar valor de movimento.\nErro " + ex.Message);
            }
            finally
            {
                con.ObjCon.Close();
            }
        }

        private void btEstorno_Click(object sender, EventArgs e)
        {


            try
            {
                conexao.abreBanco();


                //conn.trans = conn.conexao.BeginTransaction();

                String sql = "select idMovimento,tpPagamento from tblMovimentoCaixa where nrPedido = " + txNrPedido.Text;

                DataTable tbMovimento = conexao.retornarDataSet(sql);


                if (tbMovimento.Rows.Count > 0)
                {

                    for (int i = 0; tbMovimento.Rows.Count > i;i++ )
                    {
                        sql = "delete from tblMovimentoCaixa where idMovimento = " + tbMovimento.Rows[i]["idMovimento"].ToString();
                        conexao.executaSemRetorno(sql);

                        if (Convert.ToInt16(tbMovimento.Rows[i]["tpPagamento"]) == 2)
                        {
                            sql = "delete from tblPedidosCorrentista where nrPedido = " + txNrPedido.Text;
                        }
                        else
                        {
                            sql = "delete from tblCheque where nrPedido = " + txNrPedido.Text;
                        }

                        conexao.executaSemRetorno(sql);

                    }

                }
                sql = "update tblPedidos set stPedido = 'F' where nrPedido = " + txNrPedido.Text;
                conexao.executaSemRetorno(sql);

                //conn.trans.Commit();
                
                utils.MessagensExcept.funMsgSistema("Pedido estornado", 2);
            }
            catch (Exception ex)
            {
                //conn.trans.Rollback();
                utils.MessagensExcept.funMsgSistema("Erro ao estornar pagamento.\n" + ex.Message, 1);
            }
            finally {
                conexao.fechaBanco();
            }
              
        }

        private void btEtiqueta_Click(object sender, EventArgs e)
        {

            List<int> item = new List<int>();
            item.Add(Convert.ToInt32(txNrPedido.Text));
            linhasImpressao = this.pedidoBll.geraDadosEtiqueta(item, sessao.PathIniFile, sessao.UsuarioSessao.NmUsuario);

            utils.IniFile iniFile = new utils.IniFile(sessao.PathIniFile);
            Reporter imp = new Reporter();
            bool arquivo = Convert.ToBoolean(iniFile.IniReadValue("CONFIGCAIXA", "FLAGARQUIVO"));

            if (arquivo)
            {
                if (File.Exists(iniFile.IniReadValue("CONFIGCAIXA", "IMPRETIQUETA")))
                {
                    File.Delete(iniFile.IniReadValue("CONFIGCAIXA", "IMPRETIQUETA"));
                }
            }


            imp.Output = iniFile.IniReadValue("CONFIGCAIXA", "IMPRETIQUETA");
            imp.StartJob();

            sbyte i = 1;
            imp.PrintText(i,1,"");
            
            for (int x = 0; x < linhasImpressao.Count; x++)
            {
                imp.PrintText((i++), 1, linhasImpressao[x]);
            }


            imp.PrintJob();
            /*
            Margins margens = new Margins(10,10,10,10);
            //pgSettings.Margins = margens;
            printDoc.DefaultPageSettings = pgSettings;
            printDoc.DefaultPageSettings.Margins = margens;
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDoc;
            printDoc.Print();
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
            */

            
        }

        

        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            
            Font printFont = new Font("Courier New", 9);
            int leftMargin = e.MarginBounds.Left;
            int topMargin =  e.MarginBounds.Top;

            int Y = 15;

            for (int a = 0; a <= 4;a++ ) {
                e.Graphics.DrawString("   " , printFont, Brushes.Black,leftMargin, Y);
                Y = Y + 15;
            }


            //print text, true type text.
            for (int x = 0; x < linhasImpressao.Count; x++)
            {
                e.Graphics.DrawString("  "+linhasImpressao[x].ToString(), printFont, Brushes.Black,
                  leftMargin, Y);
                
                Y = Y + 15;
            }

            
        }

        public void imprimeEtiqueta(List<string> linhas)
        {

            
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
            //MessageBox.Show(strmsg);
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
            //A_Draw_Box('A', 20, 10, 320, 170, 4, 4);

            int Y = 20;

            //print text, true type text.
            for (int x = 0; x < linhas.Count ; x++)
            {
                A_Prn_Text(25, Y, 1, 2, 0, 1, 1, 'N', 2, linhas[x].ToString());
                Y = Y + 20;
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
        
    }
}
