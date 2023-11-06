
using API.Dtos.Medicamento;

namespace API.Dtos.Laboratorio;
public class LaboratorioConsultaDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public List<MedicamentoConsultaDto> ? Medicamentos { get; set; }
        
}
