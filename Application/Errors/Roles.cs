using ErrorOr;

namespace Application.Errors; 

public partial class ApplicationErrors  {
   public abstract class Roles {
      public static Error NotFound = Error.NotFound("Roles.NotFound", "There is no role with the given name.");
      public static Error AlreadyIn = Error.Conflict("Roles.AlreadyIn", "User already in role");
   } 
}