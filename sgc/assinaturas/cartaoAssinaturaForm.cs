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
using Vintasoft.Twain;


namespace sgc.assinaturas
{
    public partial class cartaoAssinaturaForm : Form
    {
        private DataTable dados;
        private DataRow linha;
        private AssinaturasBLL assinaturaBLL;
        private Conexao con;
        private int idx;
        private int idxTotal;
        private char op;
        private CartaoAssinatura cartao;
        private Image imgOriginal;
        private Vintasoft.Twain.Device device;
        private Vintasoft.Twain.DeviceManager deviceManager;

        // Para acesso remoto

        public cartaoAssinaturaForm()
        {
            con = new Conexao(Dados.strConexao);
            assinaturaBLL = new AssinaturasBLL(con);
            dados = null;
            linha = null;
            idx = 0;
            idxTotal = 0;
            op = 'I';
            cartao = new CartaoAssinatura();

            TwainEnvironment.Register("Domingos Santos", "domsantos@gmail.com", "eoFCQlZLvJVmSx20kWI0zGQT8LdsdUpY7HrgTl+ZX/6eDVJVoWQj81oEhzguzfBRvZbg+GZfGEJHydk9rxEN5bcLuey5z+tVrPClUjgZqtcCXm5NDGLkJgB29Zz2ty5qPZcL6WRNMVyro5lSFGzpJ4n9xd5TOLuQ/c9zdmj0Olto");
            deviceManager = new Vintasoft.Twain.DeviceManager(this);
            
            InitializeComponent();
        }

        private void getScanner() {
            deviceManager.Open();
            for (int i = 0; i < deviceManager.Devices.Count; i++)
            {
                cbScanner.Items.Add(deviceManager.Devices[i].Info.ProductName);
            }
        }

        private void pesquisar()
        {

            if (op.Equals('P'))
            {
                if (!txNrCartao.Text.Equals(""))
                {
                    dados = assinaturaBLL.getCartaoPorArgumento(txNrCartao.Text.Trim().PadLeft(7,'0'), 1);
                    atualizaDados();
                    return;
                }

                if (!txNome.Text.Equals(""))
                {
                    dados = assinaturaBLL.getCartaoPorArgumento(txNome.Text, 3);
                    atualizaDados();
                    return;
                }
            }

        }

