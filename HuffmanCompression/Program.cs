using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace HuffmanCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("./Input.txt");
            var dict =
                HuffmanCode.GetCodeDictionaryFromAlphabet(StringHelper.GetAlphabetAndFrequencyFromText(input));

            var str = new StringBuilder();
            foreach (var a in input)
                str.Append(dict[a]);

            var bitArray = new BitArray(str.ToString().Select(x => x == '1').ToArray());
            StringHelper.WriteInFile(bitArray,  StringHelper.MakeHeaderFromDictionary(dict), "./MyFile.mtre");

            var text = File.ReadAllBytes("./MyFile.mtre");
            var readBytes = Encoding.ASCII.GetString(text).Split(StringHelper.HeaderDelimiter);
            
            var header = readBytes[0];
            var headerByteLength = Encoding.ASCII.GetBytes(header).Length;
            var decodedDict = HuffmanCode.GetCodeDictionaryFromHeader(header.Split(StringHelper.HeaderDelimiter)[0]);
            
            var readBitArray = new BitArray(text.Skip(headerByteLength).ToArray());
            
            File.WriteAllText("./DecodedInput.txt", HuffmanCode.DecodeMessage(readBitArray, decodedDict.ToDictionary(x => x.Value, c => c.Key)));
        }

    }
}