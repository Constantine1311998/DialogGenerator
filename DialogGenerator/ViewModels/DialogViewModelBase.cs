using DialogGenerator.Services;
using System.Windows;

namespace DialogGenerator.ViewModels
{
    public class DialogViewModelBase : ViewModelBase, IDialogViewModelBase
    {
        public ResizeMode ResizeMode => ResizeMode.NoResize;

        public virtual void CloseDialogWindow(IDialogWindow dialog)
        {
            dialog.Close();
        }
    }
}