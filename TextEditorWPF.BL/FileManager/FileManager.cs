using System.IO;
using System.Text;

namespace TextEditorWPF.BL.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool IsExist(string filePath) => File.Exists(filePath);

        public string GetContent(string filePath) => 
            GetContent(filePath, _defaultEncoding);

        public string GetContent(string filePath, Encoding encoding) => 
            File.ReadAllText(filePath, encoding);

        public void SaveContent(string content, string filePath) => 
            SaveContent(content, filePath, _defaultEncoding);

        public void SaveContent(string content, string filePath, Encoding encoding) => 
            File.WriteAllText(filePath, content, encoding);
    }
}
