using AutoMapper;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Domain.Entities;

namespace Ridel.Application.Mappings.Vehicle
{
    public class UpdateVehicleFeatureProfile : Profile
    {
        public UpdateVehicleFeatureProfile()
        {
            CreateMap<UpdateVehicleFeatureCommand, VehicleFeature>()
                .ForMember(dest => dest.FeatureName, opt => opt.MapFrom(source => source.Name));
        }
    }
}
