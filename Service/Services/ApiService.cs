using System.Collections;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Services;

public class ApiService
{
    private readonly IRepository<Person> _personRepository;
    private readonly IRepository<Interest> _interestRepository;
    private readonly IRepository<Link> _linkRepository;

    public ApiService(IRepository<Person> personRepository, IRepository<Interest> interestRepository, IRepository<Link> linkRepository)
    {
        _personRepository = personRepository;
        _interestRepository = interestRepository;
        _linkRepository = linkRepository;
    }

    public IEnumerable<PersonDto>? GetPersons(PageParameters pageParameters, string? name = null, bool? includeAllData = false)
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

        return query.Select(p => (PersonDto) p).ToList();
    }

    public ICollection<InterestDto> GetInterestsByPerson(int personId)
    {
        var results = _interestRepository.Query.Where(i => i.PersonId == personId)
            .Select(i => (InterestDto)i).ToList();
        return results;
    }

    public ICollection<LinkDto> GetLinksByPerson(int personId)
    {
        var results = _linkRepository.Query.Where(l => l.PersonId == personId)
            .Select(l => (LinkDto)l).ToList();
        return results;
    }

    public bool PostInterest(InterestDto interest)
    {
        _interestRepository.Insert(interest);
        return true;
    }

    public bool PostLink(LinkDto link)
    {
        _linkRepository.Insert(link);
        return true;
    }
}