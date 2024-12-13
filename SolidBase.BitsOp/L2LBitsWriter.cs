namespace SolidBase.BitsOp;

public class L2LBitsWriter(Stream stream) : IBitsWriter
{
    private ulong _buffer = 0;

    private int _len = 0;

    public void Write(uint bits, int bitCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        _buffer |= (bits & (((ulong)1 << bitCount) - 1)) << _len;
        _len += bitCount;
        while (_len >= 8)
        {
            stream.WriteByte((byte)(_buffer & 0xFF));
            _buffer >>= 8;
            _len -= 8;
        }
    }

    public void Write(int bits, int bitCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        _buffer |= ((ulong)bits & (((ulong)1 << bitCount) - 1)) << _len;
        _len += bitCount;
        while (_len >= 8)
        {
            stream.WriteByte((byte)(_buffer & 0xFF));
            _buffer >>= 8;
            _len -= 8;
        }
    }

    public void Flush()
    {
        if (_len > 0) stream.WriteByte((byte)_buffer);
    }
}
