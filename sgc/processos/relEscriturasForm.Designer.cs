namespace sgc.processos
{
    partial class relEscriturasForm
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
            this.tblListaEscrituraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sGCDataSet = new sgc.SGCDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tblListaEscrituraTableAdapter = new sgc.SGCDataSetTableAdapters.tblListaEscrituraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaEscrituraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tblListaEscrituraBindingSource
            // 
            this.tblListaEscrituraBindingSource.DataMember = "tblListaEscritura";
            this.tblListaEscrituraBindingSource.DataSource = this.sGCDataSet;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsListaEscritura";
            reportDataSource1.Value = this.tblListaEscrituraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sgc.relatorios.listaEscrituras.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(489, 424);
            this.reportViewer1.TabIndex = 0;
            // 
            // tblListaEscrituraTableAdapter
            // 
            this.tblListaEscrituraTableAdapter.ClearBeforeFill = true;
            // 
            // relEscriturasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 424);
            this.Controls.Add(this.reportViewer1);
            this.Name = "relEscriturasForm";
            this.Text = "Relatorio Escrituras";
            this.Load += new System.EventHandler(this.relEscriturasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblListaEscrituraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SGCDataSet sGCDataSet;
        public System.Windows.Forms.BindingSource tblListaEscrituraBindingSource;
        public SGCDataSetTableAdapters.tblListaEscrituraTableAdapter tblListaEscrituraTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}