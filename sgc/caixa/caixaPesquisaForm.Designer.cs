namespace sgc.caixa
{
    partial class caixaPesquisaForm
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
            this.btLimpar = new System.Windows.Forms.Button();
            this.brPrint = new System.Windows.Forms.Button();
            this.brFechar = new System.Windows.Forms.Button();
            this.btPesquisa = new System.Windows.Forms.Button();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.txCaixa = new System.Windows.Forms.TextBox();
            this.Data = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btLimpar);
            this.panel1.Controls.Add(this.brPrint);
            this.panel1.Controls.Add(this.brFechar);
            this.panel1.Controls.Add(this.btPesquisa);
            this.panel1.Controls.Add(this.dtFim);
            this.panel1.Controls.Add(this.dtInicio);
            this.panel1.Controls.Add(this.cbUsuarios);
            this.panel1.Controls.Add(this.txCaixa);
            this.panel1.Controls.Add(this.Data);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 97);
            this.panel1.TabIndex = 0;
            // 
            // btLimpar
            // 
            this.btLimpar.Location = new System.Drawing.Point(626, 55);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(96, 36);
            this.btLimpar.TabIndex = 13;
            this.btLimpar.Text = "Limpar Campos";
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // brPrint
            // 
            this.brPrint.Image = global::sgc.Properties.Resources.fileprint_48;
            this.brPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brPrint.Location = new System.Drawing.Point(15, 55);
            this.brPrint.Name = "brPrint";
            this.brPrint.Size = new System.Drawing.Size(102, 36);
            this.brPrint.TabIndex = 12;
            this.brPrint.Text = "Imprimir";
            this.brPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brPrint.UseVisualStyleBackColor = true;
            this.brPrint.Click += new System.EventHandler(this.brPrint_Click);
            // 
            // brFechar
            // 
            this.brFechar.Image = global::sgc.Properties.Resources.money;
            this.brFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brFechar.Location = new System.Drawing.Point(123, 55);
            this.brFechar.Name = "brFechar";
            this.brFechar.Size = new System.Drawing.Size(114, 36);
            this.brFechar.TabIndex = 11;
            this.brFechar.Text = "Fechar Caixa";
            this.brFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brFechar.UseVisualStyleBackColor = true;
            this.brFechar.Click += new System.EventHandler(this.brFechar_Click);
            // 
            // btPesquisa
            // 
            this.btPesquisa.Image = global::sgc.Properties.Resources.search;
            this.btPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisa.Location = new System.Drawing.Point(626, 12);
            this.btPesquisa.Name = "btPesquisa";
            this.btPesquisa.Size = new System.Drawing.Size(96, 33);
            this.btPesquisa.TabIndex = 10;
            this.btPesquisa.Text = "Pesquisar";
            this.btPesquisa.UseVisualStyleBackColor = true;
            this.btPesquisa.Click += new System.EventHandler(this.btPesquisa_Click);
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(409, 25);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(93, 20);
            this.dtFim.TabIndex = 6;
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(319, 25);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(84, 20);
            this.dtInicio.TabIndex = 5;
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.FormattingEnabled = true;
            this.cbUsuarios.Location = new System.Drawing.Point(71, 25);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(242, 21);
            this.cbUsuarios.TabIndex = 4;
            // 
            // txCaixa
            // 
            this.txCaixa.Location = new System.Drawing.Point(15, 25);
            this.txCaixa.Name = "txCaixa";
            this.txCaixa.Size = new System.Drawing.Size(50, 20);
            this.txCaixa.TabIndex = 3;
            // 
            // Data
            // 
            this.Data.AutoSize = true;
            this.Data.Location = new System.Drawing.Point(316, 9);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(30, 13);
            this.Data.TabIndex = 2;
            this.Data.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuário";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Caixa";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 97);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(747, 348);
            this.grid.TabIndex = 1;
            // 
            // caixaPesquisaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 445);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "caixaPesquisaForm";
            this.Text = "Pesquisa Caixa";
            this.Load += new System.EventHandler(this.caixaPesquisaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.TextBox txCaixa;
        private System.Windows.Forms.Button btPesquisa;
        private System.Windows.Forms.Button brPrint;
        private System.Windows.Forms.Button brFechar;
        private System.Windows.Forms.Button btLimpar;
    }
}