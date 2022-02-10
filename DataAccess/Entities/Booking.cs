using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("Bookings")]
    public class Booking : BaseEntity
    {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BookingId")]
        public int Id { get; set; }
        public Guid Bookingcode { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }        
        public User UserNavigation { get; set; }
        public Flight FlightNavigation { get; set; }     
       
    }
}