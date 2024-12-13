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
        TrieStringTable table = new();

        var bw = new H2LBitsWriter(output);

        ushort codeMax = EOI_CODE;

        ushort size = MIN_CODE_BIT_COUNT;

        var pBuffer = stackalloc byte[1 << MAX_CODE_BIT_COUNT];

        int pLen = 0;

        bw.Write(CLEAR_CODE, size);
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
                bw.Write(table.Get(pBuffer, pLen), size);

                table.Add(pBuffer, pLen + 1, ++codeMax);

                if (((codeMax + 1) >> size) > 0) size++;

                if (codeMax + 3 >= (1 << MAX_CODE_BIT_COUNT))
                {
                    bw.Write(CLEAR_CODE, size);

                    table = new();
                    codeMax = EOI_CODE;
                    size = MIN_CODE_BIT_COUNT;
                }

                pBuffer[0] = pBuffer[pLen];
                pLen = 1;
            }
        }

        bw.Write(table.Get(pBuffer, pLen), size);
        bw.Write(EOI_CODE, size);
        bw.Flush();
    }

    public static void Decode(Stream input, Stream output)
    {
        throw new NotImplementedException();
    }
}