using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Usuario;
public class AddRoleDto
{
    [Required]
    public string ? Username { get; set; }

    [Required]
    public string ? Password { get; set; }

    [Required]
    public string ? Role { get; set; }
        
}
