namespace sgc.financeiro
{
    partial class relAtendimentoLoginForm
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
            this.btVisualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtRelatorio = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btVisualizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtRelatorio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1392, 120);
            this.panel1.TabIndex = 0;
            // 
            // btVisualizar
            // 
            this.btVisualizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btVisualizar.Image = global::sgc.Properties.Resources.report;
            this.btVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVisualizar.Location = new System.Drawing.Point(1155, 49);
            this.btVisualizar.Margin = new System.Windows.Forms.Padding(6);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(208, 58);
            this.btVisualizar.TabIndex = 5;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btVisualizar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Impressão";
            // 
            // dtRelatorio
            // 
            this.dtRelatorio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRelatorio.Location = new System.Drawing.Point(15, 49);
            this.dtRelatorio.Margin = new System.Windows.Forms.Padding(6);
            this.dtRelatorio.Name = "dtRelatorio";
            this.dtRelatorio.Size = new System.Drawing.Size(216, 31);
            this.dtRelatorio.TabIndex = 3;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sgc.relatorios.relAtendimentoLogin.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 120);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1392, 593);
            this.reportViewer1.TabIndex = 1;
            // 
            // relAtendimentoLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 713);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "relAtendimentoLoginForm";
            this.Text = "Relatorio Atendimento por Usuario";
            this.Load += new System.EventHandler(this.relAtendimentoLoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtRelatorio;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}