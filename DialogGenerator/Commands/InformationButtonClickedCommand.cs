using DialogGenerator.Enums;
using DialogGenerator.Services;
using System;

namespace DialogGenerator.Commands
{
    public class InformationButtonClickedCommand : CommandBase
    {
        private Action<IDialogWindow, InformationBoxResult, bool> _closeDialogAction;

        public InformationButtonClickedCommand(Action<IDialogWindow, InformationBoxResult, bool> closeDialogAction)
        {
            _closeDialogAction = closeDialogAction;
        }

        public override void Execute(object? parameter)
        {
            object[] parameters = parameter as object[];
            string buttonResult = parameters[0] as string;
            IDialogWindow window = parameters[1] as IDialogWindow;

            Enum.TryParse<InformationBoxResult>(buttonResult, out InformationBoxResult result);
            _closeDialogAction(window, result, true);
        }
    }
}