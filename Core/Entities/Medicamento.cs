
namespace Core.Entities;
public class Medicamento : BaseEntityB
{
    public string ? Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public double Precio { get; set; }
    public int Id_laboratorio { get; set; }
    public Laboratorio ? Laboratorio { get; set; }

    public ICollection<MovimientoMedicamento> ? MovimientosMedicamentos { get; set; }
    public ICollection<DetalleMovimiento> ? DetallesMovimientos { get; set; }
    public ICollection<MedicamentoProveedor> ? MedicamentosProveedores { get; set; }

    public ICollection<TratamientoMedico> ? TratamientosMedicos { get; set; }
    
        
}
