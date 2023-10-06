using API.Dtos.Propietario;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class PropietarioController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public PropietarioController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;

    }

    //METODO GET obtener todos los registros
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<PropietarioDto>>> Get()
    {
        var movi = await _UnitOfWork.Propietarios.GetAllAsync();
        return this.mapper.Map<List<PropietarioDto>>(movi);
    }

    //METODO GET inplemetacion de la paginacion, busquedas
    [HttpGet("Paginacion")]
    [MapToApiVersion("1.1")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Pager<PropietarioDto>>> Get1A([FromQuery] Params mascoParams)
    {
        var masco = await _UnitOfWork.Propietarios.GetAllAsync(mascoParams.PageIndex, mascoParams.PageSize, mascoParams.Search);
        var lstmascosDto = this.mapper.Map<List<PropietarioDto>>(masco.registros);

        return new Pager<PropietarioDto>(lstmascosDto , masco.totalRegistros, mascoParams.PageIndex, mascoParams.PageSize, mascoParams.Search);
    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    //[MapToApiVersion("1.0")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Get(int id)
    {
        var labo = await _UnitOfWork.Propietarios.GetByIdAsync(id);
        if (labo == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PropietarioDto>(labo);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Post(PropietarioDto propietarioDto)
    {
        var labo = this.mapper.Map<Propietario>(propietarioDto);
        _UnitOfWork.Propietarios.Add(labo);
        await _UnitOfWork.SaveAsync();

        if (labo == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<PropietarioDto>(labo);
    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody]PropietarioDto propietarioDto)
    {
        var labo = this.mapper.Map<Propietario>(propietarioDto);
        if (labo == null)
        {
            return NotFound();
        }
        labo.IdCodigo = id;
        _UnitOfWork.Propietarios.Update(labo);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<PropietarioDto>(labo);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var labo = await _UnitOfWork.Propietarios.GetByIdAsync(id);
        if (labo == null)
        {
            return NotFound();
        }
        _UnitOfWork.Propietarios.Remove(labo);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
        
}
