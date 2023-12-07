using Application.Errors;
using Application.Interfaces;
using Application.Repository;
using Application.Services.Bookings.Common;
using Application.Services.Bookings.Interfaces;
using AutoMapper;
using Domain.Model.BookingModels;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.Bookings.Implements; 

public class BookingService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IDateTimeProvider dateTimeProvider
    ): IBookingService{
    public async Task<ErrorOr<Created>> BookUserForEvent(BookForEventCommand command, User user) {
        // first check if event exists
        if (await unitOfWork.Events.FindAsync(e => e.Id == command.EventId) is not { } targetEvent)
            return ApplicationErrors.Events.NotFound;
        
        // check if there is a previous booking 
        if (await unitOfWork.Bookings.FindAsync(b => b.EventId == targetEvent.Id && b.UserId == user.Id) is not null)
            return ApplicationErrors.Bookings.Duplicate;
        
        if (targetEvent.AvailableTickets < command.NumberOfTickets)
            return ApplicationErrors.Bookings.Insufficient;

        var createdBooking = new Booking {
            NumberOfTickets = command.NumberOfTickets,
            Date = dateTimeProvider.UtcNow,
            Event = targetEvent,
            User = user
        };

        // update the number of available tickets in this event.
        targetEvent.AvailableTickets -= command.NumberOfTickets;
        
        unitOfWork.Bookings.Add(createdBooking);
        unitOfWork.Events.Update(targetEvent);
        
        await unitOfWork.CommitAsync();
        
        return Result.Created;
    }

    public async Task<IEnumerable<BookingResult>> GetBookingByUser(User user) {
        return mapper.Map<IEnumerable<BookingResult>>(
            await unitOfWork.Bookings
                .FindAllAsync(
                    booking => booking.UserId == user.Id,
                    includeProperties: booking => booking.Event));
    }

    public async Task<ErrorOr<Deleted>> CancelBooking(int eventId, User user) {
        // first check if event exists
        if (await unitOfWork.Events.FindAsync(
                e => e.Id == eventId) is not { } targetEvent)
            return ApplicationErrors.Events.NotFound;

        // check if user has this event
        if (targetEvent.UserId != user.Id)
            return ApplicationErrors.Events.UnAuthorized;

        // check if booking exists
        if (await unitOfWork.Bookings
                .FindAsync(b => b.EventId == eventId && b.UserId == user.Id) is not { } booking)
            return ApplicationErrors.Bookings.NotFound;

        // recover tickets before deletion   
        targetEvent.AvailableTickets += booking.NumberOfTickets;
        
        // remove booking 
        unitOfWork.Bookings.Remove(booking);
        // update event
        unitOfWork.Events.Update(targetEvent);
        // commit changes 
        await unitOfWork.CommitAsync();
        // return result
        return Result.Deleted;
    }

    public async Task<ErrorOr<BookingResult>> UpdateBooking(UpdateBookCommand command, User user) {
        // check for event exists
        if (await unitOfWork.Events.FindAsync(e => e.Id == command.EventId) is not { } targetEvent)
            return ApplicationErrors.Events.NotFound;
        
        // check if user has this event
        if (targetEvent.UserId != user.Id)
            return ApplicationErrors.Events.UnAuthorized;
        
        // check if booking exists 
        if (await unitOfWork.Bookings.FindAsync(
                b => b.UserId == user.Id && b.EventId == command.EventId) is not {} booking)
            return ApplicationErrors.Bookings.NotFound;

        if (targetEvent.AvailableTickets < command.NumberOfTickets)
            return ApplicationErrors.Bookings.Insufficient;


        // update event available tickets 
        targetEvent.AvailableTickets -= command.NumberOfTickets - booking.NumberOfTickets;
        
        // update the number of tickets
        booking.NumberOfTickets = command.NumberOfTickets;
        
        // save changes.
        unitOfWork.Bookings.Update(booking);
        unitOfWork.Events.Update(targetEvent);
        
        await unitOfWork.CommitAsync();
       
        // return result
        return mapper.Map<BookingResult>(booking);
    }
}