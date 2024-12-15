namespace SolidBase.BitsOp;

public class L2LBitsWriter(Stream stream) : IBitsWriter
{
    private long _left;

    private int _len;

    public void Write(int bitCount, uint value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        _left |= (value & (((long)1 << bitCount) - 1)) << _len;
        _len += bitCount;
        while (_len >= 8)
        {
            stream.WriteByte((byte)(_left & 0xFF));
            _left >>= 8;
            _len -= 8;
        }
    }

    public void Write(int bitCount, int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        _left |= (value & (((long)1 << bitCount) - 1)) << _len;
        _len += bitCount;
        while (_len >= 8)
        {
            stream.WriteByte((byte)(_left & 0xFF));
            _left >>= 8;
            _len -= 8;
        }
    }

    public void Flush()
    {
        if (_len > 0) stream.WriteByte((byte)_left);
    }
}