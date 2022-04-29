using Domain.Models;

namespace Service.Models;

public record InterestDto(int Id, int PersonId, string Title, string Description, ICollection<LinkDto>? Links)
{
    public static implicit operator InterestDto(Interest interest) =>
        new(interest.Id, interest.PersonId, interest.Title, interest.Description, interest.Links?.Select(l => (LinkDto)l).ToList());

    public static implicit operator Interest(InterestDto interestDto) =>
        new(/*interestDto.Id,*/ interestDto.PersonId, interestDto.Title, interestDto.Description, interestDto.Links?.Select(l => (Link)l).ToList());

}