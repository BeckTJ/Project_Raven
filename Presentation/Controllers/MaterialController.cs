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
    public async Task<IActionResult> CreateMaterial([FromBody] MaterialDTO material)
    {
        if (material is null)
            return BadRequest("MaterialDTO is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var hpMaterial = await _services.MaterialService.AddMaterial(material);

        return CreatedAtRoute("MaterialByMaterialNumber", new { hpMaterial.MaterialNumber }, hpMaterial);
    }
    [HttpDelete("{materialNumber:int}")]
    public async Task<IActionResult> DeleteMaterial(int materialNumber)
    {
        await _services.MaterialService.DeleteMaterial(materialNumber);

        return NoContent();
    }
    [HttpPut("{materialNumber:int}")]
    public async Task<IActionResult> UpdateMaterial(int materialNumber, [FromBody] MaterialDTO materialToUpdate)
    {
        if (materialToUpdate is null)
            return BadRequest("Material is Null");

        await _services.MaterialService.UpdateMaterial(materialNumber, materialToUpdate);
        return NoContent();
    }
}