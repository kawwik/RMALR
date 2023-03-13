using RMALR.Syntax.Rules.BaseClasses;

namespace RMALR.Syntax.Rules;

public class ActionRule : UnnamedRule
{
    public ActionRule(Rule payload, string actionCode)
    {
        Payload = payload;
        ActionCode = actionCode;
    }

    public Rule Payload { get; }
    
    public string ActionCode { get; }
    
    protected override HashSet<string> FirstInternal() => Payload.First();
}