namespace SolidBase.BitsOp.Test;

public class H2LBitsReaderTest
{
    [Fact]
    public void Test0BitRead()
    {
        byte[] buffer = [0b10000000, 0b00111111, 0b11100000, 0b01010000];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;
        count = br.Read(0, out value);

        Assert.Equal(0, count);
        Assert.Equal(0, value);
    }

    [Fact]
    public void TestReadFromEmptyStream()
    {
        byte[] buffer = [];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;
        count = br.Read(8, out value);

        Assert.Equal(0, count);
        Assert.Equal(0, value);
    }

    [Fact]
    public void Test4BitsRead()
    {
        byte[] buffer = [0b10000000, 0b00111111, 0b11100000, 0b01010000];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b1000, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b0000, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b0011, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b1111, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b1110, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b0000, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b0101, value);

        count = br.Read(4, out value);
        Assert.Equal(4, count);
        Assert.Equal(0b0000, value);
    }

    [Fact]
    public void Test5BitsRead()
    {
        byte[] buffer = [0b10000000, 0b00111111, 0b11100000, 0b01010000];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b10000, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b00000, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b11111, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b11110, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b00000, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b10100, value);

        count = br.Read(5, out value);
        Assert.Equal(2, count);
        Assert.Equal(0b00, value);
    }

    [Fact]
    public void Test8BitsRead()
    {
        byte[] buffer = [0b10000000, 0b00111111, 0b11100000, 0b01010000];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;

        count = br.Read(8, out value);
        Assert.Equal(8, count);
        Assert.Equal(0b10000000, value);

        count = br.Read(8, out value);
        Assert.Equal(8, count);
        Assert.Equal(0b00111111, value);

        count = br.Read(8, out value);
        Assert.Equal(8, count);
        Assert.Equal(0b11100000, value);

        count = br.Read(8, out value);
        Assert.Equal(8, count);
        Assert.Equal(0b01010000, value);
    }

    [Fact]
    public void Test11BitsRead()
    {
        byte[] buffer = [0b10000000, 0b00111111, 0b11100000, 0b01010000];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;

        count = br.Read(11, out value);
        Assert.Equal(11, count);
        Assert.Equal(0b10000000001, value);

        count = br.Read(11, out value);
        Assert.Equal(11, count);
        Assert.Equal(0b11111111000, value);

        count = br.Read(11, out value);
        Assert.Equal(10, count);
        Assert.Equal(0b0001010000, value);
    }

    [Fact]
    public void Test32BitsRead()
    {
        byte[] buffer = [0b10000000, 0b00111111, 0b11100000, 0b01010000];
        var ms = new MemoryStream(buffer);
        var br = new H2LBitsReader(ms);

        long value;
        int count;

        count = br.Read(32, out value);
        Assert.Equal(32, count);
        Assert.Equal(0b10000000001111111110000001010000, value);
    }

}
