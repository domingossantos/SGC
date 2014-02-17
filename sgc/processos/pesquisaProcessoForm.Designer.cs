namespace sgc.processos
{
    partial class pesquisaProcessoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.brReabrirPedido = new System.Windows.Forms.Button();
            this.btEditarProcesso = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.txPesquisa = new System.Windows.Forms.TextBox();
            this.lbArgumentoPesquisa = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNumProcesso = new System.Windows.Forms.RadioButton();
            this.rbPesquisaCpf = new System.Windows.Forms.RadioButton();
            this.rbPesquisaNome = new System.Windows.Forms.RadioButton();
            this.grid = new System.Windows.Forms.DataGridView();
            this.rbSelo = new System.Windows.Forms.RadioButton();
            this.rbData = new System.Windows.Forms.RadioButton();
            this.rbEntreDatas = new System.Windows.Forms.RadioButton();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtFim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtInicio);
            this.panel1.Controls.Add(this.brReabrirPedido);
            this.panel1.Controls.Add(this.btEditarProcesso);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.txPesquisa);
            this.panel1.Controls.Add(this.lbArgumentoPesquisa);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 101);
            this.panel1.TabIndex = 0;
            // 
            // brReabrirPedido
            // 
            this.brReabrirPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.brReabrirPedido.Image = global::sgc.Properties.Resources.money;
            this.brReabrirPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brReabrirPedido.Location = new System.Drawing.Point(629, 32);
            this.brReabrirPedido.Name = "brReabrirPedido";
            this.brReabrirPedido.Size = new System.Drawing.Size(118, 30);
            this.brReabrirPedido.TabIndex = 5;
            this.brReabrirPedido.Text = "Reabrir Pedido";
            this.brReabrirPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brReabrirPedido.UseVisualStyleBackColor = false;
            this.brReabrirPedido.Click += new System.EventHandler(this.brReabrirPedido_Click);
            // 
            // btEditarProcesso
            // 
            this.btEditarProcesso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btEditarProcesso.Image = global::sgc.Properties.Resources.edit24;
            this.btEditarProcesso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEditarProcesso.Location = new System.Drawing.Point(629, 61);
            this.btEditarProcesso.Name = "btEditarProcesso";
            this.btEditarProcesso.Size = new System.Drawing.Size(118, 30);
            this.btEditarProcesso.TabIndex = 4;
            this.btEditarProcesso.Text = "Editar Processo";
            this.btEditarProcesso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditarProcesso.UseVisualStyleBackColor = false;
            this.btEditarProcesso.Click += new System.EventHandler(this.btEditarProcesso_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisar.Image = global::sgc.Properties.Resources.search;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisar.Location = new System.Drawing.Point(629, 3);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(118, 30);
            this.btPesquisar.TabIndex = 3;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // txPesquisa
            // 
            this.txPesquisa.Location = new System.Drawing.Point(305, 22);
            this.txPesquisa.Name = "txPesquisa";
            this.txPesquisa.Size = new System.Drawing.Size(263, 20);
            this.txPesquisa.TabIndex = 2;
            // 
            // lbArgumentoPesquisa
            // 
            this.lbArgumentoPesquisa.AutoSize = true;
            this.lbArgumentoPesquisa.Location = new System.Drawing.Point(302, 6);
            this.lbArgumentoPesquisa.Name = "lbArgumentoPesquisa";
            this.lbArgumentoPesquisa.Size = new System.Drawing.Size(119, 13);
            this.lbArgumentoPesquisa.TabIndex = 1;
            this.lbArgumentoPesquisa.Text = "Argumento de Pesquisa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEntreDatas);
            this.groupBox1.Controls.Add(this.rbData);
            this.groupBox1.Controls.Add(this.rbSelo);
            this.groupBox1.Controls.Add(this.rbNumProcesso);
            this.groupBox1.Controls.Add(this.rbPesquisaCpf);
            this.groupBox1.Controls.Add(this.rbPesquisaNome);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Argumento de Pesquisa:";
            // 
            // rbNumProcesso
            // 
            this.rbNumProcesso.AutoSize = true;
            this.rbNumProcesso.Location = new System.Drawing.Point(16, 53);
            this.rbNumProcesso.Name = "rbNumProcesso";
            this.rbNumProcesso.Size = new System.Drawing.Size(84, 17);
            this.rbNumProcesso.TabIndex = 2;
            this.rbNumProcesso.TabStop = true;
            this.rbNumProcesso.Text = "Nº Processo";
            this.rbNumProcesso.UseVisualStyleBackColor = true;
            // 
            // rbPesquisaCpf
            // 
            this.rbPesquisaCpf.AutoSize = true;
            this.rbPesquisaCpf.Location = new System.Drawing.Point(104, 19);
            this.rbPesquisaCpf.Name = "rbPesquisaCpf";
            this.rbPesquisaCpf.Size = new System.Drawing.Size(77, 17);
            this.rbPesquisaCpf.TabIndex = 1;
            this.rbPesquisaCpf.TabStop = true;
            this.rbPesquisaCpf.Text = "CPF/CNPJ";
            this.rbPesquisaCpf.UseVisualStyleBackColor = true;
            // 
            // rbPesquisaNome
            // 
            this.rbPesquisaNome.AutoSize = true;
            this.rbPesquisaNome.Location = new System.Drawing.Point(16, 19);
            this.rbPesquisaNome.Name = "rbPesquisaNome";
            this.rbPesquisaNome.Size = new System.Drawing.Size(53, 17);
            this.rbPesquisaNome.TabIndex = 0;
            this.rbPesquisaNome.TabStop = true;
            this.rbPesquisaNome.Text = "Nome";
            this.rbPesquisaNome.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle5;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 101);
            this.grid.Name = "grid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid.Size = new System.Drawing.Size(760, 403);
            this.grid.TabIndex = 1;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // rbSelo
            // 
            this.rbSelo.AutoSize = true;
            this.rbSelo.Location = new System.Drawing.Point(104, 53);
            this.rbSelo.Name = "rbSelo";
            this.rbSelo.Size = new System.Drawing.Size(61, 17);
            this.rbSelo.TabIndex = 3;
            this.rbSelo.TabStop = true;
            this.rbSelo.Text = "Nº Selo";
            this.rbSelo.UseVisualStyleBackColor = true;
            // 
            // rbData
            // 
            this.rbData.AutoSize = true;
            this.rbData.Location = new System.Drawing.Point(187, 19);
            this.rbData.Name = "rbData";
            this.rbData.Size = new System.Drawing.Size(89, 17);
            this.rbData.TabIndex = 4;
            this.rbData.TabStop = true;
            this.rbData.Text = "Em uma Data";
            this.rbData.UseVisualStyleBackColor = true;
            // 
            // rbEntreDatas
            // 
            this.rbEntreDatas.AutoSize = true;
            this.rbEntreDatas.Location = new System.Drawing.Point(187, 53);
            this.rbEntreDatas.Name = "rbEntreDatas";
            this.rbEntreDatas.Size = new System.Drawing.Size(81, 17);
            this.rbEntreDatas.TabIndex = 5;
            this.rbEntreDatas.TabStop = true;
            this.rbEntreDatas.Text = "Entre Datas";
            this.rbEntreDatas.UseVisualStyleBackColor = true;
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(303, 64);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(116, 20);
            this.dtInicio.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data Final";
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(448, 64);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(118, 20);
            this.dtFim.TabIndex = 9;
            // 
            // pesquisaProcessoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 504);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "pesquisaProcessoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Processo";
            this.Load += new System.EventHandler(this.pesquisaProcessoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPesquisaCpf;
        private System.Windows.Forms.RadioButton rbPesquisaNome;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.TextBox txPesquisa;
        private System.Windows.Forms.Label lbArgumentoPesquisa;
        private System.Windows.Forms.RadioButton rbNumProcesso;
        private System.Windows.Forms.Button btEditarProcesso;
        private System.Windows.Forms.Button brReabrirPedido;
        private System.Windows.Forms.RadioButton rbEntreDatas;
        private System.Windows.Forms.RadioButton rbData;
        private System.Windows.Forms.RadioButton rbSelo;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtInicio;
    }
}