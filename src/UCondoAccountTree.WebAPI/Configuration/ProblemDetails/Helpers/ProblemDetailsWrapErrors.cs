namespace UCondoAccountTree.WebAPI.Configuration.ProblemDetails.Helpers;

public class ProblemDetailsWrapErrors
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int? Code { get; set; }
    public string Type { get; set; }

    public static IEnumerable<ProblemDetailsWrapErrors> GetErrors(Exception exception)
    {
        return new[] { new ProblemDetailsWrapErrors { Description = exception.Message } };
    }
}
