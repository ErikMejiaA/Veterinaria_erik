
using System.Text.Json.Serialization;

namespace API.Dtos.Usuario;
public class DatosUsuarioDto
{
    public string ? Mensaje { get; set; }
    public bool EstaAutenticado { get; set; }
    public string ? UserName { get; set; }
    public string ? Email { get; set; }
    public List<string> ? Roles { get; set; }
    public string ? Token { get; set; } 
    [JsonIgnore] //se utiliza para ignorar un atributo de la tabla no visible para el usuario
    public string ? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
        
}
