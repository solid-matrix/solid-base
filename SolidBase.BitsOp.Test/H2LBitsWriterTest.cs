namespace SolidBase.BitsOp.Test;

public class H2LBitsWriterTest
{
    [Fact]
    public void TestCase1()
    {
        var ms = new MemoryStream();
        var bw = new H2LBitsWriter(ms);

        bw.Write(0b_100000000, 9);
        bw.Write(0b_011111111, 9);
        bw.Write(0b_100000010, 9);
        bw.Write(0b_100000011, 9);
        bw.Write(0b_100000100, 9);
        bw.Write(0b_100000101, 9);
        bw.Write(0b_100000110, 9);
        bw.Write(0b_100000111, 9);

        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(9, buffer.Count);

            Assert.Equal(0b_10000000, buffer[0]);
            Assert.Equal(0b_00111111, buffer[1]);
            Assert.Equal(0b_11100000, buffer[2]);
            Assert.Equal(0b_01010000, buffer[3]);
            Assert.Equal(0b_00111000, buffer[4]);
            Assert.Equal(0b_00100100, buffer[5]);
            Assert.Equal(0b_00010110, buffer[6]);
            Assert.Equal(0b_00001101, buffer[7]);
            Assert.Equal(0b_00000111, buffer[8]);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
