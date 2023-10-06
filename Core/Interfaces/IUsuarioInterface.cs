using Core.Entities;

namespace Core.Interfaces;
public interface IUsuarioInterface : IGenericInterfaceB<Usuario>
{
    //aqui van otors metodos 
    Task<Usuario> GetByUsernameAsync(string username);
    Task<Usuario> GetByRefreshTokenAsync(string refreshToken);
}