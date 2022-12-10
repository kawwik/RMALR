//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/79148/RiderProjects/Lab4/Lab4\lexis.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Lab4.Generated.Lexis {
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
public partial class lexisParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, TOKEN_NAME=3, REGEXP=4, QUOTE=5, WHITESPACES=6, NEWLINE=7;
	public const int
		RULE_start = 0, RULE_token = 1, RULE_patterns = 2, RULE_pattern = 3;
	public static readonly string[] ruleNames = {
		"start", "token", "patterns", "pattern"
	};

	private static readonly string[] _LiteralNames = {
		null, "':'", "';'", null, null, "'\"'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "TOKEN_NAME", "REGEXP", "QUOTE", "WHITESPACES", "NEWLINE"
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

	public override string GrammarFileName { get { return "lexis.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static lexisParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public lexisParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public lexisParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class StartContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(lexisParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public TokenContext[] token() {
			return GetRuleContexts<TokenContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public TokenContext token(int i) {
			return GetRuleContext<TokenContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(lexisParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(lexisParser.NEWLINE, i);
		}
		public StartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_start; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IlexisVisitor<TResult> typedVisitor = visitor as IlexisVisitor<TResult>;
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
			State = 22;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 8;
				Match(Eof);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 18;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==TOKEN_NAME) {
					{
					{
					State = 9;
					token();
					State = 13;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
					while (_la==NEWLINE) {
						{
						{
						State = 10;
						Match(NEWLINE);
						}
						}
						State = 15;
						ErrorHandler.Sync(this);
						_la = TokenStream.LA(1);
					}
					}
					}
					State = 20;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 21;
				Match(Eof);
				}
				break;
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
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TOKEN_NAME() { return GetToken(lexisParser.TOKEN_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public PatternsContext patterns() {
			return GetRuleContext<PatternsContext>(0);
		}
		public TokenContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_token; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IlexisVisitor<TResult> typedVisitor = visitor as IlexisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitToken(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TokenContext token() {
		TokenContext _localctx = new TokenContext(Context, State);
		EnterRule(_localctx, 2, RULE_token);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 24;
			Match(TOKEN_NAME);
			State = 25;
			Match(T__0);
			State = 26;
			patterns();
			State = 27;
			Match(T__1);
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
			IlexisVisitor<TResult> typedVisitor = visitor as IlexisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPatterns(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PatternsContext patterns() {
		PatternsContext _localctx = new PatternsContext(Context, State);
		EnterRule(_localctx, 4, RULE_patterns);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 30;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 29;
				pattern();
				}
				}
				State = 32;
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
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TOKEN_NAME() { return GetToken(lexisParser.TOKEN_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REGEXP() { return GetToken(lexisParser.REGEXP, 0); }
		public PatternContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_pattern; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IlexisVisitor<TResult> typedVisitor = visitor as IlexisVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPattern(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PatternContext pattern() {
		PatternContext _localctx = new PatternContext(Context, State);
		EnterRule(_localctx, 6, RULE_pattern);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 34;
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

	private static int[] _serializedATN = {
		4,1,7,37,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,1,0,1,0,1,0,5,0,12,8,0,10,0,12,
		0,15,9,0,5,0,17,8,0,10,0,12,0,20,9,0,1,0,3,0,23,8,0,1,1,1,1,1,1,1,1,1,
		1,1,2,4,2,31,8,2,11,2,12,2,32,1,3,1,3,1,3,0,0,4,0,2,4,6,0,1,1,0,3,4,36,
		0,22,1,0,0,0,2,24,1,0,0,0,4,30,1,0,0,0,6,34,1,0,0,0,8,23,5,0,0,1,9,13,
		3,2,1,0,10,12,5,7,0,0,11,10,1,0,0,0,12,15,1,0,0,0,13,11,1,0,0,0,13,14,
		1,0,0,0,14,17,1,0,0,0,15,13,1,0,0,0,16,9,1,0,0,0,17,20,1,0,0,0,18,16,1,
		0,0,0,18,19,1,0,0,0,19,21,1,0,0,0,20,18,1,0,0,0,21,23,5,0,0,1,22,8,1,0,
		0,0,22,18,1,0,0,0,23,1,1,0,0,0,24,25,5,3,0,0,25,26,5,1,0,0,26,27,3,4,2,
		0,27,28,5,2,0,0,28,3,1,0,0,0,29,31,3,6,3,0,30,29,1,0,0,0,31,32,1,0,0,0,
		32,30,1,0,0,0,32,33,1,0,0,0,33,5,1,0,0,0,34,35,7,0,0,0,35,7,1,0,0,0,4,
		13,18,22,32
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Lab4.Generated.Lexis
