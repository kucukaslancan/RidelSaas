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
    [ApiController]
    [Authorize]
    public class VehicleFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add new vehicle feature ("Deri Koltuk", "Navigasyon" etc.)
        /// </summary>
        /// <remarks>
        /// Bu endpoint yeni özellik ("Deri Koltuk", "Navigasyon" etc.) eklemeye yarar
        /// </remarks>
        /// <response code="200">Başarılı bir şekilde kayıt edildi.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<RidelResponse<string>>> AddVehicleFeature(AddVehicleFeatureCommand vehicleType)
        {
            RidelResponse<VehicleFeatureDTO>? addVehicleFeatureResponse = await _mediator.Send(vehicleType);
            return Ok(addVehicleFeatureResponse);
        }

        /// <summary>
        /// Get All vehicle Features 
        /// </summary>
        /// <remarks>
        /// tüm araç türlerini döndürür
        /// </remarks>
        /// <response code="200">Tüm kayıtlar başarıyla getirildi.</response>
        [Authorize(Roles = "Admin,Driver")]
        [HttpGet]
        public async Task<ActionResult<RidelResponse<VehicleTypeDTO>>> GetVehicleFeatures()
        {
            RidelResponse<IEnumerable<VehicleFeatureDTO>>? vehicleTypes = await _mediator.Send(new GetAllVehicleFeaturesQuery());
            return Ok(vehicleTypes);
        }

        /// <summary>
        /// Update vehicle Feature
        /// </summary>
        /// <remarks>
        /// araç özelliğini günceller
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<RidelResponse<string>>> UpdateVehicleFeature(UpdateVehicleFeatureCommand vehicleFeature)
        {
            RidelResponse<string>? vehicleFeatureUpdateResult = await _mediator.Send(vehicleFeature);
            return Ok(vehicleFeatureUpdateResult);
        }

        /// <summary>
        /// Delete vehicle Feature
        /// </summary>
        /// <remarks>
        /// araç özelliğini siler
        /// </remarks>
        /// <response code="200"></response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult<RidelResponse<string>>> DeleteVehicleFeature(DeleteVehicleFeatureCommand vehicleType)
        {
            RidelResponse<string>? vehicleTypeDeleteResult = await _mediator.Send(vehicleType);
            return Ok(vehicleTypeDeleteResult);
        }
    }
}
