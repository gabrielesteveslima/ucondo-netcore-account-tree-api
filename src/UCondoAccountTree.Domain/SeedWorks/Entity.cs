namespace UCondoAccountTree.Domain.SeedWorks;

public abstract class Entity
{
    public DateTime CreateAt { get; protected set; }

    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
