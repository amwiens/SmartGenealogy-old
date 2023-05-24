using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Person : ObservableObject
{
    public Person() { }

    public Person(PersonResponse response)
    {
        Id = response.Id;
        GivenName = response.GivenName;
        Surname = response.Surname;
        CreatedDate = response.CreatedDate;
        UpdatedDate = response.UpdatedDate;
    }

    public Guid Id { get; set; }

    public string GivenName { get; set; }

    public string Surname { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string Name => $"{GivenName} {Surname}";
}