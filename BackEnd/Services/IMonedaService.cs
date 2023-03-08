using BackEnd.Models;

namespace BackEnd.Services;

public interface IMonedaService
{
    Task<List<Monedum>> GetMonedas();
}