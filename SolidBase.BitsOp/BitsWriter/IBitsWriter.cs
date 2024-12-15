namespace SolidBase.BitsOp;

public interface IBitsWriter
{
    public void Write(int bitCount, uint value);

    public void Write(int bitCount, int value);

    public void Flush();
}