﻿namespace Lab4.Lexis.Tokens;

public class Token : IToken
{
    public Token(string value, TokenType type)
    {
        Value = value;
        Type = type;
    }

    public string Value { get; }
    public TokenType Type { get; }
}