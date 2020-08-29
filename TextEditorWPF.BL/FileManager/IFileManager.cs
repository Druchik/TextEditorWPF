using System.Text;

namespace TextEditorWPF.BL.FileManager
{
    public interface IFileManager
    {
        bool IsExist(string filePath);
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string content, string filePath);
        void SaveContent(string content, string filePath, Encoding encoding);
    }
}
