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
    [HttpGet("{MaterialNumber:int}", Name ="VendorByMaterialNumber")]
    public async Task<IActionResult> GetMaterialVendorByMaterialNumber(int materialNumber)
    {
        var vendor = await _services.MaterialVendor.GetVendorByMaterialNumber(materialNumber);
        return Ok(vendor);
    }
    [HttpPost]
    public IActionResult CreateMaterialVendor([FromBody] MaterialVendorDTO vendor)
    {
        _services.MaterialVendor.AddMaterialVendor(vendor);
        return CreatedAtRoute("VendorByMaterialNumber", new {materialNumber = vendor.MaterialNumber});
    }
}