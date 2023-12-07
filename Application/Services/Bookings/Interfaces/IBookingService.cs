using Application.Services.Bookings.Common;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.Bookings.Interfaces;

public interface IBookingService {
    Task<ErrorOr<Created>> BookUserForEvent(BookForEventCommand command, User user);

    Task<IEnumerable<BookingResult>> GetBookingByUser(User user);

    Task<ErrorOr<Deleted>> CancelBooking(int eventId, User user);


    Task<ErrorOr<BookingResult>> UpdateBooking(UpdateBookCommand command, User user);
}