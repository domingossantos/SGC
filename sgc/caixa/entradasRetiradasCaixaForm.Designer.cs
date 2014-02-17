namespace sgc.caixa
{
    partial class entradasRetiradasCaixaForm
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
            this.txValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOutros = new System.Windows.Forms.RadioButton();
            this.rbSangria = new System.Windows.Forms.RadioButton();
            this.rbCorrentista = new System.Windows.Forms.RadioButton();
            this.cbOpcao = new System.Windows.Forms.ComboBox();
            this.lbOpcao = new System.Windows.Forms.Label();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txObservacao = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txValor
            // 
            this.txValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txValor.Location = new System.Drawing.Point(12, 134);
            this.txValor.Name = "txValor";
            this.txValor.Size = new System.Drawing.Size(166, 32);
            this.txValor.TabIndex = 2;
            this.txValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txValor_KeyDown);
            this.txValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txValor_KeyPress);
            this.txValor.Leave += new System.EventHandler(this.txValor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOutros);
            this.groupBox1.Controls.Add(this.rbSangria);
            this.groupBox1.Controls.Add(this.rbCorrentista);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Registro";
            // 
            // rbOutros
            // 
            this.rbOutros.AutoSize = true;
            this.rbOutros.Location = new System.Drawing.Point(274, 25);
            this.rbOutros.Name = "rbOutros";
            this.rbOutros.Size = new System.Drawing.Size(118, 17);
            this.rbOutros.TabIndex = 2;
            this.rbOutros.TabStop = true;
            this.rbOutros.Text = "Outros Pagamentos";
            this.rbOutros.UseVisualStyleBackColor = true;
            this.rbOutros.Click += new System.EventHandler(this.rbOutros_Click);
            // 
            // rbSangria
            // 
            this.rbSangria.AutoSize = true;
            this.rbSangria.Location = new System.Drawing.Point(191, 25);
            this.rbSangria.Name = "rbSangria";
            this.rbSangria.Size = new System.Drawing.Size(61, 17);
            this.rbSangria.TabIndex = 1;
            this.rbSangria.TabStop = true;
            this.rbSangria.Text = "Sangria";
            this.rbSangria.UseVisualStyleBackColor = true;
            this.rbSangria.Click += new System.EventHandler(this.rbSangria_Click);
            // 
            // rbCorrentista
            // 
            this.rbCorrentista.AutoSize = true;
            this.rbCorrentista.Location = new System.Drawing.Point(12, 25);
            this.rbCorrentista.Name = "rbCorrentista";
            this.rbCorrentista.Size = new System.Drawing.Size(161, 17);
            this.rbCorrentista.TabIndex = 0;
            this.rbCorrentista.TabStop = true;
            this.rbCorrentista.Text = "Recebimentos de Correntista";
            this.rbCorrentista.UseVisualStyleBackColor = true;
            this.rbCorrentista.Click += new System.EventHandler(this.rbCorrentista_Click);
            // 
            // cbOpcao
            // 
            this.cbOpcao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOpcao.FormattingEnabled = true;
            this.cbOpcao.Location = new System.Drawing.Point(12, 94);
            this.cbOpcao.Name = "cbOpcao";
            this.cbOpcao.Size = new System.Drawing.Size(450, 21);
            this.cbOpcao.TabIndex = 1;
            // 
            // lbOpcao
            // 
            this.lbOpcao.AutoSize = true;
            this.lbOpcao.Location = new System.Drawing.Point(12, 78);
            this.lbOpcao.Name = "lbOpcao";
            this.lbOpcao.Size = new System.Drawing.Size(39, 13);
            this.lbOpcao.TabIndex = 4;
            this.lbOpcao.Text = "Opção";
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btConfirmar.Image = global::sgc.Properties.Resources.accept;
            this.btConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConfirmar.Location = new System.Drawing.Point(360, 250);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(114, 40);
            this.btConfirmar.TabIndex = 4;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelar.Image = global::sgc.Properties.Resources.delete;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(245, 250);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(109, 40);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Observação";
            // 
            // txObservacao
            // 
            this.txObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txObservacao.Location = new System.Drawing.Point(15, 195);
            this.txObservacao.Name = "txObservacao";
            this.txObservacao.Size = new System.Drawing.Size(447, 26);
            this.txObservacao.TabIndex = 3;
            // 
            // entradasRetiradasCaixaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 302);
            this.Controls.Add(this.txObservacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.lbOpcao);
            this.Controls.Add(this.cbOpcao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "entradasRetiradasCaixaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas Retiradas Caixa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOutros;
        private System.Windows.Forms.RadioButton rbSangria;
        private System.Windows.Forms.RadioButton rbCorrentista;
        private System.Windows.Forms.ComboBox cbOpcao;
        private System.Windows.Forms.Label lbOpcao;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txObservacao;
    }
}