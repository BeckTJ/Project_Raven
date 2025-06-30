using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using shared.DTO;

namespace Presentation.Controllers;

[Route("/VendorLot")]
[ApiController]

public class VendorLotController : ControllerBase
{
    private readonly IServiceManager _services;

    public VendorLotController(IServiceManager services)
    {
        _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vendorLot = await _services.VendorLotServices.GetAllVendorLots();
        return Ok(vendorLot);
    }
    [HttpGet("{VendorLotNumber}")]
    public async Task<IActionResult> GetVendorLotByLotNumber(string vendorLotNumber)
    {
        var rawMaterial = await _services.RawMaterialService.GetRawMaterialByVendorLot(vendorLotNumber);
        return Ok(rawMaterial);
    }
}