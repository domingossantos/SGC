using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using Modelos;
using BLL;
using DAO;
using Vintasoft.Twain;

namespace sgc.assinaturas
{
    public partial class scannerLoteForm : Form
    {
        private AssinaturasBLL assinaturaBLL;
        private Conexao con;
        private CartaoAssinatura cartao;
        private Image imgOriginal;
        private Device device;
        private DeviceManager deviceManager;
        private DataTable cartoes = new DataTable();

        public scannerLoteForm()
        {
            con = new Conexao(Dados.strConexao);
            assinaturaBLL = new AssinaturasBLL(con);
            cartao = new CartaoAssinatura();
            TwainEnvironment.Register("Domingos Santos", "domsantos@gmail.com", "eoFCQlZLvJVmSx20kWI0zGQT8LdsdUpY7HrgTl+ZX/6eDVJVoWQj81oEhzguzfBRvZbg+GZfGEJHydk9rxEN5bcLuey5z+tVrPClUjgZqtcCXm5NDGLkJgB29Zz2ty5qPZcL6WRNMVyro5lSFGzpJ4n9xd5TOLuQ/c9zdmj0Olto");
            deviceManager = new Vintasoft.Twain.DeviceManager(this);
            InitializeComponent();
            
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            if (txIni.Text.Equals("")) {
                MessageBox.Show("Informe o primeiro cartão!");
                txIni.Focus();
                return;
            }
            if (txFim.Text.Equals(""))
            {
                MessageBox.Show("Informe o último cartão!");
                txFim.Focus();
                return;
            }

            grid.DataSource = assinaturaBLL.getCartoes(txIni.Text, txFim.Text);
        }

        private void scannear(string nrCartao) {

            try
            {

                deviceManager.Open();

                deviceManager.Devices.CurrentIndex = cbScanner.SelectedIndex;
                device = deviceManager.Devices.Current;
                device.ShowUI = true;
                device.TransferMode = TransferMode.Memory;

                device.Open();

                System.IO.MemoryStream msImg = null;

                AcquireModalState acquireModalState = AcquireModalState.None;
                do
                {
                    acquireModalState = device.AcquireModal();
                    switch (acquireModalState)
                    {
                        case AcquireModalState.ImageAcquired:
                            msImg = device.AcquiredImages.Last.GetAsStream(ImageFileFormat.BMP);
                            fechaScanner(device, deviceManager);
                            break;
                        case AcquireModalState.ScanCompleted:
                            fechaScanner(device, deviceManager);
                            break;
                        case AcquireModalState.ScanCanceled:
                            fechaScanner(device, deviceManager);
                            break;
                        case AcquireModalState.ScanFailed:
                            fechaScanner(device, deviceManager);
                            break;
                    }
                }
                while (acquireModalState != AcquireModalState.None);

                byte[] imageByte = (byte[])msImg.GetBuffer();

                Assinatura oAssinatura = new Assinatura();
                oAssinatura.NrCartao = nrCartao;
                oAssinatura.DtAssnatura = DateTime.Now;
                oAssinatura.BiAssinatura = imageByte;

                assinaturaBLL.addAssinatura(oAssinatura);
                Image imagem = Image.FromStream(msImg);
                MessageBox.Show("Assinatura gravada.\nColoque o Proximo Cartão e precione OK.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao digitalizar imagem!\n" + ex.Message);
            }
            finally {

                fechaScanner(device,deviceManager);
            }
            //}
        }

        private void fechaScanner(Device _device,DeviceManager _deviceManager)
        {

            if (_device.State == DeviceState.Opened)
            {
                _device.Close();
            }

            if (_deviceManager.State == DeviceManagerState.Opened)
            {
                _deviceManager.Close();
            }
        }

        private void btScanner_Click(object sender, EventArgs e)
        {
            if (grid.RowCount <= 0) {
                MessageBox.Show("Não há cartões para scannear!");
                return;
            }

            if (cbScanner.Text.Equals("")) {
                MessageBox.Show("Selecione um Scanner!");
                return;
            }

            for (int i = 0; i < (grid.RowCount - 1); i++)
            {
                
                lbCartao.Text = grid[0, i].Value.ToString();
                cartao = assinaturaBLL.getCartao(lbCartao.Text);

                if (cartao != null)
                {
                    MessageBox.Show("Iniciando a digitalização do cartão "+lbCartao.Text);
                    lbNome.Text = cartao.NmCartao;
                    scannear(cartao.NrCartao);
                }
                else {
                    MessageBox.Show("Cartão No. " + lbCartao.Text + " não existente");
                }

            }

            MessageBox.Show("O processo de scanner em lote terminou!");
        }

        private void scannerLoteForm_Load(object sender, EventArgs e)
        {
            //TwainEnvironment.Register("Domingos Santos", "domsantos@gmail.com", "eoFCQlZLvJVmSx20kWI0zGQT8LdsdUpY7HrgTl+ZX/6eDVJVoWQj81oEhzguzfBRvZbg+GZfGEJHydk9rxEN5bcLuey5z+tVrPClUjgZqtcCXm5NDGLkJgB29Zz2ty5qPZcL6WRNMVyro5lSFGzpJ4n9xd5TOLuQ/c9zdmj0Olto");
            deviceManager.Open();
            for (int i = 0; i < deviceManager.Devices.Count; i++)
            {
                cbScanner.Items.Add(deviceManager.Devices[i].Info.ProductName);
            }
            deviceManager.Close();

            cartoes.Columns.Add("Cartao", typeof(string));

        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            cartoes.Rows.Add(txIni.Text);

            grid.DataSource = cartoes;
            txIni.Text = "";
            txIni.Focus();
        }
    }
}
