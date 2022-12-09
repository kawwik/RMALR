namespace Lab4.Lexis;

public class TokenMatcherBase : IMatcher
{
    private readonly List<IMatcher> _matchers;

    public TokenMatcherBase(List<IMatcher> matchers)
    {
        _matchers = matchers;
    }

    public int GetMatchingOffset(string str)
    {
        int currentIndex = 0;

        foreach (var matcher in _matchers)
        {
            var offset = matcher.GetMatchingOffset(str[currentIndex..]);
            if (offset == 0)
                return 0;

            currentIndex += offset;
        }

        return currentIndex > str.Length ? 0 : currentIndex;
    }
}