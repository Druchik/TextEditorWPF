using System.Windows;

namespace TextEditorWPF
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message) => MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowExclamation(string exclamation) => MessageBox.Show(exclamation, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        public void ShowError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
