using System.ComponentModel.DataAnnotations;

namespace Contract.Requests.Bookings;

public class BookForEventRequest {
    [Required]
    public int EventId { get; init; }
    [Required]
    [Range(1, int.MaxValue)]
    public int NumberOfTickets { get; init; }
}
