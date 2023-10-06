using API.Dtos.Usuario;
using API.Helpers;
using API.Services;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class UsuarioController : BaseApiController
{
    private readonly IUserServiceInterface _userService;
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public UsuarioController(IUserServiceInterface userService, IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _userService = userService;
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    //METODO POST PARA ONTENER EL TOKEN CON SU REFRESHTOKEN
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken); //activar la cookie con el refreshToken
        return Ok(result);
    }

    //METODO PARA AÑADIR UN ROL 
    [HttpPost("addrole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
    {
        var result = await _userService.AddRoleAsync(model);
        return Ok(result);
    }

    //METODO POST PARA OBTENER EL REFRESTOKEN Y ACTUALIZARLO
    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshTokenAsync(refreshToken);
        
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);

        return Ok(response);
    }
    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

    //METODO GET PARA OBTENER LOS USUARIOS REGISTRADOS
    [HttpGet]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UsuarioDto>>> GetUsuario()
    {
        var usuarios = await _UnitOfWork.Usuarios.GetAllAsync();
        return this.mapper.Map<List<UsuarioDto>>(usuarios);
    }

    //METODO GET POR ID (TRAER UN UNICO REGISTRO CON SUS ROLES)
    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioXrolDto>> Get(int id)
    {
        var usuarioXrol = await _UnitOfWork.Usuarios.GetByIdAsync(id);

        if (usuarioXrol == null) {
            return NotFound();
        }

        return this.mapper.Map<UsuarioXrolDto>(usuarioXrol);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet("Paginacion")]
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UsuarioXrolDto>>> GetTodoPagina([FromQuery] Params usuarioParams)
    {
        var usuariosXroles = await _UnitOfWork.Usuarios.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
        var lstUsuarioXrolDto = this.mapper.Map<List<UsuarioXrolDto>>(usuariosXroles.registros);

        return new Pager<UsuarioXrolDto>(lstUsuarioXrolDto, usuariosXroles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    //METOD PUT PARA EDITAR UN USUARIO 
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody] UsuarioDto usuarioDto)
    {
        if (usuarioDto == null) {
            return NotFound();
        }
        var usuario = this.mapper.Map<Usuario>(usuarioDto);
        usuario.IdCodigo = id;
        var editUsuarioRol = await _userService.EditarUsuarioAsync(usuario);

        return this.mapper.Map<UsuarioDto>(editUsuarioRol);
    }

    //METODO DELETE (ELIMINAR USUARIO REGISTRADO)
    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> DeleteUsuario(int id)
    {
        var usuario = await _UnitOfWork.Usuarios.GetByIdAsync(id);

        if(usuario == null) {
            return NotFound();
        }

        _UnitOfWork.Usuarios.Remove(usuario);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}
