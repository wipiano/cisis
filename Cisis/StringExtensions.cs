using System;
using System.Text;

namespace Cisis
{
    public static class StringExtensions
    {
        #region null check
        public static bool IsNullOrEmpty(this string s)
            => string.IsNullOrEmpty(s);

        public static bool IsNullOrWhiteSpace(this string s)
            => string.IsNullOrWhiteSpace(s);

        public static bool IsNotNullAndNotEmpty(this string s)
            => !string.IsNullOrEmpty(s);

        public static bool IsNotNullAndNotWhiteSpace(this string s)
            => !string.IsNullOrWhiteSpace(s);
        #endregion

        #region convert to primitive types
        public static bool ToBool(this string s)
            => bool.Parse(s);

        public static bool? ToBoolOrNull(this string s)
            => bool.TryParse(s, out var v) ? v : null as bool?;
        
        public static byte ToByte(this string s)
            => byte.Parse(s);

        public static byte? ToByteOrNull(this string s)
            => byte.TryParse(s, out var v) ? v : null as byte?;
        
        public static sbyte ToSByte(this string s)
            => sbyte.Parse(s);

        public static sbyte? ToSByteOrNull(this string s)
            => sbyte.TryParse(s, out var v) ? v : null as sbyte?;
        
        public static ushort ToUShort(this string s)
            => ushort.Parse(s);

        public static ushort? ToUShortOrNull(this string s)
            => ushort.TryParse(s, out var v) ? v : null as ushort?;
        
        public static short ToShort(this string s)
            => short.Parse(s);

        public static short? ToShortOrNull(this string s)
            => short.TryParse(s, out var v) ? v : null as short?;
        
        public static uint ToUInt(this string s)
            => uint.Parse(s);

        public static uint? ToUIntOrNull(this string s)
            => uint.TryParse(s, out var v) ? v : null as uint?;
        
        public static int ToInt(this string s)
            => int.Parse(s);

        public static int? ToIntOrNull(this string s)
            => int.TryParse(s, out var v) ? v : null as int?;
        
        public static ulong ToULong(this string s)
            => ulong.Parse(s);

        public static ulong? ToULongOrNull(this string s)
            => ulong.TryParse(s, out var v) ? v : null as ulong?;
        
        public static long ToLong(this string s)
            => long.Parse(s);

        public static long? ToLongOrNull(this string s)
            => long.TryParse(s, out var v) ? v : null as long?;
        #endregion
        
        #region convert to Guid
        public static Guid ToGuid(this string s)
            => Guid.Parse(s);

        public static Guid? ToGuidOrNull(this string s)
            => Guid.TryParse(s, out var v) ? v : null as Guid?;
        #endregion
        
        #region substring as ReadOnlySpan<char>
        public static ReadOnlySpan<char> SubstringSpan(this string s, int startIndex)
            => s?.AsSpan(startIndex) ?? throw new ArgumentNullException(nameof(s));

        public static ReadOnlySpan<char> SubstringSpan(this string s, int startIndex, int length)
            => s?.AsSpan(startIndex, length) ?? throw new ArgumentNullException(nameof(s));
        #endregion
        
        #region Encoding support
        public static byte[] ToUtf8Bytes(this string s)
            => Encoding.UTF8.GetBytes(s);

        public static int ToUtf8Bytes(this string s, Span<byte> bytes)
            => Encoding.UTF8.GetBytes(s, bytes);

        public static int ToUtf8Bytes(this ReadOnlySpan<char> s, Span<byte> bytes)
            => Encoding.UTF8.GetBytes(s, bytes);
        #endregion
    }
}