// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Lab4.Generated.Lexis;
using Lab4.Lexis;

var lexer = new lexisLexer(CharStreams.fromString(@"TOKEN_NAME: ""[A-Z][A-Za-z_]*"";
SOME_TOKEN: TOKEN_NAME ""[A-Z][A-Za-z_]*"";"));
var parser = new lexisParser(new CommonTokenStream(lexer));

var lexisVisitor = new LexisVisitor();
var result = lexisVisitor.Visit(parser.start());

Console.WriteLine(result);
