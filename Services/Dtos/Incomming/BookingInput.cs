using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dtos.Incomming
{
    public class BookingInput
    {
        public int UserId { get; set; }
        public int FlightId { get; set; }        

    }
}