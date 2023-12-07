using Application.Services.PermissionsManager.Common;
using AutoMapper;
using Contract.Requests.Permissions;
using Contract.Responses.Permissions;

namespace Authorization.Mapping; 

public class PermissionMapping : Profile{
   public PermissionMapping() {

      CreateMap<AssignPermissionToRoleRequest, AssignPermissionToRoleCommand>()
         .ForCtorParam("Role", opt => opt.MapFrom(src => src.Role))
         .ForCtorParam("Permission", opt => opt.MapFrom(src => src.Permission));
      
      CreateMap<PermissionResult, PermissionResponse>()
         .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
         .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name));
   } 
}