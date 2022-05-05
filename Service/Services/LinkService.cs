using System.Collections;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Services;

public class LinkService
{
    
    
    private readonly IRepository<Link> _linkRepository;

    public LinkService(IRepository<Link> linkRepository)
    {
        _linkRepository = linkRepository;
    }

    public ICollection<LinkDto> GetLinksByPerson(int personId)
    {
        var results = _linkRepository.Query.Where(l => l.PersonId == personId)
            .Select(l => (LinkDto)l).ToList();
        return results;
    }


    public bool PostLink(LinkDto link)
    {
        _linkRepository.Insert(link);
        return true;
    }
}