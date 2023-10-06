using API.Dtos.Cita;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class CitaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public CitaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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

    public async Task<ActionResult<List<CitaDto>>> Get()
    {
        var citas = await _UnitOfWork.Citas.GetAllAsync();
        return this.mapper.Map<List<CitaDto>>(citas);
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

    public async Task<ActionResult<Pager<CitaDto>>> Get1A([FromQuery] Params citaParams)
    {
        var citas = await _UnitOfWork.Citas.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        var lstCitas = this.mapper.Map<List<CitaDto>>(citas.registros);

        return new Pager<CitaDto>(lstCitas , citas.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
    }

    //METODO GET POR ID (buscar un registro por id)
    [HttpGet("{id}")]
    //[MapToApiVersion("1.0")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Get(int id)
    {
        var rol = await _UnitOfWork.Citas.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return this.mapper.Map<CitaDto>(rol);
    }

    //METODO POST (para enviar iformacion a la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Post(CitaDto citaDto)
    {
        var cita = this.mapper.Map<Cita>(citaDto);
        _UnitOfWork.Citas.Add(cita);
        await _UnitOfWork.SaveAsync();

        if (cita == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<CitaDto>(cita);
    }

    //METODO PUT (para editar un registro de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Put(int id, [FromBody]CitaDto citaDto)
    {
        var cita = this.mapper.Map<Cita>(citaDto);
        if (cita == null)
        {
            return NotFound();
        }
        cita.IdCodigo = id;
        _UnitOfWork.Citas.Update(cita);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<CitaDto>(cita);
    }

    //METODO DELETE (Eliminar un regidtro de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var cita = await _UnitOfWork.Citas.GetByIdAsync(id);
        if (cita == null)
        {
            return NotFound();
        }
        _UnitOfWork.Citas.Remove(cita);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}
