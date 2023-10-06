
namespace Core.Entities;
public class TipoMovimiento : BaseEntityB
{
    public string ? Descripcion { get; set; }
    public ICollection<MovimientoMedicamento> ? MovimientosMedicamentos { get; set; }
        
}
