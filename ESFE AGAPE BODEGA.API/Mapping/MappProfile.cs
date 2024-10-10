using AutoMapper;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs;

namespace ESFE_AGAPE_BODEGA.API.Mapping
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            CreateMap<SolicitudActivo, CrearSolicitudActivoDTO>();
            CreateMap<SolicitudActivo, EditSolicitudActivoDTO>();
            CreateMap<SolicitudActivo, GetIdResultSolicitudActivoDTO>().ForMember(dest => dest.DetalleSolicitudActivoDTOs, opt => opt.MapFrom(src => src.DetalleSolicitudActivos));
            CreateMap<SolicitudActivo, SearchQuerySolicitudActivoDTO>();
            CreateMap<SolicitudActivo, SearchResultSolicitudActivoDTO>();
            CreateMap<DetalleSolicitudActivo, DetalleSolicitudActivoDTO>();
            CreateMap<DetalleSolicitudActivo, CrearDetalleSolicitudActivoDTO>();

            CreateMap<Bodega, CrearBodegaDTO>();
            CreateMap<Bodega, EditBodegaDTO>();
            CreateMap<Bodega, GetIdResultBodegaDTO>();
            CreateMap<Bodega, SearchResultBodegaDTO>();
            CreateMap<Bodega, SearchQueryBodegaDTO>();

        }
    }
}
