namespace sgc.controleSelos
{
    partial class selosUsuarioForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.txNrSelo = new System.Windows.Forms.TextBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbDisponivel = new System.Windows.Forms.RadioButton();
            this.rbUsado = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dpFim = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.ckData = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.ckData);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txNrSelo);
            this.panel1.Controls.Add(this.rbTodos);
            this.panel1.Controls.Add(this.rbDisponivel);
            this.panel1.Controls.Add(this.rbUsado);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dpFim);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dpInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 98);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "No. Selo";
            // 
            // txNrSelo
            // 
            this.txNrSelo.Location = new System.Drawing.Point(265, 28);
            this.txNrSelo.Name = "txNrSelo";
            this.txNrSelo.Size = new System.Drawing.Size(118, 20);
            this.txNrSelo.TabIndex = 12;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(419, 72);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 11;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbDisponivel
            // 
            this.rbDisponivel.AutoSize = true;
            this.rbDisponivel.Location = new System.Drawing.Point(327, 72);
            this.rbDisponivel.Name = "rbDisponivel";
            this.rbDisponivel.Size = new System.Drawing.Size(76, 17);
            this.rbDisponivel.TabIndex = 10;
            this.rbDisponivel.Text = "Disponível";
            this.rbDisponivel.UseVisualStyleBackColor = true;
            // 
            // rbUsado
            // 
            this.rbUsado.AutoSize = true;
            this.rbUsado.Location = new System.Drawing.Point(265, 72);
            this.rbUsado.Name = "rbUsado";
            this.rbUsado.Size = new System.Drawing.Size(56, 17);
            this.rbUsado.TabIndex = 9;
            this.rbUsado.Text = "Usado";
            this.rbUsado.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status";
            // 
            // dpFim
            // 
            this.dpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFim.Location = new System.Drawing.Point(148, 71);
            this.dpFim.Name = "dpFim";
            this.dpFim.Size = new System.Drawing.Size(86, 20);
            this.dpFim.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "De:";
            // 
            // dpInicio
            // 
            this.dpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpInicio.Location = new System.Drawing.Point(42, 71);
            this.dpInicio.Name = "dpInicio";
            this.dpInicio.Size = new System.Drawing.Size(88, 20);
            this.dpInicio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Período";
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btPesquisar.Image = global::sgc.Properties.Resources.addressbook_search;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisar.Location = new System.Drawing.Point(601, 54);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(113, 37);
            this.btPesquisar.TabIndex = 2;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(12, 26);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(193, 21);
            this.cbUsuario.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 98);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(726, 376);
            this.grid.TabIndex = 1;
            // 
            // ckData
            // 
            this.ckData.AutoSize = true;
            this.ckData.Location = new System.Drawing.Point(601, 30);
            this.ckData.Name = "ckData";
            this.ckData.Size = new System.Drawing.Size(107, 17);
            this.ckData.TabIndex = 14;
            this.ckData.Text = "Considerar Datas";
            this.ckData.UseVisualStyleBackColor = true;
            // 
            // selosUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 474);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "selosUsuarioForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selos Usuário";
            this.Load += new System.EventHandler(this.selosUsuarioForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DateTimePicker dpFim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbUsado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbDisponivel;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txNrSelo;
        private System.Windows.Forms.CheckBox ckData;
    }
}