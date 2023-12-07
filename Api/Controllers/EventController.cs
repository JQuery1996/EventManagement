using Application.Services;
using Application.Services.Events.Common;
using AutoMapper;
using Contract.Requests.Events;
using Domain.Constants;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers; 

[Route("/api/event")]
public class EventController(
    ServiceContainer serviceContainer,
    IMapper mapper
    ) : ApiController{

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HasPermission(Permissions.ViewEvents)]
    public async Task<IActionResult> All() {
        return Ok(await serviceContainer.EventService.GetAvailableEventsAsync());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HasPermission(Permissions.ShowEvent)]
    public async Task<IActionResult> Get([FromRoute] int id) {
        if (await serviceContainer.EventService.GetEventAsync(id) is not { } result)
            return NotFound();
        return Ok(result);
    }

    
    [HasPermission(Permissions.CreateEvent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request) {
        var authenticatedUser
            = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
        if (authenticatedUser is null)
            return Unauthorized();

        var createResult = await serviceContainer.EventService.CreateEventAsync(
            mapper.Map<CreateEventCommand>(request), 
            authenticatedUser);

        return CreatedAtAction(
            "Get",
            new { createResult.Id },
            createResult);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HasPermission(Permissions.EditEvent)]
    public async Task<IActionResult> Update([FromRoute] int id, EditEventRequest request) {
        var authenticatedUser
            = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
        if (authenticatedUser is null)
            return Unauthorized();
        var updateResult =
            await serviceContainer.EventService.EditEventAsync(id, mapper.Map<EditEventCommand>(request), authenticatedUser);
        return updateResult.Match(Ok, Problem);
    }

    [HttpDelete("{id:int}")]
    [HasPermission(Permissions.RemoveEvent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Remove([FromRoute] int id) {
        var authenticatedUser
            = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
        if (authenticatedUser is null)
            return Unauthorized();

        var removeResult =
            await serviceContainer.EventService.RemoveEventAsync(id, authenticatedUser);

        return removeResult.Match(_ => NoContent(), Problem);
    }
}