        private void atualizaDados() {
            if (dados != null)
            {
                if (dados.Rows.Count > 0)
                {
                    preencherCampos();
                    lbNrReg.Text = dados.Rows.Count.ToString();
                    idxTotal = dados.Rows.Count - 1;
                    op = 'U';
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado");
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
        }

        private void carregaImagem(String cartao, DateTime data)
        {
            if (cartao != "")
            {

                try
                {
                    MemoryStream ms;
                    byte[] imgByte = null;
                    assinatura.Image = null;

                    //grid[0, grid.CurrentRow.Index].Value.ToString();
                    imgByte = assinaturaBLL.getAssinatura(cartao, data);
                    ms = new MemoryStream(imgByte, 0, imgByte.Length);

                    ms.Write(imgByte, 0, imgByte.Length);
                    assinatura.Image = Image.FromStream(ms, true);
                    imgOriginal = assinatura.Image;
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro ao carregar Imagem\n" + ex.Message);
                }
            }
        }

        public void preencheGridAssinaturas(string nrCartao)
        {
            try
            {
                grid.DataSource = assinaturaBLL.getAssinaturas(nrCartao);
                grid.Columns[0].HeaderText = "Data Assinatura";

                if (grid.RowCount > 1)
                {

                    if (grid[0, grid.CurrentRow.Index].Value.ToString() != "")
                    {
                        DateTime data = Convert.ToDateTime(grid[0, grid.CurrentRow.Index].Value.ToString());
                        carregaImagem(txNrCartao.Text, data);
                    }
                }
            }
            finally { 
                
            }
        }

        private void carregaCartorio(int id=0) {

            cbCartorio.DataSource = assinaturaBLL.getCartoriosCombo();
            cbCartorio.DisplayMember = "nmCartorio";
            cbCartorio.ValueMember = "idCartorio";

            if (id != 0) {
                cbCartorio.SelectedValue = id;
            }
        }

        private void carregaTipoRG(int id = 0)
        {

            cbTipoRG.DataSource = assinaturaBLL.getTipoRGCombo();
            cbTipoRG.DisplayMember = "dsTipoRG";
            cbTipoRG.ValueMember = "cdTipoRG";

            if (id != 0)
            {
                cbTipoRG.SelectedValue = id;
            }
        }

        private void preencherCampos()
        {
            try
            {
                linha = dados.Rows[idx];

                txNrCartao.Text = linha["nrCartao"].ToString();
                txCPF.Text = linha["nrCPF"].ToString();
                txDtCadastro.Text = linha["dtCadastro"].ToString();
                txDtRenovacao.Text = linha["dtRenovacao"].ToString();
                txDataNasc.Text = linha["dtNascimento"].ToString();
                txNome.Text = linha["nmCartao"].ToString();
                txEndereco.Text = linha["dsEndereco"].ToString();
                txUF.Text = linha["sgUF"].ToString();
                txBairro.Text = linha["dsBairro"].ToString();
                txCidade.Text = linha["nmCidade"].ToString();
                txNrRG.Text = linha["nrRG"].ToString();
                txOrgExpRG.Text = linha["dsOrgaoExpRG"].ToString();
                txDataExpRG.Text = linha["dtExpRG"].ToString();
                txFones.Text = linha["nrFones"].ToString();
                cbCartorio.SelectedValue = Convert.ToInt32(linha["idCartorio"].ToString());

                if (!linha["cdTipoRG"].ToString().Equals(""))
                    cbTipoRG.SelectedValue = Convert.ToInt32(linha["cdTipoRG"].ToString());

                txObservacao.Text = cartao.DsObservacao = linha["dsObservacao"].ToString();
                txEmail.Text = linha["dsEmail"].ToString(); 
                txCEP.Text = linha["nrCEP"].ToString();


                cartao.NrCartao = linha["nrCartao"].ToString();
                cartao.NrCPF = linha["nrCPF"].ToString();

                cartao.DtCadastro = Convert.ToDateTime( linha["dtCadastro"].ToString());

                if (!linha["dtRenovacao"].ToString().Equals(""))
                    cartao.DtRenovacao = Convert.ToDateTime(linha["dtRenovacao"].ToString());

                if (!linha["dtNascimento"].ToString().Equals(""))
                    cartao.DtNascimento = Convert.ToDateTime(linha["dtNascimento"].ToString());

                cartao.IdEstadoCivil = Convert.ToInt32(linha["idEstadoCivil"].ToString());

                cartao.NmCartao = linha["nmCartao"].ToString();
                cartao.DsEndereco = linha["dsEndereco"].ToString();
                cartao.SgUF = linha["sgUF"].ToString();
                cartao.DsBairro = linha["dsBairro"].ToString();
                cartao.NmCidade =  linha["nmCidade"].ToString();
                cartao.NrRG = linha["nrRG"].ToString();
                cartao.DsOrgaoEmissor = linha["dsOrgaoExpRG"].ToString();
                
                if (!linha["dtExpRG"].ToString().Equals(""))
                    cartao.DtExpedicao = Convert.ToDateTime(linha["dtExpRG"].ToString());

                cartao.IdCartorio = Convert.ToInt32(linha["idCartorio"].ToString());
                cartao.DsObservacao = linha["dsObservacao"].ToString();
                if (!linha["cdTipoRG"].ToString().Equals(""))
                    cartao.CdTipoRG = Convert.ToInt32(linha["cdTipoRG"].ToString());

                cbEsrtadoCivil.SelectedValue = Convert.ToInt32(cartao.IdEstadoCivil.ToString());
                txProfissao.Text = linha["dsProfissao"].ToString();
                
                preencheGridAssinaturas(txNrCartao.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não há mas registros a exibir"+ ex.Message);

            }
        }

        private void limparCampos()
        {
            dados = null;
            txNrCartao.Text = "";
            txCPF.Text = "";
            txDtCadastro.Text = "";
            txDtRenovacao.Text = "";
            txDataNasc.Text = "";
            txNome.Text = "";
            txEndereco.Text = "";
            txUF.Text = "";
            txBairro.Text = "";
            txCidade.Text = "";
            txNrRG.Text = "";
            txOrgExpRG.Text = "";
            txDataExpRG.Text = "";
            txFones.Text = "";
            txObservacao.Text = "";
            lbNrReg.Text = "0";
            txNrCartao.Focus();
            carregaTipoRG();
            carregaCartorio();
        }

        private void setIdx(string op)
        {
            if(op.Equals("+"))
            {
                if (idxTotal <= idx)
                    idx = idxTotal;
                if (idxTotal >= idx)
                {
                    if (idx <= 0)
                    {
                        if (idx == 0)
                            idx++;
                        else
                            idx = 0;
                    }
                    else
                    {
                        if (idx >= idxTotal)
                            idx = idxTotal;
                        else
                            idx++;
                    }
                        
                }  
            }

            if(op.Equals("-"))
            {
                if (idxTotal <= idx)
                    idx = idxTotal;
                if (idxTotal >= idx)
                {
                    if (idx <= 0)
                    {
                        if (idx > 0)
                            idx--;
                        else
                            idx = 0;
                    }
                    else
                    {
                        if (idx > idxTotal)
                            idx = idxTotal;
                        else
                            idx--;
                    }
                }  
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            op = 'P';
            string arg = (Microsoft.VisualBasic.Interaction.InputBox("Nome do Cliente:", "Cartorio Conduru", "0", 150, 150));

            if (!arg.Equals("0"))
            {
                int result = 0;
                bool sucesso = Int32.TryParse(arg, out result);
                if (sucesso)
                {
                    txNrCartao.Text = arg;
                }
                else
                {
                    txNome.Text = arg;
                }

                pesquisar();
            }
            
        }

        private void btAvanca_Click(object sender, EventArgs e)
        {
            setIdx("+");
            preencherCampos();
        }

        private void btVoltar_Click(object sender, EventArgs e)
        {
            setIdx("-");
            preencherCampos();
        }


        private void cartaoAssinaturaForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.PageUp)
                btAvanca_Click(null, null);

            if (e.KeyCode == Keys.PageDown)
                btVoltar_Click(null, null);

            if (e.KeyCode == Keys.F10)
                this.Close();

            if (e.KeyCode == Keys.F6)
            {
                /*limparCampos();
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                op = 'P';*/
            }
            if (e.KeyCode == Keys.F8)
            {
                btCancelar_Click(null,null);
            }
            if (e.KeyCode == Keys.F4)
            {
                btSalvar_Click(null, null);
            }
            if (e.KeyCode == Keys.F2)
            {
                btEditar_Click(null, null);
            }
            
            if (e.KeyCode == Keys.Insert)
            {
                btNovo_Click(null, null);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                btPesquisar_Click(null,null);
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D1)
            {
                if (!groupBox1.Enabled)
                    MessageBox.Show("Habilite campos para pesquisa (F6)");
                else
                    txNrCartao.Focus();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D2)
            {
                if (!groupBox1.Enabled)
                    MessageBox.Show("Habilite campos para pesquisa (F8)");
                else
                    txCPF.Focus();
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D3)
            {
                if (!groupBox1.Enabled)
                    MessageBox.Show("Habilite campos para pesquisa (F8)");
                else
                    txNome.Focus();
            }
            
            
        }

        

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (op != 'I')
            {
                cartao.NrCartao = txNrCartao.Text;
                cartao.NmCartao = txNome.Text;
                cartao.NrCPF = utils.formatos.limpaStr(txCPF.Text);
                DateTime dTest = DateTime.MinValue;

                if (txDataNasc.Text.Equals("  /  /"))
                    cartao.DtNascimento = null;
                else
                {
                    if (DateTime.TryParse(txDataNasc.Text.Trim(), out dTest))
                    {
                        cartao.DtNascimento = DateTime.Parse(txDataNasc.Text);
                    }
                    else
                    {
                        MessageBox.Show("Data de Nascimento inválida!");
                        txDataNasc.Focus();
                        return;
                    }
                }

                //MessageBox.Show(lbDataCadastro.Text);
                if (txDtCadastro.Text.Equals(""))
                    cartao.DtCadastro = DateTime.Now;
                else
                {
                    if (DateTime.TryParse(txDtCadastro.Text.Trim(), out dTest))
                    {
                        cartao.DtCadastro = DateTime.Parse(txDtCadastro.Text);
                    }
                    else
                    {
                        MessageBox.Show("Data de Cadastro inválida!");
                        return;
                    }
                }
                cartao.NrRG = txNrRG.Text;
                cartao.DsOrgaoEmissor = txOrgExpRG.Text;

                if (txDataExpRG.Text.Equals("  /  /"))
                    cartao.DtExpedicao = null;
                else
                {
                    if (DateTime.TryParse(txDataExpRG.Text.Trim(), out dTest))
                    {
                        cartao.DtExpedicao = DateTime.Parse(txDataExpRG.Text);
                    }
                    else
                    {
                        MessageBox.Show("Data de expedição inválida!");
                        return;
                    }
                }
                cartao.DsEndereco = txEndereco.Text;
                cartao.DsBairro = txBairro.Text;
                cartao.NrCEP = txCEP.Text;
                cartao.NmCidade = txCidade.Text;
                cartao.SgUF = txUF.Text;
                cartao.TpCartao = 'C';
                cartao.NrFones = txFones.Text;


                if (op == 'N')
                {
                    cartao.DtRenovacao = null;
                    
                }
                else
                {
                    if (txDtRenovacao.Text.Equals("  /  /"))
                        cartao.DtRenovacao = null;
                    else
                    {
                        if (DateTime.TryParse(txDtRenovacao.Text.Trim(), out dTest))
                        {
                            cartao.DtRenovacao = DateTime.Parse(txDtRenovacao.Text);
                        }
                        else
                        {
                            MessageBox.Show("Data de renovação inválida!");
                            return;
                        }
                    }
                }

                
                cartao.IdCartorio = Convert.ToInt32(cbCartorio.SelectedValue);
                cartao.DsObservacao = txObservacao.Text;
                cartao.CdTipoRG = Convert.ToInt32(cbTipoRG.SelectedValue);
                cartao.DsEmail = txEmail.Text;
                cartao.IdEstadoCivil = Convert.ToInt32(cbEsrtadoCivil.SelectedValue);
                cartao.DsProfissao = txProfissao.Text;
                try
                {
                    assinaturaBLL.saveCartaoAssinatura(cartao, op);
                    txDtCadastro.Text = cartao.DtCadastro.ToString();
                    preencheGridAssinaturas(cartao.NrCartao);


                    MessageBox.Show("Cartão Salvo!");

                    panel1.BackColor = this.BackColor;
                    panel2.BackColor = this.BackColor;
                    op = 'I';
                    limparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar registro!\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Clique no botão Novo para iniciar o cadastro do Cartão.");
            }


        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if (dados != null || cartao.NrCartao != null)
            {
                if (dados.Rows.Count > 0)
                {
                    op = 'U';
                    groupBox1.BackColor = Color.BlanchedAlmond;
                    groupBox2.BackColor = Color.BlanchedAlmond;
                    txCPF.Focus();
                }
            }
            else
            {
                MessageBox.Show("Não há dados para edição!");
            }

        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            carregaCartorio();
            op = 'N';
            groupBox1.BackColor = Color.Azure;
            groupBox1.Enabled = true;
            groupBox2.BackColor = Color.Azure;
            groupBox2.Enabled = true;
            txNrCartao.Enabled = true;
            txNrCartao.Enabled = true;
            txNrCartao.Focus();
            txDtCadastro.Text = DateTime.Now.ToShortDateString();
        }

        private void grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grid[0, grid.CurrentRow.Index].Value.ToString() != "")
            {
                DateTime data = Convert.ToDateTime(grid[0, grid.CurrentRow.Index].Value.ToString());
                carregaImagem(txNrCartao.Text, data);
            }
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            assinatura.Top = (int)(assinatura.Top - (assinatura.Height * 0.025));
            assinatura.Left = (int)(assinatura.Left - (assinatura.Width * 0.025));
            assinatura.Height = (int)(assinatura.Height + (assinatura.Height * 0.05));
            assinatura.Width = (int)(assinatura.Width + (assinatura.Width * 0.05));
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            assinatura.Top = (int)(assinatura.Top + (assinatura.Height * 0.025));
            assinatura.Left = (int)(assinatura.Left + (assinatura.Width * 0.025));
            assinatura.Height = (int)(assinatura.Height - (assinatura.Height * 0.05));
            assinatura.Width = (int)(assinatura.Width - (assinatura.Width * 0.05));
        }


