
using Core.Entities;
using iText.Kernel.Colors;

namespace Core.Interfaces;
public interface IMedicamentoInterface :  IGenericInterfaceB<Medicamento>
{
    Task<IEnumerable<Laboratorio>> GetAllMedicamentosSegunUnLab(string laboratori);
    Task<IEnumerable<Medicamento>> GetAllMayoresA(double precio);
        
}
