using System.Runtime.InteropServices;

namespace SolidBase.BitsOp.Test;

public class ReverseEndianCodecTest
{
    private const int RandomCount = 1 << 16;

    private readonly ReverseEndianCodec _codec = new();

    private void AssertReverseEqual(ReadOnlySpan<byte> span1, ReadOnlySpan<byte> span2)
    {
        Assert.Equal(span1.Length, span2.Length);
        var len = span1.Length;
        for (var i = 0; i < len; i++) Assert.Equal(span1[i], span2[len - 1 - i]);
    }

    private void ReverseSpan(ReadOnlySpan<byte> source, Span<byte> destination)
    {
        for (var i = 0; i < destination.Length; i++) destination[i] = source[destination.Length - 1 - i];
    }

    [Fact]
    public void ReadTest()
    {
        var buffer = new byte[16];
        var buffer2 = new byte[16];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(buffer);

            {
                var expect = MemoryMarshal.Read<ushort>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadUInt16(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<short>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadInt16(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<uint>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadUInt32(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<int>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadInt32(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<ulong>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadUInt64(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<long>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadInt64(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<UInt128>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadUInt128(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Int128>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadInt128(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Half>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadHalf(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<float>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadSingle(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<double>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadDouble(reverse);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<nint>(buffer);
                var reverse = new Span<byte>(buffer2, 0, Marshal.SizeOf(expect));
                ReverseSpan(buffer, reverse);
                var result = _codec.ReadIntPtr(reverse);
                Assert.Equal(expect, result);
            }
        }
    }

    [Fact]
    public void WriteTest()
    {
        var buffer = new byte[16];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(buffer);
            {
                var value = MemoryMarshal.Read<ushort>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt16(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<short>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt16(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<uint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt32(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<int>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt32(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<ulong>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt64(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<long>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt64(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<UInt128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt128(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Int128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt128(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Half>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteHalf(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<float>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteSingle(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<double>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteDouble(result, value);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<nint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteIntPtr(result, value);
                AssertReverseEqual(expect, result);
            }
        }
    }
}