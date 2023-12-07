using Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authentication; 

public sealed class HasPermissionAttribute : AuthorizeAttribute{
   public HasPermissionAttribute(Permissions permission) : base(permission.ToString()){} 
}