﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NBitcoin.DataEncoders
{
	public class HexEncoder : DataEncoder
	{
#if HAS_SPAN
		public static ReadOnlySpan<byte> CharToHexLookup => new byte[]
		{
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 15
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 31
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 47
            0x0,  0x1,  0x2,  0x3,  0x4,  0x5,  0x6,  0x7,  0x8,  0x9,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 63
            0xFF, 0xA,  0xB,  0xC,  0xD,  0xE,  0xF,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 79
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 95
            0xFF, 0xa,  0xb,  0xc,  0xd,  0xe,  0xf,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 111
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 127
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 143
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 159
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 175
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 191
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 207
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 223
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 239
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  // 255
        };
#else
		public static byte[] CharToHexLookup => new byte[]
		{
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 15
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 31
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 47
            0x0,  0x1,  0x2,  0x3,  0x4,  0x5,  0x6,  0x7,  0x8,  0x9,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 63
            0xFF, 0xA,  0xB,  0xC,  0xD,  0xE,  0xF,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 79
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 95
            0xFF, 0xa,  0xb,  0xc,  0xd,  0xe,  0xf,  0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 111
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 127
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 143
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 159
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 175
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 191
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 207
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 223
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, // 239
            0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF  // 255
        };
#endif
#if !HAS_SPAN
		private static readonly string[] HexTbl = Enumerable.Range(0, 256).Select(v => v.ToString("x2")).ToArray();
#endif

		public override string EncodeData(byte[] data, int offset, int count)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

#if !HAS_SPAN
			int pos = 0;
			var s = new char[2 * count];
			for (var i = offset; i < offset + count; i++)
			{
				var c = HexTbl[data[i]];
				s[pos++] = c[0];
				s[pos++] = c[1];
			}
			return new string(s);
#else
			return string.Create(2 * count, (offset, count, data), CreateHexString);
#endif
		}

#if HAS_SPAN
		void CreateHexString(Span<char> s, (int offset, int count, byte[] data) state)
		{
			for (var pos = 0; pos < state.count; ++pos)
			{
				ToCharsBuffer(state.data[state.offset + pos], s, pos * 2);
			}
		}

		// Magic taken from dotnet runtime (src/libraries/Common/src/System/HexConverter.cs)
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToCharsBuffer(byte value, Span<char> buffer, int startingIndex = 0)
		{
			uint difference = (((uint)value & 0xF0U) << 4) + ((uint)value & 0x0FU) - 0x8989U;
			uint packedResult = ((((uint)(-(int)difference) & 0x7070U) >> 4) + difference + 0xB9B9U) | 0x2020U;
			buffer[startingIndex + 1] = (char)(packedResult & 0xFF);
			buffer[startingIndex] = (char)(packedResult >> 8);
		}
#endif

		public override byte[] DecodeData(string encoded)
		{
			if (encoded == null)
				throw new ArgumentNullException(nameof(encoded));
			if (encoded.Length % 2 == 1)
				throw new FormatException("Invalid Hex String");

			var result = new byte[encoded.Length / 2];
			for (int i = 0, j = 0; i < encoded.Length; i += 2, j++)
			{
				var hi = IsDigitCore(encoded[i]);
				var lo = IsDigitCore(encoded[i + 1]);
				if ((hi | lo) == 0xFF)
					throw new FormatException("Invalid Hex String");
				result[j] = (byte)((hi << 4) | lo);
			}
			return result;
		}
#if HAS_SPAN
		public void DecodeData(string encoded, Span<byte> output)
		{
			if (encoded == null)
				throw new ArgumentNullException(nameof(encoded));
			if (encoded.Length % 2 == 1)
				throw new FormatException("Invalid Hex String");
			if (output.Length < (encoded.Length >> 1))
				throw new ArgumentException("output should be bigger", nameof(output));
			try
			{
				for (int i = 0, j = 0; i < encoded.Length; i += 2, j++)
				{
					var a = IsDigitCore(encoded[i]);
					var b = IsDigitCore(encoded[i + 1]);
					if (a == 0xff || b == 0xff)
						throw new FormatException("Invalid Hex String");
					output[j] = (byte)(((uint)a << 4) | (uint)b);
				}
			}
			catch(IndexOutOfRangeException) { throw new FormatException("Invalid Hex String"); }
		}
#endif
		public bool IsValid(string str)
		{
			if (str.Length % 2 != 0)
				return false;
			for (int i = 0; i < str.Length; i++)
			{
				if (IsDigitCore(str[i]) == 0xff)
					return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IsDigit(char c)
		{
			var d = IsDigitCore(c);
			if (d == 0xff)
				return -1;
			return d;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static byte IsDigitCore(char c)
		{
			return CharToHexLookup[c];
		}

		public static bool IsWellFormed(string str)
		{
			return ((HexEncoder)Encoders.Hex).IsValid(str);
		}
	}
}
