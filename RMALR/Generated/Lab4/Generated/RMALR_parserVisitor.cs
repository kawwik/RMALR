//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/79148/RiderProjects/RMALR/RMALR\RMALR_parser.g4 by ANTLR 4.10.1

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
/// by <see cref="RMALR_parser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IRMALR_parserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] RMALR_parser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.rule_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_definition([NotNull] RMALR_parser.Rule_definitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.rule_body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_body([NotNull] RMALR_parser.Rule_bodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.rule_option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_option([NotNull] RMALR_parser.Rule_optionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.rule_part"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_part([NotNull] RMALR_parser.Rule_partContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.attribute_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute_list([NotNull] RMALR_parser.Attribute_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] RMALR_parser.AttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.returned_attributes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturned_attributes([NotNull] RMALR_parser.Returned_attributesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.rule_invocation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRule_invocation([NotNull] RMALR_parser.Rule_invocationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.argument_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument_list([NotNull] RMALR_parser.Argument_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument([NotNull] RMALR_parser.ArgumentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAction([NotNull] RMALR_parser.ActionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.token"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToken([NotNull] RMALR_parser.TokenContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.patterns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPatterns([NotNull] RMALR_parser.PatternsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.pattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPattern([NotNull] RMALR_parser.PatternContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RMALR_parser.lexer_rule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexer_rule([NotNull] RMALR_parser.Lexer_ruleContext context);
}
} // namespace RMALR.Generated
