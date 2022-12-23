// ------------------------------------------------------------------------------
// <copyright file="ScrollInfo.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Area53.WinForms.Native
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ScrollInfo
    {
#pragma warning disable SA1307
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
#pragma warning restore SA1307
    }
}