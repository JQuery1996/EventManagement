using Application.Services;
using Application.Services.Bookings.Common;
using AutoMapper;
using Contract.Requests.Bookings;
using Contract.Responses.Bookings;
using Domain.Constants;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authorization.Controllers; 

[Route("/api/booking")]
public class BookingController(
   ServiceContainer serviceContainer,
   IMapper mapper
   ) : ApiController{
   [HttpPost]
   [HasPermission(Permissions.CreateBooking)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   public async Task<IActionResult> Create([FromBody] BookForEventRequest request) {
      var authenticatedUser = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
      if (authenticatedUser is null)
         return Unauthorized();
      
      var createResult = await serviceContainer.BookingService.BookUserForEvent(
         mapper.Map<BookForEventCommand>(request), authenticatedUser);

      return createResult.Match(result => Ok(), Problem);
   }

   [HttpGet]
   [HasPermission(Permissions.ViewBookings)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   public async Task<IActionResult> Get() {
      var authenticatedUser
         = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
      if (authenticatedUser is null)
         return Unauthorized();

      var result 
         = await serviceContainer.BookingService.GetBookingByUser(authenticatedUser);
      if (result.IsNullOrEmpty())
         return NoContent();
      
      return Ok(mapper.Map<IEnumerable<BookingResponse>>(result));
   }

   [HttpPut("{id:int}")]
   [HasPermission(Permissions.EditBooking)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] UpdateBookRequest request) {
      var authenticatedUser 
         = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
      if (authenticatedUser is null)
         return Unauthorized();
      var updateResult 
         = await serviceContainer.BookingService.UpdateBooking(
            new UpdateBookCommand(id, request.NumberOfTickets), authenticatedUser);

      return updateResult.Match(Ok, Problem);
   }
   
   [HttpDelete("{id:int}")]
   [HasPermission(Permissions.RemoveBooking)]
   public async Task<IActionResult> Cancel([FromRoute] int id) {
      var authenticatedUser
         = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
      if (authenticatedUser is null)
         return Unauthorized();

      var cancelResult = 
         await serviceContainer.BookingService.CancelBooking(eventId: id, user: authenticatedUser);
      return cancelResult.Match(result => NoContent(), Problem);
   }
}