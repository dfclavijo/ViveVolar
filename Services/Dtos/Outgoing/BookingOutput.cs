using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Dtos.Outgoing
{
    public class BookingOutput
    {
        public int Id { get; set; }
        public Guid Bookingcode { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int FlightId { get; set; }      
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }  
        public User UserNavigation { get; set; }
        public Flight FlightNavigation { get; set; }     
       
    }
}