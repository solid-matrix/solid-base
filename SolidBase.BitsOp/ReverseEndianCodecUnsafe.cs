using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace SolidBase.BitsOp;

public unsafe class ReverseEndianCodecUnsafe : IEndianCodecUnsafe
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort ReadUInt16(byte* source)
    {
        var value = Unsafe.ReadUnaligned<ushort>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short ReadInt16(byte* source)
    {
        var value = Unsafe.ReadUnaligned<short>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ReadUInt32(byte* source)
    {
        var value = Unsafe.ReadUnaligned<uint>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ReadInt32(byte* source)
    {
        var value = Unsafe.ReadUnaligned<int>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong ReadUInt64(byte* source)
    {
        var value = Unsafe.ReadUnaligned<ulong>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ReadInt64(byte* source)
    {
        var value = Unsafe.ReadUnaligned<long>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UInt128 ReadUInt128(byte* source)
    {
        var value = Unsafe.ReadUnaligned<UInt128>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int128 ReadInt128(byte* source)
    {
        var value = Unsafe.ReadUnaligned<Int128>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Half ReadHalf(byte* source)
    {
        var value = Unsafe.ReadUnaligned<ushort>(source);
        return BitConverter.UInt16BitsToHalf(BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float ReadSingle(byte* source)
    {
        var value = Unsafe.ReadUnaligned<uint>(source);
        return BitConverter.UInt32BitsToSingle(BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ReadDouble(byte* source)
    {
        var value = Unsafe.ReadUnaligned<ulong>(source);
        return BitConverter.UInt64BitsToDouble(BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint ReadIntPtr(byte* source)
    {
        var value = Unsafe.ReadUnaligned<nint>(source);
        return BinaryPrimitives.ReverseEndianness(value);
    }
}
