
namespace BlasModInstaller
{
    partial class UIHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIHandler));
            this.blas1modScroll = new System.Windows.Forms.VScrollBar();
            this.blas1modSection = new System.Windows.Forms.Panel();
            this.locationBtn = new System.Windows.Forms.Button();
            this.validationSection = new System.Windows.Forms.Panel();
            this.toolsBtn = new System.Windows.Forms.Button();
            this.blasLocDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainSection = new System.Windows.Forms.Panel();
            this.titleSectionOuter = new System.Windows.Forms.Panel();
            this.titleSectionInner = new System.Windows.Forms.Panel();
            this.warningSectionOuter = new System.Windows.Forms.Panel();
            this.warningSectionInner = new System.Windows.Forms.Panel();
            this.warningText = new System.Windows.Forms.LinkLabel();
            this.warningImage = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.blas1skinSection = new System.Windows.Forms.Panel();
            this.blas1skinScroll = new System.Windows.Forms.VScrollBar();
            this.blas2modSection = new System.Windows.Forms.Panel();
            this.blas2modScroll = new System.Windows.Forms.VScrollBar();
            this.sideSectionInner = new System.Windows.Forms.Panel();
            this.divider2 = new System.Windows.Forms.Panel();
            this.divider1 = new System.Windows.Forms.Panel();
            this.disableBtn = new System.Windows.Forms.Button();
            this.enableBtn = new System.Windows.Forms.Button();
            this.uninstallBtn = new System.Windows.Forms.Button();
            this.installBtn = new System.Windows.Forms.Button();
            this.sortSection = new System.Windows.Forms.Panel();
            this.sortByText = new System.Windows.Forms.Label();
            this.sortByName = new System.Windows.Forms.RadioButton();
            this.sortByAuthor = new System.Windows.Forms.RadioButton();
            this.sortByLatestRelease = new System.Windows.Forms.RadioButton();
            this.sortByInitialRelease = new System.Windows.Forms.RadioButton();
            this.debugLog = new System.Windows.Forms.TextBox();
            this.blas2modsBtn = new System.Windows.Forms.Button();
            this.blas1skinsBtn = new System.Windows.Forms.Button();
            this.blas1modsBtn = new System.Windows.Forms.Button();
            this.sideSectionOuter = new System.Windows.Forms.Panel();
            this.blas1modSection.SuspendLayout();
            this.validationSection.SuspendLayout();
            this.mainSection.SuspendLayout();
            this.titleSectionOuter.SuspendLayout();
            this.titleSectionInner.SuspendLayout();
            this.warningSectionOuter.SuspendLayout();
            this.warningSectionInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningImage)).BeginInit();
            this.blas1skinSection.SuspendLayout();
            this.blas2modSection.SuspendLayout();
            this.sideSectionInner.SuspendLayout();
            this.sortSection.SuspendLayout();
            this.sideSectionOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // blas1modScroll
            // 
            this.blas1modScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1modScroll.Location = new System.Drawing.Point(2134, 15);
            this.blas1modScroll.Name = "blas1modScroll";
            this.blas1modScroll.Size = new System.Drawing.Size(20, 663);
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
            this.blas1modSection.Location = new System.Drawing.Point(0, 120);
            this.blas1modSection.Name = "blas1modSection";
            this.blas1modSection.Size = new System.Drawing.Size(1150, 741);
            this.blas1modSection.TabIndex = 3;
            this.blas1modSection.Visible = false;
            // 
            // locationBtn
            // 
            this.locationBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.locationBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationBtn.Location = new System.Drawing.Point(470, 310);
            this.locationBtn.Name = "locationBtn";
            this.locationBtn.Size = new System.Drawing.Size(210, 50);
            this.locationBtn.TabIndex = 0;
            this.locationBtn.Text = "Locate .exe";
            this.locationBtn.UseVisualStyleBackColor = true;
            this.locationBtn.Click += new System.EventHandler(this.ClickLocationButton);
            // 
            // validationSection
            // 
            this.validationSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validationSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.validationSection.Controls.Add(this.toolsBtn);
            this.validationSection.Controls.Add(this.locationBtn);
            this.validationSection.Location = new System.Drawing.Point(0, 120);
            this.validationSection.Name = "validationSection";
            this.validationSection.Size = new System.Drawing.Size(1150, 741);
            this.validationSection.TabIndex = 4;
            // 
            // toolsBtn
            // 
            this.toolsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolsBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsBtn.Location = new System.Drawing.Point(470, 380);
            this.toolsBtn.Name = "toolsBtn";
            this.toolsBtn.Size = new System.Drawing.Size(210, 50);
            this.toolsBtn.TabIndex = 1;
            this.toolsBtn.Text = "Install modding tools";
            this.toolsBtn.UseVisualStyleBackColor = true;
            this.toolsBtn.Click += new System.EventHandler(this.ClickToolsButton);
            // 
            // blasLocDialog
            // 
            this.blasLocDialog.FileName = ".exe";
            this.blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            this.blasLocDialog.Title = "Choose .exe location";
            // 
            // mainSection
            // 
            this.mainSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSection.BackColor = System.Drawing.Color.White;
            this.mainSection.Controls.Add(this.validationSection);
            this.mainSection.Controls.Add(this.titleSectionOuter);
            this.mainSection.Controls.Add(this.blas1modSection);
            this.mainSection.Controls.Add(this.blas1skinSection);
            this.mainSection.Controls.Add(this.blas2modSection);
            this.mainSection.Location = new System.Drawing.Point(250, 0);
            this.mainSection.Name = "mainSection";
            this.mainSection.Size = new System.Drawing.Size(1150, 900);
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
            this.titleSectionOuter.Size = new System.Drawing.Size(1150, 120);
            this.titleSectionOuter.TabIndex = 9;
            // 
            // titleSectionInner
            // 
            this.titleSectionInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleSectionInner.BackColor = System.Drawing.Color.Maroon;
            this.titleSectionInner.BackgroundImage = global::BlasModInstaller.Properties.Resources.background1;
            this.titleSectionInner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.titleSectionInner.Controls.Add(this.warningSectionOuter);
            this.titleSectionInner.Controls.Add(this.titleLabel);
            this.titleSectionInner.Location = new System.Drawing.Point(0, 0);
            this.titleSectionInner.Name = "titleSectionInner";
            this.titleSectionInner.Size = new System.Drawing.Size(1150, 118);
            this.titleSectionInner.TabIndex = 1;
            // 
            // warningSectionOuter
            // 
            this.warningSectionOuter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.warningSectionOuter.BackColor = System.Drawing.Color.Red;
            this.warningSectionOuter.Controls.Add(this.warningSectionInner);
            this.warningSectionOuter.Location = new System.Drawing.Point(896, 19);
            this.warningSectionOuter.Name = "warningSectionOuter";
            this.warningSectionOuter.Size = new System.Drawing.Size(220, 80);
            this.warningSectionOuter.TabIndex = 6;
            this.warningSectionOuter.Visible = false;
            // 
            // warningSectionInner
            // 
            this.warningSectionInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningSectionInner.BackColor = System.Drawing.Color.Black;
            this.warningSectionInner.Controls.Add(this.warningText);
            this.warningSectionInner.Controls.Add(this.warningImage);
            this.warningSectionInner.Location = new System.Drawing.Point(2, 2);
            this.warningSectionInner.Name = "warningSectionInner";
            this.warningSectionInner.Size = new System.Drawing.Size(216, 76);
            this.warningSectionInner.TabIndex = 0;
            // 
            // warningText
            // 
            this.warningText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.warningText.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.warningText.LinkArea = new System.Windows.Forms.LinkArea(57, 8);
            this.warningText.LinkColor = System.Drawing.Color.Cyan;
            this.warningText.Location = new System.Drawing.Point(52, 10);
            this.warningText.Name = "warningText";
            this.warningText.Size = new System.Drawing.Size(160, 56);
            this.warningText.TabIndex = 3;
            this.warningText.TabStop = true;
            this.warningText.Text = "A new update is available for the mod installer.  Please download it now.";
            this.warningText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.warningText.UseCompatibleTextRendering = true;
            this.warningText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickInstallerUpdateLink);
            // 
            // warningImage
            // 
            this.warningImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.warningImage.BackColor = System.Drawing.Color.Black;
            this.warningImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.warningImage.Image = global::BlasModInstaller.Properties.Resources.warning;
            this.warningImage.Location = new System.Drawing.Point(10, 20);
            this.warningImage.Name = "warningImage";
            this.warningImage.Size = new System.Drawing.Size(36, 36);
            this.warningImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.warningImage.TabIndex = 4;
            this.warningImage.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Trebuchet MS", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1150, 118);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Blasphemous Mods";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blas1skinSection
            // 
            this.blas1skinSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1skinSection.AutoScroll = true;
            this.blas1skinSection.AutoScrollMargin = new System.Drawing.Size(0, 15);
            this.blas1skinSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.blas1skinSection.Controls.Add(this.blas1skinScroll);
            this.blas1skinSection.Location = new System.Drawing.Point(0, 120);
            this.blas1skinSection.Name = "blas1skinSection";
            this.blas1skinSection.Size = new System.Drawing.Size(1150, 741);
            this.blas1skinSection.TabIndex = 5;
            this.blas1skinSection.Visible = false;
            // 
            // blas1skinScroll
            // 
            this.blas1skinScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas1skinScroll.Location = new System.Drawing.Point(1114, 15);
            this.blas1skinScroll.Name = "blas1skinScroll";
            this.blas1skinScroll.Size = new System.Drawing.Size(20, 680);
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
            this.blas2modSection.Controls.Add(this.blas2modScroll);
            this.blas2modSection.Location = new System.Drawing.Point(0, 120);
            this.blas2modSection.Name = "blas2modSection";
            this.blas2modSection.Size = new System.Drawing.Size(1150, 741);
            this.blas2modSection.TabIndex = 4;
            this.blas2modSection.Visible = false;
            // 
            // blas2modScroll
            // 
            this.blas2modScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blas2modScroll.Location = new System.Drawing.Point(1114, 15);
            this.blas2modScroll.Name = "blas2modScroll";
            this.blas2modScroll.Size = new System.Drawing.Size(20, 680);
            this.blas2modScroll.TabIndex = 2;
            this.blas2modScroll.Visible = false;
            // 
            // sideSectionInner
            // 
            this.sideSectionInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sideSectionInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sideSectionInner.Controls.Add(this.divider2);
            this.sideSectionInner.Controls.Add(this.divider1);
            this.sideSectionInner.Controls.Add(this.disableBtn);
            this.sideSectionInner.Controls.Add(this.enableBtn);
            this.sideSectionInner.Controls.Add(this.uninstallBtn);
            this.sideSectionInner.Controls.Add(this.installBtn);
            this.sideSectionInner.Controls.Add(this.sortSection);
            this.sideSectionInner.Controls.Add(this.debugLog);
            this.sideSectionInner.Controls.Add(this.blas2modsBtn);
            this.sideSectionInner.Controls.Add(this.blas1skinsBtn);
            this.sideSectionInner.Controls.Add(this.blas1modsBtn);
            this.sideSectionInner.Location = new System.Drawing.Point(0, 0);
            this.sideSectionInner.Name = "sideSectionInner";
            this.sideSectionInner.Size = new System.Drawing.Size(248, 900);
            this.sideSectionInner.TabIndex = 8;
            // 
            // divider2
            // 
            this.divider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.divider2.Location = new System.Drawing.Point(44, 455);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(160, 1);
            this.divider2.TabIndex = 22;
            // 
            // divider1
            // 
            this.divider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.divider1.Location = new System.Drawing.Point(44, 250);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(160, 1);
            this.divider1.TabIndex = 21;
            // 
            // disableBtn
            // 
            this.disableBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.disableBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.disableBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.disableBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.disableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.disableBtn.Location = new System.Drawing.Point(15, 625);
            this.disableBtn.Name = "disableBtn";
            this.disableBtn.Size = new System.Drawing.Size(220, 35);
            this.disableBtn.TabIndex = 7;
            this.disableBtn.Text = "Disable all";
            this.disableBtn.UseVisualStyleBackColor = false;
            this.disableBtn.Click += new System.EventHandler(this.ClickedDisableAll);
            this.disableBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.disableBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.disableBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // enableBtn
            // 
            this.enableBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.enableBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.enableBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.enableBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.enableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enableBtn.Location = new System.Drawing.Point(15, 580);
            this.enableBtn.Name = "enableBtn";
            this.enableBtn.Size = new System.Drawing.Size(220, 35);
            this.enableBtn.TabIndex = 6;
            this.enableBtn.Text = "Enable all";
            this.enableBtn.UseVisualStyleBackColor = false;
            this.enableBtn.Click += new System.EventHandler(this.ClickedEnableAll);
            this.enableBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.enableBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.enableBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // uninstallBtn
            // 
            this.uninstallBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uninstallBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uninstallBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uninstallBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.uninstallBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstallBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uninstallBtn.Location = new System.Drawing.Point(15, 535);
            this.uninstallBtn.Name = "uninstallBtn";
            this.uninstallBtn.Size = new System.Drawing.Size(220, 35);
            this.uninstallBtn.TabIndex = 5;
            this.uninstallBtn.Text = "Uninstall all";
            this.uninstallBtn.UseVisualStyleBackColor = false;
            this.uninstallBtn.Click += new System.EventHandler(this.ClickedUninstallAll);
            this.uninstallBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.uninstallBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.uninstallBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // installBtn
            // 
            this.installBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.installBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.installBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.installBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.installBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.installBtn.Location = new System.Drawing.Point(15, 490);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(220, 35);
            this.installBtn.TabIndex = 4;
            this.installBtn.Text = "Install all";
            this.installBtn.UseVisualStyleBackColor = false;
            this.installBtn.Click += new System.EventHandler(this.ClickedInstallAll);
            this.installBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.installBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.installBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // sortSection
            // 
            this.sortSection.Controls.Add(this.sortByText);
            this.sortSection.Controls.Add(this.sortByName);
            this.sortSection.Controls.Add(this.sortByAuthor);
            this.sortSection.Controls.Add(this.sortByLatestRelease);
            this.sortSection.Controls.Add(this.sortByInitialRelease);
            this.sortSection.Location = new System.Drawing.Point(57, 290);
            this.sortSection.Name = "sortSection";
            this.sortSection.Size = new System.Drawing.Size(147, 141);
            this.sortSection.TabIndex = 13;
            // 
            // sortByText
            // 
            this.sortByText.AutoSize = true;
            this.sortByText.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortByText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByText.Location = new System.Drawing.Point(0, 0);
            this.sortByText.Name = "sortByText";
            this.sortByText.Size = new System.Drawing.Size(67, 20);
            this.sortByText.TabIndex = 11;
            this.sortByText.Text = "Sort by:";
            // 
            // sortByName
            // 
            this.sortByName.AutoSize = true;
            this.sortByName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByName.Location = new System.Drawing.Point(4, 30);
            this.sortByName.Name = "sortByName";
            this.sortByName.Size = new System.Drawing.Size(52, 20);
            this.sortByName.TabIndex = 10;
            this.sortByName.TabStop = true;
            this.sortByName.Text = "Name";
            this.sortByName.UseVisualStyleBackColor = true;
            this.sortByName.Click += new System.EventHandler(this.ClickedSortByName);
            // 
            // sortByAuthor
            // 
            this.sortByAuthor.AutoSize = true;
            this.sortByAuthor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByAuthor.Location = new System.Drawing.Point(4, 55);
            this.sortByAuthor.Name = "sortByAuthor";
            this.sortByAuthor.Size = new System.Drawing.Size(59, 20);
            this.sortByAuthor.TabIndex = 11;
            this.sortByAuthor.TabStop = true;
            this.sortByAuthor.Text = "Author";
            this.sortByAuthor.UseVisualStyleBackColor = true;
            this.sortByAuthor.Click += new System.EventHandler(this.ClickedSortByAuthor);
            // 
            // sortByLatestRelease
            // 
            this.sortByLatestRelease.AutoSize = true;
            this.sortByLatestRelease.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByLatestRelease.Location = new System.Drawing.Point(4, 105);
            this.sortByLatestRelease.Name = "sortByLatestRelease";
            this.sortByLatestRelease.Size = new System.Drawing.Size(97, 20);
            this.sortByLatestRelease.TabIndex = 9;
            this.sortByLatestRelease.TabStop = true;
            this.sortByLatestRelease.Text = "Latest release";
            this.sortByLatestRelease.UseVisualStyleBackColor = true;
            this.sortByLatestRelease.Click += new System.EventHandler(this.ClickedSortByLatestRelease);
            // 
            // sortByInitialRelease
            // 
            this.sortByInitialRelease.AutoSize = true;
            this.sortByInitialRelease.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByInitialRelease.Location = new System.Drawing.Point(4, 80);
            this.sortByInitialRelease.Name = "sortByInitialRelease";
            this.sortByInitialRelease.Size = new System.Drawing.Size(93, 20);
            this.sortByInitialRelease.TabIndex = 8;
            this.sortByInitialRelease.TabStop = true;
            this.sortByInitialRelease.Text = "Initial release";
            this.sortByInitialRelease.UseVisualStyleBackColor = true;
            this.sortByInitialRelease.Click += new System.EventHandler(this.ClickedSortByInitialRelease);
            // 
            // debugLog
            // 
            this.debugLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.debugLog.ForeColor = System.Drawing.SystemColors.Menu;
            this.debugLog.Location = new System.Drawing.Point(15, 665);
            this.debugLog.Multiline = true;
            this.debugLog.Name = "debugLog";
            this.debugLog.ReadOnly = true;
            this.debugLog.Size = new System.Drawing.Size(220, 183);
            this.debugLog.TabIndex = 0;
            this.debugLog.Visible = false;
            // 
            // blas2modsBtn
            // 
            this.blas2modsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas2modsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas2modsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas2modsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas2modsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blas2modsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas2modsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blas2modsBtn.Location = new System.Drawing.Point(15, 165);
            this.blas2modsBtn.Name = "blas2modsBtn";
            this.blas2modsBtn.Size = new System.Drawing.Size(220, 35);
            this.blas2modsBtn.TabIndex = 3;
            this.blas2modsBtn.Text = "Blasphemous II Mods";
            this.blas2modsBtn.UseVisualStyleBackColor = false;
            this.blas2modsBtn.Click += new System.EventHandler(this.ClickedBlas2Mods);
            this.blas2modsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.blas2modsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.blas2modsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // blas1skinsBtn
            // 
            this.blas1skinsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1skinsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1skinsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1skinsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1skinsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blas1skinsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas1skinsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blas1skinsBtn.Location = new System.Drawing.Point(15, 120);
            this.blas1skinsBtn.Name = "blas1skinsBtn";
            this.blas1skinsBtn.Size = new System.Drawing.Size(220, 35);
            this.blas1skinsBtn.TabIndex = 2;
            this.blas1skinsBtn.Text = "Blasphemous Skins";
            this.blas1skinsBtn.UseVisualStyleBackColor = false;
            this.blas1skinsBtn.Click += new System.EventHandler(this.ClickedBlas1Skins);
            this.blas1skinsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.blas1skinsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.blas1skinsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // blas1modsBtn
            // 
            this.blas1modsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1modsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1modsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1modsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.blas1modsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blas1modsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas1modsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blas1modsBtn.Location = new System.Drawing.Point(15, 75);
            this.blas1modsBtn.Name = "blas1modsBtn";
            this.blas1modsBtn.Size = new System.Drawing.Size(220, 35);
            this.blas1modsBtn.TabIndex = 1;
            this.blas1modsBtn.Text = "Blasphemous Mods";
            this.blas1modsBtn.UseVisualStyleBackColor = false;
            this.blas1modsBtn.Click += new System.EventHandler(this.ClickedBlas1Mods);
            this.blas1modsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.blas1modsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.blas1modsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // sideSectionOuter
            // 
            this.sideSectionOuter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sideSectionOuter.BackColor = System.Drawing.Color.Black;
            this.sideSectionOuter.Controls.Add(this.sideSectionInner);
            this.sideSectionOuter.Location = new System.Drawing.Point(0, 0);
            this.sideSectionOuter.Name = "sideSectionOuter";
            this.sideSectionOuter.Size = new System.Drawing.Size(250, 900);
            this.sideSectionOuter.TabIndex = 9;
            // 
            // UIHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.mainSection);
            this.Controls.Add(this.sideSectionOuter);
            this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "UIHandler";
            this.Text = "Blasphemous Mod Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
            this.Load += new System.EventHandler(this.OnFormOpen);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.blas1modSection.ResumeLayout(false);
            this.validationSection.ResumeLayout(false);
            this.mainSection.ResumeLayout(false);
            this.titleSectionOuter.ResumeLayout(false);
            this.titleSectionInner.ResumeLayout(false);
            this.warningSectionOuter.ResumeLayout(false);
            this.warningSectionInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningImage)).EndInit();
            this.blas1skinSection.ResumeLayout(false);
            this.blas2modSection.ResumeLayout(false);
            this.sideSectionInner.ResumeLayout(false);
            this.sideSectionInner.PerformLayout();
            this.sortSection.ResumeLayout(false);
            this.sortSection.PerformLayout();
            this.sideSectionOuter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.VScrollBar blas1modScroll;
        private System.Windows.Forms.Panel blas1modSection;
        private System.Windows.Forms.Button locationBtn;
        private System.Windows.Forms.OpenFileDialog blasLocDialog;
        private System.Windows.Forms.Panel validationSection;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainSection;
        private System.Windows.Forms.Panel sideSectionInner;
        private System.Windows.Forms.Panel titleSectionOuter;
        private System.Windows.Forms.Button blas1modsBtn;
        private System.Windows.Forms.Button blas1skinsBtn;
        private System.Windows.Forms.Button blas2modsBtn;
        private System.Windows.Forms.TextBox debugLog;
        private System.Windows.Forms.Panel blas2modSection;
        private System.Windows.Forms.VScrollBar blas2modScroll;
        private System.Windows.Forms.PictureBox warningImage;
        private System.Windows.Forms.Panel warningSectionOuter;
        private System.Windows.Forms.Panel warningSectionInner;
        private System.Windows.Forms.Panel blas1skinSection;
        private System.Windows.Forms.VScrollBar blas1skinScroll;
        private System.Windows.Forms.Panel titleSectionInner;
        private System.Windows.Forms.Panel sideSectionOuter;
        private System.Windows.Forms.LinkLabel warningText;
        private System.Windows.Forms.RadioButton sortByLatestRelease;
        private System.Windows.Forms.RadioButton sortByInitialRelease;
        private System.Windows.Forms.RadioButton sortByAuthor;
        private System.Windows.Forms.RadioButton sortByName;
        private System.Windows.Forms.Label sortByText;
        private System.Windows.Forms.Panel sortSection;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.Button disableBtn;
        private System.Windows.Forms.Button enableBtn;
        private System.Windows.Forms.Button uninstallBtn;
        private System.Windows.Forms.Panel divider1;
        private System.Windows.Forms.Panel divider2;
        private System.Windows.Forms.Button toolsBtn;
    }
}

