using System.Text;
using Lab4.Generated.Lexis;

namespace Lab4.Lexis;

public class LexisVisitor : lexisBaseVisitor<string>
{
    private const string _indent = "    ";
    
    public override string VisitStart(lexisParser.StartContext context)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("using Lab4.Lexis.Lexers;\nusing Lab4.Lexis.Matchers;\n\n");

        stringBuilder.Append("namespace Lab4.Lexis.Examples;\n\n");

        var tokenNames = context.token().Select(x => x.TOKEN_NAME().Symbol.Text).ToArray();
        
        BuildTokenTypeEnum(stringBuilder, tokenNames);

        stringBuilder.Append($"public class ExampleTokenizer : TokenizerBase<TokenType>\n" +
                             $"{{\n{_indent}public ExampleTokenizer()\n{_indent}{{\n");
        
        context.token().Aggregate(stringBuilder, (sb, token) => sb.Append(VisitToken(token)));
        
        stringBuilder.Append($"{_indent}}}\n");
        stringBuilder.Append("}");

        return stringBuilder.ToString();
    }

    private void BuildTokenTypeEnum(StringBuilder stringBuilder, string[] tokenNames)
    {
        stringBuilder.Append("public enum TokenType\n{\n");

        foreach (var tokenName in tokenNames)
        {
            stringBuilder.Append($"{_indent}{tokenName},\n");
        }

        stringBuilder.Append("}\n\n");
    }
    
    public override string VisitToken(lexisParser.TokenContext context)
    {
        var tokenName = context.TOKEN_NAME().Symbol.Text;

        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"{_indent}{_indent}var {tokenName} = new TokenMatcher<TokenType>(TokenType.{tokenName}, ");
        foreach (var pattern in context.patterns().pattern())
        {
            if (pattern.TOKEN_NAME() is not null)
            {
                stringBuilder.Append(pattern.TOKEN_NAME().Symbol.Text + ", ");
            }

            if (pattern.REGEXP() is not null)
            {
                stringBuilder.Append($"new RegexMatcher(@{pattern.REGEXP()}), ");
            }
        }

        stringBuilder.Length -= 2;
        stringBuilder.Append(");" + "\n");

        stringBuilder.Append($"{_indent}{_indent}Matchers.Add({tokenName});" + "\n");

        return stringBuilder.ToString();
    }
}