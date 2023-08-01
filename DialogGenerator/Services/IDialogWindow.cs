using System;
using System.Windows;

namespace DialogGenerator.Services
{
    public interface IDialogWindow
    {
        Window Owner { get; set; }

        bool? DialogResult { get; set; }

        object DataContext { get; set; }

        object Content { get; set; }

        void Show();

        bool? ShowDialog();

        void Close();

        event EventHandler Closed;

        ResizeMode ResizeMode { get; set; }
    }
}