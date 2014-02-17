namespace sgc.processos
{
    partial class registroProcuracaoAntiga
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
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAtos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txLivro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txFolha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTipoSelo = new System.Windows.Forms.ComboBox();
            this.txNrSelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txObservacao = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btGeraPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Documento";
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Location = new System.Drawing.Point(15, 25);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDoc.TabIndex = 1;
            this.cbTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cbTipoDoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ato";
            // 
            // cbAtos
            // 
            this.cbAtos.FormattingEnabled = true;
            this.cbAtos.Location = new System.Drawing.Point(146, 25);
            this.cbAtos.Name = "cbAtos";
            this.cbAtos.Size = new System.Drawing.Size(407, 21);
            this.cbAtos.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Lavratura";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Livro";
            // 
            // txLivro
            // 
            this.txLivro.Location = new System.Drawing.Point(124, 74);
            this.txLivro.Name = "txLivro";
            this.txLivro.Size = new System.Drawing.Size(100, 20);
            this.txLivro.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Folha";
            // 
            // txFolha
            // 
            this.txFolha.Location = new System.Drawing.Point(230, 74);
            this.txFolha.Name = "txFolha";
            this.txFolha.Size = new System.Drawing.Size(100, 20);
            this.txFolha.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo Selo";
            // 
            // cbTipoSelo
            // 
            this.cbTipoSelo.FormattingEnabled = true;
            this.cbTipoSelo.Location = new System.Drawing.Point(15, 131);
            this.cbTipoSelo.Name = "cbTipoSelo";
            this.cbTipoSelo.Size = new System.Drawing.Size(264, 21);
            this.cbTipoSelo.TabIndex = 12;
            // 
            // txNrSelo
            // 
            this.txNrSelo.Location = new System.Drawing.Point(296, 131);
            this.txNrSelo.Name = "txNrSelo";
            this.txNrSelo.Size = new System.Drawing.Size(100, 20);
            this.txNrSelo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nº Selo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Observação";
            // 
            // txObservacao
            // 
            this.txObservacao.Location = new System.Drawing.Point(15, 184);
            this.txObservacao.Multiline = true;
            this.txObservacao.Name = "txObservacao";
            this.txObservacao.Size = new System.Drawing.Size(538, 107);
            this.txObservacao.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Image = global::sgc.Properties.Resources.cancel16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(478, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Fechar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btGeraPedido
            // 
            this.btGeraPedido.Image = global::sgc.Properties.Resources.evolution_tasks;
            this.btGeraPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGeraPedido.Location = new System.Drawing.Point(360, 313);
            this.btGeraPedido.Name = "btGeraPedido";
            this.btGeraPedido.Size = new System.Drawing.Size(112, 23);
            this.btGeraPedido.TabIndex = 18;
            this.btGeraPedido.Text = "Gerar Pedido";
            this.btGeraPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGeraPedido.UseVisualStyleBackColor = true;
            this.btGeraPedido.Click += new System.EventHandler(this.btGeraPedido_Click);
            // 
            // registroProcuracaoAntiga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 344);
            this.Controls.Add(this.btGeraPedido);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txObservacao);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txNrSelo);
            this.Controls.Add(this.cbTipoSelo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txFolha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txLivro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAtos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTipoDoc);
            this.Controls.Add(this.label1);
            this.Name = "registroProcuracaoAntiga";
            this.Text = "Registro de Procuração Antiga";
            this.Load += new System.EventHandler(this.registroProcuracaoAntiga_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAtos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txLivro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txFolha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTipoSelo;
        private System.Windows.Forms.TextBox txNrSelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txObservacao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btGeraPedido;
    }
}