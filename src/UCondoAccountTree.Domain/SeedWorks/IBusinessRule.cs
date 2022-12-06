namespace UCondoAccountTree.Domain.SeedWorks;

public interface IBusinessRule
{
    string Message { get; }
    bool IsBroken();
}
