using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TextEditorWPF.BL;

namespace TextEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            MessageService service = new MessageService();
            FileManager manager = new FileManager();
            MainPresenter presenter = new MainPresenter(this, manager, service);

            btnOpenFile.Click += BtnOpenFile_Click;
            btnSaveFile.Click += BtnSaveFile_Click;
            fldContent.TextChanged += FldContent_TextChanged;
            btnSelectFile.Click += BtnSelectFile_Click;
            numFont.ValueChanged += NumFont_ValueChanged;
        }

        #region Проброс событий
        private void FldContent_TextChanged(object sender, TextChangedEventArgs e) => ContentChanged?.Invoke(this, EventArgs.Empty);

        private void BtnSaveFile_Click(object sender, EventArgs e) => FileSaveClick?.Invoke(this, EventArgs.Empty);

        private void BtnOpenFile_Click(object sender, EventArgs e) => FileOpenClick?.Invoke(this, EventArgs.Empty);
        #endregion

        #region IMainWindow
        public string FilePath => fldFilePath.Text;

        string IMainWindow.Content { get => fldContent.Text; set => fldContent.Text = value; }

        public void SetSymbolCount(int count) => lblSymbolCount.Content = count.ToString();

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dlg.ShowDialog() == true)
            {
                fldFilePath.Text = dlg.FileName;
                FileOpenClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.FontFamily = new FontFamily("Calibri");
            fldContent.FontSize = (float)numFont.Value;
        }
    }
}
