namespace Service.Services;

public class PersonService
{
    private readonly IRepository<Person> _personRepository;
    public PersonService(IRepository<Person> personRepository)
    {
        _personRepository = personRepository;
    }

    public IEnumerable<PersonDto> GetPersons(PageParameters pageParameters, string? name = null, bool? includeAllData = false)
    {
        var query = name is null ? _personRepository.Query
                .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                .Take(pageParameters.PageSize)
            : _personRepository.Query.Where(p => p.Name.Contains(name)).Select(p => p)
                .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                .Take(pageParameters.PageSize);


        if (includeAllData is true)
            query = query.Include(x => x.Interests)!
                .ThenInclude(x => x.Links);

        return query.Select(p => (PersonDto)p).ToList();
    }
}