using System.Diagnostics;
using Xunit.Abstractions;

namespace SolidBase.Lzw.Test;

public class LzwEncodeTest(ITestOutputHelper Output)
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
        var lzwBytes = File.ReadAllBytes(TestCases[0].Item2);

        using var ucStream = File.OpenRead(TestCases[0].Item1);
        using var ms = new MemoryStream();

        LzwCodec.Encode(ucStream, ms);

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(lzwBytes.Length, buffer.Count);
            for (int i = 0; i < lzwBytes.Length; i++)
            {
                Assert.Equal(lzwBytes[i], buffer[i]);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void Test2()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[1].Item2);

        using var ucStream = File.OpenRead(TestCases[1].Item1);
        using var ms = new MemoryStream();

        LzwCodec.Encode(ucStream, ms);

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(lzwBytes.Length, buffer.Count);
            for (int i = 0; i < lzwBytes.Length; i++)
            {
                Assert.Equal(lzwBytes[i], buffer[i]);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void Test3()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[2].Item2);

        using var ucStream = File.OpenRead(TestCases[2].Item1);
        using var ms = new MemoryStream();



        LzwCodec.Encode(ucStream, ms);



        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(lzwBytes.Length, buffer.Count);
            for (int i = 0; i < lzwBytes.Length; i++)
            {
                Assert.Equal(lzwBytes[i], buffer[i]);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void Test4()
    {
        var lzwBytes = File.ReadAllBytes(TestCases[3].Item2);

        using var ucStream = File.OpenRead(TestCases[3].Item1);

        using var ms = new MemoryStream(4 * 1024 * 1024);


        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            LzwCodec.Encode(ucStream, ms);

            stopwatch.Stop();
            Output.WriteLine($"Time Spent = {stopwatch.ElapsedMilliseconds}");
        }



        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(lzwBytes.Length, buffer.Count);
            for (int i = 0; i < lzwBytes.Length; i++)
            {
                Assert.Equal(lzwBytes[i], buffer[i]);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
