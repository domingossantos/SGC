namespace sgc.processos
{
    partial class pesquisaEscrituraForm
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
            this.txNumSelo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txEndereco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txPEssoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancela = new System.Windows.Forms.Button();
            this.btPesquisa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSelo = new System.Windows.Forms.RadioButton();
            this.rbEndereco = new System.Windows.Forms.RadioButton();
            this.rbPessoa = new System.Windows.Forms.RadioButton();
            this.rbDatas = new System.Windows.Forms.RadioButton();
            this.rbNumero = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.txNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txNumSelo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txEndereco);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txPEssoa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btCancela);
            this.panel1.Controls.Add(this.btPesquisa);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtFinal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtInicial);
            this.panel1.Controls.Add(this.txNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 149);
            this.panel1.TabIndex = 0;
            // 
            // txNumSelo
            // 
            this.txNumSelo.Location = new System.Drawing.Point(94, 110);
            this.txNumSelo.Name = "txNumSelo";
            this.txNumSelo.Size = new System.Drawing.Size(100, 20);
            this.txNumSelo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nº Selo:";
            // 
            // txEndereco
            // 
            this.txEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txEndereco.Location = new System.Drawing.Point(94, 81);
            this.txEndereco.Name = "txEndereco";
            this.txEndereco.Size = new System.Drawing.Size(268, 20);
            this.txEndereco.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Endereço:";
            // 
            // txPEssoa
            // 
            this.txPEssoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txPEssoa.Location = new System.Drawing.Point(94, 51);
            this.txPEssoa.Name = "txPEssoa";
            this.txPEssoa.Size = new System.Drawing.Size(268, 20);
            this.txPEssoa.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nome Pessoa:";
            // 
            // btCancela
            // 
            this.btCancela.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancela.Image = global::sgc.Properties.Resources.cancel24;
            this.btCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancela.Location = new System.Drawing.Point(620, 57);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(100, 33);
            this.btCancela.TabIndex = 8;
            this.btCancela.Text = "Cancelar";
            this.btCancela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancela.UseVisualStyleBackColor = false;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // btPesquisa
            // 
            this.btPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisa.Image = global::sgc.Properties.Resources.Product_documentation24;
            this.btPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisa.Location = new System.Drawing.Point(620, 18);
            this.btPesquisa.Name = "btPesquisa";
            this.btPesquisa.Size = new System.Drawing.Size(100, 33);
            this.btPesquisa.TabIndex = 7;
            this.btPesquisa.Text = "Pesquisar";
            this.btPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisa.UseVisualStyleBackColor = false;
            this.btPesquisa.Click += new System.EventHandler(this.btPesquisa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSelo);
            this.groupBox1.Controls.Add(this.rbEndereco);
            this.groupBox1.Controls.Add(this.rbPessoa);
            this.groupBox1.Controls.Add(this.rbDatas);
            this.groupBox1.Controls.Add(this.rbNumero);
            this.groupBox1.Location = new System.Drawing.Point(383, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Busca";
            // 
            // rbSelo
            // 
            this.rbSelo.AutoSize = true;
            this.rbSelo.Location = new System.Drawing.Point(7, 109);
            this.rbSelo.Name = "rbSelo";
            this.rbSelo.Size = new System.Drawing.Size(61, 17);
            this.rbSelo.TabIndex = 4;
            this.rbSelo.TabStop = true;
            this.rbSelo.Text = "Nº Selo";
            this.rbSelo.UseVisualStyleBackColor = true;
            // 
            // rbEndereco
            // 
            this.rbEndereco.AutoSize = true;
            this.rbEndereco.Location = new System.Drawing.Point(6, 85);
            this.rbEndereco.Name = "rbEndereco";
            this.rbEndereco.Size = new System.Drawing.Size(71, 17);
            this.rbEndereco.TabIndex = 3;
            this.rbEndereco.TabStop = true;
            this.rbEndereco.Text = "Endereço";
            this.rbEndereco.UseVisualStyleBackColor = true;
            // 
            // rbPessoa
            // 
            this.rbPessoa.AutoSize = true;
            this.rbPessoa.Location = new System.Drawing.Point(6, 63);
            this.rbPessoa.Name = "rbPessoa";
            this.rbPessoa.Size = new System.Drawing.Size(146, 17);
            this.rbPessoa.TabIndex = 2;
            this.rbPessoa.TabStop = true;
            this.rbPessoa.Text = "Por Comprador/Vendedor";
            this.rbPessoa.UseVisualStyleBackColor = true;
            // 
            // rbDatas
            // 
            this.rbDatas.AutoSize = true;
            this.rbDatas.Location = new System.Drawing.Point(6, 39);
            this.rbDatas.Name = "rbDatas";
            this.rbDatas.Size = new System.Drawing.Size(81, 17);
            this.rbDatas.TabIndex = 1;
            this.rbDatas.Text = "Entra Datas";
            this.rbDatas.UseVisualStyleBackColor = true;
            // 
            // rbNumero
            // 
            this.rbNumero.AutoSize = true;
            this.rbNumero.Checked = true;
            this.rbNumero.Location = new System.Drawing.Point(6, 17);
            this.rbNumero.Name = "rbNumero";
            this.rbNumero.Size = new System.Drawing.Size(157, 17);
            this.rbNumero.TabIndex = 0;
            this.rbNumero.TabStop = true;
            this.rbNumero.Text = "Por Nº Escritura/Orçamento";
            this.rbNumero.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Final";
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinal.Location = new System.Drawing.Point(260, 25);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(102, 20);
            this.dtFinal.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Inicial ";
            // 
            // dtInicial
            // 
            this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicial.Location = new System.Drawing.Point(147, 25);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(102, 20);
            this.dtInicial.TabIndex = 2;
            // 
            // txNum
            // 
            this.txNum.Location = new System.Drawing.Point(15, 25);
            this.txNum.Name = "txNum";
            this.txNum.Size = new System.Drawing.Size(100, 20);
            this.txNum.TabIndex = 1;
            this.txNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txNum_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº Orcamento / Escritura";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 149);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(732, 332);
            this.grid.TabIndex = 1;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // pesquisaEscrituraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 481);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "pesquisaEscrituraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Escritura";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.TextBox txNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDatas;
        private System.Windows.Forms.RadioButton rbNumero;
        private System.Windows.Forms.Button btCancela;
        private System.Windows.Forms.Button btPesquisa;
        private System.Windows.Forms.TextBox txPEssoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txEndereco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbEndereco;
        private System.Windows.Forms.RadioButton rbPessoa;
        private System.Windows.Forms.TextBox txNumSelo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbSelo;
    }
}