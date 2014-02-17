namespace sgc.auxiliares
{
    partial class correntistaForm
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
            this.txCpfCnpj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rbAtivo = new System.Windows.Forms.RadioButton();
            this.rbInativo = new System.Windows.Forms.RadioButton();
            this.txEndereco = new System.Windows.Forms.TextBox();
            this.txBairro = new System.Windows.Forms.TextBox();
            this.txCidade = new System.Windows.Forms.TextBox();
            this.txUF = new System.Windows.Forms.TextBox();
            this.txEmail = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txNrFone = new System.Windows.Forms.MaskedTextBox();
            this.txNrCep = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
            this.spContainer.Panel1.SuspendLayout();
            this.spContainer.Panel2.SuspendLayout();
            this.spContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // spContainer
            // 
            // 
            // spContainer.Panel1
            // 
            this.spContainer.Panel1.Controls.Add(this.txNrCep);
            this.spContainer.Panel1.Controls.Add(this.txNrFone);
            this.spContainer.Panel1.Controls.Add(this.label9);
            this.spContainer.Panel1.Controls.Add(this.txEmail);
            this.spContainer.Panel1.Controls.Add(this.txUF);
            this.spContainer.Panel1.Controls.Add(this.txCidade);
            this.spContainer.Panel1.Controls.Add(this.txBairro);
            this.spContainer.Panel1.Controls.Add(this.txEndereco);
            this.spContainer.Panel1.Controls.Add(this.rbInativo);
            this.spContainer.Panel1.Controls.Add(this.rbAtivo);
            this.spContainer.Panel1.Controls.Add(this.label8);
            this.spContainer.Panel1.Controls.Add(this.label7);
            this.spContainer.Panel1.Controls.Add(this.label6);
            this.spContainer.Panel1.Controls.Add(this.label5);
            this.spContainer.Panel1.Controls.Add(this.label4);
            this.spContainer.Panel1.Controls.Add(this.label3);
            this.spContainer.Panel1.Controls.Add(this.txNome);
            this.spContainer.Panel1.Controls.Add(this.label2);
            this.spContainer.Panel1.Controls.Add(this.txCpfCnpj);
            this.spContainer.Panel1.Controls.Add(this.label1);
            // 
            // spContainer.Panel2
            // 
            this.spContainer.Panel2.Controls.Add(this.grid);
            this.spContainer.SplitterDistance = 129;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPF/CNPJ";
            // 
            // txCpfCnpj
            // 
            this.txCpfCnpj.Location = new System.Drawing.Point(14, 18);
            this.txCpfCnpj.Name = "txCpfCnpj";
            this.txCpfCnpj.Size = new System.Drawing.Size(120, 20);
            this.txCpfCnpj.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // txNome
            // 
            this.txNome.Location = new System.Drawing.Point(143, 18);
            this.txNome.Name = "txNome";
            this.txNome.Size = new System.Drawing.Size(350, 20);
            this.txNome.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Endereço";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bairro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(574, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "CEP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Cidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "UF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "E-Mail";
            // 
            // rbAtivo
            // 
            this.rbAtivo.AutoSize = true;
            this.rbAtivo.Location = new System.Drawing.Point(545, 96);
            this.rbAtivo.Name = "rbAtivo";
            this.rbAtivo.Size = new System.Drawing.Size(49, 17);
            this.rbAtivo.TabIndex = 10;
            this.rbAtivo.TabStop = true;
            this.rbAtivo.Text = "Ativo";
            this.rbAtivo.UseVisualStyleBackColor = true;
            // 
            // rbInativo
            // 
            this.rbInativo.AutoSize = true;
            this.rbInativo.Location = new System.Drawing.Point(620, 96);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(57, 17);
            this.rbInativo.TabIndex = 11;
            this.rbInativo.TabStop = true;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;
            // 
            // txEndereco
            // 
            this.txEndereco.Location = new System.Drawing.Point(14, 57);
            this.txEndereco.Name = "txEndereco";
            this.txEndereco.Size = new System.Drawing.Size(350, 20);
            this.txEndereco.TabIndex = 12;
            // 
            // txBairro
            // 
            this.txBairro.Location = new System.Drawing.Point(374, 57);
            this.txBairro.Name = "txBairro";
            this.txBairro.Size = new System.Drawing.Size(190, 20);
            this.txBairro.TabIndex = 13;
            // 
            // txCidade
            // 
            this.txCidade.Location = new System.Drawing.Point(14, 96);
            this.txCidade.Name = "txCidade";
            this.txCidade.Size = new System.Drawing.Size(180, 20);
            this.txCidade.TabIndex = 15;
            // 
            // txUF
            // 
            this.txUF.Location = new System.Drawing.Point(207, 96);
            this.txUF.Name = "txUF";
            this.txUF.Size = new System.Drawing.Size(50, 20);
            this.txUF.TabIndex = 16;
            // 
            // txEmail
            // 
            this.txEmail.Location = new System.Drawing.Point(272, 96);
            this.txEmail.Name = "txEmail";
            this.txEmail.Size = new System.Drawing.Size(230, 20);
            this.txEmail.TabIndex = 17;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(776, 316);
            this.grid.TabIndex = 0;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(512, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fone";
            // 
            // txNrFone
            // 
            this.txNrFone.Location = new System.Drawing.Point(515, 18);
            this.txNrFone.Mask = "0000-0000";
            this.txNrFone.Name = "txNrFone";
            this.txNrFone.Size = new System.Drawing.Size(100, 20);
            this.txNrFone.TabIndex = 19;
            // 
            // txNrCep
            // 
            this.txNrCep.Location = new System.Drawing.Point(577, 57);
            this.txNrCep.Mask = "99.999-999";
            this.txNrCep.Name = "txNrCep";
            this.txNrCep.Size = new System.Drawing.Size(100, 20);
            this.txNrCep.TabIndex = 20;
            // 
            // correntistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(778, 490);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "correntistaForm";
            this.Text = "Correntistas";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txEmail;
        private System.Windows.Forms.TextBox txUF;
        private System.Windows.Forms.TextBox txCidade;
        private System.Windows.Forms.TextBox txBairro;
        private System.Windows.Forms.TextBox txEndereco;
        private System.Windows.Forms.RadioButton rbInativo;
        private System.Windows.Forms.RadioButton rbAtivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txCpfCnpj;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.MaskedTextBox txNrCep;
        private System.Windows.Forms.MaskedTextBox txNrFone;
        private System.Windows.Forms.Label label9;
    }
}
