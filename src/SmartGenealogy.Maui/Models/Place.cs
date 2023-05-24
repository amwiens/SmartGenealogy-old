using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Place : BaseEntity
{
    public Place() { }

    public Place(PlaceResponse response)
    {
        Id = response.Id;

        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }
}