﻿namespace SolidBase.BitsOp.Test;

public class L2LBitsWriterTest
{
    [Fact]
    public void Test1()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        bw.Write(9, 0b_100000000);
        bw.Write(9, 0b_011111111);
        bw.Write(9, 0b_100000010);
        bw.Write(9, 0b_100000011);
        bw.Write(9, 0b_100000100);
        bw.Write(9, 0b_100000101);
        bw.Write(9, 0b_100000110);
        bw.Write(9, 0b_100000111);

        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(9, buffer.Count);
            Assert.Equal(0b_00000000, buffer[0]);
            Assert.Equal(0b_11111111, buffer[1]);
            Assert.Equal(0b_00001001, buffer[2]);
            Assert.Equal(0b_00011100, buffer[3]);
            Assert.Equal(0b_01001000, buffer[4]);
            Assert.Equal(0b_10110000, buffer[5]);
            Assert.Equal(0b_10100000, buffer[6]);
            Assert.Equal(0b_11000001, buffer[7]);
            Assert.Equal(0b_10000011, buffer[8]);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void TestSingleByteWrite()
    {
        for (var value = 0; value <= byte.MaxValue; value++)
        for (var len = 1; len <= 8; len++)
        {
            var ms = new MemoryStream();
            var bw = new L2LBitsWriter(ms);

            bw.Write(len, value);
            bw.Flush();

            if (ms.TryGetBuffer(out var buffer))
                Assert.Equal(value & ((1 << len) - 1), Assert.Single(buffer));
            else
                throw new InvalidOperationException();
        }
    }

    [Fact]
    public void Test0BitString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        bw.Write(0, 0xff);
        bw.Write(0, 0xfe);
        bw.Write(0, 0xfc);
        bw.Write(0, 0xfd);
        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
            Assert.Equal(0, buffer.Count);
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test1BitString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        var bytes = "Hello World!"u8;

        foreach (var b in bytes)
        {
            bw.Write(1, b >> 0);
            bw.Write(1, b >> 1);
            bw.Write(1, b >> 2);
            bw.Write(1, b >> 3);
            bw.Write(1, b >> 4);
            bw.Write(1, b >> 5);
            bw.Write(1, b >> 6);
            bw.Write(1, b >> 7);
        }

        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
            Assert.Collection(buffer,
                v => Assert.Equal((byte)'H', v),
                v => Assert.Equal((byte)'e', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'o', v),
                v => Assert.Equal((byte)' ', v),
                v => Assert.Equal((byte)'W', v),
                v => Assert.Equal((byte)'o', v),
                v => Assert.Equal((byte)'r', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'d', v),
                v => Assert.Equal((byte)'!', v)
            );
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test4BitsString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        var bytes = "Hello World!"u8;

        foreach (var b in bytes)
        {
            bw.Write(4, b);
            bw.Write(4, b >> 4);
        }

        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
            Assert.Collection(buffer,
                v => Assert.Equal((byte)'H', v),
                v => Assert.Equal((byte)'e', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'o', v),
                v => Assert.Equal((byte)' ', v),
                v => Assert.Equal((byte)'W', v),
                v => Assert.Equal((byte)'o', v),
                v => Assert.Equal((byte)'r', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'d', v),
                v => Assert.Equal((byte)'!', v)
            );
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test5BitsString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);


        bw.Write(5, 0b11111);
        bw.Write(5, 0b00000);
        bw.Write(5, 0b10101);
        bw.Write(5, 0b01010);
        bw.Write(5, 0b11011);
        bw.Write(5, 0b10001);
        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(4, buffer.Count);
            Assert.Equal(0b00011111, buffer[0]);
            Assert.Equal(0b01010100, buffer[1]);
            Assert.Equal(0b10110101, buffer[2]);
            Assert.Equal(0b00100011, buffer[3]);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }


    [Fact]
    public void Test8BitsString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        var bytes = "Hello World!"u8;

        foreach (var b in bytes)
            bw.Write(8, b);
        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
            Assert.Collection(buffer,
                v => Assert.Equal((byte)'H', v),
                v => Assert.Equal((byte)'e', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'o', v),
                v => Assert.Equal((byte)' ', v),
                v => Assert.Equal((byte)'W', v),
                v => Assert.Equal((byte)'o', v),
                v => Assert.Equal((byte)'r', v),
                v => Assert.Equal((byte)'l', v),
                v => Assert.Equal((byte)'d', v),
                v => Assert.Equal((byte)'!', v)
            );
        else
            throw new InvalidOperationException();
    }

    [Fact]
    public void Test13BitsString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        bw.Write(13, 0b1010101010101);
        bw.Write(13, 0b1100110011001);
        bw.Write(13, 0b1000100010001);
        bw.Write(13, 0b1011011101111);
        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(7, buffer.Count);
            Assert.Equal(0b_01010101, buffer[0]);
            Assert.Equal(0b_00110101, buffer[1]);
            Assert.Equal(0b_00110011, buffer[2]);
            Assert.Equal(0b_01000111, buffer[3]);
            Assert.Equal(0b_11000100, buffer[4]);
            Assert.Equal(0b_01110111, buffer[5]);
            Assert.Equal(0b_00001011, buffer[6]);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void Test16BitsString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        var nums = new ushort[16];
        for (var i = 0; i < 16; i++) nums[i] = (ushort)(0xff - (1 << i));

        foreach (int num in nums)
            bw.Write(16, num);
        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(32, buffer.Count);
            for (var i = 0; i < 16; i++)
            {
                Assert.Equal(nums[i] & 0xff, buffer[i * 2]);
                Assert.Equal((nums[i] >> 8) & 0xff, buffer[i * 2 + 1]);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void Test32BitsString()
    {
        var ms = new MemoryStream();
        var bw = new L2LBitsWriter(ms);

        var nums = new ushort[32];
        for (var i = 0; i < 32; i++) nums[i] = (ushort)(0xff - (1 << i));

        foreach (int num in nums)
            bw.Write(32, num);
        bw.Flush();

        if (ms.TryGetBuffer(out var buffer))
        {
            Assert.Equal(128, buffer.Count);

            for (var i = 0; i < 32; i++)
            {
                Assert.Equal(nums[i] & 0xff, buffer[i * 4]);
                Assert.Equal((nums[i] >> 8) & 0xff, buffer[i * 4 + 1]);
                Assert.Equal((nums[i] >> 16) & 0xff, buffer[i * 4 + 2]);
                Assert.Equal((nums[i] >> 24) & 0xff, buffer[i * 4 + 3]);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}