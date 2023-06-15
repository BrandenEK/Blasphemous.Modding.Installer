
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scroll = new System.Windows.Forms.VScrollBar();
            this.modSection = new System.Windows.Forms.Panel();
            this.blasLocButton = new System.Windows.Forms.Button();
            this.locationSection = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.debugBtn = new System.Windows.Forms.Button();
            this.blasLocFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.blasLocDialog = new System.Windows.Forms.OpenFileDialog();
            this.debugText = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainSection = new System.Windows.Forms.Panel();
            this.titleSection = new System.Windows.Forms.Panel();
            this.sideSection = new System.Windows.Forms.Panel();
            this.modSection.SuspendLayout();
            this.locationSection.SuspendLayout();
            this.mainSection.SuspendLayout();
            this.titleSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // scroll
            // 
            this.scroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scroll.Location = new System.Drawing.Point(914, 14);
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(20, 640);
            this.scroll.TabIndex = 2;
            this.scroll.Visible = false;
            // 
            // modSection
            // 
            this.modSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modSection.AutoScroll = true;
            this.modSection.AutoScrollMargin = new System.Drawing.Size(0, 15);
            this.modSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.modSection.Controls.Add(this.scroll);
            this.modSection.Controls.Add(this.vScrollBar1);
            this.modSection.Location = new System.Drawing.Point(0, 60);
            this.modSection.Name = "modSection";
            this.modSection.Size = new System.Drawing.Size(950, 701);
            this.modSection.TabIndex = 3;
            // 
            // blasLocButton
            // 
            this.blasLocButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blasLocButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocButton.Location = new System.Drawing.Point(375, 325);
            this.blasLocButton.Name = "blasLocButton";
            this.blasLocButton.Size = new System.Drawing.Size(200, 50);
            this.blasLocButton.TabIndex = 7;
            this.blasLocButton.Text = "Locate Blasphemous.exe";
            this.blasLocButton.UseVisualStyleBackColor = true;
            this.blasLocButton.Click += new System.EventHandler(this.ChooseBlasLocation);
            // 
            // locationSection
            // 
            this.locationSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.locationSection.Controls.Add(this.blasLocButton);
            this.locationSection.Location = new System.Drawing.Point(0, 60);
            this.locationSection.Name = "locationSection";
            this.locationSection.Size = new System.Drawing.Size(950, 701);
            this.locationSection.TabIndex = 4;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(965, -7);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 714);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Visible = false;
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(10, 14);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(66, 29);
            this.debugBtn.TabIndex = 0;
            this.debugBtn.Text = "Debug";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Visible = false;
            this.debugBtn.Click += new System.EventHandler(this.ClickedDebug);
            // 
            // blasLocDialog
            // 
            this.blasLocDialog.FileName = "Blasphemous.exe";
            this.blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            this.blasLocDialog.Title = "Choose Blasphemous.exe location";
            // 
            // debugText
            // 
            this.debugText.AutoSize = true;
            this.debugText.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugText.Location = new System.Drawing.Point(81, 19);
            this.debugText.Name = "debugText";
            this.debugText.Size = new System.Drawing.Size(39, 16);
            this.debugText.TabIndex = 6;
            this.debugText.Text = "Debug";
            this.debugText.Visible = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Trebuchet MS", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(950, 60);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Blasphemous Mods";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainSection
            // 
            this.mainSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSection.BackColor = System.Drawing.Color.White;
            this.mainSection.Controls.Add(this.titleSection);
            this.mainSection.Controls.Add(this.modSection);
            this.mainSection.Controls.Add(this.locationSection);
            this.mainSection.Location = new System.Drawing.Point(250, 0);
            this.mainSection.Name = "mainSection";
            this.mainSection.Size = new System.Drawing.Size(950, 800);
            this.mainSection.TabIndex = 7;
            // 
            // titleSection
            // 
            this.titleSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleSection.BackColor = System.Drawing.Color.Maroon;
            this.titleSection.Controls.Add(this.titleLabel);
            this.titleSection.Location = new System.Drawing.Point(0, 0);
            this.titleSection.Name = "titleSection";
            this.titleSection.Size = new System.Drawing.Size(950, 60);
            this.titleSection.TabIndex = 9;
            // 
            // sideSection
            // 
            this.sideSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sideSection.BackColor = System.Drawing.Color.Black;
            this.sideSection.Location = new System.Drawing.Point(0, 0);
            this.sideSection.Name = "sideSection";
            this.sideSection.Size = new System.Drawing.Size(250, 800);
            this.sideSection.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.debugText);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.mainSection);
            this.Controls.Add(this.sideSection);
            this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Blasphemous Mod Installer";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.modSection.ResumeLayout(false);
            this.locationSection.ResumeLayout(false);
            this.mainSection.ResumeLayout(false);
            this.titleSection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.VScrollBar scroll;
        private System.Windows.Forms.Panel modSection;
        private System.Windows.Forms.Button debugBtn;
        private System.Windows.Forms.Button blasLocButton;
        private System.Windows.Forms.FolderBrowserDialog blasLocFolderDialog;
        private System.Windows.Forms.OpenFileDialog blasLocDialog;
        private System.Windows.Forms.Panel locationSection;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label debugText;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainSection;
        private System.Windows.Forms.Panel sideSection;
        private System.Windows.Forms.Panel titleSection;
    }
}

