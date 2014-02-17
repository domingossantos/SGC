namespace sgc.cnj
{
    partial class ExtrairTextoProvimento18Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCESDI = new System.Windows.Forms.RadioButton();
            this.rbCRTO = new System.Windows.Forms.RadioButton();
            this.rbCEP = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btGerar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCESDI);
            this.groupBox1.Controls.Add(this.rbCRTO);
            this.groupBox1.Controls.Add(this.rbCEP);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 75);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Provimento";
            // 
            // rbCESDI
            // 
            this.rbCESDI.AutoSize = true;
            this.rbCESDI.Location = new System.Drawing.Point(176, 16);
            this.rbCESDI.Name = "rbCESDI";
            this.rbCESDI.Size = new System.Drawing.Size(157, 17);
            this.rbCESDI.TabIndex = 3;
            this.rbCESDI.TabStop = true;
            this.rbCESDI.Text = "CESDI (Divorcio/Inventário)";
            this.rbCESDI.UseVisualStyleBackColor = true;
            // 
            // rbCRTO
            // 
            this.rbCRTO.AutoSize = true;
            this.rbCRTO.Location = new System.Drawing.Point(6, 16);
            this.rbCRTO.Name = "rbCRTO";
            this.rbCRTO.Size = new System.Drawing.Size(120, 17);
            this.rbCRTO.TabIndex = 2;
            this.rbCRTO.TabStop = true;
            this.rbCRTO.Text = "CRTO (Testamento)";
            this.rbCRTO.UseVisualStyleBackColor = true;
            // 
            // rbCEP
            // 
            this.rbCEP.AutoSize = true;
            this.rbCEP.Location = new System.Drawing.Point(6, 42);
            this.rbCEP.Name = "rbCEP";
            this.rbCEP.Size = new System.Drawing.Size(156, 17);
            this.rbCEP.TabIndex = 1;
            this.rbCEP.TabStop = true;
            this.rbCEP.Text = "CEP (Escritura/Procuração)";
            this.rbCEP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ano";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mês";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "JAN",
            "FEV",
            "MAR",
            "ABR",
            "MAI",
            "JUN",
            "JUL",
            "AGO",
            "SET",
            "OUT",
            "NOV",
            "DEZ"});
            this.comboBox1.Location = new System.Drawing.Point(101, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Quinzena";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1ª QUINZENA",
            "2ª QUINZENA"});
            this.comboBox2.Location = new System.Drawing.Point(221, 117);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 14;
            // 
            // btGerar
            // 
            this.btGerar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btGerar.Image = global::sgc.Properties.Resources.process;
            this.btGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGerar.Location = new System.Drawing.Point(221, 157);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(121, 28);
            this.btGerar.TabIndex = 15;
            this.btGerar.Text = "Gerar Arquivo";
            this.btGerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerar.UseVisualStyleBackColor = false;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // ExtrairTextoProvimento18Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 197);
            this.Controls.Add(this.btGerar);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExtrairTextoProvimento18Form";
            this.Text = "Extrair Texto Provimento18 ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCESDI;
        private System.Windows.Forms.RadioButton rbCRTO;
        private System.Windows.Forms.RadioButton rbCEP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}