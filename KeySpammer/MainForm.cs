// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace KeySpammer
{
    public partial class MainForm : Form
    {
        private const int HOTKEY_ID = 1;
        private const int MOD_NONE = 0x0000;
        private int _vkHotkey = 0xDC; // \ key

        private string _keySequence = "";
        private int _initialDelay;
        private int _keyHoldTime;
        private int _currentDelay;
        private bool _isRunning;
        private bool _enabled = true;

        public MainForm()
        {
            InitializeComponent();

            User32.RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, _vkHotkey);
        }

        protected override void WndProc(ref Message m)
        {
            if (!_enabled)
                return;

            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                if (!_isRunning)
                {
                    StartSequence();
                }
            }
            base.WndProc(ref m);
        }

        private async void StartSequence()
        {
            _isRunning = true;
            _keySequence = textBoxKeySequence.Text;
            _initialDelay = int.Parse(textBoxDelay.Text);
            _keyHoldTime = int.Parse(textBoxHoldTime.Text);
            _currentDelay = _initialDelay;

            while (_enabled && _isRunning && User32.GetAsyncKeyState((Keys)_vkHotkey) < 0) // Loop while \ key is pressed
            {
                foreach (var t in _keySequence)
                {
                    if (!_isRunning || User32.GetAsyncKeyState((Keys)_vkHotkey) >= 0) // Check if key is released
                    {
                        _isRunning = false;
                        break;
                    }

                    await HoldKey(t);

                    await Task.Delay(_currentDelay);
                }
            }

            _isRunning = false;
        }

        private async Task HoldKey(char key)
        {
            await InputSender.SendKey(KeyConverter.CharToScanCode(key), _keyHoldTime);
            await Task.Delay(_keyHoldTime);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            User32.UnregisterHotKey(this.Handle, HOTKEY_ID);
            base.OnFormClosing(e);
        }

        private void NumericTextOnly(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CheckBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is not CheckBox checkBox) return;

            _enabled = checkBox.Checked;

            if (_enabled)
                User32.RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, _vkHotkey);
            else
                User32.UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        private void TextBoxHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            User32.UnregisterHotKey(this.Handle, HOTKEY_ID);

            _vkHotkey = e.KeyValue;

            textBoxHotkey.Text = User32.GetPrintableKey(_vkHotkey);

            User32.RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, _vkHotkey);

            e.SuppressKeyPress = true;
        }
    }
}
