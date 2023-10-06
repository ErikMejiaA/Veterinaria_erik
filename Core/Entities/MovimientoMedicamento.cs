
namespace Core.Entities;
public class MovimientoMedicamento : BaseEntityB
{
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; }
    public int Id_medicamento { get; set; }
    public int Id_tipo { get; set; }
    public Medicamento ? Medicamento { get; set; }
    public TipoMovimiento ? TipoMovimiento { get; set; }
    public ICollection<DetalleMovimiento> ? DetallesMovimientos { get; set; }
        
}
