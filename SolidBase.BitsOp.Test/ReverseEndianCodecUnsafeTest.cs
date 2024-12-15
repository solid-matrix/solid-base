using System.Runtime.InteropServices;

namespace SolidBase.BitsOp.Test;

public unsafe class ReverseEndianCodecUnsafeTest
{
    private const int RandomCount = 1 << 16;

    private readonly ReverseEndianCodecUnsafe _codec = new();

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
        var buffer2 = stackalloc byte[16];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(buffer);

            {
                var expect = MemoryMarshal.Read<ushort>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadUInt16(buffer2);
                Assert.Equal(expect, result);
            }

            {
                var expect = MemoryMarshal.Read<short>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadInt16(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<uint>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadUInt32(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<int>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadInt32(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<ulong>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadUInt64(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<long>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadInt64(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<UInt128>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadUInt128(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Int128>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadInt128(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Half>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadHalf(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<float>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadSingle(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<double>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadDouble(buffer2);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<nint>(buffer);
                var span2 = new Span<byte>(buffer2, Marshal.SizeOf(expect));
                ReverseSpan(buffer, span2);
                var result = _codec.ReadIntPtr(buffer2);
                Assert.Equal(expect, result);
            }
        }
    }

    [Fact]
    public void WriteTest()
    {
        var buffer = new byte[16];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        var expect = new byte[16];
        var result = stackalloc byte[16];

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(buffer);

            {
                var value = MemoryMarshal.Read<ushort>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt16(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<short>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt16(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<uint>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt32(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<int>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt32(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<ulong>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt64(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<long>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt64(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<UInt128>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt128(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<Int128>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt128(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<Half>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteHalf(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<float>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteSingle(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<double>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteDouble(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<nint>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteIntPtr(result, value);
                AssertReverseEqual(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
        }
    }
}