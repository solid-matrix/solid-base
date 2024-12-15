namespace SolidBase.BitsOp;

public interface IEndianReader
{
    public static IEndianReader CreateConsistentEndianReader(Stream stream)
    {
        return new EndianReaderBase(stream, IEndianCodec.CreateConsistentEndianCodec());
    }

    public static IEndianReader CreateReverseEndianReader(Stream stream)
    {
        return new EndianReaderBase(stream, IEndianCodec.CreateReverseEndianCodec());
    }

    public static IEndianReader CreateLittleEndianReader(Stream stream)
    {
        return new EndianReaderBase(stream, IEndianCodec.CreateLittleEndianCodec());
    }

    public static IEndianReader CreateBigEndianReader(Stream stream)
    {
        return new EndianReaderBase(stream, IEndianCodec.CreateBigEndianCodec());
    }

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

    ReadOnlySpan<ushort> ReadUInt16Range(int count);

    ReadOnlySpan<short> ReadInt16Range(int count);

    ReadOnlySpan<uint> ReadUInt32Range(int count);

    ReadOnlySpan<int> ReadInt32Range(int count);

    ReadOnlySpan<ulong> ReadUInt64Range(int count);

    ReadOnlySpan<long> ReadInt64Range(int count);

    ReadOnlySpan<UInt128> ReadUInt128Range(int count);

    ReadOnlySpan<Int128> ReadInt128Range(int count);

    ReadOnlySpan<Half> ReadHalfRange(int count);

    ReadOnlySpan<float> ReadSingleRange(int count);

    ReadOnlySpan<double> ReadDoubleRange(int count);

    ReadOnlySpan<nint> ReadIntPtrRange(int count);
}