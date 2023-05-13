
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
            this.debugBtn = new System.Windows.Forms.Button();
            this.blasLocButton = new System.Windows.Forms.Button();
            this.blasLocFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.blasLocDialog = new System.Windows.Forms.OpenFileDialog();
            this.fakePanel = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.modHolder.SuspendLayout();
            this.fakePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // scroll
            // 
            this.scroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scroll.Location = new System.Drawing.Point(1142, 12);
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(20, 635);
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
            this.modHolder.Size = new System.Drawing.Size(1183, 660);
            this.modHolder.TabIndex = 3;
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(12, 12);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(75, 26);
            this.debugBtn.TabIndex = 5;
            this.debugBtn.Text = "Debug";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.ClickedDebug);
            // 
            // blasLocButton
            // 
            this.blasLocButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.blasLocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocButton.Location = new System.Drawing.Point(460, 300);
            this.blasLocButton.Name = "blasLocButton";
            this.blasLocButton.Size = new System.Drawing.Size(260, 50);
            this.blasLocButton.TabIndex = 7;
            this.blasLocButton.Text = "Locate Blasphemous.exe";
            this.blasLocButton.UseVisualStyleBackColor = true;
            this.blasLocButton.Click += new System.EventHandler(this.ChooseBlasLocation);
            // 
            // blasLocDialog
            // 
            this.blasLocDialog.FileName = "Blasphemous.exe";
            this.blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            this.blasLocDialog.Title = "Choose Blasphemous.exe location";
            // 
            // fakePanel
            // 
            this.fakePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fakePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fakePanel.Controls.Add(this.vScrollBar1);
            this.fakePanel.Controls.Add(this.blasLocButton);
            this.fakePanel.Location = new System.Drawing.Point(0, 100);
            this.fakePanel.Name = "fakePanel";
            this.fakePanel.Size = new System.Drawing.Size(1183, 660);
            this.fakePanel.TabIndex = 4;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(1142, 12);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 635);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.fakePanel);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.modHolder);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Blasphemous Mod Installer";
            this.modHolder.ResumeLayout(false);
            this.fakePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.VScrollBar scroll;
        private System.Windows.Forms.Panel modHolder;
        private System.Windows.Forms.Button debugBtn;
        private System.Windows.Forms.Button blasLocButton;
        private System.Windows.Forms.FolderBrowserDialog blasLocFolderDialog;
        private System.Windows.Forms.OpenFileDialog blasLocDialog;
        private System.Windows.Forms.Panel fakePanel;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

