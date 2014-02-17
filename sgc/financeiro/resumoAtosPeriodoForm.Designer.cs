namespace sgc.financeiro
{
    partial class resumoAtosPeriodoForm
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
            this.btPesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.view = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sGCDataSet = new sgc.SGCDataSet();
            this.tblItensPedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblItensPedidoTableAdapter = new sgc.SGCDataSetTableAdapters.tblItensPedidoTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblItensPedidoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.dtFim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtInicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 61);
            this.panel1.TabIndex = 0;
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisar.Image = global::sgc.Properties.Resources.report;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisar.Location = new System.Drawing.Point(588, 12);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(82, 33);
            this.btPesquisar.TabIndex = 0;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Inicial";
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(12, 25);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(107, 20);
            this.dtInicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Final";
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(144, 25);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(101, 20);
            this.dtFim.TabIndex = 4;
            // 
            // view
            // 
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsRelAtosRealizados";
            reportDataSource1.Value = this.tblItensPedidoBindingSource;
            this.view.LocalReport.DataSources.Add(reportDataSource1);
            this.view.LocalReport.ReportEmbeddedResource = "sgc.relatorios.relAtosRealizados.rdlc";
            this.view.Location = new System.Drawing.Point(0, 61);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(682, 431);
            this.view.TabIndex = 1;
            // 
            // sGCDataSet
            // 
            this.sGCDataSet.DataSetName = "SGCDataSet";
            this.sGCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblItensPedidoBindingSource
            // 
            this.tblItensPedidoBindingSource.DataMember = "tblItensPedido";
            this.tblItensPedidoBindingSource.DataSource = this.sGCDataSet;
            // 
            // tblItensPedidoTableAdapter
            // 
            this.tblItensPedidoTableAdapter.ClearBeforeFill = true;
            // 
            // resumoAtosPeriodoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 492);
            this.Controls.Add(this.view);
            this.Controls.Add(this.panel1);
            this.Name = "resumoAtosPeriodoForm";
            this.Text = "Resumo Atos Periodo";
            this.Load += new System.EventHandler(this.resumoAtosPeriodoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblItensPedidoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer view;
        private System.Windows.Forms.BindingSource tblItensPedidoBindingSource;
        private SGCDataSet sGCDataSet;
        private SGCDataSetTableAdapters.tblItensPedidoTableAdapter tblItensPedidoTableAdapter;
    }
}