namespace Core.Interfaces;
public interface IUnitOfWorkInterface
{
    //definimos las interfaces creadas
    IRolInterface Roles { get; }
    IUsuarioInterface Usuarios { get; }
    IUsuariosRolesInterface UsuariosRoles { get; }
    ICitaInterface Citas { get; }
    IDetalleMovimientoInterface DetallesMovimientos { get; }
    IEspecieInterface Especies { get; }
    ILaboratorioInterface Laboratorios { get; }
    IMascotaInterface Mascotas { get; }
    IMedicamentoInterface Medicamentos { get; }
    IMedicamentoProveedorInterface MedicamentosProveedores { get; }
    IMovimientoMedicamentoInterface MovimientosMedicamentos { get; }
    IPropietarioInterface Propietarios { get; }
    IProveedorInterface Proveedores { get; }
    IRazaInterface Razas { get; }
    ITipoMovimientoInterface TiposMovimientos { get; }
    ITrtamientoMedicoInterface TratamientosMedicos { get; }
    IVeterinarioInterface Veterinarios { get; }

    Task<int> SaveAsync();
        
}
