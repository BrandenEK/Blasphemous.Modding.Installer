namespace Blasphemous.Modding.Installer.Prompts;

partial class SkinPreviewPrompt
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
        _text = new Label();
        SuspendLayout();
        // 
        // _text
        // 
        _text.Dock = DockStyle.Fill;
        _text.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        _text.ForeColor = Color.FromArgb(191, 175, 152);
        _text.Location = new Point(0, 0);
        _text.Name = "_text";
        _text.Size = new Size(784, 561);
        _text.TabIndex = 0;
        _text.Text = "Loading preview...";
        _text.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // SkinPreviewPrompt
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(17, 8, 3);
        BackgroundImageLayout = ImageLayout.Center;
        ClientSize = new Size(784, 561);
        Controls.Add(_text);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SkinPreviewPrompt";
        StartPosition = FormStartPosition.CenterParent;
        Text = "SKIN_NAME";
        ResumeLayout(false);
    }

    #endregion

    private Label _text;
}