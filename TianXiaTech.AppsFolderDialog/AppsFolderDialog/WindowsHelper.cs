using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace AppsFolderDialog
{
    internal class WindowsHelper
    {
        public const uint SWP_SHOWWINDOW = 0x0040;
        public const uint WM_CLOSE = 0x0010;

        [DllImport("User32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("User32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref tagRECT lpRect);

        [DllImport("User32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd,uint Msg, IntPtr wParam, IntPtr lParam);


        public struct tagRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}
