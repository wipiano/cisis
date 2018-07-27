using System;
using System.Text;

namespace Cisis
{
    public static class StringExtensions
    {
        #region null or empty check
        /// <summary>
        /// Indicates whether the specified string is null or empty string
        /// </summary>
        public static bool IsNullOrEmpty(this string s)
            => string.IsNullOrEmpty(s);

        /// <summary>
        /// Indicates whether a specified string is null, empty,
        /// or consists only of white-space characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string s)
            => string.IsNullOrWhiteSpace(s);

        /// <summary>
        /// Indicates whether the specified string is not null and not empty string.
        /// </summary>
        public static bool IsNotNullAndNotEmpty(this string s)
            => !string.IsNullOrEmpty(s);

        /// <summary>
        /// Indicates whether the specified string is not null, not empty, and contains non white-space characters.
        /// </summary>
        public static bool IsNotNullAndNotWhiteSpace(this string s)
            => !string.IsNullOrWhiteSpace(s);
        #endregion

        #region convert to primitive types
        /// <summary>
        /// Convert string to bool
        /// </summary>
        public static bool ToBool(this string s)
            => bool.Parse(s);

        /// <summary>
        /// Convert to bool or null.
        /// </summary>
        public static bool? ToBoolOrNull(this string s)
            => bool.TryParse(s, out var v) ? v : null as bool?;
        
        /// <summary>
        /// Convert to byte
        /// </summary>
        public static byte ToByte(this string s)
            => byte.Parse(s);

        /// <summary>
        /// Convert to byte or null.
        /// </summary>
        public static byte? ToByteOrNull(this string s)
            => byte.TryParse(s, out var v) ? v : null as byte?;
        
        /// <summary>
        /// Convert to signed byte
        /// </summary>
        public static sbyte ToSByte(this string s)
            => sbyte.Parse(s);

        /// <summary>
        /// Convert to signed byte or null
        /// </summary>
        public static sbyte? ToSByteOrNull(this string s)
            => sbyte.TryParse(s, out var v) ? v : null as sbyte?;
        
        /// <summary>
        /// Convert to unsigned short 
        /// </summary>
        public static ushort ToUShort(this string s)
            => ushort.Parse(s);

        /// <summary>
        /// Convert to unsigned short or null
        /// </summary>
        public static ushort? ToUShortOrNull(this string s)
            => ushort.TryParse(s, out var v) ? v : null as ushort?;
        
        /// <summary>
        /// Convert to short
        /// </summary>
        public static short ToShort(this string s)
            => short.Parse(s);

        /// <summary>
        /// Convert to short or null
        /// </summary>
        public static short? ToShortOrNull(this string s)
            => short.TryParse(s, out var v) ? v : null as short?;
        
        /// <summary>
        /// Convert to unsigned int
        /// </summary>
        public static uint ToUInt(this string s)
            => uint.Parse(s);

        /// <summary>
        /// Convert to unsigned int or null
        /// </summary>
        public static uint? ToUIntOrNull(this string s)
            => uint.TryParse(s, out var v) ? v : null as uint?;
        
        /// <summary>
        /// Convert to int
        /// </summary>
        public static int ToInt(this string s)
            => int.Parse(s);

        /// <summary>
        /// Convert to int or null
        /// </summary>
        public static int? ToIntOrNull(this string s)
            => int.TryParse(s, out var v) ? v : null as int?;
        
        /// <summary>
        /// Convert to unsigned long
        /// </summary>
        public static ulong ToULong(this string s)
            => ulong.Parse(s);

        /// <summary>
        /// Convert to unsigned long or null
        /// </summary>
        public static ulong? ToULongOrNull(this string s)
            => ulong.TryParse(s, out var v) ? v : null as ulong?;
        
        /// <summary>
        /// Convert to long
        /// </summary>
        public static long ToLong(this string s)
            => long.Parse(s);

        /// <summary>
        /// Convert to long or null
        /// </summary>
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
        {
            s.ThrowIfArgumentNull(nameof(s));
            return s.AsSpan(startIndex);
        }

        public static ReadOnlySpan<char> SubstringSpan(this string s, int startIndex, int length)
        {
            s.ThrowIfArgumentNull(nameof(s));
            
            return s.AsSpan(startIndex, length);
        }
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