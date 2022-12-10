using Antlr4.Runtime;
using Lab4.Generated.Lexis;
using Lab4.Lexis;
using Lab4.Lexis.Examples;

var lexer = new lexisLexer(CharStreams.fromString("WordToken: \"\\w+\";\r\nSPACES: \" +\" -> skip;"));
var parser = new lexisParser(new CommonTokenStream(lexer));

var lexisVisitor = new LexisVisitor();
var result = lexisVisitor.Visit(parser.start());

var tokenizer = new ExampleTokenizer();
var tokenStream = tokenizer.GetTokenStream("word word");

var token = tokenStream.NextToken();
token = tokenStream.NextToken();

Console.WriteLine(result);
