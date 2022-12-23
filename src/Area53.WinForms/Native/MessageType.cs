// ------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

namespace Area53.WinForms.Native
{
    // https://wiki.winehq.org/List_Of_Windows_Messages
    internal enum MessageType : uint
    {
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
    }
}