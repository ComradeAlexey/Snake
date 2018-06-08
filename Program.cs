using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Snake
{
    public enum DirectionMove
    {
        up,
        down,
        left,
        right
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inizialize();
            Game.StartGame();
            Game.Update();
            Game.GameOver();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos
        (
            IntPtr hWnd,
            int hWndInsertAfter,
            int x,
            int Y,
            int cx,
            int cy,
            int wFlags
        );

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static void Inizialize()
        {
            var wndRect = new RECT();
            var cWidth = wndRect.Left;
            var cHeight = wndRect.Top;
            var SWP_NOSIZE = 0x1;
            var HWND_TOPMOST = -1;
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            SetWindowPos
            (
                handle, HWND_TOPMOST,
                0, 0, 0, 0, SWP_NOSIZE
            );
        }
    }
}
//Спасибо Михе и Маше за моральную поддержку, Вы самые лучшие! 