using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;

namespace Services;

/*
    User inputs raw material vendor lot infomation->
        the system needs to verify if it is a new or previously input vendor lot
        determine if the lot needs to be sampled
        add or update the vendor lot in the database
        output the required sample and the product lot number
*/
internal sealed class RawMaterialInputServices : IRawMaterialInputServices
{
    private readonly IRepoManager _repo;
    private readonly IMapper _mapper;

    public RawMaterialInputServices(IRepoManager repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }
    //Need to add sample submit
    public async Task<RawMaterialSampleDTO> CreateRawMaterial(CreateRawMaterialDTO rawMaterial)
    {
        VendorLotDTO vendorLot = new()
        {
            VendorLotNumber = rawMaterial.VendorLotNumber,
            Quantity = rawMaterial.Quantity,
            BatchNumber = rawMaterial.BatchNumber,
            MaterialNumber = rawMaterial.MaterialNumber
        };

        var requiredSample = await GetRequiredSample(vendorLot);

        var lot = await _repo.VendorLotRepo.GetVendorLotByLotNumber(rawMaterial.VendorLotNumber);

        RawMaterialInputDTO rawMaterialDrum = new()
        {
            ProductLotNumber = await _repo.RawMaterialLotNumber.UpdateLotNumber(await _repo.RawMaterialLotNumber.GetProductLotNumber(rawMaterial.MaterialNumber)),
            ContainerNumber = rawMaterial.ContainerNumber,
            IssueDate = DateTime.Now.Date,
            NetWeight = rawMaterial.NetWeight,
            MaterialNumber = rawMaterial.MaterialNumber,
            LotId = lot.LotId
        };

        AddRawMaterialDrum(rawMaterialDrum);
        await _repo.Save();
        var rawMaterialToSample = _mapper.Map<RawMaterialDTO>(await _repo.RawMaterial.GetRawMaterialByProductLotNumber(rawMaterialDrum.ProductLotNumber));

        return new RawMaterialSampleDTO
        {
            RawMaterialDrum = rawMaterialToSample,
            SampleRequired = requiredSample
        };
    }
    private async Task<RequiredSampleDTO> GetRequiredSample(VendorLotDTO vendorLot)
    {
        RequiredSampleDTO sampleRequired = new();
        // check vendor lot
        var vendor = await _repo.VendorRepo.GetVendorByMaterialNumberWithVendorLots(vendorLot.MaterialNumber);
        var requiredSample = await _repo.SampleRequiredRepo.GetSampleRequiredByMaterialNumber(vendor.ParentMaterialNumber);

        if (vendor.VendorName == "Reclaim")
        {
            sampleRequired = _mapper.Map<RequiredSampleDTO>(requiredSample.First(s => s.ProductType == "Reclaim"));
        }
        else
        {
            var lot = _mapper.Map<VendorLotDTO>(vendor.MaterialVendorLots.FirstOrDefault(l => l.VendorLotNumber == vendorLot.VendorLotNumber));
            if (lot == null)
            {
                AddVendorLot(vendorLot);
                sampleRequired = _mapper.Map<RequiredSampleDTO>(requiredSample.First(s => s.ProductType == "New"));
            }
            else
            {
                lot.Quantity += vendorLot.Quantity;
                UpdateVendorLot(lot);

                var required = _mapper.Map<RequiredSampleDTO>(requiredSample.First(s => s.ProductType == "Old"));

                if (required != null)
                {
                    sampleRequired = required;
                }
            }
        }
        return sampleRequired;
    }
    private void AddRawMaterialDrum(RawMaterialInputDTO rawMaterial)
    {
        _repo.RawMaterial.CreateRawMaterial(_mapper.Map<RawMaterialLog>(rawMaterial));

    }
    private void AddVendorLot(VendorLotDTO vendorLot)
    {
        _repo.VendorLotRepo.AddVendorLot(_mapper.Map<MaterialVendorLot>(vendorLot));

    }
    private void UpdateVendorLot(VendorLotDTO vendorLot)
    {
        _repo.VendorLotRepo.UpdateVendorLot(_mapper.Map<MaterialVendorLot>(vendorLot));

    }
}