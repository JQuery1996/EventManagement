using Application.Errors;
using Application.Repository;
using Application.Services.Users.Common;
using Application.Services.Users.Interfaces;
using AutoMapper;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Users.Implementations; 

public class UserService(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IUserService{
    // list of all users
    public async Task<IEnumerable<UserResult>> GetUsersAsync() {
        return mapper.Map<IEnumerable<UserResult>>(
            await unitOfWork.UserContainer.Users.ToListAsync());
    }
    // get user by id 
    public async Task<UserResult?> GetUserByIdAsync(string id) {
        return mapper.Map<UserResult>(await unitOfWork.UserContainer.FindByIdAsync(id));
        
    }
    // Filter users by UserName, Email and PhoneNumber
    public async Task<IEnumerable<UserResult>> FilterUsersAsync(FilterUsersQuery query) {
        return mapper.Map<IEnumerable<UserResult>>(
            await unitOfWork.Users.FindAllAsync(user =>
                (query.UserName != null && user.UserName != null && user.UserName.ToLower() == query.UserName.ToLower()) ||
                (query.Email != null && user.Email != null && user.Email.ToLower() == query.Email.ToLower()) ||
                (query.PhoneNumber != null && user.PhoneNumber != null && user.PhoneNumber.ToLower() == query.PhoneNumber.ToLower()) 
                ));
    }
    
    public async Task<ErrorOr<Updated>> EditUserAsync(string id, EditUserCommand command) {
        // first check if user exists
        if (await unitOfWork.UserContainer.FindByIdAsync(id) is not { } user)
            return ApplicationErrors.Users.NotFound;
        
        // check for username, email and phone number uniqueness
        var result = await FilterUsersAsync(mapper.Map<FilterUsersQuery>(command));
        if (result.Any())
            return ApplicationErrors.Authentication.Duplicate;
        
        // set the new values
        if(!string.IsNullOrWhiteSpace(command.UserName))
            user.UserName = command.UserName;
        if(!string.IsNullOrWhiteSpace(command.Email))
            user.Email = command.Email;
        if (!string.IsNullOrWhiteSpace(command.PhoneNumber))
            user.PhoneNumber = command.PhoneNumber;

        // persist changes 
        await unitOfWork.UserContainer.UpdateAsync(user);
        await unitOfWork.CommitAsync();
        
        // return result
        return Result.Updated;
    }

    public async Task<ErrorOr<Deleted>> RemoveUserAsync(string id) {
        // check if user exists
        if (await unitOfWork.UserContainer.FindByIdAsync(id) is not { } user)
            return ApplicationErrors.Users.NotFound;
        
        // remove user 
        // persist the data
        await unitOfWork.UserContainer.DeleteAsync(user);
        await unitOfWork.CommitAsync();
        return Result.Deleted;
    }
}