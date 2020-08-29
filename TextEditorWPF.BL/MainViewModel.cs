using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TextEditorWPF.BL.Command;
using TextEditorWPF.BL.FileManager;

namespace TextEditorWPF.BL
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IMessageService _messageService;
        private readonly IFileManager _fileManager;
        private readonly IOpenFileDialog _openFileDialog;

        #region Properties

        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                if(filePath != value)
                {
                    filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        private string text;
        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    CountSymbols = Text.Length;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private int countSymbols;
        public int CountSymbols
        {
            get => countSymbols;
            set
            {
                if (countSymbols != value)
                {
                    countSymbols = value;
                    OnPropertyChanged(nameof(countSymbols));
                }
            }
        }

        private int fontSize = 11;
        public int FontSize
        {
            get => fontSize;
            set
            {
                if (fontSize != value)
                {
                    fontSize = value;
                    OnPropertyChanged(nameof(fontSize));
                }
            }
        }

        #endregion

        #region Commands

        private RelayCommand openFileCommand = null;
        public RelayCommand OpenFileCommand => openFileCommand ?? (openFileCommand = new RelayCommand(
            obj => {
                try
                {
                    bool isExist = _fileManager.IsExist(FilePath);
                    
                    if (!isExist)
                    {
                        _messageService.ShowExclamation("Выбранный файл не существует.");
                        return;
                    }

                    Text = _fileManager.GetContent(FilePath);
                    CountSymbols = Text.Length;
                }
                catch (Exception ex)
                {
                    _messageService.ShowError(ex.Message);
                }
            },
            obj => true
        ));

        private RelayCommand chooseFileCommand = null;
        public RelayCommand ChooseFileCommand => chooseFileCommand ?? (chooseFileCommand = new RelayCommand(
            obj => {
                var showDialog = _openFileDialog.OpenFileDialog();

                if (showDialog == true)
                {
                    FilePath = _openFileDialog.FileName;
                    OpenFileCommand.Execute(obj);
                }
            },
            obj => true
        ));

        private RelayCommand saveFileCommand = null;
        public RelayCommand SaveFileCommand => saveFileCommand ?? (saveFileCommand = new RelayCommand(
            obj => {
                try
                {
                    _fileManager.SaveContent(Text, FilePath);
                    _messageService.ShowMessage("Файл успешно сохранен.");
                }
                catch (Exception ex)
                {
                    _messageService.ShowError(ex.Message);
                }
            },
            obj => true
        ));

        #endregion

        public MainViewModel(IMessageService messageService, IFileManager fileManager, IOpenFileDialog openFileDialog)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
            _openFileDialog = openFileDialog ?? throw new ArgumentNullException(nameof(openFileDialog));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
