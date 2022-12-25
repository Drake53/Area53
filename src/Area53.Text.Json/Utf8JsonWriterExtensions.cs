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
        /// Writes the property name (as a JSON string) and <see cref="bool"/> value (as a JSON literal true or false) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON literal true or false.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteBoolean(this Utf8JsonWriter writer, bool value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteBooleanValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="int"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, int value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="uint"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, uint value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="long"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, long value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="ulong"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, ulong value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="float"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, float value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="double"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, double value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

        /// <summary>
        /// Writes the property name (as a JSON string) and <see cref="decimal"/> value (as a JSON number) to the provided writer.
        /// </summary>
        /// <param name="writer">A JSON writer to write to.</param>
        /// <param name="value">The value to be written as a JSON number.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <param name="propertyName">The property name of the JSON object to be transcoded and written as UTF-8.</param>
        public static void WriteNumber(this Utf8JsonWriter writer, decimal value, JsonSerializerOptions? options = null, [CallerArgumentExpression("value"), DisallowNull] string? propertyName = null!)
        {
            writer.WritePropertyName(options?.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
            writer.WriteNumberValue(value);
        }

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