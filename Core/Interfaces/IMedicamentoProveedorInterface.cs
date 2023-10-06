
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;
public interface IMedicamentoProveedorInterface
{
    Task<MedicamentoProveedor> GetByIdAsync(int idProveedor, int idMedicamento);
    Task<IEnumerable<MedicamentoProveedor>> GetAllAsync();
    IEnumerable<MedicamentoProveedor> Find(Expression<Func<MedicamentoProveedor, bool>> expression);
    Task<(int totalRegistros, IEnumerable<MedicamentoProveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(MedicamentoProveedor entity);
    void AddRange(IEnumerable<MedicamentoProveedor> entities);
    void Remove(MedicamentoProveedor entity);
    void RemoveRange(IEnumerable<MedicamentoProveedor> entities);
    void Update(MedicamentoProveedor entity);
        
}

