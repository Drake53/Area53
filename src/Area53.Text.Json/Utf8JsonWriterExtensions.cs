// ------------------------------------------------------------------------------
// <copyright file="Utf8JsonWriterExtensions.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Area53.Text.Json
{
    /// <summary>
    /// Extension methods for <see cref="Utf8JsonWriter"/>.
    /// </summary>
    public static class Utf8JsonWriterExtensions
    {
        /// <summary>
        /// Writes the property name (as a JSON string) and the JSON representation of a type specified by a generic type parameter to the provided writer.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to convert and write.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteObject<TValue>(this Utf8JsonWriter writer, TValue value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}