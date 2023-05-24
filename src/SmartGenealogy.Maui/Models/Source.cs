using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Source : BaseEntity
{
    public Source() { }

    public Source(SourceResponse response)
    {
        Id = response.Id;

        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }
}