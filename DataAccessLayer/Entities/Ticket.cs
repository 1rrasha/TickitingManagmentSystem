using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities

{
    public class Ticket
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime Deadline { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public User? UpdatedByUser { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserTicket> UserTickets { get; set; }
    }

}
