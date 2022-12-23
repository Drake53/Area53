// ------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Area53.WinForms.Native
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollInfo(IntPtr hWnd, int fnBar, ref ScrollInfo lpsi);

        [DllImport("user32.dll")]
        public static extern int SetScrollInfo(IntPtr hWnd, int fnBar, [In] ref ScrollInfo lpsi, bool fRedraw);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}