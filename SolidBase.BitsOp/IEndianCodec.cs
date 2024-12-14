namespace SolidBase.BitsOp;

public interface IEndianCodec
{
    public static IEndianCodec CreateConsistentEndianCodec() =>
        new ConsistentEndianCodec();

    public static IEndianCodec CreateReverseEndianCodec() =>
        new ReverseEndianCodec();

    public static IEndianCodec CreateLittleEndianCodec() =>
        BitConverter.IsLittleEndian ?
            new ConsistentEndianCodec() :
            new ReverseEndianCodec();

    public static IEndianCodec CreateBigEndianCodec() =>
        BitConverter.IsLittleEndian ?
            new ReverseEndianCodec() :
            new ConsistentEndianCodec();

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
}
