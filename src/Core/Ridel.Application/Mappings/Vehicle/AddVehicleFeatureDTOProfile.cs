using AutoMapper;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Domain.Entities;

namespace Ridel.Application.Mappings.Vehicle
{
    public class AddVehicleFeatureDTOProfile : Profile
    {
        public AddVehicleFeatureDTOProfile()
        {
            CreateMap<VehicleFeature, VehicleFeatureDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Id alanı doğrudan eşleniyor
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FeatureName)) // FeatureName alanı Name'e eşleniyor
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)) // Description alanı Description'a eşleniyor
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted)); // IsDeleted alanı doğrudan eşleniyor

        }
    }
}
