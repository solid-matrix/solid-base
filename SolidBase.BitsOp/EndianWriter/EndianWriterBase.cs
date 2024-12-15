namespace SolidBase.BitsOp;

public unsafe class EndianWriterBase(Stream stream, IEndianCodec codec) : IEndianWriter
{
    public void WriteUInt16(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        codec.WriteUInt16(buffer, value);
        stream.Write(buffer);
    }

    public void WriteInt16(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        codec.WriteInt16(buffer, value);
        stream.Write(buffer);
    }

    public void WriteUInt32(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        codec.WriteUInt32(buffer, value);
        stream.Write(buffer);
    }

    public void WriteInt32(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        codec.WriteInt32(buffer, value);
        stream.Write(buffer);
    }

    public void WriteUInt64(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        codec.WriteUInt64(buffer, value);
        stream.Write(buffer);
    }

    public void WriteInt64(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        codec.WriteInt64(buffer, value);
        stream.Write(buffer);
    }

    public void WriteUInt128(UInt128 value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(UInt128)];
        codec.WriteUInt128(buffer, value);
        stream.Write(buffer);
    }

    public void WriteInt128(Int128 value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(Int128)];
        codec.WriteInt128(buffer, value);
        stream.Write(buffer);
    }

    public void WriteHalf(Half value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(Half)];
        codec.WriteHalf(buffer, value);
        stream.Write(buffer);
    }

    public void WriteSingle(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        codec.WriteSingle(buffer, value);
        stream.Write(buffer);
    }

    public void WriteDouble(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        codec.WriteDouble(buffer, value);
        stream.Write(buffer);
    }

    public void WriteIntPtr(IntPtr value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(IntPtr)];
        codec.WriteIntPtr(buffer, value);
        stream.Write(buffer);
    }
}