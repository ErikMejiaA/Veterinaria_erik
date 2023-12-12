
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MascotaRepository : GenericRepositoryB<Mascota>, IMascotaInterface
{
    private readonly WebDbAppiContext _context;

    public MascotaRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Set<Mascota>()
        .Include(p => p.Citas)
        .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Set<Mascota>()
        .Include(p => p.Citas)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Mascotas as IQueryable<Mascota>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Citas)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    //CONSULTAS
    public async Task<IEnumerable<Especie>> GetAllMascotasFelinas(string especie)
    {
        var lstMascotasEspecie = _context.Set<Especie>()
        .Include(p => p.Mascotas)
        .Where(p => p.Nombre.ToLower().Contains(especie.ToLower()))
        .ToListAsync();

        return await lstMascotasEspecie;
    }

    public async Task<IEnumerable<Mascota>> GetAllMascotasPorVacunacion(string motivo)
    {
        var lstMascotasPorMotivo = _context.Set<Mascota>()
        .Where(p => p.Citas.Any(p => (p.Motivo.ToLower().Contains(motivo.ToLower())) && (p.Fecha >= new DateTime(2023, 1, 1) && p.Fecha < new DateTime(2023, 4, 1))))
        .ToListAsync();
        
        return await lstMascotasPorMotivo;
    }

    public async Task<IEnumerable<Especie>> GetAllMascotasEspecies()
    {
        var lstMascotasEspecie = _context.Set<Especie>()
        .Include(p => p.Mascotas)
        .Where(p => !(p.Mascotas.Count() == 0 || p.Mascotas == null))
        .ToListAsync();

        return await lstMascotasEspecie;
    }

    public IEnumerable<Mascota> GetAllMascotasPorVeterinario(string Veterinario)
    {
        List<Mascota> mascotas = new();
        var lstVeterinario = _context.Set<Veterinario>()
        .Include(p => p.Citas)
        .Where(p => p.Nombre.ToLower().Contains(Veterinario.ToLower()))
        .ToList();

        foreach (var veterCita in lstVeterinario)
        {
            foreach (var mascId in veterCita.Citas)
            {
                var lstMascotas = _context.Set<Mascota>()
                .Where(p => p.IdCodigo == mascId.Id_mascota)
                .First();
                mascotas.Add(lstMascotas);
            }
        }

        return mascotas;
    }

    public IEnumerable<Mascota> GetLtsMascotasPropietarioRaza(string nombreRaza)
    {
        var raza = _context.Set<Raza>()
        .Where(p => p.Nombre.ToLower() == nombreRaza.ToLower())
        .First();

        var lstMascotaPropietario = _context.Set<Mascota>()
        .Include(p => p.Propietario)
        .Where(p => p.Id_raza == raza.IdCodigo)
        .ToList();

        return lstMascotaPropietario;
    }
}
