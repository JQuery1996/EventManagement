using Domain.Model.BookingModels;
using Domain.Model.EventModels;
using Microsoft.AspNetCore.Identity;

namespace Domain.Model.IdentityModels;

public class User : IdentityUser {
    public List<Booking> Bookings { get; set; } = new();
}