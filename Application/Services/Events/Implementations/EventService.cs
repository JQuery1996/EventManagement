using Application.Errors;
using Application.Interfaces;
using Application.Repository;
using Application.Services.Events.Common;
using Application.Services.Events.Interfaces;
using AutoMapper;
using Domain.Model.EventModels;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.Events.Implementations; 

public class EventService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    IDateTimeProvider dateTimeProvider) : IEventService {
    public async Task<EventResult> CreateEventAsync(CreateEventCommand command, User user) {
        var createEvent = mapper.Map<Event>(command);
        // attach user to the event 
        createEvent.User = user;
        // add event 
        unitOfWork.Events.Add(createEvent);
        // commit changes
        await unitOfWork.CommitAsync();
        return mapper.Map<EventResult>(createEvent);
    }

    public async Task<IEnumerable<EventResult>> GetAvailableEventsAsync() {
        return mapper.Map<IEnumerable<EventResult>>(
            await unitOfWork.Events.FindAllAsync(predicate: e => e.AvailableTickets > 0 ));
    }

    public async Task<EventResult?> GetEventAsync(int id) {
        return mapper.Map<EventResult>(await unitOfWork.Events.FindAsync(e => e.Id == id));
    }

    public async Task<ErrorOr<EventResult>> EditEventAsync(int id, EditEventCommand command, User user) {
        if (await unitOfWork.Events.FindAsync(
                e => e.Id == id) is not {} updateEvent)
            return ApplicationErrors.Events.NotFound;

        if (updateEvent.UserId != user.Id)
            return ApplicationErrors.Events.UnAuthorized;
        
        // using automapper to map properties
        mapper.Map(command, updateEvent);

        unitOfWork.Events.Update(updateEvent);
        await unitOfWork.CommitAsync();
        return mapper.Map<EventResult>(updateEvent);

    }

    public async Task<ErrorOr<Deleted>> RemoveEventAsync(int id, User user) {
        if (await unitOfWork.Events.FindAsync(
                e => e.Id == id) is not {} deleteEvent)
            return ApplicationErrors.Events.NotFound;

        if (deleteEvent.UserId != user.Id)
            return ApplicationErrors.Events.UnAuthorized;


        if (await unitOfWork.Bookings.AnyAsync(booking => booking.EventId == id))
            return ApplicationErrors.Events.HasBookings;
        
        unitOfWork.Events.Remove(deleteEvent);
        await unitOfWork.CommitAsync();
        return Result.Deleted;
    }
}