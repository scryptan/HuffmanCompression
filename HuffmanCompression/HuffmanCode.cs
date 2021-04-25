using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanCompression
{
    public static class HuffmanCode
    {
        public static Node GetTreeFromDict(Dictionary<char, int> alphabet)
        {
            var list = alphabet.Select(x => new Node {Frequency = x.Value, Symbol = x.Key}).OrderBy(x => x.Frequency)
                .ToList();
            while (list.Count > 1)
            {
                var first = list[0];
                list.RemoveAt(0);
                var second = list[0];
                list.RemoveAt(0);

                var parent = new Node
                {
                    Frequency = first.Frequency += second.Frequency,
                    Left = first,
                    Right = second,
                };
                first.Parent = parent;
                second.Parent = parent;
                first.Code = false;
                second.Code = true;

                list.Add(parent);

                list = list.OrderBy(x => x.Frequency).ToList();
            }

            return list.SingleOrDefault();
        }

        public static List<Node> GetListOfTree(Node root)
        {
            var list = new List<Node>();
            if (root.Left != null)
                list.AddRange(GetListOfTree(root.Left));

            if (root.Right != null)
                list.AddRange(GetListOfTree(root.Right));

            if (root.Symbol != null)
                list.Add(root);

            return list;
        }

        public static string GetCodeFromLeaf(Node leaf)
        {
            var code = "";
            while (leaf.Parent != null)
            {
                code += Convert.ToByte(leaf.Code);
                leaf = leaf.Parent;
            }

            return new string(code.Reverse().ToArray());
        }

        public static Dictionary<char, string> GetCodeDictionaryFromAlphabet(Dictionary<char, int> alphabet)
        {
            var dict = new Dictionary<char, string>();
            foreach (var i in GetListOfTree(GetTreeFromDict(alphabet)))
            {
                var code = GetCodeFromLeaf(i);
                if (i.Symbol != null)
                    dict.Add((char) i.Symbol!, code);
            }

            return dict;
        }

        public static Dictionary<char, string> GetCodeDictionaryFromHeader(string header)
        {
            var keValuePairs =
                header.Split(StringHelper.HeaderKeyValueDelimiter, StringSplitOptions.RemoveEmptyEntries);
            return keValuePairs.ToDictionary(x => x[0], x => x.Substring(1));
        }

        public static string DecodeMessage(BitArray content, Dictionary<string, char> alphabet)
        {
            var result = new StringBuilder();

            var tempStr = new StringBuilder();
            foreach (bool b in content)
            {
                tempStr.Append(b ? "1" : "0");
                if (alphabet.TryGetValue(tempStr.ToString(), out var symbol))
                {
                    tempStr.Clear();
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }
    }
}