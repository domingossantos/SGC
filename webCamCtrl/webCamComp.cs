using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace webCamCtrl
{
    public partial class webCamComp : UserControl
    {
        private int m_Width = 500;
        private int m_Height = 500;
        private int mCapHwnd;
        private bool bStoped = true;

        
        #region API Declarations 

        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, uint Msd, int wParam, int lParam);
        
        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(String lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hwdParent, int nID);
       
        [DllImport("user32", EntryPoint = "OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);
        
        [DllImport("user32", EntryPoint = "EmptyClipboard")]
        public static extern int EmptyClipboard();
        
        [DllImport("user32", EntryPoint = "CloseClipboard")]
        public static extern int CloseClipboard();
        
        [DllImport("user32.dll")]
        extern static IntPtr GetClipboardData(uint uFormat);
        #endregion

        #region API Constants
        public const int WM_USER = 1024;
        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GET_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;
        
        public const int WM_CAP_START = WM_USER;
        
        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
        public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43;
        public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
        public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;
        #endregion

        public webCamComp()
        {
            InitializeComponent();
        }
        
        ~webCamComp()
        {
            this.Stop();
        }

        #region Start and Stop Capture Funcion
        /// <summary>
        /// Ajustar o tamanho da imagem ao tamanho da tela
        /// </summary>
        private void ImageSize()
        {
            m_Width = imgWebCam.Size.Width;
            m_Height = imgWebCam.Size.Height;
        }
        /// <summary>
        /// Inicia a captira de imagem
        /// </summary>
        public void Start()
        {
            try
            {
                ImageSize();
                this.Stop();

                mCapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, m_Width, m_Height, this.Handle.ToInt32(), 0);

                Application.DoEvents();

                SendMessage(mCapHwnd, WM_CAP_CONNECT, 0, 0);
                this.tRefreshFrame.Interval = 1;
                bStoped = false;
                this.tRefreshFrame.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na captura da imagem: "+ex.Message);
                this.Stop();
            }
        }

        public void Stop() 
        {
            try
            {
                bStoped = true;
                this.tRefreshFrame.Stop();
                Application.DoEvents();
                SendMessage(mCapHwnd, WM_CAP_DISCONNECT, 0, 0);
                CloseClipboard();
            }
            catch (Exception ex){ }
        }
        #endregion

        private void tRefreshFrame_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tRefreshFrame.Stop();

                ImageSize();
                SendMessage(mCapHwnd, WM_CAP_GET_FRAME, 0, 0);
                SendMessage(mCapHwnd, WM_CAP_COPY, 0, 0);
                OpenClipboard(mCapHwnd);
                IntPtr img = GetClipboardData(2);
                CloseClipboard();

                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m_Width, m_Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;

                g.DrawImage(Image.FromHbitmap(img), 0, 0, m_Width, m_Height);

                imgWebCam.Image = bmp;
                imgWebCam.Refresh();

                Application.DoEvents();

                if (!bStoped)
                    this.tRefreshFrame.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na captura da imagem: " + ex.Message);
                this.Stop();
            }
        }

        
       
    }
}
