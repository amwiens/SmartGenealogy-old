using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Address : BaseEntity
{
    public Address() { }

    public Address(AddressResponse response)
    {
        Id = response.Id;

        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }
}