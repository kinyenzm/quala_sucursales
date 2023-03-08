using BackEnd.Models;

namespace BackEnd.Services;

public interface ISucursalService
{
    Task<List<MonedaSucursal>> GetSucursales();
    Task<MonedaSucursal> GetSucursal(int id);
    Task<MonedaSucursal> AddSucursal(MonedaSucursal sucursal);
    Task<bool> UpdateSucursal(MonedaSucursal sucursal);
    Task<bool> DeleteSucursal(int codigo);
}