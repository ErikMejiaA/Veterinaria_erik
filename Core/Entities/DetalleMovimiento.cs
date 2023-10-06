
namespace Core.Entities;
public class DetalleMovimiento : BaseEntityB
{
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public int Id_medicamento { get; set; }
    public int Id_movimientoMedicamento { get; set; }
    public Medicamento ? Medicamento { get; set; }
    public MovimientoMedicamento ? MovimientoMedicamento { get; set; }
        
}
