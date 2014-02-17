namespace sgc.admin
{
    partial class HistoricoCancelamentoPedidosForm
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbRegEncontrados = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txFim = new System.Windows.Forms.MaskedTextBox();
            this.txInicio = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txNrPedido = new System.Windows.Forms.TextBox();
            this.btLimpar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 86);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(731, 380);
            this.grid.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btLimpar);
            this.panel1.Controls.Add(this.lbRegEncontrados);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbUsuario);
            this.panel1.Controls.Add(this.txNrPedido);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txFim);
            this.panel1.Controls.Add(this.txInicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 86);
            this.panel1.TabIndex = 2;
            // 
            // lbRegEncontrados
            // 
            this.lbRegEncontrados.AutoSize = true;
            this.lbRegEncontrados.Location = new System.Drawing.Point(174, 59);
            this.lbRegEncontrados.Name = "lbRegEncontrados";
            this.lbRegEncontrados.Size = new System.Drawing.Size(13, 13);
            this.lbRegEncontrados.TabIndex = 19;
            this.lbRegEncontrados.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Quant. de Registros Encontrados:";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(617, 49);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(98, 23);
            this.btPesquisar.TabIndex = 17;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Usuário";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(281, 23);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(130, 21);
            this.cmbUsuario.TabIndex = 14;
            this.cmbUsuario.Text = "Selecione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Final";
            // 
            // txFim
            // 
            this.txFim.Location = new System.Drawing.Point(100, 23);
            this.txFim.Mask = "00/00/0000";
            this.txFim.Name = "txFim";
            this.txFim.Size = new System.Drawing.Size(74, 20);
            this.txFim.TabIndex = 2;
            this.txFim.ValidatingType = typeof(System.DateTime);
            // 
            // txInicio
            // 
            this.txInicio.Location = new System.Drawing.Point(13, 23);
            this.txInicio.Mask = "00/00/0000";
            this.txInicio.Name = "txInicio";
            this.txInicio.Size = new System.Drawing.Size(74, 20);
            this.txInicio.TabIndex = 1;
            this.txInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "No. Pedido";
            // 
            // txNrPedido
            // 
            this.txNrPedido.Location = new System.Drawing.Point(192, 24);
            this.txNrPedido.MaxLength = 10;
            this.txNrPedido.Name = "txNrPedido";
            this.txNrPedido.Size = new System.Drawing.Size(75, 20);
            this.txNrPedido.TabIndex = 10;
            // 
            // btLimpar
            // 
            this.btLimpar.Location = new System.Drawing.Point(617, 21);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(98, 23);
            this.btLimpar.TabIndex = 20;
            this.btLimpar.Text = "Limpar Campos";
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // HistoricoCancelamentoPedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 466);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "HistoricoCancelamentoPedidosForm";
            this.Text = "Historico Cancelamento Pedidos";
            this.Load += new System.EventHandler(this.HistoricoCancelamentoPedidosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbRegEncontrados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.TextBox txNrPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txFim;
        private System.Windows.Forms.MaskedTextBox txInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLimpar;
    }
}