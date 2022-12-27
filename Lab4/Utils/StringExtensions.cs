namespace Lab4.Utils;

public static class StringExtensions
{
    public static string Capitalize(this string str) => 
        string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1));
}