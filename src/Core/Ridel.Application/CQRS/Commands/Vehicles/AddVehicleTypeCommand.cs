using MediatR;
using Ridel.Application.Wrappers;
using System.ComponentModel.DataAnnotations;

namespace Ridel.Application.CQRS.Commands.Vehicles
{
    public record class AddVehicleTypeCommand : IRequest<RidelResponse<string>>
    {
        [Required(ErrorMessage = $"[{nameof(Name)}] value it cannot be left empty.")]
        public string Name { get; init; }
        public string Description { get; init; }

        public AddVehicleTypeCommand(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
               // throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            }

            Name = name;
            Description = description;
        }
    }
}
