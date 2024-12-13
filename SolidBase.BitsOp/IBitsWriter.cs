namespace SolidBase.BitsOp;

public interface IBitsWriter
{
    public void Write(int bits, int bitCount);

    public void Write(uint bits, int bitCount);

    public void Flush();
}
