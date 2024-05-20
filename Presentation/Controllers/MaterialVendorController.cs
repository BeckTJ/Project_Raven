using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using shared.DTO;

namespace Presentation.Controllers;

[Route("RavenAPI/MaterialVendor")]
[ApiController]
public class MaterialVendorController : ControllerBase
{
    private readonly IServiceManager _services;

    public MaterialVendorController(IServiceManager services)
    {
        _services = services;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vendor = await _services.MaterialVendor.GetAllVendors();
        return Ok(vendor);
    }

    [HttpGet("{MaterialNumber:int}", Name = "VendorByMaterialNumber")]
    public async Task<IActionResult> GetMaterialVendorByMaterialNumber(int materialNumber)
    {
        var vendor = await _services.MaterialVendor.GetVendorByMaterialNumber(materialNumber);
        return Ok(vendor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMaterialVendor([FromBody] MaterialVendorDTO vendor)
    {
        if (vendor is null)
            return BadRequest("Material is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var rawMaterial = await _services.MaterialVendor.AddMaterialVendor(vendor);
        return CreatedAtRoute("VendorByMaterialNumber", new { rawMaterial.MaterialNumber }, rawMaterial);
    }
    [HttpDelete("{materialNumber:int}")]
    public async Task<IActionResult> DeleteMaterialVendor(int materialNumber)
    {
        await _services.MaterialVendor.DeleteMaterialVendor(materialNumber);
        return NoContent();
    }
    [HttpPut("{materialNumber:int}")]
    public async Task<IActionResult> UpdateMaterialVendor(int materialNumber, [FromBody] MaterialVendorDTO vendorToUpdate)
    {
        if (vendorToUpdate is null)
            return BadRequest("Vendor is null");
        await _services.MaterialVendor.UpdateMaterialVendor(materialNumber, vendorToUpdate);
        return NoContent();
    }
}