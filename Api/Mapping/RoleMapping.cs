using Application.Services.RolesManager.Common;
using AutoMapper;
using Contract.Responses.Roles;

namespace Authorization.Mapping; 

public class RoleMapping : Profile{
    public RoleMapping() {
        CreateMap<RoleResult, RoleResponse>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
            .ForCtorParam("NormalizedName", opt => opt.MapFrom(src => src.NormalizedName));
    }
}