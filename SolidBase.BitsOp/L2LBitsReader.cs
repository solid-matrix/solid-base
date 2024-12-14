namespace SolidBase.BitsOp;

public class L2LBitsReader(Stream stream) : IBitsReader
{
    private long _left = 0;
    private int _len = 0;

    public int Read(int bitCount, out uint value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        int tmp;
        while (_len <= bitCount)
        {
            tmp = stream.ReadByte();
            if (tmp < 0) break;
            _left |= (long)tmp << _len;
            _len += 8;
        }

        tmp = Math.Min(bitCount, _len);

        value = (uint)(_left & (((long)1 << tmp) - 1));
        _left >>= tmp;
        _len -= tmp;
        return tmp;
    }
}
