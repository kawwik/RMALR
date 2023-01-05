using Lab4.Generated;
using Lab4.Syntax.Parser.Builders;
using Lab4.Syntax.Parser.Interfaces;

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
             // parserBuilder.AddMethod(BuildRuleReadingMethod(rule));
         }

         return parserBuilder.ToString();
     }
}