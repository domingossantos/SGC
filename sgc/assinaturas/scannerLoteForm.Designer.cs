namespace sgc.assinaturas
{
    partial class scannerLoteForm
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
            this.txIni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txFim = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btPesquisa = new System.Windows.Forms.Button();
            this.btScanner = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imagem = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCartao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.cbScanner = new System.Windows.Forms.ComboBox();
            this.btAdicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cartão Inicial";
            // 
            // txIni
            // 
            this.txIni.Location = new System.Drawing.Point(12, 25);
            this.txIni.Name = "txIni";
            this.txIni.Size = new System.Drawing.Size(100, 20);
            this.txIni.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cartão Final";
            // 
            // txFim
            // 
            this.txFim.Location = new System.Drawing.Point(12, 74);
            this.txFim.Name = "txFim";
            this.txFim.Size = new System.Drawing.Size(100, 20);
            this.txFim.TabIndex = 3;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 138);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(193, 318);
            this.grid.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lista de Cartões";
            // 
            // btPesquisa
            // 
            this.btPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisa.Image = global::sgc.Properties.Resources.evolution_contacts;
            this.btPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisa.Location = new System.Drawing.Point(129, 4);
            this.btPesquisa.Name = "btPesquisa";
            this.btPesquisa.Size = new System.Drawing.Size(97, 41);
            this.btPesquisa.TabIndex = 6;
            this.btPesquisa.Text = "Pesquisar";
            this.btPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisa.UseVisualStyleBackColor = false;
            this.btPesquisa.Click += new System.EventHandler(this.btPesquisa_Click);
            // 
            // btScanner
            // 
            this.btScanner.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btScanner.Image = global::sgc.Properties.Resources.kfax;
            this.btScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btScanner.Location = new System.Drawing.Point(129, 90);
            this.btScanner.Name = "btScanner";
            this.btScanner.Size = new System.Drawing.Size(97, 41);
            this.btScanner.TabIndex = 7;
            this.btScanner.Text = "Scannear";
            this.btScanner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btScanner.UseVisualStyleBackColor = false;
            this.btScanner.Click += new System.EventHandler(this.btScanner_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.imagem);
            this.panel1.Location = new System.Drawing.Point(226, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 318);
            this.panel1.TabIndex = 8;
            // 
            // imagem
            // 
            this.imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagem.Location = new System.Drawing.Point(0, 0);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(395, 318);
            this.imagem.TabIndex = 0;
            this.imagem.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cartão Atual";
            // 
            // lbCartao
            // 
            this.lbCartao.AutoSize = true;
            this.lbCartao.Location = new System.Drawing.Point(232, 28);
            this.lbCartao.Name = "lbCartao";
            this.lbCartao.Size = new System.Drawing.Size(43, 13);
            this.lbCartao.TabIndex = 10;
            this.lbCartao.Text = "000000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nome";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(232, 74);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(70, 13);
            this.lbNome.TabIndex = 12;
            this.lbNome.Text = "Nome Cliente";
            // 
            // cbScanner
            // 
            this.cbScanner.FormattingEnabled = true;
            this.cbScanner.Location = new System.Drawing.Point(500, 20);
            this.cbScanner.Name = "cbScanner";
            this.cbScanner.Size = new System.Drawing.Size(121, 21);
            this.cbScanner.TabIndex = 13;
            this.cbScanner.Visible = false;
            // 
            // btAdicionar
            // 
            this.btAdicionar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAdicionar.Image = global::sgc.Properties.Resources.All_software_is_current;
            this.btAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdicionar.Location = new System.Drawing.Point(130, 51);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(96, 36);
            this.btAdicionar.TabIndex = 15;
            this.btAdicionar.Text = "Ad Cartão";
            this.btAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAdicionar.UseVisualStyleBackColor = false;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // scannerLoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(633, 468);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.cbScanner);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbCartao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btScanner);
            this.Controls.Add(this.btPesquisa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txFim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txIni);
            this.Controls.Add(this.label1);
            this.Name = "scannerLoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanner em Lote";
            this.Load += new System.EventHandler(this.scannerLoteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txFim;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btPesquisa;
        private System.Windows.Forms.Button btScanner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbCartao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.ComboBox cbScanner;
        private System.Windows.Forms.Button btAdicionar;
    }
}