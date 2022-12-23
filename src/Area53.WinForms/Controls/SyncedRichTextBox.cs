// ------------------------------------------------------------------------------
// <copyright file="SyncedRichTextBox.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

using Area53.WinForms.Extensions;
using Area53.WinForms.Native;

using DiffPlex.DiffBuilder.Model;

namespace Area53.WinForms.Controls
{
    [DesignerCategory("")]
    internal class SyncedRichTextBox : RichTextBox
    {
        private static readonly Color _lineNumberColor = Color.DodgerBlue;
        private static readonly Color _insertedBackColor = Color.Honeydew;
        private static readonly Color _deletedBackColor = Color.Bisque;
        private static readonly Color _insertedWordBackColor = Color.LightGreen;
        private static readonly Color _deletedWordBackColor = Color.LightCoral;

        private int _incomingMessages;

        public SyncedRichTextBox()
        {
            ReadOnly = true;
            SetStyle(ControlStyles.EnableNotifyMessage, true);

            HScroll += OnHScroll;
            VScroll += OnVScroll;
        }

        [DisallowNull] public SyncedRichTextBox? Other { get; set; }

        internal void AppendLineDiff(DiffPiece lineDiff, bool isNew, string lineNumberText)
        {
            Color backColor;
            switch (lineDiff.Type)
            {
                case ChangeType.Unchanged:
                    this.SetColors(_lineNumberColor, BackColor);
                    AppendText(lineNumberText);
                    this.SetForeColor(ForeColor);
                    AppendText("  ");
                    backColor = BackColor;
                    break;

                case ChangeType.Deleted:
                    this.SetColors(_lineNumberColor, _deletedBackColor);
                    AppendText(lineNumberText);
                    this.SetForeColor(ForeColor);
                    AppendText("- ");
                    backColor = _deletedBackColor;
                    break;

                case ChangeType.Inserted:
                    this.SetColors(_lineNumberColor, _insertedBackColor);
                    AppendText(lineNumberText);
                    this.SetForeColor(ForeColor);
                    AppendText("+ ");
                    backColor = _insertedBackColor;
                    break;

                case ChangeType.Modified:
                    if (isNew)
                    {
                        this.SetColors(_lineNumberColor, _insertedBackColor);
                        AppendText(lineNumberText);
                        this.SetForeColor(ForeColor);
                        AppendText("+ ");
                        backColor = _insertedBackColor;
                    }
                    else
                    {
                        this.SetColors(_lineNumberColor, _deletedBackColor);
                        AppendText(lineNumberText);
                        this.SetForeColor(ForeColor);
                        AppendText("- ");
                        backColor = _deletedBackColor;
                    }

                    break;

                default:
                    backColor = BackColor;
                    break;
            }

            if (lineDiff.SubPieces.Count > 0)
            {
                foreach (var pieceDiff in lineDiff.SubPieces)
                {
                    AppendDiff(pieceDiff, isNew);
                    this.SetBackColor(backColor);
                }
            }
            else
            {
                AppendDiff(lineDiff, isNew);
            }
        }

        internal void AppendDiff(DiffPiece diffPiece, bool isNew)
        {
            switch (diffPiece.Type)
            {
                case ChangeType.Unchanged:
                    AppendText(diffPiece.Text);
                    break;

                case ChangeType.Deleted:
                    this.SetBackColor(_deletedWordBackColor);
                    AppendText(diffPiece.Text);
                    break;

                case ChangeType.Inserted:
                    this.SetBackColor(_insertedWordBackColor);
                    AppendText(diffPiece.Text);
                    break;

                case ChangeType.Modified:
                    if (isNew)
                    {
                        this.SetBackColor(_insertedWordBackColor);
                    }
                    else
                    {
                        this.SetBackColor(_deletedWordBackColor);
                    }

                    AppendText(diffPiece.Text);
                    break;
            }
        }

        protected override unsafe void OnNotifyMessage(Message m)
        {
            if (m.Msg == (int)MessageType.WM_HSCROLL)
            {
                if (_incomingMessages == 0)
                {
                    SyncHScroll(m);
                }
            }
            else if (m.Msg == (int)MessageType.WM_VSCROLL)
            {
                if (_incomingMessages == 0)
                {
                    SyncVScroll(m);
                }
            }

            base.OnNotifyMessage(m);
        }

        private void OnHScroll(object? sender, EventArgs e)
        {
            if (_incomingMessages > 0)
            {
                _incomingMessages--;
                return;
            }

            SyncHScroll();
        }

        private void OnVScroll(object? sender, EventArgs e)
        {
            if (_incomingMessages > 0)
            {
                _incomingMessages--;
                return;
            }

            SyncVScroll();
        }

        private void SyncHScroll(Message? message = null)
        {
            SyncScroll(ScrollBarType.SB_HORZ, MessageType.WM_HSCROLL, message);
        }

        private void SyncVScroll(Message? message = null)
        {
            SyncScroll(ScrollBarType.SB_VERT, MessageType.WM_VSCROLL, message);
        }

        private unsafe void SyncScroll(ScrollBarType scrollBarType, MessageType messageType, Message? message = null)
        {
            if (Other is null)
            {
                return;
            }

            var fnBar = (int)scrollBarType;
            var scrollInfo = default(ScrollInfo);
            scrollInfo.cbSize = (uint)sizeof(ScrollInfo);
            scrollInfo.fMask = (uint)ScrollInfoMask.SIF_TRACKPOS;

            if (NativeMethods.GetScrollInfo(Handle, fnBar, ref scrollInfo))
            {
                scrollInfo.nPos = scrollInfo.nTrackPos;
                scrollInfo.fMask = (uint)ScrollInfoMask.SIF_POS;

                NativeMethods.SetScrollInfo(Other.Handle, fnBar, ref scrollInfo, true);

                Other._incomingMessages++;
                if (message.HasValue)
                {
                    NativeMethods.SendMessage(Other.Handle, (uint)message.Value.Msg, message.Value.WParam, message.Value.LParam);
                }
                else
                {
                    var wParam = (int)ScrollBarCommands.SB_THUMBPOSITION | (scrollInfo.nPos << 16);
                    NativeMethods.SendMessage(Other.Handle, (uint)messageType, new IntPtr(wParam), IntPtr.Zero);
                }
            }
        }
    }
}