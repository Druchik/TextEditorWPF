namespace TextEditorWPF.BL
{
    public interface IOpenFileDialog
    {
        string FileName { get; set; }
        bool? OpenFileDialog();
    }
}
