namespace sgc.assinaturas
{
    partial class atualizarAssinaturasForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbNoAssinaturas = new System.Windows.Forms.Label();
            this.btAtualizar = new System.Windows.Forms.Button();
            this.pbAtualiza = new System.Windows.Forms.ProgressBar();
            this.lbStatus = new System.Windows.Forms.Label();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.btVerificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. de Assinaturas para Atualizar:";
            // 
            // lbNoAssinaturas
            // 
            this.lbNoAssinaturas.AutoSize = true;
            this.lbNoAssinaturas.Location = new System.Drawing.Point(12, 32);
            this.lbNoAssinaturas.Name = "lbNoAssinaturas";
            this.lbNoAssinaturas.Size = new System.Drawing.Size(13, 13);
            this.lbNoAssinaturas.TabIndex = 1;
            this.lbNoAssinaturas.Text = "0";
            // 
            // btAtualizar
            // 
            this.btAtualizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAtualizar.Enabled = false;
            this.btAtualizar.Image = global::sgc.Properties.Resources.evolution_contacts;
            this.btAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtualizar.Location = new System.Drawing.Point(214, 53);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(87, 31);
            this.btAtualizar.TabIndex = 2;
            this.btAtualizar.Text = "Iniciar Atualização";
            this.btAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAtualizar.UseVisualStyleBackColor = false;
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
            // 
            // pbAtualiza
            // 
            this.pbAtualiza.Location = new System.Drawing.Point(15, 104);
            this.pbAtualiza.Name = "pbAtualiza";
            this.pbAtualiza.Size = new System.Drawing.Size(398, 23);
            this.pbAtualiza.TabIndex = 3;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 146);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(261, 13);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "Clique em Verificar para saber se existem atualizações";
            // 
            // bgWork
            // 
            this.bgWork.WorkerReportsProgress = true;
            this.bgWork.WorkerSupportsCancellation = true;
            // 
            // btVerificar
            // 
            this.btVerificar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btVerificar.Image = global::sgc.Properties.Resources.addressbook_search;
            this.btVerificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerificar.Location = new System.Drawing.Point(108, 53);
            this.btVerificar.Name = "btVerificar";
            this.btVerificar.Size = new System.Drawing.Size(89, 31);
            this.btVerificar.TabIndex = 5;
            this.btVerificar.Text = "Verificar Atualização";
            this.btVerificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btVerificar.UseVisualStyleBackColor = false;
            this.btVerificar.Click += new System.EventHandler(this.btVerificar_Click);
            // 
            // atualizarAssinaturasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(425, 168);
            this.Controls.Add(this.btVerificar);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.pbAtualiza);
            this.Controls.Add(this.btAtualizar);
            this.Controls.Add(this.lbNoAssinaturas);
            this.Controls.Add(this.label1);
            this.Name = "atualizarAssinaturasForm";
            this.Text = "Atualizar Assinaturas";
            this.Load += new System.EventHandler(this.atualizarAssinaturasForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNoAssinaturas;
        private System.Windows.Forms.Button btAtualizar;
        private System.Windows.Forms.ProgressBar pbAtualiza;
        private System.Windows.Forms.Label lbStatus;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Button btVerificar;
    }
}