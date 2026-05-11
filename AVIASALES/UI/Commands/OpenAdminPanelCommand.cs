using System;

namespace AVIASALES.UI.Commands
{
    public class OpenAdminPanelCommand : WindowCommandBase
    {
        private readonly MainWindow _receiver;

        public OpenAdminPanelCommand(MainWindow receiver)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException("receiver");
            }

            _receiver = receiver;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _receiver.OpenAdminPanel();
        }
    }
}
