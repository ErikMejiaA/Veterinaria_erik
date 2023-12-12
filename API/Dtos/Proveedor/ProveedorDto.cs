
using API.Dtos.MedicamentoProveedor;

namespace API.Dtos.Proveedor;
public class ProveedorDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public string ? Direccion { get; set; }
    public string ? Telefono {  get; set; }
    public List<MedicamentoProveedorDto> ? MedicamentosProveedores { get; set; }
        
}
