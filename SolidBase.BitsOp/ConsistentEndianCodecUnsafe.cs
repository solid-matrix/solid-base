using System.Runtime.CompilerServices;

namespace SolidBase.BitsOp;

public unsafe class ConsistentEndianCodecUnsafe : IEndianCodecUnsafe
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort ReadUInt16(byte* source)
    {
        return Unsafe.ReadUnaligned<ushort>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short ReadInt16(byte* source)
    {
        return Unsafe.ReadUnaligned<short>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ReadUInt32(byte* source)
    {
        return Unsafe.ReadUnaligned<uint>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ReadInt32(byte* source)
    {
        return Unsafe.ReadUnaligned<int>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong ReadUInt64(byte* source)
    {
        return Unsafe.ReadUnaligned<ulong>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ReadInt64(byte* source)
    {
        return Unsafe.ReadUnaligned<long>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UInt128 ReadUInt128(byte* source)
    {
        return Unsafe.ReadUnaligned<UInt128>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Int128 ReadInt128(byte* source)
    {
        return Unsafe.ReadUnaligned<Int128>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Half ReadHalf(byte* source)
    {
        return Unsafe.ReadUnaligned<Half>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float ReadSingle(byte* source)
    {
        return Unsafe.ReadUnaligned<float>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double ReadDouble(byte* source)
    {
        return Unsafe.ReadUnaligned<double>(source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint ReadIntPtr(byte* source)
    {
        return Unsafe.ReadUnaligned<nint>(source);
    }
}
