namespace SolidBase.Lzw;

public unsafe class TrieStringTable
{
    readonly ushort[][] _child;
    readonly int[] _value;
    ushort _size;

    public TrieStringTable(int maxSize = 12)
    {
        _child = new ushort[1 << maxSize][];
        _value = new int[1 << maxSize];
        _child[0] = new ushort[256];
        for (ushort i = 0; i < 256; i++)
        {
            _child[0][i] = (ushort)(i + 1);
            _child[i + 1] = new ushort[256];
            _value[i + 1] = i;
        }
        _size = 257;
    }

    public bool Exist(byte* str, int len)
    {
        int node = 0;
        for (int i = 0; i < len; i++)
        {
            var tmp = _child[node][str[i]];
            if (tmp == 0) return false;
            node = tmp;

        }
        return true;
    }

    public int Get(byte* str, int len)
    {
        int node = 0;
        for (int i = 0; i < len; i++) node = _child[node][str[i]];
        return _value[node];
    }

    public void Add(byte* str, int len, int value)
    {
        var node = 0;
        for (int i = 0; i < len - 1; i++) node = _child[node][str[i]];
        _value[_size] = value;
        _child[_size] = new ushort[256];
        _child[node][str[len - 1]] = _size++;
    }

}


//public unsafe class TrieStringTable2
//{
//    public class TrieNode(int value)
//    {
//        public TrieNode[] Children = new TrieNode[256];
//        public int Value = value;
//    }

//    public TrieNode Root;

//    public TrieStringTable2()
//    {
//        Root = new TrieNode(0);
//        for (int i = 0; i < 256; i++) Root.Children[i] = new TrieNode(i);
//    }

//    public bool Exist(byte* str, int len)
//    {
//        var node = Root;
//        for (int i = 0; i < len; i++)
//        {
//            if (node.Children[str[i]] == null) return false;
//            node = node.Children[str[i]];
//        }
//        return true;
//    }

//    public int Get(byte* str, int len)
//    {
//        var node = Root;
//        for (int i = 0; i < len; i++) node = node.Children[str[i]];
//        return node.Value;
//    }

//    public void Add(byte* str, int len, int value)
//    {
//        var node = Root;
//        for (int i = 0; i < len - 1; i++) node = node.Children[str[i]];
//        node.Children[str[len - 1]] = new TrieNode(value);
//    }
//}
