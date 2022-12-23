// ------------------------------------------------------------------------------
// <copyright file="ScrollInfoMask.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;

namespace Area53.WinForms.Native
{
    [Flags]
    internal enum ScrollInfoMask : uint
    {
        /// <summary><see cref="ScrollInfo.nMin"/> and <see cref="ScrollInfo.nMax"/>.</summary>
        SIF_RANGE = 1 << 0,

        /// <summary><see cref="ScrollInfo.nPage"/>.</summary>
        SIF_PAGE = 1 << 1,

        /// <summary><see cref="ScrollInfo.nPos"/>.</summary>
        SIF_POS = 1 << 2,

        /// <summary>Set-only.</summary>
        SIF_DISABLENOSCROLL = 1 << 3,

        /// <summary><see cref="ScrollInfo.nTrackPos"/>, get-only.</summary>
        SIF_TRACKPOS = 1 << 4,

        SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS,
    }
}