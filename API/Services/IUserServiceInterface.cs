
using API.Dtos.Usuario;
using Core.Entities;

namespace API.Services;
public interface IUserServiceInterface
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
    Task<Usuario> EditarUsuarioAsync(Usuario model);
    Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken);
}
