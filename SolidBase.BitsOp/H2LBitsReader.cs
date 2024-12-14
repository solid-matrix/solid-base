namespace SolidBase.BitsOp;

public class H2LBitsReader(Stream stream) : IBitsReader
{
    private long _left = 0;
    private int _len = 0;

    public int Read(int bitCount, out long value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 32);

        int tmp;
        while (_len <= bitCount)
        {
            tmp = stream.ReadByte();
            if (tmp < 0) break;
            _left = (_left << 8) | (long)tmp;
            _len += 8;
        }

        tmp = Math.Min(bitCount, _len);

        value = (_left >> (_len - tmp)) & (((long)1 << tmp) - 1);
        _len -= tmp;

        return tmp;
    }
}
