namespace Service.Services;

public class InterestService
{
    private readonly IRepository<Interest> _interestRepository;
    public InterestService(IRepository<Interest> interestRepository)
    {
        _interestRepository = interestRepository;
    }
    public ICollection<InterestDto> GetInterestsByPerson(int personId)
    {
        var results = _interestRepository.Query.Where(i => i.PersonId == personId)
            .Select(i => (InterestDto)i).ToList();
        return results;
    }

    public bool PostInterest(InterestDto interest)
    {
        _interestRepository.Insert(interest);
        return true;
    }
}