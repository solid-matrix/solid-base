using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidBase.BitsOp;

public unsafe class ReverseEndianCodec : IEndianCodec
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort ReadUInt16(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(ushort));
        var value = Unsafe.ReadUnaligned<ushort>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short ReadInt16(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(short));
        var value = Unsafe.ReadUnaligned<short>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ReadUInt32(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(uint));
        var value = Unsafe.ReadUnaligned<uint>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ReadInt32(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(int));
        var value = Unsafe.ReadUnaligned<int>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong ReadUInt64(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(ulong));
        var value = Unsafe.ReadUnaligned<ulong>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ReadInt64(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(long));
        var value = Unsafe.ReadUnaligned<long>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UInt128 ReadUInt128(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(UInt128));
        var value = Unsafe.ReadUnaligned<UInt128>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int128 ReadInt128(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(Int128));
        var value = Unsafe.ReadUnaligned<Int128>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Half ReadHalf(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(Half));
        var value = Unsafe.ReadUnaligned<ushort>(ref MemoryMarshal.GetReference(source));
        return BitConverter.UInt16BitsToHalf(BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float ReadSingle(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(float));
        var value = Unsafe.ReadUnaligned<uint>(ref MemoryMarshal.GetReference(source));
        return BitConverter.UInt32BitsToSingle(BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ReadDouble(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(double));
        var value = Unsafe.ReadUnaligned<ulong>(ref MemoryMarshal.GetReference(source));
        return BitConverter.UInt64BitsToDouble(BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint ReadIntPtr(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(nint));
        var value = Unsafe.ReadUnaligned<nint>(ref MemoryMarshal.GetReference(source));
        return BinaryPrimitives.ReverseEndianness(value);
    }
}
