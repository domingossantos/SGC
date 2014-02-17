namespace sgc.auxiliares
{
    partial class PessoaForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbFisca = new System.Windows.Forms.RadioButton();
            this.rbJuridica = new System.Windows.Forms.RadioButton();
            this.txCpfCnpj = new System.Windows.Forms.TextBox();
            this.txNome = new System.Windows.Forms.TextBox();
            this.txEndereco = new System.Windows.Forms.TextBox();
            this.txFones = new System.Windows.Forms.TextBox();
            this.txEmail = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Pessoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPF/CNPJ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Endereço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "E-mail";
            // 
            // rbFisca
            // 
            this.rbFisca.AutoSize = true;
            this.rbFisca.Location = new System.Drawing.Point(16, 39);
            this.rbFisca.Name = "rbFisca";
            this.rbFisca.Size = new System.Drawing.Size(58, 17);
            this.rbFisca.TabIndex = 6;
            this.rbFisca.TabStop = true;
            this.rbFisca.Text = "FISICA";
            this.rbFisca.UseVisualStyleBackColor = true;
            // 
            // rbJuridica
            // 
            this.rbJuridica.AutoSize = true;
            this.rbJuridica.Location = new System.Drawing.Point(90, 39);
            this.rbJuridica.Name = "rbJuridica";
            this.rbJuridica.Size = new System.Drawing.Size(74, 17);
            this.rbJuridica.TabIndex = 7;
            this.rbJuridica.TabStop = true;
            this.rbJuridica.Text = "JURIDICA";
            this.rbJuridica.UseVisualStyleBackColor = true;
            // 
            // txCpfCnpj
            // 
            this.txCpfCnpj.Location = new System.Drawing.Point(16, 86);
            this.txCpfCnpj.Name = "txCpfCnpj";
            this.txCpfCnpj.Size = new System.Drawing.Size(137, 20);
            this.txCpfCnpj.TabIndex = 8;
            // 
            // txNome
            // 
            this.txNome.Location = new System.Drawing.Point(16, 131);
            this.txNome.Name = "txNome";
            this.txNome.Size = new System.Drawing.Size(400, 20);
            this.txNome.TabIndex = 9;
            // 
            // txEndereco
            // 
            this.txEndereco.Location = new System.Drawing.Point(15, 180);
            this.txEndereco.Name = "txEndereco";
            this.txEndereco.Size = new System.Drawing.Size(401, 20);
            this.txEndereco.TabIndex = 10;
            // 
            // txFones
            // 
            this.txFones.Location = new System.Drawing.Point(16, 228);
            this.txFones.Name = "txFones";
            this.txFones.Size = new System.Drawing.Size(148, 20);
            this.txFones.TabIndex = 11;
            // 
            // txEmail
            // 
            this.txEmail.Location = new System.Drawing.Point(16, 278);
            this.txEmail.Name = "txEmail";
            this.txEmail.Size = new System.Drawing.Size(400, 20);
            this.txEmail.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::sgc.Properties.Resources.config_users;
            this.pictureBox1.Location = new System.Drawing.Point(253, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 74);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::sgc.Properties.Resources.cancel16;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(319, 321);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(97, 23);
            this.btCancelar.TabIndex = 14;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // button1
            // 
            this.button1.Image = global::sgc.Properties.Resources.accept;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(225, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Gravar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PessoaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txEmail);
            this.Controls.Add(this.txFones);
            this.Controls.Add(this.txEndereco);
            this.Controls.Add(this.txNome);
            this.Controls.Add(this.txCpfCnpj);
            this.Controls.Add(this.rbJuridica);
            this.Controls.Add(this.rbFisca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PessoaForm";
            this.Text = "Pessoa";
            this.Load += new System.EventHandler(this.PessoaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbFisca;
        private System.Windows.Forms.RadioButton rbJuridica;
        private System.Windows.Forms.TextBox txCpfCnpj;
        private System.Windows.Forms.TextBox txNome;
        private System.Windows.Forms.TextBox txEndereco;
        private System.Windows.Forms.TextBox txFones;
        private System.Windows.Forms.TextBox txEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button button1;
    }
}