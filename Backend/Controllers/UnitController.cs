using Backend.Dtos;
using Backend.Extensions;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class UnitController : ControllerBase
{
    private readonly ILogger<UnitController> _logger;
    private readonly IUnitService _service;


    // units will be stored in frontend id-title

    public UnitController(ILogger<UnitController> logger, IUnitService service)
    {
        _logger = logger;
        _service = service;
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetUnitDto>>> GetAllUnits()
    {
        // fetches from Unit
        var userId = User.GetUserId();
        var units = await _service.GetAllUnits(userId);

        return Ok(units);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GetUnitDto>> CreateNewUnit([FromBody] NewEditUnitDto newUnit) // takes dto
    {
        // modifies Unit
        var userId = User.GetUserId();
        var unit = await _service.AddNewUnit(userId, newUnit);
        return Ok(unit);
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> EditUnit(Guid id, [FromBody] NewEditUnitDto unitEdited) // takes dto
    {
        // modifies Unit
        await _service.EditUnit(id, unitEdited);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUnit(Guid id)
    {
        // modifies Unit
        await _service.DeleteUserDefinedUnit(id);
        return Ok();
    }

    [Authorize]
    [HttpPost("delete-multiple")]
    public async Task<ActionResult> DeleteBatchUnits([FromBody] BatchDeleteDto idsToDelete)
    {
        // modifies Unit
        await _service.BatchDeleteUnits(idsToDelete);
        return Ok();
    }

}