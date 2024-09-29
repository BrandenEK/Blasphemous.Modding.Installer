using Blasphemous.Modding.Installer.UIComponents;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIHandler));
            _bottom_blas1mod_scroll = new VScrollBar();
            _bottom_blas1mod = new Panel();
            _bottom_validation = new Panel();
            _left = new Panel();
            _left_outer = new Panel();
            _left_inner = new Panel();
            _left_startVanilla = new ButtonWithCutoff();
            _left_startModded = new ButtonWithCutoff();
            _left_page = new Panel();
            _left_page_blas1mod = new TransparentButton();
            _left_page_blas1skin = new TransparentButton();
            _left_page_blas2mod = new TransparentButton();
            _left_page_divider = new Panel();
            _left_details_outer = new Panel();
            _left_details_inner = new Panel();
            _left_details_version = new Label();
            _left_details_desc = new Label();
            _left_details_name = new Label();
            _left_sort = new Panel();
            _left_filter_options = new ComboBox();
            _left_filter_text = new Label();
            _left_sort_options = new ComboBox();
            _left_sort_text = new Label();
            _left_sort_divider = new Panel();
            _left_all = new Panel();
            _left_all_install = new TransparentButton();
            _left_all_enable = new TransparentButton();
            _left_all_uninstall = new TransparentButton();
            _left_all_disable = new TransparentButton();
            _left_all_divider = new Panel();
            _top = new Panel();
            _top_outer = new Panel();
            _top_inner = new Panel();
            _top_warning_outer = new Panel();
            _top_warning_inner = new Panel();
            _top_warning_text = new LinkLabel();
            _top_warning_image = new PictureBox();
            _top_text = new Label();
            _middle_tools_icon = new PictureBox();
            _middle_tools_text = new Label();
            _bottom = new Panel();
            _bottom_blas1skin = new Panel();
            _bottom_blas1skin_scroll = new VScrollBar();
            _bottom_blas2mod = new Panel();
            _bottom_blas2mod_scroll = new VScrollBar();
            _middle = new Panel();
            _middle_outer = new Panel();
            _middle_inner = new Panel();
            _middle_path = new Label();
            _middle_tools = new Panel();
            _tooltip = new ToolTip(components);
            _bottom_blas1mod.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)_middle_tools_icon).BeginInit();
            _bottom.SuspendLayout();
            _bottom_blas1skin.SuspendLayout();
            _bottom_blas2mod.SuspendLayout();
            _middle.SuspendLayout();
            _middle_outer.SuspendLayout();
            _middle_inner.SuspendLayout();
            _middle_tools.SuspendLayout();
            SuspendLayout();
            // 
            // _bottom_blas1mod_scroll
            // 
            _bottom_blas1mod_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_blas1mod_scroll.Location = new Point(2318, 15);
            _bottom_blas1mod_scroll.Name = "_bottom_blas1mod_scroll";
            _bottom_blas1mod_scroll.Size = new Size(20, 633);
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
            _bottom_blas1mod.Size = new Size(1334, 711);
            _bottom_blas1mod.TabIndex = 3;
            _bottom_blas1mod.Visible = false;
            // 
            // _bottom_validation
            // 
            _bottom_validation.BackColor = Color.FromArgb(52, 52, 52);
            _bottom_validation.Dock = DockStyle.Fill;
            _bottom_validation.Location = new Point(0, 0);
            _bottom_validation.Name = "_bottom_validation";
            _bottom_validation.Size = new Size(1334, 711);
            _bottom_validation.TabIndex = 4;
            // 
            // _left
            // 
            _left.BackColor = Color.SkyBlue;
            _left.Controls.Add(_left_outer);
            _left.Dock = DockStyle.Left;
            _left.Location = new Point(0, 0);
            _left.Name = "_left";
            _left.Size = new Size(250, 861);
            _left.TabIndex = 11;
            // 
            // _left_outer
            // 
            _left_outer.BackColor = Color.Black;
            _left_outer.Controls.Add(_left_inner);
            _left_outer.Dock = DockStyle.Fill;
            _left_outer.Location = new Point(0, 0);
            _left_outer.Name = "_left_outer";
            _left_outer.Size = new Size(250, 861);
            _left_outer.TabIndex = 9;
            // 
            // _left_inner
            // 
            _left_inner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _left_inner.BackColor = Color.FromArgb(30, 30, 30);
            _left_inner.Controls.Add(_left_startVanilla);
            _left_inner.Controls.Add(_left_startModded);
            _left_inner.Controls.Add(_left_page);
            _left_inner.Controls.Add(_left_details_outer);
            _left_inner.Controls.Add(_left_sort);
            _left_inner.Controls.Add(_left_all);
            _left_inner.Location = new Point(0, 0);
            _left_inner.Name = "_left_inner";
            _left_inner.Size = new Size(248, 861);
            _left_inner.TabIndex = 8;
            // 
            // _left_startVanilla
            // 
            _left_startVanilla.Anchor = AnchorStyles.Bottom;
            _left_startVanilla.BackColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.ExpectedVisibility = true;
            _left_startVanilla.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_startVanilla.FlatStyle = FlatStyle.Flat;
            _left_startVanilla.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_startVanilla.ForeColor = SystemColors.ButtonHighlight;
            _left_startVanilla.Location = new Point(15, 731);
            _left_startVanilla.Name = "_left_startVanilla";
            _left_startVanilla.Size = new Size(220, 30);
            _left_startVanilla.TabIndex = 25;
            _left_startVanilla.Text = "Start game (Vanilla)";
            _left_startVanilla.UseVisualStyleBackColor = false;
            _left_startVanilla.VerticalCutoff = 680;
            _left_startVanilla.Click += ClickedStartVanilla;
            // 
            // _left_startModded
            // 
            _left_startModded.Anchor = AnchorStyles.Bottom;
            _left_startModded.BackColor = Color.FromArgb(30, 30, 30);
            _left_startModded.ExpectedVisibility = true;
            _left_startModded.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_startModded.FlatStyle = FlatStyle.Flat;
            _left_startModded.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_startModded.ForeColor = SystemColors.ButtonHighlight;
            _left_startModded.Location = new Point(15, 771);
            _left_startModded.Name = "_left_startModded";
            _left_startModded.Size = new Size(220, 30);
            _left_startModded.TabIndex = 24;
            _left_startModded.Text = "Start game (Modded)";
            _left_startModded.UseVisualStyleBackColor = false;
            _left_startModded.VerticalCutoff = 680;
            _left_startModded.Click += ClickedStartModded;
            // 
            // _left_page
            // 
            _left_page.Controls.Add(_left_page_blas1mod);
            _left_page.Controls.Add(_left_page_blas1skin);
            _left_page.Controls.Add(_left_page_blas2mod);
            _left_page.Controls.Add(_left_page_divider);
            _left_page.Location = new Point(15, 15);
            _left_page.Name = "_left_page";
            _left_page.Size = new Size(220, 145);
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
            _left_page_blas1mod.Location = new Point(0, 0);
            _left_page_blas1mod.Name = "_left_page_blas1mod";
            _left_page_blas1mod.Size = new Size(220, 35);
            _left_page_blas1mod.TabIndex = 1;
            _left_page_blas1mod.Text = "Blasphemous Mods";
            _left_page_blas1mod.UseVisualStyleBackColor = false;
            _left_page_blas1mod.Click += ClickedBlas1Mods;
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
            _left_page_blas1skin.Location = new Point(0, 45);
            _left_page_blas1skin.Name = "_left_page_blas1skin";
            _left_page_blas1skin.Size = new Size(220, 35);
            _left_page_blas1skin.TabIndex = 2;
            _left_page_blas1skin.Text = "Blasphemous Skins";
            _left_page_blas1skin.UseVisualStyleBackColor = false;
            _left_page_blas1skin.Click += ClickedBlas1Skins;
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
            _left_page_blas2mod.Location = new Point(0, 90);
            _left_page_blas2mod.Name = "_left_page_blas2mod";
            _left_page_blas2mod.Size = new Size(220, 35);
            _left_page_blas2mod.TabIndex = 3;
            _left_page_blas2mod.Text = "Blasphemous II Mods";
            _left_page_blas2mod.UseVisualStyleBackColor = false;
            _left_page_blas2mod.Click += ClickedBlas2Mods;
            // 
            // _left_page_divider
            // 
            _left_page_divider.Anchor = AnchorStyles.Bottom;
            _left_page_divider.BackColor = SystemColors.ButtonHighlight;
            _left_page_divider.Location = new Point(29, 143);
            _left_page_divider.Name = "_left_page_divider";
            _left_page_divider.Size = new Size(160, 1);
            _left_page_divider.TabIndex = 21;
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
            // _left_sort
            // 
            _left_sort.Controls.Add(_left_filter_options);
            _left_sort.Controls.Add(_left_filter_text);
            _left_sort.Controls.Add(_left_sort_options);
            _left_sort.Controls.Add(_left_sort_text);
            _left_sort.Controls.Add(_left_sort_divider);
            _left_sort.Location = new Point(15, 160);
            _left_sort.Name = "_left_sort";
            _left_sort.Size = new Size(220, 100);
            _left_sort.TabIndex = 13;
            // 
            // _left_filter_options
            // 
            _left_filter_options.DropDownStyle = ComboBoxStyle.DropDownList;
            _left_filter_options.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_filter_options.FormattingEnabled = true;
            _left_filter_options.Location = new Point(87, 55);
            _left_filter_options.Name = "_left_filter_options";
            _left_filter_options.Size = new Size(121, 26);
            _left_filter_options.TabIndex = 14;
            _left_filter_options.Visible = false;
            // 
            // _left_filter_text
            // 
            _left_filter_text.AutoSize = true;
            _left_filter_text.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            _left_filter_text.ForeColor = SystemColors.ButtonHighlight;
            _left_filter_text.Location = new Point(5, 55);
            _left_filter_text.Name = "_left_filter_text";
            _left_filter_text.Size = new Size(78, 20);
            _left_filter_text.TabIndex = 13;
            _left_filter_text.Text = "Filter by:";
            _left_filter_text.Visible = false;
            // 
            // _left_sort_options
            // 
            _left_sort_options.DropDownStyle = ComboBoxStyle.DropDownList;
            _left_sort_options.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_sort_options.FormattingEnabled = true;
            _left_sort_options.Location = new Point(87, 15);
            _left_sort_options.Name = "_left_sort_options";
            _left_sort_options.Size = new Size(121, 26);
            _left_sort_options.TabIndex = 12;
            _left_sort_options.SelectedIndexChanged += ChangedSortOption;
            // 
            // _left_sort_text
            // 
            _left_sort_text.AutoSize = true;
            _left_sort_text.Font = new Font("Trebuchet MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            _left_sort_text.ForeColor = SystemColors.ButtonHighlight;
            _left_sort_text.Location = new Point(5, 15);
            _left_sort_text.Name = "_left_sort_text";
            _left_sort_text.Size = new Size(67, 20);
            _left_sort_text.TabIndex = 11;
            _left_sort_text.Text = "Sort by:";
            // 
            // _left_sort_divider
            // 
            _left_sort_divider.Anchor = AnchorStyles.Bottom;
            _left_sort_divider.BackColor = SystemColors.ButtonHighlight;
            _left_sort_divider.Location = new Point(29, 98);
            _left_sort_divider.Name = "_left_sort_divider";
            _left_sort_divider.Size = new Size(160, 1);
            _left_sort_divider.TabIndex = 22;
            // 
            // _left_all
            // 
            _left_all.Controls.Add(_left_all_install);
            _left_all.Controls.Add(_left_all_enable);
            _left_all.Controls.Add(_left_all_uninstall);
            _left_all.Controls.Add(_left_all_disable);
            _left_all.Controls.Add(_left_all_divider);
            _left_all.Location = new Point(15, 260);
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
            // 
            // _left_all_divider
            // 
            _left_all_divider.Anchor = AnchorStyles.Bottom;
            _left_all_divider.BackColor = SystemColors.ButtonHighlight;
            _left_all_divider.Location = new Point(29, 118);
            _left_all_divider.Name = "_left_all_divider";
            _left_all_divider.Size = new Size(160, 1);
            _left_all_divider.TabIndex = 23;
            // 
            // _top
            // 
            _top.BackColor = Color.SpringGreen;
            _top.Controls.Add(_top_outer);
            _top.Dock = DockStyle.Top;
            _top.Location = new Point(250, 0);
            _top.Name = "_top";
            _top.Size = new Size(1334, 120);
            _top.TabIndex = 12;
            // 
            // _top_outer
            // 
            _top_outer.BackColor = Color.Black;
            _top_outer.Controls.Add(_top_inner);
            _top_outer.Dock = DockStyle.Fill;
            _top_outer.Location = new Point(0, 0);
            _top_outer.Name = "_top_outer";
            _top_outer.Size = new Size(1334, 120);
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
            _top_inner.Size = new Size(1334, 118);
            _top_inner.TabIndex = 1;
            // 
            // _top_warning_outer
            // 
            _top_warning_outer.Anchor = AnchorStyles.Right;
            _top_warning_outer.BackColor = Color.Red;
            _top_warning_outer.Controls.Add(_top_warning_inner);
            _top_warning_outer.Location = new Point(1084, 12);
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
            _top_warning_text.LinkClicked += ClickedVersionWarning;
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
            _top_text.Size = new Size(1334, 118);
            _top_text.TabIndex = 0;
            _top_text.Text = "Blasphemous Mods";
            _top_text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _middle_tools_icon
            // 
            _middle_tools_icon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _middle_tools_icon.BackColor = Color.Transparent;
            _middle_tools_icon.BackgroundImage = Properties.Resources.icon_check_light;
            _middle_tools_icon.BackgroundImageLayout = ImageLayout.Zoom;
            _middle_tools_icon.Cursor = Cursors.Hand;
            _middle_tools_icon.Location = new Point(150, 0);
            _middle_tools_icon.Name = "_middle_tools_icon";
            _middle_tools_icon.Size = new Size(25, 25);
            _middle_tools_icon.TabIndex = 8;
            _middle_tools_icon.TabStop = false;
            _middle_tools_icon.Click += ClickedToolsStatus;
            // 
            // _middle_tools_text
            // 
            _middle_tools_text.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _middle_tools_text.BackColor = Color.FromArgb(0, 0, 0, 0);
            _middle_tools_text.Cursor = Cursors.Hand;
            _middle_tools_text.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            _middle_tools_text.Location = new Point(0, 1);
            _middle_tools_text.Name = "_middle_tools_text";
            _middle_tools_text.Size = new Size(150, 25);
            _middle_tools_text.TabIndex = 7;
            _middle_tools_text.Text = "Modding Tools";
            _middle_tools_text.TextAlign = ContentAlignment.MiddleCenter;
            _middle_tools_text.Click += ClickedToolsStatus;
            // 
            // _bottom
            // 
            _bottom.BackColor = Color.Firebrick;
            _bottom.Controls.Add(_bottom_blas1mod);
            _bottom.Controls.Add(_bottom_blas1skin);
            _bottom.Controls.Add(_bottom_blas2mod);
            _bottom.Controls.Add(_bottom_validation);
            _bottom.Dock = DockStyle.Fill;
            _bottom.Location = new Point(250, 150);
            _bottom.Name = "_bottom";
            _bottom.Size = new Size(1334, 711);
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
            _bottom_blas1skin.Size = new Size(1334, 711);
            _bottom_blas1skin.TabIndex = 5;
            _bottom_blas1skin.Visible = false;
            // 
            // _bottom_blas1skin_scroll
            // 
            _bottom_blas1skin_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_blas1skin_scroll.Location = new Point(1298, 15);
            _bottom_blas1skin_scroll.Name = "_bottom_blas1skin_scroll";
            _bottom_blas1skin_scroll.Size = new Size(20, 650);
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
            _bottom_blas2mod.Size = new Size(1334, 711);
            _bottom_blas2mod.TabIndex = 4;
            _bottom_blas2mod.Visible = false;
            // 
            // _bottom_blas2mod_scroll
            // 
            _bottom_blas2mod_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_blas2mod_scroll.Location = new Point(1298, 15);
            _bottom_blas2mod_scroll.Name = "_bottom_blas2mod_scroll";
            _bottom_blas2mod_scroll.Size = new Size(20, 650);
            _bottom_blas2mod_scroll.TabIndex = 2;
            _bottom_blas2mod_scroll.Visible = false;
            // 
            // _middle
            // 
            _middle.BackColor = Color.MediumOrchid;
            _middle.Controls.Add(_middle_outer);
            _middle.Dock = DockStyle.Top;
            _middle.Location = new Point(250, 120);
            _middle.Name = "_middle";
            _middle.Size = new Size(1334, 30);
            _middle.TabIndex = 9;
            // 
            // _middle_outer
            // 
            _middle_outer.BackColor = Color.Black;
            _middle_outer.Controls.Add(_middle_inner);
            _middle_outer.Dock = DockStyle.Fill;
            _middle_outer.Location = new Point(0, 0);
            _middle_outer.Name = "_middle_outer";
            _middle_outer.Size = new Size(1334, 30);
            _middle_outer.TabIndex = 9;
            // 
            // _middle_inner
            // 
            _middle_inner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _middle_inner.BackColor = Color.FromArgb(80, 80, 80);
            _middle_inner.Controls.Add(_middle_path);
            _middle_inner.Controls.Add(_middle_tools);
            _middle_inner.Location = new Point(0, 0);
            _middle_inner.Name = "_middle_inner";
            _middle_inner.Size = new Size(1334, 28);
            _middle_inner.TabIndex = 0;
            // 
            // _middle_path
            // 
            _middle_path.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _middle_path.BackColor = Color.FromArgb(0, 0, 0, 0);
            _middle_path.Cursor = Cursors.Hand;
            _middle_path.Font = new Font("Trebuchet MS", 12F, FontStyle.Italic, GraphicsUnit.Point);
            _middle_path.Location = new Point(10, 2);
            _middle_path.Name = "_middle_path";
            _middle_path.Size = new Size(1000, 25);
            _middle_path.TabIndex = 9;
            _middle_path.Text = "Root Folder text";
            _middle_path.TextAlign = ContentAlignment.MiddleLeft;
            _middle_path.Click += ClickedRootFolder;
            // 
            // _middle_tools
            // 
            _middle_tools.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _middle_tools.BackColor = Color.FromArgb(80, 80, 80);
            _middle_tools.Controls.Add(_middle_tools_icon);
            _middle_tools.Controls.Add(_middle_tools_text);
            _middle_tools.Location = new Point(1140, 1);
            _middle_tools.Name = "_middle_tools";
            _middle_tools.Size = new Size(180, 25);
            _middle_tools.TabIndex = 9;
            _middle_tools.Visible = false;
            // 
            // _tooltip
            // 
            _tooltip.AutomaticDelay = 100;
            _tooltip.AutoPopDelay = 100000;
            _tooltip.InitialDelay = 100;
            _tooltip.ReshowDelay = 100;
            _tooltip.ShowAlways = true;
            // 
            // UIHandler
            // 
            AutoScaleDimensions = new SizeF(6F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1584, 861);
            Controls.Add(_bottom);
            Controls.Add(_middle);
            Controls.Add(_top);
            Controls.Add(_left);
            Font = new Font("Trebuchet MS", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1280, 720);
            Name = "UIHandler";
            _bottom_blas1mod.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)_middle_tools_icon).EndInit();
            _bottom.ResumeLayout(false);
            _bottom_blas1skin.ResumeLayout(false);
            _bottom_blas2mod.ResumeLayout(false);
            _middle.ResumeLayout(false);
            _middle_outer.ResumeLayout(false);
            _middle_inner.ResumeLayout(false);
            _middle_tools.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.VScrollBar _bottom_blas1mod_scroll;
        private System.Windows.Forms.Panel _bottom_blas1mod;
        private System.Windows.Forms.Panel _bottom_validation;
        private System.Windows.Forms.Label _top_text;
        private System.Windows.Forms.Panel _left_inner;
        private System.Windows.Forms.Panel _top_outer;
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
        private System.Windows.Forms.Label _left_sort_text;
        private System.Windows.Forms.Panel _left_sort;
        private System.Windows.Forms.Panel _left_page_divider;
        private System.Windows.Forms.Panel _left_sort_divider;
        private System.Windows.Forms.Panel _left_all_divider;
        private System.Windows.Forms.Panel _left_details_outer;
        private System.Windows.Forms.Panel _left_details_inner;
        private System.Windows.Forms.Label _left_details_name;
        private System.Windows.Forms.Label _left_details_desc;
        private System.Windows.Forms.Label _left_details_version;
        private System.Windows.Forms.Panel _left_all;
        private System.Windows.Forms.Panel _left_page;
        private Panel _bottom;
        private Panel _left;
        private Panel _top;
        private TransparentButton _left_page_blas1mod;
        private TransparentButton _left_page_blas1skin;
        private TransparentButton _left_page_blas2mod;
        private TransparentButton _left_all_install;
        private TransparentButton _left_all_disable;
        private TransparentButton _left_all_enable;
        private TransparentButton _left_all_uninstall;
        private ButtonWithCutoff _left_startModded;
        private ButtonWithCutoff _left_startVanilla;
        private Label _middle_tools_text;
        private PictureBox _middle_tools_icon;
        private Panel _middle;
        private Panel _middle_outer;
        private Panel _middle_inner;
        private ToolTip _tooltip;
        private Panel _middle_tools;
        private Label _middle_path;
        private ComboBox _left_sort_options;
        private Label _left_filter_text;
        private ComboBox _left_filter_options;
    }
}

