using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Task : BaseEntity
{
    public Task() { }

    public Task(TaskResponse response)
    {
        Id = response.Id;

        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }
}