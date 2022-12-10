using System.Text;
using Lab4.Generated.Lexis;

namespace Lab4.Lexis;

public class LexisVisitor : lexisBaseVisitor<string>
{
    public override string VisitStart(lexisParser.StartContext context)
    {
        var stringBuilder = new StringBuilder();

        context.token().Aggregate(stringBuilder, (sb, token) => sb.Append(VisitToken(token) + "\n"));

        return stringBuilder.ToString();
    }

    public override string VisitToken(lexisParser.TokenContext context)
    {
        var tokenName = context.TOKEN_NAME().Symbol.Text;

        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"var {tokenName} = new TokenMatcher(");
        foreach (var pattern in context.patterns().pattern())
        {
            if (pattern.TOKEN_NAME() is not null)
            {
                stringBuilder.Append(pattern.TOKEN_NAME().Symbol.Text + ", ");
            }

            if (pattern.REGEXP() is not null)
            {
                stringBuilder.Append($"new RegexMatcher({pattern.REGEXP()}), ");
            }
        }

        stringBuilder.Length -= 2;
        stringBuilder.Append(");");

        return stringBuilder.ToString();
    }
}