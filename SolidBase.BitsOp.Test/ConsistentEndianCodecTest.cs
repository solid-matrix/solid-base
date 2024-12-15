using System.Runtime.InteropServices;

namespace SolidBase.BitsOp.Test;

public class ConsistentEndianCodecTest
{
    private const int RepeatCount = 1 << 16;

    private const int RangeCount = 16;

    private readonly ConsistentEndianCodec _codec = new();

    [Fact]
    public void ReadTest()
    {
        var buffer = new byte[16];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        for (var i = 0; i < RepeatCount; i++)
        {
            rand.NextBytes(buffer);

            {
                var expect = MemoryMarshal.Read<ushort>(buffer);
                var result = _codec.ReadUInt16(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<short>(buffer);
                var result = _codec.ReadInt16(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<uint>(buffer);
                var result = _codec.ReadUInt32(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<int>(buffer);
                var result = _codec.ReadInt32(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<ulong>(buffer);
                var result = _codec.ReadUInt64(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<long>(buffer);
                var result = _codec.ReadInt64(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<UInt128>(buffer);
                var result = _codec.ReadUInt128(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Int128>(buffer);
                var result = _codec.ReadInt128(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Half>(buffer);
                var result = _codec.ReadHalf(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<float>(buffer);
                var result = _codec.ReadSingle(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<double>(buffer);
                var result = _codec.ReadDouble(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<nint>(buffer);
                var result = _codec.ReadIntPtr(buffer);
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
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<short>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt16(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<uint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt32(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<int>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt32(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<ulong>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt64(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<long>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt64(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<UInt128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt128(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Int128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt128(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Half>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteHalf(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<float>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteSingle(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<double>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteDouble(value, result);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<nint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteIntPtr(value, result);
                Assert.Equal(expect, result);
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
                var expect = MemoryMarshal.Read<T>(new Span<byte>(buffer, i * size, size));
                Assert.Equal(expect, results[i]);
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

            for (var i = 0; i < num; i++) MemoryMarshal.Write(new Span<byte>(expects, i * size, size), values[i]);
            codecFunc(values, results);
            Assert.Equal(buffer, results);
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