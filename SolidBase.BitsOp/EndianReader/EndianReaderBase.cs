﻿namespace SolidBase.BitsOp;

public unsafe class EndianReaderBase(Stream stream, IEndianCodec codec) : IEndianReader
{
    public ushort ReadUInt16()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        stream.ReadExactly(buffer);
        return codec.ReadUInt16(buffer);
    }

    public short ReadInt16()
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        stream.ReadExactly(buffer);
        return codec.ReadInt16(buffer);
    }

    public uint ReadUInt32()
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        stream.ReadExactly(buffer);
        return codec.ReadUInt32(buffer);
    }

    public int ReadInt32()
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        stream.ReadExactly(buffer);
        return codec.ReadInt32(buffer);
    }

    public ulong ReadUInt64()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        stream.ReadExactly(buffer);
        return codec.ReadUInt64(buffer);
    }

    public long ReadInt64()
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        stream.ReadExactly(buffer);
        return codec.ReadInt64(buffer);
    }

    public UInt128 ReadUInt128()
    {
        Span<byte> buffer = stackalloc byte[sizeof(UInt128)];
        stream.ReadExactly(buffer);
        return codec.ReadUInt128(buffer);
    }

    public Int128 ReadInt128()
    {
        Span<byte> buffer = stackalloc byte[sizeof(Int128)];
        stream.ReadExactly(buffer);
        return codec.ReadInt128(buffer);
    }

    public Half ReadHalf()
    {
        Span<byte> buffer = stackalloc byte[sizeof(Half)];
        stream.ReadExactly(buffer);
        return codec.ReadHalf(buffer);
    }

    public float ReadSingle()
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        stream.ReadExactly(buffer);
        return codec.ReadSingle(buffer);
    }

    public double ReadDouble()
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        stream.ReadExactly(buffer);
        return codec.ReadDouble(buffer);
    }

    public nint ReadIntPtr()
    {
        Span<byte> buffer = stackalloc byte[sizeof(nint)];
        stream.ReadExactly(buffer);
        return codec.ReadIntPtr(buffer);
    }
}