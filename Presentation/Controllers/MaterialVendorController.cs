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
        var vendor = await _services.MaterialVendorService.GetAllVendors();
        return Ok(vendor);
    }

    [HttpGet("{MaterialNumber}", Name = "VendorByMaterialNumber")]
    public async Task<IActionResult> GetMaterialVendorByMaterialNumber(int materialNumber)
    {
        var vendor = await _services.MaterialVendorService.GetVendorByMaterialNumber(materialNumber);
        return Ok(vendor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMaterialVendor([FromBody] MaterialVendorDTO vendor)
    {
        if (vendor is null)
            return BadRequest("Material is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var rawMaterial = await _services.MaterialVendorService.AddMaterialVendor(vendor);
        return CreatedAtRoute("VendorByMaterialNumber", new { rawMaterial.MaterialNumber }, rawMaterial);
    }
    [HttpDelete("{materialNumber}")]
    public async Task<IActionResult> DeleteMaterialVendor(int materialNumber)
    {
        await _services.MaterialVendorService.DeleteMaterialVendor(materialNumber);
        return NoContent();
    }
    [HttpPut("{materialNumber}")]
    public async Task<IActionResult> UpdateMaterialVendor(int materialNumber, [FromBody] MaterialVendorDTO vendorToUpdate)
    {
        if (vendorToUpdate is null)
            return BadRequest("Vendor is null");
        await _services.MaterialVendorService.UpdateMaterialVendor(materialNumber, vendorToUpdate);
        return NoContent();
    }
}