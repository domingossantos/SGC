namespace sgc.assinaturas
{
    partial class assinaturasForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btOutraBase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txObservacao = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.txPesquisa = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDoc = new System.Windows.Forms.RadioButton();
            this.rbSemelhante = new System.Windows.Forms.RadioButton();
            this.rbAutentico = new System.Windows.Forms.RadioButton();
            this.btPesquisa = new System.Windows.Forms.Button();
            this.grbPesquisa = new System.Windows.Forms.GroupBox();
            this.rbCartorio = new System.Windows.Forms.RadioButton();
            this.rbCidade = new System.Windows.Forms.RadioButton();
            this.rbCartao = new System.Windows.Forms.RadioButton();
            this.rbRG = new System.Windows.Forms.RadioButton();
            this.rbCPF = new System.Windows.Forms.RadioButton();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.lbRenovacao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txPedido = new System.Windows.Forms.ListBox();
            this.btZoomOut = new System.Windows.Forms.Button();
            this.btZoomIn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imagem = new System.Windows.Forms.PictureBox();
            this.btCancelarPedido = new System.Windows.Forms.Button();
            this.btFecharPedido = new System.Windows.Forms.Button();
            this.btInserirPedido = new System.Windows.Forms.Button();
            this.cbOperacao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grbPesquisa.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel1.Controls.Add(this.btOutraBase);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btPesquisa);
            this.splitContainer1.Panel1.Controls.Add(this.grbPesquisa);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel2.Controls.Add(this.lbRenovacao);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txPedido);
            this.splitContainer1.Panel2.Controls.Add(this.btZoomOut);
            this.splitContainer1.Panel2.Controls.Add(this.btZoomIn);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(859, 474);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.TabIndex = 0;
            // 
            // btOutraBase
            // 
            this.btOutraBase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btOutraBase.Image = global::sgc.Properties.Resources.search;
            this.btOutraBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOutraBase.Location = new System.Drawing.Point(336, 44);
            this.btOutraBase.Name = "btOutraBase";
            this.btOutraBase.Size = new System.Drawing.Size(75, 23);
            this.btOutraBase.TabIndex = 9;
            this.btOutraBase.Text = "Outra";
            this.btOutraBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOutraBase.UseVisualStyleBackColor = false;
            this.btOutraBase.Click += new System.EventHandler(this.btOutraBase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txObservacao);
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Controls.Add(this.txPesquisa);
            this.groupBox1.Location = new System.Drawing.Point(8, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 310);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Argumentos para Pesquisa";
            // 
            // txObservacao
            // 
            this.txObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txObservacao.ForeColor = System.Drawing.Color.Red;
            this.txObservacao.Location = new System.Drawing.Point(4, 270);
            this.txObservacao.Multiline = true;
            this.txObservacao.Name = "txObservacao";
            this.txObservacao.Size = new System.Drawing.Size(402, 34);
            this.txObservacao.TabIndex = 10;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Location = new System.Drawing.Point(6, 58);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(403, 206);
            this.grid.TabIndex = 9;
            this.grid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEnter);
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // txPesquisa
            // 
            this.txPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPesquisa.Location = new System.Drawing.Point(7, 19);
            this.txPesquisa.Name = "txPesquisa";
            this.txPesquisa.Size = new System.Drawing.Size(398, 26);
            this.txPesquisa.TabIndex = 7;
            this.txPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txPesquisa_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbDoc);
            this.groupBox2.Controls.Add(this.rbSemelhante);
            this.groupBox2.Controls.Add(this.rbAutentico);
            this.groupBox2.Location = new System.Drawing.Point(8, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 44);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Reconhecimento";
            // 
            // rbDoc
            // 
            this.rbDoc.AutoSize = true;
            this.rbDoc.Location = new System.Drawing.Point(257, 16);
            this.rbDoc.Name = "rbDoc";
            this.rbDoc.Size = new System.Drawing.Size(92, 17);
            this.rbDoc.TabIndex = 2;
            this.rbDoc.Text = "Endo (Ctrl + 0)";
            this.rbDoc.UseVisualStyleBackColor = true;
            // 
            // rbSemelhante
            // 
            this.rbSemelhante.AutoSize = true;
            this.rbSemelhante.Checked = true;
            this.rbSemelhante.Location = new System.Drawing.Point(124, 16);
            this.rbSemelhante.Name = "rbSemelhante";
            this.rbSemelhante.Size = new System.Drawing.Size(123, 17);
            this.rbSemelhante.TabIndex = 1;
            this.rbSemelhante.TabStop = true;
            this.rbSemelhante.Text = "Semelhante (Ctrl + 9)";
            this.rbSemelhante.UseVisualStyleBackColor = true;
            // 
            // rbAutentico
            // 
            this.rbAutentico.AutoSize = true;
            this.rbAutentico.Location = new System.Drawing.Point(6, 16);
            this.rbAutentico.Name = "rbAutentico";
            this.rbAutentico.Size = new System.Drawing.Size(112, 17);
            this.rbAutentico.TabIndex = 0;
            this.rbAutentico.Text = "Autentico (Ctrl + 8)";
            this.rbAutentico.UseVisualStyleBackColor = true;
            // 
            // btPesquisa
            // 
            this.btPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisa.Image = global::sgc.Properties.Resources.search;
            this.btPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisa.Location = new System.Drawing.Point(336, 12);
            this.btPesquisa.Name = "btPesquisa";
            this.btPesquisa.Size = new System.Drawing.Size(77, 26);
            this.btPesquisa.TabIndex = 8;
            this.btPesquisa.Text = "Pesquisar";
            this.btPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisa.UseVisualStyleBackColor = false;
            this.btPesquisa.Click += new System.EventHandler(this.btPesquisa_Click);
            // 
            // grbPesquisa
            // 
            this.grbPesquisa.Controls.Add(this.rbCartorio);
            this.grbPesquisa.Controls.Add(this.rbCidade);
            this.grbPesquisa.Controls.Add(this.rbCartao);
            this.grbPesquisa.Controls.Add(this.rbRG);
            this.grbPesquisa.Controls.Add(this.rbCPF);
            this.grbPesquisa.Controls.Add(this.rbNome);
            this.grbPesquisa.Location = new System.Drawing.Point(8, 7);
            this.grbPesquisa.Name = "grbPesquisa";
            this.grbPesquisa.Size = new System.Drawing.Size(316, 53);
            this.grbPesquisa.TabIndex = 1;
            this.grbPesquisa.TabStop = false;
            this.grbPesquisa.Text = "Pesquisar por:";
            // 
            // rbCartorio
            // 
            this.rbCartorio.AutoSize = true;
            this.rbCartorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCartorio.Location = new System.Drawing.Point(111, 31);
            this.rbCartorio.Name = "rbCartorio";
            this.rbCartorio.Size = new System.Drawing.Size(103, 17);
            this.rbCartorio.TabIndex = 5;
            this.rbCartorio.TabStop = true;
            this.rbCartorio.Text = "Cartório (Ctrl + 6)";
            this.rbCartorio.UseVisualStyleBackColor = true;
            this.rbCartorio.Click += new System.EventHandler(this.rbCartorio_Click);
            // 
            // rbCidade
            // 
            this.rbCidade.AutoSize = true;
            this.rbCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCidade.Location = new System.Drawing.Point(5, 31);
            this.rbCidade.Name = "rbCidade";
            this.rbCidade.Size = new System.Drawing.Size(100, 17);
            this.rbCidade.TabIndex = 4;
            this.rbCidade.TabStop = true;
            this.rbCidade.Text = "Cidade (Ctrl + 5)";
            this.rbCidade.UseVisualStyleBackColor = true;
            this.rbCidade.Click += new System.EventHandler(this.rbCidade_Click);
            // 
            // rbCartao
            // 
            this.rbCartao.AutoSize = true;
            this.rbCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCartao.Location = new System.Drawing.Point(216, 30);
            this.rbCartao.Name = "rbCartao";
            this.rbCartao.Size = new System.Drawing.Size(93, 17);
            this.rbCartao.TabIndex = 3;
            this.rbCartao.TabStop = true;
            this.rbCartao.Text = "Ficha (Ctrl + 4)";
            this.rbCartao.UseVisualStyleBackColor = true;
            this.rbCartao.Click += new System.EventHandler(this.rbCartao_Click);
            // 
            // rbRG
            // 
            this.rbRG.AutoSize = true;
            this.rbRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRG.Location = new System.Drawing.Point(217, 13);
            this.rbRG.Name = "rbRG";
            this.rbRG.Size = new System.Drawing.Size(80, 17);
            this.rbRG.TabIndex = 2;
            this.rbRG.TabStop = true;
            this.rbRG.Text = "RG (Ctrl+ 3)";
            this.rbRG.UseVisualStyleBackColor = true;
            this.rbRG.Click += new System.EventHandler(this.rbRG_Click);
            // 
            // rbCPF
            // 
            this.rbCPF.AutoSize = true;
            this.rbCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCPF.Location = new System.Drawing.Point(111, 13);
            this.rbCPF.Name = "rbCPF";
            this.rbCPF.Size = new System.Drawing.Size(87, 17);
            this.rbCPF.TabIndex = 1;
            this.rbCPF.TabStop = true;
            this.rbCPF.Text = "CPF (Ctrl + 2)";
            this.rbCPF.UseVisualStyleBackColor = true;
            this.rbCPF.Click += new System.EventHandler(this.rbCPF_Click);
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Checked = true;
            this.rbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNome.Location = new System.Drawing.Point(5, 13);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(95, 17);
            this.rbNome.TabIndex = 0;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome (Ctrl + 1)";
            this.rbNome.UseVisualStyleBackColor = true;
            this.rbNome.Click += new System.EventHandler(this.rbNome_Click);
            // 
            // lbRenovacao
            // 
            this.lbRenovacao.AutoSize = true;
            this.lbRenovacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRenovacao.ForeColor = System.Drawing.Color.Red;
            this.lbRenovacao.Location = new System.Drawing.Point(66, 296);
            this.lbRenovacao.Name = "lbRenovacao";
            this.lbRenovacao.Size = new System.Drawing.Size(90, 18);
            this.lbRenovacao.TabIndex = 8;
            this.lbRenovacao.Text = "00/00/0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Renovação";
            // 
            // txPedido
            // 
            this.txPedido.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPedido.FormattingEnabled = true;
            this.txPedido.ItemHeight = 14;
            this.txPedido.Location = new System.Drawing.Point(3, 322);
            this.txPedido.Name = "txPedido";
            this.txPedido.ScrollAlwaysVisible = true;
            this.txPedido.Size = new System.Drawing.Size(416, 130);
            this.txPedido.TabIndex = 6;
            // 
            // btZoomOut
            // 
            this.btZoomOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btZoomOut.Image = global::sgc.Properties.Resources.search;
            this.btZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btZoomOut.Location = new System.Drawing.Point(319, 294);
            this.btZoomOut.Name = "btZoomOut";
            this.btZoomOut.Size = new System.Drawing.Size(100, 25);
            this.btZoomOut.TabIndex = 4;
            this.btZoomOut.Text = "Afastar (F12)";
            this.btZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btZoomOut.UseVisualStyleBackColor = false;
            this.btZoomOut.Click += new System.EventHandler(this.btZoomOut_Click);
            // 
            // btZoomIn
            // 
            this.btZoomIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btZoomIn.Image = global::sgc.Properties.Resources.search;
            this.btZoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btZoomIn.Location = new System.Drawing.Point(208, 294);
            this.btZoomIn.Name = "btZoomIn";
            this.btZoomIn.Size = new System.Drawing.Size(100, 25);
            this.btZoomIn.TabIndex = 2;
            this.btZoomIn.Text = "Aproximar (F11)";
            this.btZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btZoomIn.UseVisualStyleBackColor = false;
            this.btZoomIn.Click += new System.EventHandler(this.btZoomIn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.imagem);
            this.panel1.Location = new System.Drawing.Point(3, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 286);
            this.panel1.TabIndex = 5;
            // 
            // imagem
            // 
            this.imagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imagem.Location = new System.Drawing.Point(0, -2);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(414, 281);
            this.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagem.TabIndex = 2;
            this.imagem.TabStop = false;
            // 
            // btCancelarPedido
            // 
            this.btCancelarPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelarPedido.Image = global::sgc.Properties.Resources.delete;
            this.btCancelarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelarPedido.Location = new System.Drawing.Point(706, 10);
            this.btCancelarPedido.Name = "btCancelarPedido";
            this.btCancelarPedido.Size = new System.Drawing.Size(147, 30);
            this.btCancelarPedido.TabIndex = 16;
            this.btCancelarPedido.Text = "Cancelar Pedido (Ctrl+del)";
            this.btCancelarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelarPedido.UseVisualStyleBackColor = false;
            this.btCancelarPedido.Click += new System.EventHandler(this.btCancelarPedido_Click);
            // 
            // btFecharPedido
            // 
            this.btFecharPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btFecharPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFecharPedido.Image = global::sgc.Properties.Resources.alert;
            this.btFecharPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFecharPedido.Location = new System.Drawing.Point(555, 10);
            this.btFecharPedido.Name = "btFecharPedido";
            this.btFecharPedido.Size = new System.Drawing.Size(147, 30);
            this.btFecharPedido.TabIndex = 15;
            this.btFecharPedido.Text = "Fechar Pedido (Ctrl+F)";
            this.btFecharPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFecharPedido.UseVisualStyleBackColor = false;
            this.btFecharPedido.Click += new System.EventHandler(this.btFecharPedido_Click);
            // 
            // btInserirPedido
            // 
            this.btInserirPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btInserirPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInserirPedido.Image = global::sgc.Properties.Resources.package_editors;
            this.btInserirPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInserirPedido.Location = new System.Drawing.Point(404, 10);
            this.btInserirPedido.Name = "btInserirPedido";
            this.btInserirPedido.Size = new System.Drawing.Size(147, 30);
            this.btInserirPedido.TabIndex = 14;
            this.btInserirPedido.Text = "Inserir Pedido (Insert)";
            this.btInserirPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInserirPedido.UseVisualStyleBackColor = false;
            this.btInserirPedido.Click += new System.EventHandler(this.btInserirPedido_Click);
            // 
            // cbOperacao
            // 
            this.cbOperacao.AutoCompleteCustomSource.AddRange(new string[] {
            "Selecione"});
            this.cbOperacao.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOperacao.FormattingEnabled = true;
            this.cbOperacao.Items.AddRange(new object[] {
            "Selecione"});
            this.cbOperacao.Location = new System.Drawing.Point(3, 16);
            this.cbOperacao.Name = "cbOperacao";
            this.cbOperacao.Size = new System.Drawing.Size(384, 24);
            this.cbOperacao.TabIndex = 13;
            this.cbOperacao.Text = "Selecione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Operação(+):";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbOperacao);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btCancelarPedido);
            this.panel2.Controls.Add(this.btFecharPedido);
            this.panel2.Controls.Add(this.btInserirPedido);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 43);
            this.panel2.TabIndex = 1;
            // 
            // assinaturasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 474);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "assinaturasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assinaturas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.assinaturasForm_FormClosed);
            this.Load += new System.EventHandler(this.assinaturasForm_Load);
            this.Shown += new System.EventHandler(this.assinaturasForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.assinaturasForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbPesquisa.ResumeLayout(false);
            this.grbPesquisa.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbPesquisa;
        private System.Windows.Forms.RadioButton rbCartao;
        private System.Windows.Forms.RadioButton rbRG;
        private System.Windows.Forms.RadioButton rbCPF;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDoc;
        private System.Windows.Forms.RadioButton rbSemelhante;
        private System.Windows.Forms.RadioButton rbAutentico;
        private System.Windows.Forms.Button btZoomIn;
        private System.Windows.Forms.Button btZoomOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.ListBox txPedido;
        private System.Windows.Forms.Button btCancelarPedido;
        private System.Windows.Forms.Button btFecharPedido;
        private System.Windows.Forms.Button btInserirPedido;
        private System.Windows.Forms.ComboBox cbOperacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbCartorio;
        private System.Windows.Forms.RadioButton rbCidade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btPesquisa;
        private System.Windows.Forms.TextBox txPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRenovacao;
        private System.Windows.Forms.TextBox txObservacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btOutraBase;
    }
}