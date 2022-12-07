namespace UCondoAccountTree.Application.Configuration;

using System.Text.RegularExpressions;

public static class GuidValidator
{
    private static readonly Regex isGuid = new(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

    public static bool IsGuid(string candidate)
    {
        if (candidate != null)
        {
            if (isGuid.IsMatch(candidate))
            {
                return true;
            }
        }

        return false;
    }
}
