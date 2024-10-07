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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIHandler));
            _bottom_holder_scroll = new VScrollBar();
            _bottom_holder = new Panel();
            _left = new Panel();
            _left_outer = new Panel();
            _left_inner = new Panel();
            _left_holder = new Panel();
            _left_start = new Panel();
            _left_start_console = new CheckBox();
            _left_start_modded = new CheckBox();
            _left_start_button = new TransparentButton();
            _left_start_divider = new Panel();
            _left_all = new Panel();
            _left_all_install = new TransparentButton();
            _left_all_enable = new TransparentButton();
            _left_all_uninstall = new TransparentButton();
            _left_all_disable = new TransparentButton();
            _left_all_divider = new Panel();
            _left_sort = new Panel();
            _left_filter_options = new ComboBox();
            _left_filter_text = new Label();
            _left_sort_options = new ComboBox();
            _left_sort_text = new Label();
            _left_sort_divider = new Panel();
            _left_details = new Panel();
            _left_details_divider = new Panel();
            _left_details_outer = new Panel();
            _left_details_inner = new Panel();
            _left_details_version = new Label();
            _left_details_desc = new Label();
            _left_details_name = new Label();
            _left_page = new Panel();
            _left_page_blas1mod = new TransparentButton();
            _left_page_blas1skin = new TransparentButton();
            _left_page_blas2mod = new TransparentButton();
            _left_page_divider = new Panel();
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
            _middle = new Panel();
            _middle_outer = new Panel();
            _middle_inner = new Panel();
            _middle_path = new Label();
            _middle_tools = new Panel();
            _bottom_holder.SuspendLayout();
            _left.SuspendLayout();
            _left_outer.SuspendLayout();
            _left_inner.SuspendLayout();
            _left_holder.SuspendLayout();
            _left_start.SuspendLayout();
            _left_all.SuspendLayout();
            _left_sort.SuspendLayout();
            _left_details.SuspendLayout();
            _left_details_outer.SuspendLayout();
            _left_details_inner.SuspendLayout();
            _left_page.SuspendLayout();
            _top.SuspendLayout();
            _top_outer.SuspendLayout();
            _top_inner.SuspendLayout();
            _top_warning_outer.SuspendLayout();
            _top_warning_inner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_top_warning_image).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_middle_tools_icon).BeginInit();
            _bottom.SuspendLayout();
            _middle.SuspendLayout();
            _middle_outer.SuspendLayout();
            _middle_inner.SuspendLayout();
            _middle_tools.SuspendLayout();
            SuspendLayout();
            // 
            // _bottom_holder_scroll
            // 
            _bottom_holder_scroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _bottom_holder_scroll.Location = new Point(2318, 15);
            _bottom_holder_scroll.Name = "_bottom_holder_scroll";
            _bottom_holder_scroll.Size = new Size(20, 633);
            _bottom_holder_scroll.TabIndex = 2;
            _bottom_holder_scroll.Visible = false;
            // 
            // _bottom_holder
            // 
            _bottom_holder.AutoScroll = true;
            _bottom_holder.AutoScrollMargin = new Size(0, 15);
            _bottom_holder.BackColor = Color.FromArgb(52, 52, 52);
            _bottom_holder.Controls.Add(_bottom_holder_scroll);
            _bottom_holder.Dock = DockStyle.Fill;
            _bottom_holder.Location = new Point(0, 0);
            _bottom_holder.Name = "_bottom_holder";
            _bottom_holder.Size = new Size(1334, 711);
            _bottom_holder.TabIndex = 3;
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
            _left_inner.Controls.Add(_left_holder);
            _left_inner.Location = new Point(0, 0);
            _left_inner.Name = "_left_inner";
            _left_inner.Size = new Size(248, 861);
            _left_inner.TabIndex = 8;
            // 
            // _left_holder
            // 
            _left_holder.Controls.Add(_left_start);
            _left_holder.Controls.Add(_left_all);
            _left_holder.Controls.Add(_left_sort);
            _left_holder.Controls.Add(_left_details);
            _left_holder.Controls.Add(_left_page);
            _left_holder.Location = new Point(15, 15);
            _left_holder.Name = "_left_holder";
            _left_holder.Size = new Size(220, 800);
            _left_holder.TabIndex = 26;
            // 
            // _left_start
            // 
            _left_start.Controls.Add(_left_start_console);
            _left_start.Controls.Add(_left_start_modded);
            _left_start.Controls.Add(_left_start_button);
            _left_start.Controls.Add(_left_start_divider);
            _left_start.Dock = DockStyle.Top;
            _left_start.Location = new Point(0, 545);
            _left_start.Name = "_left_start";
            _left_start.Size = new Size(220, 120);
            _left_start.TabIndex = 24;
            // 
            // _left_start_console
            // 
            _left_start_console.AutoSize = true;
            _left_start_console.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_start_console.ForeColor = SystemColors.ButtonHighlight;
            _left_start_console.Location = new Point(20, 42);
            _left_start_console.Name = "_left_start_console";
            _left_start_console.Size = new Size(125, 22);
            _left_start_console.TabIndex = 25;
            _left_start_console.Text = "Run with console";
            _left_start_console.UseVisualStyleBackColor = true;
            _left_start_console.CheckedChanged += CheckedStartOption;
            // 
            // _left_start_modded
            // 
            _left_start_modded.AutoSize = true;
            _left_start_modded.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            _left_start_modded.ForeColor = SystemColors.ButtonHighlight;
            _left_start_modded.Location = new Point(20, 15);
            _left_start_modded.Name = "_left_start_modded";
            _left_start_modded.Size = new Size(99, 22);
            _left_start_modded.TabIndex = 24;
            _left_start_modded.Text = "Run modded";
            _left_start_modded.UseVisualStyleBackColor = true;
            _left_start_modded.CheckedChanged += CheckedStartOption;
            // 
            // _left_start_button
            // 
            _left_start_button.BackColor = Color.FromArgb(30, 30, 30);
            _left_start_button.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            _left_start_button.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            _left_start_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            _left_start_button.FlatStyle = FlatStyle.Flat;
            _left_start_button.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_start_button.ForeColor = SystemColors.ButtonHighlight;
            _left_start_button.Location = new Point(35, 70);
            _left_start_button.Name = "_left_start_button";
            _left_start_button.Size = new Size(150, 35);
            _left_start_button.TabIndex = 4;
            _left_start_button.Text = "Launch game";
            _left_start_button.UseVisualStyleBackColor = false;
            _left_start_button.Click += ClickedStart;
            // 
            // _left_start_divider
            // 
            _left_start_divider.Anchor = AnchorStyles.Bottom;
            _left_start_divider.BackColor = SystemColors.ButtonHighlight;
            _left_start_divider.Location = new Point(29, 118);
            _left_start_divider.Name = "_left_start_divider";
            _left_start_divider.Size = new Size(160, 1);
            _left_start_divider.TabIndex = 23;
            _left_start_divider.Visible = false;
            // 
            // _left_all
            // 
            _left_all.Controls.Add(_left_all_install);
            _left_all.Controls.Add(_left_all_enable);
            _left_all.Controls.Add(_left_all_uninstall);
            _left_all.Controls.Add(_left_all_disable);
            _left_all.Controls.Add(_left_all_divider);
            _left_all.Dock = DockStyle.Top;
            _left_all.Location = new Point(0, 435);
            _left_all.Name = "_left_all";
            _left_all.Size = new Size(220, 110);
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
            _left_all_install.Location = new Point(5, 15);
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
            _left_all_enable.Location = new Point(5, 60);
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
            _left_all_uninstall.Location = new Point(115, 15);
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
            _left_all_disable.Location = new Point(115, 60);
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
            _left_all_divider.Location = new Point(29, 108);
            _left_all_divider.Name = "_left_all_divider";
            _left_all_divider.Size = new Size(160, 1);
            _left_all_divider.TabIndex = 23;
            // 
            // _left_sort
            // 
            _left_sort.Controls.Add(_left_filter_options);
            _left_sort.Controls.Add(_left_filter_text);
            _left_sort.Controls.Add(_left_sort_options);
            _left_sort.Controls.Add(_left_sort_text);
            _left_sort.Controls.Add(_left_sort_divider);
            _left_sort.Dock = DockStyle.Top;
            _left_sort.Location = new Point(0, 335);
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
            _left_filter_options.SelectedIndexChanged += ChangedFilterOption;
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
            // _left_details
            // 
            _left_details.Controls.Add(_left_details_divider);
            _left_details.Controls.Add(_left_details_outer);
            _left_details.Dock = DockStyle.Top;
            _left_details.Location = new Point(0, 145);
            _left_details.Name = "_left_details";
            _left_details.Size = new Size(220, 190);
            _left_details.TabIndex = 25;
            // 
            // _left_details_divider
            // 
            _left_details_divider.Anchor = AnchorStyles.Bottom;
            _left_details_divider.BackColor = SystemColors.ButtonHighlight;
            _left_details_divider.Location = new Point(29, 188);
            _left_details_divider.Name = "_left_details_divider";
            _left_details_divider.Size = new Size(160, 1);
            _left_details_divider.TabIndex = 22;
            // 
            // _left_details_outer
            // 
            _left_details_outer.BackColor = Color.Black;
            _left_details_outer.Controls.Add(_left_details_inner);
            _left_details_outer.Location = new Point(0, 20);
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
            _left_details_version.BackColor = Color.FromArgb(40, 40, 40);
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
            _left_details_desc.BackColor = Color.FromArgb(40, 40, 40);
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
            _left_details_name.BackColor = Color.FromArgb(40, 40, 40);
            _left_details_name.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _left_details_name.ForeColor = Color.White;
            _left_details_name.Location = new Point(3, 5);
            _left_details_name.Name = "_left_details_name";
            _left_details_name.Size = new Size(210, 20);
            _left_details_name.TabIndex = 0;
            _left_details_name.Text = "Name";
            _left_details_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _left_page
            // 
            _left_page.Controls.Add(_left_page_blas1mod);
            _left_page.Controls.Add(_left_page_blas1skin);
            _left_page.Controls.Add(_left_page_blas2mod);
            _left_page.Controls.Add(_left_page_divider);
            _left_page.Dock = DockStyle.Top;
            _left_page.Location = new Point(0, 0);
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
            _middle_tools_icon.BackColor = SystemColors.WindowFrame;
            _middle_tools_icon.BackgroundImageLayout = ImageLayout.Zoom;
            _middle_tools_icon.Cursor = Cursors.Hand;
            _middle_tools_icon.Dock = DockStyle.Right;
            _middle_tools_icon.Location = new Point(272, 0);
            _middle_tools_icon.Name = "_middle_tools_icon";
            _middle_tools_icon.Size = new Size(28, 26);
            _middle_tools_icon.TabIndex = 8;
            _middle_tools_icon.TabStop = false;
            _middle_tools_icon.Click += ClickedToolsStatus;
            // 
            // _middle_tools_text
            // 
            _middle_tools_text.BackColor = SystemColors.WindowFrame;
            _middle_tools_text.Cursor = Cursors.Hand;
            _middle_tools_text.Dock = DockStyle.Fill;
            _middle_tools_text.Font = new Font("Trebuchet MS", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            _middle_tools_text.Location = new Point(0, 0);
            _middle_tools_text.Name = "_middle_tools_text";
            _middle_tools_text.Size = new Size(272, 26);
            _middle_tools_text.TabIndex = 7;
            _middle_tools_text.Text = "Modding tools";
            _middle_tools_text.TextAlign = ContentAlignment.MiddleRight;
            _middle_tools_text.Click += ClickedToolsStatus;
            // 
            // _bottom
            // 
            _bottom.BackColor = Color.Firebrick;
            _bottom.Controls.Add(_bottom_holder);
            _bottom.Dock = DockStyle.Fill;
            _bottom.Location = new Point(250, 150);
            _bottom.Name = "_bottom";
            _bottom.Size = new Size(1334, 711);
            _bottom.TabIndex = 10;
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
            _middle_inner.BackColor = SystemColors.WindowFrame;
            _middle_inner.Controls.Add(_middle_path);
            _middle_inner.Controls.Add(_middle_tools);
            _middle_inner.Location = new Point(0, 0);
            _middle_inner.Name = "_middle_inner";
            _middle_inner.Size = new Size(1334, 28);
            _middle_inner.TabIndex = 0;
            // 
            // _middle_path
            // 
            _middle_path.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _middle_path.BackColor = SystemColors.WindowFrame;
            _middle_path.Cursor = Cursors.Hand;
            _middle_path.Font = new Font("Trebuchet MS", 12F, FontStyle.Italic, GraphicsUnit.Point);
            _middle_path.Location = new Point(10, 0);
            _middle_path.Name = "_middle_path";
            _middle_path.Size = new Size(1000, 28);
            _middle_path.TabIndex = 9;
            _middle_path.Text = "Root Folder text";
            _middle_path.TextAlign = ContentAlignment.MiddleLeft;
            _middle_path.Click += ClickedRootFolder;
            // 
            // _middle_tools
            // 
            _middle_tools.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _middle_tools.BackColor = SystemColors.WindowFrame;
            _middle_tools.Controls.Add(_middle_tools_text);
            _middle_tools.Controls.Add(_middle_tools_icon);
            _middle_tools.Location = new Point(1000, 1);
            _middle_tools.Name = "_middle_tools";
            _middle_tools.Size = new Size(300, 26);
            _middle_tools.TabIndex = 9;
            _middle_tools.Visible = false;
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
            _bottom_holder.ResumeLayout(false);
            _left.ResumeLayout(false);
            _left_outer.ResumeLayout(false);
            _left_inner.ResumeLayout(false);
            _left_holder.ResumeLayout(false);
            _left_start.ResumeLayout(false);
            _left_start.PerformLayout();
            _left_all.ResumeLayout(false);
            _left_sort.ResumeLayout(false);
            _left_sort.PerformLayout();
            _left_details.ResumeLayout(false);
            _left_details_outer.ResumeLayout(false);
            _left_details_inner.ResumeLayout(false);
            _left_page.ResumeLayout(false);
            _top.ResumeLayout(false);
            _top_outer.ResumeLayout(false);
            _top_inner.ResumeLayout(false);
            _top_warning_outer.ResumeLayout(false);
            _top_warning_inner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_top_warning_image).EndInit();
            ((System.ComponentModel.ISupportInitialize)_middle_tools_icon).EndInit();
            _bottom.ResumeLayout(false);
            _middle.ResumeLayout(false);
            _middle_outer.ResumeLayout(false);
            _middle_inner.ResumeLayout(false);
            _middle_tools.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.VScrollBar _bottom_holder_scroll;
        private System.Windows.Forms.Panel _bottom_holder;
        private System.Windows.Forms.Label _top_text;
        private System.Windows.Forms.Panel _left_inner;
        private System.Windows.Forms.Panel _top_outer;
        private System.Windows.Forms.PictureBox _top_warning_image;
        private System.Windows.Forms.Panel _top_warning_outer;
        private System.Windows.Forms.Panel _top_warning_inner;
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
        private Label _middle_tools_text;
        private PictureBox _middle_tools_icon;
        private Panel _middle;
        private Panel _middle_outer;
        private Panel _middle_inner;
        private Panel _middle_tools;
        private Label _middle_path;
        private ComboBox _left_sort_options;
        private Label _left_filter_text;
        private ComboBox _left_filter_options;
        private Panel _left_start;
        private TransparentButton _left_start_button;
        private Panel _left_start_divider;
        private CheckBox _left_start_modded;
        private CheckBox _left_start_console;
        private Panel _left_details;
        private Panel _left_details_divider;
        private Panel _left_holder;
    }
}

