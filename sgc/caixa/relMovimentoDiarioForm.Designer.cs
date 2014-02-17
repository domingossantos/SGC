namespace sgc.caixa
{
    partial class relMovimentoDiarioForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bTblMovimentoDia = new System.Windows.Forms.BindingSource(this.components);
            this.sGCDataSet = new sgc.SGCDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btVisualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtRelatorio = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tblMovimentoTotalDiaTableAdapter = new sgc.SGCDataSetTableAdapters.tblMovimentoTotalDiaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bTblMovimentoDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bTblMovimentoDia
            // 
            this.bTblMovimentoDia.DataMember = "tblMovimentoTotalDia";
            this.bTblMovimentoDia.DataSource = this.sGCDataSet;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btVisualizar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtRelatorio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 59);
            this.panel1.TabIndex = 1;
            // 
            // btVisualizar
            // 
            this.btVisualizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btVisualizar.Image = global::sgc.Properties.Resources.report;
            this.btVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVisualizar.Location = new System.Drawing.Point(582, 23);
            this.btVisualizar.Name = "btVisualizar";
            this.btVisualizar.Size = new System.Drawing.Size(104, 30);
            this.btVisualizar.TabIndex = 2;
            this.btVisualizar.Text = "Visualizar";
            this.btVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btVisualizar.UseVisualStyleBackColor = false;
            this.btVisualizar.Click += new System.EventHandler(this.btVisualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Impressão";
            // 
            // dtRelatorio
            // 
            this.dtRelatorio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRelatorio.Location = new System.Drawing.Point(12, 23);
            this.dtRelatorio.Name = "dtRelatorio";
            this.dtRelatorio.Size = new System.Drawing.Size(110, 20);
            this.dtRelatorio.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(689, 404);
            this.panel2.TabIndex = 2;
            // 
            // rView
            // 
            this.rView.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsMovimentoTotalDia";
            reportDataSource1.Value = this.bTblMovimentoDia;
            this.rView.LocalReport.DataSources.Add(reportDataSource1);
            this.rView.LocalReport.ReportEmbeddedResource = "sgc.relatorios.relMovimentoDia.rdlc";
            this.rView.Location = new System.Drawing.Point(0, 0);
            this.rView.Name = "rView";
            this.rView.Size = new System.Drawing.Size(689, 404);
            this.rView.TabIndex = 1;
            // 
            // tblMovimentoTotalDiaTableAdapter
            // 
            this.tblMovimentoTotalDiaTableAdapter.ClearBeforeFill = true;
            // 
            // relMovimentoDiarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "relMovimentoDiarioForm";
            this.Text = "Movimento Diario";
            this.Load += new System.EventHandler(this.relMovimentoDiarioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bTblMovimentoDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btVisualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtRelatorio;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer rView;
        private System.Windows.Forms.BindingSource bTblMovimentoDia;
        private SGCDataSetTableAdapters.tblMovimentoTotalDiaTableAdapter tblMovimentoTotalDiaTableAdapter;
        protected SGCDataSet sGCDataSet;
    }
}