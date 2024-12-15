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
    public void WriteUInt16(ReadOnlySpan<byte> destination, ushort value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ushort));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt16(ReadOnlySpan<byte> destination, short value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(short));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt32(ReadOnlySpan<byte> destination, uint value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(uint));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32(ReadOnlySpan<byte> destination, int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(int));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt64(ReadOnlySpan<byte> destination, ulong value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(ulong));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt64(ReadOnlySpan<byte> destination, long value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(long));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteUInt128(ReadOnlySpan<byte> destination, UInt128 value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(UInt128));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt128(ReadOnlySpan<byte> destination, Int128 value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Int128));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteHalf(ReadOnlySpan<byte> destination, Half value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(Half));
        var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.HalfToUInt16Bits(value));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteSingle(ReadOnlySpan<byte> destination, float value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(float));
        var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.SingleToUInt32Bits(value));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteDouble(ReadOnlySpan<byte> destination, double value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(double));
        var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToUInt64Bits(value));
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteIntPtr(ReadOnlySpan<byte> destination, nint value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, sizeof(nint));
        var tmp = BinaryPrimitives.ReverseEndianness(value);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), tmp);
    }
}