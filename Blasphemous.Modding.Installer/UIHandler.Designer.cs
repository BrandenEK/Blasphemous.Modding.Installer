
namespace Blasphemous.Modding.Installer
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
            blas1modScroll = new VScrollBar();
            blas1modSection = new Panel();
            locationBtn = new Button();
            validationSection = new Panel();
            toolsBtn = new Button();
            blasLocDialog = new OpenFileDialog();
            mainSection = new Panel();
            titleSectionOuter = new Panel();
            titleSectionInner = new Panel();
            warningSectionOuter = new Panel();
            warningSectionInner = new Panel();
            warningText = new LinkLabel();
            warningImage = new PictureBox();
            titleLabel = new Label();
            blas1skinSection = new Panel();
            blas1skinScroll = new VScrollBar();
            blas2modSection = new Panel();
            blas2modScroll = new VScrollBar();
            sideSectionInner = new Panel();
            changePathBtn = new Button();
            pageSection = new Panel();
            pageb1mBtn = new Button();
            pageb1sBtn = new Button();
            pageb2mBtn = new Button();
            detailsSectionOuter = new Panel();
            detailsSectionInner = new Panel();
            detailsVersion = new Label();
            detailsDescription = new Label();
            detailsName = new Label();
            divider3 = new Panel();
            divider2 = new Panel();
            divider1 = new Panel();
            sortSection = new Panel();
            sortByText = new Label();
            sortByName = new RadioButton();
            sortByAuthor = new RadioButton();
            sortByLatestRelease = new RadioButton();
            sortByInitialRelease = new RadioButton();
            allSection = new Panel();
            allInstallBtn = new Button();
            allEnableBtn = new Button();
            allUninstallBtn = new Button();
            allDisableBtn = new Button();
            sideSectionOuter = new Panel();
            blas1modSection.SuspendLayout();
            validationSection.SuspendLayout();
            mainSection.SuspendLayout();
            titleSectionOuter.SuspendLayout();
            titleSectionInner.SuspendLayout();
            warningSectionOuter.SuspendLayout();
            warningSectionInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)warningImage).BeginInit();
            blas1skinSection.SuspendLayout();
            blas2modSection.SuspendLayout();
            sideSectionInner.SuspendLayout();
            pageSection.SuspendLayout();
            detailsSectionOuter.SuspendLayout();
            detailsSectionInner.SuspendLayout();
            sortSection.SuspendLayout();
            allSection.SuspendLayout();
            sideSectionOuter.SuspendLayout();
            SuspendLayout();
            // 
            // blas1modScroll
            // 
            blas1modScroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            blas1modScroll.Location = new Point(1020, 15);
            blas1modScroll.Name = "blas1modScroll";
            blas1modScroll.Size = new Size(20, 310);
            blas1modScroll.TabIndex = 2;
            blas1modScroll.Visible = false;
            // 
            // blas1modSection
            // 
            blas1modSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            blas1modSection.AutoScroll = true;
            blas1modSection.AutoScrollMargin = new Size(0, 15);
            blas1modSection.BackColor = Color.FromArgb(52, 52, 52);
            blas1modSection.Controls.Add(blas1modScroll);
            blas1modSection.Location = new Point(0, 120);
            blas1modSection.Name = "blas1modSection";
            blas1modSection.Size = new Size(36, 388);
            blas1modSection.TabIndex = 3;
            blas1modSection.Visible = false;
            // 
            // locationBtn
            // 
            locationBtn.Anchor = AnchorStyles.None;
            locationBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            locationBtn.Location = new Point(413, 134);
            locationBtn.Name = "locationBtn";
            locationBtn.Size = new Size(210, 50);
            locationBtn.TabIndex = 0;
            locationBtn.Text = "Locate .exe";
            locationBtn.UseVisualStyleBackColor = true;
            locationBtn.Click += ClickLocationButton;
            // 
            // validationSection
            // 
            validationSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            validationSection.BackColor = Color.FromArgb(52, 52, 52);
            validationSection.Controls.Add(toolsBtn);
            validationSection.Controls.Add(locationBtn);
            validationSection.Location = new Point(0, 120);
            validationSection.Name = "validationSection";
            validationSection.Size = new Size(1036, 388);
            validationSection.TabIndex = 4;
            // 
            // toolsBtn
            // 
            toolsBtn.Anchor = AnchorStyles.None;
            toolsBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolsBtn.Location = new Point(413, 204);
            toolsBtn.Name = "toolsBtn";
            toolsBtn.Size = new Size(210, 50);
            toolsBtn.TabIndex = 1;
            toolsBtn.Text = "Install modding tools";
            toolsBtn.UseVisualStyleBackColor = true;
            toolsBtn.Click += ClickToolsButton;
            // 
            // blasLocDialog
            // 
            blasLocDialog.FileName = ".exe";
            blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            blasLocDialog.Title = "Choose .exe location";
            // 
            // mainSection
            // 
            mainSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainSection.BackColor = Color.White;
            mainSection.Controls.Add(validationSection);
            mainSection.Controls.Add(titleSectionOuter);
            mainSection.Controls.Add(blas1modSection);
            mainSection.Controls.Add(blas1skinSection);
            mainSection.Controls.Add(blas2modSection);
            mainSection.Location = new Point(250, 0);
            mainSection.Name = "mainSection";
            mainSection.Size = new Size(1100, 700);
            mainSection.TabIndex = 7;
            // 
            // titleSectionOuter
            // 
            titleSectionOuter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleSectionOuter.BackColor = Color.Black;
            titleSectionOuter.Controls.Add(titleSectionInner);
            titleSectionOuter.Location = new Point(0, 0);
            titleSectionOuter.Name = "titleSectionOuter";
            titleSectionOuter.Size = new Size(1100, 120);
            titleSectionOuter.TabIndex = 9;
            // 
            // titleSectionInner
            // 
            titleSectionInner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titleSectionInner.BackColor = Color.Maroon;
            titleSectionInner.BackgroundImage = Properties.Resources.background1;
            titleSectionInner.BackgroundImageLayout = ImageLayout.Center;
            titleSectionInner.Controls.Add(warningSectionOuter);
            titleSectionInner.Controls.Add(titleLabel);
            titleSectionInner.Location = new Point(0, 0);
            titleSectionInner.Name = "titleSectionInner";
            titleSectionInner.Size = new Size(1100, 118);
            titleSectionInner.TabIndex = 1;
            // 
            // warningSectionOuter
            // 
            warningSectionOuter.Anchor = AnchorStyles.Right;
            warningSectionOuter.BackColor = Color.Red;
            warningSectionOuter.Controls.Add(warningSectionInner);
            warningSectionOuter.Location = new Point(850, 12);
            warningSectionOuter.Name = "warningSectionOuter";
            warningSectionOuter.Size = new Size(220, 80);
            warningSectionOuter.TabIndex = 6;
            warningSectionOuter.Visible = false;
            // 
            // warningSectionInner
            // 
            warningSectionInner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            warningSectionInner.BackColor = Color.Black;
            warningSectionInner.Controls.Add(warningText);
            warningSectionInner.Controls.Add(warningImage);
            warningSectionInner.Location = new Point(2, 2);
            warningSectionInner.Name = "warningSectionInner";
            warningSectionInner.Size = new Size(216, 76);
            warningSectionInner.TabIndex = 0;
            // 
            // warningText
            // 
            warningText.Anchor = AnchorStyles.Right;
            warningText.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            warningText.ForeColor = SystemColors.ButtonHighlight;
            warningText.LinkArea = new LinkArea(57, 8);
            warningText.LinkColor = Color.Cyan;
            warningText.Location = new Point(52, 10);
            warningText.Name = "warningText";
            warningText.Size = new Size(160, 56);
            warningText.TabIndex = 3;
            warningText.TabStop = true;
            warningText.Text = "A new update is available for the mod installer.  Please download it now.";
            warningText.TextAlign = ContentAlignment.MiddleLeft;
            warningText.UseCompatibleTextRendering = true;
            warningText.LinkClicked += ClickInstallerUpdateLink;
            // 
            // warningImage
            // 
            warningImage.Anchor = AnchorStyles.Left;
            warningImage.BackColor = Color.Black;
            warningImage.BackgroundImageLayout = ImageLayout.Stretch;
            warningImage.Image = Properties.Resources.warning;
            warningImage.Location = new Point(10, 20);
            warningImage.Name = "warningImage";
            warningImage.Size = new Size(36, 36);
            warningImage.SizeMode = PictureBoxSizeMode.StretchImage;
            warningImage.TabIndex = 4;
            warningImage.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Trebuchet MS", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1100, 118);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Blasphemous Mods";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // blas1skinSection
            // 
            blas1skinSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            blas1skinSection.AutoScroll = true;
            blas1skinSection.AutoScrollMargin = new Size(0, 15);
            blas1skinSection.BackColor = Color.FromArgb(52, 52, 52);
            blas1skinSection.Controls.Add(blas1skinScroll);
            blas1skinSection.Location = new Point(0, 120);
            blas1skinSection.Name = "blas1skinSection";
            blas1skinSection.Size = new Size(1036, 388);
            blas1skinSection.TabIndex = 5;
            blas1skinSection.Visible = false;
            // 
            // blas1skinScroll
            // 
            blas1skinScroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            blas1skinScroll.Location = new Point(1000, 15);
            blas1skinScroll.Name = "blas1skinScroll";
            blas1skinScroll.Size = new Size(20, 327);
            blas1skinScroll.TabIndex = 2;
            blas1skinScroll.Visible = false;
            // 
            // blas2modSection
            // 
            blas2modSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            blas2modSection.AutoScroll = true;
            blas2modSection.AutoScrollMargin = new Size(0, 15);
            blas2modSection.BackColor = Color.FromArgb(52, 52, 52);
            blas2modSection.Controls.Add(blas2modScroll);
            blas2modSection.Location = new Point(0, 120);
            blas2modSection.Name = "blas2modSection";
            blas2modSection.Size = new Size(1036, 388);
            blas2modSection.TabIndex = 4;
            blas2modSection.Visible = false;
            // 
            // blas2modScroll
            // 
            blas2modScroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            blas2modScroll.Location = new Point(1000, 15);
            blas2modScroll.Name = "blas2modScroll";
            blas2modScroll.Size = new Size(20, 327);
            blas2modScroll.TabIndex = 2;
            blas2modScroll.Visible = false;
            // 
            // sideSectionInner
            // 
            sideSectionInner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sideSectionInner.BackColor = Color.FromArgb(30, 30, 30);
            sideSectionInner.Controls.Add(changePathBtn);
            sideSectionInner.Controls.Add(pageSection);
            sideSectionInner.Controls.Add(detailsSectionOuter);
            sideSectionInner.Controls.Add(divider3);
            sideSectionInner.Controls.Add(divider2);
            sideSectionInner.Controls.Add(divider1);
            sideSectionInner.Controls.Add(sortSection);
            sideSectionInner.Controls.Add(allSection);
            sideSectionInner.Location = new Point(0, 0);
            sideSectionInner.Name = "sideSectionInner";
            sideSectionInner.Size = new Size(248, 750);
            sideSectionInner.TabIndex = 8;
            // 
            // changePathBtn
            // 
            changePathBtn.Anchor = AnchorStyles.Bottom;
            changePathBtn.BackColor = Color.FromArgb(30, 30, 30);
            changePathBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            changePathBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            changePathBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            changePathBtn.FlatStyle = FlatStyle.Flat;
            changePathBtn.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            changePathBtn.ForeColor = SystemColors.ButtonHighlight;
            changePathBtn.Location = new Point(15, 700);
            changePathBtn.Name = "changePathBtn";
            changePathBtn.Size = new Size(220, 30);
            changePathBtn.TabIndex = 8;
            changePathBtn.Text = "Change exe location";
            changePathBtn.UseVisualStyleBackColor = false;
            changePathBtn.Click += ClickedChangePath;
            changePathBtn.MouseEnter += ShowSideButtonBorder;
            changePathBtn.MouseLeave += HideSideButtonBorder;
            changePathBtn.MouseUp += RemoveButtonFocus;
            // 
            // pageSection
            // 
            pageSection.Controls.Add(pageb1mBtn);
            pageSection.Controls.Add(pageb1sBtn);
            pageSection.Controls.Add(pageb2mBtn);
            pageSection.Location = new Point(15, 15);
            pageSection.Name = "pageSection";
            pageSection.Size = new Size(220, 235);
            pageSection.TabIndex = 14;
            // 
            // pageb1mBtn
            // 
            pageb1mBtn.BackColor = Color.FromArgb(30, 30, 30);
            pageb1mBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            pageb1mBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            pageb1mBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            pageb1mBtn.FlatStyle = FlatStyle.Flat;
            pageb1mBtn.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            pageb1mBtn.ForeColor = SystemColors.ButtonHighlight;
            pageb1mBtn.Location = new Point(0, 60);
            pageb1mBtn.Name = "pageb1mBtn";
            pageb1mBtn.Size = new Size(220, 35);
            pageb1mBtn.TabIndex = 1;
            pageb1mBtn.Text = "Blasphemous Mods";
            pageb1mBtn.UseVisualStyleBackColor = false;
            pageb1mBtn.Click += ClickedBlas1Mods;
            pageb1mBtn.MouseEnter += ShowSideButtonBorder;
            pageb1mBtn.MouseLeave += HideSideButtonBorder;
            pageb1mBtn.MouseUp += RemoveButtonFocus;
            // 
            // pageb1sBtn
            // 
            pageb1sBtn.BackColor = Color.FromArgb(30, 30, 30);
            pageb1sBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            pageb1sBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            pageb1sBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            pageb1sBtn.FlatStyle = FlatStyle.Flat;
            pageb1sBtn.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            pageb1sBtn.ForeColor = SystemColors.ButtonHighlight;
            pageb1sBtn.Location = new Point(0, 105);
            pageb1sBtn.Name = "pageb1sBtn";
            pageb1sBtn.Size = new Size(220, 35);
            pageb1sBtn.TabIndex = 2;
            pageb1sBtn.Text = "Blasphemous Skins";
            pageb1sBtn.UseVisualStyleBackColor = false;
            pageb1sBtn.Click += ClickedBlas1Skins;
            pageb1sBtn.MouseEnter += ShowSideButtonBorder;
            pageb1sBtn.MouseLeave += HideSideButtonBorder;
            pageb1sBtn.MouseUp += RemoveButtonFocus;
            // 
            // pageb2mBtn
            // 
            pageb2mBtn.BackColor = Color.FromArgb(30, 30, 30);
            pageb2mBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            pageb2mBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            pageb2mBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            pageb2mBtn.FlatStyle = FlatStyle.Flat;
            pageb2mBtn.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            pageb2mBtn.ForeColor = SystemColors.ButtonHighlight;
            pageb2mBtn.Location = new Point(0, 150);
            pageb2mBtn.Name = "pageb2mBtn";
            pageb2mBtn.Size = new Size(220, 35);
            pageb2mBtn.TabIndex = 3;
            pageb2mBtn.Text = "Blasphemous II Mods";
            pageb2mBtn.UseVisualStyleBackColor = false;
            pageb2mBtn.Click += ClickedBlas2Mods;
            pageb2mBtn.MouseEnter += ShowSideButtonBorder;
            pageb2mBtn.MouseLeave += HideSideButtonBorder;
            pageb2mBtn.MouseUp += RemoveButtonFocus;
            // 
            // detailsSectionOuter
            // 
            detailsSectionOuter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            detailsSectionOuter.BackColor = Color.Black;
            detailsSectionOuter.Controls.Add(detailsSectionInner);
            detailsSectionOuter.Location = new Point(15, 515);
            detailsSectionOuter.Name = "detailsSectionOuter";
            detailsSectionOuter.Size = new Size(220, 150);
            detailsSectionOuter.TabIndex = 7;
            // 
            // detailsSectionInner
            // 
            detailsSectionInner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            detailsSectionInner.BackColor = Color.FromArgb(40, 40, 40);
            detailsSectionInner.BackgroundImageLayout = ImageLayout.Stretch;
            detailsSectionInner.Controls.Add(detailsVersion);
            detailsSectionInner.Controls.Add(detailsDescription);
            detailsSectionInner.Controls.Add(detailsName);
            detailsSectionInner.Location = new Point(2, 2);
            detailsSectionInner.Name = "detailsSectionInner";
            detailsSectionInner.Size = new Size(216, 146);
            detailsSectionInner.TabIndex = 0;
            // 
            // detailsVersion
            // 
            detailsVersion.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            detailsVersion.ForeColor = Color.White;
            detailsVersion.Location = new Point(3, 100);
            detailsVersion.Name = "detailsVersion";
            detailsVersion.Size = new Size(210, 40);
            detailsVersion.TabIndex = 2;
            detailsVersion.Text = "Latest version";
            detailsVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // detailsDescription
            // 
            detailsDescription.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            detailsDescription.ForeColor = Color.White;
            detailsDescription.Location = new Point(3, 35);
            detailsDescription.Name = "detailsDescription";
            detailsDescription.Size = new Size(210, 60);
            detailsDescription.TabIndex = 1;
            detailsDescription.Text = "Description";
            // 
            // detailsName
            // 
            detailsName.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            detailsName.ForeColor = Color.White;
            detailsName.Location = new Point(3, 5);
            detailsName.Name = "detailsName";
            detailsName.Size = new Size(210, 20);
            detailsName.TabIndex = 0;
            detailsName.Text = "Name";
            detailsName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // divider3
            // 
            divider3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            divider3.BackColor = SystemColors.ButtonHighlight;
            divider3.Location = new Point(44, 490);
            divider3.Name = "divider3";
            divider3.Size = new Size(160, 1);
            divider3.TabIndex = 23;
            // 
            // divider2
            // 
            divider2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            divider2.BackColor = SystemColors.ButtonHighlight;
            divider2.Location = new Point(44, 370);
            divider2.Name = "divider2";
            divider2.Size = new Size(160, 1);
            divider2.TabIndex = 22;
            // 
            // divider1
            // 
            divider1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            divider1.BackColor = SystemColors.ButtonHighlight;
            divider1.Location = new Point(44, 250);
            divider1.Name = "divider1";
            divider1.Size = new Size(160, 1);
            divider1.TabIndex = 21;
            // 
            // sortSection
            // 
            sortSection.Controls.Add(sortByText);
            sortSection.Controls.Add(sortByName);
            sortSection.Controls.Add(sortByAuthor);
            sortSection.Controls.Add(sortByLatestRelease);
            sortSection.Controls.Add(sortByInitialRelease);
            sortSection.Location = new Point(15, 250);
            sortSection.Name = "sortSection";
            sortSection.Size = new Size(220, 120);
            sortSection.TabIndex = 13;
            // 
            // sortByText
            // 
            sortByText.AutoSize = true;
            sortByText.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            sortByText.ForeColor = SystemColors.ButtonHighlight;
            sortByText.Location = new Point(76, 20);
            sortByText.Name = "sortByText";
            sortByText.Size = new Size(67, 20);
            sortByText.TabIndex = 11;
            sortByText.Text = "Sort by:";
            // 
            // sortByName
            // 
            sortByName.AutoSize = true;
            sortByName.ForeColor = SystemColors.ButtonHighlight;
            sortByName.Location = new Point(29, 50);
            sortByName.Name = "sortByName";
            sortByName.Size = new Size(52, 20);
            sortByName.TabIndex = 10;
            sortByName.TabStop = true;
            sortByName.Text = "Name";
            sortByName.UseVisualStyleBackColor = true;
            sortByName.Click += ClickedSortByName;
            // 
            // sortByAuthor
            // 
            sortByAuthor.AutoSize = true;
            sortByAuthor.ForeColor = SystemColors.ButtonHighlight;
            sortByAuthor.Location = new Point(29, 75);
            sortByAuthor.Name = "sortByAuthor";
            sortByAuthor.Size = new Size(59, 20);
            sortByAuthor.TabIndex = 11;
            sortByAuthor.TabStop = true;
            sortByAuthor.Text = "Author";
            sortByAuthor.UseVisualStyleBackColor = true;
            sortByAuthor.Click += ClickedSortByAuthor;
            // 
            // sortByLatestRelease
            // 
            sortByLatestRelease.AutoSize = true;
            sortByLatestRelease.ForeColor = SystemColors.ButtonHighlight;
            sortByLatestRelease.Location = new Point(105, 75);
            sortByLatestRelease.Name = "sortByLatestRelease";
            sortByLatestRelease.Size = new Size(97, 20);
            sortByLatestRelease.TabIndex = 9;
            sortByLatestRelease.TabStop = true;
            sortByLatestRelease.Text = "Latest release";
            sortByLatestRelease.UseVisualStyleBackColor = true;
            sortByLatestRelease.Click += ClickedSortByLatestRelease;
            // 
            // sortByInitialRelease
            // 
            sortByInitialRelease.AutoSize = true;
            sortByInitialRelease.ForeColor = SystemColors.ButtonHighlight;
            sortByInitialRelease.Location = new Point(105, 50);
            sortByInitialRelease.Name = "sortByInitialRelease";
            sortByInitialRelease.Size = new Size(93, 20);
            sortByInitialRelease.TabIndex = 8;
            sortByInitialRelease.TabStop = true;
            sortByInitialRelease.Text = "Initial release";
            sortByInitialRelease.UseVisualStyleBackColor = true;
            sortByInitialRelease.Click += ClickedSortByInitialRelease;
            // 
            // allSection
            // 
            allSection.Controls.Add(allInstallBtn);
            allSection.Controls.Add(allEnableBtn);
            allSection.Controls.Add(allUninstallBtn);
            allSection.Controls.Add(allDisableBtn);
            allSection.Location = new Point(15, 370);
            allSection.Name = "allSection";
            allSection.Size = new Size(220, 120);
            allSection.TabIndex = 14;
            // 
            // allInstallBtn
            // 
            allInstallBtn.BackColor = Color.FromArgb(30, 30, 30);
            allInstallBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            allInstallBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            allInstallBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            allInstallBtn.FlatStyle = FlatStyle.Flat;
            allInstallBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            allInstallBtn.ForeColor = SystemColors.ButtonHighlight;
            allInstallBtn.Location = new Point(5, 20);
            allInstallBtn.Name = "allInstallBtn";
            allInstallBtn.Size = new Size(100, 35);
            allInstallBtn.TabIndex = 4;
            allInstallBtn.Text = "Install all";
            allInstallBtn.UseVisualStyleBackColor = false;
            allInstallBtn.Click += ClickedInstallAll;
            allInstallBtn.MouseEnter += ShowSideButtonBorder;
            allInstallBtn.MouseLeave += HideSideButtonBorder;
            allInstallBtn.MouseUp += RemoveButtonFocus;
            // 
            // allEnableBtn
            // 
            allEnableBtn.BackColor = Color.FromArgb(30, 30, 30);
            allEnableBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            allEnableBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            allEnableBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            allEnableBtn.FlatStyle = FlatStyle.Flat;
            allEnableBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            allEnableBtn.ForeColor = SystemColors.ButtonHighlight;
            allEnableBtn.Location = new Point(5, 66);
            allEnableBtn.Name = "allEnableBtn";
            allEnableBtn.Size = new Size(100, 35);
            allEnableBtn.TabIndex = 6;
            allEnableBtn.Text = "Enable all";
            allEnableBtn.UseVisualStyleBackColor = false;
            allEnableBtn.Click += ClickedEnableAll;
            allEnableBtn.MouseEnter += ShowSideButtonBorder;
            allEnableBtn.MouseLeave += HideSideButtonBorder;
            allEnableBtn.MouseUp += RemoveButtonFocus;
            // 
            // allUninstallBtn
            // 
            allUninstallBtn.BackColor = Color.FromArgb(30, 30, 30);
            allUninstallBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            allUninstallBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            allUninstallBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            allUninstallBtn.FlatStyle = FlatStyle.Flat;
            allUninstallBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            allUninstallBtn.ForeColor = SystemColors.ButtonHighlight;
            allUninstallBtn.Location = new Point(115, 20);
            allUninstallBtn.Name = "allUninstallBtn";
            allUninstallBtn.Size = new Size(100, 35);
            allUninstallBtn.TabIndex = 5;
            allUninstallBtn.Text = "Uninstall all";
            allUninstallBtn.UseVisualStyleBackColor = false;
            allUninstallBtn.Click += ClickedUninstallAll;
            allUninstallBtn.MouseEnter += ShowSideButtonBorder;
            allUninstallBtn.MouseLeave += HideSideButtonBorder;
            allUninstallBtn.MouseUp += RemoveButtonFocus;
            // 
            // allDisableBtn
            // 
            allDisableBtn.BackColor = Color.FromArgb(30, 30, 30);
            allDisableBtn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            allDisableBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            allDisableBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            allDisableBtn.FlatStyle = FlatStyle.Flat;
            allDisableBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            allDisableBtn.ForeColor = SystemColors.ButtonHighlight;
            allDisableBtn.Location = new Point(115, 65);
            allDisableBtn.Name = "allDisableBtn";
            allDisableBtn.Size = new Size(100, 35);
            allDisableBtn.TabIndex = 7;
            allDisableBtn.Text = "Disable all";
            allDisableBtn.UseVisualStyleBackColor = false;
            allDisableBtn.Click += ClickedDisableAll;
            allDisableBtn.MouseEnter += ShowSideButtonBorder;
            allDisableBtn.MouseLeave += HideSideButtonBorder;
            allDisableBtn.MouseUp += RemoveButtonFocus;
            // 
            // sideSectionOuter
            // 
            sideSectionOuter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            sideSectionOuter.BackColor = Color.Black;
            sideSectionOuter.Controls.Add(sideSectionInner);
            sideSectionOuter.Location = new Point(0, 0);
            sideSectionOuter.Name = "sideSectionOuter";
            sideSectionOuter.Size = new Size(250, 750);
            sideSectionOuter.TabIndex = 9;
            // 
            // UIHandler
            // 
            AutoScaleDimensions = new SizeF(6F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1384, 761);
            Controls.Add(mainSection);
            Controls.Add(sideSectionOuter);
            Font = new Font("Trebuchet MS", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1400, 800);
            Name = "UIHandler";
            Text = "Blasphemous Mod Installer";
            FormClosing += OnFormClose;
            Load += OnFormOpen;
            SizeChanged += MainForm_SizeChanged;
            blas1modSection.ResumeLayout(false);
            validationSection.ResumeLayout(false);
            mainSection.ResumeLayout(false);
            titleSectionOuter.ResumeLayout(false);
            titleSectionInner.ResumeLayout(false);
            warningSectionOuter.ResumeLayout(false);
            warningSectionInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)warningImage).EndInit();
            blas1skinSection.ResumeLayout(false);
            blas2modSection.ResumeLayout(false);
            sideSectionInner.ResumeLayout(false);
            pageSection.ResumeLayout(false);
            detailsSectionOuter.ResumeLayout(false);
            detailsSectionInner.ResumeLayout(false);
            sortSection.ResumeLayout(false);
            sortSection.PerformLayout();
            allSection.ResumeLayout(false);
            sideSectionOuter.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Button pageb1mBtn;
        private System.Windows.Forms.Button pageb1sBtn;
        private System.Windows.Forms.Button pageb2mBtn;
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
        private System.Windows.Forms.Button allInstallBtn;
        private System.Windows.Forms.Button allDisableBtn;
        private System.Windows.Forms.Button allEnableBtn;
        private System.Windows.Forms.Button allUninstallBtn;
        private System.Windows.Forms.Panel divider1;
        private System.Windows.Forms.Panel divider2;
        private System.Windows.Forms.Button toolsBtn;
        private System.Windows.Forms.Panel divider3;
        private System.Windows.Forms.Panel detailsSectionOuter;
        private System.Windows.Forms.Panel detailsSectionInner;
        private System.Windows.Forms.Label detailsName;
        private System.Windows.Forms.Label detailsDescription;
        private System.Windows.Forms.Label detailsVersion;
        private System.Windows.Forms.Panel allSection;
        private System.Windows.Forms.Panel pageSection;
        private Button changePathBtn;
    }
}

