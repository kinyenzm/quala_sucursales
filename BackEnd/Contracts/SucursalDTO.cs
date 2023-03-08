namespace BackEnd.Contracts;

public class SucursalDTO
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
    public string Direccion { get; set; }
    public string Identificacion { get; set; }
    public int? IdMoneda { get; set; }
    public string? Moneda { get; set; }
    public string FechaCreacion { get; set; }
}
