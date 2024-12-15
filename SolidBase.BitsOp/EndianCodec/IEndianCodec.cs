namespace SolidBase.BitsOp;

public interface IEndianCodec
{
    public static IEndianCodec CreateConsistentEndianCodec()
    {
        return new ConsistentEndianCodec();
    }

    public static IEndianCodec CreateReverseEndianCodec()
    {
        return new ReverseEndianCodec();
    }

    public static IEndianCodec CreateLittleEndianCodec()
    {
        return BitConverter.IsLittleEndian ? new ConsistentEndianCodec() : new ReverseEndianCodec();
    }

    public static IEndianCodec CreateBigEndianCodec()
    {
        return BitConverter.IsLittleEndian ? new ReverseEndianCodec() : new ConsistentEndianCodec();
    }

    ushort ReadUInt16(ReadOnlySpan<byte> source);

    short ReadInt16(ReadOnlySpan<byte> source);

    uint ReadUInt32(ReadOnlySpan<byte> source);

    int ReadInt32(ReadOnlySpan<byte> source);

    ulong ReadUInt64(ReadOnlySpan<byte> source);

    long ReadInt64(ReadOnlySpan<byte> source);

    UInt128 ReadUInt128(ReadOnlySpan<byte> source);

    Int128 ReadInt128(ReadOnlySpan<byte> source);

    Half ReadHalf(ReadOnlySpan<byte> source);

    float ReadSingle(ReadOnlySpan<byte> source);

    double ReadDouble(ReadOnlySpan<byte> source);

    nint ReadIntPtr(ReadOnlySpan<byte> source);

    void WriteUInt16(ReadOnlySpan<byte> destination, ushort value);

    void WriteInt16(ReadOnlySpan<byte> destination, short value);

    void WriteUInt32(ReadOnlySpan<byte> destination, uint value);

    void WriteInt32(ReadOnlySpan<byte> destination, int value);

    void WriteUInt64(ReadOnlySpan<byte> destination, ulong value);

    void WriteInt64(ReadOnlySpan<byte> destination, long value);

    void WriteUInt128(ReadOnlySpan<byte> destination, UInt128 value);

    void WriteInt128(ReadOnlySpan<byte> destination, Int128 value);

    void WriteHalf(ReadOnlySpan<byte> destination, Half value);

    void WriteSingle(ReadOnlySpan<byte> destination, float value);

    void WriteDouble(ReadOnlySpan<byte> destination, double value);

    void WriteIntPtr(ReadOnlySpan<byte> destination, nint value);
}