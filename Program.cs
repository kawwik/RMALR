// See https://aka.ms/new-console-template for more information

using Lab4.Lexis;

var helloMatcher = new RegexMatcher("hello");
var worldMatcher = new RegexMatcher("World");

var helloWorldMatcher = new TokenMatcher(new List<IMatcher> {helloMatcher, worldMatcher});

Console.WriteLine(helloWorldMatcher.GetMatchingOffset("helloWorld"));