namespace SmartGenealogy.Maui.Models.Responses;

public class PersonResponse
{
    public Guid Id { get; set; }

    public string GivenName { get; set; }

    public string Surname { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}