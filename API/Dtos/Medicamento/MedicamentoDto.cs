
using API.Dtos.DetalleMovimiento;
using API.Dtos.MedicamentoProveedor;
using API.Dtos.MovimientoMedicamento;
using API.Dtos.TratamientoMedico;

namespace API.Dtos.Medicamento;

public class MedicamentoDto
{
    
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public double Precio { get; set; }
    public int Id_laboratorio { get; set; }
    //public Laboratorio ? Laboratorio { get; set; }

    public List<MovimientoMedicamentoDto> ? MovimientosMedicamentos { get; set; }
    public List<DetalleMovimientoDto> ? DetallesMovimientos { get; set; }
    public List<MedicamentoProveedorDto> ? MedicamentosProveedores { get; set; }
    public List<TratamientoMedicoDto> ? TratamientosMedicos { get; set; }
        
}
