using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HuffmanCompression
{
    public static class StringHelper
    {
        public const string HeaderDelimiter = "{}";
        public const string HeaderKeyValueDelimiter = "(_";

        public static Dictionary<char, int> GetAlphabetAndFrequencyFromText(string text)
        {
            var result = new ConcurrentDictionary<char, int>();

            foreach (var symbol in text)
                result.AddOrUpdate(symbol, _ => 1, (_, i) => ++i);
            
            return result.ToDictionary(x => x.Key, c => c.Value);
        }

        public static string MakeHeaderFromDictionary(Dictionary<char, string> alphabet)
        {
            var header = new StringBuilder();
            
            foreach (var (key, value) in alphabet)
                header.Append($"{key}{value}{HeaderKeyValueDelimiter}");
            
            header.Append(HeaderDelimiter);
            return header.ToString();
        }
        
        public static void WriteInFile(BitArray array, string header, string path)
        {
            var headerBytes = Encoding.ASCII.GetBytes(header).ToList();
            byte [] bytes = new byte[array.Length / 8 + ( array.Length % 8 == 0 ? 0 : 1 )];
            array.CopyTo( bytes, 0 );
            headerBytes.AddRange(bytes);
            File.WriteAllBytes(path, headerBytes.ToArray());
        }
    }
}