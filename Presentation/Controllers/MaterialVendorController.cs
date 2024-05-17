using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
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
    [HttpGet("{MaterialNumber:int}")]
    public async Task<IActionResult> GetMaterialVendorByMaterialNumber(int materialNumber)
    {
        var vendor = await _services.MaterialVendor.GetVendorByMaterialNumber(materialNumber);
        return Ok(vendor);
    }
}