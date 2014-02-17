namespace sgc.processos
{
    partial class andamentosForm
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
            this.txAndamento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txVlAndamento = new System.Windows.Forms.TextBox();
            this.dtAndamento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btGravar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.gridAndamento = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lbFicha = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAndamento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbFicha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txAndamento);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txVlAndamento);
            this.panel1.Controls.Add(this.dtAndamento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btGravar);
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 125);
            this.panel1.TabIndex = 0;
            // 
            // txAndamento
            // 
            this.txAndamento.Location = new System.Drawing.Point(15, 61);
            this.txAndamento.MaxLength = 150;
            this.txAndamento.Multiline = true;
            this.txAndamento.Name = "txAndamento";
            this.txAndamento.Size = new System.Drawing.Size(460, 58);
            this.txAndamento.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Descrição";
            // 
            // txVlAndamento
            // 
            this.txVlAndamento.Location = new System.Drawing.Point(142, 22);
            this.txVlAndamento.Name = "txVlAndamento";
            this.txVlAndamento.Size = new System.Drawing.Size(100, 20);
            this.txVlAndamento.TabIndex = 7;
            this.txVlAndamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txVlAndamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txVlAndamento_KeyPress);
            // 
            // dtAndamento
            // 
            this.dtAndamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAndamento.Location = new System.Drawing.Point(15, 22);
            this.dtAndamento.Name = "dtAndamento";
            this.dtAndamento.Size = new System.Drawing.Size(104, 20);
            this.dtAndamento.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data";
            // 
            // btGravar
            // 
            this.btGravar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btGravar.Image = global::sgc.Properties.Resources.add;
            this.btGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGravar.Location = new System.Drawing.Point(481, 67);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Adicionar";
            this.btGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGravar.UseVisualStyleBackColor = false;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelar.Image = global::sgc.Properties.Resources.cancel16;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(481, 96);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 0;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // gridAndamento
            // 
            this.gridAndamento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAndamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAndamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAndamento.Location = new System.Drawing.Point(0, 125);
            this.gridAndamento.Name = "gridAndamento";
            this.gridAndamento.Size = new System.Drawing.Size(568, 167);
            this.gridAndamento.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ficha Nº:";
            // 
            // lbFicha
            // 
            this.lbFicha.AutoSize = true;
            this.lbFicha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFicha.Location = new System.Drawing.Point(366, 16);
            this.lbFicha.Name = "lbFicha";
            this.lbFicha.Size = new System.Drawing.Size(26, 29);
            this.lbFicha.TabIndex = 11;
            this.lbFicha.Text = "0";
            // 
            // andamentosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 292);
            this.Controls.Add(this.gridAndamento);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "andamentosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Andamentos";
            this.Load += new System.EventHandler(this.andamentosForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAndamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridAndamento;
        private System.Windows.Forms.TextBox txAndamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txVlAndamento;
        private System.Windows.Forms.DateTimePicker dtAndamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lbFicha;
        private System.Windows.Forms.Label label3;
    }
}