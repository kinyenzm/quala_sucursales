using AutoMapper;
using BackEnd.Contracts;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController, Route("api/sucursales")]
public class SucursalController : ControllerBase
{
    private readonly ISucursalService _sucursalService;
    private IMapper _mapper;

    public SucursalController(ISucursalService sucursalService, IMapper mapper)
    {
        _sucursalService = sucursalService;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtieene todas las sucursales
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetSucursales()
    {
        var sucursales = await _sucursalService.GetSucursales();
        var sucursalesDto = _mapper.Map<List<SucursalDTO>>(sucursales);
        if (sucursalesDto.Count > 0)
            return Ok(sucursalesDto);
        return NotFound();
    }

    /// <summary>
    /// Obtiene una sucursal por su codigo
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSucursal(int id)
    {
        var sucursal = await _sucursalService.GetSucursal(id);
        return sucursal != null ? Ok(_mapper.Map<SucursalDTO>(sucursal)) : NotFound();
    }

    /// <summary>
    /// Agrega una sucursal
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddSucursal(SucursalDTO sucursal)
    {
        var sucursal_ = _mapper.Map<MonedaSucursal>(sucursal);
        var sucursalAdded = await _sucursalService.AddSucursal(sucursal_);
        return sucursalAdded.Id != 0
            ? Ok(_mapper.Map<SucursalDTO>(sucursalAdded))
            : StatusCode(StatusCodes.Status500InternalServerError);
    }

    /// <summary>
    /// Actualiza una sucursal
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> UpdateSucursal(SucursalDTO sucursal)
    {
        var _encontrada = await _sucursalService.GetSucursal(sucursal.Id);

        if (_encontrada is null) return NotFound();

        bool sucursalUpdated = await _sucursalService.UpdateSucursal(_encontrada);

        return sucursalUpdated
            ? Ok(_mapper.Map<SucursalDTO>(_encontrada))
            : StatusCode(StatusCodes.Status500InternalServerError);
    }

    /// <summary>
    /// Elimina una sucursal
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSucursal(int id)
    {
        var sucursalEncontrada = await _sucursalService.GetSucursal(id);

        if (sucursalEncontrada is null) return NotFound();

        var borrado = await _sucursalService.DeleteSucursal(id);
        return borrado ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
    }
}