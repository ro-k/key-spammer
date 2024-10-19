namespace KeySpammer;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        labelKeySequence = new Label();
        lebelDelay = new Label();
        labelKeyHoldTime = new Label();
        textBoxKeySequence = new TextBox();
        textBoxDelay = new TextBox();
        textBoxHoldTime = new TextBox();
        checkBoxEnabled = new CheckBox();
        textBoxHotkey = new TextBox();
        labelHotkey = new Label();
        SuspendLayout();
        // 
        // labelKeySequence
        // 
        labelKeySequence.AutoSize = true;
        labelKeySequence.Location = new Point(12, 9);
        labelKeySequence.Name = "labelKeySequence";
        labelKeySequence.Size = new Size(80, 15);
        labelKeySequence.TabIndex = 0;
        labelKeySequence.Text = "Key Sequence";
        // 
        // lebelDelay
        // 
        lebelDelay.AutoSize = true;
        lebelDelay.Location = new Point(12, 54);
        lebelDelay.Name = "lebelDelay";
        lebelDelay.Size = new Size(36, 15);
        lebelDelay.TabIndex = 1;
        lebelDelay.Text = "Delay";
        // 
        // labelKeyHoldTime
        // 
        labelKeyHoldTime.AutoSize = true;
        labelKeyHoldTime.Location = new Point(12, 99);
        labelKeyHoldTime.Name = "labelKeyHoldTime";
        labelKeyHoldTime.Size = new Size(80, 15);
        labelKeyHoldTime.TabIndex = 2;
        labelKeyHoldTime.Text = "Key hold time";
        // 
        // textBoxKeySequence
        // 
        textBoxKeySequence.Location = new Point(12, 27);
        textBoxKeySequence.Name = "textBoxKeySequence";
        textBoxKeySequence.Size = new Size(100, 23);
        textBoxKeySequence.TabIndex = 3;
        textBoxKeySequence.TextAlign = HorizontalAlignment.Center;
        // 
        // textBoxDelay
        // 
        textBoxDelay.Location = new Point(12, 72);
        textBoxDelay.Name = "textBoxDelay";
        textBoxDelay.Size = new Size(100, 23);
        textBoxDelay.TabIndex = 4;
        textBoxDelay.Text = "50";
        textBoxDelay.TextAlign = HorizontalAlignment.Center;
        textBoxDelay.KeyPress += NumericTextOnly;
        // 
        // textBoxHoldTime
        // 
        textBoxHoldTime.Location = new Point(12, 117);
        textBoxHoldTime.Name = "textBoxHoldTime";
        textBoxHoldTime.Size = new Size(100, 23);
        textBoxHoldTime.TabIndex = 5;
        textBoxHoldTime.Text = "50";
        textBoxHoldTime.TextAlign = HorizontalAlignment.Center;
        textBoxHoldTime.KeyPress += NumericTextOnly;
        // 
        // checkBoxEnabled
        // 
        checkBoxEnabled.AutoSize = true;
        checkBoxEnabled.Checked = true;
        checkBoxEnabled.CheckState = CheckState.Checked;
        checkBoxEnabled.Location = new Point(12, 146);
        checkBoxEnabled.Name = "checkBoxEnabled";
        checkBoxEnabled.Size = new Size(68, 19);
        checkBoxEnabled.TabIndex = 6;
        checkBoxEnabled.Text = "Enabled";
        checkBoxEnabled.UseVisualStyleBackColor = true;
        checkBoxEnabled.CheckedChanged += CheckBoxEnabled_CheckedChanged;
        // 
        // textBoxHotkey
        // 
        textBoxHotkey.Location = new Point(12, 199);
        textBoxHotkey.Name = "textBoxHotkey";
        textBoxHotkey.Size = new Size(100, 23);
        textBoxHotkey.TabIndex = 7;
        textBoxHotkey.Text = "\\";
        textBoxHotkey.TextAlign = HorizontalAlignment.Center;
        textBoxHotkey.KeyDown += TextBoxHotkey_KeyDown;
        // 
        // labelHotkey
        // 
        labelHotkey.AutoSize = true;
        labelHotkey.Location = new Point(12, 181);
        labelHotkey.Name = "labelHotkey";
        labelHotkey.Size = new Size(45, 15);
        labelHotkey.TabIndex = 8;
        labelHotkey.Text = "Hotkey";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(128, 234);
        Controls.Add(labelHotkey);
        Controls.Add(textBoxHotkey);
        Controls.Add(checkBoxEnabled);
        Controls.Add(textBoxHoldTime);
        Controls.Add(textBoxDelay);
        Controls.Add(textBoxKeySequence);
        Controls.Add(labelKeyHoldTime);
        Controls.Add(lebelDelay);
        Controls.Add(labelKeySequence);
        Name = "MainForm";
        Text = "KeySpammer";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelKeySequence;
    private Label lebelDelay;
    private Label labelKeyHoldTime;
    private TextBox textBoxKeySequence;
    private TextBox textBoxDelay;
    private TextBox textBoxHoldTime;
    private CheckBox checkBoxEnabled;
    private TextBox textBoxHotkey;
    private Label labelHotkey;
}