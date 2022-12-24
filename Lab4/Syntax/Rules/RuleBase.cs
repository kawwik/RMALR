﻿namespace Lab4.Syntax.Rules;

public abstract class RuleBase
{
    /// <summary>
    /// Вычисляет множество FIRST для правила
    /// </summary>
    /// <returns>Множество типов токенов, содержащихся в FIRST</returns>
    public abstract HashSet<string> First();
}