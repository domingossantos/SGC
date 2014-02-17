namespace sgc.processos
{
    partial class pedidosAbertosForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btPesquisa = new System.Windows.Forms.Button();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.rbEntreDatas = new System.Windows.Forms.RadioButton();
            this.rbTresDias = new System.Windows.Forms.RadioButton();
            this.rbHoje = new System.Windows.Forms.RadioButton();
            this.grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fecharPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.rbTodos);
            this.panel1.Controls.Add(this.btPesquisa);
            this.panel1.Controls.Add(this.dtFim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtInicio);
            this.panel1.Controls.Add(this.rbEntreDatas);
            this.panel1.Controls.Add(this.rbTresDias);
            this.panel1.Controls.Add(this.rbHoje);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 52);
            this.panel1.TabIndex = 0;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(134, 26);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 8;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // btPesquisa
            // 
            this.btPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisa.ForeColor = System.Drawing.Color.Black;
            this.btPesquisa.Image = global::sgc.Properties.Resources.demo;
            this.btPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisa.Location = new System.Drawing.Point(563, 12);
            this.btPesquisa.Name = "btPesquisa";
            this.btPesquisa.Size = new System.Drawing.Size(127, 34);
            this.btPesquisa.TabIndex = 7;
            this.btPesquisa.Text = "Pesquiar";
            this.btPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisa.UseVisualStyleBackColor = false;
            this.btPesquisa.Click += new System.EventHandler(this.btPesquisa_Click);
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(430, 26);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(98, 20);
            this.dtFim.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Início";
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(304, 26);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(97, 20);
            this.dtInicio.TabIndex = 3;
            // 
            // rbEntreDatas
            // 
            this.rbEntreDatas.AutoSize = true;
            this.rbEntreDatas.Location = new System.Drawing.Point(134, 6);
            this.rbEntreDatas.Name = "rbEntreDatas";
            this.rbEntreDatas.Size = new System.Drawing.Size(81, 17);
            this.rbEntreDatas.TabIndex = 2;
            this.rbEntreDatas.Text = "Entre Datas";
            this.rbEntreDatas.UseVisualStyleBackColor = true;
            // 
            // rbTresDias
            // 
            this.rbTresDias.AutoSize = true;
            this.rbTresDias.Location = new System.Drawing.Point(12, 26);
            this.rbTresDias.Name = "rbTresDias";
            this.rbTresDias.Size = new System.Drawing.Size(101, 17);
            this.rbTresDias.TabIndex = 1;
            this.rbTresDias.Text = "Últimos três dias";
            this.rbTresDias.UseVisualStyleBackColor = true;
            // 
            // rbHoje
            // 
            this.rbHoje.AutoSize = true;
            this.rbHoje.Checked = true;
            this.rbHoje.Location = new System.Drawing.Point(12, 6);
            this.rbHoje.Name = "rbHoje";
            this.rbHoje.Size = new System.Drawing.Size(47, 17);
            this.rbHoje.TabIndex = 0;
            this.rbHoje.TabStop = true;
            this.rbHoje.Text = "Hoje";
            this.rbHoje.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.ContextMenuStrip = this.contextMenuStrip1;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 52);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(710, 412);
            this.grid.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharPedidoToolStripMenuItem,
            this.cancelarPedidoToolStripMenuItem,
            this.apagarPedidoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 92);
            // 
            // fecharPedidoToolStripMenuItem
            // 
            this.fecharPedidoToolStripMenuItem.Name = "fecharPedidoToolStripMenuItem";
            this.fecharPedidoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fecharPedidoToolStripMenuItem.Text = "Fechar Pedido";
            this.fecharPedidoToolStripMenuItem.Click += new System.EventHandler(this.fecharPedidoToolStripMenuItem_Click);
            // 
            // cancelarPedidoToolStripMenuItem
            // 
            this.cancelarPedidoToolStripMenuItem.Name = "cancelarPedidoToolStripMenuItem";
            this.cancelarPedidoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelarPedidoToolStripMenuItem.Text = "Cancelar Pedido";
            this.cancelarPedidoToolStripMenuItem.Click += new System.EventHandler(this.cancelarPedidoToolStripMenuItem_Click);
            // 
            // apagarPedidoToolStripMenuItem
            // 
            this.apagarPedidoToolStripMenuItem.Name = "apagarPedidoToolStripMenuItem";
            this.apagarPedidoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.apagarPedidoToolStripMenuItem.Text = "Apagar Pedido";
            this.apagarPedidoToolStripMenuItem.Click += new System.EventHandler(this.apagarPedidoToolStripMenuItem_Click);
            // 
            // pedidosAbertosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 464);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "pedidosAbertosForm";
            this.Text = "Pedidos Abertos";
            this.Load += new System.EventHandler(this.pedidosAbertosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fecharPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarPedidoToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbHoje;
        private System.Windows.Forms.RadioButton rbEntreDatas;
        private System.Windows.Forms.RadioButton rbTresDias;
        private System.Windows.Forms.Button btPesquisa;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.ToolStripMenuItem apagarPedidoToolStripMenuItem;
    }
}