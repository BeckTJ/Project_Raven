using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using shared.DTO;

namespace Presentation.Controllers;

[Route("RavenAPI/Material")]
[ApiController]

public class MaterialController : ControllerBase
{
    private readonly IServiceManager _services;

    public MaterialController(IServiceManager services)
    {
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materials = await _services.MaterialService.GetAllMaterial();
        return Ok(materials);
    }
    [HttpGet("{MaterialNumber:int}", Name = "MaterialByMaterialNumber")]
    public async Task<IActionResult> GetMaterialByMaterialNumber(int materialNumber)
    {
        var material = await _services.MaterialService.GetMaterialByMaterialNumber(materialNumber);
        return Ok(material);
    }
    [HttpPost]
    public IActionResult CreateMaterial([FromBody] MaterialDTO material)
    {
        _services.MaterialService.AddMaterial(material);
        return CreatedAtRoute("GetMaterialByMaterialNumber", new {materialNumber = material.MaterialNumber});
    }
}