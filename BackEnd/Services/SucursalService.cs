using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Services;

public class SucursalService : ISucursalService
{
    private readonly TestDBContext _dbContext;

    public SucursalService(TestDBContext persistenceContext)
    {
        _dbContext = persistenceContext;
    }

    public async Task<List<MonedaSucursal>> GetSucursales()
    {
        try
        {
            return await _dbContext.MonedaSucursals.Include(c => c.IdModenaNavigation)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw new Exception("No se encontró las sucursales");
        }
    }

    public async Task<MonedaSucursal> GetSucursal(int id)
    {
        try
        {
            return await _dbContext.MonedaSucursals.Include(c => c.IdModenaNavigation)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            throw new Exception("No se encontró la sucursal");
        }
    }

    public async Task<MonedaSucursal> AddSucursal(MonedaSucursal sucursal)
    {
        try
        {
            _dbContext.MonedaSucursals.Add(sucursal);
            await _dbContext.SaveChangesAsync();
            return sucursal;
        }
        catch (Exception)
        {
            throw new Exception("No se guardó la sucursal");
        }
    }

    public async Task<bool> UpdateSucursal(MonedaSucursal sucursal)
    {
        try
        {
            _dbContext.Entry(sucursal).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteSucursal(int id)
    {
        try
        {
            var sucursal = GetSucursal(id);
            if (sucursal.Result != null) _dbContext.MonedaSucursals.Remove(sucursal.Result);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}