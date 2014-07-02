namespace sgc.assinaturas
{
    partial class ImpressaoCartaoForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sGCDataSet = new sgc.SGCDataSet();
            this.tblCartaoAssinaturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblCartaoAssinaturaTableAdapter = new sgc.SGCDataSetTableAdapters.tblCartaoAssinaturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCartaoAssinaturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CartaoDS";
            reportDataSource1.Value = this.tblCartaoAssinaturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sgc.relatorios.relCartaoAssinatura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(583, 409);
            this.reportViewer1.TabIndex = 0;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblCartaoAssinaturaBindingSource
            // 
            this.tblCartaoAssinaturaBindingSource.DataMember = "tblCartaoAssinatura";
            this.tblCartaoAssinaturaBindingSource.DataSource = this.sGCDataSet;
            // 
            // tblCartaoAssinaturaTableAdapter
            // 
            this.tblCartaoAssinaturaTableAdapter.ClearBeforeFill = true;
            // 
            // ImpressaoCartaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 409);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ImpressaoCartaoForm";
            this.Text = "ImpressaoCartaoForm";
            this.Load += new System.EventHandler(this.ImpressaoCartaoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCartaoAssinaturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblCartaoAssinaturaBindingSource;
        private SGCDataSet sGCDataSet;
        private SGCDataSetTableAdapters.tblCartaoAssinaturaTableAdapter tblCartaoAssinaturaTableAdapter;


    }
}