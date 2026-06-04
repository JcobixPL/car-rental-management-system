using CarRentalManagementSystem.Application.Branches.CreateBranch;
using CarRentalManagementSystem.Application.Branches.Get;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/branches")]
    public class BranchesController : ControllerBase
    {
        private readonly CreateBranchService _createBranchService;
        private readonly GetBranchesService _getBranchesService;
        private readonly GetBranchByIdService _getBranchByIdService;

        public BranchesController(
            CreateBranchService createBranchService,
            GetBranchesService getBranchesService,
            GetBranchByIdService getBranchByIdService)
        {
            _createBranchService = createBranchService;
            _getBranchesService = getBranchesService;
            _getBranchByIdService = getBranchByIdService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var branches = await _getBranchesService.GetAllAsync(cancellationToken);
            return Ok(branches);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var branch = await _getBranchByIdService.GetByIdAsync(id, cancellationToken);
            if (branch is null)
                return NotFound();

            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateBranchRequest request,
            CancellationToken cancellationToken)
        {
            var branch = await _createBranchService.CreateAsync(request, cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = branch.Id },
                branch);
        }
    }
}
