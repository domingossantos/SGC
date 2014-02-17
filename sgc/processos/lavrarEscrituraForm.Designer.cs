namespace sgc.processos
{
    partial class lavrarEscrituraForm
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
            this.lbFicha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAtos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txLivro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txFolha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txNrSelo = new System.Windows.Forms.TextBox();
            this.btGetSelo = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ficha:";
            // 
            // lbFicha
            // 
            this.lbFicha.AutoSize = true;
            this.lbFicha.Location = new System.Drawing.Point(54, 18);
            this.lbFicha.Name = "lbFicha";
            this.lbFicha.Size = new System.Drawing.Size(13, 13);
            this.lbFicha.TabIndex = 1;
            this.lbFicha.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ato:";
            // 
            // cbAtos
            // 
            this.cbAtos.FormattingEnabled = true;
            this.cbAtos.Location = new System.Drawing.Point(66, 51);
            this.cbAtos.Name = "cbAtos";
            this.cbAtos.Size = new System.Drawing.Size(390, 21);
            this.cbAtos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Livro:";
            // 
            // txLivro
            // 
            this.txLivro.Location = new System.Drawing.Point(66, 90);
            this.txLivro.Name = "txLivro";
            this.txLivro.Size = new System.Drawing.Size(100, 20);
            this.txLivro.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Folha:";
            // 
            // txFolha
            // 
            this.txFolha.Location = new System.Drawing.Point(66, 134);
            this.txFolha.Name = "txFolha";
            this.txFolha.Size = new System.Drawing.Size(100, 20);
            this.txFolha.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nº Selo:";
            // 
            // txNrSelo
            // 
            this.txNrSelo.Location = new System.Drawing.Point(66, 183);
            this.txNrSelo.Name = "txNrSelo";
            this.txNrSelo.Size = new System.Drawing.Size(100, 20);
            this.txNrSelo.TabIndex = 9;
            // 
            // btGetSelo
            // 
            this.btGetSelo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btGetSelo.Image = global::sgc.Properties.Resources.mail_sent;
            this.btGetSelo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGetSelo.Location = new System.Drawing.Point(182, 180);
            this.btGetSelo.Name = "btGetSelo";
            this.btGetSelo.Size = new System.Drawing.Size(106, 23);
            this.btGetSelo.TabIndex = 10;
            this.btGetSelo.Text = "Atribuir Selo";
            this.btGetSelo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGetSelo.UseVisualStyleBackColor = false;
            this.btGetSelo.Click += new System.EventHandler(this.btGetSelo_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelar.Image = global::sgc.Properties.Resources.cancel24;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(346, 222);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(109, 36);
            this.btCancelar.TabIndex = 11;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Image = global::sgc.Properties.Resources.advanced_directory;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(223, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "Lavrar Escritura";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lavrarEscrituraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 270);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGetSelo);
            this.Controls.Add(this.txNrSelo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txFolha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txLivro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAtos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFicha);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "lavrarEscrituraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lavrar Escritura";
            this.Load += new System.EventHandler(this.lavrarEscrituraForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFicha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAtos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txLivro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txFolha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txNrSelo;
        private System.Windows.Forms.Button btGetSelo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button button1;
    }
}