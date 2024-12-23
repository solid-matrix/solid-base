﻿using Xunit.Abstractions;

namespace SolidBase.BitsOp.Test;

public class L2LBitsReaderTest(ITestOutputHelper output)
{
    [Fact]
    public void Test0BitRead()
    {
        byte[] buffer = [0b10101010, 0b01010101, 0b11001100, 0b00110011];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        count = br.Read(0, out value);
        Assert.Equal(0, count);
        Assert.Equal(0u, value);
    }

    [Fact]
    public void TestReadFromEmptyStream()
    {
        byte[] buffer = [];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        count = br.Read(8, out value);
        Assert.Equal(0, count);
        Assert.Equal(0u, value);
    }

    [Fact]
    public void Test4BitsRead()
    {
        byte[] buffer = [0b10101010, 0b01010101, 0b11001100, 0b00110011];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        for (var i = 0; i < buffer.Length; i++)
        {
            count = br.Read(4, out value);
            Assert.Equal(4, count);
            Assert.Equal((uint)(buffer[i] & 0xf), value);

            count = br.Read(4, out value);
            Assert.Equal(4, count);
            Assert.Equal((uint)(buffer[i] >> 4), value);
        }
    }


    [Fact]
    public void Test5BitsRead()
    {
        byte[] buffer = [0b10101010, 0b01010101, 0b11001100, 0b10110011];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b01010u, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b01101u, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b10101u, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b11000u, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b11100u, value);

        count = br.Read(5, out value);
        Assert.Equal(5, count);
        Assert.Equal(0b11001u, value);

        count = br.Read(2, out value);
        Assert.Equal(2, count);
        Assert.Equal(0b10u, value);
    }

    [Fact]
    public void Test8BitsRead()
    {
        byte[] buffer = [0b10101010, 0b01010101, 0b11001100, 0b00110011];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        for (var i = 0; i < buffer.Length; i++)
        {
            count = br.Read(8, out value);
            Assert.Equal(8, count);
            Assert.Equal(buffer[i], value);
        }
    }

    [Fact]
    public void Test11BitsRead()
    {
        byte[] buffer = [0b10101010, 0b01010101, 0b11001100, 0b10110011];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        count = br.Read(11, out value);
        Assert.Equal(11, count);
        Assert.Equal(0b10110101010u, value);

        count = br.Read(11, out value);
        Assert.Equal(11, count);
        Assert.Equal(0b00110001010u, value);

        count = br.Read(10, out value);
        Assert.Equal(10, count);
        Assert.Equal(0b1011001111u, value);
    }

    [Fact]
    public void Test32BitsRead()
    {
        byte[] buffer = [0b10101010, 0b01010101, 0b11001100, 0b10110011];
        var ms = new MemoryStream(buffer);
        var br = new L2LBitsReader(ms);

        uint value;
        int count;

        count = br.Read(32, out value);
        Assert.Equal(32, count);
        Assert.Equal(0b10110011110011000101010110101010u, value);
    }
}