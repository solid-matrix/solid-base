using SolidBase.BitsOp;

namespace SolidBase.Lzw;

public unsafe class LzwCodec
{
    public const int MIN_CODE_BIT_COUNT = 9;

    public const int MAX_CODE_BIT_COUNT = 12;

    public const int CLEAR_CODE = 256;

    public const int EOI_CODE = 257;

    public static void Encode(Stream input, Stream output)
    {
        var bw = new H2LBitsWriter(output);

        TrieStringTable table = new(MAX_CODE_BIT_COUNT);

        var codeMax = EOI_CODE;

        var size = MIN_CODE_BIT_COUNT;

        var pBuffer = stackalloc byte[1 << MAX_CODE_BIT_COUNT];

        int pLen = 0;

        bw.Write(size, CLEAR_CODE);
        while (true)
        {
            int tmp = input.ReadByte();
            if (tmp == -1) break;
            pBuffer[pLen] = (byte)tmp;

            if (table.Exist(pBuffer, pLen + 1))
            {
                pLen++;
            }
            else
            {
                bw.Write(size, table.Get(pBuffer, pLen));

                table.Add(pBuffer, pLen + 1, ++codeMax);

                if (((codeMax + 1) >> size) > 0) size++;

                if (codeMax + 3 >= (1 << MAX_CODE_BIT_COUNT))
                {
                    bw.Write(size, CLEAR_CODE);

                    table = new(MAX_CODE_BIT_COUNT);
                    codeMax = EOI_CODE;
                    size = MIN_CODE_BIT_COUNT;
                }

                pBuffer[0] = pBuffer[pLen];
                pLen = 1;
            }
        }

        bw.Write(size, table.Get(pBuffer, pLen));
        bw.Write(size, EOI_CODE);
        bw.Flush();
    }

    public static void Decode(Stream input, Stream output)
    {
        var br = new H2LBitsReader(input);

        byte[][] table = null!;
        uint codeMax = EOI_CODE;
        int size = MIN_CODE_BIT_COUNT;

        byte[]? p = null;

        while (true)
        {
            int codeSize = br.Read(size, out uint code);
            if (codeSize != size) throw new Exception("fail to read code");
            if (code == EOI_CODE) break;

            if (code == CLEAR_CODE)
            {
                table = new byte[1 << MAX_CODE_BIT_COUNT][];
                for (uint i = 0; i < 256; i++) table[i] = [(byte)i];

                codeMax = EOI_CODE;
                size = MIN_CODE_BIT_COUNT;
                p = null;
            }
            else
            {
                byte[] k = table[code];

                if (k != null)
                {
                    output.Write(k);

                    if (p != null)
                    {
                        ++codeMax;
                        table[codeMax] = [.. p, k[0]];
                        if (((codeMax + 2) >> size) > 0) size++;
                    }

                    p = k;
                }
                else
                {
                    k = [.. p, p![0]];

                    output.Write(k);

                    ++codeMax;
                    table[codeMax] = k;
                    if (((codeMax + 2) >> size) > 0) size++;

                    p = k;
                }
            }
        }

    }
}