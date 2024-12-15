using System.Runtime.InteropServices;

namespace SolidBase.BitsOp.Test;

public class ReverseEndianCodecTest
{
    private const int RepeatCount = 1 << 16;

    private const int RangeCount = 16;

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

        for (var i = 0; i < RepeatCount; i++)
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

        for (var i = 0; i < RepeatCount; i++)
        {
            rand.NextBytes(buffer);
            {
                var value = MemoryMarshal.Read<ushort>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt16(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<short>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt16(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<uint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt32(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<int>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt32(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<ulong>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt64(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<long>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt64(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<UInt128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt128(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Int128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt128(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Half>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteHalf(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<float>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteSingle(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<double>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteDouble(value, result);
                AssertReverseEqual(expect, result);
            }
            {
                var value = MemoryMarshal.Read<nint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteIntPtr(value, result);
                AssertReverseEqual(expect, result);
            }
        }
    }

    [Fact]
    public void ReadRangeTest()
    {
        var buffer = new byte[16 * RangeCount];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        void ReadRangeTestOnce<T>(Func<ReadOnlySpan<byte>, ReadOnlySpan<T>> codecFunc) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var num = buffer.Length / size;
            var results = codecFunc(buffer);
            for (var i = 0; i < num; i++)
            {
                var span = new byte[size];
                ReverseSpan(new Span<byte>(buffer, i * size, size), span);
                var expect = MemoryMarshal.Read<T>(span);
                //Assert.Equal(expect, results[i]);
            }
        }

        for (var i = 0; i < RepeatCount; i++)
        {
            rand.NextBytes(buffer);
            ReadRangeTestOnce(_codec.ReadUInt16Range);
            ReadRangeTestOnce(_codec.ReadInt16Range);
            ReadRangeTestOnce(_codec.ReadUInt32Range);
            ReadRangeTestOnce(_codec.ReadInt32Range);
            ReadRangeTestOnce(_codec.ReadUInt64Range);
            ReadRangeTestOnce(_codec.ReadInt64Range);
            ReadRangeTestOnce(_codec.ReadUInt128Range);
            ReadRangeTestOnce(_codec.ReadInt128Range);
            ReadRangeTestOnce(_codec.ReadHalfRange);
            ReadRangeTestOnce(_codec.ReadSingleRange);
            ReadRangeTestOnce(_codec.ReadDoubleRange);
            ReadRangeTestOnce(_codec.ReadIntPtrRange);
        }
    }

    [Fact]
    public void WriteRangeTest()
    {
        var buffer = new byte[16 * RangeCount];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        void WriteRangeTestOnce<T>(Action<ReadOnlySpan<T>, Span<byte>> codecFunc) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var num = buffer.Length / size;
            var values = MemoryMarshal.Cast<byte, T>(buffer);
            var expects = new byte[16 * RangeCount];
            var results = new byte [16 * RangeCount];

            codecFunc(values, results);

            for (var i = 0; i < num; i++)
            {
                var span1 = new Span<byte>(expects, i * size, size);
                var span2 = new Span<byte>(results, i * size, size);
                MemoryMarshal.Write(span1, values[i]);
                AssertReverseEqual(span1, span2);
            }
        }

        for (var i = 0; i < RepeatCount; i++)
        {
            rand.NextBytes(buffer);
            WriteRangeTestOnce<ushort>(_codec.WriteUInt16Range);
            WriteRangeTestOnce<short>(_codec.WriteInt16Range);
            WriteRangeTestOnce<uint>(_codec.WriteUInt32Range);
            WriteRangeTestOnce<int>(_codec.WriteInt32Range);
            WriteRangeTestOnce<ulong>(_codec.WriteUInt64Range);
            WriteRangeTestOnce<long>(_codec.WriteInt64Range);
            WriteRangeTestOnce<UInt128>(_codec.WriteUInt128Range);
            WriteRangeTestOnce<Int128>(_codec.WriteInt128Range);
            WriteRangeTestOnce<Half>(_codec.WriteHalfRange);
            WriteRangeTestOnce<float>(_codec.WriteSingleRange);
            WriteRangeTestOnce<double>(_codec.WriteDoubleRange);
            WriteRangeTestOnce<nint>(_codec.WriteIntPtrRange);
        }
    }
}