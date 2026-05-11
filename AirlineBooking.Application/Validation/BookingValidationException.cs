using System;

namespace AVIASALES.Application.Validation
{
    public class BookingValidationException : Exception
    {
        public BookingValidationException(string message) : base(message)
        {
        }
    }
}
