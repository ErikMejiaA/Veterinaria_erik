using API.Dtos.Cita;
using API.Dtos.DetalleMovimiento;
using API.Dtos.Especie;
using API.Dtos.Laboratorio;
using API.Dtos.Mascota;
using API.Dtos.Medicamento;
using API.Dtos.MedicamentoProveedor;
using API.Dtos.MovimientoMedicamento;
using API.Dtos.Propietario;
using API.Dtos.Proveedor;
using API.Dtos.Raza;
using API.Dtos.TipoMovimiento;
using API.Dtos.TratamientoMedico;
using API.Dtos.Usuario;
using API.Dtos.UsuariosRoles;
using API.Dtos.Veterinario;
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

        CreateMap<Cita, CitaDto>().ReverseMap();

        CreateMap<DetalleMovimiento, DetalleMovimientoDto>().ReverseMap();

        CreateMap<Especie, EspecieDto>().ReverseMap();

        CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();

        CreateMap<Mascota, MascotaDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();

        CreateMap<MedicamentoProveedor, MedicamentoProveedorDto>().ReverseMap();

        CreateMap<MovimientoMedicamentoDto, MovimientoMedicamentoDto>().ReverseMap();

        CreateMap<Propietario, PropietarioDto>().ReverseMap();

        CreateMap<Proveedor, ProveedorDto>().ReverseMap();

        CreateMap<Raza, RazaDto>().ReverseMap();

        CreateMap<TipoMovimiento, TipoMovimientoDto>().ReverseMap();

        CreateMap<TratamientoMedico, TratamientoMedicoDto>().ReverseMap();

        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();

    }
        
}
