using AutoMapper;
using BackEnd.Contracts;
using BackEnd.Models;
using System.Globalization;

namespace BackEnd.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Sucursal

        CreateMap<MonedaSucursal, SucursalDTO>()
            .ForMember(dest =>
                    dest.Moneda,
                opt =>
                    opt.MapFrom(o => o.IdModenaNavigation.Codigo)
            )
            .ForMember(dest =>
                    dest.IdMoneda,
                opt =>
                    opt.MapFrom(o => o.IdModenaNavigation.Id)
            )
            .ForMember(dest =>
                    dest.FechaCreacion, opt =>
                    opt.MapFrom(o => o.FechaCreacion.Value.ToString("dd/MM/yyyy"))
            );

        CreateMap<SucursalDTO, MonedaSucursal>()
            .ForMember(dest =>
                    dest.IdModena,
                opt => opt.MapFrom(src => src.IdMoneda)
            )
            .ForMember(dest =>
                    dest.IdModenaNavigation,
                opt => opt.Ignore()
            )
            .ForMember(destine =>
                    destine.FechaCreacion, opt =>
                    opt.MapFrom(o =>
                        DateTime.ParseExact(o.FechaCreacion, "dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    )
            );

        #endregion

        #region Moneda

        CreateMap<Monedum, MonedaDTO>().ReverseMap();

        #endregion
    }
}