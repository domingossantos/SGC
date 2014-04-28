namespace sgc.admin
{
    partial class ImprimirFitaArquivoForm
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
            this.txArquivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btEscolheArquivo = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txArquivo
            // 
            this.txArquivo.Location = new System.Drawing.Point(12, 21);
            this.txArquivo.Name = "txArquivo";
            this.txArquivo.Size = new System.Drawing.Size(268, 20);
            this.txArquivo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arquivo";
            // 
            // btEscolheArquivo
            // 
            this.btEscolheArquivo.Location = new System.Drawing.Point(15, 73);
            this.btEscolheArquivo.Name = "btEscolheArquivo";
            this.btEscolheArquivo.Size = new System.Drawing.Size(102, 23);
            this.btEscolheArquivo.TabIndex = 2;
            this.btEscolheArquivo.Text = "Selecione Arquivo";
            this.btEscolheArquivo.UseVisualStyleBackColor = true;
            this.btEscolheArquivo.Click += new System.EventHandler(this.btEscolheArquivo_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.Location = new System.Drawing.Point(168, 73);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(112, 23);
            this.btImprimir.TabIndex = 3;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // ImprimirFitaArquivoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 108);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.btEscolheArquivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txArquivo);
            this.Name = "ImprimirFitaArquivoForm";
            this.Text = "Imprimir Fita de Arquivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txArquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btEscolheArquivo;
        private System.Windows.Forms.Button btImprimir;
    }
}