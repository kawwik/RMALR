parser grammar RMALR_parser;

options { tokenVocab=RMALR_lexer; }

start: ((token | rule_definition) SEMICOLON NEWLINE*)* EOF;

// Grammar
rule_definition: IDENTIFIER attribute_list? returned_attributes? COLON rule_body;
rule_body: rule_option (OPTION_MARK rule_option)*;
rule_option: rule_part+;
rule_part
    : rule_invocation
    | TOKEN_NAME 
    | LEFT_PAR rule_body RIGHT_PAR
    | rule_part (QUESTION_MARK | PLUS | MULTIPLY);

attribute_list: LEFT_SQUARE attribute (COMMA attribute)* RIGHT_SQUARE;
attribute: IDENTIFIER;

returned_attributes: RETURNS attribute_list;

rule_invocation: IDENTIFIER argument_list?;
argument_list: LEFT_SQUARE argument (COMMA argument)* RIGHT_SQUARE;
argument: IDENTIFIER;

// Lexis
token: TOKEN_NAME COLON patterns (ARROW lexer_rule)?;
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

lexer_rule: SKIP_RULE;