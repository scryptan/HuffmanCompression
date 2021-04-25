using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using HuffmanCompression;
using Microsoft.Win32;

namespace FrontApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _readPath;
        private string _savePath;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ArchiveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_readPath))
            {
                MessageBox.Show(this, "Не выбран файл для архивирования");
                return;
            }

            if (!File.Exists(_readPath))
            {
                MessageBox.Show(this, $"Неправильный путь {_readPath}");
                return;
            }
            
            if (string.IsNullOrEmpty(_savePath))
            {
                MessageBox.Show(this, "Не выбран файл для сохранения архивированного файла");
                return;
            }

            if (!File.Exists(_savePath))
            {
                MessageBox.Show(this, $"Неправильный путь {_savePath}");
                return;
            }
            
            var input = File.ReadAllText(_readPath);
            var dict =
                HuffmanCode.GetCodeDictionaryFromAlphabet(StringHelper.GetAlphabetAndFrequencyFromText(input));

            var str = new StringBuilder();
            foreach (var a in input)
                str.Append(dict[a]);

            var bitArray = new BitArray(str.ToString().Select(x => x == '1').ToArray());
            StringHelper.WriteInFile(bitArray,  StringHelper.MakeHeaderFromDictionary(dict), _savePath);
        }

        private void UnzipBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_readPath))
            {
                MessageBox.Show(this, "Не выбран файл для архивирования");
                return;
            }

            if (!File.Exists(_readPath))
            {
                MessageBox.Show(this, $"Неправильный путь {_readPath}");
                return;
            }
            
            if (string.IsNullOrEmpty(_savePath))
            {
                MessageBox.Show(this, "Не выбран файл для сохранения архивированного файла");
                return;
            }

            if (!File.Exists(_savePath))
            {
                MessageBox.Show(this, $"Неправильный путь {_savePath}");
                return;
            }
            
            var text = File.ReadAllBytes(_savePath);
            var readBytes = Encoding.ASCII.GetString(text).Split(StringHelper.HeaderDelimiter);
            
            var header = readBytes[0];
            var headerByteLength = Encoding.ASCII.GetBytes(header).Length;
            var decodedDict = HuffmanCode.GetCodeDictionaryFromHeader(header.Split(StringHelper.HeaderDelimiter)[0]);
            
            var readBitArray = new BitArray(text.Skip(headerByteLength).ToArray());
            
            File.WriteAllText(_readPath, HuffmanCode.DecodeMessage(readBitArray, decodedDict.ToDictionary(x => x.Value, c => c.Key)));
        }

        private void SelectSavePath_OnClick(object sender, RoutedEventArgs e)
        {
            _savePath = OpenDialog("All files (*.*)|*.*");
        }

        private void SelectReadPath_OnClick(object sender, RoutedEventArgs e)
        {
            _readPath = OpenDialog("Text files (*.txt)|*.txt");
        }

        private string OpenDialog(string filter)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = filter;
            return openFile.ShowDialog() == true ? openFile.FileName : null;
        }
    }
}