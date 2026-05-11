using System;

namespace AVIASALES.UI.Commands
{
    public class CloneBookingCommand : WindowCommandBase
    {
        private readonly MainWindow _receiver;

        public CloneBookingCommand(MainWindow receiver)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException("receiver");
            }

            _receiver = receiver;
        }

        public override bool CanExecute(object parameter)
        {
            return _receiver.CanCloneBooking();
        }

        public override void Execute(object parameter)
        {
            _receiver.CloneSelectedBooking();
        }
    }
}
