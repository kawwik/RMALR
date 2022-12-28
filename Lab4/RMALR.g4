grammar RMALR;

start: ((token | rule_definition) ';' NEWLINE*)* EOF;

// Grammar
rule_definition: RULE_NAME ':' rule_body;
rule_body: rule_option ('|' rule_option)*;
rule_option: rule_part+;
rule_part
    : RULE_NAME | TOKEN_NAME 
    | '(' rule_body ')'
    | rule_part (QUESTION_MARK | PLUS | MULTIPLY);

// Lexis
token: TOKEN_NAME ':' patterns ('->' lexer_rule)?;
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

lexer_rule: SKIP_RULE;

// Tokens
RULE_NAME: [a-z][A-Za-z_]*;

TOKEN_NAME: [A-Z][A-Za-z_]*;
REGEXP: QUOTE .+? QUOTE;

QUESTION_MARK: '?';
PLUS: '+';
MULTIPLY: '*';

QUOTE: '"';

SKIP_RULE: '@skip';

WHITESPACES: ' '+ -> skip;
NEWLINE: '\r'? '\n';