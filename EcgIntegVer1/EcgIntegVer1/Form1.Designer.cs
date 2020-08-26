namespace EcgIntegVer1
{
    partial class ECGInteg
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
            this.closeButton = new System.Windows.Forms.Button();
            this.callEcgButton = new System.Windows.Forms.Button();
            this.tryOpenFile = new System.Windows.Forms.Button();
            this.createFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(356, 21);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(77, 28);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // callEcgButton
            // 
            this.callEcgButton.Location = new System.Drawing.Point(39, 50);
            this.callEcgButton.Name = "callEcgButton";
            this.callEcgButton.Size = new System.Drawing.Size(91, 25);
            this.callEcgButton.TabIndex = 2;
            this.callEcgButton.Text = "CallEcgLib";
            this.callEcgButton.UseVisualStyleBackColor = true;
            this.callEcgButton.Click += new System.EventHandler(this.callEcgButton_Click);
            // 
            // tryOpenFile
            // 
            this.tryOpenFile.Location = new System.Drawing.Point(39, 21);
            this.tryOpenFile.Name = "tryOpenFile";
            this.tryOpenFile.Size = new System.Drawing.Size(91, 25);
            this.tryOpenFile.TabIndex = 3;
            this.tryOpenFile.Text = "Try Open File";
            this.tryOpenFile.UseVisualStyleBackColor = true;
            this.tryOpenFile.Click += new System.EventHandler(this.tryOpenFile_Click);
            // 
            // createFile
            // 
            this.createFile.Location = new System.Drawing.Point(39, 96);
            this.createFile.Name = "createFile";
            this.createFile.Size = new System.Drawing.Size(91, 25);
            this.createFile.TabIndex = 4;
            this.createFile.Text = "Create File";
            this.createFile.UseVisualStyleBackColor = true;
            this.createFile.Click += new System.EventHandler(this.createFile_Click);
            // 
            // ECGInteg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(443, 324);
            this.Controls.Add(this.createFile);
            this.Controls.Add(this.tryOpenFile);
            this.Controls.Add(this.callEcgButton);
            this.Controls.Add(this.closeButton);
            this.Name = "ECGInteg";
            this.Text = "ECGInteg";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button callEcgButton;
        private System.Windows.Forms.Button tryOpenFile;
        private System.Windows.Forms.Button createFile;
    }
}

