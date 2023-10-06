
namespace Core.Entities;
public class Proveedor : BaseEntityB
{
    public string ? Nombre { get; set; }
    public string ? Direccion { get; set; }
    public string ? Telefono {  get; set; }
    public ICollection<MedicamentoProveedor> ? MedicamentosProveedores { get; set; }
        
}
