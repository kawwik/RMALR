namespace Lab4.Syntax.Rules;

public abstract class Rule
{
    private HashSet<string>? _first;
    
    /// <summary>
    /// Вычисляет множество FIRST для правила
    /// </summary>
    /// <returns>Множество типов токенов, содержащихся в FIRST</returns>
    public HashSet<string> First() => _first ??= FirstInternal();

    protected abstract HashSet<string> FirstInternal();
}