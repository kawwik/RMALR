// using Lab4.Lexis.Lexers;
// using Lab4.Lexis.Matchers;
//
// namespace Lab4.Lexis.Examples;
//
// public enum TokenType
// {
//     Finish = 0,
//     TOKEN_NAME,
//     SOME_TOKEN,
// }
//
// public class ExampleTokenizer : TokenizerBase
// {
//     public ExampleTokenizer()
//     {
//         var TOKEN_NAME = new TokenMatcher(TokenType.TOKEN_NAME, new RegexMatcher("[A-Z][A-Za-z_]*"));
//         Matchers.Add(TOKEN_NAME);
//         var SOME_TOKEN = new TokenMatcher(TokenType.SOME_TOKEN, TOKEN_NAME, new RegexMatcher("[A-Z][A-Za-z_]*"));
//         Matchers.Add(SOME_TOKEN);
//     }
// }