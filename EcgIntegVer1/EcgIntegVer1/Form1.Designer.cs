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
            this.callEcgButton.Location = new System.Drawing.Point(184, 146);
            this.callEcgButton.Name = "callEcgButton";
            this.callEcgButton.Size = new System.Drawing.Size(75, 23);
            this.callEcgButton.TabIndex = 2;
            this.callEcgButton.Text = "CallEcgLib";
            this.callEcgButton.UseVisualStyleBackColor = true;
            this.callEcgButton.Click += new System.EventHandler(this.callEcgButton_Click);
            // 
            // ECGInteg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(443, 324);
            this.Controls.Add(this.callEcgButton);
            this.Controls.Add(this.closeButton);
            this.Name = "ECGInteg";
            this.Text = "ECGInteg";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button callEcgButton;
    }
}

