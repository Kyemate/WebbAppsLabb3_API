using Domain.Models;

namespace Service.Models;

public record PersonDto(int Id, string Name, string Phone, ICollection<InterestDto>? Interests)
{
    public PersonDto(string name, string phone, ICollection<InterestDto>? interests)
        : this(0, name, phone, interests) {}


    public static implicit operator PersonDto(Person person) =>
        new (person.Id, person.Name,person.Phone, person.Interests?.Select(p =>(InterestDto)p).ToList());

    public static implicit operator Person(PersonDto person) =>
        new(person.Id, person.Name, person.Phone, person.Interests?.Select(p => (Interest)p).ToList());
}