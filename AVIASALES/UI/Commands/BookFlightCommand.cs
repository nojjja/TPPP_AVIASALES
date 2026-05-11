using System;

namespace AVIASALES.UI.Commands
{
    public class BookFlightCommand : WindowCommandBase
    {
        private readonly MainWindow _receiver;

        public BookFlightCommand(MainWindow receiver)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException("receiver");
            }

            _receiver = receiver;
        }

        public override bool CanExecute(object parameter)
        {
            return _receiver.CanBookFlight();
        }

        public override void Execute(object parameter)
        {
            _receiver.BookFlight();
        }
    }
}
