namespace sgc.assinaturas
{
    partial class recuperaDadosRemotoForm
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
            this.lbStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbQtdAssinaturas = new System.Windows.Forms.Label();
            this.pbAssin = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDataAtualizacao = new System.Windows.Forms.Label();
            this.lbQtd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCopiado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbErros = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No. de Cartões disponíveis para atualização";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status da atualização:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 210);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(74, 13);
            this.lbStatus.TabIndex = 3;
            this.lbStatus.Text = "Conectando...";
            // 
            // button1
            // 
            this.button1.Image = global::sgc.Properties.Resources.All_software_is_current;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(128, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Copiar Dados!";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbQtdAssinaturas
            // 
            this.lbQtdAssinaturas.AutoSize = true;
            this.lbQtdAssinaturas.Location = new System.Drawing.Point(12, 36);
            this.lbQtdAssinaturas.Name = "lbQtdAssinaturas";
            this.lbQtdAssinaturas.Size = new System.Drawing.Size(13, 13);
            this.lbQtdAssinaturas.TabIndex = 5;
            this.lbQtdAssinaturas.Text = "0";
            // 
            // pbAssin
            // 
            this.pbAssin.Location = new System.Drawing.Point(15, 149);
            this.pbAssin.Name = "pbAssin";
            this.pbAssin.Size = new System.Drawing.Size(382, 23);
            this.pbAssin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data da ultima atualização:";
            // 
            // lbDataAtualizacao
            // 
            this.lbDataAtualizacao.AutoSize = true;
            this.lbDataAtualizacao.Location = new System.Drawing.Point(153, 62);
            this.lbDataAtualizacao.Name = "lbDataAtualizacao";
            this.lbDataAtualizacao.Size = new System.Drawing.Size(65, 13);
            this.lbDataAtualizacao.TabIndex = 8;
            this.lbDataAtualizacao.Text = "00/00/0000";
            // 
            // lbQtd
            // 
            this.lbQtd.AutoSize = true;
            this.lbQtd.Location = new System.Drawing.Point(372, 185);
            this.lbQtd.Name = "lbQtd";
            this.lbQtd.Size = new System.Drawing.Size(13, 13);
            this.lbQtd.TabIndex = 9;
            this.lbQtd.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Copiados:";
            // 
            // lbCopiado
            // 
            this.lbCopiado.AutoSize = true;
            this.lbCopiado.Location = new System.Drawing.Point(372, 198);
            this.lbCopiado.Name = "lbCopiado";
            this.lbCopiado.Size = new System.Drawing.Size(13, 13);
            this.lbCopiado.TabIndex = 12;
            this.lbCopiado.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Erros:";
            // 
            // lbErros
            // 
            this.lbErros.AutoSize = true;
            this.lbErros.Location = new System.Drawing.Point(373, 213);
            this.lbErros.Name = "lbErros";
            this.lbErros.Size = new System.Drawing.Size(13, 13);
            this.lbErros.TabIndex = 14;
            this.lbErros.Text = "0";
            // 
            // recuperaDadosRemotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 235);
            this.Controls.Add(this.lbErros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbCopiado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbQtd);
            this.Controls.Add(this.lbDataAtualizacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbAssin);
            this.Controls.Add(this.lbQtdAssinaturas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "recuperaDadosRemotoForm";
            this.Text = "Recupera Dados Remoto";
            this.Load += new System.EventHandler(this.recuperaDadosRemotoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbQtdAssinaturas;
        private System.Windows.Forms.ProgressBar pbAssin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDataAtualizacao;
        private System.Windows.Forms.Label lbQtd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCopiado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbErros;
    }
}