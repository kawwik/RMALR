﻿namespace RMALR.Syntax.Rules.BaseClasses;

public abstract class Rule
{
    private HashSet<string>? _first;
    
    /// <summary>
    /// Вычисляет множество FIRST для правила
    /// </summary>
    /// <returns>Множество типов токенов, содержащихся в FIRST</returns>
    public HashSet<string> First() => (_first ??= FirstInternal()).ToHashSet();

    protected abstract HashSet<string> FirstInternal();
}