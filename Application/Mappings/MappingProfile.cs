using AutoMapper;
using DamInspectionApi.Models;
using DamInspectionApi.Application.DTOs;

namespace DamInspectionApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento de Dam para Dam DTOs
            CreateMap<Dam, DamReadDto>()
                .ForMember(dest => dest.Inspections, opt => opt.MapFrom(src => src.Inspections));

            CreateMap<DamWriteDto, Dam>();

            // Mapeamento de Dam para DamSummaryDto
            CreateMap<Dam, DamSummaryDto>();

            // Mapeamento de Inspection para Inspection DTOs
            CreateMap<Inspection, InspectionReadDto>()
                .ForMember(dest => dest.Dam, opt => opt.MapFrom(src => src.Dam));

            CreateMap<InspectionWriteDto, Inspection>();

            // Mapeamento de Inspection para InspectionSummaryDto
            CreateMap<Inspection, InspectionSummaryDto>();
        }
    }
}
