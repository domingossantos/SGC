namespace sgc.admin
{
    partial class HistoricoMovimentoSelosForm
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
            this.lbRegEncontrados = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoSelo = new System.Windows.Forms.ComboBox();
            this.txSeloFim = new System.Windows.Forms.TextBox();
            this.txSeloInicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txFim = new System.Windows.Forms.MaskedTextBox();
            this.txInicio = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btExportarXls = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExportarXls);
            this.panel1.Controls.Add(this.lbRegEncontrados);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbUsuario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbTipoSelo);
            this.panel1.Controls.Add(this.txSeloFim);
            this.panel1.Controls.Add(this.txSeloInicio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txFim);
            this.panel1.Controls.Add(this.txInicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 86);
            this.panel1.TabIndex = 0;
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
            this.label6.Location = new System.Drawing.Point(584, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Usuário";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(585, 22);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(130, 21);
            this.cmbUsuario.TabIndex = 14;
            this.cmbUsuario.Text = "Selecione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tipo";
            // 
            // cmbTipoSelo
            // 
            this.cmbTipoSelo.FormattingEnabled = true;
            this.cmbTipoSelo.Location = new System.Drawing.Point(366, 22);
            this.cmbTipoSelo.Name = "cmbTipoSelo";
            this.cmbTipoSelo.Size = new System.Drawing.Size(210, 21);
            this.cmbTipoSelo.TabIndex = 12;
            this.cmbTipoSelo.Text = "Selecione";
            // 
            // txSeloFim
            // 
            this.txSeloFim.Location = new System.Drawing.Point(279, 24);
            this.txSeloFim.MaxLength = 10;
            this.txSeloFim.Name = "txSeloFim";
            this.txSeloFim.Size = new System.Drawing.Size(73, 20);
            this.txSeloFim.TabIndex = 11;
            // 
            // txSeloInicio
            // 
            this.txSeloInicio.Location = new System.Drawing.Point(192, 24);
            this.txSeloInicio.MaxLength = 10;
            this.txSeloInicio.Name = "txSeloInicio";
            this.txSeloInicio.Size = new System.Drawing.Size(75, 20);
            this.txSeloInicio.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Selo Final";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Selo Inicial";
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
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 86);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(730, 269);
            this.grid.TabIndex = 1;
            // 
            // btExportarXls
            // 
            this.btExportarXls.Location = new System.Drawing.Point(516, 49);
            this.btExportarXls.Name = "btExportarXls";
            this.btExportarXls.Size = new System.Drawing.Size(95, 23);
            this.btExportarXls.TabIndex = 20;
            this.btExportarXls.Text = "Exportar XLS";
            this.btExportarXls.UseVisualStyleBackColor = true;
            this.btExportarXls.Click += new System.EventHandler(this.btExportarXls_Click);
            // 
            // HistoricoMovimentoSelosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 355);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "HistoricoMovimentoSelosForm";
            this.Text = "Historico Movimento Selos";
            this.Load += new System.EventHandler(this.HistoricoMovimentoSelosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txFim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoSelo;
        private System.Windows.Forms.TextBox txSeloFim;
        private System.Windows.Forms.TextBox txSeloInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Label lbRegEncontrados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btExportarXls;
    }
}