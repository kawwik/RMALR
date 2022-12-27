using Lab4.Syntax.Interfaces;
using Lab4.Syntax.Parser.Builders;
using Lab4.Syntax.Rules;
using Microsoft.CodeAnalysis;

namespace Lab4.Syntax.Parser;

public class ParserGenerator : IParserGenerator
{
    public string Generate(IReadOnlyCollection<NamedRule> rules)
    {
        var caseBuilder = new SwitchCaseBuilder();
        caseBuilder.AddLabels("Some1", "Some2", "Some3");
        caseBuilder.AddTerminalNodeReading("XorNode");
        caseBuilder.AddNonTerminalNodeReading("Zhopa");
        
        var switchBuilder = new SwitchBuilder();
        switchBuilder.AddCase(caseBuilder);
        switchBuilder.AddDefaultThrow();
        
        var methodBuilder = MethodBuilder.BuildParserMethod("And", switchBuilder.GetSwitchStatement());

        var parserBuilder = new ParserBuilder("Example");
        parserBuilder.AddMethod(methodBuilder);

        return parserBuilder.GetCompilationUnit().NormalizeWhitespace().ToString();
    }
}