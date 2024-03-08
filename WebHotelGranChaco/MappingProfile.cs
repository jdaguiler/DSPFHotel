using AutoMapper;
using WebHotelGranChaco.Dtos;
using WebHotelGranChaco.Models;

namespace WebHotelGranChaco
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de DtoCliente a Cliente y viceversa
            CreateMap<DtoCliente, Cliente>()
                  // Para el miembro "Natural" de Cliente, asigna un nuevo objeto Natural basado en los datos de DtoCliente
                  .ForMember(dest => dest.Natural, opt => opt.MapFrom(src => new Natural
                  {
                      Nombre = src.Nombre,
                      ApellidoPaterno = src.ApellidoPaterno,
                      ApellidoMaterno = src.ApellidoMaterno,
                      Genero = src.Genero,
                      DocumentoIdentidad = src.DocumentoIdentidad,
                      Nacionalidad = src.Nacionalidad
                  }));
            CreateMap<Cliente, DtoCliente>()
              // Para los miembros de DtoCliente, asigna los valores de los miembros correspondientes de Natural dentro de Cliente
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Natural.Nombre))
              .ForMember(dest => dest.ApellidoPaterno, opt => opt.MapFrom(src => src.Natural.ApellidoPaterno))
              .ForMember(dest => dest.ApellidoMaterno, opt => opt.MapFrom(src => src.Natural.ApellidoMaterno))
              .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Natural.Genero))
              .ForMember(dest => dest.DocumentoIdentidad, opt => opt.MapFrom(src => src.Natural.DocumentoIdentidad))
              .ForMember(dest => dest.Nacionalidad, opt => opt.MapFrom(src => src.Natural.Nacionalidad));

            // Mapeo directo entre DtoRegistro y Registro
            CreateMap<DtoRegistro, Registro>();
            CreateMap<Registro, DtoRegistro>();
        }
    }
}

