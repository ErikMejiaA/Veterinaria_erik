using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Usuario;
public class LoginDto
{
    [Required]
    public string ? Username { get; set; }

    [Required]
    public string ? Password { get; set; }
        
}
