namespace UCondoAccountTree.Application.Configuration;

public class NotFoundException : Exception
{
    public NotFoundException(string details) : base(details)
    {
        Details = details;
    }

    public string Details { get; }
}
