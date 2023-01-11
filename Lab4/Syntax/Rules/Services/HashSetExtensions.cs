namespace Lab4.Syntax.Rules.Services;

public static class HashSetExtensions
{
    public static bool UnionWith<T>(this HashSet<T> hashSet, HashSet<T> other)
    {
        var result = false;
        foreach (var element in other)
        {
            result |= hashSet.Add(element);
        }

        return result;
    }
}