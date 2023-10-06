
using API.Dtos.Medicamento;

namespace API.Dtos.Laboratorio;
public class LaboratorioDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public string ? Direccion { get; set; }
    public string ? Telefono { get; set; }

    public List<MedicamentoDto> ? Medicamentos { get; set; }
        
}
