namespace CombatForms
{
    partial class CombatForm
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
            if(disposing && (components != null))
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
            this.userControl11 = new CombatForms.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userControl11.BackColor = System.Drawing.Color.Transparent;
            this.userControl11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userControl11.Location = new System.Drawing.Point(0, -7);
            this.userControl11.Margin = new System.Windows.Forms.Padding(0);
            this.userControl11.MaximumSize = new System.Drawing.Size(775, 385);
            this.userControl11.MinimumSize = new System.Drawing.Size(775, 385);
            this.userControl11.Name = "userControl11";
            this.userControl11.Padding = new System.Windows.Forms.Padding(3);
            this.userControl11.Size = new System.Drawing.Size(775, 385);
            this.userControl11.TabIndex = 1;
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(771, 398);
            this.Controls.Add(this.userControl11);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CombatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CombatForm";
            this.ResumeLayout(false);

        }

        #endregion
        private UserControl1 userControl11;
    }
}