
using API.Dtos.DetalleMovimiento;

namespace API.Dtos.MovimientoMedicamento;
public class MovimientoMedicamentoDto
{
    public int IdCodigo { get; set; }
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; }
    public int Id_medicamento { get; set; }
    public int Id_tipo { get; set; }
    //public Medicamento ? Medicamento { get; set; }
    //public TipoMovimiento ? TipoMovimiento { get; set; }
    public List<DetalleMovimientoDto> ? DetallesMovimientos { get; set; }
    
}