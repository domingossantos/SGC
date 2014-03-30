namespace sgc.controleSelos
{
    partial class situacaoSelosForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTipoSelo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txNumSelo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSituacao = new System.Windows.Forms.RadioButton();
            this.rbTipoDocSelo = new System.Windows.Forms.RadioButton();
            this.rbTipoSelo = new System.Windows.Forms.RadioButton();
            this.rbNumSelo = new System.Windows.Forms.RadioButton();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.rbDataUsuario = new System.Windows.Forms.RadioButton();
            this.rbUsuario = new System.Windows.Forms.RadioButton();
            this.rbNumPedido = new System.Windows.Forms.RadioButton();
            this.rbDatas = new System.Windows.Forms.RadioButton();
            this.txNumPedido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.vwSituacaoSelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sGCDataSet = new sgc.SGCDataSet();
            this.vwSituacaoSelosTableAdapter = new sgc.SGCDataSetTableAdapters.vwSituacaoSelosTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vwSituacaoSelosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.cbSituacao);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbTipoDocumento);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbTipoSelo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txNumSelo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txNumPedido);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txNome);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbUsuario);
            this.panel1.Controls.Add(this.dtFim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtInicio);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 144);
            this.panel1.TabIndex = 0;
            // 
            // cbSituacao
            // 
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "DISPONIVEL",
            "CANCELADO",
            "TRANSFERIDO",
            "USADO"});
            this.cbSituacao.Location = new System.Drawing.Point(470, 110);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(115, 21);
            this.cbSituacao.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(467, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Situação";
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(263, 110);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(189, 21);
            this.cbTipoDocumento.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tipo Documento";
            // 
            // cbTipoSelo
            // 
            this.cbTipoSelo.FormattingEnabled = true;
            this.cbTipoSelo.Location = new System.Drawing.Point(263, 70);
            this.cbTipoSelo.Name = "cbTipoSelo";
            this.cbTipoSelo.Size = new System.Drawing.Size(189, 21);
            this.cbTipoSelo.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tipo Selo";
            // 
            // txNumSelo
            // 
            this.txNumSelo.Location = new System.Drawing.Point(353, 25);
            this.txNumSelo.Name = "txNumSelo";
            this.txNumSelo.Size = new System.Drawing.Size(100, 20);
            this.txNumSelo.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nº Selo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSituacao);
            this.groupBox1.Controls.Add(this.rbTipoDocSelo);
            this.groupBox1.Controls.Add(this.rbTipoSelo);
            this.groupBox1.Controls.Add(this.rbNumSelo);
            this.groupBox1.Controls.Add(this.rbNome);
            this.groupBox1.Controls.Add(this.rbDataUsuario);
            this.groupBox1.Controls.Add(this.rbUsuario);
            this.groupBox1.Controls.Add(this.rbNumPedido);
            this.groupBox1.Controls.Add(this.rbDatas);
            this.groupBox1.Location = new System.Drawing.Point(470, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 86);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar Por";
            // 
            // rbSituacao
            // 
            this.rbSituacao.AutoSize = true;
            this.rbSituacao.Location = new System.Drawing.Point(225, 65);
            this.rbSituacao.Name = "rbSituacao";
            this.rbSituacao.Size = new System.Drawing.Size(67, 17);
            this.rbSituacao.TabIndex = 8;
            this.rbSituacao.TabStop = true;
            this.rbSituacao.Text = "Situação";
            this.rbSituacao.UseVisualStyleBackColor = true;
            // 
            // rbTipoDocSelo
            // 
            this.rbTipoDocSelo.AutoSize = true;
            this.rbTipoDocSelo.Location = new System.Drawing.Point(90, 65);
            this.rbTipoDocSelo.Name = "rbTipoDocSelo";
            this.rbTipoDocSelo.Size = new System.Drawing.Size(134, 17);
            this.rbTipoDocSelo.TabIndex = 7;
            this.rbTipoDocSelo.TabStop = true;
            this.rbTipoDocSelo.Text = "Documento e Situação";
            this.rbTipoDocSelo.UseVisualStyleBackColor = true;
            // 
            // rbTipoSelo
            // 
            this.rbTipoSelo.AutoSize = true;
            this.rbTipoSelo.Location = new System.Drawing.Point(7, 63);
            this.rbTipoSelo.Name = "rbTipoSelo";
            this.rbTipoSelo.Size = new System.Drawing.Size(70, 17);
            this.rbTipoSelo.TabIndex = 6;
            this.rbTipoSelo.TabStop = true;
            this.rbTipoSelo.Text = "Tipo Selo";
            this.rbTipoSelo.UseVisualStyleBackColor = true;
            // 
            // rbNumSelo
            // 
            this.rbNumSelo.AutoSize = true;
            this.rbNumSelo.Location = new System.Drawing.Point(225, 19);
            this.rbNumSelo.Name = "rbNumSelo";
            this.rbNumSelo.Size = new System.Drawing.Size(61, 17);
            this.rbNumSelo.TabIndex = 5;
            this.rbNumSelo.TabStop = true;
            this.rbNumSelo.Text = "Nº Selo";
            this.rbNumSelo.UseVisualStyleBackColor = true;
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Location = new System.Drawing.Point(89, 42);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(87, 17);
            this.rbNome.TabIndex = 4;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome Cartão";
            this.rbNome.UseVisualStyleBackColor = true;
            // 
            // rbDataUsuario
            // 
            this.rbDataUsuario.AutoSize = true;
            this.rbDataUsuario.Location = new System.Drawing.Point(89, 19);
            this.rbDataUsuario.Name = "rbDataUsuario";
            this.rbDataUsuario.Size = new System.Drawing.Size(96, 17);
            this.rbDataUsuario.TabIndex = 3;
            this.rbDataUsuario.TabStop = true;
            this.rbDataUsuario.Text = "Date e Usuario";
            this.rbDataUsuario.UseVisualStyleBackColor = true;
            // 
            // rbUsuario
            // 
            this.rbUsuario.AutoSize = true;
            this.rbUsuario.Location = new System.Drawing.Point(224, 42);
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.Size = new System.Drawing.Size(80, 17);
            this.rbUsuario.TabIndex = 2;
            this.rbUsuario.TabStop = true;
            this.rbUsuario.Text = "Por Usuário";
            this.rbUsuario.UseVisualStyleBackColor = true;
            // 
            // rbNumPedido
            // 
            this.rbNumPedido.AutoSize = true;
            this.rbNumPedido.Location = new System.Drawing.Point(7, 42);
            this.rbNumPedido.Name = "rbNumPedido";
            this.rbNumPedido.Size = new System.Drawing.Size(73, 17);
            this.rbNumPedido.TabIndex = 1;
            this.rbNumPedido.TabStop = true;
            this.rbNumPedido.Text = "Nº Pedido";
            this.rbNumPedido.UseVisualStyleBackColor = true;
            // 
            // rbDatas
            // 
            this.rbDatas.AutoSize = true;
            this.rbDatas.Checked = true;
            this.rbDatas.Location = new System.Drawing.Point(7, 19);
            this.rbDatas.Name = "rbDatas";
            this.rbDatas.Size = new System.Drawing.Size(81, 17);
            this.rbDatas.TabIndex = 0;
            this.rbDatas.TabStop = true;
            this.rbDatas.Text = "Entre Datas";
            this.rbDatas.UseVisualStyleBackColor = true;
            // 
            // txNumPedido
            // 
            this.txNumPedido.Location = new System.Drawing.Point(245, 25);
            this.txNumPedido.Name = "txNumPedido";
            this.txNumPedido.Size = new System.Drawing.Size(93, 20);
            this.txNumPedido.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nr Pedido";
            // 
            // txNome
            // 
            this.txNome.Location = new System.Drawing.Point(15, 110);
            this.txNome.Name = "txNome";
            this.txNome.Size = new System.Drawing.Size(235, 20);
            this.txNome.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nome Cartão";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuário:";
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(15, 70);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(235, 21);
            this.cbUsuario.TabIndex = 5;
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(129, 25);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(89, 20);
            this.dtFim.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio";
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(15, 25);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(91, 20);
            this.dtInicio.TabIndex = 1;
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisar.Image = global::sgc.Properties.Resources.report;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisar.Location = new System.Drawing.Point(688, 104);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(91, 31);
            this.btPesquisar.TabIndex = 0;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // vwSituacaoSelosBindingSource
            // 
            this.vwSituacaoSelosBindingSource.DataMember = "vwSituacaoSelos";
            this.vwSituacaoSelosBindingSource.DataSource = this.sGCDataSet;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwSituacaoSelosTableAdapter
            // 
            this.vwSituacaoSelosTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsSituacaoSelos";
            reportDataSource1.Value = this.vwSituacaoSelosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sgc.relatorios.relSituacaoSelos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 144);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(791, 291);
            this.reportViewer1.TabIndex = 1;
            // 
            // situacaoSelosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 435);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "situacaoSelosForm";
            this.Text = "Situação Selos";
            this.Load += new System.EventHandler(this.situacaoSelosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vwSituacaoSelosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.RadioButton rbDataUsuario;
        private System.Windows.Forms.RadioButton rbUsuario;
        private System.Windows.Forms.RadioButton rbNumPedido;
        private System.Windows.Forms.RadioButton rbDatas;
        private System.Windows.Forms.TextBox txNumPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txNumSelo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbNumSelo;
        private System.Windows.Forms.RadioButton rbTipoSelo;
        private System.Windows.Forms.ComboBox cbTipoSelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.RadioButton rbTipoDocSelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.RadioButton rbSituacao;
        private SGCDataSet sGCDataSet;
        private System.Windows.Forms.BindingSource vwSituacaoSelosBindingSource;
        private SGCDataSetTableAdapters.vwSituacaoSelosTableAdapter vwSituacaoSelosTableAdapter;
        private System.Windows.Forms.Button btPesquisar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}