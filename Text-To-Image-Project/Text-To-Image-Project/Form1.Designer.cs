namespace DALLE_WinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button GenerateImageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DownloadImageButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.GenerateImageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DownloadImageButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 12);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(776, 20);
            this.InputTextBox.TabIndex = 0;
            // 
            // GenerateImageButton
            // 
            this.GenerateImageButton.Location = new System.Drawing.Point(12, 38);
            this.GenerateImageButton.Name = "GenerateImageButton";
            this.GenerateImageButton.Size = new System.Drawing.Size(150, 23);
            this.GenerateImageButton.TabIndex = 1;
            this.GenerateImageButton.Text = "Generate Image";
            this.GenerateImageButton.UseVisualStyleBackColor = true;
            this.GenerateImageButton.Click += new System.EventHandler(this.GenerateImageButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 371);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // DownloadImageButton
            // 
            this.DownloadImageButton.Location = new System.Drawing.Point(168, 38);
            this.DownloadImageButton.Name = "DownloadImageButton";
            this.DownloadImageButton.Size = new System.Drawing.Size(150, 23);
            this.DownloadImageButton.TabIndex = 3;
            this.DownloadImageButton.Text = "Download Image";
            this.DownloadImageButton.UseVisualStyleBackColor = true;
            this.DownloadImageButton.Click += new System.EventHandler(this.DownloadImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DownloadImageButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GenerateImageButton);
            this.Controls.Add(this.InputTextBox);
            this.Name = "Form1";
            this.Text = "DALL-E Image Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
