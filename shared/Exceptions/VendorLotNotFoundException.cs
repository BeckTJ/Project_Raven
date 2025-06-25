using System.Runtime.Serialization;

[Serializable]
public sealed class VendorLotNotFoundException : Exception
{
    public VendorLotNotFoundException()
    {
    }

    public VendorLotNotFoundException(string? vendorLot)
        : base($"The Vendor Lot {vendorLot} was not found")
    {
    }

    public VendorLotNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}