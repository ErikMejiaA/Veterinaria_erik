using System.Collections;
using API.Dtos.Especie;
using API.Dtos.Mascota;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class ConsultasGrupoBController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public ConsultasGrupoBController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET para obtener todas las mascotas agrupadas segun el grupo de especie al que pertenecen
    [HttpGet("LstMascotasXespecie")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<EspecieXmascotaDto>>> GetLstMascotasEspecie()
    {
        var movi = await _UnitOfWork.Mascotas.GetAllMascotasEspecies();
        return this.mapper.Map<List<EspecieXmascotaDto>>(movi);
    }

    //METODO GET para obtener todas las mascotas segun un determinado veterinario 
    [HttpGet("MascotasPorVeterinario/{veterinario}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult<List<MascotaConsultaDto>> GetLstMascotasPorVeterinario(string veterinario)
    {
        var movi =  _UnitOfWork.Mascotas.GetAllMascotasPorVeterinario(veterinario);
        return this.mapper.Map<List<MascotaConsultaDto>>(movi);
    }

     
}
