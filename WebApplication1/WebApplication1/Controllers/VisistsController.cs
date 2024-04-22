using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controller;

[ApiController]
[Route("visits")]
public class VisitsController : ControllerBase
{
    private IMockDb _mockDb;

    public VisitsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        return Ok(_mockDb.GetVisitsForAnimal(animalId));
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _mockDb.AddVisit(visit);
        return Created($"visits/{visit.Id}", visit);
    }
}