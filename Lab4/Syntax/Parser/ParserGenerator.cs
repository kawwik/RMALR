using Lab4.Generated;
using Lab4.Lexis.Tokens;
using Lab4.Syntax.Parser.Builders;
using Lab4.Syntax.Parser.Interfaces;
using Lab4.Syntax.Rules;
using Lab4.Utils;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab4.Syntax.Parser;

public class ParserGenerator : IParserGenerator
{
    public string Generate(RMALRParser.StartContext tree, string grammarName)
    {
        var grammarVisitor = new GrammarVisitor();
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
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.AddStatements(ReadRule(rule.Payload));

        foreach (var attribute in rule.SynthesizedAttribute)
        {
            methodBuilder.AddVariableDefinition("dynamic", attribute);
        }

        methodBuilder.AddBodyStatements(bodyBuilder);
        methodBuilder.AddParameters(rule.InheritedAttributes.ToArray());
        
        return methodBuilder;
    }

    private StatementSyntax[] ReadTokenRule(TokenRule tokenRule)
    {
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.AddTerminalNodeReading(tokenRule.TokenType);
        bodyBuilder.PopChildAddingStatement();
        
        return bodyBuilder.GetStatements();
    }

    private StatementSyntax[] ReadInvocationRule(InvocationRule invocationRule)
    {
        var bodyBuilder = new BodyBuilder();

        var arguments = invocationRule.Arguments
            .Select(Microsoft.CodeAnalysis.CSharp.SyntaxFactory.IdentifierName)
            .ToList();
        
        bodyBuilder.AddNonTerminalNodeReading(invocationRule.NamedRule.Name.Capitalize(), arguments);
        bodyBuilder.PopChildAddingStatement();
        
        return bodyBuilder.GetStatements();
    }

    private StatementSyntax ReadOptionsRule(OptionsRule optionsRule)
    {
        var switchBuilder = new SwitchBuilder();

        foreach (var option in optionsRule.Options.Where(x => x is not EmptyRule))
        {
            var first = option.First();
            var caseBuilder = new SwitchCaseBuilder();
            caseBuilder.AddLabels(first.ToArray());
            caseBuilder.AddStatements(ReadRule(option));

            switchBuilder.AddCase(caseBuilder);
        }

        if (!optionsRule.First().Contains(EmptyToken.TokenType))
            switchBuilder.AddDefaultThrow();

        return switchBuilder.GetSwitchStatement();
    }

    private StatementSyntax[] ReadCompositeRule(CompositeRule compositeRule)
    {
        var bodyBuilder = new BodyBuilder();

        foreach (var rule in compositeRule.Rules)
        {
            bodyBuilder.AddStatements(ReadRule(rule));
        }

        return bodyBuilder.GetStatements();
    }

    private StatementSyntax[] ReadRule(Rule rule)
    {
        return rule switch
        {
            EmptyRule => Array.Empty<StatementSyntax>(),
            TokenRule tokenRule => ReadTokenRule(tokenRule),
            InvocationRule invocationRule => ReadInvocationRule(invocationRule),
            OptionsRule optionsRule => new[] { ReadOptionsRule(optionsRule) },
            CompositeRule compositeRule => ReadCompositeRule(compositeRule)
        };
    }
}