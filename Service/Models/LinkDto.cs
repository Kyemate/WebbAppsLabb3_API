using Domain.Models;

namespace Service.Models;

public record LinkDto(int PersonId, int InterestId, string Url)
{
    public static implicit operator LinkDto(Link link) =>
        new(link.PersonId, link.InterestId, link.Url);

    public static implicit operator Link(LinkDto linkDto) =>
        new(linkDto.PersonId, linkDto.InterestId, linkDto.Url);
}