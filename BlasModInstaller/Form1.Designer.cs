
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
            this.mainSection = new System.Windows.Forms.Panel();
            this.titleSectionOuter = new System.Windows.Forms.Panel();
            this.titleSectionInner = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.blas1skinSection = new System.Windows.Forms.Panel();
            this.blas1skinScroll = new System.Windows.Forms.VScrollBar();
            this.blas2modSection = new System.Windows.Forms.Panel();
            this.blas2modText = new System.Windows.Forms.Label();
            this.blas2modScroll = new System.Windows.Forms.VScrollBar();
            this.sideSectionInner = new System.Windows.Forms.Panel();
            this.disableAllBtn = new System.Windows.Forms.Button();
            this.enableAllBtn = new System.Windows.Forms.Button();
            this.uninstallAllBtn = new System.Windows.Forms.Button();
            this.sortSection = new System.Windows.Forms.Panel();
            this.sortByText = new System.Windows.Forms.Label();
            this.sortByName = new System.Windows.Forms.RadioButton();
            this.sortByAuthor = new System.Windows.Forms.RadioButton();
            this.sortByMostRecent = new System.Windows.Forms.RadioButton();
            this.sortByInitialRelease = new System.Windows.Forms.RadioButton();
            this.installAllBtn = new System.Windows.Forms.Button();
            this.gearImage = new System.Windows.Forms.PictureBox();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.warningSectionOuter = new System.Windows.Forms.Panel();
            this.warningSectionInner = new System.Windows.Forms.Panel();
            this.warningText = new System.Windows.Forms.LinkLabel();
            this.warningImage = new System.Windows.Forms.PictureBox();
            this.debugLog = new System.Windows.Forms.TextBox();
            this.blas2modsBtn = new System.Windows.Forms.Button();
            this.blas1skinsBtn = new System.Windows.Forms.Button();
            this.blas1modsBtn = new System.Windows.Forms.Button();
            this.sideSectionOuter = new System.Windows.Forms.Panel();
            this.blas1modSection.SuspendLayout();
            this.blas1locationSection.SuspendLayout();
            this.mainSection.SuspendLayout();
            this.titleSectionOuter.SuspendLayout();
            this.titleSectionInner.SuspendLayout();
            this.blas1skinSection.SuspendLayout();
            this.blas2modSection.SuspendLayout();
            this.sideSectionInner.SuspendLayout();
            this.sortSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gearImage)).BeginInit();
            this.warningSectionOuter.SuspendLayout();
            this.warningSectionInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningImage)).BeginInit();
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
            // 
            // blasLocButton
            // 
            this.blasLocButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blasLocButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocButton.Location = new System.Drawing.Point(475, 345);
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
            this.blas1locationSection.Location = new System.Drawing.Point(0, 120);
            this.blas1locationSection.Name = "blas1locationSection";
            this.blas1locationSection.Size = new System.Drawing.Size(1150, 741);
            this.blas1locationSection.TabIndex = 4;
            // 
            // blasLocDialog
            // 
            this.blasLocDialog.FileName = "Blasphemous.exe";
            this.blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            this.blasLocDialog.Title = "Choose Blasphemous.exe location";
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
            this.titleSectionInner.Controls.Add(this.titleLabel);
            this.titleSectionInner.Location = new System.Drawing.Point(0, 0);
            this.titleSectionInner.Name = "titleSectionInner";
            this.titleSectionInner.Size = new System.Drawing.Size(1150, 118);
            this.titleSectionInner.TabIndex = 1;
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
            this.blas2modSection.Controls.Add(this.blas2modText);
            this.blas2modSection.Controls.Add(this.blas2modScroll);
            this.blas2modSection.Location = new System.Drawing.Point(0, 120);
            this.blas2modSection.Name = "blas2modSection";
            this.blas2modSection.Size = new System.Drawing.Size(1150, 741);
            this.blas2modSection.TabIndex = 4;
            // 
            // blas2modText
            // 
            this.blas2modText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blas2modText.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blas2modText.Location = new System.Drawing.Point(0, 0);
            this.blas2modText.Name = "blas2modText";
            this.blas2modText.Size = new System.Drawing.Size(1150, 741);
            this.blas2modText.TabIndex = 3;
            this.blas2modText.Text = "There is nothing here yet...";
            this.blas2modText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.sideSectionInner.Controls.Add(this.disableAllBtn);
            this.sideSectionInner.Controls.Add(this.enableAllBtn);
            this.sideSectionInner.Controls.Add(this.uninstallAllBtn);
            this.sideSectionInner.Controls.Add(this.sortSection);
            this.sideSectionInner.Controls.Add(this.installAllBtn);
            this.sideSectionInner.Controls.Add(this.gearImage);
            this.sideSectionInner.Controls.Add(this.settingsBtn);
            this.sideSectionInner.Controls.Add(this.warningSectionOuter);
            this.sideSectionInner.Controls.Add(this.debugLog);
            this.sideSectionInner.Controls.Add(this.blas2modsBtn);
            this.sideSectionInner.Controls.Add(this.blas1skinsBtn);
            this.sideSectionInner.Controls.Add(this.blas1modsBtn);
            this.sideSectionInner.Location = new System.Drawing.Point(0, 0);
            this.sideSectionInner.Name = "sideSectionInner";
            this.sideSectionInner.Size = new System.Drawing.Size(248, 900);
            this.sideSectionInner.TabIndex = 8;
            // 
            // disableAllBtn
            // 
            this.disableAllBtn.BackColor = System.Drawing.Color.Maroon;
            this.disableAllBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.disableAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.disableAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.disableAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableAllBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableAllBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.disableAllBtn.Location = new System.Drawing.Point(44, 555);
            this.disableAllBtn.Name = "disableAllBtn";
            this.disableAllBtn.Size = new System.Drawing.Size(160, 25);
            this.disableAllBtn.TabIndex = 16;
            this.disableAllBtn.TabStop = false;
            this.disableAllBtn.Text = "Disable all";
            this.disableAllBtn.UseVisualStyleBackColor = false;
            this.disableAllBtn.Click += new System.EventHandler(this.ClickedDisableAll);
            this.disableAllBtn.MouseLeave += new System.EventHandler(this.RemoveButtonFocus);
            this.disableAllBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // enableAllBtn
            // 
            this.enableAllBtn.BackColor = System.Drawing.Color.Navy;
            this.enableAllBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.enableAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.enableAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.enableAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableAllBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableAllBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enableAllBtn.Location = new System.Drawing.Point(44, 520);
            this.enableAllBtn.Name = "enableAllBtn";
            this.enableAllBtn.Size = new System.Drawing.Size(160, 25);
            this.enableAllBtn.TabIndex = 15;
            this.enableAllBtn.TabStop = false;
            this.enableAllBtn.Text = "Enable all";
            this.enableAllBtn.UseVisualStyleBackColor = false;
            this.enableAllBtn.Click += new System.EventHandler(this.ClickedEnableAll);
            this.enableAllBtn.MouseLeave += new System.EventHandler(this.RemoveButtonFocus);
            this.enableAllBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // uninstallAllBtn
            // 
            this.uninstallAllBtn.BackColor = System.Drawing.Color.Maroon;
            this.uninstallAllBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.uninstallAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.uninstallAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.uninstallAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallAllBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstallAllBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uninstallAllBtn.Location = new System.Drawing.Point(44, 485);
            this.uninstallAllBtn.Name = "uninstallAllBtn";
            this.uninstallAllBtn.Size = new System.Drawing.Size(160, 25);
            this.uninstallAllBtn.TabIndex = 14;
            this.uninstallAllBtn.TabStop = false;
            this.uninstallAllBtn.Text = "Uninstall all";
            this.uninstallAllBtn.UseVisualStyleBackColor = false;
            this.uninstallAllBtn.Click += new System.EventHandler(this.ClickedUninstallAll);
            this.uninstallAllBtn.MouseLeave += new System.EventHandler(this.RemoveButtonFocus);
            this.uninstallAllBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // sortSection
            // 
            this.sortSection.Controls.Add(this.sortByText);
            this.sortSection.Controls.Add(this.sortByName);
            this.sortSection.Controls.Add(this.sortByAuthor);
            this.sortSection.Controls.Add(this.sortByMostRecent);
            this.sortSection.Controls.Add(this.sortByInitialRelease);
            this.sortSection.Location = new System.Drawing.Point(44, 290);
            this.sortSection.Name = "sortSection";
            this.sortSection.Size = new System.Drawing.Size(160, 141);
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
            this.sortByName.Location = new System.Drawing.Point(4, 80);
            this.sortByName.Name = "sortByName";
            this.sortByName.Size = new System.Drawing.Size(53, 20);
            this.sortByName.TabIndex = 3;
            this.sortByName.TabStop = true;
            this.sortByName.Text = "Name";
            this.sortByName.UseVisualStyleBackColor = true;
            // 
            // sortByAuthor
            // 
            this.sortByAuthor.AutoSize = true;
            this.sortByAuthor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByAuthor.Location = new System.Drawing.Point(4, 105);
            this.sortByAuthor.Name = "sortByAuthor";
            this.sortByAuthor.Size = new System.Drawing.Size(60, 20);
            this.sortByAuthor.TabIndex = 8;
            this.sortByAuthor.TabStop = true;
            this.sortByAuthor.Text = "Author";
            this.sortByAuthor.UseVisualStyleBackColor = true;
            // 
            // sortByMostRecent
            // 
            this.sortByMostRecent.AutoSize = true;
            this.sortByMostRecent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByMostRecent.Location = new System.Drawing.Point(4, 55);
            this.sortByMostRecent.Name = "sortByMostRecent";
            this.sortByMostRecent.Size = new System.Drawing.Size(87, 20);
            this.sortByMostRecent.TabIndex = 10;
            this.sortByMostRecent.TabStop = true;
            this.sortByMostRecent.Text = "Most recent";
            this.sortByMostRecent.UseVisualStyleBackColor = true;
            // 
            // sortByInitialRelease
            // 
            this.sortByInitialRelease.AutoSize = true;
            this.sortByInitialRelease.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortByInitialRelease.Location = new System.Drawing.Point(4, 30);
            this.sortByInitialRelease.Name = "sortByInitialRelease";
            this.sortByInitialRelease.Size = new System.Drawing.Size(94, 20);
            this.sortByInitialRelease.TabIndex = 9;
            this.sortByInitialRelease.TabStop = true;
            this.sortByInitialRelease.Text = "Initial release";
            this.sortByInitialRelease.UseVisualStyleBackColor = true;
            // 
            // installAllBtn
            // 
            this.installAllBtn.BackColor = System.Drawing.Color.Navy;
            this.installAllBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.installAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.installAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.installAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installAllBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installAllBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.installAllBtn.Location = new System.Drawing.Point(44, 450);
            this.installAllBtn.Name = "installAllBtn";
            this.installAllBtn.Size = new System.Drawing.Size(160, 25);
            this.installAllBtn.TabIndex = 12;
            this.installAllBtn.TabStop = false;
            this.installAllBtn.Text = "Install all";
            this.installAllBtn.UseVisualStyleBackColor = false;
            this.installAllBtn.Click += new System.EventHandler(this.ClickedInstallAll);
            this.installAllBtn.MouseLeave += new System.EventHandler(this.RemoveButtonFocus);
            this.installAllBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // gearImage
            // 
            this.gearImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gearImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gearImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gearImage.Image = global::BlasModInstaller.Properties.Resources.gear;
            this.gearImage.Location = new System.Drawing.Point(68, 215);
            this.gearImage.Name = "gearImage";
            this.gearImage.Size = new System.Drawing.Size(25, 25);
            this.gearImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gearImage.TabIndex = 6;
            this.gearImage.TabStop = false;
            this.gearImage.Visible = false;
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.settingsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.settingsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.settingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingsBtn.Location = new System.Drawing.Point(15, 210);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(220, 35);
            this.settingsBtn.TabIndex = 7;
            this.settingsBtn.Text = "      Settings";
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Visible = false;
            this.settingsBtn.Click += new System.EventHandler(this.ClickedSettings);
            this.settingsBtn.MouseEnter += new System.EventHandler(this.ShowSideButtonBorder);
            this.settingsBtn.MouseLeave += new System.EventHandler(this.HideSideButtonBorder);
            this.settingsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RemoveButtonFocus);
            // 
            // warningSectionOuter
            // 
            this.warningSectionOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.warningSectionOuter.BackColor = System.Drawing.Color.White;
            this.warningSectionOuter.Controls.Add(this.warningSectionInner);
            this.warningSectionOuter.Location = new System.Drawing.Point(15, 765);
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
            this.warningSectionInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
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
            this.warningImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.warningImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.warningImage.Image = global::BlasModInstaller.Properties.Resources.warning;
            this.warningImage.Location = new System.Drawing.Point(10, 20);
            this.warningImage.Name = "warningImage";
            this.warningImage.Size = new System.Drawing.Size(36, 36);
            this.warningImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.warningImage.TabIndex = 4;
            this.warningImage.TabStop = false;
            // 
            // debugLog
            // 
            this.debugLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.debugLog.ForeColor = System.Drawing.SystemColors.Menu;
            this.debugLog.Location = new System.Drawing.Point(15, 643);
            this.debugLog.Multiline = true;
            this.debugLog.Name = "debugLog";
            this.debugLog.ReadOnly = true;
            this.debugLog.Size = new System.Drawing.Size(220, 292);
            this.debugLog.TabIndex = 0;
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
            this.blas2modsBtn.TabIndex = 2;
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
            this.blas1skinsBtn.TabIndex = 1;
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
            this.blas1modsBtn.TabIndex = 3;
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
            // MainForm
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
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blasphemous Mod Installer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.blas1modSection.ResumeLayout(false);
            this.blas1locationSection.ResumeLayout(false);
            this.mainSection.ResumeLayout(false);
            this.titleSectionOuter.ResumeLayout(false);
            this.titleSectionInner.ResumeLayout(false);
            this.blas1skinSection.ResumeLayout(false);
            this.blas2modSection.ResumeLayout(false);
            this.sideSectionInner.ResumeLayout(false);
            this.sideSectionInner.PerformLayout();
            this.sortSection.ResumeLayout(false);
            this.sortSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gearImage)).EndInit();
            this.warningSectionOuter.ResumeLayout(false);
            this.warningSectionInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningImage)).EndInit();
            this.sideSectionOuter.ResumeLayout(false);
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
        private System.Windows.Forms.Panel sideSectionInner;
        private System.Windows.Forms.Panel titleSectionOuter;
        private System.Windows.Forms.Button blas1modsBtn;
        private System.Windows.Forms.Button blas1skinsBtn;
        private System.Windows.Forms.Button blas2modsBtn;
        private System.Windows.Forms.TextBox debugLog;
        private System.Windows.Forms.Panel blas2modSection;
        private System.Windows.Forms.VScrollBar blas2modScroll;
        private System.Windows.Forms.Label blas2modText;
        private System.Windows.Forms.PictureBox warningImage;
        private System.Windows.Forms.Panel warningSectionOuter;
        private System.Windows.Forms.Panel warningSectionInner;
        private System.Windows.Forms.Panel blas1skinSection;
        private System.Windows.Forms.VScrollBar blas1skinScroll;
        private System.Windows.Forms.Panel titleSectionInner;
        private System.Windows.Forms.Panel sideSectionOuter;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.PictureBox gearImage;
        private System.Windows.Forms.LinkLabel warningText;
        private System.Windows.Forms.RadioButton sortByMostRecent;
        private System.Windows.Forms.RadioButton sortByInitialRelease;
        private System.Windows.Forms.RadioButton sortByAuthor;
        private System.Windows.Forms.RadioButton sortByName;
        private System.Windows.Forms.Label sortByText;
        private System.Windows.Forms.Button installAllBtn;
        private System.Windows.Forms.Panel sortSection;
        private System.Windows.Forms.Button uninstallAllBtn;
        private System.Windows.Forms.Button disableAllBtn;
        private System.Windows.Forms.Button enableAllBtn;
    }
}

