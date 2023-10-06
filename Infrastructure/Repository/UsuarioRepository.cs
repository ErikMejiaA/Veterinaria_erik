using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class UsuarioRepository : GenericRepositoryB<Usuario>, IUsuarioInterface
{
    private readonly WebDbAppiContext _context;

    public UsuarioRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Set<Usuario>()
                                    .Include(u => u.Roles)
                                    .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }

    public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Usuarios
                                    .Include(p => p.Roles)
                                    .Include(p => p.RefreshTokens)
                                    .FirstOrDefaultAsync(p => p.RefreshTokens.Any(p => p.Token == refreshToken));;
    }

    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Set<Usuario>()
        .Include(p => p.Roles)
        .ToListAsync();
    }
    
    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Set<Usuario>()
        .Include(p => p.Roles)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Usuarios as IQueryable<Usuario>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Username.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Roles)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
}
