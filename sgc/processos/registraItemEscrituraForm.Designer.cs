namespace sgc.processos
{
    partial class registraItemEscrituraForm
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
            this.lbItem = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txValor = new System.Windows.Forms.TextBox();
            this.lbQuant = new System.Windows.Forms.Label();
            this.txQuant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txDescricao = new System.Windows.Forms.TextBox();
            this.btGravar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Location = new System.Drawing.Point(12, 9);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(27, 13);
            this.lbItem.TabIndex = 2;
            this.lbItem.Text = "Item";
            // 
            // cbItem
            // 
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(15, 25);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(342, 21);
            this.cbItem.TabIndex = 3;
            this.cbItem.SelectionChangeCommitted += new System.EventHandler(this.cbItem_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Valor";
            // 
            // txValor
            // 
            this.txValor.Location = new System.Drawing.Point(15, 75);
            this.txValor.Name = "txValor";
            this.txValor.Size = new System.Drawing.Size(100, 20);
            this.txValor.TabIndex = 5;
            this.txValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txValor_KeyPress);
            // 
            // lbQuant
            // 
            this.lbQuant.AutoSize = true;
            this.lbQuant.Location = new System.Drawing.Point(146, 59);
            this.lbQuant.Name = "lbQuant";
            this.lbQuant.Size = new System.Drawing.Size(62, 13);
            this.lbQuant.TabIndex = 6;
            this.lbQuant.Text = "Quantidade";
            // 
            // txQuant
            // 
            this.txQuant.Location = new System.Drawing.Point(149, 75);
            this.txQuant.Name = "txQuant";
            this.txQuant.Size = new System.Drawing.Size(100, 20);
            this.txQuant.TabIndex = 7;
            this.txQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txQuant_KeyPress);
            this.txQuant.Leave += new System.EventHandler(this.txQuant_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descrição";
            // 
            // txDescricao
            // 
            this.txDescricao.Location = new System.Drawing.Point(15, 128);
            this.txDescricao.Multiline = true;
            this.txDescricao.Name = "txDescricao";
            this.txDescricao.Size = new System.Drawing.Size(342, 145);
            this.txDescricao.TabIndex = 9;
            // 
            // btGravar
            // 
            this.btGravar.Image = global::sgc.Properties.Resources.add1_16;
            this.btGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGravar.Location = new System.Drawing.Point(219, 298);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::sgc.Properties.Resources.cancel16;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(300, 298);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 0;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // registraItemEscrituraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 333);
            this.Controls.Add(this.txDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txQuant);
            this.Controls.Add(this.lbQuant);
            this.Controls.Add(this.txValor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbItem);
            this.Controls.Add(this.lbItem);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.btCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "registraItemEscrituraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registraItemEscrituraForm";
            this.Load += new System.EventHandler(this.registraItemEscrituraForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txValor;
        private System.Windows.Forms.Label lbQuant;
        private System.Windows.Forms.TextBox txQuant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txDescricao;
    }
}