using CarRentalManagementSystem.Application.Vehicles.Create;
using CarRentalManagementSystem.Application.Vehicles.Get;
using CarRentalManagementSystem.Application.Vehicles.Update;
using CarRentalManagementSystem.Application.Vehicles.UpdateMileage;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public sealed class VehiclesController : ControllerBase
    {
        private readonly CreateVehicleService _createVehicleService;
        private readonly GetVehiclesService _getVehiclesService;
        private readonly GetVehicleByIdService _getVehicleByIdService;
        private readonly UpdateVehicleService _updateVehicleService;
        private readonly UpdateVehicleMileageService _updateVehicleMileageService;
        private readonly WithdrawVehicleService _withdrawVehicleService;

        public VehiclesController(
            CreateVehicleService createVehicleService,
            GetVehiclesService getVehiclesService,
            GetVehicleByIdService getVehicleByIdService,
            UpdateVehicleService updateVehicleService,
            UpdateVehicleMileageService updateVehicleMileageService,
            WithdrawVehicleService withdrawVehicleService)
        {
            _createVehicleService = createVehicleService;
            _getVehiclesService = getVehiclesService;
            _getVehicleByIdService = getVehicleByIdService;
            _updateVehicleService = updateVehicleService;
            _updateVehicleMileageService = updateVehicleMileageService;
            _withdrawVehicleService = withdrawVehicleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateVehicleRequest request,
            CancellationToken cancellationToken)
        {
            var vehicle = await _createVehicleService.CreateAsync(
                request,
                cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = vehicle.Id },
                vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var vehicles = await _getVehiclesService.GetAsync(cancellationToken);

            return Ok(vehicles);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var vehicle = await _getVehicleByIdService.GetByIdAsync(id, cancellationToken);

            if (vehicle is null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateVehicleRequest request,
            CancellationToken cancellationToken)
        {
            await _updateVehicleService.UpdateAsync(
                id,
                request,
                cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}/mileage")]
        public async Task<IActionResult> UpdateMileage(
            Guid id,
            UpdateVehicleMileageRequest request,
            CancellationToken cancellationToken)
        {
            await _updateVehicleMileageService.UpdateAsync(
                id,
                request,
                cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}/withdraw")]
        public async Task<IActionResult> Withdraw(
            Guid id,
            CancellationToken cancellationToken)
        {
            await _withdrawVehicleService.WithdrawAsync(
                id,
                cancellationToken);

            return NoContent();
        }
    }
}
