
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class UnitController : ControllerBase
{
    private readonly ILogger<UnitController> _logger;
    //private readonly IUnitService _service;

    public UnitController(ILogger<UnitController> logger/*, IUnitService service*/)
    {
        _logger = logger;
        //_service = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Unit> GetSingleUnit(Guid id)
    {
        return Ok();
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<Unit>> GetAllUnits()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<Unit> CreateNewUnit() // takes dto
    {
        return Ok();
    }

    [HttpPut]
    public ActionResult<Unit> EditUnit() // takes dto
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteUnit(Guid id)
    {
        return Ok();
    } 

}