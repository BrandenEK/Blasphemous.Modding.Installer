
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
            this.blasLocText = new System.Windows.Forms.Label();
            this.debugBtn = new System.Windows.Forms.Button();
            this.blasLocBox = new System.Windows.Forms.TextBox();
            this.blasLocButton = new System.Windows.Forms.Button();
            this.blasLocFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.blasLocDialog = new System.Windows.Forms.OpenFileDialog();
            this.modHolder.SuspendLayout();
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
            // blasLocText
            // 
            this.blasLocText.AutoSize = true;
            this.blasLocText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocText.Location = new System.Drawing.Point(12, 9);
            this.blasLocText.Name = "blasLocText";
            this.blasLocText.Size = new System.Drawing.Size(186, 18);
            this.blasLocText.TabIndex = 4;
            this.blasLocText.Text = "Blasphemous.exe location:";
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(677, 29);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(75, 26);
            this.debugBtn.TabIndex = 5;
            this.debugBtn.Text = "Debug";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.ClickedDebug);
            // 
            // blasLocBox
            // 
            this.blasLocBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocBox.Location = new System.Drawing.Point(227, 9);
            this.blasLocBox.Name = "blasLocBox";
            this.blasLocBox.Size = new System.Drawing.Size(224, 24);
            this.blasLocBox.TabIndex = 6;
            // 
            // blasLocButton
            // 
            this.blasLocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blasLocButton.Location = new System.Drawing.Point(457, 10);
            this.blasLocButton.Name = "blasLocButton";
            this.blasLocButton.Size = new System.Drawing.Size(25, 25);
            this.blasLocButton.TabIndex = 7;
            this.blasLocButton.Text = "...";
            this.blasLocButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.blasLocButton.UseVisualStyleBackColor = true;
            this.blasLocButton.Click += new System.EventHandler(this.ChooseBlasLocation);
            // 
            // blasLocDialog
            // 
            this.blasLocDialog.FileName = "Blasphemous.exe";
            this.blasLocDialog.Filter = "Exe files (*.exe)|*.exe";
            this.blasLocDialog.Title = "Choose Blasphemous.exe location";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.blasLocButton);
            this.Controls.Add(this.blasLocBox);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.blasLocText);
            this.Controls.Add(this.modHolder);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Blasphemous Mod Installer";
            this.modHolder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.VScrollBar scroll;
        private System.Windows.Forms.Panel modHolder;
        private System.Windows.Forms.Label blasLocText;
        private System.Windows.Forms.Button debugBtn;
        private System.Windows.Forms.TextBox blasLocBox;
        private System.Windows.Forms.Button blasLocButton;
        private System.Windows.Forms.FolderBrowserDialog blasLocFolderDialog;
        private System.Windows.Forms.OpenFileDialog blasLocDialog;
    }
}

