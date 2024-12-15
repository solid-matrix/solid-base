namespace SolidBase.BitsOp;

public interface IEndianWriter
{
    public static IEndianWriter CreateConsistentEndianWriter(Stream stream)
    {
        return new EndianWriterBase(stream, IEndianCodec.CreateConsistentEndianCodec());
    }

    public static IEndianWriter CreateReverseEndianWriter(Stream stream)
    {
        return new EndianWriterBase(stream, IEndianCodec.CreateReverseEndianCodec());
    }

    public static IEndianWriter CreateLittleEndianWriter(Stream stream)
    {
        return new EndianWriterBase(stream, IEndianCodec.CreateLittleEndianCodec());
    }

    public static IEndianWriter CreateBigEndianWriter(Stream stream)
    {
        return new EndianWriterBase(stream, IEndianCodec.CreateBigEndianCodec());
    }

    void WriteUInt16(ushort value);

    void WriteInt16(short value);

    void WriteUInt32(uint value);

    void WriteInt32(int value);

    void WriteUInt64(ulong value);

    void WriteInt64(long value);

    void WriteUInt128(UInt128 value);

    void WriteInt128(Int128 value);

    void WriteHalf(Half value);

    void WriteSingle(float value);

    void WriteDouble(double value);

    void WriteIntPtr(nint value);
}