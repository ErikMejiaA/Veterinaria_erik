using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWorkInterface, IDisposable
{
    //definimos el constructor y las variabales de los repositorios creados 
    private readonly WebDbAppiContext _context;
    private RolRepository ? _roles;
    private UsuarioRepository ? _usuarios;
    private UsuariosRolesRepository ? _usuariosRoles;
    private CitaRepository ? _citas;
    private DetalleMovimientoRepository ? _detallesMovimientos;
    private EspecieRepository ? _especies;
    private LaboratorioRepository ? _laboratorios;
    private MascotaRepository ? _mascotas;
    private MedicamentoProveedorRepository ? _medicamentosProveedores;
    private MedicamentoRepository ? _medicamentos;
    private MovimientoMedicamnetoRepository ? _movimientosMedicamnetos;
    private PropietarioRepository ? _propietarios;
    private ProveedorRepository ? _proveedores;
    private RazaRepository ? _razas;
    private TipoMovimientoRepository ? _tiposMovimientos;
    private TratamientoMedicoRepository ? _tratamientosMedicos;
    private VeterinarioRepository ? _veterinarios;

    public UnitOfWork(WebDbAppiContext context)
    {
        _context = context;
    }

    
    public IRolInterface Roles
    {
        get
        {
            if (_roles == null) {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUsuarioInterface Usuarios
    {
        get
        {
            if (_usuarios == null) {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public IUsuariosRolesInterface UsuariosRoles
    {
        get
        {
            if (_usuariosRoles == null) {
                _usuariosRoles = new UsuariosRolesRepository(_context);
            }
            return _usuariosRoles;

        }
    }

    public ICitaInterface Citas
    {
        get
        {
            if (_citas == null) {
                _citas = new CitaRepository(_context);
            }
            return _citas;

        }
    }

    public IDetalleMovimientoInterface DetallesMovimientos
    {
        get
        {
            if (_detallesMovimientos == null) {
                _detallesMovimientos = new DetalleMovimientoRepository(_context);
            }
            return _detallesMovimientos;
        }
    }

    public IEspecieInterface Especies
    {
        get
        {
            if (_especies == null) {
                _especies = new EspecieRepository(_context);
            }
            return _especies;
        }
    }

    public ILaboratorioInterface Laboratorios
    {
        get
        {
            if(_laboratorios == null) {
                _laboratorios = new LaboratorioRepository(_context);
            }
            return _laboratorios;
        }
    }

    public IMascotaInterface Mascotas
    {
        get
        {
            if (_mascotas == null) {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    public IMedicamentoInterface Medicamentos 
    {
        get
        {
            if(_medicamentos == null) { 
                _medicamentos = new MedicamentoRepository(_context);
            }
            return _medicamentos;
        }
    }

    public IMedicamentoProveedorInterface MedicamentosProveedores
    {
        get
        {
            if (_medicamentosProveedores == null) {
                _medicamentosProveedores = new MedicamentoProveedorRepository(_context);
            }
            return _medicamentosProveedores;
        }
    }

    public IMovimientoMedicamentoInterface MovimientosMedicamentos
    {
        get
        {
            if (_movimientosMedicamnetos == null) {
                _movimientosMedicamnetos = new MovimientoMedicamnetoRepository(_context);
            }
            return _movimientosMedicamnetos;
        }
    }

    public IPropietarioInterface Propietarios
    {
        get
        {
            if (_propietarios == null) {
                _propietarios = new PropietarioRepository(_context);
            }
            return _propietarios;
        }
    }

    public IProveedorInterface Proveedores
    {
        get
        {
            if (_proveedores == null) {
                _proveedores = new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    }

    public IRazaInterface Razas
    {
        get
        {
            if (_razas == null) {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }

    public ITipoMovimientoInterface TiposMovimientos
    {
        get
        {
            if (_tiposMovimientos == null) {
                _tiposMovimientos = new TipoMovimientoRepository(_context);
            }
            return _tiposMovimientos;
        }
    }

    public ITrtamientoMedicoInterface TratamientosMedicos
    {
        get
        {
            if (_tratamientosMedicos == null) { 
                _tratamientosMedicos = new TratamientoMedicoRepository(_context);
            }
            return _tratamientosMedicos;
        }
    }

    public IVeterinarioInterface Veterinarios
    {
        get
        {
            if (_veterinarios == null) {
                _veterinarios = new VeterinarioRepository(_context);
                
            }
            return _veterinarios;
        }
    }

    public void Dispose()
    {
        _context.Dispose(); //liberar memoria 
    }


    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync(); //para guardar los cambios en la base de datos 
    }
}