        public void buscaCartao() { 
            
            CartaoAssinatura cartao = assinaturaBLL.verificaCartao(txNrCartao.Text, "C");

            if (cartao != null)
            {
                String msg = "Cartão já atribuido a um cliente\nDeseja editar este registro?";
                DialogResult result = MessageBox.Show(msg, "Cartão de Assinatura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.ToString().Equals("Yes"))
                {

                    txNome.Text = cartao.NmCartao;
                    txCPF.Text = cartao.NrCPF;
                    txDtCadastro.Text = cartao.DtCadastro.ToString();
                    txDtRenovacao.Text = cartao.DtRenovacao.ToString();
                    txDataNasc.Text = cartao.DtNascimento.ToString();
                    txNrRG.Text = cartao.NrRG;
                    txOrgExpRG.Text = cartao.DsOrgaoEmissor;
                    txDataExpRG.Text = cartao.DtExpedicao.ToString();
                    txEndereco.Text = cartao.DsEndereco;
                    txBairro.Text = cartao.DsBairro;
                    txCEP.Text = cartao.NrCEP;
                    txUF.Text = cartao.SgUF;
                    txCidade.Text = cartao.NmCidade;
                    txFones.Text = cartao.NrFones;
                    btEditar_Click(null, null);

                    preencheGridAssinaturas(cartao.NrCartao);

                }
            }
        }

        private void txNrCartao_Leave(object sender, EventArgs e)
        {

            if (txNrCartao.Text != "")
            {
                string _cartao = txNrCartao.Text.Trim().PadLeft(7,'0');

                CartaoAssinatura cartao = assinaturaBLL.verificaCartao(_cartao);

                if (cartao != null)
                {
                    String msg = "Cartão já atribuido a um cliente\nDeseja renovar este Cartão?";
                    DialogResult result = MessageBox.Show(msg, "Cartão de Assinatura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result.ToString().Equals("Yes"))
                    {
                        txNrCartao.Text = txNrCartao.Text.PadLeft(7, '0');
                        txNome.Text = cartao.NmCartao;
                        txCPF.Text = cartao.NrCPF;
                        txDtCadastro.Text = cartao.DtCadastro.ToString();
                        txDtRenovacao.Text = cartao.DtRenovacao.ToString();
                        txDataNasc.Text = cartao.DtNascimento.ToString();
                        txNrRG.Text = cartao.NrRG;
                        txOrgExpRG.Text = cartao.DsOrgaoEmissor;
                        txDataExpRG.Text = cartao.DtExpedicao.ToString();
                        txEndereco.Text = cartao.DsEndereco;
                        txBairro.Text = cartao.DsBairro;
                        txCEP.Text = cartao.NrCEP;
                        txUF.Text = cartao.SgUF;
                        txCidade.Text = cartao.NmCidade;
                        txFones.Text = cartao.NrFones;
                        carregaCartorio(cartao.IdCartorio);
                        preencheGridAssinaturas(cartao.NrCartao);
                        carregaTipoRG(cartao.CdTipoRG);
                        txObservacao.Text = cartao.DsObservacao;
                        op = 'U';
                        txEmail.Text = cartao.DsEmail;
                        groupBox1.BackColor = Color.BlanchedAlmond;
                        groupBox2.BackColor = Color.BlanchedAlmond;
                        txCPF.Focus();
                    }

                }
                else {
                    //MessageBox.Show("Cartão já cadastrado!");
                    //pesquisar();
                }
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            dados = null;
            panel1.BackColor =  this.BackColor;
            panel2.BackColor = this.BackColor;
            assinatura.Image = null;
            grid.DataSource = null;
            op = 'I';
        }

        private void btInicioCap_Click(object sender, EventArgs e)
        {

            if (!txNrCartao.Text.Equals(""))
            {
                RGCartaoForm oRGCartaoForm = new RGCartaoForm(txNrCartao.Text);
                oRGCartaoForm.ShowDialog();
            }
            else {
                utils.MessagensExcept.funMsgSistema("Carregue um cadastro para exibir o RG",3);
            }
            
        }

        private void btFoto_Click(object sender, EventArgs e)
        {
            //imgWebCam.Stop();
        }

        private void btAddImagem_Click(object sender, EventArgs e)
        {

            TwainEnvironment.Register("Domingos Santos", "domsantos@gmail.com", "eoFCQlZLvJVmSx20kWI0zGQT8LdsdUpY7HrgTl+ZX/6eDVJVoWQj81oEhzguzfBRvZbg+GZfGEJHydk9rxEN5bcLuey5z+tVrPClUjgZqtcCXm5NDGLkJgB29Zz2ty5qPZcL6WRNMVyro5lSFGzpJ4n9xd5TOLuQ/c9zdmj0Olto");
            if (cbScanner.Text.Equals("")) {
                MessageBox.Show("Selecione um Scanner!");
                return;
            }
            
            if (cartao.NrCartao != null)
            {



                try
                {
                    deviceManager.Open();
                    deviceManager.Devices.CurrentIndex = cbScanner.SelectedIndex;
                    device = deviceManager.Devices.Current;
                    device.ShowUI = false;
                    device.ShowIndicators = true;
                    device.DisableAfterAcquire = true;
                    device.TransferMode = TransferMode.Memory;
                    device.FileFormat = TwainImageFileFormat.Jpeg;
                    device.Open();
                    device.PixelType = PixelType.Gray;
                    device.UnitOfMeasure = UnitOfMeasure.Inches;
                    device.Resolution = new Resolution(200f, 200f);
                    device.ImageLayout.Set(0f, 2.9f, 4.72f, 2.7f);

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
                        byte[] imageByte = (byte[])msImg.GetBuffer();  //img.FileData.get_BinaryData();

                        
                        Assinatura oAssinatura = new Assinatura();
                        oAssinatura.NrCartao = txNrCartao.Text.PadLeft(7, '0');
                        oAssinatura.DtAssnatura = DateTime.Now;
                        oAssinatura.BiAssinatura = imageByte;

                        assinaturaBLL.addAssinatura(oAssinatura);
                        preencheGridAssinaturas(txNrCartao.Text.PadLeft(7, '0'));

                        Image imagem = Image.FromStream(msImg);
                        assinatura.Image = imagem;
                        txDtRenovacao.Text = oAssinatura.DtAssnatura.ToString();
                    }
                    catch (Exception ex)
                    {
                        utils.MessagensExcept.funMsgSistema("Erro ao digitalizar imagem!\n"+ex.Message,1);
                    }

                }
                catch (Exception exd)
                {
                    utils.MessagensExcept.funMsgSistema("Erro ao conectar com scanner!\n"+exd.Message,1);
                }
                finally {
                    deviceManager.Close();
                }
                
            }
        }

        private void cartaoAssinaturaForm_Load(object sender, EventArgs e)
        {
            getScanner();
            carregaTipoRG();
            carregaCartorio();
            carregaEstadoCivil();
            
            string arg = (Microsoft.VisualBasic.Interaction.InputBox("Nome do Cliente:", "Cartorio Conduru", "0", 150, 150));

            if (!arg.Equals("0"))
            {
                int result = 0;
                bool sucesso = Int32.TryParse(arg, out result);


                if (sucesso)
                {
                    txNrCartao.Text = arg;
                }
                else
                {
                    txNome.Text = arg;
                }
                op = 'P';

                pesquisar();
            }
            
        }

        private void txCPF_Leave(object sender, EventArgs e)
        {
            if (op.Equals('I'))
            {
                if (utils.formatos.limpaStr(txCPF.Text).Trim().Length > 0)
                {
                    dados = assinaturaBLL.getCartaoPorArgumento(utils.formatos.limpaStr(txCPF.Text), 2);
                    atualizaDados();
                    return;
                }
            }
        }

        private void btDelImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja apagar esta imagem?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
                {
                    DateTime data = Convert.ToDateTime(grid[0, grid.CurrentRow.Index].Value.ToString());
                    assinaturaBLL.apagaAssinatura(data, txNrCartao.Text.PadLeft(7, '0'));
                    MessageBox.Show("Assinatura apagada!");
                    preencheGridAssinaturas(txNrCartao.Text);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao apagar assinatura\n" + ex.Message);
            }
        }

        private void cartaoAssinaturaForm_Shown(object sender, EventArgs e)
        {
            if (op.Equals('I'))
            {
                txNrCartao.Focus();
            }
            else {
                txCPF.Focus();
            }
        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja apagar este Cartão?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().Equals("Yes"))
                {
                    assinaturaBLL.delCartaoAssinatura(txNrCartao.Text);
                    utils.MessagensExcept.funMsgSistema("Cartão Apagado",2);
                    limparCampos();
                }
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro ao apagar Cartão\n" + ex.Message,1);
            }

        }

        private void btCartaoPrint_Click(object sender, EventArgs e)
        {
            if (!txNrCartao.Text.Equals("")) {
                ImpressaoCartaoForm oImpressaoCartaoForm = new ImpressaoCartaoForm(txNrCartao.Text);
                oImpressaoCartaoForm.ShowDialog();
            } else {
                utils.MessagensExcept.funMsgSistema("Informe um cartão para ser impresso", 2);
            }
        }

        private void carregaEstadoCivil(int id = 0) {
            try
            {
                cbEsrtadoCivil.DataSource = assinaturaBLL.getEstadoCivil();
                cbEsrtadoCivil.DisplayMember = "dsEstadoCivil";
                cbEsrtadoCivil.ValueMember = "idEstadoCivil";
                
                if (id != 0)
                {
                    cbEsrtadoCivil.SelectedValue = id;
                }
            }
            catch (Exception ex) {
                utils.MessagensExcept.funMsgSistema("Erro: "+ex.Message,1);
            }
        }
    }
}
