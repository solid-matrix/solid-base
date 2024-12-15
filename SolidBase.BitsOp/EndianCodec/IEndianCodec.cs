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

    void WriteUInt16(ushort value, Span<byte> destination);

    void WriteInt16(short value, Span<byte> destination);

    void WriteUInt32(uint value, Span<byte> destination);

    void WriteInt32(int value, Span<byte> destination);

    void WriteUInt64(ulong value, Span<byte> destination);

    void WriteInt64(long value, Span<byte> destination);

    void WriteUInt128(UInt128 value, Span<byte> destination);

    void WriteInt128(Int128 value, Span<byte> destination);

    void WriteHalf(Half value, Span<byte> destination);

    void WriteSingle(float value, Span<byte> destination);

    void WriteDouble(double value, Span<byte> destination);

    void WriteIntPtr(nint value, Span<byte> destination);

    ReadOnlySpan<ushort> ReadUInt16Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<short> ReadInt16Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<uint> ReadUInt32Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<int> ReadInt32Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<ulong> ReadUInt64Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<long> ReadInt64Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<UInt128> ReadUInt128Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<Int128> ReadInt128Range(ReadOnlySpan<byte> source);

    ReadOnlySpan<Half> ReadHalfRange(ReadOnlySpan<byte> source);

    ReadOnlySpan<float> ReadSingleRange(ReadOnlySpan<byte> source);

    ReadOnlySpan<double> ReadDoubleRange(ReadOnlySpan<byte> source);

    ReadOnlySpan<nint> ReadIntPtrRange(ReadOnlySpan<byte> source);

    void WriteUInt16Range(ReadOnlySpan<ushort> source, Span<byte> destination);

    void WriteInt16Range(ReadOnlySpan<short> source, Span<byte> destination);

    void WriteUInt32Range(ReadOnlySpan<uint> source, Span<byte> destination);

    void WriteInt32Range(ReadOnlySpan<int> source, Span<byte> destination);

    void WriteUInt64Range(ReadOnlySpan<ulong> source, Span<byte> destination);

    void WriteInt64Range(ReadOnlySpan<long> source, Span<byte> destination);

    void WriteUInt128Range(ReadOnlySpan<UInt128> source, Span<byte> destination);

    void WriteInt128Range(ReadOnlySpan<Int128> source, Span<byte> destination);

    void WriteHalfRange(ReadOnlySpan<Half> source, Span<byte> destination);

    void WriteSingleRange(ReadOnlySpan<float> source, Span<byte> destination);

    void WriteDoubleRange(ReadOnlySpan<double> source, Span<byte> destination);

    void WriteIntPtrRange(ReadOnlySpan<nint> source, Span<byte> destination);
}