
namespace API.Dtos.DetalleMovimiento;

public class DetalleMovimientoDto
{
    public int IdCodigo { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public int Id_medicamento { get; set; }
    public int Id_movimientoMedicamento { get; set; }
    //public Medicamento ? Medicamento { get; set; }
    //public MovimientoMedicamento ? MovimientoMedicamento { get; set; }
        
}
