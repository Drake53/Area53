// ------------------------------------------------------------------------------
// <copyright file="RichTextBoxExtensions.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;

namespace Area53.WinForms.Extensions
{
    public static class RichTextBoxExtensions
    {
        /// <summary>Sets the forecolor to be applied to the text when using <see cref="TextBoxBase.AppendText"/>.</summary>
        public static void SetForeColor(this RichTextBox textBox, Color color)
        {
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.SelectionColor = color;
        }

        /// <summary>Sets the backcolor to be applied to the text when using <see cref="TextBoxBase.AppendText"/>.</summary>
        public static void SetBackColor(this RichTextBox textBox, Color backColor)
        {
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.SelectionBackColor = backColor;
        }

        /// <summary>Sets the forecolor and backcolor to be applied to the text when using <see cref="TextBoxBase.AppendText"/>.</summary>
        public static void SetColors(this RichTextBox textBox, Color color, Color backColor)
        {
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.SelectionColor = color;
            textBox.SelectionBackColor = backColor;
        }
    }
}