namespace SolidBase.BitsOp;

public interface IBitsReader
{
    public bool Read(int bitCount, out int value);
}
