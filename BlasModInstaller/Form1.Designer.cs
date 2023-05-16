
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
            this.fakePanel = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.blasLocButton = new System.Windows.Forms.Button();
            this.debugBtn = new System.Windows.Forms.Button();
            this.blasLocFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.blasLocDialog = new System.Windows.Forms.OpenFileDialog();
            this.debugText = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.modHolder.SuspendLayout();
            this.fakePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // scroll
            // 
            this.scroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scroll.Location = new System.Drawing.Point(849, 14);
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(20, 440);
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
            this.modHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.modHolder.Controls.Add(this.scroll);
            this.modHolder.Controls.Add(this.fakePanel);
            this.modHolder.Location = new System.Drawing.Point(0, 60);
            this.modHolder.Name = "modHolder";
            this.modHolder.Size = new System.Drawing.Size(885, 501);
            this.modHolder.TabIndex = 3;
            // 
            // fakePanel
            // 
            this.fakePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fakePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.fakePanel.Controls.Add(this.vScrollBar1);
            this.fakePanel.Controls.Add(this.blasLocButton);
            this.fakePanel.Location = new System.Drawing.Point(0, 0);
            this.fakePanel.Name = "fakePanel";
            this.fakePanel.Size = new System.Drawing.Size(885, 501);
            this.fakePanel.TabIndex = 4;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(900, -107);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 714);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Visible = false;
            // 
            // blasLocButton
            // 
            this.blasLocButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.blasLocButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocButton.Location = new System.Drawing.Point(327, 200);
            this.blasLocButton.Name = "blasLocButton";
            this.blasLocButton.Size = new System.Drawing.Size(228, 56);
            this.blasLocButton.TabIndex = 7;
            this.blasLocButton.Text = "Locate Blasphemous.exe";
            this.blasLocButton.UseVisualStyleBackColor = true;
            this.blasLocButton.Click += new System.EventHandler(this.ChooseBlasLocation);
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
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Trebuchet MS", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(320, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(250, 35);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Blasphemous Mods";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.debugText);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.modHolder);
            this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "Blasphemous Mod Installer";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.modHolder.ResumeLayout(false);
            this.fakePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label debugText;
        private System.Windows.Forms.Label titleLabel;
    }
}

