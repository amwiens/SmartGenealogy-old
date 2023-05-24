using SmartGenealogy.Maui.Models.Responses;

namespace SmartGenealogy.Maui.Services;

public class PeopleService
{
    private bool firstLoad = true;

    public PeopleService()
    {

    }

    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        var peopleResponse = await TryGetAsync("people");
        return peopleResponse?.Select(response => new Person(response));
    }

    private Task<IEnumerable<PersonResponse>> TryGetAsync(string path)
    {
        if (firstLoad)
        {
            firstLoad = false;

            return Task.Run(() => TryGetImplementationAsync(path));
        }

        return TryGetImplementationAsync(path);
    }

    private async Task<IEnumerable<PersonResponse>> TryGetImplementationAsync(string path)
    {
        var people = new List<PersonResponse>();
        people.Add(new PersonResponse { Id = Guid.NewGuid(), GivenName = "Aaron", Surname = "Wiens", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
        people.Add(new PersonResponse { Id = Guid.NewGuid(), GivenName = "Addison", Surname = "Wiens", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
        people.Add(new PersonResponse { Id = Guid.NewGuid(), GivenName = "Chloe", Surname = "Wiens", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

        return people?.ToList();
    }
}