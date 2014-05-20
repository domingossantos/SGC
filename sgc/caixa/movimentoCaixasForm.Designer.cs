namespace sgc.caixa
{
    partial class movimentoCaixasForm
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
            this.dtMovimento = new System.Windows.Forms.DateTimePicker();
            this.btImprimir = new System.Windows.Forms.Button();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Início Movimento";
            // 
            // dtMovimento
            // 
            this.dtMovimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMovimento.Location = new System.Drawing.Point(12, 25);
            this.dtMovimento.Name = "dtMovimento";
            this.dtMovimento.Size = new System.Drawing.Size(115, 20);
            this.dtMovimento.TabIndex = 1;
            this.dtMovimento.Value = new System.DateTime(2014, 5, 19, 0, 0, 0, 0);
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btImprimir.Image = global::sgc.Properties.Resources.kfax;
            this.btImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImprimir.Location = new System.Drawing.Point(182, 54);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(94, 33);
            this.btImprimir.TabIndex = 2;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(12, 67);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(115, 20);
            this.dtFim.TabIndex = 3;
            this.dtFim.Value = new System.DateTime(2014, 5, 19, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data Final Movimento";
            // 
            // movimentoCaixasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 91);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.dtMovimento);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "movimentoCaixasForm";
            this.Text = "Movimento Caixas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtMovimento;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label label2;
    }
}