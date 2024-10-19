using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace KeySpammer
{
    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern int ToUnicode(
            uint wVirtKey,
            uint wScanCode,
            byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff,
            int cchBuff,
            uint wFlags);

        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        // Import MapVirtualKey function from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        public static string GetPrintableKey(int vkCode)
        {
            var keyboardState = new byte[256];
            if (!GetKeyboardState(keyboardState))
            {
                return string.Empty; // Return empty if we can't get the keyboard state
            }

            // Create a buffer to hold the resulting characters
            var result = new StringBuilder(2);

            // Get the scan code for the key
            var scanCode = MapVirtualKey((uint)vkCode, MAPVK_VK_TO_CHAR);

            // Convert virtual key code to Unicode
            var charsReturned = ToUnicode((uint)vkCode, scanCode, keyboardState, result, result.Capacity, 0);

            return charsReturned > 0 ? result.ToString() : ((Keys)vkCode).ToString();
        }

        private const uint MAPVK_VK_TO_CHAR = 2;

        public struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        public const int INPUT_KEYBOARD = 1;
        public const uint KEYEVENTF_KEYUP = 0x0002;
        public const uint KEYEVENTF_SCANCODE = 0x0008;
    }
}
