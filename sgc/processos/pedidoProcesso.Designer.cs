namespace sgc.processos
{
    partial class pedidoProcesso
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSalvaItem = new System.Windows.Forms.Button();
            this.lbValorItem = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txValorUnt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txQtd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNulPedido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNumProcesso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbValorTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btGrava = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btDelataItem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.lbTipo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbNulPedido);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbNumProcesso);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 128);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDelataItem);
            this.groupBox1.Controls.Add(this.btSalvaItem);
            this.groupBox1.Controls.Add(this.lbValorItem);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txValorUnt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txQtd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbItem);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(205, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 108);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novo Item";
            // 
            // btSalvaItem
            // 
            this.btSalvaItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btSalvaItem.Image = global::sgc.Properties.Resources.add1_16;
            this.btSalvaItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalvaItem.Location = new System.Drawing.Point(271, 75);
            this.btSalvaItem.Name = "btSalvaItem";
            this.btSalvaItem.Size = new System.Drawing.Size(105, 25);
            this.btSalvaItem.TabIndex = 8;
            this.btSalvaItem.Text = "&Adicionar Item";
            this.btSalvaItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSalvaItem.UseVisualStyleBackColor = false;
            this.btSalvaItem.Click += new System.EventHandler(this.btSalvaItem_Click);
            // 
            // lbValorItem
            // 
            this.lbValorItem.AutoSize = true;
            this.lbValorItem.Location = new System.Drawing.Point(78, 87);
            this.lbValorItem.Name = "lbValorItem";
            this.lbValorItem.Size = new System.Drawing.Size(45, 13);
            this.lbValorItem.TabIndex = 7;
            this.lbValorItem.Text = "R$ 0,00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Valor Item:";
            // 
            // txValorUnt
            // 
            this.txValorUnt.Location = new System.Drawing.Point(84, 61);
            this.txValorUnt.Name = "txValorUnt";
            this.txValorUnt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txValorUnt.Size = new System.Drawing.Size(100, 20);
            this.txValorUnt.TabIndex = 5;
            this.txValorUnt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txValorUnt_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Valor Unitário";
            // 
            // txQtd
            // 
            this.txQtd.Location = new System.Drawing.Point(433, 32);
            this.txQtd.Name = "txQtd";
            this.txQtd.Size = new System.Drawing.Size(43, 20);
            this.txQtd.TabIndex = 3;
            this.txQtd.Text = "1";
            this.txQtd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txQtd_KeyDown);
            this.txQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txQtd_KeyPress);
            this.txQtd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txQtd_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Quant.";
            // 
            // cbItem
            // 
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(15, 32);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(400, 21);
            this.cbItem.TabIndex = 1;
            this.cbItem.SelectedIndexChanged += new System.EventHandler(this.cbItem_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Item";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(79, 84);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(13, 13);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "0";
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(79, 57);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(28, 13);
            this.lbTipo.TabIndex = 6;
            this.lbTipo.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo:";
            // 
            // lbNulPedido
            // 
            this.lbNulPedido.AutoSize = true;
            this.lbNulPedido.Location = new System.Drawing.Point(79, 32);
            this.lbNulPedido.Name = "lbNulPedido";
            this.lbNulPedido.Size = new System.Drawing.Size(13, 13);
            this.lbNulPedido.TabIndex = 3;
            this.lbNulPedido.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Pedido:";
            // 
            // lbNumProcesso
            // 
            this.lbNumProcesso.AutoSize = true;
            this.lbNumProcesso.Location = new System.Drawing.Point(79, 9);
            this.lbNumProcesso.Name = "lbNumProcesso";
            this.lbNumProcesso.Size = new System.Drawing.Size(13, 13);
            this.lbNumProcesso.TabIndex = 1;
            this.lbNumProcesso.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Processo:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.lbValorTotal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Controls.Add(this.btGrava);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 44);
            this.panel2.TabIndex = 1;
            // 
            // lbValorTotal
            // 
            this.lbValorTotal.AutoSize = true;
            this.lbValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTotal.Location = new System.Drawing.Point(98, 11);
            this.lbValorTotal.Name = "lbValorTotal";
            this.lbValorTotal.Size = new System.Drawing.Size(65, 20);
            this.lbValorTotal.TabIndex = 3;
            this.lbValorTotal.Text = "R$ 0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Valor Total:";
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelar.Image = global::sgc.Properties.Resources.cancel16;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(471, 10);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(110, 25);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btGrava
            // 
            this.btGrava.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btGrava.Image = global::sgc.Properties.Resources.bnvn;
            this.btGrava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGrava.Location = new System.Drawing.Point(585, 10);
            this.btGrava.Name = "btGrava";
            this.btGrava.Size = new System.Drawing.Size(110, 25);
            this.btGrava.TabIndex = 0;
            this.btGrava.Text = "&Fechar Pedido";
            this.btGrava.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGrava.UseVisualStyleBackColor = false;
            this.btGrava.Click += new System.EventHandler(this.btGrava_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 128);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(707, 263);
            this.grid.TabIndex = 3;
            // 
            // btDelataItem
            // 
            this.btDelataItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btDelataItem.Image = global::sgc.Properties.Resources.delete;
            this.btDelataItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelataItem.Location = new System.Drawing.Point(380, 76);
            this.btDelataItem.Name = "btDelataItem";
            this.btDelataItem.Size = new System.Drawing.Size(104, 23);
            this.btDelataItem.TabIndex = 9;
            this.btDelataItem.Text = "Apaga Item";
            this.btDelataItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelataItem.UseVisualStyleBackColor = false;
            this.btDelataItem.Click += new System.EventHandler(this.btDelataItem_Click);
            // 
            // pedidoProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 435);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "pedidoProcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido de Processo";
            this.Load += new System.EventHandler(this.pedidoProcesso_Load);
            this.Shown += new System.EventHandler(this.pedidoProcesso_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lbNulPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNumProcesso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbValorTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btGrava;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbValorItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txValorUnt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txQtd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.Button btSalvaItem;
        private System.Windows.Forms.Button btDelataItem;
    }
}