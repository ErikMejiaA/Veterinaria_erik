namespace Core.Interfaces;
public interface IUnitOfWorkInterface
{
    //definimos las interfaces creadas
    IRolInterface Roles { get; }
    IUsuarioInterface Usuarios { get; }
    IUsuariosRolesInterface UsuariosRoles { get; }

    Task<int> SaveAsync();
        
}
