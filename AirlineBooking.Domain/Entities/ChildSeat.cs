using AVIASALES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Domain.Entities
{
    public class ChildSeat : ISeat
    {
        public string Type => "Child seat";
    }
}
