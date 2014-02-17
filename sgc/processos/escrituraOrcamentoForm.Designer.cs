namespace sgc.processos
{
    partial class escrituraOrcamentoForm
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
            this.btImprime = new System.Windows.Forms.Button();
            this.lbNumOrcamento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.pnDados = new System.Windows.Forms.Panel();
            this.btDelItem = new System.Windows.Forms.Button();
            this.txQtd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbTipoEscritura = new System.Windows.Forms.ComboBox();
            this.btAddItem = new System.Windows.Forms.Button();
            this.cbItemOrcamento = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gridItens = new System.Windows.Forms.DataGridView();
            this.txObs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txFoneContato = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txDataTrans = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txContato = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txValorVenal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txvalorTransacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnClientes = new System.Windows.Forms.Panel();
            this.btDelCliente = new System.Windows.Forms.Button();
            this.btAddCliente = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItens)).BeginInit();
            this.pnClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btImprime);
            this.panel1.Controls.Add(this.lbNumOrcamento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.btSalvar);
            this.panel1.Controls.Add(this.btNovo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 38);
            this.panel1.TabIndex = 0;
            // 
            // btImprime
            // 
            this.btImprime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btImprime.Image = global::sgc.Properties.Resources.printer1;
            this.btImprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImprime.Location = new System.Drawing.Point(246, 3);
            this.btImprime.Name = "btImprime";
            this.btImprime.Size = new System.Drawing.Size(155, 30);
            this.btImprime.TabIndex = 5;
            this.btImprime.Text = "Imprime Orçamento";
            this.btImprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImprime.UseVisualStyleBackColor = false;
            this.btImprime.Click += new System.EventHandler(this.btImprime_Click);
            // 
            // lbNumOrcamento
            // 
            this.lbNumOrcamento.AutoSize = true;
            this.lbNumOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumOrcamento.Location = new System.Drawing.Point(535, 9);
            this.lbNumOrcamento.Name = "lbNumOrcamento";
            this.lbNumOrcamento.Size = new System.Drawing.Size(20, 24);
            this.lbNumOrcamento.TabIndex = 4;
            this.lbNumOrcamento.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. Orçamento:";
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btBuscar.Image = global::sgc.Properties.Resources.search;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(165, 3);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(79, 30);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = false;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::sgc.Properties.Resources.Save16;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalvar.Location = new System.Drawing.Point(84, 3);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(79, 30);
            this.btSalvar.TabIndex = 1;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btNovo.Image = global::sgc.Properties.Resources.new_page;
            this.btNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNovo.Location = new System.Drawing.Point(3, 3);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(79, 30);
            this.btNovo.TabIndex = 0;
            this.btNovo.Text = "Novo";
            this.btNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNovo.UseVisualStyleBackColor = false;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.btDelItem);
            this.pnDados.Controls.Add(this.txQtd);
            this.pnDados.Controls.Add(this.label12);
            this.pnDados.Controls.Add(this.label11);
            this.pnDados.Controls.Add(this.cbTipoEscritura);
            this.pnDados.Controls.Add(this.btAddItem);
            this.pnDados.Controls.Add(this.cbItemOrcamento);
            this.pnDados.Controls.Add(this.label10);
            this.pnDados.Controls.Add(this.gridItens);
            this.pnDados.Controls.Add(this.txObs);
            this.pnDados.Controls.Add(this.label9);
            this.pnDados.Controls.Add(this.txEndereco);
            this.pnDados.Controls.Add(this.label8);
            this.pnDados.Controls.Add(this.txFoneContato);
            this.pnDados.Controls.Add(this.label7);
            this.pnDados.Controls.Add(this.txDataTrans);
            this.pnDados.Controls.Add(this.label6);
            this.pnDados.Controls.Add(this.txContato);
            this.pnDados.Controls.Add(this.label5);
            this.pnDados.Controls.Add(this.txValorVenal);
            this.pnDados.Controls.Add(this.label4);
            this.pnDados.Controls.Add(this.txvalorTransacao);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDados.Enabled = false;
            this.pnDados.Location = new System.Drawing.Point(0, 155);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(723, 351);
            this.pnDados.TabIndex = 1;
            // 
            // btDelItem
            // 
            this.btDelItem.Image = global::sgc.Properties.Resources.delete;
            this.btDelItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelItem.Location = new System.Drawing.Point(633, 105);
            this.btDelItem.Name = "btDelItem";
            this.btDelItem.Size = new System.Drawing.Size(75, 23);
            this.btDelItem.TabIndex = 22;
            this.btDelItem.Text = "Del Item";
            this.btDelItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelItem.UseVisualStyleBackColor = true;
            this.btDelItem.Click += new System.EventHandler(this.btDelItem_Click);
            // 
            // txQtd
            // 
            this.txQtd.Location = new System.Drawing.Point(501, 109);
            this.txQtd.Name = "txQtd";
            this.txQtd.Size = new System.Drawing.Size(38, 20);
            this.txQtd.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(498, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Qtd.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(405, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Tipo de Escritura";
            // 
            // cbTipoEscritura
            // 
            this.cbTipoEscritura.FormattingEnabled = true;
            this.cbTipoEscritura.Location = new System.Drawing.Point(408, 68);
            this.cbTipoEscritura.Name = "cbTipoEscritura";
            this.cbTipoEscritura.Size = new System.Drawing.Size(303, 21);
            this.cbTipoEscritura.TabIndex = 6;
            // 
            // btAddItem
            // 
            this.btAddItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAddItem.Image = global::sgc.Properties.Resources.add;
            this.btAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddItem.Location = new System.Drawing.Point(545, 106);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(82, 23);
            this.btAddItem.TabIndex = 17;
            this.btAddItem.Text = "Adic. Item";
            this.btAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddItem.UseVisualStyleBackColor = false;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // cbItemOrcamento
            // 
            this.cbItemOrcamento.FormattingEnabled = true;
            this.cbItemOrcamento.Location = new System.Drawing.Point(248, 109);
            this.cbItemOrcamento.Name = "cbItemOrcamento";
            this.cbItemOrcamento.Size = new System.Drawing.Size(247, 21);
            this.cbItemOrcamento.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Item Orçamento";
            // 
            // gridItens
            // 
            this.gridItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItens.Location = new System.Drawing.Point(248, 139);
            this.gridItens.Name = "gridItens";
            this.gridItens.Size = new System.Drawing.Size(463, 200);
            this.gridItens.TabIndex = 14;
            // 
            // txObs
            // 
            this.txObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txObs.Location = new System.Drawing.Point(15, 107);
            this.txObs.Multiline = true;
            this.txObs.Name = "txObs";
            this.txObs.Size = new System.Drawing.Size(220, 232);
            this.txObs.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Obs.:";
            // 
            // txEndereco
            // 
            this.txEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txEndereco.Location = new System.Drawing.Point(15, 68);
            this.txEndereco.Name = "txEndereco";
            this.txEndereco.Size = new System.Drawing.Size(386, 20);
            this.txEndereco.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Imóvel";
            // 
            // txFoneContato
            // 
            this.txFoneContato.Location = new System.Drawing.Point(539, 27);
            this.txFoneContato.Name = "txFoneContato";
            this.txFoneContato.Size = new System.Drawing.Size(172, 20);
            this.txFoneContato.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(536, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fone";
            // 
            // txDataTrans
            // 
            this.txDataTrans.Location = new System.Drawing.Point(248, 29);
            this.txDataTrans.Mask = "00/00/0000";
            this.txDataTrans.Name = "txDataTrans";
            this.txDataTrans.Size = new System.Drawing.Size(100, 20);
            this.txDataTrans.TabIndex = 2;
            this.txDataTrans.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Data Transação";
            // 
            // txContato
            // 
            this.txContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txContato.Location = new System.Drawing.Point(360, 29);
            this.txContato.Name = "txContato";
            this.txContato.Size = new System.Drawing.Size(169, 20);
            this.txContato.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contato";
            // 
            // txValorVenal
            // 
            this.txValorVenal.Location = new System.Drawing.Point(128, 29);
            this.txValorVenal.Name = "txValorVenal";
            this.txValorVenal.Size = new System.Drawing.Size(107, 20);
            this.txValorVenal.TabIndex = 1;
            this.txValorVenal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txValorVenal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txValorVenal_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Valor Venal";
            // 
            // txvalorTransacao
            // 
            this.txvalorTransacao.Location = new System.Drawing.Point(12, 29);
            this.txvalorTransacao.Name = "txvalorTransacao";
            this.txvalorTransacao.Size = new System.Drawing.Size(110, 20);
            this.txvalorTransacao.TabIndex = 0;
            this.txvalorTransacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txvalorTransacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txvalorTransacao_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Valor Transação";
            // 
            // pnClientes
            // 
            this.pnClientes.Controls.Add(this.btDelCliente);
            this.pnClientes.Controls.Add(this.btAddCliente);
            this.pnClientes.Controls.Add(this.grid);
            this.pnClientes.Controls.Add(this.label1);
            this.pnClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnClientes.Enabled = false;
            this.pnClientes.Location = new System.Drawing.Point(0, 38);
            this.pnClientes.Name = "pnClientes";
            this.pnClientes.Size = new System.Drawing.Size(723, 117);
            this.pnClientes.TabIndex = 2;
            // 
            // btDelCliente
            // 
            this.btDelCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btDelCliente.Image = global::sgc.Properties.Resources.delete;
            this.btDelCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelCliente.Location = new System.Drawing.Point(12, 83);
            this.btDelCliente.Name = "btDelCliente";
            this.btDelCliente.Size = new System.Drawing.Size(124, 22);
            this.btDelCliente.TabIndex = 3;
            this.btDelCliente.Text = "Remover";
            this.btDelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelCliente.UseVisualStyleBackColor = false;
            this.btDelCliente.Click += new System.EventHandler(this.btDelCliente_Click);
            // 
            // btAddCliente
            // 
            this.btAddCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAddCliente.Image = global::sgc.Properties.Resources.add;
            this.btAddCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddCliente.Location = new System.Drawing.Point(12, 54);
            this.btAddCliente.Name = "btAddCliente";
            this.btAddCliente.Size = new System.Drawing.Size(124, 23);
            this.btAddCliente.TabIndex = 2;
            this.btAddCliente.Text = "Adicionar";
            this.btAddCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddCliente.UseVisualStyleBackColor = false;
            this.btAddCliente.Click += new System.EventHandler(this.btAddCliente_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(142, 6);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(569, 105);
            this.grid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clientes:";
            // 
            // escrituraOrcamentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 506);
            this.Controls.Add(this.pnClientes);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.panel1);
            this.Name = "escrituraOrcamentoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escritura Orcamento";
            this.Load += new System.EventHandler(this.escrituraOrcamentoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItens)).EndInit();
            this.pnClientes.ResumeLayout(false);
            this.pnClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.Panel pnClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btDelCliente;
        private System.Windows.Forms.Button btAddCliente;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView grid;
        public System.Windows.Forms.Label lbNumOrcamento;
        private System.Windows.Forms.TextBox txFoneContato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txDataTrans;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txContato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txValorVenal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txvalorTransacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txEndereco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txObs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbItemOrcamento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView gridItens;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.Button btImprime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTipoEscritura;
        private System.Windows.Forms.TextBox txQtd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btDelItem;
    }
}