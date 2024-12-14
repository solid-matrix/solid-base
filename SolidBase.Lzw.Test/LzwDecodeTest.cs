﻿namespace SolidBase.Lzw.Test;

public class LzwDecodeTest
{
    static Tuple<string, string>[] TestCases = [
        new Tuple<string,string>("../../../tests/1-uc","../../../tests/1-lzw"),
        new Tuple<string,string>("../../../tests/2-uc","../../../tests/2-lzw"),
        new Tuple<string,string>("../../../tests/3-uc","../../../tests/3-lzw"),
        new Tuple<string,string>("../../../tests/4-uc","../../../tests/4-lzw"),
        ];

    [Fact]
    public void Test1()
    {
        var lzwStream = File.OpenRead(TestCases[0].Item2);

        var ucBytes = File.ReadAllBytes(TestCases[0].Item1);

        using var ms = new MemoryStream();

        LzwCodec.Decode(lzwStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(ucBytes, buffer);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test2()
    {
        var lzwStream = File.OpenRead(TestCases[1].Item2);

        var ucBytes = File.ReadAllBytes(TestCases[1].Item1);

        using var ms = new MemoryStream();

        LzwCodec.Decode(lzwStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(ucBytes, buffer);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test3()
    {
        var lzwStream = File.OpenRead(TestCases[2].Item2);

        var ucBytes = File.ReadAllBytes(TestCases[2].Item1);

        using var ms = new MemoryStream();

        LzwCodec.Decode(lzwStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(ucBytes, buffer);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test4()
    {
        var lzwStream = File.OpenRead(TestCases[3].Item2);

        var ucBytes = File.ReadAllBytes(TestCases[3].Item1);

        using var ms = new MemoryStream();

        LzwCodec.Decode(lzwStream, ms);

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(ucBytes, buffer);
        else
            throw new InvalidOperationException();
    }
}