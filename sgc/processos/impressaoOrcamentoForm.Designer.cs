namespace sgc.processos
{
    partial class impressaoOrcamentoForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sGCDataSet = new sgc.SGCDataSet();
            this.tblOrcamentoEscrituraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblOrcamentoEscrituraTableAdapter = new sgc.SGCDataSetTableAdapters.tblOrcamentoEscrituraTableAdapter();
            this.itensOrcamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itensOrcamentoTableAdapter = new sgc.SGCDataSetTableAdapters.ItensOrcamentoTableAdapter();
            this.pessoasOrcamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pessoasOrcamentoTableAdapter = new sgc.SGCDataSetTableAdapters.PessoasOrcamentoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrcamentoEscrituraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itensOrcamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoasOrcamentoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // report
            // 
            this.report.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "dsOrcamento";
            reportDataSource4.Value = this.tblOrcamentoEscrituraBindingSource;
            reportDataSource5.Name = "dsItens";
            reportDataSource5.Value = this.itensOrcamentoBindingSource;
            reportDataSource6.Name = "dsPessoas";
            reportDataSource6.Value = this.pessoasOrcamentoBindingSource;
            this.report.LocalReport.DataSources.Add(reportDataSource4);
            this.report.LocalReport.DataSources.Add(reportDataSource5);
            this.report.LocalReport.DataSources.Add(reportDataSource6);
            this.report.LocalReport.ReportEmbeddedResource = "sgc.relatorios.relOrcamentoEscritura.rdlc";
            this.report.Location = new System.Drawing.Point(0, 0);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(557, 451);
            this.report.TabIndex = 0;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblOrcamentoEscrituraBindingSource
            // 
            this.tblOrcamentoEscrituraBindingSource.DataMember = "tblOrcamentoEscritura";
            this.tblOrcamentoEscrituraBindingSource.DataSource = this.sGCDataSet;
            // 
            // tblOrcamentoEscrituraTableAdapter
            // 
            this.tblOrcamentoEscrituraTableAdapter.ClearBeforeFill = true;
            // 
            // itensOrcamentoBindingSource
            // 
            this.itensOrcamentoBindingSource.DataMember = "ItensOrcamento";
            this.itensOrcamentoBindingSource.DataSource = this.sGCDataSet;
            // 
            // itensOrcamentoTableAdapter
            // 
            this.itensOrcamentoTableAdapter.ClearBeforeFill = true;
            // 
            // pessoasOrcamentoBindingSource
            // 
            this.pessoasOrcamentoBindingSource.DataMember = "PessoasOrcamento";
            this.pessoasOrcamentoBindingSource.DataSource = this.sGCDataSet;
            // 
            // pessoasOrcamentoTableAdapter
            // 
            this.pessoasOrcamentoTableAdapter.ClearBeforeFill = true;
            // 
            // impressaoOrcamentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 451);
            this.Controls.Add(this.report);
            this.Name = "impressaoOrcamentoForm";
            this.Text = "impressaoOrcamentoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.impressaoOrcamentoForm_FormClosing);
            this.Load += new System.EventHandler(this.impressaoOrcamentoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrcamentoEscrituraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itensOrcamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoasOrcamentoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report;
        private System.Windows.Forms.BindingSource tblOrcamentoEscrituraBindingSource;
        private SGCDataSet sGCDataSet;
        private System.Windows.Forms.BindingSource itensOrcamentoBindingSource;
        private System.Windows.Forms.BindingSource pessoasOrcamentoBindingSource;
        private SGCDataSetTableAdapters.tblOrcamentoEscrituraTableAdapter tblOrcamentoEscrituraTableAdapter;
        private SGCDataSetTableAdapters.ItensOrcamentoTableAdapter itensOrcamentoTableAdapter;
        private SGCDataSetTableAdapters.PessoasOrcamentoTableAdapter pessoasOrcamentoTableAdapter;
    }
}