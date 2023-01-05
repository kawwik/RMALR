using Lab4.Generated;
using Lab4.Lexis.Tokens;
using Lab4.Syntax.Parser.Builders;
using Lab4.Syntax.Parser.Interfaces;
using Lab4.Syntax.Rules;
using Lab4.Utils;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab4.Syntax.Parser;

public class ParserGenerator2 : IParserGenerator
{
    public string Generate(RMALRParser.StartContext tree, string grammarName)
    {
        var grammarVisitor = new GrammarVisitor2();
        var rules = grammarVisitor.GetAllRules(tree);

        var parserBuilder = new ParserBuilder(grammarName);

        foreach (var rule in rules)
        {
            parserBuilder.AddMethod(BuildRuleReadingMethod(rule));
        }

        return parserBuilder.ToString();
    }

    private MethodBuilder BuildRuleReadingMethod(NamedRule rule)
    {
        var methodBuilder = MethodBuilder.BuildParserMethod(rule.Name.Capitalize());
        methodBuilder.AddBodyStatements(ReadRule(rule.Rule));

        return methodBuilder;
    }

    private BodyBuilder ReadTokenRule(TokenRule tokenRule)
    {
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.AddTerminalNodeReading(tokenRule.TokenType);
        
        return bodyBuilder;
    }

    private BodyBuilder ReadNamedRule(NamedRule namedRule)
    {
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.AddNonTerminalNodeReading(namedRule.Name);
        
        return bodyBuilder;
    }

    private BodyBuilder ReadOptionsRule(OptionsRule optionsRule)
    {
        var switchBuilder = new SwitchBuilder();

        foreach (var option in optionsRule.Options.Where(x => x is not EmptyRule))
        {
            var first = option.First();
            var caseBuilder = new SwitchCaseBuilder();
            caseBuilder.AddLabels(first.ToArray());
            caseBuilder.AddStatements();

            switchBuilder.AddCase(caseBuilder);
        }

        if (!optionsRule.First().Contains(EmptyToken.TokenType))
            switchBuilder.AddDefaultThrow();

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.AddStatements(switchBuilder.GetSwitchStatement());
        return bodyBuilder;
    }

    private BodyBuilder ReadCompositeRule(CompositeRule compositeRule)
    {
        var bodyBuilder = new BodyBuilder();

        foreach (var rule in compositeRule.Rules)
        {
            bodyBuilder.Append(ReadRule(rule));
        }

        bodyBuilder.PopChildAddingStatement();
        return bodyBuilder;
    }

    private BodyBuilder ReadRule(Rule rule)
    {
        return rule switch
        {
            EmptyRule => new BodyBuilder(),
            TokenRule tokenRule => ReadTokenRule(tokenRule),
            NamedRule namedRule => ReadNamedRule(namedRule),
            OptionsRule optionsRule => ReadOptionsRule(optionsRule),
            CompositeRule compositeRule => ReadCompositeRule(compositeRule)
        };
    }
}