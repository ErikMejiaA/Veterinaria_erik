using API.Dtos.MedicamentoProveedor;
using API.Helpers;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener solo las areas de incidencias
public class MedicamentoProveedorController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    //constructor de la classe
    public MedicamentoProveedorController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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

    public async Task<ActionResult<List<MedicamentoProveedorDto>>> Get()
    {
        var medic = await _UnitOfWork.MedicamentosProveedores.GetAllAsync();
        return this.mapper.Map<List<MedicamentoProveedorDto>>(medic);
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

    public async Task<ActionResult<Pager<MedicamentoProveedorDto>>> Get1A([FromQuery] Params mascoParams)
    {
        var masco = await _UnitOfWork.Mascotas.GetAllAsync(mascoParams.PageIndex, mascoParams.PageSize, mascoParams.Search);
        var lstmascosDto = this.mapper.Map<List<MedicamentoProveedorDto>>(masco.registros);

        return new Pager<MedicamentoProveedorDto>(lstmascosDto , masco.totalRegistros, mascoParams.PageIndex, mascoParams.PageSize, mascoParams.Search);
    }
}
        

