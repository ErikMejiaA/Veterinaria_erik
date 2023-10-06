using API.Dtos.Usuario;
using API.Dtos.UsuariosRoles;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //aqui va el mapeo de los Dtos a las entidades de la Db
        CreateMap<Rol, RolDto>().ReverseMap();

        CreateMap<UsuariosRoles, UsuariosRolesDto>().ReverseMap();

        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuario, UsuarioXrolDto>().ReverseMap();
    }
        
}
