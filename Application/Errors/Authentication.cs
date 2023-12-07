using ErrorOr;

namespace Application.Errors; 

public abstract partial class ApplicationErrors {
   public abstract class Authentication {
      public static Error UnAuthenticated =
         Error.Unauthorized("auth.unauthorized", "UnAuthenticated");
      
      public static Error InvalidAuthentication =
         Error.Validation(code: "auth.invalid", description: "Invalid Authentication");

      public static Error Duplicate =
         Error.Conflict(code: "Authentication.Conflict", description: "Authentication Conflict");
   } 
}