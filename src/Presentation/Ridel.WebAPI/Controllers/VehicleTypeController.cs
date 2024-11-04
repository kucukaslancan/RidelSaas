using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.CQRS.Queries.Vehicles;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Wrappers;

namespace Ridel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add new vehicle type (Economy, Business, SUV etc.)
        /// </summary>
        /// <remarks>
        /// Bu endpoint yeni araç türü (Economy, Business, SUV etc.) eklemeye yarar
        /// </remarks>
        /// <response code="200">Başarılı bir şekilde kayıt edildi.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<RidelResponse<string>>> AddVehicleType(AddVehicleTypeCommand vehicleType)
        {
            RidelResponse<string>? addVehicleResponse = await _mediator.Send(vehicleType);
            return Ok(addVehicleResponse);
        }

        /// <summary>
        /// Get All vehicle types 
        /// </summary>
        /// <remarks>
        /// tüm araç türlerini döndürür
        /// </remarks>
        /// <response code="200">Tüm kayıtlar başarıyla getirildi.</response>
        [Authorize(Roles = "Admin,Driver")]
        [HttpGet]
        public async Task<ActionResult<RidelResponse<VehicleTypeDTO>>> GetVehicleTypes()
        {
            RidelResponse<IEnumerable<VehicleTypeDTO>>? vehicleTypes = await _mediator.Send(new GetAllVehicleTypesQuery());
            return Ok(vehicleTypes);
        }

        /// <summary>
        /// Update vehicle type
        /// </summary>
        /// <remarks>
        /// araç türünü günceller
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<RidelResponse<string>>> UpdateVehicleType(UpdateVehicleTypeCommand vehicleType)
        {
            RidelResponse<string>? vehicleTypeUpdateResult = await _mediator.Send(vehicleType);
            return Ok(vehicleTypeUpdateResult);
        }

        /// <summary>
        /// Delete vehicle type
        /// </summary>
        /// <remarks>
        /// araç türünü siler
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult<RidelResponse<string>>> DeleteVehicleType(DeleteVehicleTypeCommand vehicleType)
        {
            RidelResponse<string>? vehicleTypeDeleteResult = await _mediator.Send(vehicleType);
            return Ok(vehicleTypeDeleteResult);
        }
    }
}
