namespace SolidBase.BitsOp;

public unsafe interface IEndianCodecUnsafe
{
    public static IEndianCodecUnsafe CreateConsistentEndianCodec() =>
        new ConsistentEndianCodecUnsafe();

    public static IEndianCodecUnsafe CreateReverseEndianCodec() =>
        new ReverseEndianCodecUnsafe();

    public static IEndianCodecUnsafe CreateLittleEndianCodec() =>
        BitConverter.IsLittleEndian ?
            new ConsistentEndianCodecUnsafe() :
            new ReverseEndianCodecUnsafe();

    public static IEndianCodecUnsafe CreateBigEndianCodec() =>
        BitConverter.IsLittleEndian ?
            new ReverseEndianCodecUnsafe() :
            new ConsistentEndianCodecUnsafe();

    ushort ReadUInt16(byte* source);

    short ReadInt16(byte* source);

    uint ReadUInt32(byte* source);

    int ReadInt32(byte* source);

    ulong ReadUInt64(byte* source);

    long ReadInt64(byte* source);

    UInt128 ReadUInt128(byte* source);

    Int128 ReadInt128(byte* source);

    Half ReadHalf(byte* source);

    float ReadSingle(byte* source);

    double ReadDouble(byte* source);

    nint ReadIntPtr(byte* source);

}
