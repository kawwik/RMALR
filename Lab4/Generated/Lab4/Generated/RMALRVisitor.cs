//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/79148/RiderProjects/Lab4/Lab4\RMALR.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Lab4.Generated {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="RMALRParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IRMALRVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] RMALRParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.rule_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_definition([NotNull] RMALRParser.Rule_definitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.rule_body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_body([NotNull] RMALRParser.Rule_bodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.rule_option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_option([NotNull] RMALRParser.Rule_optionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.rule_part"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_part([NotNull] RMALRParser.Rule_partContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.attribute_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute_list([NotNull] RMALRParser.Attribute_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] RMALRParser.AttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.returned_attributes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturned_attributes([NotNull] RMALRParser.Returned_attributesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.rule_invocation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_invocation([NotNull] RMALRParser.Rule_invocationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.argument_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument_list([NotNull] RMALRParser.Argument_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument([NotNull] RMALRParser.ArgumentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.token"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken([NotNull] RMALRParser.TokenContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.patterns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPatterns([NotNull] RMALRParser.PatternsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.pattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPattern([NotNull] RMALRParser.PatternContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALRParser.lexer_rule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexer_rule([NotNull] RMALRParser.Lexer_ruleContext context);
}
} // namespace Lab4.Generated
