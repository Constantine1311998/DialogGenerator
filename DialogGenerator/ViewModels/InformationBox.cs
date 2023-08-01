using DialogGenerator.Commands;
using DialogGenerator.Enums;
using DialogGenerator.Extension;
using DialogGenerator.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static DialogGenerator.Constants.Constants;

namespace DialogGenerator.ViewModels
{
    public partial class InformationBox : DialogViewModelBase<InformationBoxResult>
    {
        private string messageContent;

        public string MessageContent
        {
            get => messageContent;
            set
            {
                messageContent = value;
                OnPropertyChanged();
            }
        }

        private string caption;

        public string Caption
        {
            get => caption;
            set
            {
                caption = value;
                OnPropertyChanged();
            }
        }

        private string messageType;

        public string MessageType
        {
            get => messageType;
            set
            {
                messageType = value;
                OnPropertyChanged();
            }
        }

        private string imageUri;

        public string ImageUri
        {
            get => imageUri;
            set
            {
                imageUri = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<InformationButtonViewModel> buttonViewModels;

        public ObservableCollection<InformationButtonViewModel> ButtonViewModels
        {
            get => buttonViewModels;
            set
            {
                buttonViewModels = value;
                OnPropertyChanged();
            }
        }

        public static InformationBoxResult Show(string message, string caption)
        {
            return Show(message, caption, InformationBoxButton.OK, InformationBoxImage.None, InformationBoxResult.None);
        }

        public static InformationBoxResult Show(string message, string caption, InformationBoxButton button)
        {
            return Show(message, caption, button, InformationBoxImage.None, InformationBoxResult.None);
        }

        public static InformationBoxResult Show(string message, string caption, InformationBoxButton button, InformationBoxImage icon)
        {
            return Show(message, caption, button, icon, InformationBoxResult.None);
        }

        public static InformationBoxResult Show(string message, string caption, InformationBoxButton button, InformationBoxImage icon, InformationBoxResult defaultResult)
        {
            InformationBox infobox = new InformationBox();
            return infobox.ShowInformationBoxInternal(message, caption, button, icon, defaultResult);
        }

        public InformationBox()
        {
            InformationButtonClickedCommand = new InformationButtonClickedCommand(new Action<IDialogWindow, InformationBoxResult, bool>(CloseDialogWithResult));
        }

        public ICommand InformationButtonClickedCommand { get; }

        private InformationBoxResult ShowInformationBoxInternal(string message, string caption, InformationBoxButton button, InformationBoxImage icon,
            InformationBoxResult defaultResult = InformationBoxResult.None)
        {
            IDialogService dialogService = new DialogService();
            ButtonViewModels = new ObservableCollection<InformationButtonViewModel>();
            this.DialogResult = defaultResult;
            this.MessageType = icon.GetEnumDescription();

            SetMessageBoxIcon(icon);
            PopulateMessageButtons(button);
            this.MessageContent = message;
            this.Caption = caption;
            var result = dialogService.ShowDialog(this);
            if (result == InformationBoxResult.None && result != defaultResult)
            {
                return defaultResult;
            }
            return result;
        }

        private void PopulateMessageButtons(InformationBoxButton button)
        {
            switch (button)
            {
                case InformationBoxButton.YesNo:
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.Yes.ToString() });
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.No.ToString() });
                    break;

                case InformationBoxButton.YesNoCancel:
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.Yes.ToString() });
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.No.ToString() });
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.Cancel.ToString() });
                    break;

                case InformationBoxButton.OK:
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.OK.ToString() });
                    break;

                case InformationBoxButton.OkCancel:
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.OK.ToString() });
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.Cancel.ToString() });
                    break;

                default:
                    buttonViewModels.Add(new InformationButtonViewModel { ButtonName = InformationBoxResult.OK.ToString() });
                    break;
            }
        }

        private void SetMessageBoxIcon(InformationBoxImage icon)
        {
            switch (icon)
            {
                case InformationBoxImage.None:
                    break;

                case InformationBoxImage.Warning:
                    this.ImageUri = InformationBoxImageIcons.WarningImage;
                    break;

                case InformationBoxImage.Error:
                    this.ImageUri = InformationBoxImageIcons.ErrorImage;
                    break;

                case InformationBoxImage.Stop:
                    this.ImageUri = InformationBoxImageIcons.StopImage;
                    break;

                case InformationBoxImage.Exclamation:
                    this.ImageUri = InformationBoxImageIcons.ExclamationImage;
                    break;

                case InformationBoxImage.Asterisk:
                    this.ImageUri = InformationBoxImageIcons.AsterikImage;
                    break;

                case InformationBoxImage.Hand:
                    this.ImageUri = InformationBoxImageIcons.HandImage;
                    break;

                case InformationBoxImage.Information:
                    this.ImageUri = InformationBoxImageIcons.InformationImage;
                    break;

                case InformationBoxImage.Question:
                    this.ImageUri = InformationBoxImageIcons.QuestionImage;
                    break;

                default:
                    break;
            }
        }
    }
}