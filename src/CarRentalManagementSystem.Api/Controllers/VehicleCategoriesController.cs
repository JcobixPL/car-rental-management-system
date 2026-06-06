using CarRentalManagementSystem.Application.VehicleCategories.Create;
using CarRentalManagementSystem.Application.VehicleCategories.Get;
using CarRentalManagementSystem.Application.VehicleCategories.StatusUpdate;
using CarRentalManagementSystem.Application.VehicleCategories.Update;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class VehicleCategoriesController : ControllerBase
    {
        private readonly CreateVehicleCategoryService _createVehicleCategoryService;
        private readonly GetVehicleCategoriesService _getVehicleCategoriesService;
        private readonly GetVehicleCategoryByIdService _getVehicleCategoryByIdService;
        private readonly UpdateVehicleCategoryService _updateVehicleCategoryService;
        private readonly ActivateVehicleCategoryService _activateVehicleCategoryService;
        private readonly DeactivateVehicleCategoryService _deactivateVehicleCategoryService;

        public VehicleCategoriesController(
            CreateVehicleCategoryService createVehicleCategoryService,
            GetVehicleCategoriesService getVehicleCategoriesService,
            GetVehicleCategoryByIdService getVehicleCategoryByIdService,
            UpdateVehicleCategoryService updateVehicleCategoryService,
            ActivateVehicleCategoryService activateVehicleCategoryService,
            DeactivateVehicleCategoryService deactivateVehicleCategoryService)
        {
            _createVehicleCategoryService = createVehicleCategoryService;
            _getVehicleCategoriesService = getVehicleCategoriesService;
            _getVehicleCategoryByIdService = getVehicleCategoryByIdService;
            _updateVehicleCategoryService = updateVehicleCategoryService;
            _activateVehicleCategoryService = activateVehicleCategoryService;
            _deactivateVehicleCategoryService = deactivateVehicleCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateVehicleCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var vehicleCategory = await _createVehicleCategoryService.CreateAsync(
                request,
                cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = vehicleCategory.Id },
                vehicleCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var vehicleCategories = await _getVehicleCategoriesService.GetAllAsync(cancellationToken);
            return Ok(vehicleCategories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var vehicleCategory = await _getVehicleCategoryByIdService.GetByIdAsync(
                id, 
                cancellationToken);

            if (vehicleCategory is null)
                return NotFound();

            return Ok(vehicleCategory);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateVehicleCategoryRequest request,
            CancellationToken cancellationToken)
        {
            await _updateVehicleCategoryService.UpdateAsync(
                id,
                request,
                cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}/activate")]
        public async Task<IActionResult> Activate(
            Guid id,
            CancellationToken cancellationToken)
        {
            await _activateVehicleCategoryService.ActivateAsync(id, cancellationToken);
            
            return NoContent();
        }

        [HttpPatch("{id:guid}/deactivate")]
        public async Task<IActionResult> Deactivate(
            Guid id,
            CancellationToken cancellationToken)
        {
            await _deactivateVehicleCategoryService.DeactivateAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
