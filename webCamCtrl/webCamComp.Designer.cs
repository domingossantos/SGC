namespace webCamCtrl
{
    partial class webCamComp
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgWebCam = new System.Windows.Forms.PictureBox();
            this.tRefreshFrame = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // imgWebCam
            // 
            this.imgWebCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgWebCam.Location = new System.Drawing.Point(0, 0);
            this.imgWebCam.Name = "imgWebCam";
            this.imgWebCam.Size = new System.Drawing.Size(150, 150);
            this.imgWebCam.TabIndex = 0;
            this.imgWebCam.TabStop = false;
            // 
            // tRefreshFrame
            // 
            this.tRefreshFrame.Tick += new System.EventHandler(this.tRefreshFrame_Tick);
            // 
            // webCamComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgWebCam);
            this.Name = "webCamComp";
            ((System.ComponentModel.ISupportInitialize)(this.imgWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgWebCam;
        private System.Windows.Forms.Timer tRefreshFrame;
    }
}
