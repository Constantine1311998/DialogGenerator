using DialogGenerator.ViewModels;
using System;

namespace DialogGenerator.Services
{
    public interface IDialogService
    {
        T ShowDialog<T>(DialogViewModelBase<T> viewModel, Action<string> callback = null);

        void Show(DialogViewModelBase viewModel);
    }
}