namespace SolidBase.BitsOp;

public interface IEndianReader
{
    public static IEndianReader CreateConsistentEndianReader(Stream stream) =>
     new EndianReaderBase(stream, IEndianCodec.CreateConsistentEndianCodec());

    public static IEndianReader CreateReverseEndianReader(Stream stream) =>
        new EndianReaderBase(stream, IEndianCodec.CreateReverseEndianCodec());

    public static IEndianReader CreateLittleEndianReader(Stream stream) =>
        new EndianReaderBase(stream, IEndianCodec.CreateLittleEndianCodec());

    public static IEndianReader CreateBigEndianReader(Stream stream) =>
        new EndianReaderBase(stream, IEndianCodec.CreateBigEndianCodec());

    ushort ReadUInt16();

    short ReadInt16();

    uint ReadUInt32();

    int ReadInt32();

    ulong ReadUInt64();

    long ReadInt64();

    UInt128 ReadUInt128();

    Int128 ReadInt128();

    Half ReadHalf();

    float ReadSingle();

    double ReadDouble();

    nint ReadIntPtr();
}
