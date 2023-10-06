
using iText.Barcodes.Exceptions;

namespace Core.Entities;
public class Cita : BaseEntityB
{
    public DateTime Fecha { get; set; }
    public TimeOnly Hora { get; set; }
    public string ? Motivo { get; set; }
    public int Id_mascota { get; set; }
    public int Id_veterinario { get; set; }

    public Veterinario ? Veterinario { get; set; }
    public Mascota ? Mascota { get; set; }

    public ICollection<TratamientoMedico> ? TratamientosMedicos { get; set; }
}
