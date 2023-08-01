using System.Windows;

namespace DialogGenerator.Services
{
    public interface IDialogViewModelBase
    {
        ResizeMode ResizeMode { get; }

        void CloseDialogWindow(IDialogWindow dialog);
    }
}