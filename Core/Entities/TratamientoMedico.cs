
namespace Core.Entities;
public class TratamientoMedico : BaseEntityB
{
    public double Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string ? Observacion { get; set; }
    public int Id_Cita { get; set; }
    public int Id_medicamento { get; set; }
    public Cita ? Cita { get; set; }
    public Medicamento ? Medicamento { get; set; }
    
        
}
