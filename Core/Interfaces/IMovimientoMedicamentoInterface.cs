
using Core.Entities;

namespace Core.Interfaces;

public interface IMovimientoMedicamentoInterface : IGenericInterfaceB<MovimientoMedicamento>
{
    IEnumerable<object> ListaValorTotalMovimientoMedicamentos();
        
}
