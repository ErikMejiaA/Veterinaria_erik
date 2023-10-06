
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MedicamentoProveedorRepository : IMedicamentoProveedorInterface
{
    private readonly WebDbAppiContext _context;

    public MedicamentoProveedorRepository(WebDbAppiContext context)
    {
        _context = context;
    }

    //implementacion de los metodos de la Interfaces

    public void Add( MedicamentoProveedor entity)
    {
        _context.Set< MedicamentoProveedor>().Add(entity);
    }

    public void AddRange(IEnumerable< MedicamentoProveedor> entities)
    {
        _context.Set< MedicamentoProveedor>().AddRange(entities);
    }

    public IEnumerable< MedicamentoProveedor> Find(Expression<Func< MedicamentoProveedor, bool>> expression)
    {
        return _context.Set< MedicamentoProveedor>().Where(expression);
    }

    public async Task<IEnumerable< MedicamentoProveedor>> GetAllAsync()
    {
        return await _context.Set< MedicamentoProveedor>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable< MedicamentoProveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set< MedicamentoProveedor>().CountAsync();
        var registros = await _context.Set< MedicamentoProveedor>()
                                                        .Skip((pageIndex - 1) * pageSize)
                                                        .Take(pageSize)
                                                        .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task< MedicamentoProveedor> GetByIdAsync(int idProveedor, int idMedicamento)
    {
        return await _context.Set< MedicamentoProveedor>().FirstOrDefaultAsync(p => (p.Id_proveedor == idProveedor && p.Id_medicamento == idMedicamento));
    }

    public void Remove( MedicamentoProveedor entity)
    {
        _context.Set< MedicamentoProveedor>().Remove(entity);
    }

    public void RemoveRange(IEnumerable< MedicamentoProveedor> entities)
    {
        _context.Set< MedicamentoProveedor>().RemoveRange(entities);
    }

    public void Update( MedicamentoProveedor entity)
    {
        _context.Set< MedicamentoProveedor>().Update(entity);
    }
}


