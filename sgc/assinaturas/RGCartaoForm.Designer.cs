namespace sgc.assinaturas
{
    partial class RGCartaoForm
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
            this.btnImpressao = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRG1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbxRG1 = new System.Windows.Forms.PictureBox();
            this.pbxRG2 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRG2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImpressao);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnRG1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnImpressao
            // 
            this.btnImpressao.Image = global::sgc.Properties.Resources.page_preview;
            this.btnImpressao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImpressao.Location = new System.Drawing.Point(321, 5);
            this.btnImpressao.Name = "btnImpressao";
            this.btnImpressao.Size = new System.Drawing.Size(106, 27);
            this.btnImpressao.TabIndex = 29;
            this.btnImpressao.Text = "Imprimir RG";
            this.btnImpressao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImpressao.UseVisualStyleBackColor = true;
            this.btnImpressao.Click += new System.EventHandler(this.btnImpressao_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::sgc.Properties.Resources.close16;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(618, 5);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 27);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // button2
            // 
            this.button2.Image = global::sgc.Properties.Resources.report;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(172, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Digitalizar Verso RG";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRG1
            // 
            this.btnRG1.Image = global::sgc.Properties.Resources.report;
            this.btnRG1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRG1.Location = new System.Drawing.Point(12, 5);
            this.btnRG1.Name = "btnRG1";
            this.btnRG1.Size = new System.Drawing.Size(136, 27);
            this.btnRG1.TabIndex = 0;
            this.btnRG1.Text = "Digitalizar Frente RG ";
            this.btnRG1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRG1.UseVisualStyleBackColor = true;
            this.btnRG1.Click += new System.EventHandler(this.btnRG1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbxRG1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbxRG2);
            this.splitContainer1.Size = new System.Drawing.Size(696, 348);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 1;
            // 
            // pbxRG1
            // 
            this.pbxRG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxRG1.Location = new System.Drawing.Point(0, 0);
            this.pbxRG1.Name = "pbxRG1";
            this.pbxRG1.Size = new System.Drawing.Size(352, 348);
            this.pbxRG1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRG1.TabIndex = 0;
            this.pbxRG1.TabStop = false;
            // 
            // pbxRG2
            // 
            this.pbxRG2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxRG2.Location = new System.Drawing.Point(0, 0);
            this.pbxRG2.Name = "pbxRG2";
            this.pbxRG2.Size = new System.Drawing.Size(340, 348);
            this.pbxRG2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRG2.TabIndex = 0;
            this.pbxRG2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(696, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // RGCartaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 386);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RGCartaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RG Cartão No. ";
            this.Load += new System.EventHandler(this.RGCartaoForm_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxRG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRG2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbxRG1;
        private System.Windows.Forms.PictureBox pbxRG2;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRG1;
        private System.Windows.Forms.Button btnImpressao;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}