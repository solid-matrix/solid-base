# SolidBase

- [SolidBase.BitsOp](##SolidBase.BitsOp): Bits and bytes operation utilities.
    - [BitsWriter](###BitsWriter): write bits as byte-packed to a stream
    - [BitsReader](###BitsReader): read byte-packed bits from a stream
    - [EndianCodec](###EndianCodec): convert bytes to value by specific endian (byte order)
    - [EndianCodecUnsafe](###EndianCodecUnsafe): convert bytes to value by specific endian (byte order), in a unsafe way
    - [EndianWriter](###EndianWriter)：write value to a stream by specific endian
    - [EndianReader](###EndianReader): read value from a stream by specific endian
- [SolidBase.Lzw](##SolidBase.Lzw): LZW utilities for 8bits-byte-stream.
    - [LzwCodec](###LzwCodec): LZW compress and decompress.

## SolidBase.BitsOp

### BitsWriter

There are two variants:

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

The difference between `L2LBitsWriteer` and `H2LBitsWriter`, the test code below demonstrate:

With H2LBitsWriter:

```c#
var ms = new MemoryStream();
var bw = new H2LBitsWriter(ms);

// write 4 9-bits sequences, total 36bits
bw.Write(9, 0b_100000000);
bw.Write(9, 0b_011111111);
bw.Write(9, 0b_100000010);
bw.Write(9, 0b_100000011);
bw.Flush();

ms.TryGetBuffer(out var buffer);

// in stream buffer, there are 5 bytes
Assert.Equal(5, buffer.Count);
Assert.Equal(0b_10000000, buffer[0]);
Assert.Equal(0b_00111111, buffer[1]);
Assert.Equal(0b_11100000, buffer[2]);
Assert.Equal(0b_01010000, buffer[3]);
Assert.Equal(0b_00110000, buffer[4]);
```

With L2LBitsWriter

```c#
var ms = new MemoryStream();
var bw = new L2LBitsWriter(ms);

// ... Write same data ...

Assert.Equal(5, buffer.Count);
Assert.Equal(0b_00000000, buffer[0]);
Assert.Equal(0b_11111111, buffer[1]);
Assert.Equal(0b_00001001, buffer[2]);
Assert.Equal(0b_00011100, buffer[3]);
Assert.Equal(0b_00001000, buffer[4]);
```

### BitsReader

There are two variants:

- `H2LBitsReader`: high-to-low order within bytes
- `L2LBitsReader`: low-to-low order within bytes

Usage:

```c#
IBistReader br = new H2LBitsReader(stream);

// read 11 bits from the stream, maximum read 32 bits one time.
// value = the value read from stream
// countRead = actual bit count read from stream
// once the input stream end, countRead will be less than expected
var countRead = br.Read(11, out var value);
```

### EndianCodec

Usage

```c#
// codec for endian consistent with system architecture 
var consistentEndianCodec = IEndianCodec.CreateConsistentEndianCodec();

// codec for endian reversed with system architecture
var reverseEndianCodec = IEndianCodec.CreateReverseEndianCodec();

// codec for reading from / writing to little endian bytes, no matter what system architecture is.
var littleEndianCodec =  IEndianCodec.CreateLittleEndianCodec();

// codec for reading from / writing to big endian bytes, no matter what system architecture is.
var bigEndianCodec = IEndianCodec.CreateBigEndianCodec();
```

### EndianCodecUnsafe

Usage same as `EndianCodec`, but with `byte*` instead with `ReadOnlySpan<byte>` or `Span<byte>`

### EndianWriter

Usage, same logic as `EndianCodec`

```c#
var consistentEndianWriter =  IEndianWriter.CreateConsistentEndianWriter(stream);

var reverseEndianWriter = IEndianWriter.CreateReverseEndianWriter(stream);

var littleEndianWriter = IEndianWriter.CreateLittleEndianWriter(stream);

var bigEndianWriter = IEndianWriter.CreateBigEndianWriter(stream);
```

### EndianReader

Usage, same logic as `EndianWriter`

```c#
var consistentEndianReader =  IEndianReader.CreateConsistentEndianReader(stream);

var reverseEndianReader = IEndianReader.CreateReverseEndianReader(stream);

var littleEndianReader = IEndianReader.CreateLittleEndianReader(stream);

var bigEndianReader = IEndianReader.CreateBigEndianReader(stream);
```

## SolidBase.Lzw

Lzw compress utility for 8bits-byte-stream.

### LzwCodec

Usage

```c#
// default MAX_BIT_COUNT = 12;
var codec = new LzwCodec(MAX_BIT_COUNT);

// encode from inputStream(uncompressed) to outputStream(lzw compressed)
codec.Encode(inputStream, outputStream);

// decode from inputStream(lzw-compressed) to outputStream(uncompressed)
codec.Decode(inputStream, outputStream);
```

