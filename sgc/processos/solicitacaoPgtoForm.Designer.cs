namespace sgc.processos
{
    partial class solicitacaoPgtoForm
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
            this.btExcluir = new System.Windows.Forms.Button();
            this.btAtender = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbValorTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridSocilitacoes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSocilitacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btExcluir);
            this.panel1.Controls.Add(this.btAtender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 48);
            this.panel1.TabIndex = 0;
            // 
            // btExcluir
            // 
            this.btExcluir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btExcluir.Image = global::sgc.Properties.Resources.delete;
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcluir.Location = new System.Drawing.Point(153, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(130, 30);
            this.btExcluir.TabIndex = 1;
            this.btExcluir.Text = "Excluir Solicitação";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAtender
            // 
            this.btAtender.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAtender.Image = global::sgc.Properties.Resources.accept;
            this.btAtender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtender.Location = new System.Drawing.Point(12, 12);
            this.btAtender.Name = "btAtender";
            this.btAtender.Size = new System.Drawing.Size(135, 30);
            this.btAtender.TabIndex = 0;
            this.btAtender.Text = "Atender Solicitação";
            this.btAtender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAtender.UseVisualStyleBackColor = false;
            this.btAtender.Click += new System.EventHandler(this.btAtender_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbValorTotal);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 82);
            this.panel2.TabIndex = 1;
            // 
            // lbValorTotal
            // 
            this.lbValorTotal.AutoSize = true;
            this.lbValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTotal.Location = new System.Drawing.Point(12, 27);
            this.lbValorTotal.Name = "lbValorTotal";
            this.lbValorTotal.Size = new System.Drawing.Size(40, 20);
            this.lbValorTotal.TabIndex = 1;
            this.lbValorTotal.Text = "0,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Total de Solicitações Até o Momento:";
            // 
            // gridSocilitacoes
            // 
            this.gridSocilitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSocilitacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSocilitacoes.Location = new System.Drawing.Point(0, 48);
            this.gridSocilitacoes.Name = "gridSocilitacoes";
            this.gridSocilitacoes.Size = new System.Drawing.Size(623, 354);
            this.gridSocilitacoes.TabIndex = 2;
            // 
            // solicitacaoPgtoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 484);
            this.Controls.Add(this.gridSocilitacoes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "solicitacaoPgtoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitção de Pagamento";
            this.Load += new System.EventHandler(this.solicitacaoPgtoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSocilitacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridSocilitacoes;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btAtender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbValorTotal;
    }
}