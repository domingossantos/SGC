namespace sgc.assinaturas
{
    partial class detalheAssinaturaForm
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
            this.img = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btzoomIn = new System.Windows.Forms.Button();
            this.btZoomOut = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.Color.White;
            this.img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img.Location = new System.Drawing.Point(0, 0);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(652, 493);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btzoomIn);
            this.panel1.Controls.Add(this.btZoomOut);
            this.panel1.Controls.Add(this.btFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 39);
            this.panel1.TabIndex = 1;
            // 
            // btzoomIn
            // 
            this.btzoomIn.Image = global::sgc.Properties.Resources.search;
            this.btzoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btzoomIn.Location = new System.Drawing.Point(122, 3);
            this.btzoomIn.Name = "btzoomIn";
            this.btzoomIn.Size = new System.Drawing.Size(111, 32);
            this.btzoomIn.TabIndex = 2;
            this.btzoomIn.Text = "Aumentar (F12)";
            this.btzoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btzoomIn.UseVisualStyleBackColor = true;
            this.btzoomIn.Click += new System.EventHandler(this.btzoomIn_Click);
            // 
            // btZoomOut
            // 
            this.btZoomOut.Image = global::sgc.Properties.Resources.search;
            this.btZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btZoomOut.Location = new System.Drawing.Point(3, 4);
            this.btZoomOut.Name = "btZoomOut";
            this.btZoomOut.Size = new System.Drawing.Size(113, 32);
            this.btZoomOut.TabIndex = 1;
            this.btZoomOut.Text = "Diminuir (F11)";
            this.btZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btZoomOut.UseVisualStyleBackColor = true;
            this.btZoomOut.Click += new System.EventHandler(this.btZoomOut_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = global::sgc.Properties.Resources.cancel24;
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(540, 4);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 32);
            this.btFechar.TabIndex = 0;
            this.btFechar.Text = "Fechar (F10)";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // detalheAssinaturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 493);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.img);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "detalheAssinaturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhe Assinatura";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detalheAssinaturaForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btzoomIn;
        private System.Windows.Forms.Button btZoomOut;
        public System.Windows.Forms.PictureBox img;
    }
}