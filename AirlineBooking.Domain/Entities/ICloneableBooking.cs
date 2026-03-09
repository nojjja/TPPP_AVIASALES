using System;

namespace AVIASALES.Domain.Entities
{
    public interface ICloneableBooking
    {
        Booking Clone();
    }
}