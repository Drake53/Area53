// ------------------------------------------------------------------------------
// <copyright file="TextBoxBaseExtensions.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace Area53.WinForms.Extensions
{
    public static class TextBoxBaseExtensions
    {
        public static void AppendLine(this TextBoxBase textBox)
        {
            textBox.AppendText(Environment.NewLine);
        }

        public static void AppendLine(this TextBoxBase textBox, string text)
        {
            textBox.AppendText(text);
            textBox.AppendLine();
        }
    }
}