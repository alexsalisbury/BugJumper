namespace BugJumper.Views
{
    partial class Launchpad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launchpad));
            this.btnGo = new System.Windows.Forms.Button();
            this.mtxtNumber = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGo.Location = new System.Drawing.Point(54, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(34, 21);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // mtxtNumber
            // 
            this.mtxtNumber.Location = new System.Drawing.Point(13, 11);
            this.mtxtNumber.Mask = "0000";
            this.mtxtNumber.Name = "mtxtNumber";
            this.mtxtNumber.ResetOnSpace = false;
            this.mtxtNumber.Size = new System.Drawing.Size(35, 20);
            this.mtxtNumber.TabIndex = 1;
            this.mtxtNumber.ValidatingType = typeof(int);
            // 
            // Launchpad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(102, 42);
            this.Controls.Add(this.mtxtNumber);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launchpad";
            this.Opacity = 0.5D;
            this.Text = "Launchpad";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.MaskedTextBox mtxtNumber;
    }
}