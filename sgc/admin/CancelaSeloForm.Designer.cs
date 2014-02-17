namespace sgc.admin
{
    partial class CancelaSeloForm
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
            this.brRestaurar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoSelo = new System.Windows.Forms.ComboBox();
            this.txFim = new System.Windows.Forms.TextBox();
            this.txInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.brRestaurar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbTipoSelo);
            this.panel1.Controls.Add(this.txFim);
            this.panel1.Controls.Add(this.txInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 81);
            this.panel1.TabIndex = 0;
            // 
            // brRestaurar
            // 
            this.brRestaurar.Location = new System.Drawing.Point(489, 51);
            this.brRestaurar.Name = "brRestaurar";
            this.brRestaurar.Size = new System.Drawing.Size(122, 23);
            this.brRestaurar.TabIndex = 8;
            this.brRestaurar.Text = "Restaurar Selos";
            this.brRestaurar.UseVisualStyleBackColor = true;
            this.brRestaurar.Click += new System.EventHandler(this.brRestaurar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo";
            // 
            // cmbTipoSelo
            // 
            this.cmbTipoSelo.FormattingEnabled = true;
            this.cmbTipoSelo.Location = new System.Drawing.Point(252, 24);
            this.cmbTipoSelo.Name = "cmbTipoSelo";
            this.cmbTipoSelo.Size = new System.Drawing.Size(210, 21);
            this.cmbTipoSelo.TabIndex = 6;
            // 
            // txFim
            // 
            this.txFim.Location = new System.Drawing.Point(131, 25);
            this.txFim.MaxLength = 10;
            this.txFim.Name = "txFim";
            this.txFim.Size = new System.Drawing.Size(100, 20);
            this.txFim.TabIndex = 5;
            // 
            // txInicio
            // 
            this.txInicio.Location = new System.Drawing.Point(15, 25);
            this.txInicio.MaxLength = 10;
            this.txInicio.Name = "txInicio";
            this.txInicio.Size = new System.Drawing.Size(100, 20);
            this.txInicio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selo Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selo Inicial";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(361, 51);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar Selo";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(489, 12);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(122, 23);
            this.btnPesquisa.TabIndex = 0;
            this.btnPesquisa.Text = "Pesquisar Selo";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 81);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(623, 325);
            this.grid.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Marcar como Utilizado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelaSeloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 406);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "CancelaSeloForm";
            this.Text = "Cancelar Selos";
            this.Load += new System.EventHandler(this.CancelaSeloForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoSelo;
        private System.Windows.Forms.TextBox txFim;
        private System.Windows.Forms.TextBox txInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button brRestaurar;
        private System.Windows.Forms.Button button1;
    }
}