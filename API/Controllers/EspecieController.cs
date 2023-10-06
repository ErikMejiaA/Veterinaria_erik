using API.Dtos.Especie;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class EspecieController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public EspecieController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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

    public async Task<ActionResult<List<EspecieDto>>> Get()
    {
        var especie = await _UnitOfWork.Especies.GetAllAsync();
        return this.mapper.Map<List<EspecieDto>>(especie);
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

    public async Task<ActionResult<Pager<EspecieDto>>> Get1A([FromQuery] Params citaParams)
    {
        var citas = await _UnitOfWork.Especies.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        var lstCitas = this.mapper.Map<List<EspecieDto>>(citas.registros);

        return new Pager<EspecieDto>(lstCitas , citas.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    //[MapToApiVersion("1.0")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Get(int id)
    {
        var especie = await _UnitOfWork.Especies.GetByIdAsync(id);
        if (especie == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EspecieDto>(especie);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Post(EspecieDto especieDto)
    {
        var especie = this.mapper.Map<Especie>(especieDto);
        _UnitOfWork.Especies.Add(especie);
        await _UnitOfWork.SaveAsync();

        if (especie == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<EspecieDto>(especie);
    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody]EspecieDto especieDto)
    {
        var especie = this.mapper.Map<Especie>(especieDto);
        if (especie == null)
        {
            return NotFound();
        }
        especie.IdCodigo = id;
        _UnitOfWork.Especies.Update(especie);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<EspecieDto>(especie);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var especie = await _UnitOfWork.Especies.GetByIdAsync(id);
        if (especie == null)
        {
            return NotFound();
        }
        _UnitOfWork.Especies.Remove(especie);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
        
}
