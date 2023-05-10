
namespace BlasModInstaller
{
    partial class MainForm
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
            this.scroll = new System.Windows.Forms.VScrollBar();
            this.modHolder = new System.Windows.Forms.Panel();
            this.blasLocation = new System.Windows.Forms.Label();
            this.modHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // scroll
            // 
            this.scroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scroll.Location = new System.Drawing.Point(1142, 12);
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(20, 632);
            this.scroll.TabIndex = 2;
            this.scroll.Visible = false;
            // 
            // modHolder
            // 
            this.modHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modHolder.AutoScroll = true;
            this.modHolder.AutoScrollMargin = new System.Drawing.Size(0, 15);
            this.modHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modHolder.Controls.Add(this.scroll);
            this.modHolder.Location = new System.Drawing.Point(0, 100);
            this.modHolder.Name = "modHolder";
            this.modHolder.Size = new System.Drawing.Size(1183, 657);
            this.modHolder.TabIndex = 3;
            // 
            // blasLocation
            // 
            this.blasLocation.AutoSize = true;
            this.blasLocation.Location = new System.Drawing.Point(12, 9);
            this.blasLocation.Name = "blasLocation";
            this.blasLocation.Size = new System.Drawing.Size(414, 17);
            this.blasLocation.TabIndex = 4;
            this.blasLocation.Text = "Blasphemous location: C:\\Users\\Brand\\Documents\\Blasphemous";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.blasLocation);
            this.Controls.Add(this.modHolder);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Blasphemous Mod Installer";
            this.modHolder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.VScrollBar scroll;
        private System.Windows.Forms.Panel modHolder;
        private System.Windows.Forms.Label blasLocation;
    }
}

