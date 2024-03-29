﻿using RMALR.Syntax.Rules.BaseClasses;

namespace RMALR.Syntax.Rules;

public class OptionsRule : UnnamedRule
{
    public OptionsRule(params Rule[] options)
    {
        Options = options;
    }
    
    public Rule[] Options { get; }

    protected override HashSet<string> FirstInternal()
    {
        return Options.Aggregate(new HashSet<string>(), (set, rule) =>
        {
            set.UnionWith(rule.First());
            return set;
        });
    }
}