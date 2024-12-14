namespace SolidBase.BitsOp;

public interface IBitsReader
{
    public int Read(int bitCount, out uint value);
}
