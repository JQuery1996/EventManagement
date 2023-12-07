using ErrorOr;

namespace Application.Errors; 

public partial class ApplicationErrors {
    public abstract class Permissions {
        public static Error NotFound =
            Error.NotFound("Permissions.NotFound", "There is no permission with the given name.");

        public static Error Duplicate =
            Error.Conflict("Permission.Duplicate", "Role already has this permission");
    }
    
}