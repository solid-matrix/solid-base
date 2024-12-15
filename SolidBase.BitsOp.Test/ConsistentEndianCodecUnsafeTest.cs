using System.Runtime.InteropServices;

namespace SolidBase.BitsOp.Test;

public unsafe class ConsistentEndianCodecUnsafeTest
{
    private const int RandomCount = 1 << 16;

    private readonly ConsistentEndianCodecUnsafe _codec = new();

    [Fact]
    public void ReadTest()
    {
        var buffer = stackalloc byte[16];
        var bufferSpan = new Span<byte>(buffer, 16);
        var rand = new Random(Guid.NewGuid().GetHashCode());

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(bufferSpan);

            {
                var expect = MemoryMarshal.Read<ushort>(bufferSpan);
                var result = _codec.ReadUInt16(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<short>(bufferSpan);
                var result = _codec.ReadInt16(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<uint>(bufferSpan);
                var result = _codec.ReadUInt32(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<int>(bufferSpan);
                var result = _codec.ReadInt32(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<ulong>(bufferSpan);
                var result = _codec.ReadUInt64(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<long>(bufferSpan);
                var result = _codec.ReadInt64(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<UInt128>(bufferSpan);
                var result = _codec.ReadUInt128(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Int128>(bufferSpan);
                var result = _codec.ReadInt128(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<Half>(bufferSpan);
                var result = _codec.ReadHalf(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<float>(bufferSpan);
                var result = _codec.ReadSingle(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<double>(bufferSpan);
                var result = _codec.ReadDouble(buffer);
                Assert.Equal(expect, result);
            }
            {
                var expect = MemoryMarshal.Read<nint>(bufferSpan);
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

        var expect = new byte[16];
        var result = stackalloc byte[16];

        for (var i = 0; i < RandomCount; i++)
        {
            rand.NextBytes(buffer);
            {
                var value = MemoryMarshal.Read<ushort>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt16(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<short>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt16(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<uint>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt32(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<int>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt32(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<ulong>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt64(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<long>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt64(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<UInt128>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteUInt128(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<Int128>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteInt128(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<Half>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteHalf(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<float>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteSingle(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<double>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteDouble(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
            {
                var value = MemoryMarshal.Read<nint>(buffer);
                MemoryMarshal.Write(expect, value);
                _codec.WriteIntPtr(result, value);
                Assert.Equal(
                    new ReadOnlySpan<byte>(expect, 0, Marshal.SizeOf(value)),
                    new ReadOnlySpan<byte>(result, Marshal.SizeOf(value)));
            }
        }
    }
}