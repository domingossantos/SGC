namespace sgc.controleSelos
{
    partial class tipoSeloForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txSerie = new System.Windows.Forms.TextBox();
            this.txDescricao = new System.Windows.Forms.TextBox();
            this.txValor = new System.Windows.Forms.TextBox();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.ckGratuito = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
            this.spContainer.Panel1.SuspendLayout();
            this.spContainer.Panel2.SuspendLayout();
            this.spContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
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
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // spContainer
            // 
            // 
            // spContainer.Panel1
            // 
            this.spContainer.Panel1.Controls.Add(this.ckGratuito);
            this.spContainer.Panel1.Controls.Add(this.cbTipoDoc);
            this.spContainer.Panel1.Controls.Add(this.txValor);
            this.spContainer.Panel1.Controls.Add(this.txDescricao);
            this.spContainer.Panel1.Controls.Add(this.txSerie);
            this.spContainer.Panel1.Controls.Add(this.label5);
            this.spContainer.Panel1.Controls.Add(this.label4);
            this.spContainer.Panel1.Controls.Add(this.label3);
            this.spContainer.Panel1.Controls.Add(this.label2);
            this.spContainer.Panel1.Controls.Add(this.lbCodigo);
            this.spContainer.Panel1.Controls.Add(this.label1);
            // 
            // spContainer.Panel2
            // 
            this.spContainer.Panel2.Controls.Add(this.grid);
            this.spContainer.SplitterDistance = 120;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(776, 325);
            this.grid.TabIndex = 10;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(11, 29);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 1;
            this.lbCodigo.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Série";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Descrição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Valor Selo";
            // 
            // txSerie
            // 
            this.txSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txSerie.Location = new System.Drawing.Point(19, 75);
            this.txSerie.Name = "txSerie";
            this.txSerie.Size = new System.Drawing.Size(30, 20);
            this.txSerie.TabIndex = 7;
            // 
            // txDescricao
            // 
            this.txDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txDescricao.Location = new System.Drawing.Point(80, 75);
            this.txDescricao.Name = "txDescricao";
            this.txDescricao.Size = new System.Drawing.Size(300, 20);
            this.txDescricao.TabIndex = 8;
            // 
            // txValor
            // 
            this.txValor.Location = new System.Drawing.Point(416, 75);
            this.txValor.Name = "txValor";
            this.txValor.Size = new System.Drawing.Size(100, 20);
            this.txValor.TabIndex = 9;
            this.txValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txValor_KeyDown);
            this.txValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txValor_KeyPress);
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Location = new System.Drawing.Point(80, 30);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(250, 21);
            this.cbTipoDoc.TabIndex = 6;
            // 
            // ckGratuito
            // 
            this.ckGratuito.AutoSize = true;
            this.ckGratuito.Location = new System.Drawing.Point(546, 75);
            this.ckGratuito.Name = "ckGratuito";
            this.ckGratuito.Size = new System.Drawing.Size(78, 17);
            this.ckGratuito.TabIndex = 14;
            this.ckGratuito.Text = "Gratuidade";
            this.ckGratuito.UseVisualStyleBackColor = true;
            // 
            // tipoSeloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(778, 490);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "tipoSeloForm";
            this.Text = "Tipo Selo";
            this.Load += new System.EventHandler(this.tipoSeloForm_Load);
            this.panel1.ResumeLayout(false);
            this.spContainer.Panel1.ResumeLayout(false);
            this.spContainer.Panel1.PerformLayout();
            this.spContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).EndInit();
            this.spContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txValor;
        private System.Windows.Forms.TextBox txDescricao;
        private System.Windows.Forms.TextBox txSerie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoDoc;
        private System.Windows.Forms.CheckBox ckGratuito;
    }
}
