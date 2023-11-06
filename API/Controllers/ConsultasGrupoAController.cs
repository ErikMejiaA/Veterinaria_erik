using API.Dtos.Especie;
using API.Dtos.Laboratorio;
using API.Dtos.Mascota;
using API.Dtos.Medicamento;
using API.Dtos.Propietario;
using API.Dtos.Veterinario;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class ConsultasGrupoAController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public ConsultasGrupoAController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET para obtener a los veterinarios por una especialidad n 
    [HttpGet("VeterinarioEsp/{especialidad}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<VeterinarioConsultaDto>>> GetEspecialidad(string especialidad)
    {
        var movi = await _UnitOfWork.Veterinarios.GetAllVeterinariosEspecialidad(especialidad);
        return this.mapper.Map<List<VeterinarioConsultaDto>>(movi);
    }

    //METODO GET para obtener la lista de medicamentos segun el laboratorio 
    [HttpGet("MedicamentosXlab/{laboratorio}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<LaboratorioConsultaDto>>> GetMedicamentoXlab(string laboratorio)
    {
        var movi = await _UnitOfWork.Medicamentos.GetAllMedicamentosSegunUnLab(laboratorio);
        return this.mapper.Map<List<LaboratorioConsultaDto>>(movi);
    }

    //METODO GET para obtener la lista de mascotas segun su especie 
    [HttpGet("MascotasXespecie/{especie}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<EspecieXmascotaDto>>> GetMascotaXespecie(string especie)
    {
        var movi = await _UnitOfWork.Mascotas.GetAllMascotasFelinas(especie);
        return this.mapper.Map<List<EspecieXmascotaDto>>(movi);
    }

    //METODO GET para obtener la lista de mascotas y sus propietrios 
    [HttpGet("PropietariosSusMascotas")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<PropietarioXmascotaDto>>> GetMascotasPropietarios()
    {
        var movi = await _UnitOfWork.Propietarios.GetAllMascotasXpropietario();
        return this.mapper.Map<List<PropietarioXmascotaDto>>(movi);
    }

    //METODO GET para obtener la lista de medicamentos mayores a un determinado precio
    [HttpGet("MedicamentosXprecioMayorA/{precio}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<MedicamentoXprecioDto>>> GetMediamentosPrecio(double precio)
    {
        var movi = await _UnitOfWork.Medicamentos.GetAllMayoresA(precio);
        return this.mapper.Map<List<MedicamentoXprecioDto>>(movi);
    }

    
    //METODO GET para obtener la lista de mascotas por motivo de xxx en el Primer Trimestre
    [HttpGet("MascotasPorMotivoPrimerTrimestre/{motivo}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<MascotaConsultaDto>>> GetListaMascotasPrimerTrimestre(string motivo)
    {
        var movi = await _UnitOfWork.Mascotas.GetAllMascotasPorVacunacion(motivo);
        return this.mapper.Map<List<MascotaConsultaDto>>(movi);
    }

}
