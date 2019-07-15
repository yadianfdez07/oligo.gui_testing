using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TestMonkey.UI
{
    public enum MouseButtons
    {
        Right,
        Left,
        Wheel
    }

    public class MouseAPI
    {
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        private const int MOUSEEVENTF_LEFTDOWN = 0x2;

        private const int MOUSEEVENTF_LEFTUP = 0x4;

        private const int MOUSEEVENTF_MOVE = 0x1;

        private const int MOUSEEVENTF_RIGHTDOWN = 0x8;

        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private const int MOUSEEVENTF_WHEEL = 0x800;

        private const int SM_CXSCREEN = 0;

        private const int SM_CYSCREEN = 1;

        private const int MOUSE_MICKEYS = 65535;

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        public static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetCursorPos([MarshalAs(UnmanagedType.Struct)] ref POINTAPI lpPoint);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder lpString, int cch);

        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);



        public static bool ClickMouse(MouseButtons button, int pixelX, int pixelY, int wlTurn, int dwExtraInfo)
        {
            int mouseEvent;

            switch (button)
            {
                case MouseButtons.Right:
                    mouseEvent = MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP;
                    break;
                case MouseButtons.Left:
                    mouseEvent = MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
                    break;
                case MouseButtons.Wheel:
                    mouseEvent = MOUSEEVENTF_WHEEL;
                    break;
                default:
                    return false;
            }

            mouse_event(mouseEvent, pixelX, pixelY, wlTurn, dwExtraInfo);
            return true;
        }

        private static void PixelsToMickeys(ref int pixelX, ref int pixelY)
        {
            int resX = 0;
            int resY = 0;

            resX = GetSystemMetrics(SM_CXSCREEN);
            resY = GetSystemMetrics(SM_CYSCREEN);

            pixelX %= resX + 1;
            pixelY %= resY + 1;

            int mickeys = MOUSE_MICKEYS;

            pixelX = (int) (pixelX * (mickeys / resX));
            pixelY = (int) (pixelY * (mickeys / resY));
        }

        public static void MoveMouse(int iHndl, int pixelX, int pixelY)
        {
            PixelsToMickeys(ref pixelX, ref pixelY);
            mouse_event(MOUSEEVENTF_ABSOLUTE|MOUSEEVENTF_MOVE, pixelX, pixelY, 0, 0);
        }

        public static void GetSmartInfo(ref int wHdl, ref StringBuilder clsName, ref StringBuilder wndText)
        {
            POINTAPI pnt = new POINTAPI();
            GetCursorPos(ref pnt);
            wHdl = WindowFromPoint(pnt.x, pnt.y);
            GetClassName(wHdl, clsName, 128);
            GetWindowText(wHdl, wndText, 128);
        }
    }
}