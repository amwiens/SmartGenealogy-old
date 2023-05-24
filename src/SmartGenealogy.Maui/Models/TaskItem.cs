using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class TaskItem : BaseEntity
{
    public TaskItem() { }

    public TaskItem(TaskItemResponse response)
    {
        Id = response.Id;

        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }
}