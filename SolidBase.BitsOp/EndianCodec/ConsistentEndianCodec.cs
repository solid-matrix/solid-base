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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt16(ReadOnlySpan<byte> destination, ushort value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ushort));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt16(ReadOnlySpan<byte> destination, short value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(short));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt32(ReadOnlySpan<byte> destination, uint value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(uint));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32(ReadOnlySpan<byte> destination, int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(int));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt64(ReadOnlySpan<byte> destination, ulong value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ulong));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt64(ReadOnlySpan<byte> destination, long value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(long));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt128(ReadOnlySpan<byte> destination, UInt128 value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(UInt128));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt128(ReadOnlySpan<byte> destination, Int128 value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Int128));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteHalf(ReadOnlySpan<byte> destination, Half value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Half));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteSingle(ReadOnlySpan<byte> destination, float value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(float));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteDouble(ReadOnlySpan<byte> destination, double value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(double));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteIntPtr(ReadOnlySpan<byte> destination, nint value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(nint));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }
}