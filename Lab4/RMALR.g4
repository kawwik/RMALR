grammar RMALR;

start: ((token | rule) ';' NEWLINE*)* EOF;

// Grammar
rule: RULE_NAME ':' rule_option; // Задел на несколько options
rule_option: rule_part+;
rule_part: RULE_NAME | TOKEN_NAME;

// Lexis
token: TOKEN_NAME ':' patterns ('->' lexer_rule)?;
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

lexer_rule: SKIP_RULE;

// Tokens
RULE_NAME: [a-z][A-Za-z_]*;

TOKEN_NAME: [A-Z][A-Za-z_]*;
REGEXP: QUOTE .+? QUOTE;

QUOTE: '"';

SKIP_RULE: '@skip';

WHITESPACES: ' '+ -> skip;
NEWLINE: '\r'? '\n';