
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;
using Backend.Services.Interfaces;
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

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Unit>>> GetAllUnits([FromBody] Guid userId)
    {
        // fetches from Unit
        try
        {
            var units = await _service.GetAllUnits(userId);
            return Ok(units);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> CreateNewUnit(NewUnitDto newUnit) // takes dto
    {
        // modifies Unit
        try
        {
            var unit = await _service.AddNewUnit(newUnit);
            return Ok(unit);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    public async Task<ActionResult> EditUnit(Guid unitId, NewUnitDto unitEdited) // takes dto
    {
        // modifies Unit
        try
        {
            await _service.EditUnit(unitId, unitEdited);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUnit(Guid id)
    {
        // modifies Unit
        try
        {
            await _service.DeleteUserDefinedUnit(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    } 

}