namespace SmartGenealogy.Maui.Models;

public class BaseEntity : ObservableObject
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}