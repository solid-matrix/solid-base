namespace SolidBase.BitsOp;

public unsafe class EndianWriterBase(Stream stream, IEndianCodec codec) : IEndianWriter
{
    public void WriteUInt16(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        codec.WriteUInt16(value, buffer);
        stream.Write(buffer);
    }

    public void WriteInt16(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        codec.WriteInt16(value, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt32(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        codec.WriteUInt32(value, buffer);
        stream.Write(buffer);
    }

    public void WriteInt32(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        codec.WriteInt32(value, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt64(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        codec.WriteUInt64(value, buffer);
        stream.Write(buffer);
    }

    public void WriteInt64(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        codec.WriteInt64(value, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt128(UInt128 value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(UInt128)];
        codec.WriteUInt128(value, buffer);
        stream.Write(buffer);
    }

    public void WriteInt128(Int128 value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(Int128)];
        codec.WriteInt128(value, buffer);
        stream.Write(buffer);
    }

    public void WriteHalf(Half value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(Half)];
        codec.WriteHalf(value, buffer);
        stream.Write(buffer);
    }

    public void WriteSingle(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        codec.WriteSingle(value, buffer);
        stream.Write(buffer);
    }

    public void WriteDouble(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        codec.WriteDouble(value, buffer);
        stream.Write(buffer);
    }

    public void WriteIntPtr(nint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(nint)];
        codec.WriteIntPtr(value, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt16Range(ReadOnlySpan<ushort> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(ushort)];
        codec.WriteUInt16Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteInt16Range(ReadOnlySpan<short> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(short)];
        codec.WriteInt16Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt32Range(ReadOnlySpan<uint> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(uint)];
        codec.WriteUInt32Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteInt32Range(ReadOnlySpan<int> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(int)];
        codec.WriteInt32Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt64Range(ReadOnlySpan<ulong> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(ulong)];
        codec.WriteUInt64Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteInt64Range(ReadOnlySpan<long> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(long)];
        codec.WriteInt64Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteUInt128Range(ReadOnlySpan<UInt128> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(UInt128)];
        codec.WriteUInt128Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteInt128Range(ReadOnlySpan<Int128> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(Int128)];
        codec.WriteInt128Range(source, buffer);
        stream.Write(buffer);
    }

    public void WriteHalfRange(ReadOnlySpan<Half> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(Half)];
        codec.WriteHalfRange(source, buffer);
        stream.Write(buffer);
    }

    public void WriteSingleRange(ReadOnlySpan<float> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(float)];
        codec.WriteSingleRange(source, buffer);
        stream.Write(buffer);
    }

    public void WriteDoubleRange(ReadOnlySpan<double> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(double)];
        codec.WriteDoubleRange(source, buffer);
        stream.Write(buffer);
    }

    public void WriteIntPtrRange(ReadOnlySpan<IntPtr> source)
    {
        Span<byte> buffer = stackalloc byte[source.Length * sizeof(IntPtr)];
        codec.WriteIntPtrRange(source, buffer);
        stream.Write(buffer);
    }
}