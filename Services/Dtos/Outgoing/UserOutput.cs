using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dtos.Outgoing
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public ICollection<BookingOutput> Bookings { get; set; }
        
    }
}