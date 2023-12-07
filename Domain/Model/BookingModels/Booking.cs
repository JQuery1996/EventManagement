using Domain.Model.EventModels;
using Domain.Model.IdentityModels;

namespace Domain.Model.BookingModels; 

public class Booking {
    public string UserId { get; set; } = null!;
    public int EventId { get; set; }
    public int NumberOfTickets { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    public User User { get; set; } = null!;
    public Event Event { get; set; } = null!;
}