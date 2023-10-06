
using API.Dtos.TratamientoMedico;

namespace API.Dtos.Cita;
public class CitaDto
{
    public int IdCodigo { get; set; }
    public DateTime Fecha { get; set; }
    public TimeOnly Hora { get; set; }
    public string ? Motivo { get; set; }
    public int Id_mascota { get; set; }
    public int Id_veterinario { get; set; }
    public List<TratamientoMedicoDto> ? TratamientosMedicos { get; set; }
        
 
}