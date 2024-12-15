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
    public void WriteUInt16(ushort value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ushort));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt16(short value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(short));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt32(uint value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(uint));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32(int value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(int));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt64(ulong value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ulong));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt64(long value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(long));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt128(UInt128 value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(UInt128));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt128(Int128 value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Int128));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteHalf(Half value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Half));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteSingle(float value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(float));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteDouble(double value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(double));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteIntPtr(nint value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(nint));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<ushort> ReadUInt16Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(ushort), 0);
        return MemoryMarshal.Cast<byte, ushort>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<short> ReadInt16Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(short), 0);
        return MemoryMarshal.Cast<byte, short>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<uint> ReadUInt32Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(uint), 0);
        return MemoryMarshal.Cast<byte, uint>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<int> ReadInt32Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(int), 0);
        return MemoryMarshal.Cast<byte, int>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<ulong> ReadUInt64Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(ulong), 0);
        return MemoryMarshal.Cast<byte, ulong>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<long> ReadInt64Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(long), 0);
        return MemoryMarshal.Cast<byte, long>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<UInt128> ReadUInt128Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(UInt128), 0);
        return MemoryMarshal.Cast<byte, UInt128>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<Int128> ReadInt128Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(Int128), 0);
        return MemoryMarshal.Cast<byte, Int128>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<Half> ReadHalfRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(Half), 0);
        return MemoryMarshal.Cast<byte, Half>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<float> ReadSingleRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(float), 0);
        return MemoryMarshal.Cast<byte, float>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<double> ReadDoubleRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(double), 0);
        return MemoryMarshal.Cast<byte, double>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<nint> ReadIntPtrRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(nint), 0);
        return MemoryMarshal.Cast<byte, nint>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt16Range(ReadOnlySpan<ushort> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(ushort), destination.Length);
        MemoryMarshal.Cast<ushort, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt16Range(ReadOnlySpan<short> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(short), destination.Length);
        MemoryMarshal.Cast<short, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt32Range(ReadOnlySpan<uint> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(uint), destination.Length);
        MemoryMarshal.Cast<uint, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32Range(ReadOnlySpan<int> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(int), destination.Length);
        MemoryMarshal.Cast<int, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt64Range(ReadOnlySpan<ulong> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(ulong), destination.Length);
        MemoryMarshal.Cast<ulong, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt64Range(ReadOnlySpan<long> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(long), destination.Length);
        MemoryMarshal.Cast<long, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt128Range(ReadOnlySpan<UInt128> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(UInt128), destination.Length);
        MemoryMarshal.Cast<UInt128, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt128Range(ReadOnlySpan<Int128> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(Int128), destination.Length);
        MemoryMarshal.Cast<Int128, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteHalfRange(ReadOnlySpan<Half> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(Half), destination.Length);
        MemoryMarshal.Cast<Half, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteSingleRange(ReadOnlySpan<float> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(float), destination.Length);
        MemoryMarshal.Cast<float, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteDoubleRange(ReadOnlySpan<double> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(double), destination.Length);
        MemoryMarshal.Cast<double, byte>(source).CopyTo(destination);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteIntPtrRange(ReadOnlySpan<nint> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(nint), destination.Length);
        MemoryMarshal.Cast<nint, byte>(source).CopyTo(destination);
    }
}