parser grammar RMALR_parser;

options { tokenVocab=RMALR_lexer; }

start: ((token | rule_definition) ';' NEWLINE*)* EOF;

// Grammar
rule_definition: IDENTIFIER attribute_list? returned_attributes? ':' rule_body;
rule_body: rule_option ('|' rule_option)*;
rule_option: rule_part+ action?;
rule_part
    : rule_invocation
    | TOKEN_NAME 
    | '(' rule_body ')'
    | rule_part ('?' | '+' | '*');

attribute_list: '[' attribute (',' attribute)* ']';
attribute: IDENTIFIER;

returned_attributes: RETURNS attribute_list;

rule_invocation: IDENTIFIER argument_list?;
argument_list: '[' argument (',' argument)* ']';
argument: '$'? IDENTIFIER ('.' IDENTIFIER);

action: '{' CODE '}';

// Lexis
token: TOKEN_NAME ':' patterns ('->' lexer_rule)?;
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

lexer_rule: SKIP_RULE;