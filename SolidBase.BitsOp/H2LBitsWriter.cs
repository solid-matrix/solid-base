namespace SolidBase.BitsOp;

public class H2LBitsWriter(Stream stream) : IBitsWriter
{
    private ulong _left = 0;

    private int _len = 0;

    public void Write(uint bits, int bitCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        _left = (_left << bitCount) | (bits & (((ulong)1 << bitCount) - 1));
        _len += bitCount;
        while (_len >= 8)
        {
            stream.WriteByte((byte)((_left >> (_len - 8)) & 0xFF));
            _len -= 8;
        }
    }

    public void Write(int bits, int bitCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        _left = (_left << bitCount) | ((ulong)bits & (((ulong)1 << bitCount) - 1));
        _len += bitCount;
        while (_len >= 8)
        {
            stream.WriteByte((byte)((_left >> (_len - 8)) & 0xFF));
            _len -= 8;
        }
    }

    public void Flush()
    {
        if (_len > 0) stream.WriteByte((byte)(_left << (8 - _len)));
    }

}
