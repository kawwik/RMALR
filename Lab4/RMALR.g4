grammar RMALR;

start: ((token | rule_definition) ';' NEWLINE*)* EOF;

// Grammar
rule_definition: IDENTIFIER attribute_list? returned_attributes? ':' rule_body;
rule_body: rule_option ('|' rule_option)*;
rule_option: rule_part+;
rule_part
    : rule_invocation
    | TOKEN_NAME 
    | '(' rule_body ')'
    | rule_part (QUESTION_MARK | PLUS | MULTIPLY);

attribute_list: '[' attribute (',' attribute)* ']';
attribute: IDENTIFIER;

returned_attributes: 'returns' attribute_list;

rule_invocation: IDENTIFIER argument_list?;
argument_list: '[' argument (',' argument)* ']';
argument: IDENTIFIER;

// Lexis
token: TOKEN_NAME ':' patterns ('->' lexer_rule)?;
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

lexer_rule: SKIP_RULE;

// Tokens
IDENTIFIER: [a-z][A-Za-z_]*;

TOKEN_NAME: [A-Z][A-Za-z_]*;
REGEXP: QUOTE .+? QUOTE;

QUESTION_MARK: '?';
PLUS: '+';
MULTIPLY: '*';

QUOTE: '"';

SKIP_RULE: '@skip';

WHITESPACES: ' '+ -> skip;
NEWLINE: '\r'? '\n';