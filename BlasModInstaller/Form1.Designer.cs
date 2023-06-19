
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
            this.blas1modScroll = new System.Windows.Forms.VScrollBar();
            this.blas1modSection = new System.Windows.Forms.Panel();
            this.blasLocButton = new System.Windows.Forms.Button();
            this.blas1locationSection = new System.Windows.Forms.Panel();
            this.blasLocFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.blasLocDialog = new System.Windows.Forms.OpenFileDialog();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainSection = new System.Windows.Forms.Panel();
            this.titleSectionOuter = new System.Windows.Forms.Panel();
            this.blas1skinSection = new System.Windows.Forms.Panel();
            this.blas1skinText = new System.Windows.Forms.Label();
            this.blas1skinScroll = new System.Windows.Forms.VScrollBar();
            this.blas2modSection = new System.Windows.Forms.Panel();
            this.blas2modText = new System.Windows.Forms.Label();
            this.blas2modScroll = new System.Windows.Forms.VScrollBar();
            this.sideSection = new System.Windows.Forms.Panel();
            this.warningSection = new System.Windows.Forms.Panel();
            this.warningInner = new System.Windows.Forms.Panel();
            this.warningImage = new System.Windows.Forms.PictureBox();
            this.warningText = new System.Windows.Forms.Label();
            this.debugLog = new System.Windows.Forms.TextBox();
            this.blas2modsBtn = new System.Windows.Forms.Button();
            this.blas1skinsBtn = new System.Windows.Forms.Button();
            this.blas1modsBtn = new System.Windows.Forms.Button();
            this.titleSectionInner = new System.Windows.Forms.Panel();
            this.blas1modSection.SuspendLayout();
            this.blas1locationSection.SuspendLayout();
            this.mainSection.SuspendLayout();
            this.titleSectionOuter.SuspendLayout();
            this.blas1skinSection.SuspendLayout();
            this.blas2modSection.SuspendLayout();
            this.sideSection.SuspendLayout();
            this.warningSection.SuspendLayout();
            this.warningInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningImage)).BeginInit();
            this.SuspendLayout();
            // 
            // blas1modScroll
            // 
            this.blas1modScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1modScroll.Location = new System.Drawing.Point(1934, 15);
            this.blas1modScroll.Name = "blas1modScroll";
            this.blas1modScroll.Size = new System.Drawing.Size(20, 623);
            this.blas1modScroll.TabIndex = 2;
            this.blas1modScroll.Visible = false;
            // 
            // blas1modSection
            // 
            this.blas1modSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1modSection.AutoScroll = true;
            this.blas1modSection.AutoScrollMargin = new System.Drawing.Size(0, 15);
            this.blas1modSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.blas1modSection.Controls.Add(this.blas1modScroll);
            this.blas1modSection.Location = new System.Drawing.Point(0, 60);
            this.blas1modSection.Name = "blas1modSection";
            this.blas1modSection.Size = new System.Drawing.Size(950, 701);
            this.blas1modSection.TabIndex = 3;
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
            // blas1locationSection
            // 
            this.blas1locationSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1locationSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.blas1locationSection.Controls.Add(this.blasLocButton);
            this.blas1locationSection.Location = new System.Drawing.Point(0, 60);
            this.blas1locationSection.Name = "blas1locationSection";
            this.blas1locationSection.Size = new System.Drawing.Size(950, 701);
            this.blas1locationSection.TabIndex = 4;
            // 
            // blasLocDialog
            // 
            this.blasLocDialog.FileName = "Blasphemous.exe";
            this.blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            this.blasLocDialog.Title = "Choose Blasphemous.exe location";
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.DarkRed;
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
            this.mainSection.Controls.Add(this.titleSectionOuter);
            this.mainSection.Controls.Add(this.blas1modSection);
            this.mainSection.Controls.Add(this.blas1skinSection);
            this.mainSection.Controls.Add(this.blas1locationSection);
            this.mainSection.Controls.Add(this.blas2modSection);
            this.mainSection.Location = new System.Drawing.Point(250, 0);
            this.mainSection.Name = "mainSection";
            this.mainSection.Size = new System.Drawing.Size(950, 800);
            this.mainSection.TabIndex = 7;
            // 
            // titleSectionOuter
            // 
            this.titleSectionOuter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleSectionOuter.BackColor = System.Drawing.Color.Black;
            this.titleSectionOuter.Controls.Add(this.titleSectionInner);
            this.titleSectionOuter.Location = new System.Drawing.Point(0, 0);
            this.titleSectionOuter.Name = "titleSectionOuter";
            this.titleSectionOuter.Size = new System.Drawing.Size(950, 60);
            this.titleSectionOuter.TabIndex = 9;
            // 
            // blas1skinSection
            // 
            this.blas1skinSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1skinSection.AutoScroll = true;
            this.blas1skinSection.AutoScrollMargin = new System.Drawing.Size(0, 15);
            this.blas1skinSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.blas1skinSection.Controls.Add(this.blas1skinText);
            this.blas1skinSection.Controls.Add(this.blas1skinScroll);
            this.blas1skinSection.Location = new System.Drawing.Point(0, 60);
            this.blas1skinSection.Name = "blas1skinSection";
            this.blas1skinSection.Size = new System.Drawing.Size(950, 701);
            this.blas1skinSection.TabIndex = 5;
            // 
            // blas1skinText
            // 
            this.blas1skinText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blas1skinText.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas1skinText.Location = new System.Drawing.Point(0, 0);
            this.blas1skinText.Name = "blas1skinText";
            this.blas1skinText.Size = new System.Drawing.Size(950, 701);
            this.blas1skinText.TabIndex = 3;
            this.blas1skinText.Text = "Skin support coming soon!";
            this.blas1skinText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.blas1skinText.Visible = false;
            // 
            // blas1skinScroll
            // 
            this.blas1skinScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1skinScroll.Location = new System.Drawing.Point(914, 15);
            this.blas1skinScroll.Name = "blas1skinScroll";
            this.blas1skinScroll.Size = new System.Drawing.Size(20, 640);
            this.blas1skinScroll.TabIndex = 2;
            this.blas1skinScroll.Visible = false;
            // 
            // blas2modSection
            // 
            this.blas2modSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas2modSection.AutoScroll = true;
            this.blas2modSection.AutoScrollMargin = new System.Drawing.Size(0, 15);
            this.blas2modSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.blas2modSection.Controls.Add(this.blas2modText);
            this.blas2modSection.Controls.Add(this.blas2modScroll);
            this.blas2modSection.Location = new System.Drawing.Point(0, 60);
            this.blas2modSection.Name = "blas2modSection";
            this.blas2modSection.Size = new System.Drawing.Size(950, 701);
            this.blas2modSection.TabIndex = 4;
            // 
            // blas2modText
            // 
            this.blas2modText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blas2modText.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas2modText.Location = new System.Drawing.Point(0, 0);
            this.blas2modText.Name = "blas2modText";
            this.blas2modText.Size = new System.Drawing.Size(950, 701);
            this.blas2modText.TabIndex = 3;
            this.blas2modText.Text = "There is nothing here yet...";
            this.blas2modText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blas2modScroll
            // 
            this.blas2modScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas2modScroll.Location = new System.Drawing.Point(914, 15);
            this.blas2modScroll.Name = "blas2modScroll";
            this.blas2modScroll.Size = new System.Drawing.Size(20, 640);
            this.blas2modScroll.TabIndex = 2;
            this.blas2modScroll.Visible = false;
            // 
            // sideSection
            // 
            this.sideSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sideSection.BackColor = System.Drawing.Color.Black;
            this.sideSection.Controls.Add(this.warningSection);
            this.sideSection.Controls.Add(this.debugLog);
            this.sideSection.Controls.Add(this.blas2modsBtn);
            this.sideSection.Controls.Add(this.blas1skinsBtn);
            this.sideSection.Controls.Add(this.blas1modsBtn);
            this.sideSection.Location = new System.Drawing.Point(0, 0);
            this.sideSection.Name = "sideSection";
            this.sideSection.Size = new System.Drawing.Size(250, 800);
            this.sideSection.TabIndex = 8;
            // 
            // warningSection
            // 
            this.warningSection.BackColor = System.Drawing.Color.White;
            this.warningSection.Controls.Add(this.warningInner);
            this.warningSection.Location = new System.Drawing.Point(15, 645);
            this.warningSection.Name = "warningSection";
            this.warningSection.Size = new System.Drawing.Size(220, 100);
            this.warningSection.TabIndex = 6;
            this.warningSection.Visible = false;
            // 
            // warningInner
            // 
            this.warningInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningInner.BackColor = System.Drawing.Color.Black;
            this.warningInner.Controls.Add(this.warningImage);
            this.warningInner.Controls.Add(this.warningText);
            this.warningInner.Location = new System.Drawing.Point(2, 2);
            this.warningInner.Name = "warningInner";
            this.warningInner.Size = new System.Drawing.Size(216, 96);
            this.warningInner.TabIndex = 0;
            // 
            // warningImage
            // 
            this.warningImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.warningImage.BackColor = System.Drawing.Color.Black;
            this.warningImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.warningImage.Image = global::BlasModInstaller.Properties.Resources.warning;
            this.warningImage.Location = new System.Drawing.Point(10, 30);
            this.warningImage.Name = "warningImage";
            this.warningImage.Size = new System.Drawing.Size(36, 36);
            this.warningImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.warningImage.TabIndex = 4;
            this.warningImage.TabStop = false;
            // 
            // warningText
            // 
            this.warningText.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.warningText.Location = new System.Drawing.Point(52, 20);
            this.warningText.Name = "warningText";
            this.warningText.Size = new System.Drawing.Size(160, 56);
            this.warningText.TabIndex = 5;
            this.warningText.Text = "A new update is available for the mod installer.  Please download it now.";
            // 
            // debugLog
            // 
            this.debugLog.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.debugLog.ForeColor = System.Drawing.SystemColors.Menu;
            this.debugLog.Location = new System.Drawing.Point(15, 248);
            this.debugLog.Multiline = true;
            this.debugLog.Name = "debugLog";
            this.debugLog.ReadOnly = true;
            this.debugLog.Size = new System.Drawing.Size(220, 300);
            this.debugLog.TabIndex = 0;
            // 
            // blas2modsBtn
            // 
            this.blas2modsBtn.BackColor = System.Drawing.Color.Black;
            this.blas2modsBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.blas2modsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.blas2modsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.blas2modsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blas2modsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas2modsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blas2modsBtn.Location = new System.Drawing.Point(15, 165);
            this.blas2modsBtn.Name = "blas2modsBtn";
            this.blas2modsBtn.Size = new System.Drawing.Size(220, 35);
            this.blas2modsBtn.TabIndex = 2;
            this.blas2modsBtn.Text = "Blasphemous II Mods";
            this.blas2modsBtn.UseVisualStyleBackColor = false;
            this.blas2modsBtn.Click += new System.EventHandler(this.blas2modsBtn_Click);
            this.blas2modsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.blas2modsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.blas2modsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // blas1skinsBtn
            // 
            this.blas1skinsBtn.BackColor = System.Drawing.Color.Black;
            this.blas1skinsBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.blas1skinsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.blas1skinsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.blas1skinsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blas1skinsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas1skinsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blas1skinsBtn.Location = new System.Drawing.Point(15, 120);
            this.blas1skinsBtn.Name = "blas1skinsBtn";
            this.blas1skinsBtn.Size = new System.Drawing.Size(220, 35);
            this.blas1skinsBtn.TabIndex = 1;
            this.blas1skinsBtn.Text = "Blasphemous Skins";
            this.blas1skinsBtn.UseVisualStyleBackColor = false;
            this.blas1skinsBtn.Click += new System.EventHandler(this.blas1skinsBtn_Click);
            this.blas1skinsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.blas1skinsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.blas1skinsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // blas1modsBtn
            // 
            this.blas1modsBtn.BackColor = System.Drawing.Color.Black;
            this.blas1modsBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.blas1modsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.blas1modsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.blas1modsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blas1modsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas1modsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blas1modsBtn.Location = new System.Drawing.Point(15, 75);
            this.blas1modsBtn.Name = "blas1modsBtn";
            this.blas1modsBtn.Size = new System.Drawing.Size(220, 35);
            this.blas1modsBtn.TabIndex = 3;
            this.blas1modsBtn.Text = "Blasphemous Mods";
            this.blas1modsBtn.UseVisualStyleBackColor = false;
            this.blas1modsBtn.Click += new System.EventHandler(this.blas1modsBtn_Click);
            this.blas1modsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.blas1modsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.blas1modsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // titleSectionInner
            // 
            this.titleSectionInner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleSectionInner.BackColor = System.Drawing.Color.Maroon;
            this.titleSectionInner.Location = new System.Drawing.Point(0, 0);
            this.titleSectionInner.Name = "titleSectionInner";
            this.titleSectionInner.Size = new System.Drawing.Size(950, 58);
            this.titleSectionInner.TabIndex = 1;
            this.titleSectionInner.Controls.Add(this.titleLabel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.mainSection);
            this.Controls.Add(this.sideSection);
            this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Blasphemous Mod Installer";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.blas1modSection.ResumeLayout(false);
            this.blas1locationSection.ResumeLayout(false);
            this.mainSection.ResumeLayout(false);
            this.titleSectionOuter.ResumeLayout(false);
            this.blas1skinSection.ResumeLayout(false);
            this.blas2modSection.ResumeLayout(false);
            this.sideSection.ResumeLayout(false);
            this.sideSection.PerformLayout();
            this.warningSection.ResumeLayout(false);
            this.warningInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.VScrollBar blas1modScroll;
        private System.Windows.Forms.Panel blas1modSection;
        private System.Windows.Forms.Button blasLocButton;
        private System.Windows.Forms.FolderBrowserDialog blasLocFolderDialog;
        private System.Windows.Forms.OpenFileDialog blasLocDialog;
        private System.Windows.Forms.Panel blas1locationSection;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainSection;
        private System.Windows.Forms.Panel sideSection;
        private System.Windows.Forms.Panel titleSectionOuter;
        private System.Windows.Forms.Button blas1modsBtn;
        private System.Windows.Forms.Button blas1skinsBtn;
        private System.Windows.Forms.Button blas2modsBtn;
        private System.Windows.Forms.TextBox debugLog;
        private System.Windows.Forms.Panel blas2modSection;
        private System.Windows.Forms.VScrollBar blas2modScroll;
        private System.Windows.Forms.Label blas2modText;
        private System.Windows.Forms.PictureBox warningImage;
        private System.Windows.Forms.Label warningText;
        private System.Windows.Forms.Panel warningSection;
        private System.Windows.Forms.Panel warningInner;
        private System.Windows.Forms.Panel blas1skinSection;
        private System.Windows.Forms.Label blas1skinText;
        private System.Windows.Forms.VScrollBar blas1skinScroll;
        private System.Windows.Forms.Panel titleSectionInner;
    }
}

