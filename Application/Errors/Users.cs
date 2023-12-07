using ErrorOr;

namespace Application.Errors; 

public partial class ApplicationErrors {
    public class Users {
        public static Error NotFound =
            Error.NotFound("User.NotFound", "User Not Found");
    }
}