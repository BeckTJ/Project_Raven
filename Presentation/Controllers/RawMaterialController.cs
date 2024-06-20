
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using shared.DTO;

namespace Presentation.Controllers;

[Route("RavenAPI/RawMaterial")]
[ApiController]

public class RawMaterialController : ControllerBase
{
    private readonly IServiceManager _services;
    public RawMaterialController(IServiceManager services)
    {
        _services = services;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rawMaterial = await _services.RawMaterialService.GetAllRawMaterial();
        return Ok(rawMaterial);
    }
    [HttpGet("{materialNumber:int}", Name = "RawMaterialByMaterialNumber")]
    public async Task<IActionResult> GetRawMaterialByMaterialNumber(int materialNumber)
    {
        var rawMaterial = await _services.RawMaterialService.GetRawMaterialByMaterialNumber(materialNumber);
        return Ok(rawMaterial);
    }
    [HttpGet("{ProductLotNumber}", Name = "RawMaterialByProductId")]
    public async Task<IActionResult> GetRawMaterialByProductId(string productLotNumber)
    {
        var rawMaterial = await _services.RawMaterialService.GetRawMateriaByProductLotNumber(productLotNumber);
        return Ok(rawMaterial);
    }
    [HttpPost]
    public async Task<IActionResult> CreateRawMaterial([FromBody] CreateRawMaterialDTO rawMaterial)
    {
        if (rawMaterial is null)
            return BadRequest();
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var material = await _services.RawMaterialService.CreateRawMaterial(rawMaterial);

        return CreatedAtRoute("RawMaterialByProductId", new { material.ProductLotNumber }, material);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateRawMaterial([FromBody] RawMaterialDTO rawMaterial)
    {
        await _services.RawMaterialService.UpdateRawMaterial(rawMaterial);
        return CreatedAtRoute("RawMaterialByProductId", new { rawMaterial.ProductLotNumber }, rawMaterial);
    }
    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteRawMaterial(string productId)
    {
        await _services.RawMaterialService.DeleteRawMaterial(productId);
        return NoContent();
    }
}