
using API.Dtos.MovimientoMedicamento;

namespace API.Dtos.TipoMovimiento;
public class TipoMovimientoDto
{
    public int IdCodigo { get; set; }
    public string ? Descripcion { get; set; }
    public List<MovimientoMedicamentoDto> ? MovimientosMedicamentos { get; set; }
        
}