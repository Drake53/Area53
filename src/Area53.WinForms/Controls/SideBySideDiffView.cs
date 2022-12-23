// ------------------------------------------------------------------------------
// <copyright file="SideBySideDiffView.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Area53.WinForms.Extensions;

using DiffPlex.DiffBuilder.Model;

namespace Area53.WinForms.Controls
{
    [DesignerCategory("")]
    public class SideBySideDiffView : Control
    {
        private const int UnchangedBufferSize = 3;
        private const int BetweenChangedBufferSize = (2 * UnchangedBufferSize) + 1;

        private readonly SyncedRichTextBox _oldTextBox;
        private readonly SyncedRichTextBox _newTextBox;

        public SideBySideDiffView(SideBySideDiffModel diffModel)
        {
            if (diffModel is null)
            {
                throw new ArgumentNullException(nameof(diffModel));
            }

            if (diffModel.OldText.Lines.Count != diffModel.NewText.Lines.Count)
            {
                throw new ArgumentException("Expected OldText and NewText to have same amount of lines.", nameof(diffModel));
            }

            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
            };

            _oldTextBox = new SyncedRichTextBox
            {
                Dock = DockStyle.Fill,
                ScrollBars = RichTextBoxScrollBars.Both,
                WordWrap = false,
            };

            _newTextBox = new SyncedRichTextBox
            {
                Dock = DockStyle.Fill,
                ScrollBars = RichTextBoxScrollBars.Both,
                WordWrap = false,
            };

            FontChanged += ChangeFont;

            ReadLines(diffModel);

            splitContainer.Panel1.Controls.Add(_oldTextBox);
            splitContainer.Panel2.Controls.Add(_newTextBox);

            _oldTextBox.SelectionStart = 0;
            _oldTextBox.SelectionLength = 0;
            _oldTextBox.ScrollToCaret();

            _newTextBox.SelectionStart = 0;
            _newTextBox.SelectionLength = 0;
            _newTextBox.ScrollToCaret();

            _oldTextBox.Other = _newTextBox;
            _newTextBox.Other = _oldTextBox;

            Controls.Add(splitContainer);
        }

        private void ChangeFont(object? sender, EventArgs e)
        {
            _oldTextBox.Font = Font;
            _newTextBox.Font = Font;
        }

        private void ReadLines(SideBySideDiffModel diffModel)
        {
            var unchangedLines = 0;
            var hasAnyText = false;
            var log = Math.Log10(diffModel.OldText.Lines.Count);
            var lineNumberWidth = log == Math.Round(log, 0) ? (int)log : (int)log + 1;

            for (var i = 0; i < diffModel.OldText.Lines.Count; i++)
            {
                if (diffModel.OldText.Lines[i].Type == ChangeType.Unchanged)
                {
                    unchangedLines++;
                }
                else
                {
                    if (unchangedLines > BetweenChangedBufferSize)
                    {
                        if (hasAnyText)
                        {
                            for (var j = i - unchangedLines; j < i - unchangedLines + UnchangedBufferSize; j++)
                            {
                                var lineNumberText = (j + 1).ToString(CultureInfo.InvariantCulture).PadLeft(lineNumberWidth, ' ') + " ";

                                _oldTextBox.AppendLine();
                                _oldTextBox.AppendLineDiff(diffModel.OldText.Lines[j], false, lineNumberText);

                                _newTextBox.AppendLine();
                                _newTextBox.AppendLineDiff(diffModel.NewText.Lines[j], true, lineNumberText);
                            }

                            _oldTextBox.AppendLine();
                            _newTextBox.AppendLine();
                        }

                        _oldTextBox.AppendText("...");
                        _newTextBox.AppendText("...");
                        hasAnyText = true;

                        unchangedLines = UnchangedBufferSize;
                    }

                    for (var j = i - unchangedLines; j <= i; j++)
                    {
                        if (hasAnyText)
                        {
                            _oldTextBox.AppendLine();
                            _newTextBox.AppendLine();
                        }
                        else
                        {
                            hasAnyText = true;
                        }

                        var lineNumberText = (j + 1).ToString(CultureInfo.InvariantCulture).PadLeft(lineNumberWidth, ' ') + " ";

                        _oldTextBox.AppendLineDiff(diffModel.OldText.Lines[j], false, lineNumberText);
                        _newTextBox.AppendLineDiff(diffModel.NewText.Lines[j], true, lineNumberText);
                    }

                    unchangedLines = 0;
                }
            }

            if (unchangedLines > 0 && hasAnyText)
            {
                var max = diffModel.OldText.Lines.Count - 1;
                var last = max - unchangedLines + UnchangedBufferSize;
                if (last >= diffModel.OldText.Lines.Count)
                {
                    last = max;
                }

                for (var j = max - unchangedLines + 1; j <= last; j++)
                {
                    var lineNumberText = (j + 1).ToString(CultureInfo.InvariantCulture).PadLeft(lineNumberWidth, ' ') + " ";

                    _oldTextBox.AppendLine();
                    _oldTextBox.AppendLineDiff(diffModel.OldText.Lines[j], false, lineNumberText);

                    _newTextBox.AppendLine();
                    _newTextBox.AppendLineDiff(diffModel.NewText.Lines[j], true, lineNumberText);
                }

                if (unchangedLines > UnchangedBufferSize)
                {
                    _oldTextBox.AppendLine();
                    _newTextBox.AppendLine();

                    if (unchangedLines + 1 == UnchangedBufferSize)
                    {
                        var lineNumberText = max.ToString(CultureInfo.InvariantCulture).PadLeft(lineNumberWidth, ' ') + " ";

                        _oldTextBox.AppendLineDiff(diffModel.OldText.Lines[max], false, lineNumberText);
                        _newTextBox.AppendLineDiff(diffModel.NewText.Lines[max], true, lineNumberText);
                    }
                    else
                    {
                        _oldTextBox.AppendText("...");
                        _newTextBox.AppendText("...");
                    }
                }
            }
        }
    }
}