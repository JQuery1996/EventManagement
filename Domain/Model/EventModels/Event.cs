using System.ComponentModel.DataAnnotations;
using Domain.Model.BookingModels;
using Domain.Model.IdentityModels;

namespace Domain.Model.EventModels; 

public class Event {
    public int Id { get; set; }
    
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;

    public string DescriptionEn { get; set; } = null!;
    public string DescriptionAr { get; set; } = null!;

    public string Location { get; set; } = null!;
    
    public DateTime Date { get; set; }
    public int AvailableTickets { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;

    public List<Booking> Bookings { get; set; } = new();
}
