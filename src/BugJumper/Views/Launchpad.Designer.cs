namespace BugJumper.Views
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    partial class Launchpad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Launchpad));
            this.btnGo = new Button();
            this.mtxtNumber = new MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = SystemColors.ButtonHighlight;
            this.btnGo.BackgroundImageLayout = ImageLayout.None;
            this.btnGo.FlatStyle = FlatStyle.Popup;
            this.btnGo.Location = new Point(54, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new Size(34, 21);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new EventHandler(this.btnGo_Click);
            // 
            // mtxtNumber
            // 
            this.mtxtNumber.Location = new Point(13, 11);
            this.mtxtNumber.TextMaskFormat = MaskFormat.IncludePrompt;
            this.mtxtNumber.Name = "mtxtNumber";
            this.mtxtNumber.ResetOnSpace = false;
            this.mtxtNumber.Size = new Size(35, 20);
            this.mtxtNumber.TabIndex = 1;
            this.mtxtNumber.ValidatingType = typeof(int);
            // 
            // Launchpad
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.InfoText;
            this.ClientSize = new Size(102, 42);
            this.Controls.Add(this.mtxtNumber);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
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

        private Button btnGo;
        private MaskedTextBox mtxtNumber;
    }
}