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
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public partial class RMALRParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, RULE_NAME=4, TOKEN_NAME=5, REGEXP=6, QUOTE=7, 
		SKIP_RULE=8, WHITESPACES=9, NEWLINE=10;
	public const int
		RULE_start = 0, RULE_rule = 1, RULE_rule_option = 2, RULE_rule_part = 3, 
		RULE_token = 4, RULE_patterns = 5, RULE_pattern = 6, RULE_lexer_rule = 7;
	public static readonly string[] ruleNames = {
		"start", "rule", "rule_option", "rule_part", "token", "patterns", "pattern", 
		"lexer_rule"
	};

	private static readonly string[] _LiteralNames = {
		null, "';'", "':'", "'->'", null, null, null, "'\"'", "'@skip'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "RULE_NAME", "TOKEN_NAME", "REGEXP", "QUOTE", 
		"SKIP_RULE", "WHITESPACES", "NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "RMALR.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static RMALRParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public RMALRParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public RMALRParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class StartContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(RMALRParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public TokenContext[] token() {
			return GetRuleContexts<TokenContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public TokenContext token(int i) {
			return GetRuleContext<TokenContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public RuleContext[] rule() {
			return GetRuleContexts<RuleContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public RuleContext rule(int i) {
			return GetRuleContext<RuleContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(RMALRParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(RMALRParser.NEWLINE, i);
		}
		public StartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_start; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStart(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StartContext start() {
		StartContext _localctx = new StartContext(Context, State);
		EnterRule(_localctx, 0, RULE_start);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==RULE_NAME || _la==TOKEN_NAME) {
				{
				{
				State = 18;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case TOKEN_NAME:
					{
					State = 16;
					token();
					}
					break;
				case RULE_NAME:
					{
					State = 17;
					rule();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				State = 20;
				Match(T__0);
				State = 24;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==NEWLINE) {
					{
					{
					State = 21;
					Match(NEWLINE);
					}
					}
					State = 26;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
				}
				State = 31;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 32;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RuleContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RULE_NAME() { return GetToken(RMALRParser.RULE_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Rule_optionContext rule_option() {
			return GetRuleContext<Rule_optionContext>(0);
		}
		public RuleContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rule; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRule(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public RuleContext rule() {
		RuleContext _localctx = new RuleContext(Context, State);
		EnterRule(_localctx, 2, RULE_rule);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 34;
			Match(RULE_NAME);
			State = 35;
			Match(T__1);
			State = 36;
			rule_option();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Rule_optionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public Rule_partContext[] rule_part() {
			return GetRuleContexts<Rule_partContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public Rule_partContext rule_part(int i) {
			return GetRuleContext<Rule_partContext>(i);
		}
		public Rule_optionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rule_option; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRule_option(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Rule_optionContext rule_option() {
		Rule_optionContext _localctx = new Rule_optionContext(Context, State);
		EnterRule(_localctx, 4, RULE_rule_option);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 38;
				rule_part();
				}
				}
				State = 41;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==RULE_NAME || _la==TOKEN_NAME );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Rule_partContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RULE_NAME() { return GetToken(RMALRParser.RULE_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TOKEN_NAME() { return GetToken(RMALRParser.TOKEN_NAME, 0); }
		public Rule_partContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rule_part; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRule_part(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Rule_partContext rule_part() {
		Rule_partContext _localctx = new Rule_partContext(Context, State);
		EnterRule(_localctx, 6, RULE_rule_part);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 43;
			_la = TokenStream.LA(1);
			if ( !(_la==RULE_NAME || _la==TOKEN_NAME) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TokenContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TOKEN_NAME() { return GetToken(RMALRParser.TOKEN_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public PatternsContext patterns() {
			return GetRuleContext<PatternsContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Lexer_ruleContext lexer_rule() {
			return GetRuleContext<Lexer_ruleContext>(0);
		}
		public TokenContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_token; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitToken(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TokenContext token() {
		TokenContext _localctx = new TokenContext(Context, State);
		EnterRule(_localctx, 8, RULE_token);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 45;
			Match(TOKEN_NAME);
			State = 46;
			Match(T__1);
			State = 47;
			patterns();
			State = 50;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__2) {
				{
				State = 48;
				Match(T__2);
				State = 49;
				lexer_rule();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PatternsContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PatternContext[] pattern() {
			return GetRuleContexts<PatternContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public PatternContext pattern(int i) {
			return GetRuleContext<PatternContext>(i);
		}
		public PatternsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_patterns; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPatterns(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PatternsContext patterns() {
		PatternsContext _localctx = new PatternsContext(Context, State);
		EnterRule(_localctx, 10, RULE_patterns);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 53;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 52;
				pattern();
				}
				}
				State = 55;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==TOKEN_NAME || _la==REGEXP );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PatternContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TOKEN_NAME() { return GetToken(RMALRParser.TOKEN_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REGEXP() { return GetToken(RMALRParser.REGEXP, 0); }
		public PatternContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_pattern; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPattern(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PatternContext pattern() {
		PatternContext _localctx = new PatternContext(Context, State);
		EnterRule(_localctx, 12, RULE_pattern);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 57;
			_la = TokenStream.LA(1);
			if ( !(_la==TOKEN_NAME || _la==REGEXP) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Lexer_ruleContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SKIP_RULE() { return GetToken(RMALRParser.SKIP_RULE, 0); }
		public Lexer_ruleContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_lexer_rule; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRMALRVisitor<TResult> typedVisitor = visitor as IRMALRVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLexer_rule(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Lexer_ruleContext lexer_rule() {
		Lexer_ruleContext _localctx = new Lexer_ruleContext(Context, State);
		EnterRule(_localctx, 14, RULE_lexer_rule);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 59;
			Match(SKIP_RULE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,10,62,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,1,0,1,0,3,0,19,8,0,1,0,1,0,5,0,23,8,0,10,0,12,0,26,9,0,5,0,28,8,0,
		10,0,12,0,31,9,0,1,0,1,0,1,1,1,1,1,1,1,1,1,2,4,2,40,8,2,11,2,12,2,41,1,
		3,1,3,1,4,1,4,1,4,1,4,1,4,3,4,51,8,4,1,5,4,5,54,8,5,11,5,12,5,55,1,6,1,
		6,1,7,1,7,1,7,0,0,8,0,2,4,6,8,10,12,14,0,2,1,0,4,5,1,0,5,6,59,0,29,1,0,
		0,0,2,34,1,0,0,0,4,39,1,0,0,0,6,43,1,0,0,0,8,45,1,0,0,0,10,53,1,0,0,0,
		12,57,1,0,0,0,14,59,1,0,0,0,16,19,3,8,4,0,17,19,3,2,1,0,18,16,1,0,0,0,
		18,17,1,0,0,0,19,20,1,0,0,0,20,24,5,1,0,0,21,23,5,10,0,0,22,21,1,0,0,0,
		23,26,1,0,0,0,24,22,1,0,0,0,24,25,1,0,0,0,25,28,1,0,0,0,26,24,1,0,0,0,
		27,18,1,0,0,0,28,31,1,0,0,0,29,27,1,0,0,0,29,30,1,0,0,0,30,32,1,0,0,0,
		31,29,1,0,0,0,32,33,5,0,0,1,33,1,1,0,0,0,34,35,5,4,0,0,35,36,5,2,0,0,36,
		37,3,4,2,0,37,3,1,0,0,0,38,40,3,6,3,0,39,38,1,0,0,0,40,41,1,0,0,0,41,39,
		1,0,0,0,41,42,1,0,0,0,42,5,1,0,0,0,43,44,7,0,0,0,44,7,1,0,0,0,45,46,5,
		5,0,0,46,47,5,2,0,0,47,50,3,10,5,0,48,49,5,3,0,0,49,51,3,14,7,0,50,48,
		1,0,0,0,50,51,1,0,0,0,51,9,1,0,0,0,52,54,3,12,6,0,53,52,1,0,0,0,54,55,
		1,0,0,0,55,53,1,0,0,0,55,56,1,0,0,0,56,11,1,0,0,0,57,58,7,1,0,0,58,13,
		1,0,0,0,59,60,5,8,0,0,60,15,1,0,0,0,6,18,24,29,41,50,55
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Lab4.Generated
