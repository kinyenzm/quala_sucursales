using AutoMapper;
using BackEnd.Contracts;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;


[ApiController, Route("api/monedas")]
public class MonedaController : ControllerBase
{
       private readonly IMonedaService _monedaService;
       private IMapper _mapper;
       
       public MonedaController(IMonedaService monedaService, IMapper mapper)
       {
              _monedaService = monedaService;
              _mapper = mapper;
       }
       
       /// <summary>
       /// Obtiene todas las monedas
       /// </summary>
       [HttpGet]
       public async Task<IActionResult> GetMonedas()
       {
              var coins = await _monedaService.GetMonedas();
              var monedas = _mapper.Map<List<MonedaDTO>>(coins);
              if (monedas.Count > 0)
                     return Ok(monedas);
              return NotFound();
       }
}