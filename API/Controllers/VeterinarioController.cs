using API.Dtos.Veterinario;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class VeterinarioController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public VeterinarioController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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

    public async Task<ActionResult<List<VeterinarioDto>>> Get()
    {
        var movi = await _UnitOfWork.Veterinarios.GetAllAsync();
        return this.mapper.Map<List<VeterinarioDto>>(movi);
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

    public async Task<ActionResult<Pager<VeterinarioDto>>> Get1A([FromQuery] Params mascoParams)
    {
        var masco = await _UnitOfWork.Veterinarios.GetAllAsync(mascoParams.PageIndex, mascoParams.PageSize, mascoParams.Search);
        var lstmascosDto = this.mapper.Map<List<VeterinarioDto>>(masco.registros);

        return new Pager<VeterinarioDto>(lstmascosDto , masco.totalRegistros, mascoParams.PageIndex, mascoParams.PageSize, mascoParams.Search);
    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    //[MapToApiVersion("1.0")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Get(int id)
    {
        var labo = await _UnitOfWork.Veterinarios.GetByIdAsync(id);
        if (labo == null)
        {
            return NotFound();
        }
        return this.mapper.Map<VeterinarioDto>(labo);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Post(VeterinarioDto veterinarioDto)
    {
        var labo = this.mapper.Map<Veterinario>(veterinarioDto);
        _UnitOfWork.Veterinarios.Add(labo);
        await _UnitOfWork.SaveAsync();

        if (labo == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<VeterinarioDto>(labo);
    }

     //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody]VeterinarioDto veterinarioDto)
    {
        var labo = this.mapper.Map<Veterinario>(veterinarioDto);
        if (labo == null)
        {
            return NotFound();
        }
        labo.IdCodigo = id;
        _UnitOfWork.Veterinarios.Update(labo);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<VeterinarioDto>(labo);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var labo = await _UnitOfWork.Veterinarios.GetByIdAsync(id);
        if (labo == null)
        {
            return NotFound();
        }
        _UnitOfWork.Veterinarios.Remove(labo);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
        
}
