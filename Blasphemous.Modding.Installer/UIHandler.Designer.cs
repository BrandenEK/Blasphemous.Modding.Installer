
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
            _bottom_blas1mod_scroll = new VScrollBar();
            _bottom_blas1mod = new Panel();
            _bottom_validation_location = new Button();
            _bottom_validation = new Panel();
            _bottom_validation_tools = new Button();
            _main = new Panel();
            _left = new Panel();
            _left_outer = new Panel();
            _left_inner = new Panel();
            _left_startVanilla = new Button();
            _left_startModded = new Button();
            _left_changePath = new Button();
            _left_page = new Panel();
            _left_page_blas1mod = new Button();
            _left_page_blas1skin = new Button();
            _left_page_blas2mod = new Button();
            _left_details_outer = new Panel();
            _left_details_inner = new Panel();
            _left_details_version = new Label();
            _left_details_desc = new Label();
            _left_details_name = new Label();
            _left_divider3 = new Panel();
            _left_divider2 = new Panel();
            _left_divider1 = new Panel();
            _left_sort = new Panel();
            _left_sort_text = new Label();
            _left_sort_name = new RadioButton();
            _left_sort_author = new RadioButton();
            _left_sort_latestRelease = new RadioButton();
            _left_sort_initialRelease = new RadioButton();
            _left_all = new Panel();
            _left_all_install = new Button();
            _left_all_enable = new Button();
            _left_all_uninstall = new Button();
            _left_all_disable = new Button();
            _top = new Panel();
            _top_outer = new Panel();
            _top_inner = new Panel();
            _top_warning_outer = new Panel();
            _top_warning_inner = new Panel();
            _top_warning_text = new LinkLabel();
            _top_warning_image = new PictureBox();
            _top_text = new Label();
            _bottom = new Panel();
            _bottom_blas1skin = new Panel();
            _bottom_blas1skin_scroll = new VScrollBar();
            _bottom_blas2mod = new Panel();
            _bottom_blas2mod_scroll = new VScrollBar();
            _bottom_blas1mod.SuspendLayout();
            _bottom_validation.SuspendLayout();
            _main.SuspendLayout();
            _left.SuspendLayout();
            _left_outer.SuspendLayout();
            _left_inner.SuspendLayout();
            _left_page.SuspendLayout();
            _left_details_outer.SuspendLayout();
            _left_details_inner.SuspendLayout();
            _left_sort.SuspendLayout();
            _left_all.SuspendLayout();
            _top.SuspendLayout();
            _top_outer.SuspendLayout();
            _top_inner.SuspendLayout();
            _top_warning_outer.SuspendLayout();
            _top_warning_inner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_top_warning_image).BeginInit();
            _bottom.SuspendLayout();
            _bottom_blas1skin.SuspendLayout();
            _bottom_blas2mod.SuspendLayout();
            SuspendLayout();
            // 
            // _bottom_blas1mod_scroll
            // 
            _bottom_blas1mod_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_blas1mod_scroll.Location = new Point(2034, 15);
            _bottom_blas1mod_scroll.Name = "_bottom_blas1mod_scroll";
            _bottom_blas1mod_scroll.Size = new Size(20, 602);
            _bottom_blas1mod_scroll.TabIndex = 2;
            _bottom_blas1mod_scroll.Visible = false;
            // 
            // _bottom_blas1mod
            // 
            _bottom_blas1mod.AutoScroll = true;
            _bottom_blas1mod.AutoScrollMargin = new Size(0, 15);
            _bottom_blas1mod.BackColor = Color.FromArgb(52, 52, 52);
            _bottom_blas1mod.Controls.Add(_bottom_blas1mod_scroll);
            _bottom_blas1mod.Dock = DockStyle.Fill;
            _bottom_blas1mod.Location = new Point(0, 0);
            _bottom_blas1mod.Name = "_bottom_blas1mod";
            _bottom_blas1mod.Size = new Size(1050, 680);
            _bottom_blas1mod.TabIndex = 3;
            _bottom_blas1mod.Visible = false;
            // 
            // _bottom_validation_location
            // 
            _bottom_validation_location.Anchor = AnchorStyles.None;
            _bottom_validation_location.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _bottom_validation_location.Location = new Point(420, 280);
            _bottom_validation_location.Name = "_bottom_validation_location";
            _bottom_validation_location.Size = new Size(210, 50);
            _bottom_validation_location.TabIndex = 0;
            _bottom_validation_location.Text = "Locate .exe";
            _bottom_validation_location.UseVisualStyleBackColor = true;
            _bottom_validation_location.Click += ClickLocationButton;
            // 
            // _bottom_validation
            // 
            _bottom_validation.BackColor = Color.FromArgb(52, 52, 52);
            _bottom_validation.Controls.Add(_bottom_validation_tools);
            _bottom_validation.Controls.Add(_bottom_validation_location);
            _bottom_validation.Dock = DockStyle.Fill;
            _bottom_validation.Location = new Point(0, 0);
            _bottom_validation.Name = "_bottom_validation";
            _bottom_validation.Size = new Size(1050, 680);
            _bottom_validation.TabIndex = 4;
            // 
            // _bottom_validation_tools
            // 
            _bottom_validation_tools.Anchor = AnchorStyles.None;
            _bottom_validation_tools.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _bottom_validation_tools.Location = new Point(420, 350);
            _bottom_validation_tools.Name = "_bottom_validation_tools";
            _bottom_validation_tools.Size = new Size(210, 50);
            _bottom_validation_tools.TabIndex = 1;
            _bottom_validation_tools.Text = "Install modding tools";
            _bottom_validation_tools.UseVisualStyleBackColor = true;
            _bottom_validation_tools.Click += ClickToolsButton;
            // 
            // _main
            // 
            _main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _main.BackColor = Color.White;
            _main.Controls.Add(_left);
            _main.Controls.Add(_top);
            _main.Controls.Add(_bottom);
            _main.Location = new Point(10, 10);
            _main.Name = "_main";
            _main.Size = new Size(1300, 800);
            _main.TabIndex = 7;
            // 
            // _left
            // 
            _left.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _left.BackColor = Color.SkyBlue;
            _left.Controls.Add(_left_outer);
            _left.Location = new Point(0, 0);
            _left.Name = "_left";
            _left.Size = new Size(250, 800);
            _left.TabIndex = 11;
            // 
            // _left_outer
            // 
            _left_outer.BackColor = Color.Black;
            _left_outer.Controls.Add(_left_inner);
            _left_outer.Dock = DockStyle.Fill;
            _left_outer.Location = new Point(0, 0);
            _left_outer.Name = "_left_outer";
            _left_outer.Size = new Size(250, 800);
            _left_outer.TabIndex = 9;
            // 
            // _left_inner
            // 
            _left_inner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _left_inner.BackColor = Color.FromArgb(30, 30, 30);
            _left_inner.Controls.Add(_left_startVanilla);
            _left_inner.Controls.Add(_left_startModded);
            _left_inner.Controls.Add(_left_changePath);
            _left_inner.Controls.Add(_left_page);
            _left_inner.Controls.Add(_left_details_outer);
            _left_inner.Controls.Add(_left_divider3);
            _left_inner.Controls.Add(_left_divider2);
            _left_inner.Controls.Add(_left_divider1);
            _left_inner.Controls.Add(_left_sort);
            _left_inner.Controls.Add(_left_all);
            _left_inner.Location = new Point(0, 0);
            _left_inner.Name = "_left_inner";
            _left_inner.Size = new Size(248, 800);
            _left_inner.TabIndex = 8;
            // 
            // _left_startVanilla
            // 
            _left_startVanilla.Anchor = AnchorStyles.Bottom;
            _left_startVanilla.BackColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatStyle = FlatStyle.Flat;
            _left_startVanilla.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_startVanilla.ForeColor = SystemColors.ButtonHighlight;
            _left_startVanilla.Location = new Point(15, 670);
            _left_startVanilla.Name = "_left_startVanilla";
            _left_startVanilla.Size = new Size(220, 30);
            _left_startVanilla.TabIndex = 25;
            _left_startVanilla.Text = "Start game (Vanilla)";
            _left_startVanilla.UseVisualStyleBackColor = false;
            _left_startVanilla.Click += ClickedStartVanilla;
            _left_startVanilla.MouseEnter += ShowSideButtonBorder;
            _left_startVanilla.MouseLeave += HideSideButtonBorder;
            _left_startVanilla.MouseUp += RemoveButtonFocus;
            // 
            // _left_startModded
            // 
            _left_startModded.Anchor = AnchorStyles.Bottom;
            _left_startModded.BackColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatStyle = FlatStyle.Flat;
            _left_startModded.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_startModded.ForeColor = SystemColors.ButtonHighlight;
            _left_startModded.Location = new Point(15, 710);
            _left_startModded.Name = "_left_startModded";
            _left_startModded.Size = new Size(220, 30);
            _left_startModded.TabIndex = 24;
            _left_startModded.Text = "Start game (Modded)";
            _left_startModded.UseVisualStyleBackColor = false;
            _left_startModded.Click += ClickedStartModded;
            _left_startModded.MouseEnter += ShowSideButtonBorder;
            _left_startModded.MouseLeave += HideSideButtonBorder;
            _left_startModded.MouseUp += RemoveButtonFocus;
            // 
            // _left_changePath
            // 
            _left_changePath.Anchor = AnchorStyles.Bottom;
            _left_changePath.BackColor = Color.FromArgb(30, 30, 30);
            _left_changePath.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_changePath.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_changePath.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_changePath.FlatStyle = FlatStyle.Flat;
            _left_changePath.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_changePath.ForeColor = SystemColors.ButtonHighlight;
            _left_changePath.Location = new Point(15, 750);
            _left_changePath.Name = "_left_changePath";
            _left_changePath.Size = new Size(220, 30);
            _left_changePath.TabIndex = 8;
            _left_changePath.Text = "Change exe location";
            _left_changePath.UseVisualStyleBackColor = false;
            _left_changePath.Click += ClickedChangePath;
            _left_changePath.MouseEnter += ShowSideButtonBorder;
            _left_changePath.MouseLeave += HideSideButtonBorder;
            _left_changePath.MouseUp += RemoveButtonFocus;
            // 
            // _left_page
            // 
            _left_page.Controls.Add(_left_page_blas1mod);
            _left_page.Controls.Add(_left_page_blas1skin);
            _left_page.Controls.Add(_left_page_blas2mod);
            _left_page.Location = new Point(15, 15);
            _left_page.Name = "_left_page";
            _left_page.Size = new Size(220, 235);
            _left_page.TabIndex = 14;
            // 
            // _left_page_blas1mod
            // 
            _left_page_blas1mod.BackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1mod.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1mod.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1mod.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1mod.FlatStyle = FlatStyle.Flat;
            _left_page_blas1mod.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            _left_page_blas1mod.ForeColor = SystemColors.ButtonHighlight;
            _left_page_blas1mod.Location = new Point(0, 60);
            _left_page_blas1mod.Name = "_left_page_blas1mod";
            _left_page_blas1mod.Size = new Size(220, 35);
            _left_page_blas1mod.TabIndex = 1;
            _left_page_blas1mod.Text = "Blasphemous Mods";
            _left_page_blas1mod.UseVisualStyleBackColor = false;
            _left_page_blas1mod.Click += ClickedBlas1Mods;
            _left_page_blas1mod.MouseEnter += ShowSideButtonBorder;
            _left_page_blas1mod.MouseLeave += HideSideButtonBorder;
            _left_page_blas1mod.MouseUp += RemoveButtonFocus;
            // 
            // _left_page_blas1skin
            // 
            _left_page_blas1skin.BackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1skin.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1skin.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1skin.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas1skin.FlatStyle = FlatStyle.Flat;
            _left_page_blas1skin.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            _left_page_blas1skin.ForeColor = SystemColors.ButtonHighlight;
            _left_page_blas1skin.Location = new Point(0, 105);
            _left_page_blas1skin.Name = "_left_page_blas1skin";
            _left_page_blas1skin.Size = new Size(220, 35);
            _left_page_blas1skin.TabIndex = 2;
            _left_page_blas1skin.Text = "Blasphemous Skins";
            _left_page_blas1skin.UseVisualStyleBackColor = false;
            _left_page_blas1skin.Click += ClickedBlas1Skins;
            _left_page_blas1skin.MouseEnter += ShowSideButtonBorder;
            _left_page_blas1skin.MouseLeave += HideSideButtonBorder;
            _left_page_blas1skin.MouseUp += RemoveButtonFocus;
            // 
            // _left_page_blas2mod
            // 
            _left_page_blas2mod.BackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas2mod.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_page_blas2mod.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas2mod.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_page_blas2mod.FlatStyle = FlatStyle.Flat;
            _left_page_blas2mod.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            _left_page_blas2mod.ForeColor = SystemColors.ButtonHighlight;
            _left_page_blas2mod.Location = new Point(0, 150);
            _left_page_blas2mod.Name = "_left_page_blas2mod";
            _left_page_blas2mod.Size = new Size(220, 35);
            _left_page_blas2mod.TabIndex = 3;
            _left_page_blas2mod.Text = "Blasphemous II Mods";
            _left_page_blas2mod.UseVisualStyleBackColor = false;
            _left_page_blas2mod.Click += ClickedBlas2Mods;
            _left_page_blas2mod.MouseEnter += ShowSideButtonBorder;
            _left_page_blas2mod.MouseLeave += HideSideButtonBorder;
            _left_page_blas2mod.MouseUp += RemoveButtonFocus;
            // 
            // _left_details_outer
            // 
            _left_details_outer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _left_details_outer.BackColor = Color.Black;
            _left_details_outer.Controls.Add(_left_details_inner);
            _left_details_outer.Location = new Point(15, 515);
            _left_details_outer.Name = "_left_details_outer";
            _left_details_outer.Size = new Size(220, 150);
            _left_details_outer.TabIndex = 7;
            // 
            // _left_details_inner
            // 
            _left_details_inner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _left_details_inner.BackColor = Color.FromArgb(40, 40, 40);
            _left_details_inner.BackgroundImageLayout = ImageLayout.Stretch;
            _left_details_inner.Controls.Add(_left_details_version);
            _left_details_inner.Controls.Add(_left_details_desc);
            _left_details_inner.Controls.Add(_left_details_name);
            _left_details_inner.Location = new Point(2, 2);
            _left_details_inner.Name = "_left_details_inner";
            _left_details_inner.Size = new Size(216, 146);
            _left_details_inner.TabIndex = 0;
            // 
            // _left_details_version
            // 
            _left_details_version.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            _left_details_version.ForeColor = Color.White;
            _left_details_version.Location = new Point(3, 100);
            _left_details_version.Name = "_left_details_version";
            _left_details_version.Size = new Size(210, 40);
            _left_details_version.TabIndex = 2;
            _left_details_version.Text = "Latest version";
            _left_details_version.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _left_details_desc
            // 
            _left_details_desc.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            _left_details_desc.ForeColor = Color.White;
            _left_details_desc.Location = new Point(3, 35);
            _left_details_desc.Name = "_left_details_desc";
            _left_details_desc.Size = new Size(210, 60);
            _left_details_desc.TabIndex = 1;
            _left_details_desc.Text = "Description";
            // 
            // _left_details_name
            // 
            _left_details_name.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_details_name.ForeColor = Color.White;
            _left_details_name.Location = new Point(3, 5);
            _left_details_name.Name = "_left_details_name";
            _left_details_name.Size = new Size(210, 20);
            _left_details_name.TabIndex = 0;
            _left_details_name.Text = "Name";
            _left_details_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _left_divider3
            // 
            _left_divider3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _left_divider3.BackColor = SystemColors.ButtonHighlight;
            _left_divider3.Location = new Point(44, 490);
            _left_divider3.Name = "_left_divider3";
            _left_divider3.Size = new Size(160, 1);
            _left_divider3.TabIndex = 23;
            // 
            // _left_divider2
            // 
            _left_divider2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _left_divider2.BackColor = SystemColors.ButtonHighlight;
            _left_divider2.Location = new Point(44, 370);
            _left_divider2.Name = "_left_divider2";
            _left_divider2.Size = new Size(160, 1);
            _left_divider2.TabIndex = 22;
            // 
            // _left_divider1
            // 
            _left_divider1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _left_divider1.BackColor = SystemColors.ButtonHighlight;
            _left_divider1.Location = new Point(44, 250);
            _left_divider1.Name = "_left_divider1";
            _left_divider1.Size = new Size(160, 1);
            _left_divider1.TabIndex = 21;
            // 
            // _left_sort
            // 
            _left_sort.Controls.Add(_left_sort_text);
            _left_sort.Controls.Add(_left_sort_name);
            _left_sort.Controls.Add(_left_sort_author);
            _left_sort.Controls.Add(_left_sort_latestRelease);
            _left_sort.Controls.Add(_left_sort_initialRelease);
            _left_sort.Location = new Point(15, 250);
            _left_sort.Name = "_left_sort";
            _left_sort.Size = new Size(220, 120);
            _left_sort.TabIndex = 13;
            // 
            // _left_sort_text
            // 
            _left_sort_text.AutoSize = true;
            _left_sort_text.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            _left_sort_text.ForeColor = SystemColors.ButtonHighlight;
            _left_sort_text.Location = new Point(76, 20);
            _left_sort_text.Name = "_left_sort_text";
            _left_sort_text.Size = new Size(67, 20);
            _left_sort_text.TabIndex = 11;
            _left_sort_text.Text = "Sort by:";
            // 
            // _left_sort_name
            // 
            _left_sort_name.AutoSize = true;
            _left_sort_name.ForeColor = SystemColors.ButtonHighlight;
            _left_sort_name.Location = new Point(29, 50);
            _left_sort_name.Name = "_left_sort_name";
            _left_sort_name.Size = new Size(52, 20);
            _left_sort_name.TabIndex = 10;
            _left_sort_name.TabStop = true;
            _left_sort_name.Text = "Name";
            _left_sort_name.UseVisualStyleBackColor = true;
            _left_sort_name.Click += ClickedSortByName;
            // 
            // _left_sort_author
            // 
            _left_sort_author.AutoSize = true;
            _left_sort_author.ForeColor = SystemColors.ButtonHighlight;
            _left_sort_author.Location = new Point(29, 75);
            _left_sort_author.Name = "_left_sort_author";
            _left_sort_author.Size = new Size(59, 20);
            _left_sort_author.TabIndex = 11;
            _left_sort_author.TabStop = true;
            _left_sort_author.Text = "Author";
            _left_sort_author.UseVisualStyleBackColor = true;
            _left_sort_author.Click += ClickedSortByAuthor;
            // 
            // _left_sort_latestRelease
            // 
            _left_sort_latestRelease.AutoSize = true;
            _left_sort_latestRelease.ForeColor = SystemColors.ButtonHighlight;
            _left_sort_latestRelease.Location = new Point(105, 75);
            _left_sort_latestRelease.Name = "_left_sort_latestRelease";
            _left_sort_latestRelease.Size = new Size(97, 20);
            _left_sort_latestRelease.TabIndex = 9;
            _left_sort_latestRelease.TabStop = true;
            _left_sort_latestRelease.Text = "Latest release";
            _left_sort_latestRelease.UseVisualStyleBackColor = true;
            _left_sort_latestRelease.Click += ClickedSortByLatestRelease;
            // 
            // _left_sort_initialRelease
            // 
            _left_sort_initialRelease.AutoSize = true;
            _left_sort_initialRelease.ForeColor = SystemColors.ButtonHighlight;
            _left_sort_initialRelease.Location = new Point(105, 50);
            _left_sort_initialRelease.Name = "_left_sort_initialRelease";
            _left_sort_initialRelease.Size = new Size(93, 20);
            _left_sort_initialRelease.TabIndex = 8;
            _left_sort_initialRelease.TabStop = true;
            _left_sort_initialRelease.Text = "Initial release";
            _left_sort_initialRelease.UseVisualStyleBackColor = true;
            _left_sort_initialRelease.Click += ClickedSortByInitialRelease;
            // 
            // _left_all
            // 
            _left_all.Controls.Add(_left_all_install);
            _left_all.Controls.Add(_left_all_enable);
            _left_all.Controls.Add(_left_all_uninstall);
            _left_all.Controls.Add(_left_all_disable);
            _left_all.Location = new Point(15, 370);
            _left_all.Name = "_left_all";
            _left_all.Size = new Size(220, 120);
            _left_all.TabIndex = 14;
            // 
            // _left_all_install
            // 
            _left_all_install.BackColor = Color.FromArgb(30, 30, 30);
            _left_all_install.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_all_install.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_all_install.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_all_install.FlatStyle = FlatStyle.Flat;
            _left_all_install.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_all_install.ForeColor = SystemColors.ButtonHighlight;
            _left_all_install.Location = new Point(5, 20);
            _left_all_install.Name = "_left_all_install";
            _left_all_install.Size = new Size(100, 35);
            _left_all_install.TabIndex = 4;
            _left_all_install.Text = "Install all";
            _left_all_install.UseVisualStyleBackColor = false;
            _left_all_install.Click += ClickedInstallAll;
            _left_all_install.MouseEnter += ShowSideButtonBorder;
            _left_all_install.MouseLeave += HideSideButtonBorder;
            _left_all_install.MouseUp += RemoveButtonFocus;
            // 
            // _left_all_enable
            // 
            _left_all_enable.BackColor = Color.FromArgb(30, 30, 30);
            _left_all_enable.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_all_enable.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_all_enable.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_all_enable.FlatStyle = FlatStyle.Flat;
            _left_all_enable.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_all_enable.ForeColor = SystemColors.ButtonHighlight;
            _left_all_enable.Location = new Point(5, 66);
            _left_all_enable.Name = "_left_all_enable";
            _left_all_enable.Size = new Size(100, 35);
            _left_all_enable.TabIndex = 6;
            _left_all_enable.Text = "Enable all";
            _left_all_enable.UseVisualStyleBackColor = false;
            _left_all_enable.Click += ClickedEnableAll;
            _left_all_enable.MouseEnter += ShowSideButtonBorder;
            _left_all_enable.MouseLeave += HideSideButtonBorder;
            _left_all_enable.MouseUp += RemoveButtonFocus;
            // 
            // _left_all_uninstall
            // 
            _left_all_uninstall.BackColor = Color.FromArgb(30, 30, 30);
            _left_all_uninstall.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_all_uninstall.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_all_uninstall.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_all_uninstall.FlatStyle = FlatStyle.Flat;
            _left_all_uninstall.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_all_uninstall.ForeColor = SystemColors.ButtonHighlight;
            _left_all_uninstall.Location = new Point(115, 20);
            _left_all_uninstall.Name = "_left_all_uninstall";
            _left_all_uninstall.Size = new Size(100, 35);
            _left_all_uninstall.TabIndex = 5;
            _left_all_uninstall.Text = "Uninstall all";
            _left_all_uninstall.UseVisualStyleBackColor = false;
            _left_all_uninstall.Click += ClickedUninstallAll;
            _left_all_uninstall.MouseEnter += ShowSideButtonBorder;
            _left_all_uninstall.MouseLeave += HideSideButtonBorder;
            _left_all_uninstall.MouseUp += RemoveButtonFocus;
            // 
            // _left_all_disable
            // 
            _left_all_disable.BackColor = Color.FromArgb(30, 30, 30);
            _left_all_disable.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_all_disable.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_all_disable.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_all_disable.FlatStyle = FlatStyle.Flat;
            _left_all_disable.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_all_disable.ForeColor = SystemColors.ButtonHighlight;
            _left_all_disable.Location = new Point(115, 65);
            _left_all_disable.Name = "_left_all_disable";
            _left_all_disable.Size = new Size(100, 35);
            _left_all_disable.TabIndex = 7;
            _left_all_disable.Text = "Disable all";
            _left_all_disable.UseVisualStyleBackColor = false;
            _left_all_disable.Click += ClickedDisableAll;
            _left_all_disable.MouseEnter += ShowSideButtonBorder;
            _left_all_disable.MouseLeave += HideSideButtonBorder;
            _left_all_disable.MouseUp += RemoveButtonFocus;
            // 
            // _top
            // 
            _top.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _top.BackColor = Color.SpringGreen;
            _top.Controls.Add(_top_outer);
            _top.Location = new Point(250, 0);
            _top.Name = "_top";
            _top.Size = new Size(1050, 120);
            _top.TabIndex = 12;
            // 
            // _top_outer
            // 
            _top_outer.BackColor = Color.Black;
            _top_outer.Controls.Add(_top_inner);
            _top_outer.Dock = DockStyle.Fill;
            _top_outer.Location = new Point(0, 0);
            _top_outer.Name = "_top_outer";
            _top_outer.Size = new Size(1050, 120);
            _top_outer.TabIndex = 9;
            // 
            // _top_inner
            // 
            _top_inner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _top_inner.BackColor = Color.Maroon;
            _top_inner.BackgroundImage = Properties.Resources.background1;
            _top_inner.BackgroundImageLayout = ImageLayout.Center;
            _top_inner.Controls.Add(_top_warning_outer);
            _top_inner.Controls.Add(_top_text);
            _top_inner.Location = new Point(0, 0);
            _top_inner.Name = "_top_inner";
            _top_inner.Size = new Size(1050, 118);
            _top_inner.TabIndex = 1;
            // 
            // _top_warning_outer
            // 
            _top_warning_outer.Anchor = AnchorStyles.Right;
            _top_warning_outer.BackColor = Color.Red;
            _top_warning_outer.Controls.Add(_top_warning_inner);
            _top_warning_outer.Location = new Point(800, 12);
            _top_warning_outer.Name = "_top_warning_outer";
            _top_warning_outer.Size = new Size(220, 80);
            _top_warning_outer.TabIndex = 6;
            _top_warning_outer.Visible = false;
            // 
            // _top_warning_inner
            // 
            _top_warning_inner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _top_warning_inner.BackColor = Color.Black;
            _top_warning_inner.Controls.Add(_top_warning_text);
            _top_warning_inner.Controls.Add(_top_warning_image);
            _top_warning_inner.Location = new Point(2, 2);
            _top_warning_inner.Name = "_top_warning_inner";
            _top_warning_inner.Size = new Size(216, 76);
            _top_warning_inner.TabIndex = 0;
            // 
            // _top_warning_text
            // 
            _top_warning_text.Anchor = AnchorStyles.Right;
            _top_warning_text.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _top_warning_text.ForeColor = SystemColors.ButtonHighlight;
            _top_warning_text.LinkArea = new LinkArea(57, 8);
            _top_warning_text.LinkColor = Color.Cyan;
            _top_warning_text.Location = new Point(52, 10);
            _top_warning_text.Name = "_top_warning_text";
            _top_warning_text.Size = new Size(160, 56);
            _top_warning_text.TabIndex = 3;
            _top_warning_text.TabStop = true;
            _top_warning_text.Text = "A new update is available for the mod installer.  Please download it now.";
            _top_warning_text.TextAlign = ContentAlignment.MiddleLeft;
            _top_warning_text.UseCompatibleTextRendering = true;
            _top_warning_text.LinkClicked += ClickInstallerUpdateLink;
            // 
            // _top_warning_image
            // 
            _top_warning_image.Anchor = AnchorStyles.Left;
            _top_warning_image.BackColor = Color.Black;
            _top_warning_image.BackgroundImageLayout = ImageLayout.Stretch;
            _top_warning_image.Image = Properties.Resources.warning;
            _top_warning_image.Location = new Point(10, 20);
            _top_warning_image.Name = "_top_warning_image";
            _top_warning_image.Size = new Size(36, 36);
            _top_warning_image.SizeMode = PictureBoxSizeMode.StretchImage;
            _top_warning_image.TabIndex = 4;
            _top_warning_image.TabStop = false;
            // 
            // _top_text
            // 
            _top_text.BackColor = Color.FromArgb(0, 0, 0, 0);
            _top_text.Dock = DockStyle.Fill;
            _top_text.Font = new Font("Trebuchet MS", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            _top_text.Location = new Point(0, 0);
            _top_text.Name = "_top_text";
            _top_text.Size = new Size(1050, 118);
            _top_text.TabIndex = 0;
            _top_text.Text = "Blasphemous Mods";
            _top_text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _bottom
            // 
            _bottom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _bottom.BackColor = Color.Firebrick;
            _bottom.Controls.Add(_bottom_blas1mod);
            _bottom.Controls.Add(_bottom_blas1skin);
            _bottom.Controls.Add(_bottom_blas2mod);
            _bottom.Controls.Add(_bottom_validation);
            _bottom.Location = new Point(250, 120);
            _bottom.Name = "_bottom";
            _bottom.Size = new Size(1050, 680);
            _bottom.TabIndex = 10;
            // 
            // _bottom_blas1skin
            // 
            _bottom_blas1skin.AutoScroll = true;
            _bottom_blas1skin.AutoScrollMargin = new Size(0, 15);
            _bottom_blas1skin.BackColor = Color.FromArgb(52, 52, 52);
            _bottom_blas1skin.Controls.Add(_bottom_blas1skin_scroll);
            _bottom_blas1skin.Dock = DockStyle.Fill;
            _bottom_blas1skin.Location = new Point(0, 0);
            _bottom_blas1skin.Name = "_bottom_blas1skin";
            _bottom_blas1skin.Size = new Size(1050, 680);
            _bottom_blas1skin.TabIndex = 5;
            _bottom_blas1skin.Visible = false;
            // 
            // _bottom_blas1skin_scroll
            // 
            _bottom_blas1skin_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_blas1skin_scroll.Location = new Point(1014, 15);
            _bottom_blas1skin_scroll.Name = "_bottom_blas1skin_scroll";
            _bottom_blas1skin_scroll.Size = new Size(20, 619);
            _bottom_blas1skin_scroll.TabIndex = 2;
            _bottom_blas1skin_scroll.Visible = false;
            // 
            // _bottom_blas2mod
            // 
            _bottom_blas2mod.AutoScroll = true;
            _bottom_blas2mod.AutoScrollMargin = new Size(0, 15);
            _bottom_blas2mod.BackColor = Color.FromArgb(52, 52, 52);
            _bottom_blas2mod.Controls.Add(_bottom_blas2mod_scroll);
            _bottom_blas2mod.Dock = DockStyle.Fill;
            _bottom_blas2mod.Location = new Point(0, 0);
            _bottom_blas2mod.Name = "_bottom_blas2mod";
            _bottom_blas2mod.Size = new Size(1050, 680);
            _bottom_blas2mod.TabIndex = 4;
            _bottom_blas2mod.Visible = false;
            // 
            // _bottom_blas2mod_scroll
            // 
            _bottom_blas2mod_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_blas2mod_scroll.Location = new Point(1014, 15);
            _bottom_blas2mod_scroll.Name = "_bottom_blas2mod_scroll";
            _bottom_blas2mod_scroll.Size = new Size(20, 619);
            _bottom_blas2mod_scroll.TabIndex = 2;
            _bottom_blas2mod_scroll.Visible = false;
            // 
            // UIHandler
            // 
            AutoScaleDimensions = new SizeF(6F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1384, 861);
            Controls.Add(_main);
            Font = new Font("Trebuchet MS", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1400, 900);
            Name = "UIHandler";
            SizeChanged += MainForm_SizeChanged;
            _bottom_blas1mod.ResumeLayout(false);
            _bottom_validation.ResumeLayout(false);
            _main.ResumeLayout(false);
            _left.ResumeLayout(false);
            _left_outer.ResumeLayout(false);
            _left_inner.ResumeLayout(false);
            _left_page.ResumeLayout(false);
            _left_details_outer.ResumeLayout(false);
            _left_details_inner.ResumeLayout(false);
            _left_sort.ResumeLayout(false);
            _left_sort.PerformLayout();
            _left_all.ResumeLayout(false);
            _top.ResumeLayout(false);
            _top_outer.ResumeLayout(false);
            _top_inner.ResumeLayout(false);
            _top_warning_outer.ResumeLayout(false);
            _top_warning_inner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_top_warning_image).EndInit();
            _bottom.ResumeLayout(false);
            _bottom_blas1skin.ResumeLayout(false);
            _bottom_blas2mod.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.VScrollBar _bottom_blas1mod_scroll;
        private System.Windows.Forms.Panel _bottom_blas1mod;
        private System.Windows.Forms.Button _bottom_validation_location;
        private System.Windows.Forms.Panel _bottom_validation;
        private System.Windows.Forms.Label _top_text;
        private System.Windows.Forms.Panel _main;
        private System.Windows.Forms.Panel _left_inner;
        private System.Windows.Forms.Panel _top_outer;
        private System.Windows.Forms.Button _left_page_blas1mod;
        private System.Windows.Forms.Button _left_page_blas1skin;
        private System.Windows.Forms.Button _left_page_blas2mod;
        private System.Windows.Forms.Panel _bottom_blas2mod;
        private System.Windows.Forms.VScrollBar _bottom_blas2mod_scroll;
        private System.Windows.Forms.PictureBox _top_warning_image;
        private System.Windows.Forms.Panel _top_warning_outer;
        private System.Windows.Forms.Panel _top_warning_inner;
        private System.Windows.Forms.Panel _bottom_blas1skin;
        private System.Windows.Forms.VScrollBar _bottom_blas1skin_scroll;
        private System.Windows.Forms.Panel _top_inner;
        private System.Windows.Forms.Panel _left_outer;
        private System.Windows.Forms.LinkLabel _top_warning_text;
        private System.Windows.Forms.RadioButton _left_sort_latestRelease;
        private System.Windows.Forms.RadioButton _left_sort_initialRelease;
        private System.Windows.Forms.RadioButton _left_sort_author;
        private System.Windows.Forms.RadioButton _left_sort_name;
        private System.Windows.Forms.Label _left_sort_text;
        private System.Windows.Forms.Panel _left_sort;
        private System.Windows.Forms.Button _left_all_install;
        private System.Windows.Forms.Button _left_all_disable;
        private System.Windows.Forms.Button _left_all_enable;
        private System.Windows.Forms.Button _left_all_uninstall;
        private System.Windows.Forms.Panel _left_divider1;
        private System.Windows.Forms.Panel _left_divider2;
        private System.Windows.Forms.Button _bottom_validation_tools;
        private System.Windows.Forms.Panel _left_divider3;
        private System.Windows.Forms.Panel _left_details_outer;
        private System.Windows.Forms.Panel _left_details_inner;
        private System.Windows.Forms.Label _left_details_name;
        private System.Windows.Forms.Label _left_details_desc;
        private System.Windows.Forms.Label _left_details_version;
        private System.Windows.Forms.Panel _left_all;
        private System.Windows.Forms.Panel _left_page;
        private Button _left_changePath;
        private Panel _bottom;
        private Panel _left;
        private Panel _top;
        private Button _left_startModded;
        private Button _left_startVanilla;
    }
}

