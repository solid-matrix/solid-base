# SolidBase

## SolidBase.BitsOp

Bits and bytes operation utilities.

### BitsWriter

Write bits to a stream. There are two variants:

- `H2LBitsWriter`: high-to-low order within bytes
- `L2LBitsWriter`: low-to-low order within bytes

Usage:

```c#
IBistWriter bw = new H2LBitsWriter(stream);

// write 9 bits, 0b_100000000. maximum write 32 bits one time.
bw.Write(9, 0b_100000000);

// flush the last few bits left in buffer
bw.Flush();

```



The difference between `L2LBitsWriteer` and `H2LBitsWriter`, the test cases below demonstrate:

```c#
var ms = new MemoryStream();
var bw = new H2LBitsWriter(ms);

// write 9bits sequence 8 times, total 72bits
bw.Write(9, 0b_100000000);
bw.Write(9, 0b_011111111);
bw.Write(9, 0b_100000010);
bw.Write(9, 0b_100000011);
bw.Write(9, 0b_100000100);
bw.Write(9, 0b_100000101);
bw.Write(9, 0b_100000110);
bw.Write(9, 0b_100000111);
bw.Flush();

ms.TryGetBuffer(out var buffer);

// in stream buffer, there are 9 bytes
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
```

If by L2LBitsWriter:

```c#
var ms = new MemoryStream();
var bw = new L2LBitsWriter(ms);

// Write same data
// ...

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
```

### BitsReader

Read bits from a stream. There are two variants:

- `H2LBitsReader`: high-to-low order within bytes
- `L2LBitsReader`: low-to-low order within bytes

Usage:

```c#
IBistReader br = new H2LBitsReader(stream);

// read 11 bits from the stream, maximum read 32 bits one time.
// value= the value read from stream
// countRead = actual bit count read from stream
// once the input stream end, countRead will be less than expected
var countRead = br.Read(11, out var value);
```

## SolidBase.Lzw

Lzw algorithm implementation, with default configuration for TIFF compress usage.

