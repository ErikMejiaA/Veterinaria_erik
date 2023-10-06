
namespace Core.Entities;
public class Laboratorio : BaseEntityB
{
    public string ? Nombre { get; set; }
    public string ? Direccion { get; set; }
    public string ? Telefono { get; set; }

    public ICollection<Medicamento> ? Medicamentos { get; set; }
        
}
