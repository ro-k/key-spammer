using System.Runtime.InteropServices;

namespace KeySpammer
{
    public static class InputSender
    {
        public static async Task SendKey(ushort scanCode, int duration)
        {
            // Create a key down input
            var keyDown = new User32.INPUT
            {
                type = User32.INPUT_KEYBOARD,
                u = new User32.InputUnion
                {
                    ki = new User32.KEYBDINPUT
                    {
                        wScan = scanCode,
                        dwFlags = User32.KEYEVENTF_SCANCODE
                    }
                }
            };

            // Create a key up input
            var keyUp = new User32.INPUT
            {
                type = User32.INPUT_KEYBOARD,
                u = new User32.InputUnion
                {
                    ki = new User32.KEYBDINPUT
                    {
                        wScan = scanCode,
                        dwFlags = User32.KEYEVENTF_SCANCODE | User32.KEYEVENTF_KEYUP
                    }
                }
            };

            // Send key down
            User32.SendInput(1, new[] { keyDown }, Marshal.SizeOf(typeof(User32.INPUT)));

            // Wait for the specified duration
            await Task.Delay(duration);

            // Send key up
            User32.SendInput(1, new[] { keyUp }, Marshal.SizeOf(typeof(User32.INPUT)));
        }
    }

}
