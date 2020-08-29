using Microsoft.Win32;
using TextEditorWPF.BL;

namespace TextEditorWPF
{
    public class OpenDialog : IOpenFileDialog
    {
        public string FileName { get; set; }

        public bool? OpenFileDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Текстовые файлы|*.txt|Все файлы|*.*"
            };

            var Ok = dlg.ShowDialog();

            if(Ok == true)
                FileName = dlg.FileName;

            return Ok;
        }
    }
}
