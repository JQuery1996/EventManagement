using Application.Services.Bookings.Common;
using Application.Services.Events.Common;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.Events.Interfaces; 

public interface IEventService {
   public Task<IEnumerable<EventResult>> GetAvailableEventsAsync();
   public Task<EventResult> CreateEventAsync(CreateEventCommand command, User user);
   public Task<EventResult?> GetEventAsync(int id);
   public Task<ErrorOr<EventResult>> EditEventAsync(int id, EditEventCommand command, User user);
   public Task<ErrorOr<Deleted>> RemoveEventAsync(int id, User user);
   public Task<ErrorOr<IEnumerable<BookingResult>>> GetEventBookingsAsync(int id, User user);
}