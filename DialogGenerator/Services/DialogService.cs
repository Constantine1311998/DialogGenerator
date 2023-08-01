using DialogGenerator.ViewModels;
using DialogGenerator.Views;
using System;
using System.Collections.Generic;

namespace DialogGenerator.Services
{
    /// <summary>
    /// Implements Dialog Serive for displaying custom dialogs
    /// </summary>
    public class DialogService : IDialogService
    {
        static DialogService() => RegisterDialog<InformationBoxScreen, InformationBox>();

        /// <summary>
        /// Empty Constructor Defined for DialogService
        /// </summary>
        public DialogService()
        { }

        /// <summary>
        /// Gets a list of mapped Views aand ViewModel types
        /// </summary>
        public static Dictionary<Type, Type> mappings { get; } = new Dictionary<Type, Type>();

        /// <summary>
        /// Used for registering the types of views and view models to be used in the dialog serive.
        /// </summary>
        /// <typeparam name="TView">Type of View which implement IDialogView </typeparam>
        /// <typeparam name="TViewModel">Type of View Model which implement IDialogViewModelBase</typeparam>
        public static void RegisterDialog<TView, TViewModel>()
                                        where TView : IDialogView
                                        where TViewModel : IDialogViewModelBase
        {
            mappings.Add(typeof(TViewModel), typeof(TView));
        }

        /// <summary>
        /// Displays Dialog without showing it as window Dialog
        /// </summary>
        /// <param name="viewModel">View model for controlling the generated view</param>
        /// <exception cref="Exception">Exception thrown if View and ViewModel not registered</exception>
        public void Show(DialogViewModelBase viewModel)
        {
            IDialogWindow dialogWindow = new DialogWindow();
            Type dialogType = viewModel.GetType();
            if (mappings.TryGetValue(dialogType, out Type viewType))
            {
                dialogWindow.Content = Activator.CreateInstance(viewType);
                dialogWindow.DataContext = viewModel;
                dialogWindow.Show();
            }
            else
            {
                throw new Exception("Dialog Type and View Type not registered");
            }
        }

        /// <summary>
        /// Shows the Dialog as window dialog
        /// </summary>
        /// <typeparam name="T">Type of Result expected for the output of Dialog</typeparam>
        /// <param name="viewModel">View model for controlling generated dialog</param>
        /// <param name="callback">Call back action after dialog closed.(Optional)</param>
        /// <returns>Dialog result after action</returns>
        /// <exception cref="Exception">Exception thrown if View and ViewModel not registered</exception>
        public T ShowDialog<T>(DialogViewModelBase<T> viewModel, Action<string> callback = null)
        {
            IDialogWindow dialogWindow = new DialogWindow();
            EventHandler closedEventHandler = null;
            closedEventHandler = (s, e) =>
            {
                if (callback != null)
                {
                    callback(dialogWindow.DialogResult.ToString());
                }
                dialogWindow.Closed -= closedEventHandler;
            };
            dialogWindow.Closed += closedEventHandler;
            Type dialogType = viewModel.GetType();
            if (mappings.TryGetValue(dialogType, out Type viewType) && viewType != null)
            {
                dialogWindow.Content = Activator.CreateInstance(viewType);
                dialogWindow.DataContext = viewModel;
                dialogWindow.ShowDialog();
                return viewModel.DialogResult;
            }
            else
            {
                throw new Exception("Dialog Type and View Type not registered");
            }
        }
    }
}