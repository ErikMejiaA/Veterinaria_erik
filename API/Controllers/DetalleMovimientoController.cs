using API.Dtos.DetalleMovimiento;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class DetalleMovimientoController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public DetalleMovimientoController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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

    public async Task<ActionResult<List<DetalleMovimientoDto>>> Get()
    {
        var detalle = await _UnitOfWork.DetallesMovimientos.GetAllAsync();
        return this.mapper.Map<List<DetalleMovimientoDto>>(detalle);
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

    public async Task<ActionResult<Pager<DetalleMovimientoDto>>> Get1A([FromQuery] Params citaParams)
    {
        var citas = await _UnitOfWork.DetallesMovimientos.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        var lstCitas = this.mapper.Map<List<DetalleMovimientoDto>>(citas.registros);

        return new Pager<DetalleMovimientoDto>(lstCitas , citas.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    //[MapToApiVersion("1.0")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Get(int id)
    {
        var detalle = await _UnitOfWork.DetallesMovimientos.GetByIdAsync(id);
        if (detalle == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DetalleMovimientoDto>(detalle);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Post(DetalleMovimientoDto detalleMovimientoDto)
    {
        var detalle = this.mapper.Map<DetalleMovimiento>(detalleMovimientoDto);
        _UnitOfWork.DetallesMovimientos.Add(detalle);
        await _UnitOfWork.SaveAsync();

        if (detalle == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<DetalleMovimientoDto>(detalle);
    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Put(int id, [FromBody]DetalleMovimientoDto detalleMovimientoDto)
    {
        var detalle = this.mapper.Map<DetalleMovimiento>(detalleMovimientoDto);
        if (detalle == null)
        {
            return NotFound();
        }
        detalle.IdCodigo = id;
        _UnitOfWork.DetallesMovimientos.Update(detalle);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<DetalleMovimientoDto>(detalle);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var deatlle = await _UnitOfWork.DetallesMovimientos.GetByIdAsync(id);
        if (deatlle == null)
        {
            return NotFound();
        }
        _UnitOfWork.DetallesMovimientos.Remove(deatlle);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}
