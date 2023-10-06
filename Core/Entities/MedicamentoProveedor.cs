
namespace Core.Entities;
public class MedicamentoProveedor
{
    public int Id_medicamento { get; set; }
    public int Id_proveedor { get; set; }
    public Medicamento ? Medicamento { get; set; }
    public Proveedor ? Proveedor { get; set; }
        
}
