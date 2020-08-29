using System.Windows;
using TextEditorWPF.BL;
using TextEditorWPF.BL.FileManager;

namespace TextEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new MessageService(), new FileManager(), new OpenDialog());
        }
    }
}
