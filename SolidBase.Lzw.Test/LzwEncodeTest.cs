namespace SolidBase.Lzw.Test;

public class LzwEncodeTest
{
    private static readonly Tuple<string, string>[] TestCases =
    [
        new("../../../tests/1-uc", "../../../tests/1-lzw"),
        new("../../../tests/2-uc", "../../../tests/2-lzw"),
        new("../../../tests/3-uc", "../../../tests/3-lzw"),
        new("../../../tests/4-uc", "../../../tests/4-lzw")
    ];

    [Fact]
    public void Test1()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[0].Item2);

        using var ucStream = File.OpenRead(TestCases[0].Item1);
        using var ms = new MemoryStream();

        new LzwCodec().Encode(ucStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(lzwBytes, buffer);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test2()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[1].Item2);

        using var ucStream = File.OpenRead(TestCases[1].Item1);
        using var ms = new MemoryStream();

        new LzwCodec().Encode(ucStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(lzwBytes, buffer);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test3()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[2].Item2);

        using var ucStream = File.OpenRead(TestCases[2].Item1);
        using var ms = new MemoryStream();

        new LzwCodec().Encode(ucStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(lzwBytes, buffer);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test4()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[3].Item2);

        using var ucStream = File.OpenRead(TestCases[3].Item1);

        using var ms = new MemoryStream(4 * 1024 * 1024);

        new LzwCodec().Encode(ucStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(lzwBytes, buffer);
        else
            throw new InvalidOperationException();
    }
}