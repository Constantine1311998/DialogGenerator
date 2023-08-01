using DialogGenerator.Services;

namespace DialogGenerator.ViewModels
{
    public class DialogViewModelBase<T> : DialogViewModelBase
    {
        public T DialogResult { get; set; }

        public virtual void CloseDialogWithResult(IDialogWindow dialog, T result, bool setdialogResult = true)
        {
            DialogResult = result;
            if (dialog != null)
            {
                dialog.DialogResult = setdialogResult;
            }
        }
    }
}