
namespace Domain.Models;

public class Person
{
    private Person(){}
    public Person(int id, string name, string phone, ICollection<Interest>? interests = null)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Interests = interests;
    }
    public Person( string name, string phone, ICollection<Interest>? interests = null)
    {
        Name = name;
        Phone = phone;
        Interests = interests;
    }

    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public ICollection<Interest>? Interests { get; set; }

}