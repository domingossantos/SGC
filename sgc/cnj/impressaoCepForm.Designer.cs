namespace sgc.cnj
{
    partial class impressaoCepForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sGCDataSet = new sgc.SGCDataSet();
            this.tblListaCEPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblListaCEPTableAdapter = new sgc.SGCDataSetTableAdapters.tblListaCEPTableAdapter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaCEPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 53);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 396);
            this.panel2.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsLIstaCep";
            reportDataSource1.Value = this.tblListaCEPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sgc.relatorios.listaProvimentoCep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(760, 396);
            this.reportViewer1.TabIndex = 0;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblListaCEPBindingSource
            // 
            this.tblListaCEPBindingSource.DataMember = "tblListaCEP";
            this.tblListaCEPBindingSource.DataSource = this.sGCDataSet;
            // 
            // tblListaCEPTableAdapter
            // 
            this.tblListaCEPTableAdapter.ClearBeforeFill = true;
            // 
            // impressaoCepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "impressaoCepForm";
            this.Text = "impressaoCepForm";
            this.Load += new System.EventHandler(this.impressaoCepForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaCEPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SGCDataSet sGCDataSet;
        private System.Windows.Forms.BindingSource tblListaCEPBindingSource;
        private SGCDataSetTableAdapters.tblListaCEPTableAdapter tblListaCEPTableAdapter;
    }
}