using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Services;

namespace BackEnd.Services;

public class MonedaService : IMonedaService
{
    private readonly TestDBContext _dbContext;
    
    public MonedaService(TestDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Monedum>> GetMonedas()
    {
        try
        {
            return await _dbContext.Moneda.ToListAsync(); 
        }
        catch (Exception)
        {
            throw new Exception("No se encontró monedas");
        }
    }
}