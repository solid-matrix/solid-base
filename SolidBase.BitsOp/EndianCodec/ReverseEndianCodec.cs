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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt16(ushort value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ushort));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt16(short value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(short));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt32(uint value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(uint));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32(int value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(int));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt64(ulong value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ulong));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt64(long value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(long));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt128(UInt128 value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(UInt128));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt128(Int128 value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Int128));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteHalf(Half value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Half));
        var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.HalfToUInt16Bits(value));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteSingle(float value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(float));
        var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.SingleToUInt32Bits(value));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteDouble(double value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(double));
        var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToUInt64Bits(value));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteIntPtr(nint value, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(nint));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<ushort> ReadUInt16Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(ushort), 0);
        var values = new ushort[source.Length / sizeof(ushort)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, ushort>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<short> ReadInt16Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(short), 0);
        var values = new short[source.Length / sizeof(short)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, short>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<uint> ReadUInt32Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(uint), 0);
        var values = new uint[source.Length / sizeof(uint)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, uint>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<int> ReadInt32Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(int), 0);
        var values = new int[source.Length / sizeof(int)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, int>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<ulong> ReadUInt64Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(ulong), 0);
        var values = new ulong[source.Length / sizeof(ulong)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, ulong>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<long> ReadInt64Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(long), 0);
        var values = new long[source.Length / sizeof(long)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, long>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<UInt128> ReadUInt128Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(UInt128), 0);
        var values = new UInt128[source.Length / sizeof(UInt128)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, UInt128>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<Int128> ReadInt128Range(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(Int128), 0);
        var values = new Int128[source.Length / sizeof(Int128)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, Int128>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<Half> ReadHalfRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(Half), 0);
        var values = new ushort[source.Length / sizeof(Half)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, ushort>(source), values);
        return MemoryMarshal.Cast<ushort, Half>(values);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<float> ReadSingleRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(float), 0);
        var values = new uint[source.Length / sizeof(float)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, uint>(source), values);
        return MemoryMarshal.Cast<uint, float>(values);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<double> ReadDoubleRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(double), 0);
        var values = new ulong[source.Length / sizeof(double)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, ulong>(source), values);
        return MemoryMarshal.Cast<ulong, double>(values);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<nint> ReadIntPtrRange(ReadOnlySpan<byte> source)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(source.Length % sizeof(nint), 0);
        var values = new nint[source.Length / sizeof(nint)];
        BinaryPrimitives.ReverseEndianness(MemoryMarshal.Cast<byte, nint>(source), values);
        return values;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt16Range(ReadOnlySpan<ushort> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(ushort), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, ushort>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt16Range(ReadOnlySpan<short> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(short), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, short>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt32Range(ReadOnlySpan<uint> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(uint), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, uint>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32Range(ReadOnlySpan<int> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(int), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, int>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt64Range(ReadOnlySpan<ulong> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(ulong), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, ulong>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt64Range(ReadOnlySpan<long> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(long), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, long>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt128Range(ReadOnlySpan<UInt128> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(UInt128), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, UInt128>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt128Range(ReadOnlySpan<Int128> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(Int128), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, Int128>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteHalfRange(ReadOnlySpan<Half> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(Half), destination.Length);
        var srcSpan = MemoryMarshal.Cast<Half, ushort>(source);
        var dstSpan = MemoryMarshal.Cast<byte, ushort>(destination);
        BinaryPrimitives.ReverseEndianness(srcSpan, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteSingleRange(ReadOnlySpan<float> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(float), destination.Length);
        var srcSpan = MemoryMarshal.Cast<float, uint>(source);
        var dstSpan = MemoryMarshal.Cast<byte, uint>(destination);
        BinaryPrimitives.ReverseEndianness(srcSpan, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteDoubleRange(ReadOnlySpan<double> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(double), destination.Length);
        var srcSpan = MemoryMarshal.Cast<double, ulong>(source);
        var dstSpan = MemoryMarshal.Cast<byte, ulong>(destination);
        BinaryPrimitives.ReverseEndianness(srcSpan, dstSpan);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteIntPtrRange(ReadOnlySpan<nint> source, Span<byte> destination)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(source.Length * sizeof(nint), destination.Length);
        var dstSpan = MemoryMarshal.Cast<byte, nint>(destination);
        BinaryPrimitives.ReverseEndianness(source, dstSpan);
    }
}