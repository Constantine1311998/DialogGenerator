namespace DialogGenerator.ViewModels
{
    public partial class InformationButtonViewModel : ViewModelBase
    {
        private string buttonName;

        public string ButtonName
        {
            get
            {
                return buttonName;
            }
            set
            {
                buttonName = value;
                OnPropertyChanged();
            }
        }
    }
}