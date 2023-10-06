using API.Dtos.UsuariosRoles;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class UsuariosRolesController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public UsuariosRolesController(IUnitOfWorkInterface unitOfWork, IMapper mapper)
    {
        _UnitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet("Pagina")]
    //[Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UsuariosRolesDto>>> GetPaginaUsuarioRol([FromQuery] Params usuarioParams)
    {
        var usuariosRoles = await _UnitOfWork.UsuariosRoles.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);

        var lstUsuRolDto = this.mapper.Map<List<UsuariosRolesDto>>(usuariosRoles.registros);

        return new Pager<UsuariosRolesDto>(lstUsuRolDto, usuariosRoles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{idUsuario}/{idRol}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> GetByIdUsuarioRol( int idUsuario, int idRol)
    {
        var usuarioRol = await _UnitOfWork.UsuariosRoles.GetByIdAsync(idUsuario, idRol);

        if (usuarioRol == null) {
            return NotFound();
        }

        return this.mapper.Map<UsuariosRolesDto>(usuarioRol);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Post(UsuariosRolesDto usuarioRolDto)
    {
        var usuarioRol = this.mapper.Map<UsuariosRoles>(usuarioRolDto);
        _UnitOfWork.UsuariosRoles.Add(usuarioRol);
        await _UnitOfWork.SaveAsync();

        if (usuarioRol == null) {
            return BadRequest();
        }

        return this.mapper.Map<UsuariosRolesDto>(usuarioRol);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{idUsuario}/{idRol}")]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Put(int idUsuario, int idRol, [FromBody] UsuariosRolesDto usuarioRolDto)
    {
        if (usuarioRolDto == null) {
            return NotFound();
        }

        var usuarioRol = this.mapper.Map<UsuariosRoles>(usuarioRolDto);
        usuarioRol.UsuarioId = idUsuario;
        usuarioRol.RolId = idRol;
        _UnitOfWork.UsuariosRoles.Update(usuarioRol);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<UsuariosRolesDto>(usuarioRol);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{idUsuario}/{idRol}")]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Delete(int idUsuario, int idRol)
    {
        var usuarioRol = await _UnitOfWork.UsuariosRoles.GetByIdAsync (idUsuario, idRol);
        
        if (usuarioRol == null) {
            return NotFound();
        }

        _UnitOfWork.UsuariosRoles.Remove(usuarioRol);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
    
}
