using AutoMapper;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.Mappings.Vehicle
{
    public class GetAllVehicleTypesProfile : Profile
    {
        public GetAllVehicleTypesProfile()
        {

            CreateMap<VehicleType, VehicleTypeDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description));
        }
    }
}
