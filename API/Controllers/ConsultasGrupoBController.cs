using System.Collections;
using API.Dtos.Especie;
using API.Dtos.Mascota;
using API.Dtos.MovimientoMedicamento;
using API.Dtos.Propietario;
using API.Dtos.Proveedor;
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

    //METODO GET para obtener el listado de Movimiento de los medicamentos con el precio total de cada movimiento
    [HttpGet("ListaMovimientoMedicamentosPrecioTotal")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult<List<object>> GetLstMoviMedicamentoPrecioTotal()
    {
        var LstMoviMediPrecio =  _UnitOfWork.MovimientosMedicamentos.ListaValorTotalMovimientoMedicamentos();
        return this.mapper.Map<List<object>>(LstMoviMediPrecio);
    }

    //METODO GET para obtener el listado de los Proveedores que venden un determinado Medicamento
    [HttpGet("ProveedorVendeMedicamento/{nombreMedicamento}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult<List<ListaProveedoresDto>> GetLstProveedorMedicamento(string nombreMedicamento)
    {
        var lstProveedorMedi =  _UnitOfWork.Proveedores.GetListaProveedoresMedicamento(nombreMedicamento);
        return this.mapper.Map<List<ListaProveedoresDto>>(lstProveedorMedi);
    }

    //METODO GET para obtener el listado de los Propietarios con sus Mascotas segun la raza 
    [HttpGet("PropietariosMascotasSegunRaza/{nombreRaza}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult<List<LstaMascotasPropietarioRazaDto>> GetLstmascotasPropietarios(string nombreRaza)
    {
        var lstPropietariosMascotas =  _UnitOfWork.Mascotas.GetLtsMascotasPropietarioRaza(nombreRaza);
        return this.mapper.Map<List<LstaMascotasPropietarioRazaDto>>(lstPropietariosMascotas);
    }

    //METODO GET Para obtener una lista de las Razas con la cantidad de Mascotas que la conforman 
    [HttpGet("ListaRazasConCantidadMescotas")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult<List<object>> GetListaRazasXMascotasCantidad()
    {
        var lstMascotasXraza  = _UnitOfWork.Razas.GetAllRazasCantidadMascotas();
        return this.mapper.Map<List<object>>(lstMascotasXraza);
    }

     
}
