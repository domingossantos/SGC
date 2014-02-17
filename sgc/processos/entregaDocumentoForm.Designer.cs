namespace sgc.processos
{
    partial class entregaDocumentoForm
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
            this.btCancelar = new System.Windows.Forms.Button();
            this.btEntregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNrProcesso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLivroFolha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::sgc.Properties.Resources.cancel16;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(130, 174);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(87, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btEntregar
            // 
            this.btEntregar.Image = global::sgc.Properties.Resources.accept;
            this.btEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntregar.Location = new System.Drawing.Point(223, 174);
            this.btEntregar.Name = "btEntregar";
            this.btEntregar.Size = new System.Drawing.Size(97, 23);
            this.btEntregar.TabIndex = 0;
            this.btEntregar.Text = "Entregar";
            this.btEntregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEntregar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nº Processo";
            // 
            // lbNrProcesso
            // 
            this.lbNrProcesso.AutoSize = true;
            this.lbNrProcesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNrProcesso.Location = new System.Drawing.Point(12, 25);
            this.lbNrProcesso.Name = "lbNrProcesso";
            this.lbNrProcesso.Size = new System.Drawing.Size(99, 20);
            this.lbNrProcesso.TabIndex = 3;
            this.lbNrProcesso.Text = "0000000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ato";
            // 
            // lbAto
            // 
            this.lbAto.AutoSize = true;
            this.lbAto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAto.Location = new System.Drawing.Point(12, 68);
            this.lbAto.Name = "lbAto";
            this.lbAto.Size = new System.Drawing.Size(69, 20);
            this.lbAto.TabIndex = 5;
            this.lbAto.Text = "Sem ato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Livro Folha";
            // 
            // lbLivroFolha
            // 
            this.lbLivroFolha.AutoSize = true;
            this.lbLivroFolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLivroFolha.Location = new System.Drawing.Point(13, 126);
            this.lbLivroFolha.Name = "lbLivroFolha";
            this.lbLivroFolha.Size = new System.Drawing.Size(18, 20);
            this.lbLivroFolha.TabIndex = 7;
            this.lbLivroFolha.Text = "0";
            // 
            // entregaDocumentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 209);
            this.Controls.Add(this.lbLivroFolha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbAto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNrProcesso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btEntregar);
            this.Name = "entregaDocumentoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrega Documento";
            this.Load += new System.EventHandler(this.entregaDocumentoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEntregar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNrProcesso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbAto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLivroFolha;
    }
}