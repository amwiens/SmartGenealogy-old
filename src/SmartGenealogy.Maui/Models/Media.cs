using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Media : BaseEntity
{
    public Media() { }

    public Media(MediaResponse response)
    {
        Id = response.Id;
        FileName = response.FileName;
        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }

    public string FileName { get; set; }
}