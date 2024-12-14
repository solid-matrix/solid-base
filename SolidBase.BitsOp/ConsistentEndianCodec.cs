using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidBase.BitsOp;

public unsafe class ConsistentEndianCodec : IEndianCodec
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort ReadUInt16(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(ushort));
        return Unsafe.ReadUnaligned<ushort>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short ReadInt16(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(short));
        return Unsafe.ReadUnaligned<short>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ReadUInt32(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(uint));
        return Unsafe.ReadUnaligned<uint>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ReadInt32(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(int));
        return Unsafe.ReadUnaligned<int>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong ReadUInt64(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(ulong));
        return Unsafe.ReadUnaligned<ulong>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ReadInt64(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(long));
        return Unsafe.ReadUnaligned<long>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UInt128 ReadUInt128(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(UInt128));
        return Unsafe.ReadUnaligned<UInt128>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int128 ReadInt128(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(Int128));
        return Unsafe.ReadUnaligned<Int128>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Half ReadHalf(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(Half));
        return Unsafe.ReadUnaligned<Half>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float ReadSingle(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(float));
        return Unsafe.ReadUnaligned<float>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ReadDouble(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(double));
        return Unsafe.ReadUnaligned<double>(ref MemoryMarshal.GetReference(source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint ReadIntPtr(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Length, sizeof(nint));
        return Unsafe.ReadUnaligned<nint>(ref MemoryMarshal.GetReference(source));
    }
}
