namespace SolidBase.BitsOp;

public interface IBitsWriter
{
    public void Write(int bitCount, long bits);

    public void Flush();
}
