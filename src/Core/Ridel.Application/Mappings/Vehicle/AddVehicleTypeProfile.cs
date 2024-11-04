using AutoMapper;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Domain.Entities;

namespace Ridel.Application.Mappings.Vehicle
{
    public class AddVehicleTypeProfile:Profile
    {
        public AddVehicleTypeProfile()
        {
            CreateMap<AddVehicleTypeCommand, VehicleType>();
        }
    }
}
