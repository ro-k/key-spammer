using System.Runtime.InteropServices;


namespace KeySpammer
{
    public static class KeyConverter
    {
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private const uint MAPVK_VK_TO_VSC = 0x00;

        public static ushort CharToScanCode(char character)
        {
            // Convert the character to upper case to match standard key mappings
            character = char.ToUpper(character);

            // Get the virtual key code for the character
            var key = (Keys)Enum.Parse(typeof(Keys), character.ToString());

            // Convert the virtual key code to a scan code
            return (ushort)MapVirtualKey((uint)key, MAPVK_VK_TO_VSC);
        }
    }
}