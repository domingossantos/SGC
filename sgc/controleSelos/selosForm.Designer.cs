namespace sgc.controleSelos
{
    partial class selosForm
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
            this.brApagarSelo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btAtribuir = new System.Windows.Forms.Button();
            this.btTransferir = new System.Windows.Forms.Button();
            this.txSeqFinal = new System.Windows.Forms.TextBox();
            this.txSeqInicio = new System.Windows.Forms.TextBox();
            this.btIncluir = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.cbTipoSelo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelAtribuir = new System.Windows.Forms.Panel();
            this.btGravarAtribuicao = new System.Windows.Forms.Button();
            this.btCancelarAtribuicao = new System.Windows.Forms.Button();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTranferencia = new System.Windows.Forms.Panel();
            this.btGravarTransf = new System.Windows.Forms.Button();
            this.btCancelarTransf = new System.Windows.Forms.Button();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelAtribuir.SuspendLayout();
            this.panelTranferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.brApagarSelo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btAtribuir);
            this.panel1.Controls.Add(this.btTransferir);
            this.panel1.Controls.Add(this.txSeqFinal);
            this.panel1.Controls.Add(this.txSeqInicio);
            this.panel1.Controls.Add(this.btIncluir);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.cbTipoSelo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 100);
            this.panel1.TabIndex = 0;
            // 
            // brApagarSelo
            // 
            this.brApagarSelo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.brApagarSelo.Image = global::sgc.Properties.Resources.delete;
            this.brApagarSelo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brApagarSelo.Location = new System.Drawing.Point(509, 55);
            this.brApagarSelo.Name = "brApagarSelo";
            this.brApagarSelo.Size = new System.Drawing.Size(90, 33);
            this.brApagarSelo.TabIndex = 9;
            this.brApagarSelo.Text = "Apagar Selo";
            this.brApagarSelo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brApagarSelo.UseVisualStyleBackColor = false;
            this.brApagarSelo.Click += new System.EventHandler(this.brApagarSelo_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Image = global::sgc.Properties.Resources.window;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(413, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Limpar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAtribuir
            // 
            this.btAtribuir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAtribuir.Image = global::sgc.Properties.Resources.folder_add;
            this.btAtribuir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtribuir.Location = new System.Drawing.Point(307, 55);
            this.btAtribuir.Name = "btAtribuir";
            this.btAtribuir.Size = new System.Drawing.Size(100, 33);
            this.btAtribuir.TabIndex = 7;
            this.btAtribuir.Text = "Atribuir Usuário";
            this.btAtribuir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAtribuir.UseVisualStyleBackColor = false;
            this.btAtribuir.Click += new System.EventHandler(this.button3_Click);
            // 
            // btTransferir
            // 
            this.btTransferir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btTransferir.Enabled = false;
            this.btTransferir.Image = global::sgc.Properties.Resources.back;
            this.btTransferir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTransferir.Location = new System.Drawing.Point(203, 55);
            this.btTransferir.Name = "btTransferir";
            this.btTransferir.Size = new System.Drawing.Size(100, 33);
            this.btTransferir.TabIndex = 6;
            this.btTransferir.Text = "Transferir Selos";
            this.btTransferir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTransferir.UseVisualStyleBackColor = false;
            this.btTransferir.Click += new System.EventHandler(this.btTransferir_Click);
            // 
            // txSeqFinal
            // 
            this.txSeqFinal.Location = new System.Drawing.Point(131, 28);
            this.txSeqFinal.MaxLength = 8;
            this.txSeqFinal.Name = "txSeqFinal";
            this.txSeqFinal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txSeqFinal.Size = new System.Drawing.Size(100, 20);
            this.txSeqFinal.TabIndex = 2;
            this.txSeqFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txSeqInicio
            // 
            this.txSeqInicio.Location = new System.Drawing.Point(15, 29);
            this.txSeqInicio.MaxLength = 8;
            this.txSeqInicio.Name = "txSeqInicio";
            this.txSeqInicio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txSeqInicio.Size = new System.Drawing.Size(110, 20);
            this.txSeqInicio.TabIndex = 1;
            this.txSeqInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txSeqInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txSeqInicio_KeyPress);
            // 
            // btIncluir
            // 
            this.btIncluir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btIncluir.Image = global::sgc.Properties.Resources.add;
            this.btIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIncluir.Location = new System.Drawing.Point(104, 54);
            this.btIncluir.Name = "btIncluir";
            this.btIncluir.Size = new System.Drawing.Size(95, 34);
            this.btIncluir.TabIndex = 5;
            this.btIncluir.Text = "Registrar";
            this.btIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btIncluir.UseVisualStyleBackColor = false;
            this.btIncluir.Click += new System.EventHandler(this.btIncluir_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisar.Image = global::sgc.Properties.Resources.addressbook_search;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisar.Location = new System.Drawing.Point(12, 54);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(90, 34);
            this.btPesquisar.TabIndex = 4;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // cbTipoSelo
            // 
            this.cbTipoSelo.FormattingEnabled = true;
            this.cbTipoSelo.Location = new System.Drawing.Point(237, 27);
            this.cbTipoSelo.Name = "cbTipoSelo";
            this.cbTipoSelo.Size = new System.Drawing.Size(342, 21);
            this.cbTipoSelo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo Selo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seq. Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seq. Inicial";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 100);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(677, 368);
            this.grid.TabIndex = 1;
            // 
            // panelAtribuir
            // 
            this.panelAtribuir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelAtribuir.BackColor = System.Drawing.Color.Gainsboro;
            this.panelAtribuir.Controls.Add(this.btGravarAtribuicao);
            this.panelAtribuir.Controls.Add(this.btCancelarAtribuicao);
            this.panelAtribuir.Controls.Add(this.cbUsuario);
            this.panelAtribuir.Controls.Add(this.label5);
            this.panelAtribuir.Controls.Add(this.label4);
            this.panelAtribuir.Location = new System.Drawing.Point(157, 106);
            this.panelAtribuir.Name = "panelAtribuir";
            this.panelAtribuir.Size = new System.Drawing.Size(388, 116);
            this.panelAtribuir.TabIndex = 2;
            this.panelAtribuir.Visible = false;
            // 
            // btGravarAtribuicao
            // 
            this.btGravarAtribuicao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btGravarAtribuicao.Image = global::sgc.Properties.Resources.accept;
            this.btGravarAtribuicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGravarAtribuicao.Location = new System.Drawing.Point(170, 78);
            this.btGravarAtribuicao.Name = "btGravarAtribuicao";
            this.btGravarAtribuicao.Size = new System.Drawing.Size(102, 23);
            this.btGravarAtribuicao.TabIndex = 4;
            this.btGravarAtribuicao.Text = "Gravar";
            this.btGravarAtribuicao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGravarAtribuicao.UseVisualStyleBackColor = false;
            this.btGravarAtribuicao.Click += new System.EventHandler(this.btGravarAtribuicao_Click);
            // 
            // btCancelarAtribuicao
            // 
            this.btCancelarAtribuicao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelarAtribuicao.Image = global::sgc.Properties.Resources.delete;
            this.btCancelarAtribuicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelarAtribuicao.Location = new System.Drawing.Point(278, 78);
            this.btCancelarAtribuicao.Name = "btCancelarAtribuicao";
            this.btCancelarAtribuicao.Size = new System.Drawing.Size(93, 23);
            this.btCancelarAtribuicao.TabIndex = 3;
            this.btCancelarAtribuicao.Text = "Cancelar";
            this.btCancelarAtribuicao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelarAtribuicao.UseVisualStyleBackColor = false;
            this.btCancelarAtribuicao.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(12, 51);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(359, 21);
            this.cbUsuario.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Usuário:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(354, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Selecione um usuário para atribuir os selos";
            // 
            // panelTranferencia
            // 
            this.panelTranferencia.BackColor = System.Drawing.Color.Gainsboro;
            this.panelTranferencia.Controls.Add(this.btGravarTransf);
            this.panelTranferencia.Controls.Add(this.btCancelarTransf);
            this.panelTranferencia.Controls.Add(this.cbDestino);
            this.panelTranferencia.Controls.Add(this.label7);
            this.panelTranferencia.Controls.Add(this.label6);
            this.panelTranferencia.Location = new System.Drawing.Point(158, 228);
            this.panelTranferencia.Name = "panelTranferencia";
            this.panelTranferencia.Size = new System.Drawing.Size(387, 112);
            this.panelTranferencia.TabIndex = 3;
            this.panelTranferencia.Visible = false;
            // 
            // btGravarTransf
            // 
            this.btGravarTransf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btGravarTransf.Image = global::sgc.Properties.Resources.accept;
            this.btGravarTransf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGravarTransf.Location = new System.Drawing.Point(169, 79);
            this.btGravarTransf.Name = "btGravarTransf";
            this.btGravarTransf.Size = new System.Drawing.Size(102, 23);
            this.btGravarTransf.TabIndex = 6;
            this.btGravarTransf.Text = "Gravar";
            this.btGravarTransf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGravarTransf.UseVisualStyleBackColor = false;
            this.btGravarTransf.Click += new System.EventHandler(this.btGravarTransf_Click);
            // 
            // btCancelarTransf
            // 
            this.btCancelarTransf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelarTransf.Image = global::sgc.Properties.Resources.delete;
            this.btCancelarTransf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelarTransf.Location = new System.Drawing.Point(277, 79);
            this.btCancelarTransf.Name = "btCancelarTransf";
            this.btCancelarTransf.Size = new System.Drawing.Size(93, 23);
            this.btCancelarTransf.TabIndex = 5;
            this.btCancelarTransf.Text = "Cancelar";
            this.btCancelarTransf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelarTransf.UseVisualStyleBackColor = false;
            this.btCancelarTransf.Click += new System.EventHandler(this.btCancelarTransf_Click);
            // 
            // cbDestino
            // 
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(11, 52);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(359, 21);
            this.cbDestino.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Local Destino:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(63, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Selecione o destino dos selos";
            // 
            // selosForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 468);
            this.Controls.Add(this.panelTranferencia);
            this.Controls.Add(this.panelAtribuir);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "selosForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selos";
            this.Load += new System.EventHandler(this.selosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelAtribuir.ResumeLayout(false);
            this.panelAtribuir.PerformLayout();
            this.panelTranferencia.ResumeLayout(false);
            this.panelTranferencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTipoSelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btIncluir;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txSeqInicio;
        private System.Windows.Forms.TextBox txSeqFinal;
        private System.Windows.Forms.Button btTransferir;
        private System.Windows.Forms.Panel panelAtribuir;
        private System.Windows.Forms.Button btGravarAtribuicao;
        private System.Windows.Forms.Button btCancelarAtribuicao;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAtribuir;
        private System.Windows.Forms.Panel panelTranferencia;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btGravarTransf;
        private System.Windows.Forms.Button btCancelarTransf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button brApagarSelo;
    }
}