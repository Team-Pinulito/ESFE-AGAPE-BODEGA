﻿using AutoMapper;
using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
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

            CreateMap<IngresoActivo, CrearIngresoActivoDTO>();
            CreateMap<IngresoActivo, EditIngresoActivoDTO>();
            CreateMap<IngresoActivo, GetIdResultIngresoActivoDTO>().ForMember(dest => dest.DetalleIngresoActivos, opt => opt.MapFrom(src =>
            src.DetalleIngresoActivos));
            CreateMap<IngresoActivo, SearchResultIngresoActivoDTO>();
            CreateMap<IngresoActivo, SearchQueryIngresoActivoDTO>();
            CreateMap<DetalleIngresoActivo, DetalleIngresoActivoDTO>();
            CreateMap<DetalleIngresoActivo, CrearDetalleIngresoActivoDTO>();

        }
    }
}