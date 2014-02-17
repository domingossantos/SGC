namespace sgc.assinaturas
{
    partial class mesaForm
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
            this.btFechar = new System.Windows.Forms.Button();
            this.btApagar = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.imagem = new System.Windows.Forms.PictureBox();
            this.btZoonOut = new System.Windows.Forms.Button();
            this.btZoonIn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btZoonIn);
            this.panel1.Controls.Add(this.btZoonOut);
            this.panel1.Controls.Add(this.btFechar);
            this.panel1.Controls.Add(this.btApagar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 45);
            this.panel1.TabIndex = 0;
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btFechar.Image = global::sgc.Properties.Resources.cancel24;
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(142, 7);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(117, 32);
            this.btFechar.TabIndex = 1;
            this.btFechar.Text = "Fechar (F10)";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = false;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btApagar
            // 
            this.btApagar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btApagar.Image = global::sgc.Properties.Resources.delete16;
            this.btApagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btApagar.Location = new System.Drawing.Point(12, 6);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(124, 32);
            this.btApagar.TabIndex = 0;
            this.btApagar.Text = "Apagar (Ctrl+Del)";
            this.btApagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btApagar.UseVisualStyleBackColor = false;
            this.btApagar.Click += new System.EventHandler(this.btApagar_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grid.Location = new System.Drawing.Point(0, 416);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(764, 94);
            this.grid.TabIndex = 1;
            this.grid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEnter);
            // 
            // imagem
            // 
            this.imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagem.Location = new System.Drawing.Point(0, 45);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(764, 371);
            this.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagem.TabIndex = 3;
            this.imagem.TabStop = false;
            // 
            // btZoonOut
            // 
            this.btZoonOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btZoonOut.Location = new System.Drawing.Point(654, 15);
            this.btZoonOut.Name = "btZoonOut";
            this.btZoonOut.Size = new System.Drawing.Size(98, 23);
            this.btZoonOut.TabIndex = 1;
            this.btZoonOut.Text = "Afastar (F12)";
            this.btZoonOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btZoonOut.UseVisualStyleBackColor = false;
            this.btZoonOut.Click += new System.EventHandler(this.btZoonOut_Click);
            // 
            // btZoonIn
            // 
            this.btZoonIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btZoonIn.Location = new System.Drawing.Point(550, 16);
            this.btZoonIn.Name = "btZoonIn";
            this.btZoonIn.Size = new System.Drawing.Size(98, 23);
            this.btZoonIn.TabIndex = 0;
            this.btZoonIn.Text = "Aproximar (F11)";
            this.btZoonIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btZoonIn.UseVisualStyleBackColor = false;
            this.btZoonIn.Click += new System.EventHandler(this.btZoonIn_Click);
            // 
            // mesaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(764, 510);
            this.Controls.Add(this.imagem);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "mesaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesa de Assinaturas";
            this.Load += new System.EventHandler(this.mesaForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mesaForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Button btZoonIn;
        private System.Windows.Forms.Button btZoonOut;
        private System.Windows.Forms.Button btApagar;
        private System.Windows.Forms.Button btFechar;
    }
}