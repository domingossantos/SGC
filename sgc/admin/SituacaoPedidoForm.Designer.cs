namespace sgc.admin
{
    partial class SituacaoPedidoForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDataPedido = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txNrPedido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridPedido = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gridPagto = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarMovimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarValorMovimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagto)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbValor);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.lbUsuario);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbDataPedido);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.txNrPedido);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 86);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Pedidos Relacionados:";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(581, 14);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(28, 13);
            this.lbValor.TabIndex = 32;
            this.lbValor.Text = "0,00";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(319, 50);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(14, 13);
            this.lbStatus.TabIndex = 31;
            this.lbStatus.Text = "S";
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(319, 28);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(49, 13);
            this.lbUsuario.TabIndex = 30;
            this.lbUsuario.Text = "Ninguem";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Valor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Usuário:";
            // 
            // lbDataPedido
            // 
            this.lbDataPedido.AutoSize = true;
            this.lbDataPedido.Location = new System.Drawing.Point(319, 9);
            this.lbDataPedido.Name = "lbDataPedido";
            this.lbDataPedido.Size = new System.Drawing.Size(65, 13);
            this.lbDataPedido.TabIndex = 26;
            this.lbDataPedido.Text = "00/00/0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Data Pedido:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(543, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Movimento Caixa";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Itens do Pedido";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(111, 23);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(98, 23);
            this.btPesquisar.TabIndex = 22;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txNrPedido
            // 
            this.txNrPedido.Location = new System.Drawing.Point(18, 25);
            this.txNrPedido.MaxLength = 10;
            this.txNrPedido.Name = "txNrPedido";
            this.txNrPedido.Size = new System.Drawing.Size(75, 20);
            this.txNrPedido.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "No. Pedido";
            // 
            // gridPedido
            // 
            this.gridPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPedido.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridPedido.Location = new System.Drawing.Point(0, 86);
            this.gridPedido.Name = "gridPedido";
            this.gridPedido.Size = new System.Drawing.Size(276, 360);
            this.gridPedido.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(276, 86);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 360);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // gridPagto
            // 
            this.gridPagto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPagto.ContextMenuStrip = this.contextMenuStrip1;
            this.gridPagto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPagto.Location = new System.Drawing.Point(279, 86);
            this.gridPagto.Name = "gridPagto";
            this.gridPagto.Size = new System.Drawing.Size(454, 360);
            this.gridPagto.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarMovimentoToolStripMenuItem,
            this.alterarValorMovimentoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 70);
            // 
            // apagarMovimentoToolStripMenuItem
            // 
            this.apagarMovimentoToolStripMenuItem.Name = "apagarMovimentoToolStripMenuItem";
            this.apagarMovimentoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.apagarMovimentoToolStripMenuItem.Text = "Apagar Movimento";
            this.apagarMovimentoToolStripMenuItem.Click += new System.EventHandler(this.apagarMovimentoToolStripMenuItem_Click);
            // 
            // alterarValorMovimentoToolStripMenuItem
            // 
            this.alterarValorMovimentoToolStripMenuItem.Name = "alterarValorMovimentoToolStripMenuItem";
            this.alterarValorMovimentoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.alterarValorMovimentoToolStripMenuItem.Text = "Alterar Valor Movimento";
            this.alterarValorMovimentoToolStripMenuItem.Click += new System.EventHandler(this.alterarValorMovimentoToolStripMenuItem_Click);
            // 
            // SituacaoPedidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 446);
            this.Controls.Add(this.gridPagto);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gridPedido);
            this.Controls.Add(this.panel1);
            this.Name = "SituacaoPedidoForm";
            this.Text = "Situação Pedido";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagto)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridPedido;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txNrPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView gridPagto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDataPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbValor;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem apagarMovimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarValorMovimentoToolStripMenuItem;
    }
}