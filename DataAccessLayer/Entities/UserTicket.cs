using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class UserTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
