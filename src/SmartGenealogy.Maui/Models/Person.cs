using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Models;

public class Person : BaseEntity
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

    public string GivenName { get; set; }

    public string Surname { get; set; }

    public string Name => $"{GivenName} {Surname}";
}