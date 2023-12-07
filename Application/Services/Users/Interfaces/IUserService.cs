using Application.Services.Users.Common;
using ErrorOr;

namespace Application.Services.Users.Interfaces; 

public interface IUserService {
    public Task<IEnumerable<UserResult>> GetUsersAsync();
    public Task<UserResult?> GetUserByIdAsync(string id);
    public Task<IEnumerable<UserResult>> FilterUsersAsync(FilterUsersQuery query);
    public Task<ErrorOr<Updated>> EditUserAsync(string id, EditUserCommand command);

    public Task<ErrorOr<Deleted>> RemoveUserAsync(string id);

}