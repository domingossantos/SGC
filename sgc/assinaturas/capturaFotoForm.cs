using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DAO;

namespace sgc.assinaturas
{
    public partial class capturaFotoForm : Form
    {
        private IDataObject dados;
        private Image bmap;


        const short WM_CAP = 1024;
        const int WM_CAP_DRIVER_CONNECT = (WM_CAP + 10);
        const int WM_CAP_DRIVER_DISCONNECT = (WM_CAP + 11);
        const int WM_CAP_EDIT_COPY = (WM_CAP + 30);
        const int WM_CAP_SET_PREVIEW = (WM_CAP + 50);
        const int WM_CAP_SET_PREVIEWRATE = (WM_CAP + 52);
        const int WM_CAP_SET_SCALE = (WM_CAP + 53);
        const int WS_CHILD = 1073741824;
        const int WS_VISIBLE = 268435456;
        const short SWP_NOMOVE = 2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 4;
        const short HWND_BOTTOM = 1;
        int hHwnd1;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        static extern void SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] Object lParam);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        static extern bool DestroyWindow(int hndw);

        [DllImport("avicap32.dll")]
        static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        [DllImport("avicap32.dll")]
        static extern bool capGetDriverDescriptionA(short wDriver, string lpszName, int cbName, string lpszVer, int cbVer);
        
        
        
        
        
        public capturaFotoForm()
        {
            InitializeComponent();            
        }

        public void AbriJanelaVisualizacao()
         {

         int height = picCapture.Height;
         int widht = picCapture.Width;

         try
         {
             hHwnd1 = capCreateCaptureWindowA("WEBCAM", (WS_VISIBLE | WS_CHILD), 0, 0, 149, 126, this.picCapture.Handle.ToInt32(), 0);
             SendMessage(hHwnd1, WM_CAP_DRIVER_CONNECT, 0, 0);
             SendMessage(hHwnd1, WM_CAP_SET_SCALE, 66, 0);
             SendMessage(hHwnd1, WM_CAP_SET_PREVIEWRATE, 66, 0);
             SendMessage(hHwnd1, WM_CAP_SET_PREVIEW, 66, 0);
             SetWindowPos(hHwnd1, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, (SWP_NOMOVE | SWP_NOZORDER));
         }
         catch (Exception ex)
         {

             throw new Exception("Erro ao conectar WebCam!" + Environment.NewLine + "Detalhes: " + ex.Message); 
         }        
           
     }

        private void CapturarImagem()
        {
            try
            {
                SendMessage(hHwnd1, WM_CAP_EDIT_COPY, 0, 0);
                dados = Clipboard.GetDataObject();
                if (dados.GetDataPresent(typeof(System.Drawing.Bitmap)))
                {
                    bmap = ((Image)(dados.GetData(typeof(System.Drawing.Bitmap))));
                    picCapture.Image = bmap;
                    pictureBox1.Image = picCapture.Image; 
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao capturar imagem!" + Environment.NewLine + "Detalhes: " + ex.Message);
            }
        }



        private void FecharjanelaVisualizacao()
        {
            try
            {
                SendMessage(hHwnd1, WM_CAP_DRIVER_DISCONNECT, 0, 0);
                DestroyWindow(hHwnd1);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao desconectar câmera" + "Detalhes: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbriJanelaVisualizacao();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CapturarImagem();

            Conexao con = new Conexao(Dados.StrConRemoto);

            con.ObjCon.Open();

            MessageBox.Show(con.ObjCon.State.ToString());
            con.ObjCon.Close();
        }
    }
}
