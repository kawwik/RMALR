﻿namespace RMALR.Lexis.Tokens;

public interface IToken
{
    public string Type { get; }
    
    public string Value { get; }
    
    public int Length { get; }
}