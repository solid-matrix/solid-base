namespace SolidBase.BitsOp;

public unsafe interface IEndianCodecUnsafe
{
    public static IEndianCodecUnsafe CreateConsistentEndianCodec()
    {
        return new ConsistentEndianCodecUnsafe();
    }

    public static IEndianCodecUnsafe CreateReverseEndianCodec()
    {
        return new ReverseEndianCodecUnsafe();
    }

    public static IEndianCodecUnsafe CreateLittleEndianCodec()
    {
        return BitConverter.IsLittleEndian ? new ConsistentEndianCodecUnsafe() : new ReverseEndianCodecUnsafe();
    }

    public static IEndianCodecUnsafe CreateBigEndianCodec()
    {
        return BitConverter.IsLittleEndian ? new ReverseEndianCodecUnsafe() : new ConsistentEndianCodecUnsafe();
    }

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

    void WriteUInt16(byte* destination, ushort value);

    void WriteInt16(byte* destination, short value);

    void WriteUInt32(byte* destination, uint value);

    void WriteInt32(byte* destination, int value);

    void WriteUInt64(byte* destination, ulong value);

    void WriteInt64(byte* destination, long value);

    void WriteUInt128(byte* destination, UInt128 value);

    void WriteInt128(byte* destination, Int128 value);

    void WriteHalf(byte* destination, Half value);

    void WriteSingle(byte* destination, float value);

    void WriteDouble(byte* destination, double value);

    void WriteIntPtr(byte* destination, nint value);
}