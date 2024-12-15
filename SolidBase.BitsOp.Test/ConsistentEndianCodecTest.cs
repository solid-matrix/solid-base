using System.Runtime.InteropServices;

namespace SolidBase.BitsOp.Test;

public class ConsistentEndianCodecTest
{
    private const int RandomCount = 1 << 16;

    private readonly ConsistentEndianCodec _codec = new();

    [Fact]
    public void ReadTest()
    {
        var buffer = new byte[16];
        var rand = new Random(Guid.NewGuid().GetHashCode());

        for (var i = 0; i < RandomCount; i++)
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

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(buffer);
            {
                var value = MemoryMarshal.Read<ushort>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt16(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<short>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt16(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<uint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt32(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<int>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt32(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<ulong>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt64(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<long>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt64(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<UInt128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt128(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Int128>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt128(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<Half>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteHalf(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<float>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteSingle(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<double>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteDouble(result, value);
                Assert.Equal(expect, result);
            }
            {
                var value = MemoryMarshal.Read<nint>(buffer);
                var expect = new byte[Marshal.SizeOf(value)];
                var result = new byte[Marshal.SizeOf(value)];
                MemoryMarshal.Write(expect, value);
                _codec.WriteIntPtr(result, value);
                Assert.Equal(expect, result);
            }
        }
    }
}