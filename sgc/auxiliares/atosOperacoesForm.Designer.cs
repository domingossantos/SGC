namespace sgc.auxiliares
{
    partial class atosOperacoesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCodAto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txDescricao = new System.Windows.Forms.TextBox();
            this.txCdTJ = new System.Windows.Forms.TextBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.gbUso = new System.Windows.Forms.GroupBox();
            this.rbPlanoConta = new System.Windows.Forms.RadioButton();
            this.rbEscritura = new System.Windows.Forms.RadioButton();
            this.rbPedidos = new System.Windows.Forms.RadioButton();
            this.rbProcuracao = new System.Windows.Forms.RadioButton();
            this.rbBalcao = new System.Windows.Forms.RadioButton();
            this.grid = new System.Windows.Forms.DataGridView();
            this.txPercentual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txValor = new System.Windows.Forms.TextBox();
            this.txPlanoContas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbInativo = new System.Windows.Forms.RadioButton();
            this.rbAtivo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txTipoAto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbRepeteNao = new System.Windows.Forms.RadioButton();
            this.rbRepeteSim = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
            this.spContainer.Panel1.SuspendLayout();
            this.spContainer.Panel2.SuspendLayout();
            this.spContainer.SuspendLayout();
            this.gbUso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNovo
            // 
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(765, 39);
            // 
            // spContainer
            // 
            // 
            // spContainer.Panel1
            // 
            this.spContainer.Panel1.Controls.Add(this.groupBox2);
            this.spContainer.Panel1.Controls.Add(this.txTipoAto);
            this.spContainer.Panel1.Controls.Add(this.label8);
            this.spContainer.Panel1.Controls.Add(this.groupBox1);
            this.spContainer.Panel1.Controls.Add(this.label7);
            this.spContainer.Panel1.Controls.Add(this.txPlanoContas);
            this.spContainer.Panel1.Controls.Add(this.txValor);
            this.spContainer.Panel1.Controls.Add(this.label6);
            this.spContainer.Panel1.Controls.Add(this.txPercentual);
            this.spContainer.Panel1.Controls.Add(this.gbUso);
            this.spContainer.Panel1.Controls.Add(this.cbTipoDocumento);
            this.spContainer.Panel1.Controls.Add(this.txCdTJ);
            this.spContainer.Panel1.Controls.Add(this.txDescricao);
            this.spContainer.Panel1.Controls.Add(this.label5);
            this.spContainer.Panel1.Controls.Add(this.label4);
            this.spContainer.Panel1.Controls.Add(this.label3);
            this.spContainer.Panel1.Controls.Add(this.lbCodAto);
            this.spContainer.Panel1.Controls.Add(this.label2);
            this.spContainer.Panel1.Controls.Add(this.label1);
            // 
            // spContainer.Panel2
            // 
            this.spContainer.Panel2.Controls.Add(this.grid);
            this.spContainer.Size = new System.Drawing.Size(765, 454);
            this.spContainer.SplitterDistance = 140;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ato/Operação";
            // 
            // lbCodAto
            // 
            this.lbCodAto.AutoSize = true;
            this.lbCodAto.Location = new System.Drawing.Point(12, 37);
            this.lbCodAto.Name = "lbCodAto";
            this.lbCodAto.Size = new System.Drawing.Size(13, 13);
            this.lbCodAto.TabIndex = 2;
            this.lbCodAto.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Código TJ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo Documento";
            // 
            // txDescricao
            // 
            this.txDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txDescricao.Location = new System.Drawing.Point(76, 34);
            this.txDescricao.Name = "txDescricao";
            this.txDescricao.Size = new System.Drawing.Size(300, 20);
            this.txDescricao.TabIndex = 7;
            // 
            // txCdTJ
            // 
            this.txCdTJ.Location = new System.Drawing.Point(17, 76);
            this.txCdTJ.Name = "txCdTJ";
            this.txCdTJ.Size = new System.Drawing.Size(40, 20);
            this.txCdTJ.TabIndex = 9;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(76, 76);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(150, 21);
            this.cbTipoDocumento.TabIndex = 10;
            this.cbTipoDocumento.Text = "Selecione...";
            // 
            // gbUso
            // 
            this.gbUso.Controls.Add(this.rbPlanoConta);
            this.gbUso.Controls.Add(this.rbEscritura);
            this.gbUso.Controls.Add(this.rbPedidos);
            this.gbUso.Controls.Add(this.rbProcuracao);
            this.gbUso.Controls.Add(this.rbBalcao);
            this.gbUso.Location = new System.Drawing.Point(234, 60);
            this.gbUso.Name = "gbUso";
            this.gbUso.Size = new System.Drawing.Size(290, 65);
            this.gbUso.TabIndex = 11;
            this.gbUso.TabStop = false;
            this.gbUso.Text = "Uso";
            // 
            // rbPlanoConta
            // 
            this.rbPlanoConta.AutoSize = true;
            this.rbPlanoConta.Location = new System.Drawing.Point(198, 19);
            this.rbPlanoConta.Name = "rbPlanoConta";
            this.rbPlanoConta.Size = new System.Drawing.Size(83, 17);
            this.rbPlanoConta.TabIndex = 5;
            this.rbPlanoConta.TabStop = true;
            this.rbPlanoConta.Text = "Plano Conta";
            this.rbPlanoConta.UseVisualStyleBackColor = true;
            // 
            // rbEscritura
            // 
            this.rbEscritura.AutoSize = true;
            this.rbEscritura.Location = new System.Drawing.Point(70, 42);
            this.rbEscritura.Name = "rbEscritura";
            this.rbEscritura.Size = new System.Drawing.Size(66, 17);
            this.rbEscritura.TabIndex = 4;
            this.rbEscritura.TabStop = true;
            this.rbEscritura.Text = "Escritura";
            this.rbEscritura.UseVisualStyleBackColor = true;
            // 
            // rbPedidos
            // 
            this.rbPedidos.AutoSize = true;
            this.rbPedidos.Location = new System.Drawing.Point(4, 42);
            this.rbPedidos.Name = "rbPedidos";
            this.rbPedidos.Size = new System.Drawing.Size(63, 17);
            this.rbPedidos.TabIndex = 3;
            this.rbPedidos.TabStop = true;
            this.rbPedidos.Text = "Pedidos";
            this.rbPedidos.UseVisualStyleBackColor = true;
            // 
            // rbProcuracao
            // 
            this.rbProcuracao.AutoSize = true;
            this.rbProcuracao.Location = new System.Drawing.Point(70, 19);
            this.rbProcuracao.Name = "rbProcuracao";
            this.rbProcuracao.Size = new System.Drawing.Size(126, 17);
            this.rbProcuracao.TabIndex = 2;
            this.rbProcuracao.TabStop = true;
            this.rbProcuracao.Text = "Procuração/Escritura";
            this.rbProcuracao.UseVisualStyleBackColor = true;
            // 
            // rbBalcao
            // 
            this.rbBalcao.AutoSize = true;
            this.rbBalcao.Location = new System.Drawing.Point(4, 19);
            this.rbBalcao.Name = "rbBalcao";
            this.rbBalcao.Size = new System.Drawing.Size(58, 17);
            this.rbBalcao.TabIndex = 1;
            this.rbBalcao.TabStop = true;
            this.rbBalcao.Text = "Balcão";
            this.rbBalcao.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(763, 308);
            this.grid.TabIndex = 0;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // txPercentual
            // 
            this.txPercentual.Location = new System.Drawing.Point(488, 34);
            this.txPercentual.Name = "txPercentual";
            this.txPercentual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txPercentual.Size = new System.Drawing.Size(100, 20);
            this.txPercentual.TabIndex = 12;
            this.txPercentual.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Percentual";
            // 
            // txValor
            // 
            this.txValor.Location = new System.Drawing.Point(382, 34);
            this.txValor.Name = "txValor";
            this.txValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txValor.Size = new System.Drawing.Size(100, 20);
            this.txValor.TabIndex = 14;
            this.txValor.Click += new System.EventHandler(this.txValor_Click);
            // 
            // txPlanoContas
            // 
            this.txPlanoContas.Location = new System.Drawing.Point(601, 34);
            this.txPlanoContas.Name = "txPlanoContas";
            this.txPlanoContas.Size = new System.Drawing.Size(80, 20);
            this.txPlanoContas.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Plano de Contas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInativo);
            this.groupBox1.Controls.Add(this.rbAtivo);
            this.groupBox1.Location = new System.Drawing.Point(529, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 65);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // rbInativo
            // 
            this.rbInativo.AutoSize = true;
            this.rbInativo.Location = new System.Drawing.Point(10, 43);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(57, 17);
            this.rbInativo.TabIndex = 1;
            this.rbInativo.TabStop = true;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;
            // 
            // rbAtivo
            // 
            this.rbAtivo.AutoSize = true;
            this.rbAtivo.Checked = true;
            this.rbAtivo.Location = new System.Drawing.Point(10, 19);
            this.rbAtivo.Name = "rbAtivo";
            this.rbAtivo.Size = new System.Drawing.Size(49, 17);
            this.rbAtivo.TabIndex = 0;
            this.rbAtivo.TabStop = true;
            this.rbAtivo.Text = "Ativo";
            this.rbAtivo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(694, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tipo";
            // 
            // txTipoAto
            // 
            this.txTipoAto.Location = new System.Drawing.Point(697, 33);
            this.txTipoAto.Name = "txTipoAto";
            this.txTipoAto.Size = new System.Drawing.Size(41, 20);
            this.txTipoAto.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbRepeteNao);
            this.groupBox2.Controls.Add(this.rbRepeteSim);
            this.groupBox2.Location = new System.Drawing.Point(642, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(79, 65);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repetição";
            // 
            // rbRepeteNao
            // 
            this.rbRepeteNao.AutoSize = true;
            this.rbRepeteNao.Location = new System.Drawing.Point(10, 43);
            this.rbRepeteNao.Name = "rbRepeteNao";
            this.rbRepeteNao.Size = new System.Drawing.Size(48, 17);
            this.rbRepeteNao.TabIndex = 1;
            this.rbRepeteNao.TabStop = true;
            this.rbRepeteNao.Text = "NÃO";
            this.rbRepeteNao.UseVisualStyleBackColor = true;
            // 
            // rbRepeteSim
            // 
            this.rbRepeteSim.AutoSize = true;
            this.rbRepeteSim.Checked = true;
            this.rbRepeteSim.Location = new System.Drawing.Point(10, 19);
            this.rbRepeteSim.Name = "rbRepeteSim";
            this.rbRepeteSim.Size = new System.Drawing.Size(44, 17);
            this.rbRepeteSim.TabIndex = 0;
            this.rbRepeteSim.TabStop = true;
            this.rbRepeteSim.Text = "SIM";
            this.rbRepeteSim.UseVisualStyleBackColor = true;
            // 
            // atosOperacoesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(765, 493);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "atosOperacoesForm";
            this.Text = "Atos e Operações";
            this.Load += new System.EventHandler(this.atosOperacoesForm_Load);
            this.panel1.ResumeLayout(false);
            this.spContainer.Panel1.ResumeLayout(false);
            this.spContainer.Panel1.PerformLayout();
            this.spContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).EndInit();
            this.spContainer.ResumeLayout(false);
            this.gbUso.ResumeLayout(false);
            this.gbUso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.TextBox txCdTJ;
        private System.Windows.Forms.TextBox txDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCodAto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbUso;
        private System.Windows.Forms.RadioButton rbProcuracao;
        private System.Windows.Forms.RadioButton rbBalcao;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.RadioButton rbPedidos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txPercentual;
        private System.Windows.Forms.TextBox txValor;
        private System.Windows.Forms.RadioButton rbEscritura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txPlanoContas;
        private System.Windows.Forms.RadioButton rbPlanoConta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbInativo;
        private System.Windows.Forms.RadioButton rbAtivo;
        private System.Windows.Forms.TextBox txTipoAto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbRepeteNao;
        private System.Windows.Forms.RadioButton rbRepeteSim;
    }
}
