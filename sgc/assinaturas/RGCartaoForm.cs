using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BLL;
using DAO;
using Vintasoft.Twain;

namespace sgc.assinaturas
{
    public partial class RGCartaoForm : Form
    {
        private String nrCartao;
        private Conexao con;
        private AssinaturasBLL assinaturaBLL;
        private byte[] imageByte;
        private Vintasoft.Twain.Device device;
        private Vintasoft.Twain.DeviceManager deviceManager;
        public RGCartaoForm(String _nrCartao)
        {
            nrCartao = _nrCartao;
            
            con = new Conexao(Dados.strConexao);
            assinaturaBLL = new AssinaturasBLL(con);
            imageByte = null;
            TwainEnvironment.Register("Domingos Santos", "domsantos@gmail.com", "eoFCQlZLvJVmSx20kWI0zGQT8LdsdUpY7HrgTl+ZX/6eDVJVoWQj81oEhzguzfBRvZbg+GZfGEJHydk9rxEN5bcLuey5z+tVrPClUjgZqtcCXm5NDGLkJgB29Zz2ty5qPZcL6WRNMVyro5lSFGzpJ4n9xd5TOLuQ/c9zdmj0Olto");
            deviceManager = new Vintasoft.Twain.DeviceManager(this);
            InitializeComponent();
            this.Text = this.Text + nrCartao;
        }

        private void RGCartaoForm_Load(object sender, EventArgs e)
        {
            carregaImagem(pbxRG1, 1);
            carregaImagem(pbxRG2, 2);
            getScanner();
        }

        private void getScanner()
        {
            deviceManager.Open();
            for (int i = 0; i < deviceManager.Devices.Count; i++)
            {
                cbScanner.Items.Add(deviceManager.Devices[i].Info.ProductName);
            }
        }

        private void digitalizar(sbyte lado) {
            TwainEnvironment.Register("Domingos Santos", "domsantos@gmail.com", "eoFCQlZLvJVmSx20kWI0zGQT8LdsdUpY7HrgTl+ZX/6eDVJVoWQj81oEhzguzfBRvZbg+GZfGEJHydk9rxEN5bcLuey5z+tVrPClUjgZqtcCXm5NDGLkJgB29Zz2ty5qPZcL6WRNMVyro5lSFGzpJ4n9xd5TOLuQ/c9zdmj0Olto");

            try
            {
                deviceManager.Open();
                deviceManager.Devices.CurrentIndex = cbScanner.SelectedIndex;
                device = deviceManager.Devices.Current;
                device.ShowUI = true;
                //device.ShowIndicators = false;
                //device.DisableAfterAcquire = true;


                device.TransferMode = TransferMode.Memory;
                device.FileFormat = TwainImageFileFormat.Jpeg;
                device.Open();
                device.PixelType = PixelType.Gray;
                device.UnitOfMeasure = UnitOfMeasure.Inches;
                device.Resolution = new Resolution(200f, 200f);
                //device.ImageLayout.Set(1f, 1f, 4f, 3f);

                System.IO.MemoryStream msImg = null;


                AcquireModalState acquireModalState = AcquireModalState.None;
                do
                {
                    acquireModalState = device.AcquireModal();
                    switch (acquireModalState)
                    {
                        case AcquireModalState.ImageAcquired:
                            msImg = device.AcquiredImages.Last.GetAsStream(ImageFileFormat.JPEG);
                            break;
                        case AcquireModalState.ScanCompleted:
                            device.Close();
                            deviceManager.Close();
                            break;
                        case AcquireModalState.ScanCanceled:
                            device.Close();
                            deviceManager.Close();
                            break;
                        case AcquireModalState.ScanFailed:
                            device.Close();
                            deviceManager.Close();
                            break;
                    }
                }
                while (acquireModalState != AcquireModalState.None);

                try
                {
                    imageByte = (byte[])msImg.GetBuffer();  //img.FileData.get_BinaryData();

                    if (imageByte != null)
                    {
                        String campo = "biRGFrente";

                        if (lado == 2) {
                            campo = "biRGVerso";
                        }
                        assinaturaBLL.salvaRgCartao(nrCartao, campo, imageByte);
                        utils.MessagensExcept.funMsgSistema("Imagem Salva!" , 2);
                    }

                }
                catch (Exception ex)
                {
                    utils.MessagensExcept.funMsgSistema("Erro ao digitalizar imagem!\n" + ex.Message, 1);
                }

            }
            catch (Exception exd)
            {
                utils.MessagensExcept.funMsgSistema("Erro ao conectar com scanner!\n" + exd.Message, 1);
            }
            finally
            {
                deviceManager.Close();
            }

        }

        private void carregaImagem(PictureBox img, sbyte lado) {
            try
            {
                MemoryStream ms;
                byte[] imgByte = null;
                img.Image = null;
                String campoLado = "biRGFrente";

                if (lado == 2)
                {
                    campoLado = "biRGVerso";
                }

                imgByte = assinaturaBLL.getRG(nrCartao, campoLado);
                if (imgByte != null)
                {
                    ms = new MemoryStream(imgByte, 0, imgByte.Length);

                    ms.Write(imgByte, 0, imgByte.Length);
                    img.Image = Image.FromStream(ms, true);
                }
                else {
                    img.Image = Image.FromFile(utils.sessao.PathApp + "\\no-img.jpg");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Imagem\n" + ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRG1_Click(object sender, EventArgs e)
        {
            digitalizar(1);
            carregaImagem(pbxRG1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            digitalizar(2);
            carregaImagem(pbxRG2, 2);
        }
    }
}
