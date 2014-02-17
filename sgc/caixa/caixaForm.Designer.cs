namespace sgc.caixa
{
    partial class caixaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btRetiradas = new System.Windows.Forms.Button();
            this.btDesconto = new System.Windows.Forms.Button();
            this.btReimprimir = new System.Windows.Forms.Button();
            this.btFecharCaixa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbEscritura = new System.Windows.Forms.GroupBox();
            this.btVerificaSaldo = new System.Windows.Forms.Button();
            this.txNrEscritura = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btProcurarPedido = new System.Windows.Forms.Button();
            this.txUltmoPedido = new System.Windows.Forms.TextBox();
            this.ckPedidosMulti = new System.Windows.Forms.CheckBox();
            this.gbDesconto = new System.Windows.Forms.GroupBox();
            this.brGravarDesc = new System.Windows.Forms.Button();
            this.btCancelarDesc = new System.Windows.Forms.Button();
            this.txSenha = new System.Windows.Forms.TextBox();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.txValorDesconto = new System.Windows.Forms.TextBox();
            this.lvTipoDesconto = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.rbTipoPercent = new System.Windows.Forms.RadioButton();
            this.rbTipoDinheiro = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbPedidos = new System.Windows.Forms.Label();
            this.gbCheque = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txRG = new System.Windows.Forms.TextBox();
            this.txNrCheque = new System.Windows.Forms.TextBox();
            this.txDtResgate = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txContaCorrente = new System.Windows.Forms.TextBox();
            this.txAgencia = new System.Windows.Forms.TextBox();
            this.txBanco = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbCorrentista = new System.Windows.Forms.GroupBox();
            this.cbCorrentista = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDeposito = new System.Windows.Forms.RadioButton();
            this.rbClienteEscritura = new System.Windows.Forms.RadioButton();
            this.rbCheque = new System.Windows.Forms.RadioButton();
            this.rbCorrentista = new System.Windows.Forms.RadioButton();
            this.rbDinheiro = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btProcurar = new System.Windows.Forms.Button();
            this.txPedido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btPagamento = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txTotal = new System.Windows.Forms.TextBox();
            this.txDesconto = new System.Windows.Forms.TextBox();
            this.txTroco = new System.Windows.Forms.TextBox();
            this.txPago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbEscritura.SuspendLayout();
            this.gbDesconto.SuspendLayout();
            this.gbCheque.SuspendLayout();
            this.gbCorrentista.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btRetiradas);
            this.panel1.Controls.Add(this.btDesconto);
            this.panel1.Controls.Add(this.btReimprimir);
            this.panel1.Controls.Add(this.btFecharCaixa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 51);
            this.panel1.TabIndex = 15;
            // 
            // btRetiradas
            // 
            this.btRetiradas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btRetiradas.Image = global::sgc.Properties.Resources.evolution_tasks;
            this.btRetiradas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRetiradas.Location = new System.Drawing.Point(535, 4);
            this.btRetiradas.Name = "btRetiradas";
            this.btRetiradas.Size = new System.Drawing.Size(187, 41);
            this.btRetiradas.TabIndex = 3;
            this.btRetiradas.Text = "Entradas/Retiradas (Ctrl + O)";
            this.btRetiradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRetiradas.UseVisualStyleBackColor = false;
            this.btRetiradas.Click += new System.EventHandler(this.btRetiradas_Click);
            // 
            // btDesconto
            // 
            this.btDesconto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btDesconto.Image = global::sgc.Properties.Resources.bnvn;
            this.btDesconto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDesconto.Location = new System.Drawing.Point(363, 4);
            this.btDesconto.Name = "btDesconto";
            this.btDesconto.Size = new System.Drawing.Size(166, 43);
            this.btDesconto.TabIndex = 2;
            this.btDesconto.Text = "Uso Interno (F5)";
            this.btDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDesconto.UseVisualStyleBackColor = false;
            this.btDesconto.Click += new System.EventHandler(this.btDesconto_Click);
            // 
            // btReimprimir
            // 
            this.btReimprimir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btReimprimir.Image = global::sgc.Properties.Resources.printer1;
            this.btReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReimprimir.Location = new System.Drawing.Point(178, 4);
            this.btReimprimir.Name = "btReimprimir";
            this.btReimprimir.Size = new System.Drawing.Size(179, 43);
            this.btReimprimir.TabIndex = 1;
            this.btReimprimir.Text = "Reimprimir Recibo (Ctrl + R)";
            this.btReimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReimprimir.UseVisualStyleBackColor = false;
            this.btReimprimir.Click += new System.EventHandler(this.btReimprimir_Click);
            // 
            // btFecharCaixa
            // 
            this.btFecharCaixa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btFecharCaixa.Image = global::sgc.Properties.Resources.window_close;
            this.btFecharCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFecharCaixa.Location = new System.Drawing.Point(3, 4);
            this.btFecharCaixa.Name = "btFecharCaixa";
            this.btFecharCaixa.Size = new System.Drawing.Size(165, 43);
            this.btFecharCaixa.TabIndex = 0;
            this.btFecharCaixa.Text = "Fechar Caixa (F2)";
            this.btFecharCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFecharCaixa.UseVisualStyleBackColor = false;
            this.btFecharCaixa.Click += new System.EventHandler(this.btFecharCaixa_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.gbEscritura);
            this.panel2.Controls.Add(this.btProcurarPedido);
            this.panel2.Controls.Add(this.txUltmoPedido);
            this.panel2.Controls.Add(this.ckPedidosMulti);
            this.panel2.Controls.Add(this.gbDesconto);
            this.panel2.Controls.Add(this.lbPedidos);
            this.panel2.Controls.Add(this.gbCheque);
            this.panel2.Controls.Add(this.gbCorrentista);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btProcurar);
            this.panel2.Controls.Add(this.txPedido);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btPagamento);
            this.panel2.Controls.Add(this.grid);
            this.panel2.Controls.Add(this.txTotal);
            this.panel2.Controls.Add(this.txDesconto);
            this.panel2.Controls.Add(this.txTroco);
            this.panel2.Controls.Add(this.txPago);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 454);
            this.panel2.TabIndex = 16;
            // 
            // gbEscritura
            // 
            this.gbEscritura.Controls.Add(this.btVerificaSaldo);
            this.gbEscritura.Controls.Add(this.txNrEscritura);
            this.gbEscritura.Controls.Add(this.label18);
            this.gbEscritura.Location = new System.Drawing.Point(166, 379);
            this.gbEscritura.Name = "gbEscritura";
            this.gbEscritura.Size = new System.Drawing.Size(304, 69);
            this.gbEscritura.TabIndex = 36;
            this.gbEscritura.TabStop = false;
            this.gbEscritura.Text = "Pagamento Escritura";
            this.gbEscritura.Visible = false;
            // 
            // btVerificaSaldo
            // 
            this.btVerificaSaldo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btVerificaSaldo.Image = global::sgc.Properties.Resources.addressbook_search;
            this.btVerificaSaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerificaSaldo.Location = new System.Drawing.Point(166, 33);
            this.btVerificaSaldo.Name = "btVerificaSaldo";
            this.btVerificaSaldo.Size = new System.Drawing.Size(123, 30);
            this.btVerificaSaldo.TabIndex = 2;
            this.btVerificaSaldo.Text = "Verificar Saldo";
            this.btVerificaSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btVerificaSaldo.UseVisualStyleBackColor = false;
            this.btVerificaSaldo.Click += new System.EventHandler(this.btVerificaSaldo_Click);
            // 
            // txNrEscritura
            // 
            this.txNrEscritura.Location = new System.Drawing.Point(13, 43);
            this.txNrEscritura.Name = "txNrEscritura";
            this.txNrEscritura.Size = new System.Drawing.Size(100, 20);
            this.txNrEscritura.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Nº da Escritura";
            // 
            // btProcurarPedido
            // 
            this.btProcurarPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btProcurarPedido.Image = global::sgc.Properties.Resources.search;
            this.btProcurarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btProcurarPedido.Location = new System.Drawing.Point(677, 259);
            this.btProcurarPedido.Name = "btProcurarPedido";
            this.btProcurarPedido.Size = new System.Drawing.Size(84, 26);
            this.btProcurarPedido.TabIndex = 35;
            this.btProcurarPedido.Text = "Procurar";
            this.btProcurarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btProcurarPedido.UseVisualStyleBackColor = false;
            this.btProcurarPedido.Visible = false;
            this.btProcurarPedido.Click += new System.EventHandler(this.btProcurarPedido_Click);
            // 
            // txUltmoPedido
            // 
            this.txUltmoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txUltmoPedido.Location = new System.Drawing.Point(571, 259);
            this.txUltmoPedido.Name = "txUltmoPedido";
            this.txUltmoPedido.Size = new System.Drawing.Size(100, 26);
            this.txUltmoPedido.TabIndex = 34;
            this.txUltmoPedido.Visible = false;
            this.txUltmoPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txUltmoPedido_KeyPress);
            // 
            // ckPedidosMulti
            // 
            this.ckPedidosMulti.AutoSize = true;
            this.ckPedidosMulti.Location = new System.Drawing.Point(571, 243);
            this.ckPedidosMulti.Name = "ckPedidosMulti";
            this.ckPedidosMulti.Size = new System.Drawing.Size(152, 17);
            this.ckPedidosMulti.TabIndex = 33;
            this.ckPedidosMulti.Text = "Pedidos Multiplos (Ctrl + N)";
            this.ckPedidosMulti.UseVisualStyleBackColor = true;
            this.ckPedidosMulti.CheckedChanged += new System.EventHandler(this.ckPedidosMulti_CheckedChanged);
            this.ckPedidosMulti.Click += new System.EventHandler(this.ckPedidosMulti_Click);
            // 
            // gbDesconto
            // 
            this.gbDesconto.BackColor = System.Drawing.Color.Gainsboro;
            this.gbDesconto.Controls.Add(this.brGravarDesc);
            this.gbDesconto.Controls.Add(this.btCancelarDesc);
            this.gbDesconto.Controls.Add(this.txSenha);
            this.gbDesconto.Controls.Add(this.txLogin);
            this.gbDesconto.Controls.Add(this.txValorDesconto);
            this.gbDesconto.Controls.Add(this.lvTipoDesconto);
            this.gbDesconto.Controls.Add(this.label16);
            this.gbDesconto.Controls.Add(this.rbTipoPercent);
            this.gbDesconto.Controls.Add(this.rbTipoDinheiro);
            this.gbDesconto.Controls.Add(this.label15);
            this.gbDesconto.Controls.Add(this.label14);
            this.gbDesconto.Controls.Add(this.label13);
            this.gbDesconto.Location = new System.Drawing.Point(368, 37);
            this.gbDesconto.Margin = new System.Windows.Forms.Padding(10);
            this.gbDesconto.Name = "gbDesconto";
            this.gbDesconto.Padding = new System.Windows.Forms.Padding(5);
            this.gbDesconto.Size = new System.Drawing.Size(298, 186);
            this.gbDesconto.TabIndex = 0;
            this.gbDesconto.TabStop = false;
            this.gbDesconto.Text = "Autorizar Uso Interno";
            this.gbDesconto.Visible = false;
            // 
            // brGravarDesc
            // 
            this.brGravarDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.brGravarDesc.Image = global::sgc.Properties.Resources.accept;
            this.brGravarDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brGravarDesc.Location = new System.Drawing.Point(170, 137);
            this.brGravarDesc.Name = "brGravarDesc";
            this.brGravarDesc.Size = new System.Drawing.Size(109, 40);
            this.brGravarDesc.TabIndex = 11;
            this.brGravarDesc.Text = "Confirmar";
            this.brGravarDesc.UseVisualStyleBackColor = false;
            this.brGravarDesc.Click += new System.EventHandler(this.brGravarDesc_Click);
            // 
            // btCancelarDesc
            // 
            this.btCancelarDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelarDesc.Image = global::sgc.Properties.Resources.delete;
            this.btCancelarDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelarDesc.Location = new System.Drawing.Point(21, 137);
            this.btCancelarDesc.Name = "btCancelarDesc";
            this.btCancelarDesc.Size = new System.Drawing.Size(113, 40);
            this.btCancelarDesc.TabIndex = 10;
            this.btCancelarDesc.Text = "Cancelar";
            this.btCancelarDesc.UseVisualStyleBackColor = false;
            this.btCancelarDesc.Click += new System.EventHandler(this.btCancelarDesc_Click);
            // 
            // txSenha
            // 
            this.txSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSenha.Location = new System.Drawing.Point(167, 35);
            this.txSenha.Name = "txSenha";
            this.txSenha.PasswordChar = '*';
            this.txSenha.Size = new System.Drawing.Size(100, 26);
            this.txSenha.TabIndex = 9;
            // 
            // txLogin
            // 
            this.txLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLogin.Location = new System.Drawing.Point(11, 35);
            this.txLogin.Name = "txLogin";
            this.txLogin.Size = new System.Drawing.Size(100, 26);
            this.txLogin.TabIndex = 8;
            // 
            // txValorDesconto
            // 
            this.txValorDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txValorDesconto.Location = new System.Drawing.Point(167, 90);
            this.txValorDesconto.Name = "txValorDesconto";
            this.txValorDesconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txValorDesconto.Size = new System.Drawing.Size(100, 26);
            this.txValorDesconto.TabIndex = 7;
            this.txValorDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txValorDesconto_KeyDown);
            this.txValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txValorDesconto_KeyPress);
            // 
            // lvTipoDesconto
            // 
            this.lvTipoDesconto.AutoSize = true;
            this.lvTipoDesconto.Location = new System.Drawing.Point(227, 73);
            this.lvTipoDesconto.Name = "lvTipoDesconto";
            this.lvTipoDesconto.Size = new System.Drawing.Size(21, 13);
            this.lvTipoDesconto.TabIndex = 6;
            this.lvTipoDesconto.Text = "R$";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(169, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Valor Em:";
            // 
            // rbTipoPercent
            // 
            this.rbTipoPercent.AutoSize = true;
            this.rbTipoPercent.Location = new System.Drawing.Point(23, 116);
            this.rbTipoPercent.Name = "rbTipoPercent";
            this.rbTipoPercent.Size = new System.Drawing.Size(76, 17);
            this.rbTipoPercent.TabIndex = 4;
            this.rbTipoPercent.Text = "Percentual";
            this.rbTipoPercent.UseVisualStyleBackColor = true;
            // 
            // rbTipoDinheiro
            // 
            this.rbTipoDinheiro.AutoSize = true;
            this.rbTipoDinheiro.Checked = true;
            this.rbTipoDinheiro.Location = new System.Drawing.Point(23, 92);
            this.rbTipoDinheiro.Name = "rbTipoDinheiro";
            this.rbTipoDinheiro.Size = new System.Drawing.Size(64, 17);
            this.rbTipoDinheiro.TabIndex = 3;
            this.rbTipoDinheiro.TabStop = true;
            this.rbTipoDinheiro.Text = "Dinheiro";
            this.rbTipoDinheiro.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Tipo Desconto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(169, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Senha";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Usuário";
            // 
            // lbPedidos
            // 
            this.lbPedidos.AutoSize = true;
            this.lbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPedidos.Location = new System.Drawing.Point(385, 264);
            this.lbPedidos.Name = "lbPedidos";
            this.lbPedidos.Size = new System.Drawing.Size(20, 17);
            this.lbPedidos.TabIndex = 29;
            this.lbPedidos.Text = "0;";
            // 
            // gbCheque
            // 
            this.gbCheque.Controls.Add(this.label17);
            this.gbCheque.Controls.Add(this.txRG);
            this.gbCheque.Controls.Add(this.txNrCheque);
            this.gbCheque.Controls.Add(this.txDtResgate);
            this.gbCheque.Controls.Add(this.label12);
            this.gbCheque.Controls.Add(this.label11);
            this.gbCheque.Controls.Add(this.txContaCorrente);
            this.gbCheque.Controls.Add(this.txAgencia);
            this.gbCheque.Controls.Add(this.txBanco);
            this.gbCheque.Controls.Add(this.label10);
            this.gbCheque.Controls.Add(this.label9);
            this.gbCheque.Controls.Add(this.label8);
            this.gbCheque.Location = new System.Drawing.Point(487, 292);
            this.gbCheque.Name = "gbCheque";
            this.gbCheque.Size = new System.Drawing.Size(274, 156);
            this.gbCheque.TabIndex = 32;
            this.gbCheque.TabStop = false;
            this.gbCheque.Text = "Cheque";
            this.gbCheque.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(138, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "No. RG";
            // 
            // txRG
            // 
            this.txRG.Location = new System.Drawing.Point(136, 120);
            this.txRG.Name = "txRG";
            this.txRG.Size = new System.Drawing.Size(100, 20);
            this.txRG.TabIndex = 10;
            // 
            // txNrCheque
            // 
            this.txNrCheque.Location = new System.Drawing.Point(136, 83);
            this.txNrCheque.Name = "txNrCheque";
            this.txNrCheque.Size = new System.Drawing.Size(100, 20);
            this.txNrCheque.TabIndex = 9;
            // 
            // txDtResgate
            // 
            this.txDtResgate.Location = new System.Drawing.Point(9, 120);
            this.txDtResgate.Mask = "00/00/0000";
            this.txDtResgate.Name = "txDtResgate";
            this.txDtResgate.Size = new System.Drawing.Size(100, 20);
            this.txDtResgate.TabIndex = 8;
            this.txDtResgate.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Data Resgate/Deposito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "No. Cheque";
            // 
            // txContaCorrente
            // 
            this.txContaCorrente.Location = new System.Drawing.Point(9, 81);
            this.txContaCorrente.Name = "txContaCorrente";
            this.txContaCorrente.Size = new System.Drawing.Size(100, 20);
            this.txContaCorrente.TabIndex = 5;
            // 
            // txAgencia
            // 
            this.txAgencia.Location = new System.Drawing.Point(136, 39);
            this.txAgencia.Name = "txAgencia";
            this.txAgencia.Size = new System.Drawing.Size(68, 20);
            this.txAgencia.TabIndex = 4;
            // 
            // txBanco
            // 
            this.txBanco.Location = new System.Drawing.Point(9, 35);
            this.txBanco.Name = "txBanco";
            this.txBanco.Size = new System.Drawing.Size(100, 20);
            this.txBanco.TabIndex = 3;
            this.txBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txBanco_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Agencia";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "No. Conta Corrente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "No. Banco";
            // 
            // gbCorrentista
            // 
            this.gbCorrentista.Controls.Add(this.cbCorrentista);
            this.gbCorrentista.Controls.Add(this.label7);
            this.gbCorrentista.Location = new System.Drawing.Point(166, 292);
            this.gbCorrentista.Name = "gbCorrentista";
            this.gbCorrentista.Size = new System.Drawing.Size(304, 80);
            this.gbCorrentista.TabIndex = 31;
            this.gbCorrentista.TabStop = false;
            this.gbCorrentista.Text = "Correntista";
            // 
            // cbCorrentista
            // 
            this.cbCorrentista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbCorrentista.FormattingEnabled = true;
            this.cbCorrentista.Location = new System.Drawing.Point(13, 42);
            this.cbCorrentista.Name = "cbCorrentista";
            this.cbCorrentista.Size = new System.Drawing.Size(285, 21);
            this.cbCorrentista.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Selecione Correntista";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.rbDeposito);
            this.groupBox1.Controls.Add(this.rbClienteEscritura);
            this.groupBox1.Controls.Add(this.rbCheque);
            this.groupBox1.Controls.Add(this.rbCorrentista);
            this.groupBox1.Controls.Add(this.rbDinheiro);
            this.groupBox1.Location = new System.Drawing.Point(18, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 156);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Pagamento";
            // 
            // rbDeposito
            // 
            this.rbDeposito.AutoSize = true;
            this.rbDeposito.Location = new System.Drawing.Point(6, 130);
            this.rbDeposito.Name = "rbDeposito";
            this.rbDeposito.Size = new System.Drawing.Size(125, 17);
            this.rbDeposito.TabIndex = 4;
            this.rbDeposito.TabStop = true;
            this.rbDeposito.Text = "Depósito Conta (F11)";
            this.rbDeposito.UseVisualStyleBackColor = true;
            this.rbDeposito.CheckedChanged += new System.EventHandler(this.rbDeposito_CheckedChanged);
            // 
            // rbClienteEscritura
            // 
            this.rbClienteEscritura.AutoSize = true;
            this.rbClienteEscritura.Location = new System.Drawing.Point(6, 102);
            this.rbClienteEscritura.Name = "rbClienteEscritura";
            this.rbClienteEscritura.Size = new System.Drawing.Size(122, 17);
            this.rbClienteEscritura.TabIndex = 3;
            this.rbClienteEscritura.TabStop = true;
            this.rbClienteEscritura.Text = "Cliente Escritura (F9)";
            this.rbClienteEscritura.UseVisualStyleBackColor = true;
            this.rbClienteEscritura.CheckedChanged += new System.EventHandler(this.rbClienteEscritura_CheckedChanged);
            // 
            // rbCheque
            // 
            this.rbCheque.AutoSize = true;
            this.rbCheque.Location = new System.Drawing.Point(6, 75);
            this.rbCheque.Name = "rbCheque";
            this.rbCheque.Size = new System.Drawing.Size(83, 17);
            this.rbCheque.TabIndex = 2;
            this.rbCheque.TabStop = true;
            this.rbCheque.Text = "Cheque (F8)";
            this.rbCheque.UseVisualStyleBackColor = true;
            this.rbCheque.CheckedChanged += new System.EventHandler(this.rbCheque_CheckedChanged);
            // 
            // rbCorrentista
            // 
            this.rbCorrentista.AutoSize = true;
            this.rbCorrentista.Location = new System.Drawing.Point(6, 46);
            this.rbCorrentista.Name = "rbCorrentista";
            this.rbCorrentista.Size = new System.Drawing.Size(96, 17);
            this.rbCorrentista.TabIndex = 1;
            this.rbCorrentista.TabStop = true;
            this.rbCorrentista.Text = "Correntista (F7)";
            this.rbCorrentista.UseVisualStyleBackColor = true;
            this.rbCorrentista.CheckedChanged += new System.EventHandler(this.rbCorrentista_CheckedChanged);
            // 
            // rbDinheiro
            // 
            this.rbDinheiro.AutoSize = true;
            this.rbDinheiro.Checked = true;
            this.rbDinheiro.Location = new System.Drawing.Point(6, 19);
            this.rbDinheiro.Name = "rbDinheiro";
            this.rbDinheiro.Size = new System.Drawing.Size(85, 17);
            this.rbDinheiro.TabIndex = 0;
            this.rbDinheiro.TabStop = true;
            this.rbDinheiro.Text = "Dinheiro (F6)";
            this.rbDinheiro.UseVisualStyleBackColor = true;
            this.rbDinheiro.CheckedChanged += new System.EventHandler(this.rbDinheiro_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(327, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Pedidos:";
            // 
            // btProcurar
            // 
            this.btProcurar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btProcurar.Image = global::sgc.Properties.Resources.search;
            this.btProcurar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btProcurar.Location = new System.Drawing.Point(217, 260);
            this.btProcurar.Name = "btProcurar";
            this.btProcurar.Size = new System.Drawing.Size(83, 26);
            this.btProcurar.TabIndex = 5;
            this.btProcurar.Text = "Procurar";
            this.btProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btProcurar.UseVisualStyleBackColor = false;
            this.btProcurar.Click += new System.EventHandler(this.btProcurar_Click);
            // 
            // txPedido
            // 
            this.txPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPedido.Location = new System.Drawing.Point(111, 260);
            this.txPedido.Name = "txPedido";
            this.txPedido.Size = new System.Drawing.Size(100, 26);
            this.txPedido.TabIndex = 6;
            this.txPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txPedido_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "No. Pedido:";
            // 
            // btPagamento
            // 
            this.btPagamento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPagamento.Image = global::sgc.Properties.Resources.money;
            this.btPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPagamento.Location = new System.Drawing.Point(18, 192);
            this.btPagamento.Name = "btPagamento";
            this.btPagamento.Size = new System.Drawing.Size(255, 45);
            this.btPagamento.TabIndex = 1;
            this.btPagamento.Text = "Efetuar Pagamento (Ctrl + E)";
            this.btPagamento.UseVisualStyleBackColor = false;
            this.btPagamento.Click += new System.EventHandler(this.btPagamento_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qtd,
            this.tipo,
            this.vlUnit,
            this.total});
            this.grid.Location = new System.Drawing.Point(290, 6);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(475, 231);
            this.grid.TabIndex = 0;
            // 
            // qtd
            // 
            this.qtd.HeaderText = "Qtd";
            this.qtd.Name = "qtd";
            this.qtd.ReadOnly = true;
            this.qtd.Width = 30;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 200;
            // 
            // vlUnit
            // 
            this.vlUnit.HeaderText = "Valor Unt.";
            this.vlUnit.Name = "vlUnit";
            this.vlUnit.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Valor Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // txTotal
            // 
            this.txTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTotal.ForeColor = System.Drawing.Color.Red;
            this.txTotal.Location = new System.Drawing.Point(111, 138);
            this.txTotal.Name = "txTotal";
            this.txTotal.ReadOnly = true;
            this.txTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txTotal.ShortcutsEnabled = false;
            this.txTotal.Size = new System.Drawing.Size(162, 38);
            this.txTotal.TabIndex = 4;
            // 
            // txDesconto
            // 
            this.txDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDesconto.Location = new System.Drawing.Point(111, 94);
            this.txDesconto.Name = "txDesconto";
            this.txDesconto.ReadOnly = true;
            this.txDesconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txDesconto.Size = new System.Drawing.Size(162, 38);
            this.txDesconto.TabIndex = 3;
            this.txDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txDesconto_KeyDown);
            this.txDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txDesconto_KeyPress);
            // 
            // txTroco
            // 
            this.txTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTroco.Location = new System.Drawing.Point(111, 50);
            this.txTroco.Name = "txTroco";
            this.txTroco.ReadOnly = true;
            this.txTroco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txTroco.Size = new System.Drawing.Size(162, 38);
            this.txTroco.TabIndex = 2;
            this.txTroco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txTroco_KeyDown);
            this.txTroco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txTroco_KeyPress);
            // 
            // txPago
            // 
            this.txPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPago.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txPago.Location = new System.Drawing.Point(111, 6);
            this.txPago.Name = "txPago";
            this.txPago.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txPago.Size = new System.Drawing.Size(162, 38);
            this.txPago.TabIndex = 0;
            this.txPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txPago_KeyDown);
            this.txPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txPago_KeyPress);
            this.txPago.Leave += new System.EventHandler(this.txPago_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 31);
            this.label4.TabIndex = 18;
            this.label4.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 31);
            this.label3.TabIndex = 17;
            this.label3.Text = "Desc.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Troco:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pago:";
            // 
            // caixaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 505);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "caixaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.caixaForm_FormClosed);
            this.Load += new System.EventHandler(this.caixaForm_Load);
            this.Shown += new System.EventHandler(this.caixaForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.caixaForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbEscritura.ResumeLayout(false);
            this.gbEscritura.PerformLayout();
            this.gbDesconto.ResumeLayout(false);
            this.gbDesconto.PerformLayout();
            this.gbCheque.ResumeLayout(false);
            this.gbCheque.PerformLayout();
            this.gbCorrentista.ResumeLayout(false);
            this.gbCorrentista.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btFecharCaixa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPedidos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btProcurar;
        private System.Windows.Forms.TextBox txPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btPagamento;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.TextBox txTotal;
        private System.Windows.Forms.TextBox txDesconto;
        private System.Windows.Forms.TextBox txTroco;
        private System.Windows.Forms.TextBox txPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbCorrentista;
        private System.Windows.Forms.Button btReimprimir;
        private System.Windows.Forms.RadioButton rbCheque;
        private System.Windows.Forms.RadioButton rbCorrentista;
        private System.Windows.Forms.RadioButton rbDinheiro;
        private System.Windows.Forms.GroupBox gbCheque;
        private System.Windows.Forms.ComboBox cbCorrentista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txNrCheque;
        private System.Windows.Forms.MaskedTextBox txDtResgate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txContaCorrente;
        private System.Windows.Forms.TextBox txAgencia;
        private System.Windows.Forms.TextBox txBanco;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbDesconto;
        private System.Windows.Forms.TextBox txSenha;
        private System.Windows.Forms.TextBox txLogin;
        private System.Windows.Forms.TextBox txValorDesconto;
        private System.Windows.Forms.Label lvTipoDesconto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rbTipoPercent;
        private System.Windows.Forms.RadioButton rbTipoDinheiro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button brGravarDesc;
        private System.Windows.Forms.Button btCancelarDesc;
        private System.Windows.Forms.Button btDesconto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txRG;
        private System.Windows.Forms.Button btRetiradas;
        private System.Windows.Forms.CheckBox ckPedidosMulti;
        private System.Windows.Forms.TextBox txUltmoPedido;
        private System.Windows.Forms.Button btProcurarPedido;
        private System.Windows.Forms.RadioButton rbClienteEscritura;
        private System.Windows.Forms.GroupBox gbEscritura;
        private System.Windows.Forms.TextBox txNrEscritura;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btVerificaSaldo;
        private System.Windows.Forms.RadioButton rbDeposito;
    }
}